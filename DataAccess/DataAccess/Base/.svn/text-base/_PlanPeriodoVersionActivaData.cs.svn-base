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
    public abstract class _PlanPeriodoVersionActivaData : EntityData<PlanPeriodoVersionActiva,PlanPeriodoVersionActivaFilter,PlanPeriodoVersionActivaResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PlanPeriodoVersionActiva entity)
		{			
			return entity.IdPlanPeriodoVersionActiva;
		}		
		public override PlanPeriodoVersionActiva GetByEntity(PlanPeriodoVersionActiva entity)
        {
            return this.GetById(entity.IdPlanPeriodoVersionActiva);
        }
        public override PlanPeriodoVersionActiva GetById(int id)
        {
            return (from o in this.Table where o.IdPlanPeriodoVersionActiva == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PlanPeriodoVersionActiva> Query(PlanPeriodoVersionActivaFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPlanPeriodoVersionActiva == null || o.IdPlanPeriodoVersionActiva >=  filter.IdPlanPeriodoVersionActiva) && (filter.IdPlanPeriodoVersionActiva_To == null || o.IdPlanPeriodoVersionActiva <= filter.IdPlanPeriodoVersionActiva_To)
					  && (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo==filter.IdPlanPeriodo)
					  && (filter.IdPlanVersion == null || filter.IdPlanVersion == 0 || o.IdPlanVersion==filter.IdPlanVersion)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PlanPeriodoVersionActivaResult> QueryResult(PlanPeriodoVersionActivaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PlanPeriodos on o.IdPlanPeriodo equals t1.IdPlanPeriodo   
				    join t2  in this.Context.PlanVersions on o.IdPlanVersion equals t2.IdPlanVersion   
				   select new PlanPeriodoVersionActivaResult(){
					 IdPlanPeriodoVersionActiva=o.IdPlanPeriodoVersionActiva
					 ,IdPlanPeriodo=o.IdPlanPeriodo
					 ,IdPlanVersion=o.IdPlanVersion
					,PlanPeriodo_IdPlanTipo= t1.IdPlanTipo	
						,PlanPeriodo_Nombre= t1.Nombre	
						,PlanPeriodo_Sigla= t1.Sigla	
						,PlanPeriodo_AnioInicial= t1.AnioInicial	
						,PlanPeriodo_AnioFinal= t1.AnioFinal	
						,PlanPeriodo_Activo= t1.Activo	
						,PlanVersion_IdPlanTipo= t2.IdPlanTipo	
						,PlanVersion_Nombre= t2.Nombre	
						,PlanVersion_Orden= t2.Orden	
						,PlanVersion_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PlanPeriodoVersionActiva Copy(nc.PlanPeriodoVersionActiva entity)
        {           
            nc.PlanPeriodoVersionActiva _new = new nc.PlanPeriodoVersionActiva();
		 _new.IdPlanPeriodo= entity.IdPlanPeriodo;
		 _new.IdPlanVersion= entity.IdPlanVersion;
		return _new;			
        }
		public override int CopyAndSave(PlanPeriodoVersionActiva entity,string renameFormat)
        {
            PlanPeriodoVersionActiva  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PlanPeriodoVersionActiva entity, int id)
        {            
            entity.IdPlanPeriodoVersionActiva = id;            
        }
		public override void Set(PlanPeriodoVersionActiva source,PlanPeriodoVersionActiva target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodoVersionActiva= source.IdPlanPeriodoVersionActiva ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 		  
		}
		public override void Set(PlanPeriodoVersionActivaResult source,PlanPeriodoVersionActiva target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodoVersionActiva= source.IdPlanPeriodoVersionActiva ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 
		}
		public override void Set(PlanPeriodoVersionActiva source,PlanPeriodoVersionActivaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodoVersionActiva= source.IdPlanPeriodoVersionActiva ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 	
		}		
		public override void Set(PlanPeriodoVersionActivaResult source,PlanPeriodoVersionActivaResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodoVersionActiva= source.IdPlanPeriodoVersionActiva ;
		 target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanVersion= source.IdPlanVersion ;
		 target.PlanPeriodo_IdPlanTipo= source.PlanPeriodo_IdPlanTipo;	
			target.PlanPeriodo_Nombre= source.PlanPeriodo_Nombre;	
			target.PlanPeriodo_Sigla= source.PlanPeriodo_Sigla;	
			target.PlanPeriodo_AnioInicial= source.PlanPeriodo_AnioInicial;	
			target.PlanPeriodo_AnioFinal= source.PlanPeriodo_AnioFinal;	
			target.PlanPeriodo_Activo= source.PlanPeriodo_Activo;	
			target.PlanVersion_IdPlanTipo= source.PlanVersion_IdPlanTipo;	
			target.PlanVersion_Nombre= source.PlanVersion_Nombre;	
			target.PlanVersion_Orden= source.PlanVersion_Orden;	
			target.PlanVersion_Activo= source.PlanVersion_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PlanPeriodoVersionActiva source,PlanPeriodoVersionActiva target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanPeriodoVersionActiva.Equals(target.IdPlanPeriodoVersionActiva))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		 
		  return true;
        }
		public override bool Equals(PlanPeriodoVersionActivaResult source,PlanPeriodoVersionActivaResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanPeriodoVersionActiva.Equals(target.IdPlanPeriodoVersionActiva))return false;
		  if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanVersion.Equals(target.IdPlanVersion))return false;
		  if(!source.PlanPeriodo_IdPlanTipo.Equals(target.PlanPeriodo_IdPlanTipo))return false;
					  if((source.PlanPeriodo_Nombre == null)?target.PlanPeriodo_Nombre!=null: !( (target.PlanPeriodo_Nombre== String.Empty && source.PlanPeriodo_Nombre== null) || (target.PlanPeriodo_Nombre==null && source.PlanPeriodo_Nombre== String.Empty )) &&   !source.PlanPeriodo_Nombre.Trim().Replace ("\r","").Equals(target.PlanPeriodo_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.PlanPeriodo_Sigla == null)?target.PlanPeriodo_Sigla!=null: !( (target.PlanPeriodo_Sigla== String.Empty && source.PlanPeriodo_Sigla== null) || (target.PlanPeriodo_Sigla==null && source.PlanPeriodo_Sigla== String.Empty )) &&   !source.PlanPeriodo_Sigla.Trim().Replace ("\r","").Equals(target.PlanPeriodo_Sigla.Trim().Replace ("\r","")))return false;
						 if(!source.PlanPeriodo_AnioInicial.Equals(target.PlanPeriodo_AnioInicial))return false;
					  if(!source.PlanPeriodo_AnioFinal.Equals(target.PlanPeriodo_AnioFinal))return false;
					  if(!source.PlanPeriodo_Activo.Equals(target.PlanPeriodo_Activo))return false;
					  if(!source.PlanVersion_IdPlanTipo.Equals(target.PlanVersion_IdPlanTipo))return false;
					  if((source.PlanVersion_Nombre == null)?target.PlanVersion_Nombre!=null: !( (target.PlanVersion_Nombre== String.Empty && source.PlanVersion_Nombre== null) || (target.PlanVersion_Nombre==null && source.PlanVersion_Nombre== String.Empty )) &&   !source.PlanVersion_Nombre.Trim().Replace ("\r","").Equals(target.PlanVersion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.PlanVersion_Orden.Equals(target.PlanVersion_Orden))return false;
					  if(!source.PlanVersion_Activo.Equals(target.PlanVersion_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
