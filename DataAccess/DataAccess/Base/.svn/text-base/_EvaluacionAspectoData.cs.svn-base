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
    public abstract class _EvaluacionAspectoData : EntityData<EvaluacionAspecto,EvaluacionAspectoFilter,EvaluacionAspectoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EvaluacionAspecto entity)
		{			
			return entity.IdEvaluacionAspecto;
		}		
		public override EvaluacionAspecto GetByEntity(EvaluacionAspecto entity)
        {
            return this.GetById(entity.IdEvaluacionAspecto);
        }
        public override EvaluacionAspecto GetById(int id)
        {
            return (from o in this.Table where o.IdEvaluacionAspecto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EvaluacionAspecto> Query(EvaluacionAspectoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEvaluacionAspecto == null || filter.IdEvaluacionAspecto == 0 || o.IdEvaluacionAspecto==filter.IdEvaluacionAspecto)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Evaluacion == null || filter.Evaluacion.Trim() == string.Empty || filter.Evaluacion.Trim() == "%"  || (filter.Evaluacion.EndsWith("%") && filter.Evaluacion.StartsWith("%") && (o.Evaluacion.Contains(filter.Evaluacion.Replace("%", "")))) || (filter.Evaluacion.EndsWith("%") && o.Evaluacion.StartsWith(filter.Evaluacion.Replace("%",""))) || (filter.Evaluacion.StartsWith("%") && o.Evaluacion.EndsWith(filter.Evaluacion.Replace("%",""))) || o.Evaluacion == filter.Evaluacion )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EvaluacionAspectoResult> QueryResult(EvaluacionAspectoFilter filter)
        {
		  return (from o in Query(filter)					
					select new EvaluacionAspectoResult(){
					 IdEvaluacionAspecto=o.IdEvaluacionAspecto
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Evaluacion=o.Evaluacion
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EvaluacionAspecto Copy(nc.EvaluacionAspecto entity)
        {           
            nc.EvaluacionAspecto _new = new nc.EvaluacionAspecto();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Evaluacion= entity.Evaluacion;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(EvaluacionAspecto entity,string renameFormat)
        {
            EvaluacionAspecto  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EvaluacionAspecto entity, int id)
        {            
            entity.IdEvaluacionAspecto = id;            
        }
		public override void Set(EvaluacionAspecto source,EvaluacionAspecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Evaluacion= source.Evaluacion ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EvaluacionAspectoResult source,EvaluacionAspecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Evaluacion= source.Evaluacion ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(EvaluacionAspecto source,EvaluacionAspectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Evaluacion= source.Evaluacion ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EvaluacionAspectoResult source,EvaluacionAspectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Evaluacion= source.Evaluacion ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(EvaluacionAspecto source,EvaluacionAspecto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Evaluacion == null)?target.Evaluacion!=null:  !( (target.Evaluacion== String.Empty && source.Evaluacion== null) || (target.Evaluacion==null && source.Evaluacion== String.Empty )) &&  !source.Evaluacion.Trim().Replace ("\r","").Equals(target.Evaluacion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(EvaluacionAspectoResult source,EvaluacionAspectoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Evaluacion == null)?target.Evaluacion!=null: !( (target.Evaluacion== String.Empty && source.Evaluacion== null) || (target.Evaluacion==null && source.Evaluacion== String.Empty )) && !source.Evaluacion.Trim().Replace ("\r","").Equals(target.Evaluacion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
