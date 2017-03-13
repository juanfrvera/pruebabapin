using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using System.Net.Mail;
using nc=Contract;
using Service;
using System.Web.Security;

namespace Service
{
    public class EmailNotificationManager : INotificationManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static EmailNotificationManager current;
        public static EmailNotificationManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new EmailNotificationManager();
                    }
                return current;
            }
        }
        #endregion

        
        private string SmtpServer
        {
            get 
            {
                return SolutionContext.Current.ParameterManager.GetParameter("SMTP_SERVER").StringValue;                
            }
        }
        private string SmtpUser
        {
            get
            {
                return SolutionContext.Current.ParameterManager.GetParameter("SMTP_USER").StringValue;
            }
        }
        private string SmtpUserPassword
        {
            get
            {
                return SolutionContext.Current.ParameterManager.GetParameter("SMTP_USERPASSWORD").StringValue;
            }
        }

        public void Send(string message, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public void Send(INotificationMessage message, IContextUser contextUser)
        {
            MailMessage mailMessage = new MailMessage(message.From, message.To);
            mailMessage.Body = @message.Message;
            mailMessage.IsBodyHtml = true;
            mailMessage.BodyEncoding = Encoding.UTF8;
            mailMessage.Subject = message.Subject;

            SmtpClient smtpClient = new SmtpClient(this.SmtpServer);
            System.Net.NetworkCredential SMTPUserInfo = new System.Net.NetworkCredential(this.SmtpUser, this.SmtpUserPassword);
            smtpClient.UseDefaultCredentials = true;
            smtpClient.Credentials = SMTPUserInfo;
            smtpClient.Send(mailMessage);
        }
    }

    
}
