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
    public abstract class _EstadoData : EntityData<Estado,EstadoFilter,EstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Estado entity)
		{			
			return entity.IdEstado;
		}		
		public override Estado GetByEntity(Estado entity)
        {
            return this.GetById(entity.IdEstado);
        }
        public override Estado GetById(int id)
        {
            return (from o in this.Table where o.IdEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Estado> Query(EstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Orden == null || o.Orden >=  filter.Orden) && (filter.Orden_To == null || o.Orden <= filter.Orden_To)
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<EstadoResult> QueryResult(EstadoFilter filter)
        {
		  return (from o in Query(filter)					
					select new EstadoResult(){
					 IdEstado=o.IdEstado
					 ,Nombre=o.Nombre
					 ,Codigo=o.Codigo
					 ,Orden=o.Orden
					 ,Descripcion=o.Descripcion
					 ,Activo=o.Activo
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Estado Copy(nc.Estado entity)
        {           
            nc.Estado _new = new nc.Estado();
		 _new.Nombre= entity.Nombre;
		 _new.Codigo= entity.Codigo;
		 _new.Orden= entity.Orden;
		 _new.Descripcion= entity.Descripcion;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Estado entity,string renameFormat)
        {
            Estado  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Estado entity, int id)
        {            
            entity.IdEstado = id;            
        }
		public override void Set(Estado source,Estado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(EstadoResult source,Estado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Estado source,EstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(EstadoResult source,EstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Orden= source.Orden ;
		 target.Descripcion= source.Descripcion ;
		 target.Activo= source.Activo ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(Estado source,Estado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 
		  return true;
        }
		public override bool Equals(EstadoResult source,EstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if(!source.Orden.Equals(target.Orden))return false;
		  if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		 		
		  return true;
        }
		#endregion
    }
}
