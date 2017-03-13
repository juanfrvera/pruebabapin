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
    public abstract class _PrestamoOficinaPerfilData : EntityData<PrestamoOficinaPerfil,PrestamoOficinaPerfilFilter,PrestamoOficinaPerfilResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.PrestamoOficinaPerfil entity)
		{			
			return entity.IdPrestamoOficinaPerfil;
		}		
		public override PrestamoOficinaPerfil GetByEntity(PrestamoOficinaPerfil entity)
        {
            return this.GetById(entity.IdPrestamoOficinaPerfil);
        }
        public override PrestamoOficinaPerfil GetById(int id)
        {
            return (from o in this.Table where o.IdPrestamoOficinaPerfil == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<PrestamoOficinaPerfil> Query(PrestamoOficinaPerfilFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdPrestamoOficinaPerfil == null || filter.IdPrestamoOficinaPerfil == 0 || o.IdPrestamoOficinaPerfil==filter.IdPrestamoOficinaPerfil)
					  && (filter.IdPrestamo == null || filter.IdPrestamo == 0 || o.IdPrestamo==filter.IdPrestamo)
					  && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<PrestamoOficinaPerfilResult> QueryResult(PrestamoOficinaPerfilFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				    join t3  in this.Context.Prestamos on o.IdPrestamo equals t3.IdPrestamo   
				   select new PrestamoOficinaPerfilResult(){
					 IdPrestamoOficinaPerfil=o.IdPrestamoOficinaPerfil
					 ,IdPrestamo=o.IdPrestamo
					 ,IdOficina=o.IdOficina
					 ,IdPerfil=o.IdPerfil
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
						,Perfil_Nombre= t2.Nombre	
						,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
						,Perfil_Activo= t2.Activo	
						,Perfil_EsDefault= t2.EsDefault	
						,Perfil_Codigo= t2.Codigo	
                        //,Prestamo_IdPrograma= t3.IdPrograma	
                        //,Prestamo_Numero= t3.Numero	
                        //,Prestamo_Denominacion= t3.Denominacion	
                        //,Prestamo_Descripcion= t3.Descripcion	
                        //,Prestamo_Observacion= t3.Observacion	
                        //,Prestamo_FechaAlta= t3.FechaAlta	
                        //,Prestamo_FechaModificacion= t3.FechaModificacion	
                        //,Prestamo_IdUsuarioModificacion= t3.IdUsuarioModificacion	
                        //,Prestamo_IdEstadoActual= t3.IdEstadoActual	
                        //,Prestamo_ResponsablePolitico= t3.ResponsablePolitico	
                        //,Prestamo_ResponsableTecnico= t3.ResponsableTecnico	
                        //,Prestamo_CodigoVinculacion1= t3.CodigoVinculacion1	
                        //,Prestamo_CodigoVinculacion2= t3.CodigoVinculacion2	
                        //,Prestamo_Activo= t3.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.PrestamoOficinaPerfil Copy(nc.PrestamoOficinaPerfil entity)
        {           
            nc.PrestamoOficinaPerfil _new = new nc.PrestamoOficinaPerfil();
		 _new.IdPrestamo= entity.IdPrestamo;
		 _new.IdOficina= entity.IdOficina;
		 _new.IdPerfil= entity.IdPerfil;
		return _new;			
        }
		public override int CopyAndSave(PrestamoOficinaPerfil entity,string renameFormat)
        {
            PrestamoOficinaPerfil  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(PrestamoOficinaPerfil entity, int id)
        {            
            entity.IdPrestamoOficinaPerfil = id;            
        }
		public override void Set(PrestamoOficinaPerfil source,PrestamoOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 		  
		}
		public override void Set(PrestamoOficinaPerfilResult source,PrestamoOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 
		}
		public override void Set(PrestamoOficinaPerfil source,PrestamoOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 	
		}		
		public override void Set(PrestamoOficinaPerfilResult source,PrestamoOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdPrestamoOficinaPerfil= source.IdPrestamoOficinaPerfil ;
		 target.IdPrestamo= source.IdPrestamo ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
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
			target.Perfil_Nombre= source.Perfil_Nombre;	
			target.Perfil_IdPerfilTipo= source.Perfil_IdPerfilTipo;	
			target.Perfil_Activo= source.Perfil_Activo;	
			target.Perfil_EsDefault= source.Perfil_EsDefault;	
			target.Perfil_Codigo= source.Perfil_Codigo;	
            //target.Prestamo_IdPrograma= source.Prestamo_IdPrograma;	
            //target.Prestamo_Numero= source.Prestamo_Numero;	
            //target.Prestamo_Denominacion= source.Prestamo_Denominacion;	
            //target.Prestamo_Descripcion= source.Prestamo_Descripcion;	
            //target.Prestamo_Observacion= source.Prestamo_Observacion;	
            //target.Prestamo_FechaAlta= source.Prestamo_FechaAlta;	
            //target.Prestamo_FechaModificacion= source.Prestamo_FechaModificacion;	
            //target.Prestamo_IdUsuarioModificacion= source.Prestamo_IdUsuarioModificacion;	
            //target.Prestamo_IdEstadoActual= source.Prestamo_IdEstadoActual;	
            //target.Prestamo_ResponsablePolitico= source.Prestamo_ResponsablePolitico;	
            //target.Prestamo_ResponsableTecnico= source.Prestamo_ResponsableTecnico;	
            //target.Prestamo_CodigoVinculacion1= source.Prestamo_CodigoVinculacion1;	
            //target.Prestamo_CodigoVinculacion2= source.Prestamo_CodigoVinculacion2;	
            //target.Prestamo_Activo= source.Prestamo_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(PrestamoOficinaPerfil source,PrestamoOficinaPerfil target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoOficinaPerfil.Equals(target.IdPrestamoOficinaPerfil))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		 
		  return true;
        }
		public override bool Equals(PrestamoOficinaPerfilResult source,PrestamoOficinaPerfilResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdPrestamoOficinaPerfil.Equals(target.IdPrestamoOficinaPerfil))return false;
		  if(!source.IdPrestamo.Equals(target.IdPrestamo))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
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
						 if((source.Perfil_Nombre == null)?target.Perfil_Nombre!=null: !( (target.Perfil_Nombre== String.Empty && source.Perfil_Nombre== null) || (target.Perfil_Nombre==null && source.Perfil_Nombre== String.Empty )) &&   !source.Perfil_Nombre.Trim().Replace ("\r","").Equals(target.Perfil_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Perfil_IdPerfilTipo.Equals(target.Perfil_IdPerfilTipo))return false;
					  if(!source.Perfil_Activo.Equals(target.Perfil_Activo))return false;
					  if(!source.Perfil_EsDefault.Equals(target.Perfil_EsDefault))return false;
					  if((source.Perfil_Codigo == null)?target.Perfil_Codigo!=null: !( (target.Perfil_Codigo== String.Empty && source.Perfil_Codigo== null) || (target.Perfil_Codigo==null && source.Perfil_Codigo== String.Empty )) &&   !source.Perfil_Codigo.Trim().Replace ("\r","").Equals(target.Perfil_Codigo.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_IdPrograma.Equals(target.Prestamo_IdPrograma))return false;
                      //if(!source.Prestamo_Numero.Equals(target.Prestamo_Numero))return false;
                      //if((source.Prestamo_Denominacion == null)?target.Prestamo_Denominacion!=null: !( (target.Prestamo_Denominacion== String.Empty && source.Prestamo_Denominacion== null) || (target.Prestamo_Denominacion==null && source.Prestamo_Denominacion== String.Empty )) &&   !source.Prestamo_Denominacion.Trim().Replace ("\r","").Equals(target.Prestamo_Denominacion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Descripcion == null)?target.Prestamo_Descripcion!=null: !( (target.Prestamo_Descripcion== String.Empty && source.Prestamo_Descripcion== null) || (target.Prestamo_Descripcion==null && source.Prestamo_Descripcion== String.Empty )) &&   !source.Prestamo_Descripcion.Trim().Replace ("\r","").Equals(target.Prestamo_Descripcion.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_Observacion == null)?target.Prestamo_Observacion!=null: !( (target.Prestamo_Observacion== String.Empty && source.Prestamo_Observacion== null) || (target.Prestamo_Observacion==null && source.Prestamo_Observacion== String.Empty )) &&   !source.Prestamo_Observacion.Trim().Replace ("\r","").Equals(target.Prestamo_Observacion.Trim().Replace ("\r","")))return false;
                      //   if(!source.Prestamo_FechaAlta.Equals(target.Prestamo_FechaAlta))return false;
                      //if(!source.Prestamo_FechaModificacion.Equals(target.Prestamo_FechaModificacion))return false;
                      //if(!source.Prestamo_IdUsuarioModificacion.Equals(target.Prestamo_IdUsuarioModificacion))return false;
                      //if((source.Prestamo_IdEstadoActual == null)?(target.Prestamo_IdEstadoActual.HasValue ):!source.Prestamo_IdEstadoActual.Equals(target.Prestamo_IdEstadoActual))return false;
                      //   if((source.Prestamo_ResponsablePolitico == null)?target.Prestamo_ResponsablePolitico!=null: !( (target.Prestamo_ResponsablePolitico== String.Empty && source.Prestamo_ResponsablePolitico== null) || (target.Prestamo_ResponsablePolitico==null && source.Prestamo_ResponsablePolitico== String.Empty )) &&   !source.Prestamo_ResponsablePolitico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsablePolitico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_ResponsableTecnico == null)?target.Prestamo_ResponsableTecnico!=null: !( (target.Prestamo_ResponsableTecnico== String.Empty && source.Prestamo_ResponsableTecnico== null) || (target.Prestamo_ResponsableTecnico==null && source.Prestamo_ResponsableTecnico== String.Empty )) &&   !source.Prestamo_ResponsableTecnico.Trim().Replace ("\r","").Equals(target.Prestamo_ResponsableTecnico.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion1 == null)?target.Prestamo_CodigoVinculacion1!=null: !( (target.Prestamo_CodigoVinculacion1== String.Empty && source.Prestamo_CodigoVinculacion1== null) || (target.Prestamo_CodigoVinculacion1==null && source.Prestamo_CodigoVinculacion1== String.Empty )) &&   !source.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion1.Trim().Replace ("\r","")))return false;
                      //   if((source.Prestamo_CodigoVinculacion2 == null)?target.Prestamo_CodigoVinculacion2!=null: !( (target.Prestamo_CodigoVinculacion2== String.Empty && source.Prestamo_CodigoVinculacion2== null) || (target.Prestamo_CodigoVinculacion2==null && source.Prestamo_CodigoVinculacion2== String.Empty )) &&   !source.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","").Equals(target.Prestamo_CodigoVinculacion2.Trim().Replace ("\r","")))return false;
                      //   //if(!source.Prestamo_Activo.Equals(target.Prestamo_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
