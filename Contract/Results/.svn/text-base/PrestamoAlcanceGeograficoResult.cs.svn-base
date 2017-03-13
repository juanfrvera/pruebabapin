using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoAlcanceGeograficoResult : _PrestamoAlcanceGeograficoResult
    {
        public string Descripcion
        {
            get { return ClasificacionGeografica_Descripcion; }
            set { ClasificacionGeografica_Descripcion = value; }
        }
        public Int32 Tipo
        {
            get { return ClasificacionGeografica_IdClasificacionGeograficaTipo; }
            set { ClasificacionGeografica_IdClasificacionGeograficaTipo = value; }
        }
        public string Orden
        {
            get { return ClasificacionGeografica_IdClasificacionGeograficaTipo.ToString() + ClasificacionGeografica_Descripcion; }
        }
    }
}
