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
    public abstract class _IndicadorDetalleData : EntityData<IndicadorDetalle,IndicadorDetalleFilter,IndicadorDetalleResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorDetalle entity)
		{			
			return entity.IdIndicadorDetalle;
		}		
		public override IndicadorDetalle GetByEntity(IndicadorDetalle entity)
        {
            return this.GetById(entity.IdIndicadorDetalle);
        }
        public override IndicadorDetalle GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorDetalle == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorDetalle> Query(IndicadorDetalleFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorDetalle == null || filter.IdIndicadorDetalle == 0 || o.IdIndicadorDetalle==filter.IdIndicadorDetalle)
					  && (filter.IdMedioVerificacion == null || filter.IdMedioVerificacion == 0 || o.IdMedioVerificacion==filter.IdMedioVerificacion)
					  && (filter.IdMedioVerificacionIsNull == null || filter.IdMedioVerificacionIsNull == true || o.IdMedioVerificacion != null ) && (filter.IdMedioVerificacionIsNull == null || filter.IdMedioVerificacionIsNull == false || o.IdMedioVerificacion == null)
					  && (filter.Observacion == null || filter.Observacion.Trim() == string.Empty || filter.Observacion.Trim() == "%"  || (filter.Observacion.EndsWith("%") && filter.Observacion.StartsWith("%") && (o.Observacion.Contains(filter.Observacion.Replace("%", "")))) || (filter.Observacion.EndsWith("%") && o.Observacion.StartsWith(filter.Observacion.Replace("%",""))) || (filter.Observacion.StartsWith("%") && o.Observacion.EndsWith(filter.Observacion.Replace("%",""))) || o.Observacion == filter.Observacion )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorDetalleResult> QueryResult(IndicadorDetalleFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.MedioVerificacions on o.IdMedioVerificacion equals _t1.IdMedioVerificacion into tt1 from t1 in tt1.DefaultIfEmpty()
				   select new IndicadorDetalleResult(){
					 IdIndicadorDetalle=o.IdIndicadorDetalle
					 ,IdMedioVerificacion=o.IdMedioVerificacion
					 ,Observacion=o.Observacion
					,MedioVerificacion_Sigla= t1!=null?(string)t1.Sigla:null	
						,MedioVerificacion_Nombre= t1!=null?(string)t1.Nombre:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorDetalle Copy(nc.IndicadorDetalle entity)
        {           
            nc.IndicadorDetalle _new = new nc.IndicadorDetalle();
		 _new.IdMedioVerificacion= entity.IdMedioVerificacion;
		 _new.Observacion= entity.Observacion;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(IndicadorDetalle entity, int id)
        {            
            entity.IdIndicadorDetalle = id;            
        }
		public override void Set(IndicadorDetalle source,IndicadorDetalle target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorDetalle= source.IdIndicadorDetalle ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
		 		  
		}
		public override void Set(IndicadorDetalleResult source,IndicadorDetalle target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorDetalle= source.IdIndicadorDetalle ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
		 
		}
		public override void Set(IndicadorDetalle source,IndicadorDetalleResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorDetalle= source.IdIndicadorDetalle ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
		 	
		}		
		public override void Set(IndicadorDetalleResult source,IndicadorDetalleResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorDetalle= source.IdIndicadorDetalle ;
		 target.IdMedioVerificacion= source.IdMedioVerificacion ;
		 target.Observacion= source.Observacion ;
		 target.MedioVerificacion_Sigla= source.MedioVerificacion_Sigla;	
			target.MedioVerificacion_Nombre= source.MedioVerificacion_Nombre;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorDetalle source,IndicadorDetalle target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorDetalle.Equals(target.IdIndicadorDetalle))return false;
		  if((source.IdMedioVerificacion == null)?(target.IdMedioVerificacion.HasValue && target.IdMedioVerificacion.Value > 0):!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
						  if(!source.Observacion.Equals(target.Observacion))return false;
		 
		  return true;
        }
		public override bool Equals(IndicadorDetalleResult source,IndicadorDetalleResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorDetalle.Equals(target.IdIndicadorDetalle))return false;
		  if((source.IdMedioVerificacion == null)?(target.IdMedioVerificacion.HasValue && target.IdMedioVerificacion.Value > 0):!source.IdMedioVerificacion.Equals(target.IdMedioVerificacion))return false;
						  if(!source.Observacion.Equals(target.Observacion))return false;
		  if(!source.MedioVerificacion_Sigla.Equals(target.MedioVerificacion_Sigla))return false;
					  if(!source.MedioVerificacion_Nombre.Equals(target.MedioVerificacion_Nombre))return false;
					 		
		  return true;
        }
		#endregion
    }
}
