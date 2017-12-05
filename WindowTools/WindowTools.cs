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
namespace WindowTools
{
    public partial class WindowTools : Form
    {
        public WindowTools()
        {
            InitializeComponent();
        }

        private void btnemailSend_Click(object sender, EventArgs e)
        {
            try
            {


                var host = txtemailhost.Text.Trim();

                var sendemail = txtemailsendmail.Text.Trim();

                var password = txtemailpassword.Text.Trim();

                var port = txtemailport.Text.Trim().ToInt32();

                var sendto = txtemailsendto.Text.Trim();

                var sendmessage = txtemailsendmessage.Text;

                var subject = txtemailsubject.Text.Trim();

                var cc = txtemailSendToCC.Text.Trim();

                if (string.IsNullOrEmpty(host) || string.IsNullOrEmpty(sendemail)
                    || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(sendmessage)
                     || string.IsNullOrEmpty(sendto) || port == 0)
                {
                    txtemailsendresult.Text = string.Empty;
                    txtemailsendresult.AppendText("请输入完整信息!");
                    return;
                }

                txtemailsendresult.Text = string.Empty;
                txtemailsendresult.AppendText("start send email tesing!");

                txtemailsendresult.AppendText(string.Format("host:{0}", host));
                txtemailsendresult.AppendText(string.Format("sendemail:{0}", sendemail));
                txtemailsendresult.AppendText(string.Format("password:{0}", password));
                txtemailsendresult.AppendText(string.Format("port:{0}", port));
                txtemailsendresult.AppendText(string.Format("sendto:{0}", sendto));
                txtemailsendresult.AppendText(string.Format("sendmessage:{0}", sendmessage));
                txtemailsendresult.AppendText(string.Format("subject:{0}", subject));
                txtemailsendresult.AppendText(string.Format("cc:{0}", cc));
                EmailHelper.SendEmail(sendto, password, sendto, cc, subject, sendmessage, host, port);
            }
            catch (Exception ex)
            {
                txtemailsendresult.AppendText(ex.Message);
            }
        }
    }
}
