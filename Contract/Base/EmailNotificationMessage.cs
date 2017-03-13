using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public class EmailNotificationMessage : INotificationMessage
    {
        public string Message { get; set; }
        public string From { get; set; }
        public string Subject { get; set; }
        public string To { get; set; }
    }
}
