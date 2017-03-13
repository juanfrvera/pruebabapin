using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoDictamenData : _PrestamoDictamenData 
    { 
	   #region Singleton
	   private static volatile PrestamoDictamenData current;
	   private static object syncRoot = new Object();

	   //private PrestamoDictamenData() {}
	   public static PrestamoDictamenData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoDictamenData();
				}
			 }
			 return current;
		  }
	   }
       //protected override IQueryable<PrestamoDictamen> Query(PrestamoDictamenFilter filter)
       //{
       //    return (from o in base.Query(filter)
       //            where
       //                  (filter.IdPrestamoDictamen_From == null || o.IdPrestamoDictamen >= filter.IdPrestamoDictamen_From) && (filter.IdPrestamoDictamen_To == null || o.IdPrestamoDictamen <= filter.IdPrestamoDictamen_To)
       //                select o
       //            ).AsQueryable();
       //}

       protected override IQueryable<PrestamoDictamen> Query(PrestamoDictamenFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdPrestamoDictamen == null || filter.IdPrestamoDictamen == 0 || o.IdPrestamoDictamen == filter.IdPrestamoDictamen)
                   && (filter.Expediente == null || filter.Expediente.Trim() == string.Empty || filter.Expediente.Trim() == "%" || (filter.Expediente.EndsWith("%") && filter.Expediente.StartsWith("%") && (o.Expediente.Contains(filter.Expediente.Replace("%", "")))) || (filter.Expediente.EndsWith("%") && o.Expediente.StartsWith(filter.Expediente.Replace("%", ""))) || (filter.Expediente.StartsWith("%") && o.Expediente.EndsWith(filter.Expediente.Replace("%", ""))) || o.Expediente == filter.Expediente)
                      && (filter.IDOrganismo == null || filter.IDOrganismo == 0 || o.IDOrganismo == filter.IDOrganismo)
                     // && (filter.IDOrganismoIsNull == null || filter.IDOrganismoIsNull == true || o.IDOrganismo != null) && (filter.IDOrganismoIsNull == null || filter.IDOrganismoIsNull == false || o.IDOrganismo == null)
                   && (filter.OrganismoDetalle == null || filter.OrganismoDetalle.Trim() == string.Empty || filter.OrganismoDetalle.Trim() == "%" || (filter.OrganismoDetalle.EndsWith("%") && filter.OrganismoDetalle.StartsWith("%") && (o.OrganismoDetalle.Contains(filter.OrganismoDetalle.Replace("%", "")))) || (filter.OrganismoDetalle.EndsWith("%") && o.OrganismoDetalle.StartsWith(filter.OrganismoDetalle.Replace("%", ""))) || (filter.OrganismoDetalle.StartsWith("%") && o.OrganismoDetalle.EndsWith(filter.OrganismoDetalle.Replace("%", ""))) || o.OrganismoDetalle == filter.OrganismoDetalle)
                   && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                      && (filter.IdGestionTipo == null || filter.IdGestionTipo == 0 || o.IdGestionTipo == filter.IdGestionTipo)
                      //&& (filter.IdGestionTipoIsNull == null || filter.IdGestionTipoIsNull == true || o.IdGestionTipo != null) && (filter.IdGestionTipoIsNull == null || filter.IdGestionTipoIsNull == false || o.IdGestionTipo == null)
                      && (filter.IdOrganismoFinanciero == null || filter.IdOrganismoFinanciero == 0 || o.IdOrganismoFinanciero == filter.IdOrganismoFinanciero)
                      //&& (filter.IdOrganismoFinancieroIsNull == null || filter.IdOrganismoFinancieroIsNull == true || o.IdOrganismoFinanciero != null) && (filter.IdOrganismoFinancieroIsNull == null || filter.IdOrganismoFinancieroIsNull == false || o.IdOrganismoFinanciero == null)
                      
                      //Matias 20141126 - Tarea 181
                      && (filter.Prestamo_Numero == null || filter.Prestamo_Numero == 0 || (from pre in this.Context.Prestamos where filter.Prestamo_Numero == pre.Numero select pre.IdPrestamo).Contains(Convert.ToInt32(o.IdPrestamo)))
                      //Matias 20141126 - Tarea 181

                      //Matias 20150130 - Tarea 195
                      && (filter.IdPrestamoDictamen_From == null || o.IdPrestamoDictamen >= filter.IdPrestamoDictamen_From) 
                      && (filter.IdPrestamoDictamen_To == null || o.IdPrestamoDictamen <= filter.IdPrestamoDictamen_To)
                      //Matias 20150130 - Tarea 195

                   && (filter.MontoTotal == null || o.MontoTotal >= filter.MontoTotal) && (filter.MontoTotal_To == null || o.MontoTotal <= filter.MontoTotal_To)
                   && (filter.MontoTotalIsNull == null || filter.MontoTotalIsNull == true || o.MontoTotal != null) && (filter.MontoTotalIsNull == null || filter.MontoTotalIsNull == false || o.MontoTotal == null)
                   && (filter.MontoPrestamo == null || o.MontoPrestamo >= filter.MontoPrestamo) && (filter.MontoPrestamo_To == null || o.MontoPrestamo <= filter.MontoPrestamo_To)
                   && (filter.MontoPrestamoIsNull == null || filter.MontoPrestamoIsNull == true || o.MontoPrestamo != null) && (filter.MontoPrestamoIsNull == null || filter.MontoPrestamoIsNull == false || o.MontoPrestamo == null)
                   && (filter.MontoContraparteLocal == null || o.MontoContraparteLocal >= filter.MontoContraparteLocal) && (filter.MontoContraparteLocal_To == null || o.MontoContraparteLocal <= filter.MontoContraparteLocal_To)
                   && (filter.MontoContraparteLocalIsNull == null || filter.MontoContraparteLocalIsNull == true || o.MontoContraparteLocal != null) && (filter.MontoContraparteLocalIsNull == null || filter.MontoContraparteLocalIsNull == false || o.MontoContraparteLocal == null)
                   && (filter.MontoOtros == null || o.MontoOtros >= filter.MontoOtros) && (filter.MontoOtros_To == null || o.MontoOtros <= filter.MontoOtros_To)
                   && (filter.MontoOtrosIsNull == null || filter.MontoOtrosIsNull == true || o.MontoOtros != null) && (filter.MontoOtrosIsNull == null || filter.MontoOtrosIsNull == false || o.MontoOtros == null)
                      && (filter.IdAnalista == null || filter.IdAnalista == 0 || o.IdAnalista == filter.IdAnalista)
                      && (filter.IdAnalistaIsNull == null || filter.IdAnalistaIsNull == true || o.IdAnalista != null) && (filter.IdAnalistaIsNull == null || filter.IdAnalistaIsNull == false || o.IdAnalista == null)
                      && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo == filter.IdPrestamo)
                      && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == true || o.IdPrestamo != null) && (filter.IdPrestamoIsNull == null || filter.IdPrestamoIsNull == false || o.IdPrestamo == null)
                   && (filter.IdPrestamoDictamenRelacionado == null || filter.IdPrestamoDictamenRelacionado == 0 || o.IdPrestamoDictamenRelacionado == filter.IdPrestamoDictamenRelacionado)
                   && (filter.IdPrestamoDictamenRelacionadoIsNull == null || filter.IdPrestamoDictamenRelacionadoIsNull == true || o.IdPrestamoDictamenRelacionado != null) && (filter.IdPrestamoDictamenRelacionadoIsNull == null || filter.IdPrestamoDictamenRelacionadoIsNull == false || o.IdPrestamoDictamenRelacionado == null)
                   && (filter.Comentario == null || filter.Comentario.Trim() == string.Empty || filter.Comentario.Trim() == "%" || (filter.Comentario.EndsWith("%") && filter.Comentario.StartsWith("%") && (o.Comentario.Contains(filter.Comentario.Replace("%", "")))) || (filter.Comentario.EndsWith("%") && o.Comentario.StartsWith(filter.Comentario.Replace("%", ""))) || (filter.Comentario.StartsWith("%") && o.Comentario.EndsWith(filter.Comentario.Replace("%", ""))) || o.Comentario == filter.Comentario)
                      && (filter.IDPrestamoCalificacion == null || filter.IDPrestamoCalificacion == 0 || o.IDPrestamoCalificacion == filter.IDPrestamoCalificacion)
                      && (filter.IDPrestamoCalificacionIsNull == null || filter.IDPrestamoCalificacionIsNull == true || o.IDPrestamoCalificacion != null) && (filter.IDPrestamoCalificacionIsNull == null || filter.IDPrestamoCalificacionIsNull == false || o.IDPrestamoCalificacion == null)					  
                   && (filter.CalificacionFecha == null || filter.CalificacionFecha == DateTime.MinValue || o.CalificacionFecha >= filter.CalificacionFecha) && (filter.CalificacionFecha_To == null || filter.CalificacionFecha_To == DateTime.MinValue || o.CalificacionFecha <= filter.CalificacionFecha_To)
                   && (filter.CalificacionFechaIsNull == null || filter.CalificacionFechaIsNull == true || o.CalificacionFecha != null) && (filter.CalificacionFechaIsNull == null || filter.CalificacionFechaIsNull == false || o.CalificacionFecha == null)
                   && (filter.CalificacionITecnico == null || filter.CalificacionITecnico.Trim() == string.Empty || filter.CalificacionITecnico.Trim() == "%" || (filter.CalificacionITecnico.EndsWith("%") && filter.CalificacionITecnico.StartsWith("%") && (o.CalificacionITecnico.Contains(filter.CalificacionITecnico.Replace("%", "")))) || (filter.CalificacionITecnico.EndsWith("%") && o.CalificacionITecnico.StartsWith(filter.CalificacionITecnico.Replace("%", ""))) || (filter.CalificacionITecnico.StartsWith("%") && o.CalificacionITecnico.EndsWith(filter.CalificacionITecnico.Replace("%", ""))) || o.CalificacionITecnico == filter.CalificacionITecnico)
                   && (filter.CalificacionITFecha == null || filter.CalificacionITFecha == DateTime.MinValue || o.CalificacionITFecha >= filter.CalificacionITFecha) && (filter.CalificacionITFecha_To == null || filter.CalificacionITFecha_To == DateTime.MinValue || o.CalificacionITFecha <= filter.CalificacionITFecha_To)
                   && (filter.CalificacionITFechaIsNull == null || filter.CalificacionITFechaIsNull == true || o.CalificacionITFecha != null) && (filter.CalificacionITFechaIsNull == null || filter.CalificacionITFechaIsNull == false || o.CalificacionITFecha == null)
                   && (filter.CalificacionNotaDNIP == null || filter.CalificacionNotaDNIP.Trim() == string.Empty || filter.CalificacionNotaDNIP.Trim() == "%" || (filter.CalificacionNotaDNIP.EndsWith("%") && filter.CalificacionNotaDNIP.StartsWith("%") && (o.CalificacionNotaDNIP.Contains(filter.CalificacionNotaDNIP.Replace("%", "")))) || (filter.CalificacionNotaDNIP.EndsWith("%") && o.CalificacionNotaDNIP.StartsWith(filter.CalificacionNotaDNIP.Replace("%", ""))) || (filter.CalificacionNotaDNIP.StartsWith("%") && o.CalificacionNotaDNIP.EndsWith(filter.CalificacionNotaDNIP.Replace("%", ""))) || o.CalificacionNotaDNIP == filter.CalificacionNotaDNIP)
                   && (filter.CalificacionObservacion == null || filter.CalificacionObservacion.Trim() == string.Empty || filter.CalificacionObservacion.Trim() == "%" || (filter.CalificacionObservacion.EndsWith("%") && filter.CalificacionObservacion.StartsWith("%") && (o.CalificacionObservacion.Contains(filter.CalificacionObservacion.Replace("%", "")))) || (filter.CalificacionObservacion.EndsWith("%") && o.CalificacionObservacion.StartsWith(filter.CalificacionObservacion.Replace("%", ""))) || (filter.CalificacionObservacion.StartsWith("%") && o.CalificacionObservacion.EndsWith(filter.CalificacionObservacion.Replace("%", ""))) || o.CalificacionObservacion == filter.CalificacionObservacion)
                   && (filter.CalificacionRecomendacion == null || filter.CalificacionRecomendacion.Trim() == string.Empty || filter.CalificacionRecomendacion.Trim() == "%" || (filter.CalificacionRecomendacion.EndsWith("%") && filter.CalificacionRecomendacion.StartsWith("%") && (o.CalificacionRecomendacion.Contains(filter.CalificacionRecomendacion.Replace("%", "")))) || (filter.CalificacionRecomendacion.EndsWith("%") && o.CalificacionRecomendacion.StartsWith(filter.CalificacionRecomendacion.Replace("%", ""))) || (filter.CalificacionRecomendacion.StartsWith("%") && o.CalificacionRecomendacion.EndsWith(filter.CalificacionRecomendacion.Replace("%", ""))) || o.CalificacionRecomendacion == filter.CalificacionRecomendacion)
                   && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >= filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
                   && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >= filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
                   && (filter.IDUsuarioModificacion == null || o.IDUsuarioModificacion >= filter.IDUsuarioModificacion) && (filter.IDUsuarioModificacion_To == null || o.IDUsuarioModificacion <= filter.IDUsuarioModificacion_To)
                      && (filter.IdPrestamoDictamenEstado == null || filter.IdPrestamoDictamenEstado == 0 || o.IdPrestamoDictamenEstado == filter.IdPrestamoDictamenEstado)
                      && (filter.IdPrestamoDictamenEstadoIsNull == null || filter.IdPrestamoDictamenEstadoIsNull == true || o.IdPrestamoDictamenEstado != null) && (filter.IdPrestamoDictamenEstadoIsNull == null || filter.IdPrestamoDictamenEstadoIsNull == false || o.IdPrestamoDictamenEstado == null)					  					  
                   select o
                   ).AsQueryable();
       }	


       protected override IQueryable<PrestamoDictamenResult>  QueryResult(PrestamoDictamenFilter filter)
       {
           //Daniela
           return (from o in Query(filter)
                   join gt in this.Context.GestionTipos on o.IdGestionTipo equals gt.IdGestionTipo
                   join og in this.Context.Organismos on o.IDOrganismo equals og.IdOrganismo
                   join of in this.Context.OrganismoFinancieros on o.IdOrganismoFinanciero equals of.IdOrganismoFinanciero
                   //join pde in this.Context.PrestamoDictamenEstados on o.IdPrestamoDictamenEstado equals pde.IdPrestamoDictamenEstado
                   //cuando modifiques la base de la tabla prestamos dictamenes hay que eliminar la linea que esta abajo y habilitar la comentada
                   join pde in this.Context.PrestamoDictamenEstados on o.IdPrestamoDictamenEstado  equals pde.IdPrestamoDictamenEstado
                   join e in this.Context.Estados on pde.IdEstado equals e.IdEstado
                   join _a in this.Context.Personas on o.IdAnalista equals _a.IdPersona
                   into ta from a in ta.DefaultIfEmpty()
                   join _pr in this.Context.Prestamos on o.IdPrestamo equals _pr.IdPrestamo 
                   into tpr from pr in tpr.DefaultIfEmpty()
                   join _pc in this.Context.PrestamoCalificacions on o.IDPrestamoCalificacion equals _pc.IdPrestamoCalificacion
                   into tpc from pc in tpc.DefaultIfEmpty()
                   join _pd in this.Context.PrestamoDictamens on o.IdPrestamoDictamenRelacionado equals _pd.IdPrestamoDictamen
                   into tpd from pd in tpd.DefaultIfEmpty()
                   where
                   (filter.IdsEstado == null || filter.IdsEstado.Count == 0 || filter.IdsEstado.Contains((int)e.IdEstado))                   

                   select new PrestamoDictamenResult ()
                   {
                       IdPrestamoDictamen = o.IdPrestamoDictamen
                       ,Expediente = o.Expediente
                       ,IDOrganismo = o.IDOrganismo
                       ,OrganismoDetalle = o.OrganismoDetalle
                       ,Denominacion = o.Denominacion
                       ,IdGestionTipo = o.IdGestionTipo
                       ,IdOrganismoFinanciero = o.IdOrganismoFinanciero
                       ,MontoTotal = o.MontoTotal
                       ,MontoPrestamo = o.MontoPrestamo
                       ,MontoContraparteLocal = o.MontoContraparteLocal
                       ,MontoOtros = o.MontoOtros
                       ,IdAnalista = o.IdAnalista
                       ,IdPrestamo = o.IdPrestamo
                       ,IdPrestamoDictamenRelacionado = o.IdPrestamoDictamenRelacionado
                       ,Comentario = o.Comentario
                       ,IDPrestamoCalificacion = o.IDPrestamoCalificacion
                       ,CalificacionFecha = o.CalificacionFecha
                       ,CalificacionITecnico = o.CalificacionITecnico
                       ,CalificacionITFecha = o.CalificacionITFecha
                       ,CalificacionNotaDNIP = o.CalificacionNotaDNIP
                       ,CalificacionObservacion = o.CalificacionObservacion
                       ,CalificacionRecomendacion = o.CalificacionRecomendacion
                       ,FechaAlta = o.FechaAlta
                       ,FechaModificacion = o.FechaModificacion
                       ,IDUsuarioModificacion = o.IDUsuarioModificacion
                       ,IdPrestamoDictamenEstado  = o.IdPrestamoDictamenEstado
                       ,GestionTipo_Nombre=gt.Nombre
                       ,Organismo_Nombre=og.Nombre
                       ,OrganismoFinanciero_Nombre=of.Nombre
                       ,OrganismoFinanciero_Sigla = of.Sigla
                       ,Prestamo_Numero= pr != null ?  (int?)pr.Numero : null
                       ,Analista_ApellidoYNombre= a != null ?  (string) a.NombreCompleto : null
                       ,PrestamoCalificacion_Nombre= pc != null ?  (string) pc.Nombre : null
                       ,UltimoEstado_Fecha=pde.Fecha
                       ,UltimoEstadoNombre=e.Nombre
                       ,UltimoEstado_Observacion=pde.Observacion
                       ,PrestamoDictamenRelacionado_Expediente=pd.Expediente
                       
                   }
                ).AsQueryable();
           }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoDictamen"; } }
       public List<PrestamoDictamenResult> QueryResultExcel(PrestamoDictamenFilter filter)
       {

           return QueryResult(filter).ToList();
       }
    }
}