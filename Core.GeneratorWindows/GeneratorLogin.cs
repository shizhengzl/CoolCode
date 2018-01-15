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

            var settings = db.DataBaseSetting.OrderByDescending(x=>x.LastModifyTime).FirstOrDefault();
            if (settings != null)
            {
                txtServerName.Text = settings.Address;
                txtLoginName.Text = settings.Account;
                txtPassword.Text = settings.Password;
                chk_remberer.Checked = settings.IsRemeber;
                comLoginMethod.SelectedIndex = (int)settings.AuthenticationType;
            }
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

                var settings = db.DataBaseSetting.FirstOrDefault(x => x.Address == addres);

                if (settings == null)
                {
                    settings = new DataBaseSetting()
                    {
                        Account = account,
                        Password = password,
                        Address = addres,
                        LastModifyTime = DateTime.Now,
                        IsRemeber = chk_remberer.Checked,
                        AuthenticationType = comLoginMethod.SelectedIndex.ToString().ToEnum<AuthenticationType>()
                    };
                    db.DataBaseSetting.Add(settings);
                }
                else
                {
                    settings.LastModifyTime = DateTime.Now;
                    settings.Account = account;
                    settings.Password = password;
                    settings.Address = addres;
                    settings.IsRemeber = chk_remberer.Checked;
                    settings.AuthenticationType = comLoginMethod.SelectedIndex.ToString().ToEnum<AuthenticationType>();


                } 
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

        private void txtServerName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !string.IsNullOrEmpty(((TextBox)sender).Text.Trim()))
            {
                txtLoginName.Focus();
                txtLoginName.SelectAll();
            }
        }

        private void txtPassword_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !string.IsNullOrEmpty(((TextBox)sender).Text.Trim()))
            {
                btnLogin_Click(null, null);
            }
        }

        private void txtLoginName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13 && !string.IsNullOrEmpty(((TextBox)sender).Text.Trim()))
            {
                txtPassword.Focus();
                txtPassword.SelectAll();
            }
        }
    }
}
