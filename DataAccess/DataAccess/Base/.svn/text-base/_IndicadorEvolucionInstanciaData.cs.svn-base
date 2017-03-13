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
    public abstract class _IndicadorEvolucionInstanciaData : EntityData<IndicadorEvolucionInstancia,IndicadorEvolucionInstanciaFilter,IndicadorEvolucionInstanciaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.IndicadorEvolucionInstancia entity)
		{			
			return entity.IdIndicadorEvolucionInstancia;
		}		
		public override IndicadorEvolucionInstancia GetByEntity(IndicadorEvolucionInstancia entity)
        {
            return this.GetById(entity.IdIndicadorEvolucionInstancia);
        }
        public override IndicadorEvolucionInstancia GetById(int id)
        {
            return (from o in this.Table where o.IdIndicadorEvolucionInstancia == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<IndicadorEvolucionInstancia> Query(IndicadorEvolucionInstanciaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdIndicadorEvolucionInstancia == null || filter.IdIndicadorEvolucionInstancia == 0 || o.IdIndicadorEvolucionInstancia==filter.IdIndicadorEvolucionInstancia)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.OrdenIsNull == null || filter.OrdenIsNull == true || o.Orden != null ) && (filter.OrdenIsNull == null || filter.OrdenIsNull == false || o.Orden == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<IndicadorEvolucionInstanciaResult> QueryResult(IndicadorEvolucionInstanciaFilter filter)
        {
		  return (from o in Query(filter)					
					select new IndicadorEvolucionInstanciaResult(){
					 IdIndicadorEvolucionInstancia=o.IdIndicadorEvolucionInstancia
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.IndicadorEvolucionInstancia Copy(nc.IndicadorEvolucionInstancia entity)
        {           
            nc.IndicadorEvolucionInstancia _new = new nc.IndicadorEvolucionInstancia();
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		return _new;			
        }
		public override int CopyAndSave(IndicadorEvolucionInstancia entity,string renameFormat)
        {
            IndicadorEvolucionInstancia  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(IndicadorEvolucionInstancia entity, int id)
        {            
            entity.IdIndicadorEvolucionInstancia = id;            
        }
		public override void Set(IndicadorEvolucionInstancia source,IndicadorEvolucionInstancia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 		  
		}
		public override void Set(IndicadorEvolucionInstanciaResult source,IndicadorEvolucionInstancia target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 
		}
		public override void Set(IndicadorEvolucionInstancia source,IndicadorEvolucionInstanciaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 	
		}		
		public override void Set(IndicadorEvolucionInstanciaResult source,IndicadorEvolucionInstanciaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdIndicadorEvolucionInstancia= source.IdIndicadorEvolucionInstancia ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(IndicadorEvolucionInstancia source,IndicadorEvolucionInstancia target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorEvolucionInstancia.Equals(target.IdIndicadorEvolucionInstancia))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
			
		  return true;
        }
		public override bool Equals(IndicadorEvolucionInstanciaResult source,IndicadorEvolucionInstanciaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdIndicadorEvolucionInstancia.Equals(target.IdIndicadorEvolucionInstancia))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Orden == null)?(target.Orden.HasValue):!source.Orden.Equals(target.Orden))return false;
					
		  return true;
        }
		#endregion
    }
}
