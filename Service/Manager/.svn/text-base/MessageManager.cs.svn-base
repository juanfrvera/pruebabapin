using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Service;
using System.Data.SqlClient;
using Business;

namespace Service
{
    public class MessageManager : IMessageManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static MessageManager current;
        private MessageManager() { }
        public static MessageManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new MessageManager();
                    }
                return current;
            }
        }
        #endregion

        public void Send(int IdUserFrom, int[] idUsersTo, string subject, string body, int? idProyecto, IContextUser contextUser)
        {
            Message message = new Message();
            message.Body = body;
            message.IdMediaFrom = 1;
            message.IdPriority = 1;
            message.IdProyecto = idProyecto;
            message.IdUserFrom = SolutionContext.Current.SystemUser.IdUsuario;
            message.IsManual = false;
            message.SendDate = DateTime.Now;
            message.StartDate = DateTime.Now;
            message.Subject = subject;
            MessageService.Current.Add(message, contextUser);

            foreach (int idUserTo in idUsersTo)
            {
                MessageSend messageSend = new MessageSend();
                messageSend.IdMediaTo = 1;
                messageSend.IdMessage = message.IdMessage;
                messageSend.IdUserTo = idUserTo;
                messageSend.IsRead = false;
                MessageSendService.Current.Add(messageSend, contextUser);
            }
        }
    }
}
