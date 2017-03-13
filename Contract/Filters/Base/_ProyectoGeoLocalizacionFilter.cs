using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;

namespace Contract.Base
{
    [Serializable, DataContract]
    public abstract class _ProyectoGeoLocalizacionFilter : Filter
    {
        #region Private

        private string _TipoLocalizacion;

        private string _InfoLocalizacion;

        #endregion

        #region Properties

        [DataMember(Name = "IdProyecto", IsRequired = false)]
        public int IdProyecto { get; set; }

        [DataMember(Name = "IdGeoLocalizacion", IsRequired = false)]
        public int IdGeoLocalizacion { get; set; }

        [DataMember(Name = "TipoLocalizacion", IsRequired = false)]
        public string TipoLocalizacion
        {
            get
            {
                if (this._TipoLocalizacion == null) this._TipoLocalizacion = string.Empty;
                return this._TipoLocalizacion;
            }
            set { this._TipoLocalizacion = value; }
        }

        [DataMember(Name = "InfoLocalizacion", IsRequired = false)]
        public string InfoLocalizacion
        {
            get
            {
                if (this._InfoLocalizacion == null) this._InfoLocalizacion = string.Empty;
                return this._InfoLocalizacion;
            }
            set { this._InfoLocalizacion = value; }
        }

        #endregion
    }
}
