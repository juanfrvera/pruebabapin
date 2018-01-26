using System.ServiceModel;

namespace Bapin.WindowsService.Services
{
    [ServiceContract(Namespace = "http://bombieri.com/winservice/WinServiceConfigurationService",
                        CallbackContract = typeof(IWinServiceActivityCallback))]
    public interface IWinServiceConfigurationService
    {
        [OperationContract]
        WinServiceConfiguration GetConfiguration();

        [OperationContract(IsOneWay = true)]
        void StartProcessingHandle(string name);

        [OperationContract(IsOneWay = true)]
        void ChangeHandlerPolling(string name, int pollingInterval);

        [OperationContract(IsOneWay = true)]
        void StopProcessingHandle(string name);

        [OperationContract(IsOneWay = true)]
        void StartLogging();
    }
}
