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
    public abstract class _ProyectoRelacionTipoData : EntityData<ProyectoRelacionTipo,ProyectoRelacionTipoFilter,ProyectoRelacionTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoRelacionTipo entity)
		{			
			return entity.IdProyectoRelacionTipo;
		}		
		public override ProyectoRelacionTipo GetByEntity(ProyectoRelacionTipo entity)
        {
            return this.GetById(entity.IdProyectoRelacionTipo);
        }
        public override ProyectoRelacionTipo GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoRelacionTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoRelacionTipo> Query(ProyectoRelacionTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoRelacionTipo == null || filter.IdProyectoRelacionTipo == 0 || o.IdProyectoRelacionTipo==filter.IdProyectoRelacionTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoRelacionTipoResult> QueryResult(ProyectoRelacionTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new ProyectoRelacionTipoResult(){
					 IdProyectoRelacionTipo=o.IdProyectoRelacionTipo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoRelacionTipo Copy(nc.ProyectoRelacionTipo entity)
        {           
            nc.ProyectoRelacionTipo _new = new nc.ProyectoRelacionTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(ProyectoRelacionTipo entity,string renameFormat)
        {
            ProyectoRelacionTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoRelacionTipo entity, int id)
        {            
            entity.IdProyectoRelacionTipo = id;            
        }
		public override void Set(ProyectoRelacionTipo source,ProyectoRelacionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ProyectoRelacionTipoResult source,ProyectoRelacionTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(ProyectoRelacionTipo source,ProyectoRelacionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ProyectoRelacionTipoResult source,ProyectoRelacionTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoRelacionTipo= source.IdProyectoRelacionTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoRelacionTipo source,ProyectoRelacionTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoRelacionTipo.Equals(target.IdProyectoRelacionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoRelacionTipoResult source,ProyectoRelacionTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoRelacionTipo.Equals(target.IdProyectoRelacionTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
