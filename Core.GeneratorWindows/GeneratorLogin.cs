using Core.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Core.UsuallyCommon;
namespace Core.GeneratorWindows
{
    public partial class GeneratorLogin : Form
    {
        GeneratorContext db = new GeneratorContext();
        public GeneratorLogin()
        {
            InitializeComponent();
            this.comLoginMethod.SelectedIndex = 1;
        }

        private void comLoginMethod_SelectedIndexChanged(object sender, EventArgs e)
        {
            bool isselect = this.comLoginMethod.SelectedIndex == 1;

            txtLoginName.Enabled = isselect;
            txtPassword.Enabled = isselect;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            { 
                string addres = txtServerName.Text.Trim();
                string account = txtLoginName.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(addres) ||
                    (this.comLoginMethod.SelectedIndex == 1
                    && (string.IsNullOrEmpty(account) || string.IsNullOrEmpty(password))))
                {
                    MessageBox.Show("请输入完整信息!");
                    return;
                }
                 
                db.DataBaseSetting.Add(new DataBaseSetting()
                {
                    Account = account,
                    Password = password,
                    Address = addres,
                    IsRemeber = chk_remberer.Checked,
                    AuthenticationType = comLoginMethod.SelectedIndex.ToString().ToEnum<AuthenticationType>()
                });

                db.SaveChanges();

                DialogResult = DialogResult.OK;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCanel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }
    }
}
