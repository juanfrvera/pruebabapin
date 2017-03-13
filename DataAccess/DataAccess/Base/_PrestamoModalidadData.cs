using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _PrestamoModalidadData : EntityData<PrestamoModalidad,PrestamoModalidadFilter,PrestamoModalidadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoModalidad entity)
		{			
			return entity.IdPrestamoModalidad;
		}		
		public override PrestamoModalidad GetByEntity(PrestamoModalidad entity)
        {
            return this.GetById(entity.IdPrestamoModalidad);
        }
        public override PrestamoModalidad GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoModalidad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoModalidad> Query(PrestamoModalidadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoModalidad == null || o.IdPrestamoModalidad >=  filter.IdPrestamoModalidad) && (filter.IdPrestamoModalidad_To == null || o.IdPrestamoModalidad <= filter.IdPrestamoModalidad_To)
					  && (filter.IdPrestamoConvenio == null || filter.IdPrestamoConvenio == 0 || o.IdPrestamoConvenio==filter.IdPrestamoConvenio)
					  && (filter.IdModalidadFinanciera == null || filter.IdModalidadFinanciera == 0 || o.IdModalidadFinanciera==filter.IdModalidadFinanciera)
					  && (filter.Monto == null || o.Monto >=  filter.Monto) && (filter.Monto_To == null || o.Monto <= filter.Monto_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoModalidadResult> QueryResult(PrestamoModalidadFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ModalidadFinancieras on o.IdModalidadFinanciera equals t1.IdModalidadFinanciera   
				    join t2  in this.Context.PrestamoConvenios on o.IdPrestamoConvenio equals t2.IdPrestamoConvenio   
				   select new PrestamoModalidadResult(){
					 IdPrestamoModalidad=o.IdPrestamoModalidad
					 ,IdPrestamoConvenio=o.IdPrestamoConvenio
					 ,IdModalidadFinanciera=o.IdModalidadFinanciera
					 ,Monto=o.Monto
					,ModalidadFinanciera_IdOrganismoFinanciero= t1.IdOrganismoFinanciero	
						,ModalidadFinanciera_Sigla= t1.Sigla	
						,ModalidadFinanciera_Nombre= t1.Nombre	
						,ModalidadFinanciera_Activo= t1.Activo	
						,PrestamoConvenio_IdPrestamo= t2.IdPrestamo	
						,PrestamoConvenio_IdOrganismoFinanciero= t2.IdOrganismoFinanciero	
						,PrestamoConvenio_Sigla= t2.Sigla	
						//,PrestamoConvenio_Numero= t2.Numero	
						,PrestamoConvenio_MontoTotal= t2.MontoTotal	
						,PrestamoConvenio_MontoPrestamo= t2.MontoPrestamo	
						,PrestamoConvenio_IdMoneda= t2.IdMoneda	
						,PrestamoConvenio_Observacion= t2.Observacion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoModalidad Copy(nc.PrestamoModalidad entity)
        {           
            nc.PrestamoModalidad _new = new nc.PrestamoModalidad();
		 _new.IdPrestamoConvenio= entity.IdPrestamoConvenio;
		 _new.IdModalidadFinanciera= entity.IdModalidadFinanciera;
		 _new.Monto= entity.Monto;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(PrestamoModalidad entity, int id)
        {            
            entity.IdPrestamoModalidad = id;            
        }
		public override void Set(PrestamoModalidad source,PrestamoModalidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoModalidad= source.IdPrestamoModalidad ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.Monto= source.Monto ;
		 		  
		}
		public override void Set(PrestamoModalidadResult source,PrestamoModalidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoModalidad= source.IdPrestamoModalidad ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.Monto= source.Monto ;
		 
		}
		public override void Set(PrestamoModalidad source,PrestamoModalidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoModalidad= source.IdPrestamoModalidad ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.Monto= source.Monto ;
		 	
		}		
		public override void Set(PrestamoModalidadResult source,PrestamoModalidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoModalidad= source.IdPrestamoModalidad ;
		 target.IdPrestamoConvenio= source.IdPrestamoConvenio ;
		 target.IdModalidadFinanciera= source.IdModalidadFinanciera ;
		 target.Monto= source.Monto ;
		 target.ModalidadFinanciera_IdOrganismoFinanciero= source.ModalidadFinanciera_IdOrganismoFinanciero;	
			target.ModalidadFinanciera_Sigla= source.ModalidadFinanciera_Sigla;	
			target.ModalidadFinanciera_Nombre= source.ModalidadFinanciera_Nombre;	
			target.ModalidadFinanciera_Activo= source.ModalidadFinanciera_Activo;	
			target.PrestamoConvenio_IdPrestamo= source.PrestamoConvenio_IdPrestamo;	
			target.PrestamoConvenio_IdOrganismoFinanciero= source.PrestamoConvenio_IdOrganismoFinanciero;	
			target.PrestamoConvenio_Sigla= source.PrestamoConvenio_Sigla;	
			target.PrestamoConvenio_Numero= source.PrestamoConvenio_Numero;	
			target.PrestamoConvenio_MontoTotal= source.PrestamoConvenio_MontoTotal;	
			target.PrestamoConvenio_MontoPrestamo= source.PrestamoConvenio_MontoPrestamo;	
			target.PrestamoConvenio_IdMoneda= source.PrestamoConvenio_IdMoneda;	
			target.PrestamoConvenio_Observacion= source.PrestamoConvenio_Observacion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoModalidad source,PrestamoModalidad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoModalidad.Equals(target.IdPrestamoModalidad))return false;
		  if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if(!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoModalidadResult source,PrestamoModalidadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoModalidad.Equals(target.IdPrestamoModalidad))return false;
		  if(!source.IdPrestamoConvenio.Equals(target.IdPrestamoConvenio))return false;
		  if(!source.IdModalidadFinanciera.Equals(target.IdModalidadFinanciera))return false;
		  if(!source.Monto.Equals(target.Monto))return false;
		  if(!source.ModalidadFinanciera_IdOrganismoFinanciero.Equals(target.ModalidadFinanciera_IdOrganismoFinanciero))return false;
					  if(!source.ModalidadFinanciera_Sigla.Equals(target.ModalidadFinanciera_Sigla))return false;
					  if(!source.ModalidadFinanciera_Nombre.Equals(target.ModalidadFinanciera_Nombre))return false;
					  if(!source.ModalidadFinanciera_Activo.Equals(target.ModalidadFinanciera_Activo))return false;
					  if(!source.PrestamoConvenio_IdPrestamo.Equals(target.PrestamoConvenio_IdPrestamo))return false;
					  if(!source.PrestamoConvenio_IdOrganismoFinanciero.Equals(target.PrestamoConvenio_IdOrganismoFinanciero))return false;
					  if(!source.PrestamoConvenio_Sigla.Equals(target.PrestamoConvenio_Sigla))return false;
					  if((source.PrestamoConvenio_Numero == null)?target.PrestamoConvenio_Numero!=null:!source.PrestamoConvenio_Numero.Equals(target.PrestamoConvenio_Numero))return false;
						 if(!source.PrestamoConvenio_MontoTotal.Equals(target.PrestamoConvenio_MontoTotal))return false;
					  if(!source.PrestamoConvenio_MontoPrestamo.Equals(target.PrestamoConvenio_MontoPrestamo))return false;
					  if(!source.PrestamoConvenio_IdMoneda.Equals(target.PrestamoConvenio_IdMoneda))return false;
					  if(!source.PrestamoConvenio_Observacion.Equals(target.PrestamoConvenio_Observacion))return false;
					 		
		  return true;
        }
		#endregion
    }
}
