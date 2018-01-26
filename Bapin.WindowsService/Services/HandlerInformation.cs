using System.Runtime.Serialization;

namespace Bapin.WindowsService.Services
{
    [DataContract(Namespace = "http://bombieri.com/winservice/HandlerInformation")]
    public class HandlerInformation
    {
        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public bool Enabled { get; set; }

        [DataMember]
        public int PollingInterval { get; set; }
    }
}
