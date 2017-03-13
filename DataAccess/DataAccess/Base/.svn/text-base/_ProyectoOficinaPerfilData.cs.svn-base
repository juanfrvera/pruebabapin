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
    public abstract class _ProyectoOficinaPerfilData : EntityData<ProyectoOficinaPerfil,ProyectoOficinaPerfilFilter,ProyectoOficinaPerfilResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoOficinaPerfil entity)
		{			
			return entity.IdProyectoOficinaPerfil;
		}		
		public override ProyectoOficinaPerfil GetByEntity(ProyectoOficinaPerfil entity)
        {
            return this.GetById(entity.IdProyectoOficinaPerfil);
        }
        public override ProyectoOficinaPerfil GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoOficinaPerfil == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoOficinaPerfil> Query(ProyectoOficinaPerfilFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoOficinaPerfil == null || filter.IdProyectoOficinaPerfil == 0 || o.IdProyectoOficinaPerfil==filter.IdProyectoOficinaPerfil)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina==filter.IdOficina)
					  && (filter.IdPerfil == null || filter.IdPerfil == 0 || o.IdPerfil==filter.IdPerfil)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoOficinaPerfilResult> QueryResult(ProyectoOficinaPerfilFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Oficinas on o.IdOficina equals t1.IdOficina   
				    join t2  in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil   
				    join t3  in this.Context.Proyectos on o.IdProyecto equals t3.IdProyecto   
				   select new ProyectoOficinaPerfilResult(){
					 IdProyectoOficinaPerfil=o.IdProyectoOficinaPerfil
					 ,IdProyecto=o.IdProyecto
					 ,IdOficina=o.IdOficina
					 ,IdPerfil=o.IdPerfil
                    //,Oficina_Nombre= t1.Nombre	
                    //    ,Oficina_Codigo= t1.Codigo	
                    //    ,Oficina_Activo= t1.Activo	
                    //    ,Oficina_Visible= t1.Visible	
                    //    ,Oficina_IdOficinaPadre= t1.IdOficinaPadre	
                    //    ,Oficina_IdSaf= t1.IdSaf	
                    //    ,Oficina_BreadcrumbId= t1.BreadcrumbId	
                    //    ,Oficina_BreadcrumbOrden= t1.BreadcrumbOrden	
                    //    ,Oficina_Nivel= t1.Nivel	
                    //    ,Oficina_Orden= t1.Orden	
                    //    ,Oficina_Descripcion= t1.Descripcion	
                    //    ,Oficina_DescripcionInvertida= t1.DescripcionInvertida	
                    //    ,Oficina_Seleccionable= t1.Seleccionable	
                    //    ,Oficina_BreadcrumbCode= t1.BreadcrumbCode	
                    //    ,Oficina_DescripcionCodigo= t1.DescripcionCodigo	
                    //    ,Perfil_Nombre= t2.Nombre	
                    //    ,Perfil_IdPerfilTipo= t2.IdPerfilTipo	
                    //    ,Perfil_Activo= t2.Activo	
                    //    ,Perfil_EsDefault= t2.EsDefault	
                    //    ,Perfil_Codigo= t2.Codigo	
                        //,Proyecto_IdTipoProyecto= t3.IdTipoProyecto	
                        //,Proyecto_IdSubPrograma= t3.IdSubPrograma	
                        //,Proyecto_Codigo= t3.Codigo	
                        //,Proyecto_ProyectoDenominacion= t3.ProyectoDenominacion	
                        //,Proyecto_ProyectoSituacionActual= t3.ProyectoSituacionActual	
                        //,Proyecto_ProyectoDescripcion= t3.ProyectoDescripcion	
                        //,Proyecto_ProyectoObservacion= t3.ProyectoObservacion	
                        //,Proyecto_IdEstado= t3.IdEstado	
                        //,Proyecto_IdProceso= t3.IdProceso	
                        //,Proyecto_IdModalidadContratacion= t3.IdModalidadContratacion	
                        //,Proyecto_IdFinalidadFuncion= t3.IdFinalidadFuncion	
                        //,Proyecto_IdOrganismoPrioridad= t3.IdOrganismoPrioridad	
                        //,Proyecto_SubPrioridad= t3.SubPrioridad	
                        //,Proyecto_EsBorrador= t3.EsBorrador	
                        //,Proyecto_EsProyecto= t3.EsProyecto	
                        //,Proyecto_NroProyecto= t3.NroProyecto	
                        //,Proyecto_AnioCorriente= t3.AnioCorriente	
                        //,Proyecto_FechaInicioEjecucionCalculada= t3.FechaInicioEjecucionCalculada	
                        //,Proyecto_FechaFinEjecucionCalculada= t3.FechaFinEjecucionCalculada	
                        //,Proyecto_FechaAlta= t3.FechaAlta	
                        //,Proyecto_FechaModificacion= t3.FechaModificacion	
                        //,Proyecto_IdUsuarioModificacion= t3.IdUsuarioModificacion	
                        //,Proyecto_IdProyectoPlan= t3.IdProyectoPlan	
                        //,Proyecto_EvaluarValidaciones= t3.EvaluarValidaciones	
                        //,Proyecto_Activo= t3.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoOficinaPerfil Copy(nc.ProyectoOficinaPerfil entity)
        {           
            nc.ProyectoOficinaPerfil _new = new nc.ProyectoOficinaPerfil();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.IdOficina= entity.IdOficina;
		 _new.IdPerfil= entity.IdPerfil;
		return _new;			
        }
		public override int CopyAndSave(ProyectoOficinaPerfil entity,string renameFormat)
        {
            ProyectoOficinaPerfil  newEntity = Copy(entity);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoOficinaPerfil entity, int id)
        {            
            entity.IdProyectoOficinaPerfil = id;            
        }
		public override void Set(ProyectoOficinaPerfil source,ProyectoOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 		  
		}
		public override void Set(ProyectoOficinaPerfilResult source,ProyectoOficinaPerfil target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 
		}
		public override void Set(ProyectoOficinaPerfil source,ProyectoOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 	
		}		
		public override void Set(ProyectoOficinaPerfilResult source,ProyectoOficinaPerfilResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoOficinaPerfil= source.IdProyectoOficinaPerfil ;
		 target.IdProyecto= source.IdProyecto ;
		 target.IdOficina= source.IdOficina ;
		 target.IdPerfil= source.IdPerfil ;
		 target.Oficina_Nombre= source.Oficina_Nombre;	
            //target.Oficina_Codigo= source.Oficina_Codigo;	
            //target.Oficina_Activo= source.Oficina_Activo;	
            //target.Oficina_Visible= source.Oficina_Visible;	
            //target.Oficina_IdOficinaPadre= source.Oficina_IdOficinaPadre;	
            //target.Oficina_IdSaf= source.Oficina_IdSaf;	
            //target.Oficina_BreadcrumbId= source.Oficina_BreadcrumbId;	
            //target.Oficina_BreadcrumbOrden= source.Oficina_BreadcrumbOrden;	
            //target.Oficina_Nivel= source.Oficina_Nivel;	
            //target.Oficina_Orden= source.Oficina_Orden;	
            //target.Oficina_Descripcion= source.Oficina_Descripcion;	
            //target.Oficina_DescripcionInvertida= source.Oficina_DescripcionInvertida;	
            //target.Oficina_Seleccionable= source.Oficina_Seleccionable;	
            //target.Oficina_BreadcrumbCode= source.Oficina_BreadcrumbCode;	
            //target.Oficina_DescripcionCodigo= source.Oficina_DescripcionCodigo;	
            //target.Perfil_Nombre= source.Perfil_Nombre;	
            //target.Perfil_IdPerfilTipo= source.Perfil_IdPerfilTipo;	
            //target.Perfil_Activo= source.Perfil_Activo;	
            //target.Perfil_EsDefault= source.Perfil_EsDefault;	
            //target.Perfil_Codigo= source.Perfil_Codigo;	
            //target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
            //target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
            //target.Proyecto_Codigo= source.Proyecto_Codigo;	
            //target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
            //target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
            //target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
            //target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
            //target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
            //target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
            //target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
            //target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
            //target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
            //target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
            //target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
            //target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
            //target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
            //target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
            //target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
            //target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
            //target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
            //target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
            //target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
            //target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
            //target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
            //target.Proyecto_Activo= source.Proyecto_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoOficinaPerfil source,ProyectoOficinaPerfil target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOficinaPerfil.Equals(target.IdProyectoOficinaPerfil))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoOficinaPerfilResult source,ProyectoOficinaPerfilResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoOficinaPerfil.Equals(target.IdProyectoOficinaPerfil))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdOficina.Equals(target.IdOficina))return false;
		  if(!source.IdPerfil.Equals(target.IdPerfil))return false;
          //if((source.Oficina_Nombre == null)?target.Oficina_Nombre!=null: !( (target.Oficina_Nombre== String.Empty && source.Oficina_Nombre== null) || (target.Oficina_Nombre==null && source.Oficina_Nombre== String.Empty )) &&   !source.Oficina_Nombre.Trim().Replace ("\r","").Equals(target.Oficina_Nombre.Trim().Replace ("\r","")))return false;
          //               if((source.Oficina_Codigo == null)?target.Oficina_Codigo!=null: !( (target.Oficina_Codigo== String.Empty && source.Oficina_Codigo== null) || (target.Oficina_Codigo==null && source.Oficina_Codigo== String.Empty )) &&   !source.Oficina_Codigo.Trim().Replace ("\r","").Equals(target.Oficina_Codigo.Trim().Replace ("\r","")))return false;
          //               if(!source.Oficina_Activo.Equals(target.Oficina_Activo))return false;
          //            if(!source.Oficina_Visible.Equals(target.Oficina_Visible))return false;
          //            if((source.Oficina_IdOficinaPadre == null)?(target.Oficina_IdOficinaPadre.HasValue && target.Oficina_IdOficinaPadre.Value > 0):!source.Oficina_IdOficinaPadre.Equals(target.Oficina_IdOficinaPadre))return false;
          //                            if((source.Oficina_IdSaf == null)?(target.Oficina_IdSaf.HasValue && target.Oficina_IdSaf.Value > 0):!source.Oficina_IdSaf.Equals(target.Oficina_IdSaf))return false;
          //                            if((source.Oficina_BreadcrumbId == null)?target.Oficina_BreadcrumbId!=null: !( (target.Oficina_BreadcrumbId== String.Empty && source.Oficina_BreadcrumbId== null) || (target.Oficina_BreadcrumbId==null && source.Oficina_BreadcrumbId== String.Empty )) &&   !source.Oficina_BreadcrumbId.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbId.Trim().Replace ("\r","")))return false;
          //               if((source.Oficina_BreadcrumbOrden == null)?target.Oficina_BreadcrumbOrden!=null: !( (target.Oficina_BreadcrumbOrden== String.Empty && source.Oficina_BreadcrumbOrden== null) || (target.Oficina_BreadcrumbOrden==null && source.Oficina_BreadcrumbOrden== String.Empty )) &&   !source.Oficina_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
          //               if(!source.Oficina_Nivel.Equals(target.Oficina_Nivel))return false;
          //            if((source.Oficina_Orden == null)?(target.Oficina_Orden.HasValue ):!source.Oficina_Orden.Equals(target.Oficina_Orden))return false;
          //               if((source.Oficina_Descripcion == null)?target.Oficina_Descripcion!=null: !( (target.Oficina_Descripcion== String.Empty && source.Oficina_Descripcion== null) || (target.Oficina_Descripcion==null && source.Oficina_Descripcion== String.Empty )) &&   !source.Oficina_Descripcion.Trim().Replace ("\r","").Equals(target.Oficina_Descripcion.Trim().Replace ("\r","")))return false;
          //               if((source.Oficina_DescripcionInvertida == null)?target.Oficina_DescripcionInvertida!=null: !( (target.Oficina_DescripcionInvertida== String.Empty && source.Oficina_DescripcionInvertida== null) || (target.Oficina_DescripcionInvertida==null && source.Oficina_DescripcionInvertida== String.Empty )) &&   !source.Oficina_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionInvertida.Trim().Replace ("\r","")))return false;
          //               if(!source.Oficina_Seleccionable.Equals(target.Oficina_Seleccionable))return false;
          //            if((source.Oficina_BreadcrumbCode == null)?target.Oficina_BreadcrumbCode!=null: !( (target.Oficina_BreadcrumbCode== String.Empty && source.Oficina_BreadcrumbCode== null) || (target.Oficina_BreadcrumbCode==null && source.Oficina_BreadcrumbCode== String.Empty )) &&   !source.Oficina_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.Oficina_BreadcrumbCode.Trim().Replace ("\r","")))return false;
          //               if((source.Oficina_DescripcionCodigo == null)?target.Oficina_DescripcionCodigo!=null: !( (target.Oficina_DescripcionCodigo== String.Empty && source.Oficina_DescripcionCodigo== null) || (target.Oficina_DescripcionCodigo==null && source.Oficina_DescripcionCodigo== String.Empty )) &&   !source.Oficina_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.Oficina_DescripcionCodigo.Trim().Replace ("\r","")))return false;
          //               if((source.Perfil_Nombre == null)?target.Perfil_Nombre!=null: !( (target.Perfil_Nombre== String.Empty && source.Perfil_Nombre== null) || (target.Perfil_Nombre==null && source.Perfil_Nombre== String.Empty )) &&   !source.Perfil_Nombre.Trim().Replace ("\r","").Equals(target.Perfil_Nombre.Trim().Replace ("\r","")))return false;
          //               if(!source.Perfil_IdPerfilTipo.Equals(target.Perfil_IdPerfilTipo))return false;
          //            if(!source.Perfil_Activo.Equals(target.Perfil_Activo))return false;
          //            if(!source.Perfil_EsDefault.Equals(target.Perfil_EsDefault))return false;
          //            if((source.Perfil_Codigo == null)?target.Perfil_Codigo!=null: !( (target.Perfil_Codigo== String.Empty && source.Perfil_Codigo== null) || (target.Perfil_Codigo==null && source.Perfil_Codigo== String.Empty )) &&   !source.Perfil_Codigo.Trim().Replace ("\r","").Equals(target.Perfil_Codigo.Trim().Replace ("\r","")))return false;
          //               if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
          //            if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
          //            if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
          //            if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
          //               if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
          //               if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
          //            if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
          //                            if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
          //                            if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
          //                            if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
          //                            if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
          //               if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
          //            if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
          //               if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
          //               if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
          //               if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
          //               if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
          //               if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
          //            if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
          //            if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
          //            if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
          //               if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
          //            if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
