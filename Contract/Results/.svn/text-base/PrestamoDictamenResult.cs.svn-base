using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoDictamenResult : _PrestamoDictamenResult
    {
        public string UltimoEstadoNombre { get; set; }
        public string Analista_ApellidoYNombre { get; set; }
        public DateTime? UltimoEstado_Fecha { get; set; }
        public string UltimoEstado_Observacion { get; set; }


        #region Old Clase Base
        public int? PrestamoDictamenRelacionado_IdEstado { get; set; }
        public DateTime? PrestamoDictamenRelacionado_FechaEstado { get; set; }
        public string GestionTipo_Nombre { get; set; }
        public bool GestionTipo_Activo { get; set; }
        public string Organismo_Nombre { get; set; }
        public bool Organismo_Activo { get; set; }
        public string OrganismoFinanciero_Sigla { get; set; }
        public string OrganismoFinanciero_Nombre { get; set; }
        public bool OrganismoFinanciero_Activo { get; set; }
        public int? Prestamo_IdPrograma { get; set; }
        public int? Prestamo_Numero { get; set; }
        public string Prestamo_Denominacion { get; set; }
        public string Prestamo_Descripcion { get; set; }
        public string Prestamo_Observacion { get; set; }
        public DateTime? Prestamo_FechaAlta { get; set; }
        public DateTime? Prestamo_FechaModificacion { get; set; }
        public int? Prestamo_IdUsuarioModificacion { get; set; }
        public int? Prestamo_IdEstadoActual { get; set; }
        public string Prestamo_ResponsablePolitico { get; set; }
        public string Prestamo_ResponsableTecnico { get; set; }
        public string Prestamo_CodigoVinculacion1 { get; set; }
        public string Prestamo_CodigoVinculacion2 { get; set; }
        public string PrestamoCalificacion_Nombre { get; set; }
        public bool? PrestamoCalificacion_Activo { get; set; }
        public string Analista_NombreUsuario { get; set; }
        public string Analista_Clave { get; set; }
        public bool? Analista_Activo { get; set; }
        public bool? Analista_EsSectioralista { get; set; }
        public int? Analista_IdLanguage { get; set; }
        public bool? Analista_AccesoTotal { get; set; }
        public string UsuarioModificacion_NombreUsuario { get; set; }
        public string UsuarioModificacion_Clave { get; set; }
        public bool UsuarioModificacion_Activo { get; set; }
        public bool UsuarioModificacion_EsSectioralista { get; set; }
        public int UsuarioModificacion_IdLanguage { get; set; }
        public bool UsuarioModificacion_AccesoTotal { get; set; }	
        #endregion
        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("PrestamoDictamen", new List<DataColumnMapping>(new DataColumnMapping[]{
             new DataColumnMapping("Secuencia","IdPrestamoDictamen")
		    ,new DataColumnMapping("Expediente","Expediente")
			,new DataColumnMapping("Organismo Tipo","Organismo_Nombre")
			,new DataColumnMapping("Organismo Específico","OrganismoDetalle")
			,new DataColumnMapping("Denominación","Denominacion")
			,new DataColumnMapping("Gestion Tipo","GestionTipo_Nombre")
			,new DataColumnMapping("Organismo Financiero","OrganismoFinanciero_Nombre")
			,new DataColumnMapping("Monto Total","MontoTotal")
			,new DataColumnMapping("Monto Préstamo","MontoPrestamo")
			,new DataColumnMapping("Monto Contraparte","MontoContraparteLocal")
			,new DataColumnMapping("Monto Otros","MontoOtros")
            ,new DataColumnMapping("Préstamo Relacionado","Prestamo_Numero")
			//,new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Dictamen Relacionado","PrestamoDictamen_Expediente")
            ,new DataColumnMapping("Analista","Analista_ApellidoYNombre")
            ,new DataColumnMapping("Último Estado","UltimoEstadoNombre")
            ,new DataColumnMapping("Último Estado Fecha","UltimoEstado_Fecha","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Último Estado Observación ","UltimoEstado_Observacion","{0:dd/MM/yyyy}")

            ,new DataColumnMapping("Calificación","PrestamoCalificacion_Nombre")
			,new DataColumnMapping("Calificación Fecha","CalificacionFecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Número IT","CalificacioniTecnico")
			,new DataColumnMapping("Fecha IT","CalificacionitFecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Nota DNIP","CalificacionNotadnip")
			,new DataColumnMapping("Observación","CalificacionObservacion")
			,new DataColumnMapping("Recomendación","CalificacionRecomendacion")
            ,new DataColumnMapping("Otros","Comentario")

            ,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaModificacion","FechaModificacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioModificacion","Usuario_NombreUsuario")

			}));
             

        }
    }
}
