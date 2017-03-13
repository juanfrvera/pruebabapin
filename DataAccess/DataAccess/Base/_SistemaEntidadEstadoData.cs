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
    public abstract class _SistemaEntidadEstadoData : EntityData<SistemaEntidadEstado,SistemaEntidadEstadoFilter,SistemaEntidadEstadoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaEntidadEstado entity)
		{			
			return entity.IdSistemaEntidadEstado;
		}		
		public override SistemaEntidadEstado GetByEntity(SistemaEntidadEstado entity)
        {
            return this.GetById(entity.IdSistemaEntidadEstado);
        }
        public override SistemaEntidadEstado GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaEntidadEstado == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaEntidadEstado> Query(SistemaEntidadEstadoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaEntidadEstado == null || o.IdSistemaEntidadEstado >=  filter.IdSistemaEntidadEstado) && (filter.IdSistemaEntidadEstado_To == null || o.IdSistemaEntidadEstado <= filter.IdSistemaEntidadEstado_To)
					  && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaEntidadEstadoResult> QueryResult(SistemaEntidadEstadoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				    join t2  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals t2.IdSistemaEntidad   
				   select new SistemaEntidadEstadoResult(){
					 IdSistemaEntidadEstado=o.IdSistemaEntidadEstado
					 ,IdSistemaEntidad=o.IdSistemaEntidad
					 ,IdEstado=o.IdEstado
					 ,Nombre=o.Nombre
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,SistemaEntidad_Codigo= t2.Codigo	
						,SistemaEntidad_Nombre= t2.Nombre	
						,SistemaEntidad_EntidadTipo= t2.EntidadTipo	
						,SistemaEntidad_EntidadClase= t2.EntidadClase	
						,SistemaEntidad_EntidadClaseBase= t2.EntidadClaseBase	
						,SistemaEntidad_Activo= t2.Activo	
						,SistemaEntidad_IncluirSeguridad= t2.IncluirSeguridad	
						,SistemaEntidad_IncluirConfiguracion= t2.IncluirConfiguracion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaEntidadEstado Copy(nc.SistemaEntidadEstado entity)
        {           
            nc.SistemaEntidadEstado _new = new nc.SistemaEntidadEstado();
		 _new.IdSistemaEntidad= entity.IdSistemaEntidad;
		 _new.IdEstado= entity.IdEstado;
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(SistemaEntidadEstado entity,string renameFormat)
        {
            SistemaEntidadEstado  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaEntidadEstado entity, int id)
        {            
            entity.IdSistemaEntidadEstado = id;            
        }
		public override void Set(SistemaEntidadEstado source,SistemaEntidadEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadEstado= source.IdSistemaEntidadEstado ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(SistemaEntidadEstadoResult source,SistemaEntidadEstado target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadEstado= source.IdSistemaEntidadEstado ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(SistemaEntidadEstado source,SistemaEntidadEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadEstado= source.IdSistemaEntidadEstado ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(SistemaEntidadEstadoResult source,SistemaEntidadEstadoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadEstado= source.IdSistemaEntidadEstado ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdEstado= source.IdEstado ;
		 target.Nombre= source.Nombre ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
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
		public override bool Equals(SistemaEntidadEstado source,SistemaEntidadEstado target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidadEstado.Equals(target.IdSistemaEntidadEstado))return false;
		  if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(SistemaEntidadEstadoResult source,SistemaEntidadEstadoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidadEstado.Equals(target.IdSistemaEntidadEstado))return false;
		  if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
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
