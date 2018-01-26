using System.Runtime.Serialization;

namespace Bapin.WindowsService.Services
{
    [DataContract(Namespace = "http://bombieri.com/winservice/SmtpConfiguration")]
    public class SmtpConfiguration
    {
        [DataMember]
        public string EmailName { get; set; }

        [DataMember]
        public string EmailAddress { get; set; }

        [DataMember]
        public string SmtpServer { get; set; }

        [DataMember]
        public int? SmtpPort { get; set; }

        [DataMember]
        public bool RequiresAuthentication { get; set; }

        [DataMember]
        public string UserName { get; set; }
    }
}
