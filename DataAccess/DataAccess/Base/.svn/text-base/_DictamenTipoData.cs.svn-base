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
    public abstract class _DictamenTipoData : EntityData<DictamenTipo,DictamenTipoFilter,DictamenTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.DictamenTipo entity)
		{			
			return entity.IdDictamenTipo;
		}		
		public override DictamenTipo GetByEntity(DictamenTipo entity)
        {
            return this.GetById(entity.IdDictamenTipo);
        }
        public override DictamenTipo GetById(int id)
        {
            return (from o in this.Table where o.IdDictamenTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<DictamenTipo> Query(DictamenTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<DictamenTipoResult> QueryResult(DictamenTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new DictamenTipoResult(){
					 IdDictamenTipo=o.IdDictamenTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.DictamenTipo Copy(nc.DictamenTipo entity)
        {           
            nc.DictamenTipo _new = new nc.DictamenTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(DictamenTipo entity, int id)
        {            
            entity.IdDictamenTipo = id;            
        }
		public override void Set(DictamenTipo source,DictamenTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(DictamenTipoResult source,DictamenTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(DictamenTipo source,DictamenTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(DictamenTipoResult source,DictamenTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdDictamenTipo= source.IdDictamenTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(DictamenTipo source,DictamenTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdDictamenTipo.Equals(target.IdDictamenTipo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(DictamenTipoResult source,DictamenTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdDictamenTipo.Equals(target.IdDictamenTipo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
