using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contract.Base
{
    [Serializable, DataContract]
    public abstract class _ProyectoShapeFileFilter : Filter
    {
        #region Private

        private string _RutaArchivo;

        #endregion

        #region Properties

        [DataMember(Name = "IdProyecto", IsRequired = false)]
        public int IdProyecto { get; set; }

        [DataMember(Name = "IdProyectoShapeFile", IsRequired = false)]
        public int IdProyectoShapeFile { get; set; }

        [DataMember(Name = "RutaArchivo", IsRequired = false)]
        public string RutaArchivo
        {
            get
            {
                if (this._RutaArchivo == null) this._RutaArchivo = string.Empty;
                return this._RutaArchivo;
            }
            set { this._RutaArchivo = value; }
        }

        #endregion
    }
}
