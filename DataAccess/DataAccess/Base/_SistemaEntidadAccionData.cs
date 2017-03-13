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
    public abstract class _SistemaEntidadAccionData : EntityData<SistemaEntidadAccion,SistemaEntidadAccionFilter,SistemaEntidadAccionResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaEntidadAccion entity)
		{			
			return entity.IdSistemaEntidadAccion;
		}		
		public override SistemaEntidadAccion GetByEntity(SistemaEntidadAccion entity)
        {
            return this.GetById(entity.IdSistemaEntidadAccion);
        }
        public override SistemaEntidadAccion GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaEntidadAccion == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaEntidadAccion> Query(SistemaEntidadAccionFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaEntidadAccion == null || o.IdSistemaEntidadAccion >=  filter.IdSistemaEntidadAccion) && (filter.IdSistemaEntidadAccion_To == null || o.IdSistemaEntidadAccion <= filter.IdSistemaEntidadAccion_To)
					  && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.IdSistemaAccion == null || filter.IdSistemaAccion == 0 || o.IdSistemaAccion==filter.IdSistemaAccion)
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaEntidadAccionResult> QueryResult(SistemaEntidadAccionFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.SistemaAccions on o.IdSistemaAccion equals t1.IdSistemaAccion   
				    join t2  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals t2.IdSistemaEntidad   
				   select new SistemaEntidadAccionResult(){
					 IdSistemaEntidadAccion=o.IdSistemaEntidadAccion
					 ,IdSistemaEntidad=o.IdSistemaEntidad
					 ,IdSistemaAccion=o.IdSistemaAccion
					 ,Nombre=o.Nombre
					,SistemaAccion_Codigo= t1.Codigo	
						,SistemaAccion_Nombre= t1.Nombre	
						,SistemaAccion_Activo= t1.Activo	
						,SistemaAccion_IncluirEstado= t1.IncluirEstado	
						,SistemaAccion_EsLectura= t1.EsLectura	
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
		public override nc.SistemaEntidadAccion Copy(nc.SistemaEntidadAccion entity)
        {           
            nc.SistemaEntidadAccion _new = new nc.SistemaEntidadAccion();
		 _new.IdSistemaEntidad= entity.IdSistemaEntidad;
		 _new.IdSistemaAccion= entity.IdSistemaAccion;
		 _new.Nombre= entity.Nombre;
		return _new;			
        }
		public override int CopyAndSave(SistemaEntidadAccion entity,string renameFormat)
        {
            SistemaEntidadAccion  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaEntidadAccion entity, int id)
        {            
            entity.IdSistemaEntidadAccion = id;            
        }
		public override void Set(SistemaEntidadAccion source,SistemaEntidadAccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadAccion= source.IdSistemaEntidadAccion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Nombre= source.Nombre ;
		 		  
		}
		public override void Set(SistemaEntidadAccionResult source,SistemaEntidadAccion target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadAccion= source.IdSistemaEntidadAccion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Nombre= source.Nombre ;
		 
		}
		public override void Set(SistemaEntidadAccion source,SistemaEntidadAccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadAccion= source.IdSistemaEntidadAccion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Nombre= source.Nombre ;
		 	
		}		
		public override void Set(SistemaEntidadAccionResult source,SistemaEntidadAccionResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidadAccion= source.IdSistemaEntidadAccion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.IdSistemaAccion= source.IdSistemaAccion ;
		 target.Nombre= source.Nombre ;
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
		public override bool Equals(SistemaEntidadAccion source,SistemaEntidadAccion target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidadAccion.Equals(target.IdSistemaEntidadAccion))return false;
		  if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(SistemaEntidadAccionResult source,SistemaEntidadAccionResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidadAccion.Equals(target.IdSistemaEntidadAccion))return false;
		  if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.IdSistemaAccion.Equals(target.IdSistemaAccion))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
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
