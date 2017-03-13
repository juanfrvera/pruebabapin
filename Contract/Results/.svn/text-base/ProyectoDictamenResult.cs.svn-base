using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoDictamenResult : _ProyectoDictamenResult
    {

        public string Saf_Codigo { get; set; }
        public string Saf_Denominacion { get; set; }
        public string Analista_Apellido { get; set; }
        public string Analista_Nombre { get; set; }
        public string ProyectoSeguimiento_Ruta { get; set; }
        public string ProyectoSeguimiento_Malla { get; set; }

        public string Saf_CodigoDenominacion { get { return String.Format("{0}-{1}", Saf_Codigo, Saf_Denominacion); } }
        public string Analista_ApellidoYNombre { get { return String.Format("{0} {1}", Analista_Apellido, Analista_Nombre); } }
        public int? IdUltimoEstado { get; set; }
        public string UltimoEstadoNombre { get; set; }
        public DateTime UltimoEstadoFecha { get; set; }
        public string Dictamen_ProvinciasConcatenadas { get; set; }
        public string Dictamen_ProyectosConcatenados { get; set; }

        

        public override  DataTableMapping ToMapping()
        {
            return new DataTableMapping("ProyectoDictamen", new List<DataColumnMapping>(new DataColumnMapping[]{
            new DataColumnMapping("Secuencia","IdProyectoDictamen")
            ,new DataColumnMapping("Número","Numero")
            ,new DataColumnMapping("Saf","Saf_CodigoDenominacion")
            ,new DataColumnMapping("Denominación","Denominacion")
            ,new DataColumnMapping("Motivo Int.","PlanPeriodo_Nombre")
            ,new DataColumnMapping("Ejercicio","Ejercicio")
            ,new DataColumnMapping("Monto","Monto")
			,new DataColumnMapping("Duración","DuracionMeses")
            ,new DataColumnMapping("Estado","UltimoEstadoNombre")
            ,new DataColumnMapping("Fecha Estado","UltimoEstadoFecha","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Calificación","ProyectoCalificacion_Nombre")
            ,new DataColumnMapping("Fecha Calif.","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Fecha Vencimiento","FechaVencimiento","{0:dd/MM/yyyy}")
			,new DataColumnMapping("I.Técnico","InformeTecnico")
            ,new DataColumnMapping("Fecha IT","FechaComiteTecnico","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Observación","Observacion")
            ,new DataColumnMapping("Recomendación","Recomendacion")
            ,new DataColumnMapping("Respuesta Organismo","RespuestaOrganismo")
            ,new DataColumnMapping("FechaRepuesta","Fecha Repuesta","{0:dd/MM/yyyy}")
            
            ,new DataColumnMapping("Analista","Analista_ApellidoYNombre")
            ,new DataColumnMapping("Ruta","ProyectoSeguimiento_Ruta")
            ,new DataColumnMapping("Malla","ProyectoSeguimiento_Malla")
            
			
			}));
            
        }
        
    }
}
