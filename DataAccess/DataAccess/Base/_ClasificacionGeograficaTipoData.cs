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
    public abstract class _ClasificacionGeograficaTipoData : EntityData<ClasificacionGeograficaTipo,ClasificacionGeograficaTipoFilter,ClasificacionGeograficaTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ClasificacionGeograficaTipo entity)
		{			
			return entity.IdClasificacionGeograficaTipo;
		}		
		public override ClasificacionGeograficaTipo GetByEntity(ClasificacionGeograficaTipo entity)
        {
            return this.GetById(entity.IdClasificacionGeograficaTipo);
        }
        public override ClasificacionGeograficaTipo GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacionGeograficaTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ClasificacionGeograficaTipo> Query(ClasificacionGeograficaTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacionGeograficaTipo == null || filter.IdClasificacionGeograficaTipo == 0 || o.IdClasificacionGeograficaTipo==filter.IdClasificacionGeograficaTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionGeograficaTipoResult> QueryResult(ClasificacionGeograficaTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ClasificacionGeograficaTipoResult(){
					 IdClasificacionGeograficaTipo=o.IdClasificacionGeograficaTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ClasificacionGeograficaTipo Copy(nc.ClasificacionGeograficaTipo entity)
        {           
            nc.ClasificacionGeograficaTipo _new = new nc.ClasificacionGeograficaTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		public override int CopyAndSave(ClasificacionGeograficaTipo entity,string renameFormat)
        {
            ClasificacionGeograficaTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ClasificacionGeograficaTipo entity, int id)
        {            
            entity.IdClasificacionGeograficaTipo = id;            
        }
		public override void Set(ClasificacionGeograficaTipo source,ClasificacionGeograficaTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(ClasificacionGeograficaTipoResult source,ClasificacionGeograficaTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(ClasificacionGeograficaTipo source,ClasificacionGeograficaTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(ClasificacionGeograficaTipoResult source,ClasificacionGeograficaTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGeograficaTipo= source.IdClasificacionGeograficaTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ClasificacionGeograficaTipo source,ClasificacionGeograficaTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGeograficaTipo.Equals(target.IdClasificacionGeograficaTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(ClasificacionGeograficaTipoResult source,ClasificacionGeograficaTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGeograficaTipo.Equals(target.IdClasificacionGeograficaTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
