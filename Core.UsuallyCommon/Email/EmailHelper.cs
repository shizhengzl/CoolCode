using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Core.UsuallyCommon
{
    public static class EmailHelper
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="FormMail">发件人</param>
        /// <param name="FormMailPwd">发件人邮箱密码</param>
        /// <param name="ToMail">收件人</param>
        /// <param name="EmailCC">抄送</param>
        /// <param name="Subject">主题</param>
        /// <param name="Content">内容</param>
        /// <param name="files">附件</param>
        /// <param name="Host">SMTP服务器</param>
        /// <param name="Port">端口</param>
        /// <returns></returns>
        public static bool SendEmail(string FormMail, string FormMailPwd, string ToMail, string EmailCC, string Subject, string Content, string Host, int Port)
        {
            using (MailMessage myMail = new MailMessage())
            {
                //发件人
                myMail.From = new MailAddress(FormMail);
                //收件人(多个用;隔开的)
                string[] Tolist = ToMail.TrimEnd(';').Split(';');
                foreach (string ToMailAlone in Tolist)
                {
                    if (!string.IsNullOrEmpty(ToMailAlone))
                        myMail.To.Add(new MailAddress(ToMailAlone));
                }
                //主题
                myMail.Subject = Subject;
                myMail.SubjectEncoding = System.Text.Encoding.UTF8;
                //内容
                myMail.Body = Content;
                myMail.BodyEncoding = System.Text.Encoding.UTF8;
                myMail.IsBodyHtml = true;
                //抄送
                //发件人
                //收件人(多个用;隔开的)
                string[] EmailCCList = EmailCC.TrimEnd(';').Split(';');
                foreach (string EmailCCAlone in EmailCCList)
                {
                    if (!string.IsNullOrEmpty(EmailCCAlone))
                        myMail.CC.Add(new MailAddress(EmailCCAlone));
                }
                //是否是HTML邮件
                myMail.IsBodyHtml = true;
                //邮件优先级
                myMail.Priority = MailPriority.Normal;
                ///创建邮件服务器类
                using (SmtpClient myClient = new SmtpClient())
                {
                    myClient.Host = Host;//SMTP服务器
                    myClient.Port = Port;//SMTP端口
                    myClient.EnableSsl = true;
                    myClient.UseDefaultCredentials = false;
                    //验证邮件
                    myClient.Credentials = new NetworkCredential(FormMail, FormMailPwd);
                    //发送邮件
                    try
                    {
                        myClient.Send(myMail);
                        return true;
                    }
                    catch (Exception e)
                    {
                        throw e;
                    }
                }
            }
        }
    }
}
