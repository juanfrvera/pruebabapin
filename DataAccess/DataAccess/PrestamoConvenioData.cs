using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoConvenioData : _PrestamoConvenioData 
    { 
	   #region Singleton
	   private static volatile PrestamoConvenioData current;
	   private static object syncRoot = new Object();

	   //private PrestamoConvenioData() {}
	   public static PrestamoConvenioData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoConvenioData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoConvenio"; } }

       protected override IQueryable<PrestamoConvenioResult> QueryResult(PrestamoConvenioFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.Monedas on o.IdMoneda equals t1.IdMoneda
                   join t2 in this.Context.OrganismoFinancieros on o.IdOrganismoFinanciero equals t2.IdOrganismoFinanciero
                   join t3 in this.Context.Prestamos on o.IdPrestamo equals t3.IdPrestamo
                   where (!filter.ConSigla ||  o.Sigla == filter.Sigla)
                   && (filter.IdPrestamoConvenio == null || filter.IdPrestamoConvenio == o.IdPrestamoConvenio)
                   && (filter.IdPrestamo == null || filter.IdPrestamo == o.IdPrestamo)
                   select new PrestamoConvenioResult()
                   {
                       IdPrestamoConvenio = o.IdPrestamoConvenio
                       ,IdPrestamo = o.IdPrestamo
                       ,IdOrganismoFinanciero = o.IdOrganismoFinanciero
                       ,Sigla = o.Sigla
                       ,Numero = o.Numero
                       ,MontoTotal = o.MontoTotal
                       ,MontoPrestamo = o.MontoPrestamo
                       ,IdMoneda = o.IdMoneda
                       ,Observacion = o.Observacion
                       ,IdModalidadFinanciera = o.IdModalidadFinanciera
                       ,DatosModalidadFinanciera = o.DatosModalidadFinanciera
                       ,Moneda_Sigla = t1.Sigla
                       ,Moneda_Nombre = t1.Nombre
                       ,Moneda_Activo = t1.Activo
                       ,Moneda_Base = t1.Base
                       ,OrganismoFinanciero_Sigla = t2.Sigla
                       ,OrganismoFinanciero_Nombre = t2.Nombre
                       ,OrganismoFinanciero_Activo = t2.Activo
                       ,Prestamo_IdPrograma = t3.IdPrograma
                       ,Prestamo_Numero = t3.Numero
                       ,Prestamo_Denominacion = t3.Denominacion
                       ,Prestamo_Descripcion = t3.Descripcion
                       ,Prestamo_Observacion = t3.Observacion
                       ,Prestamo_FechaAlta = t3.FechaAlta
                       ,Prestamo_FechaModificacion = t3.FechaModificacion
                       ,Prestamo_IdUsuarioModificacion = t3.IdUsuarioModificacion
                       ,Prestamo_IdEstadoActual = t3.IdEstadoActual
                       ,Prestamo_ResponsablePolitico = t3.ResponsablePolitico
                       ,Prestamo_ResponsableTecnico = t3.ResponsableTecnico
                       ,Prestamo_CodigoVinculacion1 = t3.CodigoVinculacion1
                       ,Prestamo_CodigoVinculacion2 = t3.CodigoVinculacion2
                   }
                     ).AsQueryable();
       }
    }
}
