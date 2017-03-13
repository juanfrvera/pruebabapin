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
    public abstract class _OficinaSafData : EntityData<OficinaSaf,OficinaSafFilter,OficinaSafResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.OficinaSaf entity)
		{			
			return entity.IdOficinaSaf;
		}		
		public override OficinaSaf GetByEntity(OficinaSaf entity)
        {
            return this.GetById(entity.IdOficinaSaf);
        }
        public override OficinaSaf GetById(int id)
        {
            return (from o in this.Table where o.IdOficinaSaf == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<OficinaSaf> Query(OficinaSafFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdOficinaSaf == null || filter.IdOficinaSaf == 0 || o.IdOficinaSaf==filter.IdOficinaSaf)
					  && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.IdSaf == null || filter.IdSaf == 0 || o.IdSaf==filter.IdSaf)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<OficinaSafResult> QueryResult(OficinaSafFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				    join t2  in this.Context.Safs on o.IdSaf equals t2.IdSaf   
				   select new OficinaSafResult(){
					 IdOficinaSaf=o.IdOficinaSaf
					 ,IdOficina=o.IdOficina
					 ,IdSaf=o.IdSaf
					,Oficina_Nombre= t1.Nombre	
						,Oficina_Codigo= t1.Codigo	
						,Oficina_Activo= t1.Activo	
						,Oficina_Visible= t1.Visible	
						,Oficina_IdOficinaPadre= t1.IdOficinaPadre	
						,Oficina_IdSaf= t1.IdSaf	
						,Oficina_BreadcrumbId= t1.BreadcrumbId	
						,Oficina_BreadcrumbOrden= t1.BreadcrumbOrden	
						,Oficina_Nivel= t1.Nivel	
						,Oficina_Orden= t1.Orden	
						,Oficina_Descripcion= t1.Descripcion	
						,Oficina_DescripcionInvertida= t1.DescripcionInvertida	
						,Oficina_Seleccionable= t1.Seleccionable	
						,Oficina_BreadcrumbCode= t1.BreadcrumbCode	
						,Oficina_DescripcionCodigo= t1.DescripcionCodigo	
						,Saf_Codigo= t2.Codigo	
						,Saf_Denominacion= t2.Denominacion	
						,Saf_IdTipoOrganismo= t2.IdTipoOrganismo	
						,Saf_IdSector= t2.IdSector	
						,Saf_IdAdministracionTipo= t2.IdAdministracionTipo	
						,Saf_IdEntidadTipo= t2.IdEntidadTipo	
						,Saf_IdJurisdiccion= t2.IdJurisdiccion	
						,Saf_IdSubJurisdiccion= t2.IdSubJurisdiccion	
						,Saf_FechaAlta= t2.FechaAlta	
						,Saf_FechaBaja= t2.FechaBaja	
						,Saf_Activo= t2.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.OficinaSaf Copy(nc.OficinaSaf entity)
        {           
            nc.OficinaSaf _new = new nc.OficinaSaf();
		 _new.IdOficina= entity.IdOficina;
		 _new.IdSaf= entity.IdSaf;
		return _new;			
        }
		public override int CopyAndSave(OficinaSaf entity,string renameFormat)
        {
            OficinaSaf  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(OficinaSaf entity, int id)
        {            
            entity.IdOficinaSaf = id;            
        }
		public override void Set(OficinaSaf source,OficinaSaf target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdOficina= source.IdOficina ;
		 target.IdSaf= source.IdSaf ;
		 		  
		}
		public override void Set(OficinaSafResult source,OficinaSaf target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdOficina= source.IdOficina ;
		 target.IdSaf= source.IdSaf ;
		 
		}
		public override void Set(OficinaSaf source,OficinaSafResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdOficina= source.IdOficina ;
		 target.IdSaf= source.IdSaf ;
		 	
		}		
		public override void Set(OficinaSafResult source,OficinaSafResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdOficinaSaf= source.IdOficinaSaf ;
		 target.IdOficina= source.IdOficina ;
		 target.IdSaf= source.IdSaf ;
		 target.Oficina_Nombre= source.Oficina_Nombre;	
			target.Oficina_Codigo= source.Oficina_Codigo;	
			target.Oficina_Activo= source.Oficina_Activo;	
			target.Oficina_Visible= source.Oficina_Visible;	
			target.Oficina_IdOficinaPadre= source.Oficina_IdOficinaPadre;	
			target.Oficina_IdSaf= source.Oficina_IdSaf;	
			target.Oficina_BreadcrumbId= source.Oficina_BreadcrumbId;	
			target.Oficina_BreadcrumbOrden= source.Oficina_BreadcrumbOrden;	
			target.Oficina_Nivel= source.Oficina_Nivel;	
			target.Oficina_Orden= source.Oficina_Orden;	
			target.Oficina_Descripcion= source.Oficina_Descripcion;	
			target.Oficina_DescripcionInvertida= source.Oficina_DescripcionInvertida;	
			target.Oficina_Seleccionable= source.Oficina_Seleccionable;	
			target.Oficina_BreadcrumbCode= source.Oficina_BreadcrumbCode;	
			target.Oficina_DescripcionCodigo= source.Oficina_DescripcionCodigo;	
			target.Saf_Codigo= source.Saf_Codigo;	
			target.Saf_Denominacion= source.Saf_Denominacion;	
			target.Saf_IdTipoOrganismo= source.Saf_IdTipoOrganismo;	
			target.Saf_IdSector= source.Saf_IdSector;	
			target.Saf_IdAdministracionTipo= source.Saf_IdAdministracionTipo;	
			target.Saf_IdEntidadTipo= source.Saf_IdEntidadTipo;	
			target.Saf_IdJurisdiccion= source.Saf_IdJurisdiccion;	
			target.Saf_IdSubJurisdiccion= source.Saf_IdSubJurisdiccion;	
			target.Saf_FechaAlta= source.Saf_FechaAlta;	
			target.Saf_FechaBaja= source.Saf_FechaBaja;	
			target.Saf_Activo= source.Saf_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(OficinaSaf source,OficinaSaf target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficinaSaf.Equals(target.IdOficinaSaf))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdSaf.Equals(target.IdSaf))return false;
		 
		  return true;
        }
		public override bool Equals(OficinaSafResult source,OficinaSafResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdOficinaSaf.Equals(target.IdOficinaSaf))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdSaf.Equals(target.IdSaf))return false;
		  if((source.Oficina_Nombre == null)?target.Oficina_Nombre!=null: !( (target.Oficina_Nombre== String.Empty && source.Oficina_Nombre== null) || (target.Oficina_Nombre==null && source.Oficina_Nombre== String.Empty )) &&   !source.Oficina_Nombre.Trim().Replace ("\r","").Equals(target.Oficina_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_Codigo == null)?target.Oficina_Codigo!=null: !( (target.Oficina_Codigo== String.Empty && source.Oficina_Codigo== null) || (target.Oficina_Codigo==null && source.Oficina_Codigo== String.Empty )) &&   !source.Oficina_Codigo.Trim().Replace ("\r","").Equals(target.Oficina_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Activo.Equals(target.Oficina_Activo))return false;
					  if(!source.Oficina_Visible.Equals(target.Oficina_Visible))return false;
					  if((source.Oficina_IdOficinaPadre == null)?(target.Oficina_IdOficinaPadre.HasValue && target.Oficina_IdOficinaPadre.Value > 0):!source.Oficina_IdOficinaPadre.Equals(target.Oficina_IdOficinaPadre))return false;
									  if((source.Oficina_IdSaf == null)?(target.Oficina_IdSaf.HasValue && target.Oficina_IdSaf.Value > 0):!source.Oficina_IdSaf.Equals(target.Oficina_IdSaf))return false;
									  if((source.Oficina_BreadcrumbId == null)?target.Oficina_BreadcrumbId!=null: !( (target.Oficina_BreadcrumbId== String.Empty && source.Oficina_BreadcrumbId== null) || (target.Oficina_BreadcrumbId==null && source.Oficina_BreadcrumbId== String.Empty )) &&   !source.Oficina_BreadcrumbId.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_BreadcrumbOrden == null)?target.Oficina_BreadcrumbOrden!=null: !( (target.Oficina_BreadcrumbOrden== String.Empty && source.Oficina_BreadcrumbOrden== null) || (target.Oficina_BreadcrumbOrden==null && source.Oficina_BreadcrumbOrden== String.Empty )) &&   !source.Oficina_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Nivel.Equals(target.Oficina_Nivel))return false;
					  if((source.Oficina_Orden == null)?(target.Oficina_Orden.HasValue ):!source.Oficina_Orden.Equals(target.Oficina_Orden))return false;
						 if((source.Oficina_Descripcion == null)?target.Oficina_Descripcion!=null: !( (target.Oficina_Descripcion== String.Empty && source.Oficina_Descripcion== null) || (target.Oficina_Descripcion==null && source.Oficina_Descripcion== String.Empty )) &&   !source.Oficina_Descripcion.Trim().Replace ("\r","").Equals(target.Oficina_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_DescripcionInvertida == null)?target.Oficina_DescripcionInvertida!=null: !( (target.Oficina_DescripcionInvertida== String.Empty && source.Oficina_DescripcionInvertida== null) || (target.Oficina_DescripcionInvertida==null && source.Oficina_DescripcionInvertida== String.Empty )) &&   !source.Oficina_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.Oficina_Seleccionable.Equals(target.Oficina_Seleccionable))return false;
					  if((source.Oficina_BreadcrumbCode == null)?target.Oficina_BreadcrumbCode!=null: !( (target.Oficina_BreadcrumbCode== String.Empty && source.Oficina_BreadcrumbCode== null) || (target.Oficina_BreadcrumbCode==null && source.Oficina_BreadcrumbCode== String.Empty )) &&   !source.Oficina_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.Oficina_DescripcionCodigo == null)?target.Oficina_DescripcionCodigo!=null: !( (target.Oficina_DescripcionCodigo== String.Empty && source.Oficina_DescripcionCodigo== null) || (target.Oficina_DescripcionCodigo==null && source.Oficina_DescripcionCodigo== String.Empty )) &&   !source.Oficina_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.Saf_Codigo == null)?target.Saf_Codigo!=null: !( (target.Saf_Codigo== String.Empty && source.Saf_Codigo== null) || (target.Saf_Codigo==null && source.Saf_Codigo== String.Empty )) &&   !source.Saf_Codigo.Trim().Replace ("\r","").Equals(target.Saf_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.Saf_Denominacion == null)?target.Saf_Denominacion!=null: !( (target.Saf_Denominacion== String.Empty && source.Saf_Denominacion== null) || (target.Saf_Denominacion==null && source.Saf_Denominacion== String.Empty )) &&   !source.Saf_Denominacion.Trim().Replace ("\r","").Equals(target.Saf_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.Saf_IdTipoOrganismo.Equals(target.Saf_IdTipoOrganismo))return false;
					  if((source.Saf_IdSector == null)?(target.Saf_IdSector.HasValue && target.Saf_IdSector.Value > 0):!source.Saf_IdSector.Equals(target.Saf_IdSector))return false;
									  if((source.Saf_IdAdministracionTipo == null)?(target.Saf_IdAdministracionTipo.HasValue && target.Saf_IdAdministracionTipo.Value > 0):!source.Saf_IdAdministracionTipo.Equals(target.Saf_IdAdministracionTipo))return false;
									  if((source.Saf_IdEntidadTipo == null)?(target.Saf_IdEntidadTipo.HasValue && target.Saf_IdEntidadTipo.Value > 0):!source.Saf_IdEntidadTipo.Equals(target.Saf_IdEntidadTipo))return false;
									  if((source.Saf_IdJurisdiccion == null)?(target.Saf_IdJurisdiccion.HasValue && target.Saf_IdJurisdiccion.Value > 0):!source.Saf_IdJurisdiccion.Equals(target.Saf_IdJurisdiccion))return false;
									  if((source.Saf_IdSubJurisdiccion == null)?(target.Saf_IdSubJurisdiccion.HasValue && target.Saf_IdSubJurisdiccion.Value > 0):!source.Saf_IdSubJurisdiccion.Equals(target.Saf_IdSubJurisdiccion))return false;
									  if(!source.Saf_FechaAlta.Equals(target.Saf_FechaAlta))return false;
					  if((source.Saf_FechaBaja == null)?(target.Saf_FechaBaja.HasValue ):!source.Saf_FechaBaja.Equals(target.Saf_FechaBaja))return false;
						 if(!source.Saf_Activo.Equals(target.Saf_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
