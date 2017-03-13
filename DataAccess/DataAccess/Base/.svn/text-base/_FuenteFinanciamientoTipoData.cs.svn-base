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
    public abstract class _FuenteFinanciamientoTipoData : EntityData<FuenteFinanciamientoTipo,FuenteFinanciamientoTipoFilter,FuenteFinanciamientoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.FuenteFinanciamientoTipo entity)
		{			
			return entity.IdFuenteFinanciamientoTipo;
		}		
		public override FuenteFinanciamientoTipo GetByEntity(FuenteFinanciamientoTipo entity)
        {
            return this.GetById(entity.IdFuenteFinanciamientoTipo);
        }
        public override FuenteFinanciamientoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdFuenteFinanciamientoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<FuenteFinanciamientoTipo> Query(FuenteFinanciamientoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFuenteFinanciamientoTipo == null || filter.IdFuenteFinanciamientoTipo == 0 || o.IdFuenteFinanciamientoTipo==filter.IdFuenteFinanciamientoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<FuenteFinanciamientoTipoResult> QueryResult(FuenteFinanciamientoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new FuenteFinanciamientoTipoResult(){
					 IdFuenteFinanciamientoTipo=o.IdFuenteFinanciamientoTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.FuenteFinanciamientoTipo Copy(nc.FuenteFinanciamientoTipo entity)
        {           
            nc.FuenteFinanciamientoTipo _new = new nc.FuenteFinanciamientoTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		public override int CopyAndSave(FuenteFinanciamientoTipo entity,string renameFormat)
        {
            FuenteFinanciamientoTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(FuenteFinanciamientoTipo entity, int id)
        {            
            entity.IdFuenteFinanciamientoTipo = id;            
        }
		public override void Set(FuenteFinanciamientoTipo source,FuenteFinanciamientoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(FuenteFinanciamientoTipoResult source,FuenteFinanciamientoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(FuenteFinanciamientoTipo source,FuenteFinanciamientoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(FuenteFinanciamientoTipoResult source,FuenteFinanciamientoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFuenteFinanciamientoTipo= source.IdFuenteFinanciamientoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(FuenteFinanciamientoTipo source,FuenteFinanciamientoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFuenteFinanciamientoTipo.Equals(target.IdFuenteFinanciamientoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(FuenteFinanciamientoTipoResult source,FuenteFinanciamientoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFuenteFinanciamientoTipo.Equals(target.IdFuenteFinanciamientoTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
