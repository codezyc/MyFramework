using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    /// <summary>
    /// 邮件实体
    /// </summary>
    public class MailEntity
    {
        /// <summary>
        /// 发件人地址
        /// </summary>
        public string FromAddress { get; set; }
        /// <summary>
        /// 收件人地址
        /// </summary>
        public string[] ToAddress { get; set; }
        /// <summary>
        /// 抄送地址
        /// </summary>
        public string[] CCAddress { get; set; }
        /// <summary>
        /// 邮件主题
        /// </summary>
        public string Subject { get; set; }
        /// <summary>
        /// 邮件内容
        /// </summary>
        public string Body { get; set; }
        /// <summary>
        /// 邮件编码
        /// </summary>
        public string Encoding { get; set; }
        /// <summary>
        /// 邮箱SMTP服务器
        /// </summary>
        public string SmtpServer { get; set; }
        /// <summary>
        /// 邮箱端口
        /// </summary>
        public int Port { get; set; }
        /// <summary>
        /// 邮箱用户名
        /// </summary>
        public string UserName { get; set; }
        /// <summary>
        /// 邮箱密码
        /// </summary>
        public string Password { get; set; }
        /// <summary>
        /// 邮箱附件集合
        /// </summary>
        public string[] Attachment { get; set; }
        /// <summary>
        /// 是否随同请求一起发送
        /// </summary>
        public bool UseDefaultCredentials { get; set; }
        /// <summary>
        /// 是否启用SSL
        /// </summary>
        public bool EnableSSL { get; set; }
        /// <summary>
        /// 邮件中是否包含Html代码
        /// </summary>
        public bool IsBodyHtml { get; set; }
    }
}
