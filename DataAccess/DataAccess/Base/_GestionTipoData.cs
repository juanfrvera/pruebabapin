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
    public abstract class _GestionTipoData : EntityData<GestionTipo,GestionTipoFilter,GestionTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.GestionTipo entity)
		{			
			return entity.IdGestionTipo;
		}		
		public override GestionTipo GetByEntity(GestionTipo entity)
        {
            return this.GetById(entity.IdGestionTipo);
        }
        public override GestionTipo GetById(int id)
        {
            return (from o in this.Table where o.IdGestionTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<GestionTipo> Query(GestionTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdGestionTipo == null || filter.IdGestionTipo == 0 || o.IdGestionTipo==filter.IdGestionTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<GestionTipoResult> QueryResult(GestionTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new GestionTipoResult(){
					 IdGestionTipo=o.IdGestionTipo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.GestionTipo Copy(nc.GestionTipo entity)
        {           
            nc.GestionTipo _new = new nc.GestionTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(GestionTipo entity,string renameFormat)
        {
            GestionTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(GestionTipo entity, int id)
        {            
            entity.IdGestionTipo = id;            
        }
		public override void Set(GestionTipo source,GestionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGestionTipo= source.IdGestionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(GestionTipoResult source,GestionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGestionTipo= source.IdGestionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(GestionTipo source,GestionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGestionTipo= source.IdGestionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(GestionTipoResult source,GestionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdGestionTipo= source.IdGestionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(GestionTipo source,GestionTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGestionTipo.Equals(target.IdGestionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(GestionTipoResult source,GestionTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdGestionTipo.Equals(target.IdGestionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
