using System.ServiceModel;

namespace Bapin.WindowsService.Services
{
    [ServiceContract]
    public interface IWinServiceActivityCallback
    {
        [OperationContract(IsOneWay = true)]
        void LogActivity(string output, bool isError);
    }
}
