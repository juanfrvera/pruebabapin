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
    public abstract class _EvaluacionTipoEvaluacionAspectoData : EntityData<EvaluacionTipoEvaluacionAspecto,EvaluacionTipoEvaluacionAspectoFilter,EvaluacionTipoEvaluacionAspectoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EvaluacionTipoEvaluacionAspecto entity)
		{			
			return entity.IdEvalaucionTipoEvaluacionAspecto;
		}		
		public override EvaluacionTipoEvaluacionAspecto GetByEntity(EvaluacionTipoEvaluacionAspecto entity)
        {
            return this.GetById(entity.IdEvalaucionTipoEvaluacionAspecto);
        }
        public override EvaluacionTipoEvaluacionAspecto GetById(int id)
        {
            return (from o in this.Table where o.IdEvalaucionTipoEvaluacionAspecto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EvaluacionTipoEvaluacionAspecto> Query(EvaluacionTipoEvaluacionAspectoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEvalaucionTipoEvaluacionAspecto == null || o.IdEvalaucionTipoEvaluacionAspecto >=  filter.IdEvalaucionTipoEvaluacionAspecto) && (filter.IdEvalaucionTipoEvaluacionAspecto_To == null || o.IdEvalaucionTipoEvaluacionAspecto <= filter.IdEvalaucionTipoEvaluacionAspecto_To)
					  && (filter.IdEvaluacionTipo == null || filter.IdEvaluacionTipo == 0 || o.IdEvaluacionTipo==filter.IdEvaluacionTipo)
					  && (filter.IdEvaluacionAspecto == null || filter.IdEvaluacionAspecto == 0 || o.IdEvaluacionAspecto==filter.IdEvaluacionAspecto)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EvaluacionTipoEvaluacionAspectoResult> QueryResult(EvaluacionTipoEvaluacionAspectoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.EvaluacionAspectos on o.IdEvaluacionAspecto equals t1.IdEvaluacionAspecto   
				    join t2  in this.Context.EvaluacionTipos on o.IdEvaluacionTipo equals t2.IdEvaluacionTipo   
				   select new EvaluacionTipoEvaluacionAspectoResult(){
					 IdEvalaucionTipoEvaluacionAspecto=o.IdEvalaucionTipoEvaluacionAspecto
					 ,IdEvaluacionTipo=o.IdEvaluacionTipo
					 ,IdEvaluacionAspecto=o.IdEvaluacionAspecto
					,EvaluacionAspecto_Codigo= t1.Codigo	
						,EvaluacionAspecto_Nombre= t1.Nombre	
						,EvaluacionAspecto_Evaluacion= t1.Evaluacion	
						,EvaluacionAspecto_Activo= t1.Activo	
						,EvaluacionTipo_Codigo= t2.Codigo	
						,EvaluacionTipo_Nombre= t2.Nombre	
						,EvaluacionTipo_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EvaluacionTipoEvaluacionAspecto Copy(nc.EvaluacionTipoEvaluacionAspecto entity)
        {           
            nc.EvaluacionTipoEvaluacionAspecto _new = new nc.EvaluacionTipoEvaluacionAspecto();
		 _new.IdEvaluacionTipo= entity.IdEvaluacionTipo;
		 _new.IdEvaluacionAspecto= entity.IdEvaluacionAspecto;
		return _new;			
        }
		public override int CopyAndSave(EvaluacionTipoEvaluacionAspecto entity,string renameFormat)
        {
            EvaluacionTipoEvaluacionAspecto  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EvaluacionTipoEvaluacionAspecto entity, int id)
        {            
            entity.IdEvalaucionTipoEvaluacionAspecto = id;            
        }
		public override void Set(EvaluacionTipoEvaluacionAspecto source,EvaluacionTipoEvaluacionAspecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionTipoEvaluacionAspecto= source.IdEvalaucionTipoEvaluacionAspecto ;
		 target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 		  
		}
		public override void Set(EvaluacionTipoEvaluacionAspectoResult source,EvaluacionTipoEvaluacionAspecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionTipoEvaluacionAspecto= source.IdEvalaucionTipoEvaluacionAspecto ;
		 target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 
		}
		public override void Set(EvaluacionTipoEvaluacionAspecto source,EvaluacionTipoEvaluacionAspectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionTipoEvaluacionAspecto= source.IdEvalaucionTipoEvaluacionAspecto ;
		 target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 	
		}		
		public override void Set(EvaluacionTipoEvaluacionAspectoResult source,EvaluacionTipoEvaluacionAspectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionTipoEvaluacionAspecto= source.IdEvalaucionTipoEvaluacionAspecto ;
		 target.IdEvaluacionTipo= source.IdEvaluacionTipo ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.EvaluacionAspecto_Codigo= source.EvaluacionAspecto_Codigo;	
			target.EvaluacionAspecto_Nombre= source.EvaluacionAspecto_Nombre;	
			target.EvaluacionAspecto_Evaluacion= source.EvaluacionAspecto_Evaluacion;	
			target.EvaluacionAspecto_Activo= source.EvaluacionAspecto_Activo;	
			target.EvaluacionTipo_Codigo= source.EvaluacionTipo_Codigo;	
			target.EvaluacionTipo_Nombre= source.EvaluacionTipo_Nombre;	
			target.EvaluacionTipo_Activo= source.EvaluacionTipo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(EvaluacionTipoEvaluacionAspecto source,EvaluacionTipoEvaluacionAspecto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvalaucionTipoEvaluacionAspecto.Equals(target.IdEvalaucionTipoEvaluacionAspecto))return false;
		  if(!source.IdEvaluacionTipo.Equals(target.IdEvaluacionTipo))return false;
		  if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		 
		  return true;
        }
		public override bool Equals(EvaluacionTipoEvaluacionAspectoResult source,EvaluacionTipoEvaluacionAspectoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvalaucionTipoEvaluacionAspecto.Equals(target.IdEvalaucionTipoEvaluacionAspecto))return false;
		  if(!source.IdEvaluacionTipo.Equals(target.IdEvaluacionTipo))return false;
		  if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		  if((source.EvaluacionAspecto_Codigo == null)?target.EvaluacionAspecto_Codigo!=null: !( (target.EvaluacionAspecto_Codigo== String.Empty && source.EvaluacionAspecto_Codigo== null) || (target.EvaluacionAspecto_Codigo==null && source.EvaluacionAspecto_Codigo== String.Empty )) &&   !source.EvaluacionAspecto_Codigo.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionAspecto_Nombre == null)?target.EvaluacionAspecto_Nombre!=null: !( (target.EvaluacionAspecto_Nombre== String.Empty && source.EvaluacionAspecto_Nombre== null) || (target.EvaluacionAspecto_Nombre==null && source.EvaluacionAspecto_Nombre== String.Empty )) &&   !source.EvaluacionAspecto_Nombre.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionAspecto_Evaluacion == null)?target.EvaluacionAspecto_Evaluacion!=null: !( (target.EvaluacionAspecto_Evaluacion== String.Empty && source.EvaluacionAspecto_Evaluacion== null) || (target.EvaluacionAspecto_Evaluacion==null && source.EvaluacionAspecto_Evaluacion== String.Empty )) &&   !source.EvaluacionAspecto_Evaluacion.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Evaluacion.Trim().Replace ("\r","")))return false;
						 if(!source.EvaluacionAspecto_Activo.Equals(target.EvaluacionAspecto_Activo))return false;
					  if((source.EvaluacionTipo_Codigo == null)?target.EvaluacionTipo_Codigo!=null: !( (target.EvaluacionTipo_Codigo== String.Empty && source.EvaluacionTipo_Codigo== null) || (target.EvaluacionTipo_Codigo==null && source.EvaluacionTipo_Codigo== String.Empty )) &&   !source.EvaluacionTipo_Codigo.Trim().Replace ("\r","").Equals(target.EvaluacionTipo_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionTipo_Nombre == null)?target.EvaluacionTipo_Nombre!=null: !( (target.EvaluacionTipo_Nombre== String.Empty && source.EvaluacionTipo_Nombre== null) || (target.EvaluacionTipo_Nombre==null && source.EvaluacionTipo_Nombre== String.Empty )) &&   !source.EvaluacionTipo_Nombre.Trim().Replace ("\r","").Equals(target.EvaluacionTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionTipo_Activo == null)?(target.EvaluacionTipo_Activo.HasValue ):!source.EvaluacionTipo_Activo.Equals(target.EvaluacionTipo_Activo))return false;
								
		  return true;
        }
		#endregion
    }
}
