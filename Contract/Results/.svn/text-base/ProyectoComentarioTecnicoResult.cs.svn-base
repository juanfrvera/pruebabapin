using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoComentarioTecnicoResult : _ProyectoComentarioTecnicoResult
    {
        public string Proyecto_ProyectoTipoNombre { get; set; }
        public string Usuario_Nombre { get; set; }
        public string Programa_Nombre { get; set; }
        public string Denominacion { get; set; }
        public int Numero { get; set; }
        public string TipoProyecto { get; set; }
        public string Persona_Apellido { get; set; }
        public string Persona_Nombre { get; set; }
        public string NombreCompleto {get; set;}
        
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoComentarioTecnico", new List<DataColumnMapping>(new DataColumnMapping[]{
		     new DataColumnMapping("Proyecto","Numero")
            ,new DataColumnMapping("Denominación","Denominacion")
			,new DataColumnMapping("Tipo de Proyecto","TipoProyecto")
            ,new DataColumnMapping("Tipo","ComentarioTecnico_Nombre")
            ,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Usuario","NombreCompleto")
			,new DataColumnMapping("Observación","Observacion")			
			}));
        }


    }
}
