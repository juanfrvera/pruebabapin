using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ProyectoSeguimientoFilter : _ProyectoSeguimientoFilter
    {
        public int IdProyectoDictamen { get; set; }
        public int IdProyecto { get; set; }

        private List<int> idsEstado;
        public List<int> IdsEstado
        {
            get
            {
                if (idsEstado == null) idsEstado = new List<int>();
                return idsEstado;
            }
            set { idsEstado = value; }
        }
        
        public Int32? Proyecto_Codigo { get; set; }
    }
}
