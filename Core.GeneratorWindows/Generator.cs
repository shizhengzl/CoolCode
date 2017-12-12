using Core.EntityFramework;
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
        }

        public void GeneratorInit()
        {
            db = new GeneratorContext();
            GeneratorText.ConfigFile = GetPath.CSharpColor;
            SnippetContext.ConfigFile = GetPath.CSharpColor;

            LoadGeneartorVariable();
            InitTreeSource();
            ResreshSnippet();
            if (!(db.DataBaseSetting.Any() && db.DataBaseSetting.FirstOrDefault().IsRemeber))
            {
                // to do login
                GeneratorLogin gLogin = new GeneratorLogin();
                gLogin.ShowDialog();

                if (gLogin.DialogResult == DialogResult.Cancel)
                {
                    Close();
                    return;
                }
            }

            var settings = db.DataBaseSetting.FirstOrDefault();
            // set connection
            DatabaseHelper.connectionString = $"Server={settings.Address};uid={settings.Account};pwd={settings.Password};database=master;";

            LoadDataBaseTree();
        }

        #region data source
        private void LoadTableColumn(TreeNode tn)
        {
            if (tn.Text == "DataSource")
                return;
            var dbname = (tn.Tag as TreeNode).Parent.Parent.Text;

            var generatorsql = db.GeneratorSQL.Where(x => x.Name == "Columns").FirstOrDefault();
            var dt = DatabaseHelper.ExecuteQuery(string.Format(generatorsql.SQLContext, dbname, tn.Text)).Tables[0];
            var Columns = dt.ToList<Column>();

            dataSourceGrids.DataSource = Columns;
            dataSourceGrids.AutoGenerateColumns = true;
            dataSourceGrids.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
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

        }
        #endregion


        #region database tree 

        public void LoadDataBaseTree()
        {
            treedb.Nodes.Clear();
            treedb.ImageList = imageListcollection;
            TreeNode root = new TreeNode($"{db.DataBaseSetting.FirstOrDefault().Address}"); 
            root.Tag = DBTypeClass.ServerAddress;
            SetTreeImages(root);
            string DbSQL = @"
                           DECLARE @TABLESQL VARCHAR(MAX) = 'SELECT ''@DataBase'' as DataBaseName,Name COLLATE Chinese_PRC_CI_AS as TableName,Type from [@DataBase].sys.objects where TYPE IN (''U'',''V'',''P'')'
DECLARE @RESULT VARCHAR(MAX) = ''

SELECT @RESULT = @RESULT + CASE WHEN @RESULT = '' 
THEN   REPLACE(@TABLESQL,'@DataBase',NAME) + CHAR(13)
ELSE  ' UNION ALL ' +  REPLACE(@TABLESQL,'@DataBase',NAME) + CHAR(13) END
FROM sys.databases
PRINT @RESULT
SELECT Name as DataBaseName FROM   sys.databases
EXEC (@RESULT)";

            DataSet Ds = DatabaseHelper.ExecuteQuery(DbSQL); 
            var DataTableList = Ds.Tables[1].ToList<TableDescription>(); 
            var DataBaseList = Ds.Tables[0].ToList<DataBaseDescription>();
            foreach (var item in DataBaseList)
            {
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

            switch(dc)
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
            TreeNode tnParent = tn;
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
            DBTypeClass tyc = (DBTypeClass)e.Node.Tag;
            if (tyc == DBTypeClass.Table || tyc == DBTypeClass.View || tyc == DBTypeClass.Procduct)
            {
                if (e.Node.Checked)
                {
                    if (treeSource.Nodes[0].Nodes.Find(e.Node.Text, true).Count() == 0)
                    {
                        treeSource.Nodes[0].Nodes.Add(new TreeNode() { Name = e.Node.Text, Text = e.Node.Text,
                            ImageIndex = (int)ImageIndex.Table,SelectedImageIndex=(int)ImageIndex.Table ,Tag = e.Node });
                    }
                }
                else
                {
                    if (treeSource.Nodes[0].Nodes.Find(e.Node.Text,true).Count() > 0)
                    {
                        treeSource.Nodes[0].Nodes.Remove(treeSource.Nodes[0].Nodes.Find(e.Node.Text, true).FirstOrDefault());
                    }
                }
            }
            treeSource.ExpandAll();
        }
        #endregion 

        #region variables

        public void LoadGeneartorVariable()
        {
            var replace = db.GeneratorReplace.OrderBy(x => x.ReplaceName).ToList();
            var dt = replace.ToDataTable<GeneratorReplace>();
            dataVariables.DataSource = dt;
            dataVariables.AutoGenerateColumns = true;
            dataVariables.RowHeadersWidthSizeMode = DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders; 
        }



        #endregion

        #region tree 
        private void treeSolution_DragDrop(object sender, DragEventArgs e)
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
                            tn.ToolTipText = item.SubProject.UniqueName.Replace("..\\", "");
                            tn.Tag = item.SubProject.UniqueName.Replace("..\\", "");//.Replace("\\" + item.SubProject.Name + ".csproj", "");
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
                        chldNode.ToolTipText = project.UniqueName.Replace("..\\", "");
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
                MessageBox.Show("提示LoadComboTree" +  ex.Message);
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
                tn.ToolTipText = item.SubProject.UniqueName.Replace("..\\", "");
                tn.Tag = item.SubProject.UniqueName.Replace("..\\", "");//.Replace("\\" + item.SubProject.Name + ".csproj", "");
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
                    chldNode.ToolTipText = node.ToolTipText;
                    chldNode.Tag = chlFile.FullName.Replace(VsProjectPath, "");
                    chldNode.ImageIndex = this.IsFileReturnFlag(chlFile.Extension);
                    chldNode.SelectedImageIndex = chldNode.ImageIndex;
                    node.Nodes.Add(chldNode);
                }
                DirectoryInfo[] chldFolders = folder.GetDirectories();
                foreach (DirectoryInfo chldFolder in chldFolders)
                {
                    TreeNode chldNode = new TreeNode();
                    chldNode.ToolTipText = node.ToolTipText;
                    chldNode.ImageIndex = 2;
                    chldNode.Tag = chldFolder.FullName.Replace(VsProjectPath, "");
                    chldNode.Text = chldFolder.Name;
                    chldNode.ToolTipText = node.ToolTipText;
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
            var name = SnippetName.Text.Trim();
            var filename = SnippetFileName.Text.Trim();
            var filepath = SnippetPath.Text.Trim();

            bool ismergin = SnippetIsMergin.Checked;
            bool isappend = SnippetIsAppend.Checked;
            bool autofind = SnippetAutoFind.Checked;
            bool isenabled = SnippetIsEnabled.Checked;

            bool isselectcolumn = SnippetIsSelectColumn.Checked;

            string context = SnippetContext.Text;

            var isupdate = db.GeneratorSnippet.FirstOrDefault(x => x.Name == name);
            if(isupdate == null)
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
            isupdate.GeneratorPath = filepath;
            isupdate.Context = context;
            isupdate.IsSelectColumn = isselectcolumn;
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
            SnippetIsAppend .Checked = data.IsAppend;
            SnippetName.Text = data.Name;
            SnippetFileName.Text = data.GeneratorFileName;
            SnippetPath.Text = data.GeneratorPath;
            SnippetContext.Text = data.Context;
            SnippetIsSelectColumn.Checked = data.IsSelectColumn;
        }


        private void LoadSnippetTree()
        {
            treesnippet.Nodes.Clear();
            treesnippet.ImageList = imageListcollection;
            TreeNode allModel = new TreeNode();
            allModel.Text = "All Model";
            treesnippet.Nodes.Add(allModel);

            var list = db.GeneratorSnippet.OrderByDescending(x => x.IsEnabled);

            list.ToList().ForEach(x => allModel.Nodes.Add(
                new TreeNode() {
                    Text = x.Name,
                    ImageIndex = x.IsEnabled? (int)ImageIndex.Yes : (int)ImageIndex.Wrong,
                    SelectedImageIndex = x.IsEnabled ? (int)ImageIndex.Yes : (int)ImageIndex.Wrong,
                    Tag = x
                }) );

            treesnippet.ExpandAll();
        }

        private void treesnippet_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node == null)
                return;
            var snippet = (GeneratorSnippet)e.Node.Tag;
            if (snippet == null)
                return;
            if (dataSourceGrids.DataSource == null)
                return;

            var hasselectnode = treeSource.SelectedNode;
            if (hasselectnode == null || hasselectnode.Text == "DataSource")
                return;

            

        }

        #endregion


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
        Solution =  5, 
        Project = 6,
        Aspx = 7,
        Csharp = 8,
        Config = 9 , 
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
