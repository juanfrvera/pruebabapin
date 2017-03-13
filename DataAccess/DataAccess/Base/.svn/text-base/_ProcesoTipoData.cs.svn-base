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
    public abstract class _ProcesoTipoData : EntityData<ProcesoTipo,ProcesoTipoFilter,ProcesoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProcesoTipo entity)
		{			
			return entity.IdProcesoTipo;
		}		
		public override ProcesoTipo GetByEntity(ProcesoTipo entity)
        {
            return this.GetById(entity.IdProcesoTipo);
        }
        public override ProcesoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdProcesoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProcesoTipo> Query(ProcesoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProcesoTipo == null || filter.IdProcesoTipo == 0 || o.IdProcesoTipo==filter.IdProcesoTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Nivel == null || o.Nivel >=  filter.Nivel) && (filter.Nivel_To == null || o.Nivel <= filter.Nivel_To)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProcesoTipoResult> QueryResult(ProcesoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ProcesoTipoResult(){
					 IdProcesoTipo=o.IdProcesoTipo
					 ,Nombre=o.Nombre
					 ,Nivel=o.Nivel
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProcesoTipo Copy(nc.ProcesoTipo entity)
        {           
            nc.ProcesoTipo _new = new nc.ProcesoTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Nivel= entity.Nivel;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(ProcesoTipo entity, int id)
        {            
            entity.IdProcesoTipo = id;            
        }
		public override void Set(ProcesoTipo source,ProcesoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProcesoTipo= source.IdProcesoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		  
		}
		public override void Set(ProcesoTipoResult source,ProcesoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProcesoTipo= source.IdProcesoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 
		}
		public override void Set(ProcesoTipo source,ProcesoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProcesoTipo= source.IdProcesoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 	
		}		
		public override void Set(ProcesoTipoResult source,ProcesoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProcesoTipo= source.IdProcesoTipo ;
		 target.Nombre= source.Nombre ;
		 target.Nivel= source.Nivel ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ProcesoTipo source,ProcesoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProcesoTipo.Equals(target.IdProcesoTipo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Nivel.Equals(target.Nivel))return false;
		 
		  return true;
        }
		public override bool Equals(ProcesoTipoResult source,ProcesoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProcesoTipo.Equals(target.IdProcesoTipo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Nivel.Equals(target.Nivel))return false;
		 		
		  return true;
        }
		#endregion
    }
}
