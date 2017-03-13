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
    public abstract class _EvaluacionAspectoEvaluacionResultadoData : EntityData<EvaluacionAspectoEvaluacionResultado,EvaluacionAspectoEvaluacionResultadoFilter,EvaluacionAspectoEvaluacionResultadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EvaluacionAspectoEvaluacionResultado entity)
		{			
			return entity.IdEvalaucionAspectoEvaluacionResultado;
		}		
		public override EvaluacionAspectoEvaluacionResultado GetByEntity(EvaluacionAspectoEvaluacionResultado entity)
        {
            return this.GetById(entity.IdEvalaucionAspectoEvaluacionResultado);
        }
        public override EvaluacionAspectoEvaluacionResultado GetById(int id)
        {
            return (from o in this.Table where o.IdEvalaucionAspectoEvaluacionResultado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EvaluacionAspectoEvaluacionResultado> Query(EvaluacionAspectoEvaluacionResultadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEvalaucionAspectoEvaluacionResultado == null || o.IdEvalaucionAspectoEvaluacionResultado >=  filter.IdEvalaucionAspectoEvaluacionResultado) && (filter.IdEvalaucionAspectoEvaluacionResultado_To == null || o.IdEvalaucionAspectoEvaluacionResultado <= filter.IdEvalaucionAspectoEvaluacionResultado_To)
					  && (filter.IdEvaluacionAspecto == null || filter.IdEvaluacionAspecto == 0 || o.IdEvaluacionAspecto==filter.IdEvaluacionAspecto)
					  && (filter.IdEvaluacionResultado == null || filter.IdEvaluacionResultado == 0 || o.IdEvaluacionResultado==filter.IdEvaluacionResultado)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EvaluacionAspectoEvaluacionResultadoResult> QueryResult(EvaluacionAspectoEvaluacionResultadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.EvaluacionAspectos on o.IdEvaluacionAspecto equals t1.IdEvaluacionAspecto   
				    join t2  in this.Context.EvaluacionResultados on o.IdEvaluacionResultado equals t2.IdEvaluacionResultado   
				   select new EvaluacionAspectoEvaluacionResultadoResult(){
					 IdEvalaucionAspectoEvaluacionResultado=o.IdEvalaucionAspectoEvaluacionResultado
					 ,IdEvaluacionAspecto=o.IdEvaluacionAspecto
					 ,IdEvaluacionResultado=o.IdEvaluacionResultado
					,EvaluacionAspecto_Codigo= t1.Codigo	
						,EvaluacionAspecto_Nombre= t1.Nombre	
						,EvaluacionAspecto_Evaluacion= t1.Evaluacion	
						,EvaluacionAspecto_Activo= t1.Activo	
						,EvaluacionResultado_Codigo= t2.Codigo	
						,EvaluacionResultado_Nombre= t2.Nombre	
						,EvaluacionResultado_Aspecto= t2.Aspecto	
						,EvaluacionResultado_Aprobado= t2.Aprobado	
						,EvaluacionResultado_Orden= t2.Orden	
						,EvaluacionResultado_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EvaluacionAspectoEvaluacionResultado Copy(nc.EvaluacionAspectoEvaluacionResultado entity)
        {           
            nc.EvaluacionAspectoEvaluacionResultado _new = new nc.EvaluacionAspectoEvaluacionResultado();
		 _new.IdEvaluacionAspecto= entity.IdEvaluacionAspecto;
		 _new.IdEvaluacionResultado= entity.IdEvaluacionResultado;
		return _new;			
        }
		public override int CopyAndSave(EvaluacionAspectoEvaluacionResultado entity,string renameFormat)
        {
            EvaluacionAspectoEvaluacionResultado  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(EvaluacionAspectoEvaluacionResultado entity, int id)
        {            
            entity.IdEvalaucionAspectoEvaluacionResultado = id;            
        }
		public override void Set(EvaluacionAspectoEvaluacionResultado source,EvaluacionAspectoEvaluacionResultado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionAspectoEvaluacionResultado= source.IdEvalaucionAspectoEvaluacionResultado ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 		  
		}
		public override void Set(EvaluacionAspectoEvaluacionResultadoResult source,EvaluacionAspectoEvaluacionResultado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionAspectoEvaluacionResultado= source.IdEvalaucionAspectoEvaluacionResultado ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 
		}
		public override void Set(EvaluacionAspectoEvaluacionResultado source,EvaluacionAspectoEvaluacionResultadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionAspectoEvaluacionResultado= source.IdEvalaucionAspectoEvaluacionResultado ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 	
		}		
		public override void Set(EvaluacionAspectoEvaluacionResultadoResult source,EvaluacionAspectoEvaluacionResultadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEvalaucionAspectoEvaluacionResultado= source.IdEvalaucionAspectoEvaluacionResultado ;
		 target.IdEvaluacionAspecto= source.IdEvaluacionAspecto ;
		 target.IdEvaluacionResultado= source.IdEvaluacionResultado ;
		 target.EvaluacionAspecto_Codigo= source.EvaluacionAspecto_Codigo;	
			target.EvaluacionAspecto_Nombre= source.EvaluacionAspecto_Nombre;	
			target.EvaluacionAspecto_Evaluacion= source.EvaluacionAspecto_Evaluacion;	
			target.EvaluacionAspecto_Activo= source.EvaluacionAspecto_Activo;	
			target.EvaluacionResultado_Codigo= source.EvaluacionResultado_Codigo;	
			target.EvaluacionResultado_Nombre= source.EvaluacionResultado_Nombre;	
			target.EvaluacionResultado_Aspecto= source.EvaluacionResultado_Aspecto;	
			target.EvaluacionResultado_Aprobado= source.EvaluacionResultado_Aprobado;	
			target.EvaluacionResultado_Orden= source.EvaluacionResultado_Orden;	
			target.EvaluacionResultado_Activo= source.EvaluacionResultado_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(EvaluacionAspectoEvaluacionResultado source,EvaluacionAspectoEvaluacionResultado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvalaucionAspectoEvaluacionResultado.Equals(target.IdEvalaucionAspectoEvaluacionResultado))return false;
		  if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		  if(!source.IdEvaluacionResultado.Equals(target.IdEvaluacionResultado))return false;
		 
		  return true;
        }
		public override bool Equals(EvaluacionAspectoEvaluacionResultadoResult source,EvaluacionAspectoEvaluacionResultadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEvalaucionAspectoEvaluacionResultado.Equals(target.IdEvalaucionAspectoEvaluacionResultado))return false;
		  if(!source.IdEvaluacionAspecto.Equals(target.IdEvaluacionAspecto))return false;
		  if(!source.IdEvaluacionResultado.Equals(target.IdEvaluacionResultado))return false;
		  if((source.EvaluacionAspecto_Codigo == null)?target.EvaluacionAspecto_Codigo!=null: !( (target.EvaluacionAspecto_Codigo== String.Empty && source.EvaluacionAspecto_Codigo== null) || (target.EvaluacionAspecto_Codigo==null && source.EvaluacionAspecto_Codigo== String.Empty )) &&   !source.EvaluacionAspecto_Codigo.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionAspecto_Nombre == null)?target.EvaluacionAspecto_Nombre!=null: !( (target.EvaluacionAspecto_Nombre== String.Empty && source.EvaluacionAspecto_Nombre== null) || (target.EvaluacionAspecto_Nombre==null && source.EvaluacionAspecto_Nombre== String.Empty )) &&   !source.EvaluacionAspecto_Nombre.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionAspecto_Evaluacion == null)?target.EvaluacionAspecto_Evaluacion!=null: !( (target.EvaluacionAspecto_Evaluacion== String.Empty && source.EvaluacionAspecto_Evaluacion== null) || (target.EvaluacionAspecto_Evaluacion==null && source.EvaluacionAspecto_Evaluacion== String.Empty )) &&   !source.EvaluacionAspecto_Evaluacion.Trim().Replace ("\r","").Equals(target.EvaluacionAspecto_Evaluacion.Trim().Replace ("\r","")))return false;
						 if(!source.EvaluacionAspecto_Activo.Equals(target.EvaluacionAspecto_Activo))return false;
					  if((source.EvaluacionResultado_Codigo == null)?target.EvaluacionResultado_Codigo!=null: !( (target.EvaluacionResultado_Codigo== String.Empty && source.EvaluacionResultado_Codigo== null) || (target.EvaluacionResultado_Codigo==null && source.EvaluacionResultado_Codigo== String.Empty )) &&   !source.EvaluacionResultado_Codigo.Trim().Replace ("\r","").Equals(target.EvaluacionResultado_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionResultado_Nombre == null)?target.EvaluacionResultado_Nombre!=null: !( (target.EvaluacionResultado_Nombre== String.Empty && source.EvaluacionResultado_Nombre== null) || (target.EvaluacionResultado_Nombre==null && source.EvaluacionResultado_Nombre== String.Empty )) &&   !source.EvaluacionResultado_Nombre.Trim().Replace ("\r","").Equals(target.EvaluacionResultado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EvaluacionResultado_Aspecto == null)?target.EvaluacionResultado_Aspecto!=null: !( (target.EvaluacionResultado_Aspecto== String.Empty && source.EvaluacionResultado_Aspecto== null) || (target.EvaluacionResultado_Aspecto==null && source.EvaluacionResultado_Aspecto== String.Empty )) &&   !source.EvaluacionResultado_Aspecto.Trim().Replace ("\r","").Equals(target.EvaluacionResultado_Aspecto.Trim().Replace ("\r","")))return false;
						 if(!source.EvaluacionResultado_Aprobado.Equals(target.EvaluacionResultado_Aprobado))return false;
					  if(!source.EvaluacionResultado_Orden.Equals(target.EvaluacionResultado_Orden))return false;
					  if(!source.EvaluacionResultado_Activo.Equals(target.EvaluacionResultado_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
