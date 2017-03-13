using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class AuditOperationFilter : _AuditOperationFilter
    {
        private string _SessionId;
        public string SessionId
        {
            get
            {
                if (_SessionId == null) _SessionId = string.Empty;
                return _SessionId;
            }
            set { _SessionId = value; }
        }
    }
}
