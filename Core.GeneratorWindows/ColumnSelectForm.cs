using Core.UsuallyCommon.Database;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Core.GeneratorWindows
{
    public partial class ColumnSelectForm : Form
    {
        public List<Column> datasource;
        public ColumnSelectForm(string tableName , List<Column> columns)
        {
            datasource = columns;
            InitializeComponent();
            groupColumns.Text = string.Format("{0} Columns", tableName);
            DataBind();
        }

        public void DataBind()
        {
            this.dataGridViewSelect.DataSource = datasource;
            this.dataGridViewSelect.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
        }

        private void tselectAll_Click(object sender, EventArgs e)
        {
            this.dataGridViewSelect.DataSource = null;
            foreach (var item in datasource)
            {
                item.IsSelect = false;
            }
            DataBind();
        }

        private void tcansel_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Cancel;
        }

        private void treverse_Click(object sender, EventArgs e)
        {
            this.dataGridViewSelect.DataSource = null;
            foreach (var item in datasource)
            {
                item.IsSelect = !item.IsSelect;
            }
            DataBind();
        }

        private void tok_Click(object sender, EventArgs e)
        {
            dataGridViewSelect.EndEdit();
            try
            {
                for (int i = 0; i < this.datasource.Count; i++)//得到总行数并在之内循环    
                {
                    Column col = this.datasource[i];
                    PropertyInfo[] piar = col.GetType().GetProperties();
                    foreach (PropertyInfo pi in piar)
                    {
                        col.GetType().GetProperty(pi.Name).SetValue(col, Convert.ChangeType(dataGridViewSelect.Rows[i].Cells[pi.Name].Value, dataGridViewSelect.Rows[i].Cells[pi.Name].ValueType), null);
                    }
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            this.DialogResult = System.Windows.Forms.DialogResult.OK;
        }
    }
}
