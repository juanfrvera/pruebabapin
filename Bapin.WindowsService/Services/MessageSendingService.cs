using ITsynch.ARMS.Backend.Entities.MessagesService;
using ITsynch.ARMS.Backend.Exceptions;
using ITsynch.Common.Extensions;
using ITsynch.Common.Smtp;
using log4net;
using MimeKit;
using System;
using System.Net;
using System.Net.Mail;
using System.ServiceModel;

namespace ITsynch.ARMS.WinService.Services
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class MessageSendingService : IMessageSendingService
    {
        private static readonly ILog Log = LogManager.GetLogger(typeof(MessageSendingService));

        public bool SendMailMessage(SerializableMailMessage message)
        {
            try
            {
                Console.WriteLine("message received...");
                if (message == null)
                {
                    Log.Warn("Message received is null");
                    return false;
                }

                if (message.To.IsNullOrEmpty() && message.Cc.IsNullOrEmpty()) return true;

                if (message.From == null || message.From.Address.IsNullOrEmpty())
                {
                    Console.WriteLine("FromAddress incomplete...");
                    Log.Warn(string.Format("From ({0}) or FromAddress ({1}) incomplete", message.From, message.From != null ? message.From.Address : string.Empty));
                }

                MailMessage mailMessage;
                try
                {
                    mailMessage = message.GetMailMessage();
                }
                catch (Exception ex)
                {
                    Log.Error("Error getting mail message", ex);
                    return false;
                }

                var emailSettings = GlobalData.EmailConfiguration;
                mailMessage.Sender = new MailAddress(emailSettings.EmailAddress, emailSettings.EmailName);

                using (var smtpClient = SmtpClientHelper.GetConnectedSmtpClient())
                {
                    // remember that mailkit allows explicit casting a system.net.mailmessage to a mime message.
                    smtpClient.Send((MimeMessage)mailMessage);

                    smtpClient.Disconnect(true);
                }

                return true;
            }
            catch (Exception ex)
            {
                Log.Error(ex);
                ExceptionNotifierErrorHandler.HandleError(ex);
                return false;
            }
        }
    }
}
