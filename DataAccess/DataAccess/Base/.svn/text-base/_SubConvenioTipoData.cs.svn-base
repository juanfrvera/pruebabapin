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
    public abstract class _SubConvenioTipoData : EntityData<SubConvenioTipo,SubConvenioTipoFilter,SubConvenioTipoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SubConvenioTipo entity)
		{			
			return entity.IdSubconvenioTipo;
		}		
		public override SubConvenioTipo GetByEntity(SubConvenioTipo entity)
        {
            return this.GetById(entity.IdSubconvenioTipo);
        }
        public override SubConvenioTipo GetById(int id)
        {
            return (from o in this.Table where o.IdSubconvenioTipo == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SubConvenioTipo> Query(SubConvenioTipoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSubconvenioTipo == null || filter.IdSubconvenioTipo == 0 || o.IdSubconvenioTipo==filter.IdSubconvenioTipo)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SubConvenioTipoResult> QueryResult(SubConvenioTipoFilter filter)
        {
		  return (from o in Query(filter)					
					select new SubConvenioTipoResult(){
					 IdSubconvenioTipo=o.IdSubconvenioTipo
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SubConvenioTipo Copy(nc.SubConvenioTipo entity)
        {           
            nc.SubConvenioTipo _new = new nc.SubConvenioTipo();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(SubConvenioTipo entity,string renameFormat)
        {
            SubConvenioTipo  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SubConvenioTipo entity, int id)
        {            
            entity.IdSubconvenioTipo = id;            
        }
		public override void Set(SubConvenioTipo source,SubConvenioTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubconvenioTipo= source.IdSubconvenioTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(SubConvenioTipoResult source,SubConvenioTipo target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubconvenioTipo= source.IdSubconvenioTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(SubConvenioTipo source,SubConvenioTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubconvenioTipo= source.IdSubconvenioTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(SubConvenioTipoResult source,SubConvenioTipoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSubconvenioTipo= source.IdSubconvenioTipo ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(SubConvenioTipo source,SubConvenioTipo target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubconvenioTipo.Equals(target.IdSubconvenioTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(SubConvenioTipoResult source,SubConvenioTipoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSubconvenioTipo.Equals(target.IdSubconvenioTipo))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
