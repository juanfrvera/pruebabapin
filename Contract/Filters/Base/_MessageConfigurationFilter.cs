using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contract.Base
{
    [Serializable, DataContract]
    public abstract class _MessageConfigurationFilter : Filter
    {
        #region Private
        private string _Page;
        private string _Body;
        private string _Subject;
        private int _OperationType;

        #endregion

        #region Properties
        [DataMember(Name = "IdMessageConfiguration", IsRequired = false)]
        public int? IdMessageConfiguration { get; set; }

        [DataMember(Name = "IdMessage", IsRequired = false)]
        public int? IdMessage { get; set; }

        [DataMember(Name = "Page", IsRequired = false)]
        public string Page
        {
            get
            {
                if (this._Page == null) this._Page = string.Empty;
                return this._Page;
            }
            set { this._Page = value; }
        }

        [DataMember(Name = "Body", IsRequired = false)]
        public string Body
        {
            get
            {
                if (this._Body == null) this._Body = string.Empty;
                return this._Body;
            }
            set { this._Body = value; }
        }

        [DataMember(Name = "Subject", IsRequired = false)]
        public string Subject
        {
            get
            {
                if (this._Subject == null) this._Subject = string.Empty;
                return this._Subject;
            }
            set { this._Subject = value; }
        }

        [DataMember(Name = "OperationType", IsRequired = false)]
        public int OperationType
        {
            get
            {
                if (this._OperationType == null) this._OperationType = 0;
                return this._OperationType;
            }
            set { this._OperationType = value; }
        }

        #endregion
    }
}
