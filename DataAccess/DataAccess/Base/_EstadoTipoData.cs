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
    public abstract class _EstadoTipoData : EntityData<EstadoTipo,EstadoTipoFilter,EstadoTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.EstadoTipo entity)
		{			
			return entity.IdEstadoTipo;
		}		
		public override EstadoTipo GetByEntity(EstadoTipo entity)
        {
            return this.GetById(entity.IdEstadoTipo);
        }
        public override EstadoTipo GetById(int id)
        {
            return (from o in this.Table where o.IdEstadoTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<EstadoTipo> Query(EstadoTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEstadoTipo == null || filter.IdEstadoTipo == 0 || o.IdEstadoTipo==filter.IdEstadoTipo)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EstadoTipoResult> QueryResult(EstadoTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new EstadoTipoResult(){
					 IdEstadoTipo=o.IdEstadoTipo
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.EstadoTipo Copy(nc.EstadoTipo entity)
        {           
            nc.EstadoTipo _new = new nc.EstadoTipo();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(EstadoTipo entity, int id)
        {            
            entity.IdEstadoTipo = id;            
        }
		public override void Set(EstadoTipo source,EstadoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoTipo= source.IdEstadoTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EstadoTipoResult source,EstadoTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoTipo= source.IdEstadoTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(EstadoTipo source,EstadoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoTipo= source.IdEstadoTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EstadoTipoResult source,EstadoTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstadoTipo= source.IdEstadoTipo ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(EstadoTipo source,EstadoTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstadoTipo.Equals(target.IdEstadoTipo))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(EstadoTipoResult source,EstadoTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstadoTipo.Equals(target.IdEstadoTipo))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if(!source.Nombre.Equals(target.Nombre))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
