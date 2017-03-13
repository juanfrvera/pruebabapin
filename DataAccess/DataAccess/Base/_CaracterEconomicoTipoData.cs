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
    public abstract class _CaracterEconomicoTipoData : EntityData<CaracterEconomicoTipo,CaracterEconomicoTipoFilter,CaracterEconomicoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.CaracterEconomicoTipo entity)
		{			
			return entity.IdCaracterEconomicoTipo;
		}		
		public override CaracterEconomicoTipo GetByEntity(CaracterEconomicoTipo entity)
        {
            return this.GetById(entity.IdCaracterEconomicoTipo);
        }
        public override CaracterEconomicoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdCaracterEconomicoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<CaracterEconomicoTipo> Query(CaracterEconomicoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdCaracterEconomicoTipo == null || filter.IdCaracterEconomicoTipo == 0 || o.IdCaracterEconomicoTipo==filter.IdCaracterEconomicoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<CaracterEconomicoTipoResult> QueryResult(CaracterEconomicoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new CaracterEconomicoTipoResult(){
					 IdCaracterEconomicoTipo=o.IdCaracterEconomicoTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.CaracterEconomicoTipo Copy(nc.CaracterEconomicoTipo entity)
        {           
            nc.CaracterEconomicoTipo _new = new nc.CaracterEconomicoTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		public override int CopyAndSave(CaracterEconomicoTipo entity,string renameFormat)
        {
            CaracterEconomicoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(CaracterEconomicoTipo entity, int id)
        {            
            entity.IdCaracterEconomicoTipo = id;            
        }
		public override void Set(CaracterEconomicoTipo source,CaracterEconomicoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(CaracterEconomicoTipoResult source,CaracterEconomicoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(CaracterEconomicoTipo source,CaracterEconomicoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(CaracterEconomicoTipoResult source,CaracterEconomicoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdCaracterEconomicoTipo= source.IdCaracterEconomicoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(CaracterEconomicoTipo source,CaracterEconomicoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCaracterEconomicoTipo.Equals(target.IdCaracterEconomicoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(CaracterEconomicoTipoResult source,CaracterEconomicoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdCaracterEconomicoTipo.Equals(target.IdCaracterEconomicoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
