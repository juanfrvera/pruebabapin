using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Service;

namespace Service
{
    public class AuditManager : IAuditManager
    {
        #region singleton
        private static readonly object padlock = new object();
        private static AuditManager current;
        public static AuditManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new AuditManager();
                    }
                return current;
            }
        }
        #endregion

        public void Save(AuditSession auditSession)
        {
            AuditSessionService.Current.Save(auditSession, null);  
        }
        public void Save(AuditOperation auditOperation)
        {
            AuditOperationService.Current.Save(auditOperation, null); 
        }
        public void Save(AuditOperationDetail auditOperationDetail)
        {
            AuditOperationDetailService.Current.Save(auditOperationDetail, null); 
        }
    }
}
