using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ClasificacionGastoResult : _ClasificacionGastoResult
    {
        public string PadreCodigoNombre
        {
            get
            {
                if (ClasificacionGastoPadre_Nombre == null)
                    return "[" + Codigo +"]";
                else
                    return String.Format("[{0}] {1}", ClasificacionGastoPadre_BreadcrumbCode.Substring(1,ClasificacionGastoPadre_BreadcrumbCode.Length - 2) , ClasificacionGastoPadre_Nombre);
            }
        }
        public string ClasificacionGastoPadre_BreadcrumbCodeOrden { get; set; }
        public string CaracterEconomico_Nombre { get; set; }
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("ClasificacionGasto", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("Padre","PadreCodigoNombre")
		    ,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel/Tipo","ClasificacionGastoTipo_Nombre")
			,new DataColumnMapping("Rubro","ClasificacionGastoRubro_Nombre")
			,new DataColumnMapping("CaracterEconomico","CaracterEconomico_Nombre")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
            ,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			}));
        }
    }
}
