using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public class MembershipException : Exception
    {
        public string MessageCode {get; set;}

        public MembershipException(string msgCode) : base ()
        {
            MessageCode = msgCode;
        }

        public MembershipException() : base() { }
        public MembershipException(string message, Exception innerException) : base(message, innerException) { }
        public MembershipException(System.Runtime.Serialization.SerializationInfo info, System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
