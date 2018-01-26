using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Bapin.WindowsService.Services
{
    [DataContract(Namespace = "http://bombieri.com/winservice/WinServiceConfiguration")]
    public class WinServiceConfiguration
    {
        public WinServiceConfiguration()
        {
            Handlers = new List<HandlerInformation>();
            SmtpConfiguration = new SmtpConfiguration();
        }

        [DataMember]
        public SmtpConfiguration SmtpConfiguration { get; set; }

        [DataMember]
        public IList<HandlerInformation> Handlers { get; set; }
    }
}
