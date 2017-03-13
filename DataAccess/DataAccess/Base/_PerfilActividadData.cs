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
    public abstract class _PerfilActividadData : EntityData<PerfilActividad,PerfilActividadFilter,PerfilActividadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PerfilActividad entity)
		{			
			return entity.IdPerfilActividad;
		}		
		public override PerfilActividad GetByEntity(PerfilActividad entity)
        {
            return this.GetById(entity.IdPerfilActividad);
        }
        public override PerfilActividad GetById(int id)
        {
            return (from o in this.Table where o.IdPerfilActividad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PerfilActividad> Query(PerfilActividadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPerfilActividad == null || o.IdPerfilActividad >=  filter.IdPerfilActividad) && (filter.IdPerfilActividad_To == null || o.IdPerfilActividad <= filter.IdPerfilActividad_To)
					  && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  && (filter.IdActividad == null || filter.IdActividad == 0 || o.IdActividad==filter.IdActividad)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PerfilActividadResult> QueryResult(PerfilActividadFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Actividads on o.IdActividad equals t1.IdActividad   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				   select new PerfilActividadResult(){
					 IdPerfilActividad=o.IdPerfilActividad
					 ,IdPerfil=o.IdPerfil
					 ,IdActividad=o.IdActividad
					,Actividad_Nombre= t1.Nombre	
						,Actividad_Activo= t1.Activo	
						,Perfil_Nombre= t2.Nombre	
						,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
						,Perfil_Activo= t2.Activo	
						,Perfil_EsDefault= t2.EsDefault	
						,Perfil_Codigo= t2.Codigo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PerfilActividad Copy(nc.PerfilActividad entity)
        {           
            nc.PerfilActividad _new = new nc.PerfilActividad();
		 _new.IdPerfil= entity.IdPerfil;
		 _new.IdActividad= entity.IdActividad;
		return _new;			
        }
		public override int CopyAndSave(PerfilActividad entity,string renameFormat)
        {
            PerfilActividad  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PerfilActividad entity, int id)
        {            
            entity.IdPerfilActividad = id;            
        }
		public override void Set(PerfilActividad source,PerfilActividad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilActividad= source.IdPerfilActividad ;
		 target.IdPerfil= source.IdPerfil ;
		 target.IdActividad= source.IdActividad ;
		 		  
		}
		public override void Set(PerfilActividadResult source,PerfilActividad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilActividad= source.IdPerfilActividad ;
		 target.IdPerfil= source.IdPerfil ;
		 target.IdActividad= source.IdActividad ;
		 
		}
		public override void Set(PerfilActividad source,PerfilActividadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilActividad= source.IdPerfilActividad ;
		 target.IdPerfil= source.IdPerfil ;
		 target.IdActividad= source.IdActividad ;
		 	
		}		
		public override void Set(PerfilActividadResult source,PerfilActividadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPerfilActividad= source.IdPerfilActividad ;
		 target.IdPerfil= source.IdPerfil ;
		 target.IdActividad= source.IdActividad ;
		 target.Actividad_Nombre= source.Actividad_Nombre;	
			target.Actividad_Activo= source.Actividad_Activo;	
			target.Perfil_Nombre= source.Perfil_Nombre;	
			target.Perfil_IdPerfilTipo= source.Perfil_IdPerfilTipo;	
			target.Perfil_Activo= source.Perfil_Activo;	
			target.Perfil_EsDefault= source.Perfil_EsDefault;	
			target.Perfil_Codigo= source.Perfil_Codigo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PerfilActividad source,PerfilActividad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfilActividad.Equals(target.IdPerfilActividad))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if(!source.IdActividad.Equals(target.IdActividad))return false;
		 
		  return true;
        }
		public override bool Equals(PerfilActividadResult source,PerfilActividadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPerfilActividad.Equals(target.IdPerfilActividad))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		  if(!source.IdActividad.Equals(target.IdActividad))return false;
		  if((source.Actividad_Nombre == null)?target.Actividad_Nombre!=null: !( (target.Actividad_Nombre== String.Empty && source.Actividad_Nombre== null) || (target.Actividad_Nombre==null && source.Actividad_Nombre== String.Empty )) &&   !source.Actividad_Nombre.Trim().Replace ("\r","").Equals(target.Actividad_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Actividad_Activo.Equals(target.Actividad_Activo))return false;
					  if((source.Perfil_Nombre == null)?target.Perfil_Nombre!=null: !( (target.Perfil_Nombre== String.Empty && source.Perfil_Nombre== null) || (target.Perfil_Nombre==null && source.Perfil_Nombre== String.Empty )) &&   !source.Perfil_Nombre.Trim().Replace ("\r","").Equals(target.Perfil_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Perfil_IdPerfilTipo.Equals(target.Perfil_IdPerfilTipo))return false;
					  if(!source.Perfil_Activo.Equals(target.Perfil_Activo))return false;
					  if(!source.Perfil_EsDefault.Equals(target.Perfil_EsDefault))return false;
					  if((source.Perfil_Codigo == null)?target.Perfil_Codigo!=null: !( (target.Perfil_Codigo== String.Empty && source.Perfil_Codigo== null) || (target.Perfil_Codigo==null && source.Perfil_Codigo== String.Empty )) &&   !source.Perfil_Codigo.Trim().Replace ("\r","").Equals(target.Perfil_Codigo.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
