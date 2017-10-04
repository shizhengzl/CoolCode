using Core.EntityFramework;
using Core.EntityFramework.GeneratorClass;
using Core.UsuallyCommon;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static Core.UsuallyCommon.Extensions;

namespace Core.GeneratorWindows
{
    public partial class Geneartor : Form
    {
        GeneratorContext db = new GeneratorContext();
        public Geneartor()
        {
            InitializeComponent();
            LoadGeneartorVariable();
            LoadSnippet();
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


        #region database tree
        public void LoadDataBaseTree()
        {
            treedb.Nodes.Clear();
            treedb.ImageList = imageListcollection;
            TreeNode root = new TreeNode($"{db.DataBaseSetting.FirstOrDefault().Address}");
            root.ImageIndex = (int)ImageIndex.DataBaseAddress;

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
                dbnode.Tag = item;
                dbnode.ImageIndex = (int)ImageIndex.DataBase;
                root.Nodes.Add(dbnode);

                var dtlist= DataTableList.Where(x => x.DataBaseName == item.DataBaseName).OrderBy(x => x.TableName);

                foreach (var dt in dtlist)
                {
                    TreeNode tabletn = new TreeNode("Tables");
                    tabletn.ImageIndex = (int)ImageIndex.Floder;
                    dbnode.Nodes.Add(tabletn);

                    TreeNode viewtn = new TreeNode("Views");
                    viewtn.ImageIndex = (int)ImageIndex.Floder;
                    dbnode.Nodes.Add(viewtn);

                    TreeNode producttn = new TreeNode("Products");
                    producttn.ImageIndex = (int)ImageIndex.Floder;
                    dbnode.Nodes.Add(producttn);


                    TreeNode dtn = new TreeNode(dt.TableName);
                    dtn.Tag = dt;
                    dtn.ImageIndex = (int)ImageIndex.Table;

                    switch(dt.Type.ToUpper().Trim())
                    {
                        case "U":
                            tabletn.Nodes.Add(dtn);
                            break;
                        case "P":
                            producttn.Nodes.Add(dtn);
                            break;
                        case "V":
                            viewtn.Nodes.Add(dtn);
                            break;
                    }

                }
            }

            treedb.Nodes.Add(root);
        }
        

        private void tooldbrefresh_Click(object sender, EventArgs e)
        {
            LoadDataBaseTree();
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

        #region snippet
        public void LoadSnippet()
        {
            treeViewSnippet.Nodes.Clear();
            treeViewSnippet.ImageList = imageListcollection ;
            var snippets = db.GeneratorSnippet.ToList();

            var root = snippets.OrderBy(x => x.Id).FirstOrDefault();

            TreeNode node = new TreeNode();
            node.Text = root.Name;

            node.Tag = root;
            node.ImageIndex = (int) ImageIndex.Floder;

            treeViewSnippet.Nodes.Add(node);
            AddChild(node, snippets);

        }

        public void AddChild(TreeNode fatherNode, List<GeneratorSnippet> list)
        {
            var ft = (GeneratorSnippet)fatherNode.Tag;
            var node = list.Where(x => x.FatherId == ft.Id);
            foreach (var item in node)
            {
                var childnode = new TreeNode();
                childnode.Text = item.Name;
                childnode.Tag = item;
                childnode.ImageIndex = item.IsFloder ? (int)ImageIndex.Floder : (int)ImageIndex.Table;
                fatherNode.Nodes.Add(childnode);
                AddChild(childnode, list);
            }
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
        Refresh = 4
    }


}
