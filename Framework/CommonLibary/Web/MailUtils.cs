using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace CommonLibary.Web
{
    /// <summary>
    /// C#邮件常用操作
    /// </summary>
    public static class MailUtils
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="mailentity">封装好的邮件实体</param>
        /// <returns>返回是否发送成功</returns>
        public static bool SendMail(MailEntity mailentity)
        {
            if (CheckValid(mailentity))
            {
                MailMessage mailmessage = new MailMessage();
                SetMailMessage(mailentity, ref mailmessage);
                if (mailmessage != null)
                {
                    SmtpClient client = new SmtpClient(mailentity.SmtpServer, mailentity.Port);
                    client.UseDefaultCredentials = true;
                    client.Credentials = new NetworkCredential(mailentity.UserName, mailentity.Password);
                    client.DeliveryMethod = SmtpDeliveryMethod.Network;
                    client.EnableSsl = mailentity.EnableSSL;
                    client.Send(mailmessage);
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 设置邮件内容
        /// </summary>
        /// <param name="mailentity">封装好的邮件实体</param>
        /// <returns>返回MailMessage实体</returns>
        public static MailMessage SetMailMessage(MailEntity mailentity, ref MailMessage mailmessage)
        {
            MailAddressCollection addresscollection = new MailAddressCollection();
            if (mailentity.ToAddress.Length == 1)
                mailmessage.To.Add(new MailAddress(mailentity.ToAddress[0]));
            else if (mailentity.ToAddress.Length > 1)
            {
                foreach (var item in mailentity.ToAddress)
                {
                    mailmessage.To.Add(new MailAddress(item));
                }
            }
            if (mailentity.CCAddress.Length == 1)
                mailmessage.CC.Add(new MailAddress(mailentity.CCAddress[0]));
            else if (mailentity.CCAddress.Length > 1)
            {
                foreach (var item in mailentity.CCAddress)
                {
                    mailmessage.CC.Add(new MailAddress(item));
                }
            }
            mailmessage.From = new MailAddress(mailentity.FromAddress);
            mailmessage.Subject = mailentity.Subject;
            mailmessage.Body = mailentity.Body;
            mailmessage.IsBodyHtml = mailentity.IsBodyHtml;
            if (!string.IsNullOrEmpty(mailentity.Encoding))
            {
                mailmessage.BodyEncoding = Encoding.GetEncoding(mailentity.Encoding);
                mailmessage.SubjectEncoding = Encoding.GetEncoding(mailentity.Encoding);
            }
            else
            {
                mailmessage.BodyEncoding = Encoding.Default;
                mailmessage.SubjectEncoding = Encoding.Default;
            }
            if (mailentity.Attachment.Length == 1)
                mailmessage.Attachments.Add(new Attachment(mailentity.Attachment[0]));
            else if (mailentity.Attachment.Length > 1)
            {
                foreach (var item in mailentity.Attachment)
                {
                    mailmessage.Attachments.Add(new Attachment(item));
                }
            }
            return mailmessage;
        }

        /// <summary>
        /// 验证邮件实体是否合格
        /// </summary>
        /// <param name="mailentity">封装好的邮件实体</param>
        /// <returns>是否验证通过</returns>
        public static bool CheckValid(MailEntity mailentity)
        {
            if (mailentity == null)
                throw new Exception("发送邮件实体不能为空");
            else if (mailentity.FromAddress.Length != 1)
                throw new Exception("发件人不能为空");
            else if (mailentity.ToAddress.Length < 1)
                throw new Exception("收件人不能为空");
            else if (string.IsNullOrWhiteSpace(mailentity.Subject))
                throw new Exception("邮件标题不能为空");
            else if (string.IsNullOrWhiteSpace(mailentity.Body))
                throw new Exception("邮件正文不能为空");
            else if (string.IsNullOrWhiteSpace(mailentity.SmtpServer) || mailentity.Port != 0)
                throw new Exception("邮件SMTP服务器或端口不能为空");
            else if (string.IsNullOrWhiteSpace(mailentity.UserName) || string.IsNullOrWhiteSpace(mailentity.Password))
                throw new Exception("发件人用户名或密码错误");
            else
                return true;
        }
    }
}
