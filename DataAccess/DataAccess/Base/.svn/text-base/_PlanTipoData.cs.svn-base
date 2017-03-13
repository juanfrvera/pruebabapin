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
    public abstract class _PlanTipoData : EntityData<PlanTipo,PlanTipoFilter,PlanTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PlanTipo entity)
		{			
			return entity.IdPlanTipo;
		}		
		public override PlanTipo GetByEntity(PlanTipo entity)
        {
            return this.GetById(entity.IdPlanTipo);
        }
        public override PlanTipo GetById(int id)
        {
            return (from o in this.Table where o.IdPlanTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PlanTipo> Query(PlanTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPlanTipo == null || filter.IdPlanTipo == 0 || o.IdPlanTipo==filter.IdPlanTipo)
					  && (filter.Sigla == null || filter.Sigla.Trim() == string.Empty || filter.Sigla.Trim() == "%"  || (filter.Sigla.EndsWith("%") && filter.Sigla.StartsWith("%") && (o.Sigla.Contains(filter.Sigla.Replace("%", "")))) || (filter.Sigla.EndsWith("%") && o.Sigla.StartsWith(filter.Sigla.Replace("%",""))) || (filter.Sigla.StartsWith("%") && o.Sigla.EndsWith(filter.Sigla.Replace("%",""))) || o.Sigla == filter.Sigla )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }       

        protected override IQueryable<PlanTipoResult> QueryResult(PlanTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new PlanTipoResult(){
					 IdPlanTipo=o.IdPlanTipo
					 ,Sigla=o.Sigla
					 ,Nombre=o.Nombre
					 ,Orden=o.Orden
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PlanTipo Copy(nc.PlanTipo entity)
        {           
            nc.PlanTipo _new = new nc.PlanTipo();
		 _new.Sigla= entity.Sigla;
		 _new.Nombre= entity.Nombre;
		 _new.Orden= entity.Orden;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(PlanTipo entity,string renameFormat)
        {
            PlanTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PlanTipo entity, int id)
        {            
            entity.IdPlanTipo = id;            
        }
		public override void Set(PlanTipo source,PlanTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanTipo= source.IdPlanTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PlanTipoResult source,PlanTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanTipo= source.IdPlanTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(PlanTipo source,PlanTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanTipo= source.IdPlanTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PlanTipoResult source,PlanTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPlanTipo= source.IdPlanTipo ;
		 target.Sigla= source.Sigla ;
		 target.Nombre= source.Nombre ;
		 target.Orden= source.Orden ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(PlanTipo source,PlanTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null:  !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) &&  !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(PlanTipoResult source,PlanTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPlanTipo.Equals(target.IdPlanTipo))return false;
		  if((source.Sigla == null)?target.Sigla!=null: !( (target.Sigla== String.Empty && source.Sigla== null) || (target.Sigla==null && source.Sigla== String.Empty )) && !source.Sigla.Trim().Replace ("\r","").Equals(target.Sigla.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
