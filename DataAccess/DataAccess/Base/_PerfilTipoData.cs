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
    public abstract class _PerfilTipoData : EntityData<PerfilTipo,PerfilTipoFilter,PerfilTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PerfilTipo entity)
		{			
			return entity.IdPerfilTipo;
		}		
		public override PerfilTipo GetByEntity(PerfilTipo entity)
        {
            return this.GetById(entity.IdPerfilTipo);
        }
        public override PerfilTipo GetById(int id)
        {
            return (from o in this.Table where o.IdPerfilTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PerfilTipo> Query(PerfilTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPerfilTipo == null || filter.IdPerfilTipo == 0 || o.IdPerfilTipo==filter.IdPerfilTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PerfilTipoResult> QueryResult(PerfilTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new PerfilTipoResult(){
					 IdPerfilTipo=o.IdPerfilTipo
					 ,Nombre=o.Nombre
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PerfilTipo Copy(nc.PerfilTipo entity)
        {           
            nc.PerfilTipo _new = new nc.PerfilTipo();
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(PerfilTipo entity,string renameFormat)
        {
            PerfilTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PerfilTipo entity, int id)
        {            
            entity.IdPerfilTipo = id;            
        }
		public override void Set(PerfilTipo source,PerfilTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(PerfilTipoResult source,PerfilTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(PerfilTipo source,PerfilTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(PerfilTipoResult source,PerfilTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilTipo= source.IdPerfilTipo ;
		 target.Nombre= source.Nombre ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(PerfilTipo source,PerfilTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfilTipo.Equals(target.IdPerfilTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(PerfilTipoResult source,PerfilTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfilTipo.Equals(target.IdPerfilTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
					
		  return true;
        }
		#endregion
    }
}
