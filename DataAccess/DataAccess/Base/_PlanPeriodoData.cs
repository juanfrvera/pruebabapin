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
    public abstract class _PlanPeriodoData : EntityData<PlanPeriodo,PlanPeriodoFilter,PlanPeriodoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PlanPeriodo entity)
		{			
			return entity.IdPlanPeriodo;
		}		
		public override PlanPeriodo GetByEntity(PlanPeriodo entity)
        {
            return this.GetById(entity.IdPlanPeriodo);
        }
        public override PlanPeriodo GetById(int id)
        {
            return (from o in this.Table where o.IdPlanPeriodo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PlanPeriodo> Query(PlanPeriodoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPlanPeriodo == null || filter.IdPlanPeriodo == 0 || o.IdPlanPeriodo==filter.IdPlanPeriodo)
					  && (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || o.IdPlanTipo==filter.IdPlanTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.AnioInicial == null || o.AnioInicial >=  filter.AnioInicial) && (filter.AnioInicial_To == null || o.AnioInicial <= filter.AnioInicial_To)
					  && (filter.AnioFinal == null || o.AnioFinal >=  filter.AnioFinal) && (filter.AnioFinal_To == null || o.AnioFinal <= filter.AnioFinal_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PlanPeriodoResult> QueryResult(PlanPeriodoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.PlanTipos on o.IdPlanTipo equals t1.IdPlanTipo   
				   select new PlanPeriodoResult(){
					 IdPlanPeriodo=o.IdPlanPeriodo
					 ,IdPlanTipo=o.IdPlanTipo
					 ,Nombre=o.Nombre
					 ,Sigla=o.Sigla
					 ,AnioInicial=o.AnioInicial
					 ,AnioFinal=o.AnioFinal
					 ,Activo=o.Activo
					,PlanTipo_Sigla= t1.Sigla	
						,PlanTipo_Nombre= t1.Nombre	
						,PlanTipo_Orden= t1.Orden	
						,PlanTipo_Activo= t1.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PlanPeriodo Copy(nc.PlanPeriodo entity)
        {           
            nc.PlanPeriodo _new = new nc.PlanPeriodo();
		 _new.IdPlanTipo= entity.IdPlanTipo;
		 _new.Nombre= entity.Nombre;
		 _new.Sigla= entity.Sigla;
		 _new.AnioInicial= entity.AnioInicial;
		 _new.AnioFinal= entity.AnioFinal;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(PlanPeriodo entity,string renameFormat)
        {
            PlanPeriodo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PlanPeriodo entity, int id)
        {            
            entity.IdPlanPeriodo = id;            
        }
		public override void Set(PlanPeriodo source,PlanPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Sigla= source.Sigla ;
		 target.AnioInicial= source.AnioInicial ;
		 target.AnioFinal= source.AnioFinal ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PlanPeriodoResult source,PlanPeriodo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Sigla= source.Sigla ;
		 target.AnioInicial= source.AnioInicial ;
		 target.AnioFinal= source.AnioFinal ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(PlanPeriodo source,PlanPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Sigla= source.Sigla ;
		 target.AnioInicial= source.AnioInicial ;
		 target.AnioFinal= source.AnioFinal ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PlanPeriodoResult source,PlanPeriodoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanPeriodo= source.IdPlanPeriodo ;
		 target.IdPlanTipo= source.IdPlanTipo ;
		 target.Nombre= source.Nombre ;
		 target.Sigla= source.Sigla ;
		 target.AnioInicial= source.AnioInicial ;
		 target.AnioFinal= source.AnioFinal ;
		 target.Activo= source.Activo ;
		 target.PlanTipo_Sigla= source.PlanTipo_Sigla;	
			target.PlanTipo_Nombre= source.PlanTipo_Nombre;	
			target.PlanTipo_Orden= source.PlanTipo_Orden;	
			target.PlanTipo_Activo= source.PlanTipo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PlanPeriodo source,PlanPeriodo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if(!source.AnioInicial.Equals(target.AnioInicial))return false;
		  if(!source.AnioFinal.Equals(target.AnioFinal))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PlanPeriodoResult source,PlanPeriodoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanPeriodo.Equals(target.IdPlanPeriodo))return false;
		  if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if(!source.AnioInicial.Equals(target.AnioInicial))return false;
		  if(!source.AnioFinal.Equals(target.AnioFinal))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.PlanTipo_Sigla == null)?target.PlanTipo_Sigla!=null: !( (target.PlanTipo_Sigla== String.Empty && source.PlanTipo_Sigla== null) || (target.PlanTipo_Sigla==null && source.PlanTipo_Sigla== String.Empty )) &&   !source.PlanTipo_Sigla.Trim().Replace ("\r","").Equals(target.PlanTipo_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.PlanTipo_Nombre == null)?target.PlanTipo_Nombre!=null: !( (target.PlanTipo_Nombre== String.Empty && source.PlanTipo_Nombre== null) || (target.PlanTipo_Nombre==null && source.PlanTipo_Nombre== String.Empty )) &&   !source.PlanTipo_Nombre.Trim().Replace ("\r","").Equals(target.PlanTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.PlanTipo_Orden.Equals(target.PlanTipo_Orden))return false;
					  if(!source.PlanTipo_Activo.Equals(target.PlanTipo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
