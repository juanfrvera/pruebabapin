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
    public abstract class _ActividadPermisoData : EntityData<ActividadPermiso,ActividadPermisoFilter,ActividadPermisoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ActividadPermiso entity)
		{			
			return entity.IdActividadPermiso;
		}		
		public override ActividadPermiso GetByEntity(ActividadPermiso entity)
        {
            return this.GetById(entity.IdActividadPermiso);
        }
        public override ActividadPermiso GetById(int id)
        {
            return (from o in this.Table where o.IdActividadPermiso == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ActividadPermiso> Query(ActividadPermisoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdActividadPermiso == null || o.IdActividadPermiso >=  filter.IdActividadPermiso) && (filter.IdActividadPermiso_To == null || o.IdActividadPermiso <= filter.IdActividadPermiso_To)
					  && (filter.IdPermiso == null || filter.IdPermiso == 0 || o.IdPermiso==filter.IdPermiso)
					  && (filter.IdActividad == null || filter.IdActividad == 0 || o.IdActividad==filter.IdActividad)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ActividadPermisoResult> QueryResult(ActividadPermisoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Actividads on o.IdActividad equals t1.IdActividad   
				    join t2  in this.Context.Permisos on o.IdPermiso equals t2.IdPermiso   
				   select new ActividadPermisoResult(){
					 IdActividadPermiso=o.IdActividadPermiso
					 ,IdPermiso=o.IdPermiso
					 ,IdActividad=o.IdActividad
					,Actividad_Nombre= t1.Nombre	
						,Actividad_Activo= t1.Activo	
						,Permiso_Nombre= t2.Nombre	
						,Permiso_Codigo= t2.Codigo	
						,Permiso_IdSistemaEntidad= t2.IdSistemaEntidad	
						,Permiso_IdSistemaAccion= t2.IdSistemaAccion	
						,Permiso_IdSistemaEstado= t2.IdSistemaEstado	
						,Permiso_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ActividadPermiso Copy(nc.ActividadPermiso entity)
        {           
            nc.ActividadPermiso _new = new nc.ActividadPermiso();
		 _new.IdPermiso= entity.IdPermiso;
		 _new.IdActividad= entity.IdActividad;
		return _new;			
        }
		public override int CopyAndSave(ActividadPermiso entity,string renameFormat)
        {
            ActividadPermiso  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ActividadPermiso entity, int id)
        {            
            entity.IdActividadPermiso = id;            
        }
		public override void Set(ActividadPermiso source,ActividadPermiso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividadPermiso= source.IdActividadPermiso ;
		 target.IdPermiso= source.IdPermiso ;
		 target.IdActividad= source.IdActividad ;
		 		  
		}
		public override void Set(ActividadPermisoResult source,ActividadPermiso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividadPermiso= source.IdActividadPermiso ;
		 target.IdPermiso= source.IdPermiso ;
		 target.IdActividad= source.IdActividad ;
		 
		}
		public override void Set(ActividadPermiso source,ActividadPermisoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividadPermiso= source.IdActividadPermiso ;
		 target.IdPermiso= source.IdPermiso ;
		 target.IdActividad= source.IdActividad ;
		 	
		}		
		public override void Set(ActividadPermisoResult source,ActividadPermisoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdActividadPermiso= source.IdActividadPermiso ;
		 target.IdPermiso= source.IdPermiso ;
		 target.IdActividad= source.IdActividad ;
		 target.Actividad_Nombre= source.Actividad_Nombre;	
			target.Actividad_Activo= source.Actividad_Activo;	
			target.Permiso_Nombre= source.Permiso_Nombre;	
			target.Permiso_Codigo= source.Permiso_Codigo;	
			target.Permiso_IdSistemaEntidad= source.Permiso_IdSistemaEntidad;	
			target.Permiso_IdSistemaAccion= source.Permiso_IdSistemaAccion;	
			target.Permiso_IdSistemaEstado= source.Permiso_IdSistemaEstado;	
			target.Permiso_Activo= source.Permiso_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ActividadPermiso source,ActividadPermiso target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdActividadPermiso.Equals(target.IdActividadPermiso))return false;
		  if(!source.IdPermiso.Equals(target.IdPermiso))return false;
		  if(!source.IdActividad.Equals(target.IdActividad))return false;
		 
		  return true;
        }
		public override bool Equals(ActividadPermisoResult source,ActividadPermisoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdActividadPermiso.Equals(target.IdActividadPermiso))return false;
		  if(!source.IdPermiso.Equals(target.IdPermiso))return false;
		  if(!source.IdActividad.Equals(target.IdActividad))return false;
		  if((source.Actividad_Nombre == null)?target.Actividad_Nombre!=null: !( (target.Actividad_Nombre== String.Empty && source.Actividad_Nombre== null) || (target.Actividad_Nombre==null && source.Actividad_Nombre== String.Empty )) &&   !source.Actividad_Nombre.Trim().Replace ("\r","").Equals(target.Actividad_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Actividad_Activo.Equals(target.Actividad_Activo))return false;
					  if((source.Permiso_Nombre == null)?target.Permiso_Nombre!=null: !( (target.Permiso_Nombre== String.Empty && source.Permiso_Nombre== null) || (target.Permiso_Nombre==null && source.Permiso_Nombre== String.Empty )) &&   !source.Permiso_Nombre.Trim().Replace ("\r","").Equals(target.Permiso_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Permiso_Codigo == null)?target.Permiso_Codigo!=null: !( (target.Permiso_Codigo== String.Empty && source.Permiso_Codigo== null) || (target.Permiso_Codigo==null && source.Permiso_Codigo== String.Empty )) &&   !source.Permiso_Codigo.Trim().Replace ("\r","").Equals(target.Permiso_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Permiso_IdSistemaEntidad == null)?(target.Permiso_IdSistemaEntidad.HasValue && target.Permiso_IdSistemaEntidad.Value > 0):!source.Permiso_IdSistemaEntidad.Equals(target.Permiso_IdSistemaEntidad))return false;
									  if((source.Permiso_IdSistemaAccion == null)?(target.Permiso_IdSistemaAccion.HasValue && target.Permiso_IdSistemaAccion.Value > 0):!source.Permiso_IdSistemaAccion.Equals(target.Permiso_IdSistemaAccion))return false;
									  if((source.Permiso_IdSistemaEstado == null)?(target.Permiso_IdSistemaEstado.HasValue && target.Permiso_IdSistemaEstado.Value > 0):!source.Permiso_IdSistemaEstado.Equals(target.Permiso_IdSistemaEstado))return false;
									  if((source.Permiso_Activo == null)?(target.Permiso_Activo.HasValue ):!source.Permiso_Activo.Equals(target.Permiso_Activo))return false;
								
		  return true;
        }
		#endregion
    }
}
