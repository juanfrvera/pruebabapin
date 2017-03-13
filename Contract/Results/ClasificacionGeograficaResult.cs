using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ClasificacionGeograficaResult : IResult<int>
    {
        public virtual int ID { get { return IdClasificacionGeografica; } }
        public int IdClasificacionGeografica { get; set; }
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public int IdClasificacionGeograficaTipo { get; set; }
        public int? IdClasificacionGeograficaPadre { get; set; }
        public bool Activo { get; set; }
        public string Descripcion { get; set; }
        public string BreadcrumbId { get; set; }
        public string BreadcrumOrden { get; set; }
        public int? Orden { get; set; }
        public int? Nivel { get; set; }
        public string DescripcionInvertida { get; set; }
        public bool Seleccionable { get; set; }
        public string BreadcrumbCode { get; set; }
        public string DescripcionCodigo { get; set; }
        public string ClasificacionGeograficaPadre_Nombre { get; set; }
        public string ClasificacionGeograficaPadre_BreadcrumbCode { get; set; }
        public string ClasificacionGeograficaTipo_Nombre { get; set; }
        public int ClasificacionGeograficaTipo_Nivel { get; set; }	
		
        public string PadreCodigoNombre
        {
            get
            {
                if (ClasificacionGeograficaPadre_Nombre == null)
                    return "[" + Codigo + "]";
                else
                    return String.Format("[{0}] {1}", ClasificacionGeograficaPadre_BreadcrumbCode.Substring(1, ClasificacionGeograficaPadre_BreadcrumbCode.Length - 2), ClasificacionGeograficaPadre_Nombre);
            }
        }
        public bool Selected { get; set; }
        public string ClasificacionGeograficaPadre_BreadcrumbCodeOrden { get; set; }
        public virtual DataTableMapping ToMapping()
        {
            return new DataTableMapping("ClasificacionGeografica", new List<DataColumnMapping>(new DataColumnMapping[]{
                new DataColumnMapping("Padre","PadreCodigoNombre")
		    ,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Nivel/Tipo","ClasificacionGeograficaTipo_Nombre")
			,new DataColumnMapping("Activo","Activo")
            ,new DataColumnMapping("Seleccionable","Seleccionable")
            ,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("BreadcrumbCode","BreadcrumbCode")
			}));
        }
        
    }
}
