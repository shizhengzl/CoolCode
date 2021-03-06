﻿using Core.EntityFramework;
using Core.EntityFramework.GeneratorClass;
using Core.UsuallyCommon;
using Core.UsuallyCommon.Database;
using EnvDTE;
using EnvDTE80;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Core.UsuallyCommon.Extensions;

namespace Core.GeneratorWindows
{
    public partial class Geneartor : Form
    {
        public void Connection()
        {
            GeneratorLogin gLogin = new GeneratorLogin();
            gLogin.ShowDialog();

            if (gLogin.DialogResult == DialogResult.Cancel)
            {
                Close();
                return;
            }

            var settings = db.DataBaseSetting.OrderByDescending(x => x.LastModifyTime).First();
            // set connection
            DatabaseHelper.connectionString = $"Server={settings.Address};uid={settings.Account};pwd={settings.Password};database=master;";

            LoadDataBaseTree();
        }

        public string DefaultGeneratorPath = "C:\\GeneratorFile";

        public GeneratorContext db { get; set; }

        public Geneartor(DTE2 applicationObject = null)
        {
            InitializeComponent();
            ApplicationVsHelper._applicationObject = applicationObject;
            GeneratorInit();
        }

        public Geneartor()
        {
            InitializeComponent();
            GeneratorInit();

            datatypegrid.DataSource = db.Controls.ToList();

            datatypegrid.AutoGenerateColumns = true;
            this.datatypegrid.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
        }

        public void GeneratorInit()
        {
            db = new GeneratorContext();
            GeneratorText.ConfigFile = GetPath.CSharpColor;
            SnippetContext.ConfigFile = GetPath.CSharpColor;
            textSql.ConfigFile = GetPath.CSharpColor;
            LoadGeneartorVariable();
            InitTreeSource();
            ResreshSnippet();
            Connection();
            LoadSystetmSQL();
        }

        private void LoadSystetmSQL()
        {
            dataGridSystemSQL.DataSource = db.GeneratorSQL.ToList();
        }

        #region data source
        private void LoadTableColumn(TreeNode tn)
        {
            if (tn.Text == "DataSource")
                return;

            var listColumn = (List<Column>)tn.Tag;
            var dbname = listColumn.FirstOrDefault().DataBaseName;
            listColumn = LoadTableColumn(dbname, tn.Text);

            dataSourceGrids.DataSource = listColumn;
            dataSourceGrids.AutoGenerateColumns = true;
            dataSourceGrids.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }

        private void EndEdit(List<Column> sources)
        {
            dataSourceGrids.EndEdit();
            try
            {
                for (int i = 0; i < sources.Count; i++)//得到总行数并在之内循环    
                {
                    Column col = sources[i];
                    PropertyInfo[] piar = col.GetType().GetProperties();
                    foreach (PropertyInfo pi in piar)
                    {
                        col.GetType().GetProperty(pi.Name).SetValue(col, Convert.ChangeType(dataSourceGrids.Rows[i].Cells[pi.Name].Value, dataSourceGrids.Rows[i].Cells[pi.Name].ValueType), null);
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private List<Column> LoadTableColumn(string databasename, string tablename)
        {
            var Columns = SQLString.Columns.ToStringExtension();
            var generatorsql = db.GeneratorSQL.FirstOrDefault(x => x.Name == Columns);
            var dt = DatabaseHelper.ExecuteQuery(string.Format(generatorsql.SQLContext, databasename, tablename)).Tables[0];
            return dt.ToList<Column>();
        }

        private void InitTreeSource()
        {
            treeSource.Nodes.Clear();
            treeSource.ImageList = imageListcollection;
            TreeNode node = new TreeNode();
            node.Tag = DBTypeClass.ServerAddress;
            node.Text = "DataSource";
            node.ImageIndex = (int)ImageIndex.DataBaseAddress;

            treeSource.Nodes.Add(node);
        }

        private void treeSource_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
                return;
            LoadTableColumn(e.Node);
        }

        private void toolSourceClear_Click(object sender, EventArgs e)
        {
            InitTreeSource();
        }

        private void toolGenerator_Click(object sender, EventArgs e)
        {
            if (treeSource.Nodes[0].Nodes.Count < 0)
            {
                GeneratorText.Text = "请选择数据源.";
                return;
            }

            if (treesnippet.Nodes[0].Nodes.Count < 0)
            {
                GeneratorText.Text = "请创建模版.";
                return;
            }

            var sources = treeSource.Nodes[0].Nodes;
            var snippets = treesnippet.Nodes[0].Nodes;

            bool IsExists = File.Exists(DefaultGeneratorPath);
            if (!IsExists)
                Directory.CreateDirectory(DefaultGeneratorPath);
            foreach (var source in sources)
            {
                List<Column> columns = (source as TreeNode).Tag as List<Column>;
                var dbname = columns.FirstOrDefault().DataBaseName;
                var tablename = columns.FirstOrDefault().TableName;

                foreach (var sp in snippets)
                {
                    var snippet = (GeneratorSnippet)((sp as TreeNode).Tag);
                    if (!snippet.IsEnabled)
                        continue;

                    if (snippet.IsSelectColumn)
                    {
                        ColumnSelectForm selct = new ColumnSelectForm(tablename, columns);
                        selct.ShowDialog();
                    }

                    bool isdefalepath = string.IsNullOrEmpty(snippet.GeneratorPath);
                    var tabledeclare = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.TableName.ToString()).ReplaceDeclare;
                    string filename = string.IsNullOrEmpty(snippet.GeneratorFileName) ? (tablename + ".cs") : snippet.GeneratorFileName.Replace(tabledeclare, tablename);
                    string projectPath = VsProjectPath + "\\" + snippet.ProjectName;
                    string namespaces = string.IsNullOrEmpty(snippet.ProjectName) ? string.Empty : projectPath.GetFileFirstDirectory();
                    string generatorFloder = isdefalepath ?
                        DefaultGeneratorPath :
                        (VsProjectPath + snippet.GeneratorPath);

                    var variablesnamespaces = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.NameSpace.ToString()).ReplaceDeclare;
                    var variablestablename = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.TableName.ToString()).ReplaceDeclare;


                    #region 工程选项
                    ProjectItem projitem = null;
                    Project proj = null;
                    try
                    {
                        projitem = (ProjectItem)ApplicationVsHelper.GetProjItemByUrl(VsProjectPath + snippet.ProjectName);
                    }
                    catch
                    {
                        proj = (Project)ApplicationVsHelper.GetProjItemByUrl(VsProjectPath + snippet.ProjectName);
                    }
                    #endregion

                    string code = GeneratorCode(snippet, columns);
                    code = code.Replace(variablesnamespaces, namespaces);
                    code = code.Replace(variablestablename, tablename);
                    db.GeneratorReplace.ToList().ForEach(x => code = code.Replace(x.ReplaceDeclare, string.Empty));

                    string filefullpath = generatorFloder + "\\" + filename;
                    bool isexists = DirectoryFileHelper.IsFindFile(generatorFloder, filename);
                    if (!isexists)
                    {
                        if (!string.IsNullOrEmpty(snippet.ProjectName))
                            ApplicationVsHelper.CheckOut(projectPath);
                        IoHelper.CreateFile(filefullpath, code);

                        if (proj != null || projitem != null)
                        {
                            if (proj == null)
                                projitem.SubProject.ProjectItems.AddFromFile(filefullpath);
                            else
                                proj.ProjectItems.AddFromFile(filefullpath);
                        }
                    }
                    else
                    {
                        if (!isdefalepath)
                            ApplicationVsHelper.CheckOut(filefullpath);
                        IoHelper.FileOverWrite(filefullpath, code);
                    }

                    ApplicationVsHelper.Open(filefullpath);
                    ApplicationVsHelper.EditFormatDocument(filefullpath);
                }
            }
            MessageBox.Show("执行完成！");
        }
        #endregion
        #region database tree 

        public void LoadDataBaseTree()
        {
            treedb.Nodes.Clear();
            treedb.ImageList = imageListcollection;
            TreeNode root = new TreeNode($"{db.DataBaseSetting.OrderByDescending(x => x.LastModifyTime).First().Address}");
            root.Tag = DBTypeClass.ServerAddress;
            SetTreeImages(root);

            string GetDB = SQLString.GetDB.ToStringExtension();
            string DbSQL = db.GeneratorSQL.FirstOrDefault(x => x.Name == GetDB).SQLContext;

            DataSet Ds = DatabaseHelper.ExecuteQuery(DbSQL);
            var DataTableList = Ds.Tables[1].ToList<TableDescription>();
            var DataBaseList = Ds.Tables[0].ToList<DataBaseDescription>();
            foreach (var item in DataBaseList)
            {
                string databasename = db.DataBaseSetting.OrderByDescending(x => x.LastModifyTime).First().DataBase;
                if (!string.IsNullOrEmpty(databasename) && item.DataBaseName != databasename)
                {
                    continue;
                }

                TreeNode dbnode = new TreeNode(item.DataBaseName);
                dbnode.Tag = DBTypeClass.DataBase;
                SetTreeImages(dbnode);
                root.Nodes.Add(dbnode);

                var dtlist = DataTableList.Where(x => x.DataBaseName == item.DataBaseName).OrderBy(x => x.TableName);
                TreeNode tabletn = new TreeNode("Tables");
                tabletn.Tag = DBTypeClass.Floder;
                SetTreeImages(tabletn);
                dbnode.Nodes.Add(tabletn);

                TreeNode viewtn = new TreeNode("Views");
                viewtn.Tag = DBTypeClass.Floder;
                SetTreeImages(viewtn);
                dbnode.Nodes.Add(viewtn);

                TreeNode producttn = new TreeNode("Products");
                producttn.Tag = DBTypeClass.Floder;
                SetTreeImages(producttn);
                dbnode.Nodes.Add(producttn);
                foreach (var dt in dtlist)
                {
                    TreeNode dtn = new TreeNode(dt.TableName);


                    switch (dt.Type.ToUpper().Trim())
                    {
                        case "U":
                            dtn.Tag = DBTypeClass.Table;
                            tabletn.Nodes.Add(dtn);
                            break;
                        case "P":
                            dtn.Tag = DBTypeClass.Procduct;
                            producttn.Nodes.Add(dtn);
                            break;
                        case "V":
                            dtn.Tag = DBTypeClass.View;
                            viewtn.Nodes.Add(dtn);
                            break;
                    }
                    SetTreeImages(dtn);
                }
            }
            treedb.Nodes.Add(root);
        }

        private void SetTreeImages(TreeNode tn)
        {
            DBTypeClass dc = (DBTypeClass)tn.Tag;

            switch (dc)
            {
                case DBTypeClass.ServerAddress:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.DataBaseAddress;
                    break;
                case DBTypeClass.DataBase:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.DataBase;
                    break;
                case DBTypeClass.Table:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.Table;
                    break;
                case DBTypeClass.View:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.Table;
                    break;
                case DBTypeClass.Procduct:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.Table;
                    break;
                default:
                    tn.ImageIndex = tn.SelectedImageIndex = (int)ImageIndex.Floder;
                    break;
            }
        }

        private void tooldbrefresh_Click(object sender, EventArgs e)
        {
            LoadDataBaseTree();
        }
        private void treedb_AfterCheck(object sender, TreeViewEventArgs e)
        {
            if (e.Action != TreeViewAction.Unknown)
            {
                SetNodeCheckStatus(e.Node, e.Node.Checked);
                SetNodeStyle(e.Node);
            }
        }
        private void SetNodeCheckStatus(TreeNode tn, bool Checked)
        {
            if (tn == null) return;
            foreach (TreeNode tnChild in tn.Nodes)
            {
                tnChild.Checked = Checked;
                SetNodeCheckStatus(tnChild, Checked);
            }
            DBTypeClass tyc = (DBTypeClass)tn.Tag;
            if (tyc == DBTypeClass.Table || tyc == DBTypeClass.View || tyc == DBTypeClass.Procduct)
            {
                if (tn.Checked)
                {
                    if (treeSource.Nodes[0].Nodes.Find(tn.Text, true).Count() == 0)
                    {
                        dataSourceGrids.DataSource = LoadTableColumn(tn.Parent.Parent.Text, tn.Text);
                        treeSource.Nodes[0].Nodes.Add(new TreeNode()
                        {
                            Name = tn.Text,
                            Text = tn.Text,
                            ImageIndex = (int)ImageIndex.Table,
                            SelectedImageIndex = (int)ImageIndex.Table,
                            Tag = dataSourceGrids.DataSource
                        });
                    }
                }
                else
                {
                    if (treeSource.Nodes[0].Nodes.Find(tn.Text, true).Count() > 0)
                    {
                        treeSource.Nodes[0].Nodes.Remove(treeSource.Nodes[0].Nodes.Find(tn.Text, true).FirstOrDefault());
                    }
                }
            }
        }

        private void SetNodeStyle(TreeNode Node)
        {
            int nNodeCount = 0;
            if (Node.Nodes.Count != 0)
            {
                foreach (TreeNode tnTemp in Node.Nodes)
                {
                    if (tnTemp.Checked == true)
                        nNodeCount++;
                }

                if (nNodeCount == Node.Nodes.Count)
                {
                    Node.Checked = true;
                    //Node.ExpandAll();
                    Node.ForeColor = Color.Black;
                }
                else if (nNodeCount == 0)
                {
                    Node.Checked = false;
                    //Node.Collapse();
                    Node.ForeColor = Color.Black;
                }
                else
                {
                    Node.Checked = true;
                    Node.ForeColor = Color.Gray;
                }
            }
            //当前节点选择完后，判断父节点的状态，调用此方法递归。  
            if (Node.Parent != null)
                SetNodeStyle(Node.Parent);
        }
        private void treedb_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            SetTreeImages(e.Node);
            if (e.Node == null)
                return;
            treeSource.ExpandAll();
        }
        #endregion 

        #region variables
        public void LoadGeneartorVariable()
        {
            db = new GeneratorContext();
            var replace = db.GeneratorReplace.OrderBy(x => x.ReplaceType).ToList();
            var dt = replace.ToDataTable<GeneratorReplace>();
            dataVariables.DataSource = dt;
            dataVariables.AutoGenerateColumns = true;
            dataVariables.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
        }
        #endregion

        #region tree 
        private void SnippetPath_DropDown(object sender, EventArgs e)
        {
            try
            {
                if (ApplicationVsHelper._applicationObject == null)
                    return;

                string url = ApplicationVsHelper._applicationObject.Solution.FullName;
                if (string.IsNullOrEmpty(url) || SnippetPath.Nodes.Count > 0)
                    return;

                FileInfo file = new FileInfo(url);
                SnippetPath.ImageList = imageListcollection;
                TreeNode root = new TreeNode();
                root.Text = file.Directory.Name;
                root.Tag = file.Directory.FullName;
                root.ImageIndex = root.SelectedImageIndex = (int)ImageIndex.Solution;
                foreach (Project project in ApplicationVsHelper._applicationObject.Solution.Projects)
                {
                    if (project.FullName.IndexOf(".exe") > 0)
                        continue;
                    TreeNode chldNode = new TreeNode();
                    if (project.UniqueName.IndexOf(".csproj") < 0)
                    {
                        // add float
                        chldNode.Text = project.Name;
                        chldNode.Tag = project.FullName;
                        chldNode.ImageIndex = chldNode.SelectedImageIndex = (int)ImageIndex.Floder;
                        // add proj
                        foreach (ProjectItem item in project.ProjectItems)
                        {
                            if (item.SubProject == null || item.SubProject.UniqueName == null)
                                continue;
                            bool isFloder = item.SubProject != null && item.SubProject.ProjectItems != null;
                            TreeNode tn = new TreeNode();
                            tn.Text = item.SubProject == null ? item.Name : item.SubProject.Name;
                            tn.ToolTipText = item.SubProject.UniqueName.GetFileDirectory();
                            tn.Tag = item.SubProject.UniqueName;//.Replace("\\" + item.SubProject.Name + ".csproj", "");
                            tn.ImageIndex = tn.SelectedImageIndex = isFloder ? (int)ImageIndex.Floder : (int)ImageIndex.Project;
                            //string floder 
                            string floder = item.SubProject.FullName.Replace("\\" + item.SubProject.Name + ".csproj", "");
                            if (!string.IsNullOrEmpty(floder))
                                GetFiles(floder, tn);
                            if (isFloder)
                                CheckChild(item.SubProject.ProjectItems, tn);
                            chldNode.Nodes.Add(tn);
                        }
                    }
                    else
                    {
                        chldNode.Text = project.Name;
                        chldNode.ToolTipText = project.UniqueName.GetFileDirectory();
                        chldNode.Tag = project.UniqueName.Replace("..\\", ""); // tag->proj 
                        chldNode.ImageIndex = chldNode.SelectedImageIndex = (int)ImageIndex.Project;

                        if (project.ProjectItems != null)
                            CheckChild(project.ProjectItems, chldNode);
                        string floder = project.FullName.Replace("\\" + project.Name + ".csproj", "");
                        if (!string.IsNullOrEmpty(floder))
                            GetFiles(floder, chldNode);
                    }

                    root.Nodes.Add(chldNode);
                }

                //GetFiles(file.Directory.FullName, root);
                SnippetPath.Nodes.Add(root);
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提示LoadComboTree" + ex.Message);
            }
        }

        // 递归子节点
        public void CheckChild(ProjectItems projectitems, TreeNode fathernode)
        {
            foreach (ProjectItem item in projectitems)
            {
                if (item.SubProject == null || item.SubProject.UniqueName == null)
                    continue;
                bool isFloder = item.SubProject != null && item.SubProject.ProjectItems != null;
                TreeNode tn = new TreeNode();
                tn.Text = item.SubProject == null ? item.Name : item.SubProject.Name;
                tn.ToolTipText = item.SubProject.UniqueName.GetFileDirectory();
                tn.Tag = item.SubProject.UniqueName;//.Replace("\\" + item.SubProject.Name + ".csproj", "");
                tn.ImageIndex = tn.SelectedImageIndex = isFloder ? (int)ImageIndex.Floder : (int)ImageIndex.Project;

                //string floder 
                string floder = item.SubProject.FullName.Replace("\\" + item.SubProject.Name + ".csproj", "");
                if (!string.IsNullOrEmpty(floder))
                    GetFiles(floder, tn);
                if (isFloder)
                    CheckChild(item.SubProject.ProjectItems, tn);
                fathernode.Nodes.Add(tn);
            }
        }

        // 获取文件
        private void GetFiles(string filePath, TreeNode node)
        {
            if (!System.IO.Directory.Exists(filePath))
                return;
            try
            {
                DirectoryInfo folder = new DirectoryInfo(filePath);
                FileInfo[] chldFiles = folder.GetFiles("*.*");
                foreach (FileInfo chlFile in chldFiles)
                {
                    // 处理文件在配置问题
                    //if (FileType != null && !FileType.Contains(chlFile.Extension))
                    //    continue;

                    TreeNode chldNode = new TreeNode();
                    chldNode.Text = chlFile.Name;
                    chldNode.ToolTipText = chlFile.FullName.Replace(VsProjectPath, string.Empty);
                    chldNode.Tag = node.Tag;
                    chldNode.ImageIndex = this.IsFileReturnFlag(chlFile.Extension);
                    chldNode.SelectedImageIndex = chldNode.ImageIndex;
                    node.Nodes.Add(chldNode);
                }
                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chldFolder in chldFolders)
                {
                    TreeNode chldNode = new TreeNode();
                    chldNode.ImageIndex = 2;
                    chldNode.Tag = node.Tag; //chldFolder.FullName.Replace(VsProjectPath, "");
                    chldNode.Text = chldFolder.Name;
                    chldNode.ToolTipText = chldFolder.FullName.Replace(VsProjectPath, string.Empty);
                    node.Nodes.Add(chldNode);
                    GetFiles(chldFolder.FullName, chldNode);
                }
            }
            catch (System.Exception ex)
            {
                MessageBox.Show("提示GetFiles" + ex.Message);
            }

        }

        // 返回项目树的图片
        private int IsFileReturnFlag(string lastName)
        {
            int result = 2;
            switch (lastName)
            {
                case ".sln":
                    result = (int)ImageIndex.Solution;
                    break;
                case ".csproj":
                    result = (int)ImageIndex.Project;
                    break;
                case ".aspx":
                    result = (int)ImageIndex.Aspx;
                    break;
                case ".cs":
                    result = (int)ImageIndex.Csharp;
                    break;
                case ".js":
                    result = (int)ImageIndex.JavaScript;
                    break;
                case ".config":
                    result = (int)ImageIndex.Config;
                    break;
                case ".xml":
                    result = (int)ImageIndex.Config;
                    break;
                default:
                    result = (int)ImageIndex.Other;
                    break;
            }
            return result;
        }

        public string VsProjectPath
        {
            get
            {
                try
                {
                    return
                        ApplicationVsHelper._applicationObject.Solution.FileName.Substring(0,
                        ApplicationVsHelper._applicationObject.Solution.FileName.LastIndexOf('\\')) + "\\";
                }
                catch
                {
                    return string.Empty;
                }
            }
        }

        #endregion

        #region snippet 
        private void btnsnippetsave_Click(object sender, EventArgs e)
        {
            bool isSelect = SnippetPath.SelectedNode != null;
            var name = SnippetName.Text.Trim();
            var filename = SnippetFileName.Text.Trim();

            var filepath = isSelect ? SnippetPath.SelectedNode.ToolTipText.ToStringExtension() : string.Empty;
            string projectname = isSelect ? SnippetPath.SelectedNode.Tag.ToStringExtension() : string.Empty;


            bool ismergin = SnippetIsMergin.Checked;
            bool isappend = SnippetIsAppend.Checked;
            bool autofind = SnippetAutoFind.Checked;
            bool isenabled = SnippetIsEnabled.Checked;

            bool isselectcolumn = SnippetIsSelectColumn.Checked;
            bool iFloder = ckIsFloder.Checked;

            string context = SnippetContext.Text;
            Int32 fatherId = txtFatherId.Text.ToInt32();

            var isupdate = db.GeneratorSnippet.FirstOrDefault(x => x.Name == name);
            if (isupdate == null)
            {
                isupdate = new GeneratorSnippet();
                db.GeneratorSnippet.Add(isupdate);
            }

            isupdate.AutoFind = autofind;
            isupdate.IsMergin = ismergin;
            isupdate.IsEnabled = isenabled;
            isupdate.IsAppend = isappend;
            isupdate.Name = name;
            isupdate.GeneratorFileName = filename;
            isupdate.GeneratorPath = isupdate == null ? filepath : (isSelect ? filepath : isupdate.GeneratorPath);
            isupdate.ProjectName = isupdate == null ? projectname : (isSelect ? projectname : isupdate.ProjectName);
            isupdate.Context = context;
            isupdate.IsSelectColumn = isselectcolumn;
            isupdate.IsFloder = iFloder;
            isupdate.FatherId = fatherId;
            db.SaveChanges();

            ResreshSnippet();
        }
        private void toolsnippetrefresh_Click(object sender, EventArgs e)
        {
            ResreshSnippet();
        }
        private void ResreshSnippet()
        {
            var datasnippets = db.GeneratorSnippet.OrderBy(x => x.GeneratorFileName).ToList();
            //if (datasnippet.Rows.Count == 0)
            //    return;
            var dt = datasnippets.ToDataTable<GeneratorSnippet>();
            datasnippet.DataSource = dt;
            datasnippet.AutoGenerateColumns = true;
            datasnippet.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;

            LoadSnippetTree();
        }
        private void toolsnippetdelete_Click(object sender, EventArgs e)
        {
            var selectrows = datasnippet.SelectedRows.Count;
            if (selectrows == 0)
                return;
            var index = datasnippet.SelectedRows[0].Index;

            var data = db.GeneratorSnippet.OrderBy(x => x.GeneratorFileName).ToList().Skip(index).Take(1).FirstOrDefault();

            db.GeneratorSnippet.Remove(data);

            db.SaveChanges();

            ResreshSnippet();
        }
        private void toolsnippetupdate_Click(object sender, EventArgs e)
        {
            var selectrows = datasnippet.SelectedRows.Count;
            if (selectrows == 0)
                return;
            var index = datasnippet.SelectedRows[0].Index;

            var data = db.GeneratorSnippet.OrderBy(x => x.GeneratorFileName).ToList().Skip(index).Take(1).FirstOrDefault();

            SnippetAutoFind.Checked = data.AutoFind;
            SnippetIsMergin.Checked = data.IsMergin;
            SnippetIsEnabled.Checked = data.IsEnabled;
            SnippetIsAppend.Checked = data.IsAppend;
            SnippetName.Text = data.Name;
            SnippetFileName.Text = data.GeneratorFileName;
            SnippetPath.Text = data.GeneratorPath;
            SnippetContext.Text = data.Context;
            SnippetIsSelectColumn.Checked = data.IsSelectColumn;
            txtFatherId.Text = data.FatherId.ToStringExtension();
            ckIsFloder.Checked = data.IsFloder;
        }
        private void LoadSnippetTree()
        {
            treesnippet.Nodes.Clear();
            treesnippet.ImageList = imageListcollection;
            TreeNode allModel = new TreeNode();
            allModel.Text = "All Model";
            treesnippet.Nodes.Add(allModel);


            var allList = db.GeneratorSnippet.OrderBy(x => x.Id);
            var list = allList.Where(x => x.FatherId == 0).OrderByDescending(x => x.IsEnabled);

            foreach (var x in list)
            {
                var childNodes = new TreeNode()
                {
                    Text = x.Name,
                    ImageIndex = (x.IsFloder ? (int)ImageIndex.Floder : (x.IsEnabled ? (int)ImageIndex.Yes : (int)ImageIndex.Wrong)),
                    SelectedImageIndex = (x.IsFloder ? (int)ImageIndex.Floder : (x.IsEnabled ? (int)ImageIndex.Yes : (int)ImageIndex.Wrong)),
                    Tag = x
                };
                allModel.Nodes.Add(childNodes);

                allList.Where(y => y.FatherId == x.Id).OrderByDescending(z =>
                  z.IsEnabled).ToList().ForEach(u => childNodes.Nodes.Add(
                      new TreeNode()
                      {
                          Text = u.Name,
                          ImageIndex = (u.IsEnabled ? (int)ImageIndex.Yes : (int)ImageIndex.Wrong),
                          SelectedImageIndex = (u.IsEnabled ? (int)ImageIndex.Yes : (int)ImageIndex.Wrong),
                          Tag = u
                      }
                      ));
            }
            treesnippet.ExpandAll();
        }
        private void treesnippet_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            string message = string.Empty;
            var snippet = (GeneratorSnippet)e.Node.Tag;
            if (snippet == null)
                message = "没有模版！";
            if (treeSource.Nodes[0].Nodes.Count == 0)
                message = "请选择表！";
            if (!string.IsNullOrEmpty(message))
            {
                GeneratorText.Text = message;
                return;
            }
            var tree = treeSource.SelectedNode;
            if (tree == null)
                tree = treeSource.Nodes[0].Nodes[0];
            List<Column> columns = new List<Column>();
            EndEdit(dataSourceGrids.DataSource as List<Column>);
            columns = dataSourceGrids.DataSource as List<Column>;
            string dbname = columns.FirstOrDefault().DataBaseName;
            string tableName = columns.FirstOrDefault().TableName;
            tree.Tag = columns;
            if (snippet.IsSelectColumn)
            {
                ColumnSelectForm selct = new ColumnSelectForm(tableName, columns);
                selct.ShowDialog();
            }
            var generatorCode = GeneratorCode(snippet, columns);

            string projectPath = VsProjectPath + "\\" + snippet.ProjectName;
            string namespaces = string.IsNullOrEmpty(snippet.ProjectName) ? string.Empty : projectPath.GetFileFirstDirectory();

            var variablesnamespaces = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.NameSpace.ToString()).ReplaceDeclare;
            var variablestablename = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.TableName.ToString()).ReplaceDeclare;

            generatorCode = generatorCode.Replace(variablesnamespaces, namespaces);
            generatorCode = generatorCode.Replace(variablestablename, tableName);
            db.GeneratorReplace.ToList().ForEach(x => generatorCode = generatorCode.Replace(x.ReplaceDeclare, string.Empty));

            GeneratorText.Text = generatorCode;
        }
        private string GeneratorCode(GeneratorSnippet gs, List<Column> columns)
        {
            var starts = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == "Starts").ReplaceDeclare;
            var ends = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == "Ends").ReplaceDeclare;

            var generatorCode = gs.Context;
            int length = generatorCode.Length;
            int startNumber = (length - generatorCode.Replace(starts, "").Length) / starts.Length;

            string Keys = string.Empty;
            string Wheres = string.Empty;
            var RKeys = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.Keys.ToString());
            var RWheres = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.Where.ToString());
            Keys = string.Empty;
            Wheres = " Where ";
            bool isfirstkey = true;
            foreach (var c in columns)
            {

                if (c.IsPrimaryKey)
                {
                    Keys += ((isfirstkey) ? " " : " , ") + c.ColumnName;
                    Wheres += (isfirstkey ? " " : " AND ") + c.ColumnName + " =@" + c.ColumnName;
                    isfirstkey = false;
                }
            }
            var columnsnippet = db.GeneratorReplace.Where(x => x.ReplaceType == ReplaceType.Snippet).ToList();

            for (int i = 0; i < startNumber; i++)
            {
                StringBuilder sb = new StringBuilder();
                int startIndex = generatorCode.IndexOf(starts);
                if (startIndex < 0)
                    continue;
                int lastIndex = generatorCode.IndexOf(ends);
                string repleceContext = generatorCode.Substring(startIndex, lastIndex - startIndex + starts.Length);//.Replace(starts,string.Empty).Replace(ends,string.Empty);


                var existscsharptype = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceType == ReplaceType.CsharpType && repleceContext.Contains(x.ReplaceDeclare));

                bool isexistscshaptype = existscsharptype != null;
                bool isno = false;
                if (isexistscshaptype)
                    isno = existscsharptype.ReplaceDeclare.Contains("!");
                StringBuilder sbt = new StringBuilder();


                int islastColumn = columns.Where(x => x.IsSelect).Count();

                var demiliter = db.GeneratorReplace.FirstOrDefault(x => x.ReplaceName == ReplaceVariable.Delimiter.ToString());

                foreach (var item in columns)
                {
                    if (!item.IsSelect)
                        continue;
                    islastColumn -= 1;
                    if (isexistscshaptype)
                    {
                        if (!isno)
                        {
                            if (item.CSharpType.ToUpper() != existscsharptype.ReplaceName.ToUpper())
                                continue;
                        }
                        else
                        {
                            if ("!" + item.CSharpType.ToUpper() == existscsharptype.ReplaceName.ToUpper())
                                continue;
                        }
                    }


                    string csreplace = repleceContext;

                    if (csreplace.ToUpper().IndexOf(demiliter.ReplaceDeclare.ToUpper()) > -1)
                    {
                        csreplace = csreplace.Replace(demiliter.ReplaceDeclare, ((islastColumn != 0) ? "," : ""));
                    }


                    if (csreplace.IndexOf("@Controls") > -1)
                    {
                        string defaultstring = db.Controls.FirstOrDefault(x => x.Name.ToUpper() == "varchar".ToUpper()).ControlString;

                        var nowcontrols = db.Controls.FirstOrDefault(x => x.Name.ToUpper() == item.SQLType.ToUpper()).ControlString;

                        if (string.IsNullOrEmpty(nowcontrols))
                            csreplace = defaultstring;
                        else
                            csreplace = nowcontrols;
                    }


                    foreach (var cs in columnsnippet)
                    {
                        if (csreplace.IndexOf(cs.ReplaceDeclare) > -1

                            && cs.ReplaceName.ToUpper() != RKeys.ReplaceName.ToUpper()
                             && cs.ReplaceName.ToUpper() != RWheres.ReplaceName.ToUpper()
                            )
                        {
                            csreplace = csreplace.Replace(cs.ReplaceDeclare, item.GetValue(cs.ReplaceName).ToString());

                        }
                    }
                    db.GeneratorReplace.Where(x => x.ReplaceType == ReplaceType.Brackets).ToList().ForEach(x => csreplace = csreplace.Replace(x.ReplaceDeclare, string.Empty));
                    sbt.Append(csreplace);
                }

                generatorCode = generatorCode.Replace(repleceContext, sbt.ToString());
            }

            return generatorCode.Replace(RKeys.ReplaceDeclare, Keys).Replace(RWheres.ReplaceDeclare, Wheres);
        }
        private void toolscriptreconnection_Click(object sender, EventArgs e)
        {
            Connection();
        }
        #endregion

        private void tooldatasource_Click(object sender, EventArgs e)
        {
            string sql = textSql.Text;
            var databasename = db.DataBaseSetting.First().DataBase;
            if (string.IsNullOrEmpty(sql))
            {
                MessageBox.Show("请输入SQL");
                return;
            }

            if (string.IsNullOrEmpty(databasename))
            {
                MessageBox.Show("请选择数据库");
                return;
            }
             
            SQLParser parser = new SQLParser(sql);
            var list = parser.GetMyTables();
            List<Column> rs = new List<Column>();
            foreach (var item in list)
            {
                rs.AddRange(LoadTableColumn(databasename, item));
            }
            rs.ForEach(x => x.IsSelect = false);
            parser.GetMyColumns(rs);
            rs = rs.OrderByDescending(x => x.IsSelect).ToList<Column>();
            textAlias.Text = rs.FirstOrDefault().TableName.Replace(".dbo", "");
            if (treeSource.Nodes[0].Nodes.ContainsKey("@" + textAlias.Text))
            {

                MessageBox.Show("存在key");
                return;
            }
            treeSource.Nodes[0].Nodes.Add(new TreeNode()
            {
                Name = "@" + textAlias.Text,
                Text = textAlias.Text,
                Tag = rs,
                ImageIndex = (int)ImageIndex.Table,
                SelectedImageIndex = (int)ImageIndex.Table
            });
            dataSourceGrids.DataSource = LoadTableColumn(databasename, textAlias.Text);
        }

        private void tbldatatypesave_Click(object sender, EventArgs e)
        {
            datatypegrid.EndEdit();
            var count = datatypegrid.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string name = datatypegrid.Rows[i].Cells[0].Value.ToStringExtension();
                string controls = datatypegrid.Rows[i].Cells[1].Value.ToStringExtension();
                if (!string.IsNullOrEmpty(controls))
                {
                    var up = db.Controls.Where(x => x.Name == name).FirstOrDefault();
                    up.ControlString = controls;

                }
            }
            db.SaveChanges();
            //datasnippet.CommitEdit();
            datatypegrid.DataSource = db.Controls.ToList();
        }

        private void datatypegrid_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            datatypegrid.BeginEdit(false);
        }

        private void CMS启用_Click(object sender, EventArgs e)
        {
            if (treesnippet.SelectedNode == null)
                return;
            TreeNode tn = treesnippet.SelectedNode;

            var snippet = (tn.Tag as GeneratorSnippet);
            if (snippet.IsFloder)
            {
                db.GeneratorSnippet.Where(x =>
                x.FatherId == snippet.Id).ToList<GeneratorSnippet>().ForEach(y => y.IsEnabled = true);
            }
            else
            {
                db.GeneratorSnippet.FirstOrDefault(x => x.Id == snippet.Id).IsEnabled = true;
            }
            db.SaveChanges();
            ResreshSnippet();
        }

        private void CMS禁用_Click(object sender, EventArgs e)
        {
            if (treesnippet.SelectedNode == null)
                return;
            TreeNode tn = treesnippet.SelectedNode;

            var snippet = (tn.Tag as GeneratorSnippet);
            if (snippet.IsFloder)
            {
                db.GeneratorSnippet.Where(x =>
                x.FatherId == snippet.Id).ToList<GeneratorSnippet>().ForEach(y => y.IsEnabled = false);
            }
            else
            {
                db.GeneratorSnippet.FirstOrDefault(x => x.Id == snippet.Id).IsEnabled = false;
            }
            db.SaveChanges();
            ResreshSnippet();
        }



        private void CMS删除_Click(object sender, EventArgs e)
        {
            if (treesnippet.SelectedNode == null)
                return;
            TreeNode tn = treesnippet.SelectedNode;
            var snippet = (tn.Tag as GeneratorSnippet);
            if (snippet.IsFloder)
            {
                db.GeneratorSnippet.Where(x =>
               x.FatherId == snippet.Id).ToList<GeneratorSnippet>().ForEach(y => db.GeneratorSnippet.Remove(y));
            }
            else
            {
                db.GeneratorSnippet.Remove(db.GeneratorSnippet.FirstOrDefault(x => x.Id == snippet.Id));
            }
            db.SaveChanges();
            ResreshSnippet();
        }

        private void CMS看生成代码_Click(object sender, EventArgs e)
        {
            treesnippet_NodeMouseDoubleClick(sender, null);
        }

        private void btnSaveVariables_Click(object sender, EventArgs e)
        {

            dataVariables.EndEdit();
            var count = dataVariables.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string ReplaceName = dataVariables.Rows[i].Cells[0].Value.ToStringExtension();
                string ReplaceDeclare = dataVariables.Rows[i].Cells[1].Value.ToStringExtension();
                string Operation = dataVariables.Rows[i].Cells[2].Value.ToStringExtension();
                if (!string.IsNullOrEmpty(ReplaceName))
                {
                    var up = db.GeneratorReplace.Where(x => x.ReplaceName == ReplaceName).FirstOrDefault();
                    if (up != null)
                    {
                        up.ReplaceDeclare = ReplaceDeclare;
                        up.Operation = Operation;
                    }
                    else
                    {
                        db.GeneratorReplace.Add(new GeneratorReplace()
                        {
                            Operation = Operation,
                            ReplaceDeclare = ReplaceDeclare,
                            ReplaceName = ReplaceName,
                            ReplaceType = ReplaceType.CsharpType,
                            UserDeclare = true
                        });
                    }
                }
            }
            db.SaveChanges();
            dataVariables.DataSource = db.GeneratorReplace.ToList();
        }

        private void btnSaveSystemSQL_Click(object sender, EventArgs e)
        {
            dataGridSystemSQL.EndEdit();
            var count = dataGridSystemSQL.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                string Name = dataGridSystemSQL.Rows[i].Cells[0].Value.ToStringExtension();
                string SQLContext = dataGridSystemSQL.Rows[i].Cells[1].Value.ToStringExtension();
                string Description = dataGridSystemSQL.Rows[i].Cells[2].Value.ToStringExtension();
                if (!string.IsNullOrEmpty(Name))
                {
                    var up = db.GeneratorSQL.Where(x => x.Name == Name).FirstOrDefault();
                    up.SQLContext = SQLContext;
                    up.Description = Description; 
                }
            }
            db.SaveChanges();
            dataGridSystemSQL.DataSource = db.GeneratorSQL.ToList();
        }
    }

    public class DataBaseDescription
    {
        public string DataBaseName { get; set; }
    }
    public class TableDescription
    {
        public string DataBaseName { get; set; }
        public string TableName { get; set; }
        public string Type { get; set; }
    }
    public enum ImageIndex
    {
        DataBaseAddress = 0,
        DataBase = 1,
        Floder = 2,
        Table = 3,
        Refresh = 4,
        Solution = 5,
        Project = 6,
        Aspx = 7,
        Csharp = 8,
        Config = 9,
        JavaScript = 10,
        Yes = 11,
        Wrong = 12,
        Other = 110
    }
    public class GetPath
    {
        public static string AssemblyPath = Assembly.GetExecutingAssembly().Location.GetFileDirectory();

        public static string CSharpColor = AssemblyPath + "\\csharp.xml";
    }

}
