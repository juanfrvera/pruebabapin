using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;

namespace Contract.Base
{
    [Serializable, DataContract]
    public abstract class _ProyectoDictamenFileFilter : Filter
    {
        #region Properties
        [DataMember(Name = "IdProyectoDictamenFile", IsRequired = false)]
        public int? IdProyectoDictamenFile { get; set; }
        [DataMember(Name = "IdProyectoDictamenFile_To", IsRequired = false)]
        public int? IdProyectoDictamenFile_To { get; set; }
        [DataMember(Name = "IdProyectoDictamen", IsRequired = false)]
        public int? IdProyectoDictamen { get; set; }
        [DataMember(Name = "IdFile", IsRequired = false)]
        public int? IdFile { get; set; }

        #endregion
    }
}
