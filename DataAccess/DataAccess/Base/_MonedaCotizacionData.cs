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
    public abstract class _MonedaCotizacionData : EntityData<MonedaCotizacion,MonedaCotizacionFilter,MonedaCotizacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.MonedaCotizacion entity)
		{			
			return entity.IdMonedaCotizacion;
		}		
		public override MonedaCotizacion GetByEntity(MonedaCotizacion entity)
        {
            return this.GetById(entity.IdMonedaCotizacion);
        }
        public override MonedaCotizacion GetById(int id)
        {
            return (from o in this.Table where o.IdMonedaCotizacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<MonedaCotizacion> Query(MonedaCotizacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdMonedaCotizacion == null || o.IdMonedaCotizacion >=  filter.IdMonedaCotizacion) && (filter.IdMonedaCotizacion_To == null || o.IdMonedaCotizacion <= filter.IdMonedaCotizacion_To)
					  && (filter.IdMoneda == null || filter.IdMoneda == 0 || o.IdMoneda==filter.IdMoneda)
					  && (filter.Fecha == null || filter.Fecha == DateTime.MinValue || o.Fecha >=  filter.Fecha) && (filter.Fecha_To == null || filter.Fecha_To == DateTime.MinValue || o.Fecha <= filter.Fecha_To)
					  && (filter.Cotizacion == null || o.Cotizacion >=  filter.Cotizacion) && (filter.Cotizacion_To == null || o.Cotizacion <= filter.Cotizacion_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<MonedaCotizacionResult> QueryResult(MonedaCotizacionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Monedas on o.IdMoneda equals t1.IdMoneda   
				   select new MonedaCotizacionResult(){
					 IdMonedaCotizacion=o.IdMonedaCotizacion
					 ,IdMoneda=o.IdMoneda
					 ,Fecha=o.Fecha
					 ,Cotizacion=o.Cotizacion
					,Moneda_Sigla= t1.Sigla	
						,Moneda_Nombre= t1.Nombre	
						,Moneda_Activo= t1.Activo	
						,Moneda_Base= t1.Base	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.MonedaCotizacion Copy(nc.MonedaCotizacion entity)
        {           
            nc.MonedaCotizacion _new = new nc.MonedaCotizacion();
		 _new.IdMoneda= entity.IdMoneda;
		 _new.Fecha= entity.Fecha;
		 _new.Cotizacion= entity.Cotizacion;
		return _new;			
        }
		public override int CopyAndSave(MonedaCotizacion entity,string renameFormat)
        {
            MonedaCotizacion  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(MonedaCotizacion entity, int id)
        {            
            entity.IdMonedaCotizacion = id;            
        }
		public override void Set(MonedaCotizacion source,MonedaCotizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMonedaCotizacion= source.IdMonedaCotizacion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Fecha= source.Fecha ;
		 target.Cotizacion= source.Cotizacion ;
		 		  
		}
		public override void Set(MonedaCotizacionResult source,MonedaCotizacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMonedaCotizacion= source.IdMonedaCotizacion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Fecha= source.Fecha ;
		 target.Cotizacion= source.Cotizacion ;
		 
		}
		public override void Set(MonedaCotizacion source,MonedaCotizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMonedaCotizacion= source.IdMonedaCotizacion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Fecha= source.Fecha ;
		 target.Cotizacion= source.Cotizacion ;
		 	
		}		
		public override void Set(MonedaCotizacionResult source,MonedaCotizacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdMonedaCotizacion= source.IdMonedaCotizacion ;
		 target.IdMoneda= source.IdMoneda ;
		 target.Fecha= source.Fecha ;
		 target.Cotizacion= source.Cotizacion ;
		 target.Moneda_Sigla= source.Moneda_Sigla;	
			target.Moneda_Nombre= source.Moneda_Nombre;	
			target.Moneda_Activo= source.Moneda_Activo;	
			target.Moneda_Base= source.Moneda_Base;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(MonedaCotizacion source,MonedaCotizacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMonedaCotizacion.Equals(target.IdMonedaCotizacion))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.Cotizacion.Equals(target.Cotizacion))return false;
		 
		  return true;
        }
		public override bool Equals(MonedaCotizacionResult source,MonedaCotizacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdMonedaCotizacion.Equals(target.IdMonedaCotizacion))return false;
		  if(!source.IdMoneda.Equals(target.IdMoneda))return false;
		  if(!source.Fecha.Equals(target.Fecha))return false;
		  if(!source.Cotizacion.Equals(target.Cotizacion))return false;
		  if((source.Moneda_Sigla == null)?target.Moneda_Sigla!=null: !( (target.Moneda_Sigla== String.Empty && source.Moneda_Sigla== null) || (target.Moneda_Sigla==null && source.Moneda_Sigla== String.Empty )) &&   !source.Moneda_Sigla.Trim().Replace ("\r","").Equals(target.Moneda_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.Moneda_Nombre == null)?target.Moneda_Nombre!=null: !( (target.Moneda_Nombre== String.Empty && source.Moneda_Nombre== null) || (target.Moneda_Nombre==null && source.Moneda_Nombre== String.Empty )) &&   !source.Moneda_Nombre.Trim().Replace ("\r","").Equals(target.Moneda_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Moneda_Activo.Equals(target.Moneda_Activo))return false;
					  if(!source.Moneda_Base.Equals(target.Moneda_Base))return false;
					 		
		  return true;
        }
		#endregion
    }
}
