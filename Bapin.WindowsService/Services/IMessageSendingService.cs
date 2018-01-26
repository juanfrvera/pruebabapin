using ITsynch.ARMS.Backend.Entities.MessagesService;
using System.ServiceModel;

namespace ITsynch.ARMS.WinService.Services
{
    [ServiceContract]
    public interface IMessageSendingService
    {
        [OperationContract]
        bool SendMailMessage(SerializableMailMessage message);
    }
}
