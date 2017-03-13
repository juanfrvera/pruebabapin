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
    public abstract class _ClasificacionGastoTipoData : EntityData<ClasificacionGastoTipo,ClasificacionGastoTipoFilter,ClasificacionGastoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ClasificacionGastoTipo entity)
		{			
			return entity.IdClasificacionGastoTipo;
		}		
		public override ClasificacionGastoTipo GetByEntity(ClasificacionGastoTipo entity)
        {
            return this.GetById(entity.IdClasificacionGastoTipo);
        }
        public override ClasificacionGastoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdClasificacionGastoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ClasificacionGastoTipo> Query(ClasificacionGastoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdClasificacionGastoTipo == null || filter.IdClasificacionGastoTipo == 0 || o.IdClasificacionGastoTipo==filter.IdClasificacionGastoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ClasificacionGastoTipoResult> QueryResult(ClasificacionGastoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ClasificacionGastoTipoResult(){
					 IdClasificacionGastoTipo=o.IdClasificacionGastoTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ClasificacionGastoTipo Copy(nc.ClasificacionGastoTipo entity)
        {           
            nc.ClasificacionGastoTipo _new = new nc.ClasificacionGastoTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		public override int CopyAndSave(ClasificacionGastoTipo entity,string renameFormat)
        {
            ClasificacionGastoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ClasificacionGastoTipo entity, int id)
        {            
            entity.IdClasificacionGastoTipo = id;            
        }
		public override void Set(ClasificacionGastoTipo source,ClasificacionGastoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(ClasificacionGastoTipoResult source,ClasificacionGastoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(ClasificacionGastoTipo source,ClasificacionGastoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(ClasificacionGastoTipoResult source,ClasificacionGastoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdClasificacionGastoTipo= source.IdClasificacionGastoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ClasificacionGastoTipo source,ClasificacionGastoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGastoTipo.Equals(target.IdClasificacionGastoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(ClasificacionGastoTipoResult source,ClasificacionGastoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdClasificacionGastoTipo.Equals(target.IdClasificacionGastoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
