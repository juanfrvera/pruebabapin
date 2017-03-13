using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoSubConvenioData : _PrestamoSubConvenioData 
    { 
	   #region Singleton
	   private static volatile PrestamoSubConvenioData current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubConvenioData() {}
	   public static PrestamoSubConvenioData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubConvenioData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoSubConvenio"; } } 


        protected override IQueryable<PrestamoSubConvenioResult> QueryResult(PrestamoSubConvenioFilter filter)
        {
		  return (from o in base.QueryResult(filter)					
		            where ( filter.IdsPrestamoConvenio == null || filter.IdsPrestamoConvenio.Count == 0 ||
                        filter.IdsPrestamoConvenio.Contains ( o.IdPrestamoConvenio))
				   select new PrestamoSubConvenioResult(){
					 IdPrestamoSubConvenio=o.IdPrestamoSubConvenio
					 ,IdPrestamoConvenio=o.IdPrestamoConvenio
					 ,Codigo=o.Codigo
					 ,Descripcion=o.Descripcion
					 ,IdTipoSubConvenio=o.IdTipoSubConvenio
					 ,Contraparte=o.Contraparte
					 ,MontoTotal=o.MontoTotal
					 ,MontoPrestamo=o.MontoPrestamo
					 ,Fecha=o.Fecha
					 ,Ejecutor=o.Ejecutor
					 ,Observaciones=o.Observaciones
					,PrestamoConvenio_IdPrestamo= o.PrestamoConvenio_IdPrestamo	
						,PrestamoConvenio_IdOrganismoFinanciero= o.PrestamoConvenio_IdOrganismoFinanciero	
						,PrestamoConvenio_Sigla= o.PrestamoConvenio_Sigla	
						,PrestamoConvenio_Numero= o.PrestamoConvenio_Numero	
						,PrestamoConvenio_MontoTotal= o.PrestamoConvenio_MontoTotal	
						,PrestamoConvenio_MontoPrestamo= o.PrestamoConvenio_MontoPrestamo	
						,PrestamoConvenio_IdMoneda= o.PrestamoConvenio_IdMoneda	
						,PrestamoConvenio_Observacion= o.PrestamoConvenio_Observacion	
						,PrestamoConvenio_IdModalidadFinanciera= o.PrestamoConvenio_IdModalidadFinanciera	
						,PrestamoConvenio_DatosModalidadFinanciera= o.PrestamoConvenio_DatosModalidadFinanciera	
						,TipoSubConvenio_Nombre= o.TipoSubConvenio_Nombre	
						,TipoSubConvenio_Activo= o.TipoSubConvenio_Activo	
						}
                    ).AsQueryable();
        }

        
    }
}
