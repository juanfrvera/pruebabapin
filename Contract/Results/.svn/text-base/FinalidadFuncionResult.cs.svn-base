using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class FinalidadFuncionResult : _FinalidadFuncionResult
    {
        public string FinalidadFuncionPadre_BreadcrumbCodeOrden { get; set; }
        public string PadreCodigoNombre
        {
            get
            {
                if (FinalidadFuncionPadre_Denominacion == null)
                    return "[" + Codigo + "]";
                else
                    return String.Format("[{0}] {1}", FinalidadFuncionPadre_BreadcrumbCode.Substring(1, FinalidadFuncionPadre_BreadcrumbCode.Length - 2), FinalidadFuncionPadre_Denominacion);
            }
        }

        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("FinalidadFuncion", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("Padre","PadreCodigoNombre")
		    ,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("Nivel/Tipo","FinalidadFunciontipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
            ,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			}));
        }
    }
}
