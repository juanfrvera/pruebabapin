using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class CaracterEconomicoResult : _CaracterEconomicoResult
    {
        public string PadreCodigoNombre
        {
            get
            {
                if (CaracterEconomicoPadre_Nombre == null)
                    return "[" + Codigo + "]";
                else
                    return String.Format("[{0}] {1}", CaracterEconomicoPadre_BreadcrumbCode.Substring(1, CaracterEconomicoPadre_BreadcrumbCode.Length - 2), CaracterEconomicoPadre_Nombre);
            }
        }
      public string CaracterEconomicoPadre_BreadcrumbCodeOrden { get; set; }
      public override DataTableMapping ToMapping()
      {
          return new DataTableMapping("CaracterEconomico", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("Padre","PadreCodigoNombre")
		    ,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel/Tipo","CaracterEconomicoTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
            ,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			}));
      }
    }
}
