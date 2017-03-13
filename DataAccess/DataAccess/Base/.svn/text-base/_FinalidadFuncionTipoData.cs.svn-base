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
    public abstract class _FinalidadFuncionTipoData : EntityData<FinalidadFuncionTipo,FinalidadFuncionTipoFilter,FinalidadFuncionTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.FinalidadFuncionTipo entity)
		{			
			return entity.IdFinalidadFuncionTipo;
		}		
		public override FinalidadFuncionTipo GetByEntity(FinalidadFuncionTipo entity)
        {
            return this.GetById(entity.IdFinalidadFuncionTipo);
        }
        public override FinalidadFuncionTipo GetById(int id)
        {
            return (from o in this.Table where o.IdFinalidadFuncionTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<FinalidadFuncionTipo> Query(FinalidadFuncionTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdFinalidadFuncionTipo == null || filter.IdFinalidadFuncionTipo == 0 || o.IdFinalidadFuncionTipo==filter.IdFinalidadFuncionTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<FinalidadFuncionTipoResult> QueryResult(FinalidadFuncionTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new FinalidadFuncionTipoResult(){
					 IdFinalidadFuncionTipo=o.IdFinalidadFuncionTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.FinalidadFuncionTipo Copy(nc.FinalidadFuncionTipo entity)
        {           
            nc.FinalidadFuncionTipo _new = new nc.FinalidadFuncionTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		public override int CopyAndSave(FinalidadFuncionTipo entity,string renameFormat)
        {
            FinalidadFuncionTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(FinalidadFuncionTipo entity, int id)
        {            
            entity.IdFinalidadFuncionTipo = id;            
        }
		public override void Set(FinalidadFuncionTipo source,FinalidadFuncionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncionTipo= source.IdFinalidadFuncionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(FinalidadFuncionTipoResult source,FinalidadFuncionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncionTipo= source.IdFinalidadFuncionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(FinalidadFuncionTipo source,FinalidadFuncionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncionTipo= source.IdFinalidadFuncionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(FinalidadFuncionTipoResult source,FinalidadFuncionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdFinalidadFuncionTipo= source.IdFinalidadFuncionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(FinalidadFuncionTipo source,FinalidadFuncionTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFinalidadFuncionTipo.Equals(target.IdFinalidadFuncionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(FinalidadFuncionTipoResult source,FinalidadFuncionTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdFinalidadFuncionTipo.Equals(target.IdFinalidadFuncionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
