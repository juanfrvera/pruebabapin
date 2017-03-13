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
    public abstract class _SistemaReporteData : EntityData<SistemaReporte,SistemaReporteFilter,SistemaReporteResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.SistemaReporte entity)
		{			
			return entity.IdSistemaReporte;
		}		
		public override SistemaReporte GetByEntity(SistemaReporte entity)
        {
            return this.GetById(entity.IdSistemaReporte);
        }
        public override SistemaReporte GetById(int id)
        {
            return (from o in this.Table where o.IdSistemaReporte == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<SistemaReporte> Query(SistemaReporteFilter filter)
        {
			return (from o in this.Table
                      where 
                      //(filter.IdSistemaReporte == null || o.IdSistemaReporte >=  filter.IdSistemaReporte) && (filter.IdSistemaReporte_To == null || o.IdSistemaReporte <= filter.IdSistemaReporte_To)&& 
                      (filter.Nombre == null || filter.Nombre.Trim() == string.Empty || filter.Nombre.Trim() == "%"  || (filter.Nombre.EndsWith("%") && filter.Nombre.StartsWith("%") && (o.Nombre.Contains(filter.Nombre.Replace("%", "")))) || (filter.Nombre.EndsWith("%") && o.Nombre.StartsWith(filter.Nombre.Replace("%",""))) || (filter.Nombre.StartsWith("%") && o.Nombre.EndsWith(filter.Nombre.Replace("%",""))) || o.Nombre == filter.Nombre )
					  && (filter.Codigo == null || filter.Codigo.Trim() == string.Empty || filter.Codigo.Trim() == "%"  || (filter.Codigo.EndsWith("%") && filter.Codigo.StartsWith("%") && (o.Codigo.Contains(filter.Codigo.Replace("%", "")))) || (filter.Codigo.EndsWith("%") && o.Codigo.StartsWith(filter.Codigo.Replace("%",""))) || (filter.Codigo.StartsWith("%") && o.Codigo.EndsWith(filter.Codigo.Replace("%",""))) || o.Codigo == filter.Codigo )
					  && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%"  || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%",""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%",""))) || o.Descripcion == filter.Descripcion )
					  && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || o.IdSistemaEntidad==filter.IdSistemaEntidad)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.EsListado == null || o.EsListado==filter.EsListado)
					  && (filter.FileName == null || filter.FileName.Trim() == string.Empty || filter.FileName.Trim() == "%"  || (filter.FileName.EndsWith("%") && filter.FileName.StartsWith("%") && (o.FileName.Contains(filter.FileName.Replace("%", "")))) || (filter.FileName.EndsWith("%") && o.FileName.StartsWith(filter.FileName.Replace("%",""))) || (filter.FileName.StartsWith("%") && o.FileName.EndsWith(filter.FileName.Replace("%",""))) || o.FileName == filter.FileName )
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<SistemaReporteResult> QueryResult(SistemaReporteFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.SistemaEntidads on o.IdSistemaEntidad equals t1.IdSistemaEntidad   
				   select new SistemaReporteResult(){
					 IdSistemaReporte=o.IdSistemaReporte
					 ,Nombre=o.Nombre
					 ,Codigo=o.Codigo
					 ,Descripcion=o.Descripcion
					 ,IdSistemaEntidad=o.IdSistemaEntidad
					 ,Activo=o.Activo
					 ,EsListado=o.EsListado
					 ,FileName=o.FileName
					,SistemaEntidad_Codigo= t1.Codigo	
						,SistemaEntidad_Nombre= t1.Nombre	
						,SistemaEntidad_EntidadTipo= t1.EntidadTipo	
						,SistemaEntidad_EntidadClase= t1.EntidadClase	
						,SistemaEntidad_EntidadClaseBase= t1.EntidadClaseBase	
						,SistemaEntidad_Activo= t1.Activo	
						,SistemaEntidad_IncluirSeguridad= t1.IncluirSeguridad	
						,SistemaEntidad_IncluirConfiguracion= t1.IncluirConfiguracion	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.SistemaReporte Copy(nc.SistemaReporte entity)
        {           
            nc.SistemaReporte _new = new nc.SistemaReporte();
		 _new.Nombre= entity.Nombre;
		 _new.Codigo= entity.Codigo;
		 _new.Descripcion= entity.Descripcion;
		 _new.IdSistemaEntidad= entity.IdSistemaEntidad;
		 _new.Activo= entity.Activo;
		 _new.EsListado= entity.EsListado;
		 _new.FileName= entity.FileName;
		return _new;			
        }
		public override int CopyAndSave(SistemaReporte entity,string renameFormat)
        {
            SistemaReporte  newEntity = Copy(entity);
            newEntity.Nombre = string.Format(renameFormat,newEntity.Nombre);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(SistemaReporte entity, int id)
        {            
            entity.IdSistemaReporte = id;            
        }
		public override void Set(SistemaReporte source,SistemaReporte target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Activo= source.Activo ;
		 target.EsListado= source.EsListado ;
		 target.FileName= source.FileName ;
		 		  
		}
		public override void Set(SistemaReporteResult source,SistemaReporte target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Activo= source.Activo ;
		 target.EsListado= source.EsListado ;
		 target.FileName= source.FileName ;
		 
		}
		public override void Set(SistemaReporte source,SistemaReporteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Activo= source.Activo ;
		 target.EsListado= source.EsListado ;
		 target.FileName= source.FileName ;
		 	
		}		
		public override void Set(SistemaReporteResult source,SistemaReporteResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdSistemaReporte= source.IdSistemaReporte ;
		 target.Nombre= source.Nombre ;
		 target.Codigo= source.Codigo ;
		 target.Descripcion= source.Descripcion ;
		 target.IdSistemaEntidad= source.IdSistemaEntidad ;
		 target.Activo= source.Activo ;
		 target.EsListado= source.EsListado ;
		 target.FileName= source.FileName ;
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
		public override bool Equals(SistemaReporte source,SistemaReporte target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaReporte.Equals(target.IdSistemaReporte))return false;
		  if((source.Nombre == null)?target.Nombre!=null:  !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) &&  !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null:  !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) &&  !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null:  !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) &&  !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.EsListado.Equals(target.EsListado))return false;
		  if((source.FileName == null)?target.FileName!=null:  !( (target.FileName== String.Empty && source.FileName== null) || (target.FileName==null && source.FileName== String.Empty )) &&  !source.FileName.Trim().Replace ("\r","").Equals(target.FileName.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		public override bool Equals(SistemaReporteResult source,SistemaReporteResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdSistemaReporte.Equals(target.IdSistemaReporte))return false;
		  if((source.Nombre == null)?target.Nombre!=null: !( (target.Nombre== String.Empty && source.Nombre== null) || (target.Nombre==null && source.Nombre== String.Empty )) && !source.Nombre.Trim().Replace ("\r","").Equals(target.Nombre.Trim().Replace ("\r","")))return false;
			 if((source.Codigo == null)?target.Codigo!=null: !( (target.Codigo== String.Empty && source.Codigo== null) || (target.Codigo==null && source.Codigo== String.Empty )) && !source.Codigo.Trim().Replace ("\r","").Equals(target.Codigo.Trim().Replace ("\r","")))return false;
			 if((source.Descripcion == null)?target.Descripcion!=null: !( (target.Descripcion== String.Empty && source.Descripcion== null) || (target.Descripcion==null && source.Descripcion== String.Empty )) && !source.Descripcion.Trim().Replace ("\r","").Equals(target.Descripcion.Trim().Replace ("\r","")))return false;
			 if(!source.IdSistemaEntidad.Equals(target.IdSistemaEntidad))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if(!source.EsListado.Equals(target.EsListado))return false;
		  if((source.FileName == null)?target.FileName!=null: !( (target.FileName== String.Empty && source.FileName== null) || (target.FileName==null && source.FileName== String.Empty )) && !source.FileName.Trim().Replace ("\r","").Equals(target.FileName.Trim().Replace ("\r","")))return false;
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
