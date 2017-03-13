using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoSeguimientoLocalizacionFilter : _ProyectoSeguimientoLocalizacionFilter
    {
        public int IdProyectoDictamen { get; set; }
        public int? IdProyecto { get; set; }

        private List<int> idsProyectoSeguimiento;
        public List<int> IdsProyectoSeguimiento
        {
            get
            {
                if (idsProyectoSeguimiento == null) idsProyectoSeguimiento = new List<int>();
                return idsProyectoSeguimiento;
            }
            set { idsProyectoSeguimiento = value; }
        }
        
    }
}
