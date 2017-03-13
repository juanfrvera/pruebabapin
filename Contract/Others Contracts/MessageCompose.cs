using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{   
    [Serializable]
    public class MessageCompose
    {       
        public MessageResult Message {get;set;}
        public List<MessageSendResult> MessageSends { get; set; }
    }
}
