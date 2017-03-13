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
    public abstract class _PermisoData : EntityData<Permiso,PermisoFilter,PermisoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Permiso entity)
		{			
			return entity.IdPermiso;
		}		
		public override Permiso GetByEntity(Permiso entity)
        {
            return this.GetById(entity.IdPermiso);
        }
        public override Permiso GetById(int id)
        {
            return (from o in this.Table where o.IdPermiso == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Permiso> Query(PermisoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPermiso == null || filter.IdPermiso == 0 || o.IdPermiso==filter.IdPermiso)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.IdSistemaEntidadIsNull == null || filter.IdSistemaEntidadIsNull == true || o.IdSistemaEntidad != null ) && (filter.IdSistemaEntidadIsNull == null || filter.IdSistemaEntidadIsNull == false || o.IdSistemaEntidad == null)
					  && (filter.IdSistemaAccion == null || filter.IdSistemaAccion == 0 || o.IdSistemaAccion==filter.IdSistemaAccion)
					  && (filter.IdSistemaAccionIsNull == null || filter.IdSistemaAccionIsNull == true || o.IdSistemaAccion != null ) && (filter.IdSistemaAccionIsNull == null || filter.IdSistemaAccionIsNull == false || o.IdSistemaAccion == null)
					  && (filter.IdSistemaEstado == null || filter.IdSistemaEstado == 0 || o.IdSistemaEstado==filter.IdSistemaEstado)
					  && (filter.IdSistemaEstadoIsNull == null || filter.IdSistemaEstadoIsNull == true || o.IdSistemaEstado != null ) && (filter.IdSistemaEstadoIsNull == null || filter.IdSistemaEstadoIsNull == false || o.IdSistemaEstado == null)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.ActivoIsNull == null || filter.ActivoIsNull == true || o.Activo != null ) && (filter.ActivoIsNull == null || filter.ActivoIsNull == false || o.Activo == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PermisoResult> QueryResult(PermisoFilter filter)
        {
		  return (from o in Query(filter)					
					join _t1  in this.Context.Estados on o.IdSistemaEstado equals _t1.IdEstado into tt1 from t1 in tt1.DefaultIfEmpty()
				   join _t2  in this.Context.SistemaAccions on o.IdSistemaAccion equals _t2.IdSistemaAccion into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals _t3.IdSistemaEntidad into tt3 from t3 in tt3.DefaultIfEmpty()
				   select new PermisoResult(){
					 IdPermiso=o.IdPermiso
					 ,Nombre=o.Nombre
					 ,Codigo=o.Codigo
					 ,IdSistemaEntidad=o.IdSistemaEntidad
					 ,IdSistemaAccion=o.IdSistemaAccion
					 ,IdSistemaEstado=o.IdSistemaEstado
					 ,Activo=o.Activo
					,SistemaEstado_Nombre= t1!=null?(string)t1.Nombre:null	
						,SistemaEstado_Codigo= t1!=null?(string)t1.Codigo:null	
						,SistemaEstado_Orden= t1!=null?(int?)t1.Orden:null	
						,SistemaEstado_Descripcion= t1!=null?(string)t1.Descripcion:null	
						,SistemaEstado_Activo= t1!=null?(bool?)t1.Activo:null	
						,SistemaAccion_Codigo= t2!=null?(string)t2.Codigo:null	
						,SistemaAccion_Nombre= t2!=null?(string)t2.Nombre:null	
						,SistemaAccion_Activo= t2!=null?(bool?)t2.Activo:null	
						,SistemaAccion_IncluirEstado= t2!=null?(bool?)t2.IncluirEstado:null	
						,SistemaAccion_EsLectura= t2!=null?(bool?)t2.EsLectura:null	
						,SistemaEntidad_Codigo= t3!=null?(string)t3.Codigo:null	
						,SistemaEntidad_Nombre= t3!=null?(string)t3.Nombre:null	
						,SistemaEntidad_EntidadTipo= t3!=null?(string)t3.EntidadTipo:null	
						,SistemaEntidad_EntidadClase= t3!=null?(string)t3.EntidadClase:null	
						,SistemaEntidad_EntidadClaseBase= t3!=null?(string)t3.EntidadClaseBase:null	
						,SistemaEntidad_Activo= t3!=null?(bool?)t3.Activo:null	
						,SistemaEntidad_IncluirSeguridad= t3!=null?(bool?)t3.IncluirSeguridad:null	
						,SistemaEntidad_IncluirConfiguracion= t3!=null?(bool?)t3.IncluirConfiguracion:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Permiso Copy(nc.Permiso entity)
        {           
            nc.Permiso _new = new nc.Permiso();
		 _new.Nombre= entity.Nombre;
		 _new.Codigo= entity.Codigo;
		 _new.IdSistemaEntidad= entity.IdSistemaEntidad;
		 _new.IdSistemaAccion= entity.IdSistemaAccion;
		 _new.IdSistemaEstado= entity.IdSistemaEstado;
		 _new.Activo= entity.Activo;
		return _new;			
        }
		public override int CopyAndSave(Permiso entity,string renameFormat)
        {
            Permiso  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Permiso entity, int id)
        {            
            entity.IdPermiso = id;            
        }
		public override void Set(Permiso source,Permiso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPermiso= source.IdPermiso ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.IdSistemaEstado= source.IdSistemaEstado ;
		 target.Activo= source.Activo ;
		 		  
		}
		public override void Set(PermisoResult source,Permiso target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPermiso= source.IdPermiso ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.IdSistemaEstado= source.IdSistemaEstado ;
		 target.Activo= source.Activo ;
		 
		}
		public override void Set(Permiso source,PermisoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPermiso= source.IdPermiso ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.IdSistemaEstado= source.IdSistemaEstado ;
		 target.Activo= source.Activo ;
		 	
		}		
		public override void Set(PermisoResult source,PermisoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPermiso= source.IdPermiso ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.IdSistemaEstado= source.IdSistemaEstado ;
		 target.Activo= source.Activo ;
		 target.SistemaEstado_Nombre= source.SistemaEstado_Nombre;	
			target.SistemaEstado_Codigo= source.SistemaEstado_Codigo;	
			target.SistemaEstado_Orden= source.SistemaEstado_Orden;	
			target.SistemaEstado_Descripcion= source.SistemaEstado_Descripcion;	
			target.SistemaEstado_Activo= source.SistemaEstado_Activo;	
			target.SistemaAccion_Codigo= source.SistemaAccion_Codigo;	
			target.SistemaAccion_Nombre= source.SistemaAccion_Nombre;	
			target.SistemaAccion_Activo= source.SistemaAccion_Activo;	
			target.SistemaAccion_IncluirEstado= source.SistemaAccion_IncluirEstado;	
			target.SistemaAccion_EsLectura= source.SistemaAccion_EsLectura;	
			target.SistemaEntidad_Codigo= source.SistemaEntidad_Codigo;	
			target.SistemaEntidad_Nombre= source.SistemaEntidad_Nombre;	
			target.SistemaEntidad_EntidadTipo= source.SistemaEntidad_EntidadTipo;	
			target.SistemaEntidad_EntidadClase= source.SistemaEntidad_EntidadClase;	
			target.SistemaEntidad_EntidadClaseBase= source.SistemaEntidad_EntidadClaseBase;	
			target.SistemaEntidad_Activo= source.SistemaEntidad_Activo;	
			target.SistemaEntidad_IncluirSeguridad= source.SistemaEntidad_IncluirSeguridad;	
			target.SistemaEntidad_IncluirConfiguracion= source.SistemaEntidad_IncluirConfiguracion;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Permiso source,Permiso target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPermiso.Equals(target.IdPermiso))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.IdSistemaEntidad == null)?(target.IdSistemaEntidad.HasValue && target.IdSistemaEntidad.Value > 0):!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
						  if((source.IdSistemaAccion == null)?(target.IdSistemaAccion.HasValue && target.IdSistemaAccion.Value > 0):!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
						  if((source.IdSistemaEstado == null)?(target.IdSistemaEstado.HasValue && target.IdSistemaEstado.Value > 0):!source.IdSistemaEstado.Equals(target.IdSistemaEstado))return false;
						  if((source.Activo == null)?(target.Activo.HasValue):!source.Activo.Equals(target.Activo))return false;
			
		  return true;
        }
		public override bool Equals(PermisoResult source,PermisoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPermiso.Equals(target.IdPermiso))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.IdSistemaEntidad == null)?(target.IdSistemaEntidad.HasValue && target.IdSistemaEntidad.Value > 0):!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
						  if((source.IdSistemaAccion == null)?(target.IdSistemaAccion.HasValue && target.IdSistemaAccion.Value > 0):!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
						  if((source.IdSistemaEstado == null)?(target.IdSistemaEstado.HasValue && target.IdSistemaEstado.Value > 0):!source.IdSistemaEstado.Equals(target.IdSistemaEstado))return false;
						  if((source.Activo == null)?(target.Activo.HasValue):!source.Activo.Equals(target.Activo))return false;
			 if((source.SistemaEstado_Nombre == null)?target.SistemaEstado_Nombre!=null: !( (target.SistemaEstado_Nombre== String.Empty && source.SistemaEstado_Nombre== null) || (target.SistemaEstado_Nombre==null && source.SistemaEstado_Nombre== String.Empty )) &&   !source.SistemaEstado_Nombre.Trim().Replace ("\r","").Equals(target.SistemaEstado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEstado_Codigo == null)?target.SistemaEstado_Codigo!=null: !( (target.SistemaEstado_Codigo== String.Empty && source.SistemaEstado_Codigo== null) || (target.SistemaEstado_Codigo==null && source.SistemaEstado_Codigo== String.Empty )) &&   !source.SistemaEstado_Codigo.Trim().Replace ("\r","").Equals(target.SistemaEstado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaEstado_Orden.Equals(target.SistemaEstado_Orden))return false;
					  if((source.SistemaEstado_Descripcion == null)?target.SistemaEstado_Descripcion!=null: !( (target.SistemaEstado_Descripcion== String.Empty && source.SistemaEstado_Descripcion== null) || (target.SistemaEstado_Descripcion==null && source.SistemaEstado_Descripcion== String.Empty )) &&   !source.SistemaEstado_Descripcion.Trim().Replace ("\r","").Equals(target.SistemaEstado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaEstado_Activo.Equals(target.SistemaEstado_Activo))return false;
					  if((source.SistemaAccion_Codigo == null)?target.SistemaAccion_Codigo!=null: !( (target.SistemaAccion_Codigo== String.Empty && source.SistemaAccion_Codigo== null) || (target.SistemaAccion_Codigo==null && source.SistemaAccion_Codigo== String.Empty )) &&   !source.SistemaAccion_Codigo.Trim().Replace ("\r","").Equals(target.SistemaAccion_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaAccion_Nombre == null)?target.SistemaAccion_Nombre!=null: !( (target.SistemaAccion_Nombre== String.Empty && source.SistemaAccion_Nombre== null) || (target.SistemaAccion_Nombre==null && source.SistemaAccion_Nombre== String.Empty )) &&   !source.SistemaAccion_Nombre.Trim().Replace ("\r","").Equals(target.SistemaAccion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaAccion_Activo.Equals(target.SistemaAccion_Activo))return false;
					  if(!source.SistemaAccion_IncluirEstado.Equals(target.SistemaAccion_IncluirEstado))return false;
					  if(!source.SistemaAccion_EsLectura.Equals(target.SistemaAccion_EsLectura))return false;
					  if((source.SistemaEntidad_Codigo == null)?target.SistemaEntidad_Codigo!=null: !( (target.SistemaEntidad_Codigo== String.Empty && source.SistemaEntidad_Codigo== null) || (target.SistemaEntidad_Codigo==null && source.SistemaEntidad_Codigo== String.Empty )) &&   !source.SistemaEntidad_Codigo.Trim().Replace ("\r","").Equals(target.SistemaEntidad_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_Nombre == null)?target.SistemaEntidad_Nombre!=null: !( (target.SistemaEntidad_Nombre== String.Empty && source.SistemaEntidad_Nombre== null) || (target.SistemaEntidad_Nombre==null && source.SistemaEntidad_Nombre== String.Empty )) &&   !source.SistemaEntidad_Nombre.Trim().Replace ("\r","").Equals(target.SistemaEntidad_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadTipo == null)?target.SistemaEntidad_EntidadTipo!=null: !( (target.SistemaEntidad_EntidadTipo== String.Empty && source.SistemaEntidad_EntidadTipo== null) || (target.SistemaEntidad_EntidadTipo==null && source.SistemaEntidad_EntidadTipo== String.Empty )) &&   !source.SistemaEntidad_EntidadTipo.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadTipo.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadClase == null)?target.SistemaEntidad_EntidadClase!=null: !( (target.SistemaEntidad_EntidadClase== String.Empty && source.SistemaEntidad_EntidadClase== null) || (target.SistemaEntidad_EntidadClase==null && source.SistemaEntidad_EntidadClase== String.Empty )) &&   !source.SistemaEntidad_EntidadClase.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadClase.Trim().Replace ("\r","")))return false;
						 if((source.SistemaEntidad_EntidadClaseBase == null)?target.SistemaEntidad_EntidadClaseBase!=null: !( (target.SistemaEntidad_EntidadClaseBase== String.Empty && source.SistemaEntidad_EntidadClaseBase== null) || (target.SistemaEntidad_EntidadClaseBase==null && source.SistemaEntidad_EntidadClaseBase== String.Empty )) &&   !source.SistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","").Equals(target.SistemaEntidad_EntidadClaseBase.Trim().Replace ("\r","")))return false;
						 if(!source.SistemaEntidad_Activo.Equals(target.SistemaEntidad_Activo))return false;
					  if((source.SistemaEntidad_IncluirSeguridad == null)?(target.SistemaEntidad_IncluirSeguridad.HasValue ):!source.SistemaEntidad_IncluirSeguridad.Equals(target.SistemaEntidad_IncluirSeguridad))return false;
						 if((source.SistemaEntidad_IncluirConfiguracion == null)?(target.SistemaEntidad_IncluirConfiguracion.HasValue ):!source.SistemaEntidad_IncluirConfiguracion.Equals(target.SistemaEntidad_IncluirConfiguracion))return false;
								
		  return true;
        }
		#endregion
    }
}
