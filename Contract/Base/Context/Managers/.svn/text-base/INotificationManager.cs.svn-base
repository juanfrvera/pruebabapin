using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public interface INotificationMessage
    {
        string Message { get; set;}
        string From { get; set; }
        string Subject { get; set; }
        string To { get; set; }
    }

    public interface INotificationManager
    {
        void Send(string message, IContextUser contextUser);
        void Send(INotificationMessage message, IContextUser contextUser);
    }

    public interface IMessageManager
    {
        void Send(int IdUserFrom, int[] idUsersTo, string subject, string body, int? idProyecto, IContextUser contextUser);
    }
}
