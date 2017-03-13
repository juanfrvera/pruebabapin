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
    public abstract class _SistemaEntidadData : EntityData<SistemaEntidad,SistemaEntidadFilter,SistemaEntidadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaEntidad entity)
		{			
			return entity.IdSistemaEntidad;
		}		
		public override SistemaEntidad GetByEntity(SistemaEntidad entity)
        {
            return this.GetById(entity.IdSistemaEntidad);
        }
        public override SistemaEntidad GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaEntidad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaEntidad> Query(SistemaEntidadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.EntidadTipo == null || filter.EntidadTipo.Trim() == string.Empty || filter.EntidadTipo.Trim() == "%"  || (filter.EntidadTipo.EndsWith("%") && filter.EntidadTipo.StartsWith("%") && (o.EntidadTipo.Contains(filter.EntidadTipo.Replace("%", "")))) || (filter.EntidadTipo.EndsWith("%") && o.EntidadTipo.StartsWith(filter.EntidadTipo.Replace("%",""))) || (filter.EntidadTipo.StartsWith("%") && o.EntidadTipo.EndsWith(filter.EntidadTipo.Replace("%",""))) || o.EntidadTipo == filter.EntidadTipo )
					  && (filter.EntidadClase == null || filter.EntidadClase.Trim() == string.Empty || filter.EntidadClase.Trim() == "%"  || (filter.EntidadClase.EndsWith("%") && filter.EntidadClase.StartsWith("%") && (o.EntidadClase.Contains(filter.EntidadClase.Replace("%", "")))) || (filter.EntidadClase.EndsWith("%") && o.EntidadClase.StartsWith(filter.EntidadClase.Replace("%",""))) || (filter.EntidadClase.StartsWith("%") && o.EntidadClase.EndsWith(filter.EntidadClase.Replace("%",""))) || o.EntidadClase == filter.EntidadClase )
					  && (filter.EntidadClaseBase == null || filter.EntidadClaseBase.Trim() == string.Empty || filter.EntidadClaseBase.Trim() == "%"  || (filter.EntidadClaseBase.EndsWith("%") && filter.EntidadClaseBase.StartsWith("%") && (o.EntidadClaseBase.Contains(filter.EntidadClaseBase.Replace("%", "")))) || (filter.EntidadClaseBase.EndsWith("%") && o.EntidadClaseBase.StartsWith(filter.EntidadClaseBase.Replace("%",""))) || (filter.EntidadClaseBase.StartsWith("%") && o.EntidadClaseBase.EndsWith(filter.EntidadClaseBase.Replace("%",""))) || o.EntidadClaseBase == filter.EntidadClaseBase )
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IncluirSeguridad == null || o.IncluirSeguridad==filter.IncluirSeguridad)
					  && (filter.IncluirSeguridadIsNull == null || filter.IncluirSeguridadIsNull == true || o.IncluirSeguridad != null ) && (filter.IncluirSeguridadIsNull == null || filter.IncluirSeguridadIsNull == false || o.IncluirSeguridad == null)
					  && (filter.IncluirConfiguracion == null || o.IncluirConfiguracion==filter.IncluirConfiguracion)
					  && (filter.IncluirConfiguracionIsNull == null || filter.IncluirConfiguracionIsNull == true || o.IncluirConfiguracion != null ) && (filter.IncluirConfiguracionIsNull == null || filter.IncluirConfiguracionIsNull == false || o.IncluirConfiguracion == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaEntidadResult> QueryResult(SistemaEntidadFilter filter)
        {
		  return (from o in Query(filter)					
					select new SistemaEntidadResult(){
					 IdSistemaEntidad=o.IdSistemaEntidad
					 ,Codigo=o.Codigo
					 ,Nombre=o.Nombre
					 ,EntidadTipo=o.EntidadTipo
					 ,EntidadClase=o.EntidadClase
					 ,EntidadClaseBase=o.EntidadClaseBase
					 ,Activo=o.Activo
					 ,IncluirSeguridad=o.IncluirSeguridad
					 ,IncluirConfiguracion=o.IncluirConfiguracion
					}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaEntidad Copy(nc.SistemaEntidad entity)
        {           
            nc.SistemaEntidad _new = new nc.SistemaEntidad();
		 _new.Codigo= entity.Codigo;
		 _new.Nombre= entity.Nombre;
		 _new.EntidadTipo= entity.EntidadTipo;
		 _new.EntidadClase= entity.EntidadClase;
		 _new.EntidadClaseBase= entity.EntidadClaseBase;
		 _new.Activo= entity.Activo;
		 _new.IncluirSeguridad= entity.IncluirSeguridad;
		 _new.IncluirConfiguracion= entity.IncluirConfiguracion;
		return _new;			
        }
		public override int CopyAndSave(SistemaEntidad entity,string renameFormat)
        {
            SistemaEntidad  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaEntidad entity, int id)
        {            
            entity.IdSistemaEntidad = id;            
        }
		public override void Set(SistemaEntidad source,SistemaEntidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.EntidadTipo= source.EntidadTipo ;
		 target.EntidadClase= source.EntidadClase ;
		 target.EntidadClaseBase= source.EntidadClaseBase ;
		 target.Activo= source.Activo ;
		 target.IncluirSeguridad= source.IncluirSeguridad ;
		 target.IncluirConfiguracion= source.IncluirConfiguracion ;
		 		  
		}
		public override void Set(SistemaEntidadResult source,SistemaEntidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.EntidadTipo= source.EntidadTipo ;
		 target.EntidadClase= source.EntidadClase ;
		 target.EntidadClaseBase= source.EntidadClaseBase ;
		 target.Activo= source.Activo ;
		 target.IncluirSeguridad= source.IncluirSeguridad ;
		 target.IncluirConfiguracion= source.IncluirConfiguracion ;
		 
		}
		public override void Set(SistemaEntidad source,SistemaEntidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.EntidadTipo= source.EntidadTipo ;
		 target.EntidadClase= source.EntidadClase ;
		 target.EntidadClaseBase= source.EntidadClaseBase ;
		 target.Activo= source.Activo ;
		 target.IncluirSeguridad= source.IncluirSeguridad ;
		 target.IncluirConfiguracion= source.IncluirConfiguracion ;
		 	
		}		
		public override void Set(SistemaEntidadResult source,SistemaEntidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Codigo= source.Codigo ;
		 target.Nombre= source.Nombre ;
		 target.EntidadTipo= source.EntidadTipo ;
		 target.EntidadClase= source.EntidadClase ;
		 target.EntidadClaseBase= source.EntidadClaseBase ;
		 target.Activo= source.Activo ;
		 target.IncluirSeguridad= source.IncluirSeguridad ;
		 target.IncluirConfiguracion= source.IncluirConfiguracion ;
		 		
		}
		#endregion			
		#region Equals
		public override bool Equals(SistemaEntidad source,SistemaEntidad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.EntidadTipo == null)?target.EntidadTipo!=null:  !( (target.EntidadTipo== String.Empty && source.EntidadTipo== null) || (target.EntidadTipo==null && source.EntidadTipo== String.Empty )) &&  !source.EntidadTipo.Trim().Replace ("\r","").Equals(target.EntidadTipo.Trim().Replace ("\r","")))return false;
			 if((source.EntidadClase == null)?target.EntidadClase!=null:  !( (target.EntidadClase== String.Empty && source.EntidadClase== null) || (target.EntidadClase==null && source.EntidadClase== String.Empty )) &&  !source.EntidadClase.Trim().Replace ("\r","").Equals(target.EntidadClase.Trim().Replace ("\r","")))return false;
			 if((source.EntidadClaseBase == null)?target.EntidadClaseBase!=null:  !( (target.EntidadClaseBase== String.Empty && source.EntidadClaseBase== null) || (target.EntidadClaseBase==null && source.EntidadClaseBase== String.Empty )) &&  !source.EntidadClaseBase.Trim().Replace ("\r","").Equals(target.EntidadClaseBase.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IncluirSeguridad == null)?(target.IncluirSeguridad.HasValue):!source.IncluirSeguridad.Equals(target.IncluirSeguridad))return false;
			 if((source.IncluirConfiguracion == null)?(target.IncluirConfiguracion.HasValue):!source.IncluirConfiguracion.Equals(target.IncluirConfiguracion))return false;
			
		  return true;
        }
		public override bool Equals(SistemaEntidadResult source,SistemaEntidadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.EntidadTipo == null)?target.EntidadTipo!=null: !( (target.EntidadTipo== String.Empty && source.EntidadTipo== null) || (target.EntidadTipo==null && source.EntidadTipo== String.Empty )) && !source.EntidadTipo.Trim().Replace ("\r","").Equals(target.EntidadTipo.Trim().Replace ("\r","")))return false;
			 if((source.EntidadClase == null)?target.EntidadClase!=null: !( (target.EntidadClase== String.Empty && source.EntidadClase== null) || (target.EntidadClase==null && source.EntidadClase== String.Empty )) && !source.EntidadClase.Trim().Replace ("\r","").Equals(target.EntidadClase.Trim().Replace ("\r","")))return false;
			 if((source.EntidadClaseBase == null)?target.EntidadClaseBase!=null: !( (target.EntidadClaseBase== String.Empty && source.EntidadClaseBase== null) || (target.EntidadClaseBase==null && source.EntidadClaseBase== String.Empty )) && !source.EntidadClaseBase.Trim().Replace ("\r","").Equals(target.EntidadClaseBase.Trim().Replace ("\r","")))return false;
			 if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IncluirSeguridad == null)?(target.IncluirSeguridad.HasValue):!source.IncluirSeguridad.Equals(target.IncluirSeguridad))return false;
			 if((source.IncluirConfiguracion == null)?(target.IncluirConfiguracion.HasValue):!source.IncluirConfiguracion.Equals(target.IncluirConfiguracion))return false;
					
		  return true;
        }
		#endregion
    }
}
