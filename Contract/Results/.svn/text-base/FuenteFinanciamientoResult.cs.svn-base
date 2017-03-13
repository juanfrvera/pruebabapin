using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class FuenteFinanciamientoResult : _FuenteFinanciamientoResult
    {
        public string Descripcion2
        {
            get { return BreadcrumbCode + " - " + Nombre; }
        }
        public string CodigoDescripcion
        {
            get { return Codigo + " - " + Descripcion; }
        }
        public string FuenteFinanciamientoPadre_BreadcrumbCodeOrden { get; set; }
        public string PadreCodigoNombre
        {
            get
            {
                if (FuenteFinanciamientoPadre_Nombre == null)
                    return "[" + Codigo + "]";
                else
                    return String.Format("[{0}] {1}", FuenteFinanciamientoPadre_BreadcrumbCode.Substring(1, FuenteFinanciamientoPadre_BreadcrumbCode.Length - 2), FuenteFinanciamientoPadre_Nombre);
            }
        }
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("FuenteFinanciamiento", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("Padre","PadreCodigoNombre")
		    ,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel/Tipo","FuenteFinanciamientoTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
            ,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			}));
        }
    }
}
