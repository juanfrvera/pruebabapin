using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class OficinaResult : _OficinaResult
    {
        public string Jurisdiccion_Codigo { get; set; }
        public string Oficina_NombrePadre { get; set; }
        public string Oficina_DescripcionPadre { get; set; }
        public string Jurisdiccion_Nombre { get; set; }
        public string OficinaPadre_BreadcrumbCodeOrden { get; set; }
        public string PadreCodigoNombre
        {
            get
            {
                if (OficinaPadre_Nombre == null)
                    return "[" + Codigo + "]";
                else
                    return String.Format("[{0}] {1}", OficinaPadre_BreadcrumbCode.Substring(1, OficinaPadre_BreadcrumbCode.Length - 2), OficinaPadre_Nombre);
            }
        }
        public string CodigoJurisdiccion_Nombre
        {
            get
            {
                if (Jurisdiccion_Codigo != null)
                    return String.Format("{0}-{1}", Jurisdiccion_Codigo, Jurisdiccion_Nombre);
                else
                    return "";
            }
        }
        public string SafJurisdiccion_Nombre
        {
            get
            {
                if (Saf_Codigo != null)
                    return String.Format("{0}-{1}", Saf_Codigo, Saf_Denominacion);
                else
                    return "";
            }
        }

        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("Oficina", new List<DataColumnMapping>(new DataColumnMapping[]{
                   new DataColumnMapping("Padre","PadreCodigoNombre")
			,new DataColumnMapping("Codigo","Codigo")
		    ,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Jurisdiccion","CodigoJurisdiccion_Nombre")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
			,new DataColumnMapping("Visible","Visible")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Saf Propio","SafJurisdiccion_Nombre")
			}));
        }
    }
}
