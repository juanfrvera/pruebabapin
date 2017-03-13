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
    public abstract class _ModalidadContratacionData : EntityData<ModalidadContratacion,ModalidadContratacionFilter,ModalidadContratacionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ModalidadContratacion entity)
		{			
			return entity.IdModalidadContratacion;
		}		
		public override ModalidadContratacion GetByEntity(ModalidadContratacion entity)
        {
            return this.GetById(entity.IdModalidadContratacion);
        }
        public override ModalidadContratacion GetById(int id)
        {
            return (from o in this.Table where o.IdModalidadContratacion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ModalidadContratacion> Query(ModalidadContratacionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdModalidadContratacion == null || filter.IdModalidadContratacion == 0 || o.IdModalidadContratacion==filter.IdModalidadContratacion)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ModalidadContratacionResult> QueryResult(ModalidadContratacionFilter filter)
        {
		  return (from o in Query(filter)					
					select new ModalidadContratacionResult(){
					 IdModalidadContratacion=o.IdModalidadContratacion
					 ,Nombre=o.Nombre
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ModalidadContratacion Copy(nc.ModalidadContratacion entity)
        {           
            nc.ModalidadContratacion _new = new nc.ModalidadContratacion();
		 _new.Nombre= entity.Nombre;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(ModalidadContratacion entity,string renameFormat)
        {
            ModalidadContratacion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ModalidadContratacion entity, int id)
        {            
            entity.IdModalidadContratacion = id;            
        }
		public override void Set(ModalidadContratacion source,ModalidadContratacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(ModalidadContratacionResult source,ModalidadContratacion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(ModalidadContratacion source,ModalidadContratacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(ModalidadContratacionResult source,ModalidadContratacionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.Nombre= source.Nombre ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(ModalidadContratacion source,ModalidadContratacion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdModalidadContratacion.Equals(target.IdModalidadContratacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(ModalidadContratacionResult source,ModalidadContratacionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdModalidadContratacion.Equals(target.IdModalidadContratacion))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
