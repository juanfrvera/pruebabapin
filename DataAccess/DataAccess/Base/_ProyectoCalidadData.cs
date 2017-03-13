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
    public abstract class _ProyectoCalidadData : EntityData<ProyectoCalidad,ProyectoCalidadFilter,ProyectoCalidadResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.ProyectoCalidad entity)
		{			
			return entity.IdProyectoCalidad;
		}		
		public override ProyectoCalidad GetByEntity(ProyectoCalidad entity)
        {
            return this.GetById(entity.IdProyectoCalidad);
        }
        public override ProyectoCalidad GetById(int id)
        {
            return (from o in this.Table where o.IdProyectoCalidad == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<ProyectoCalidad> Query(ProyectoCalidadFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyectoCalidad == null || filter.IdProyectoCalidad == 0 || o.IdProyectoCalidad==filter.IdProyectoCalidad)
					  && (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.DenominacionOK == null || o.DenominacionOK==filter.DenominacionOK)
					  && (filter.DenominacionSugerida == null || filter.DenominacionSugerida.Trim() == string.Empty || filter.DenominacionSugerida.Trim() == "%"  || (filter.DenominacionSugerida.EndsWith("%") && filter.DenominacionSugerida.StartsWith("%") && (o.DenominacionSugerida.Contains(filter.DenominacionSugerida.Replace("%", "")))) || (filter.DenominacionSugerida.EndsWith("%") && o.DenominacionSugerida.StartsWith(filter.DenominacionSugerida.Replace("%",""))) || (filter.DenominacionSugerida.StartsWith("%") && o.DenominacionSugerida.EndsWith(filter.DenominacionSugerida.Replace("%",""))) || o.DenominacionSugerida == filter.DenominacionSugerida )
					  && (filter.DenominacionOriginal == null || filter.DenominacionOriginal.Trim() == string.Empty || filter.DenominacionOriginal.Trim() == "%"  || (filter.DenominacionOriginal.EndsWith("%") && filter.DenominacionOriginal.StartsWith("%") && (o.DenominacionOriginal.Contains(filter.DenominacionOriginal.Replace("%", "")))) || (filter.DenominacionOriginal.EndsWith("%") && o.DenominacionOriginal.StartsWith(filter.DenominacionOriginal.Replace("%",""))) || (filter.DenominacionOriginal.StartsWith("%") && o.DenominacionOriginal.EndsWith(filter.DenominacionOriginal.Replace("%",""))) || o.DenominacionOriginal == filter.DenominacionOriginal )
					  && (filter.ProyectoTipoOk == null || o.ProyectoTipoOk==filter.ProyectoTipoOk)
					  && (filter.IdProyectoTipo == null || filter.IdProyectoTipo == 0 || o.IdProyectoTipo==filter.IdProyectoTipo)
					  && (filter.IdProyectoTipoIsNull == null || filter.IdProyectoTipoIsNull == true || o.IdProyectoTipo != null ) && (filter.IdProyectoTipoIsNull == null || filter.IdProyectoTipoIsNull == false || o.IdProyectoTipo == null)
					  && (filter.EstadoOK == null || o.EstadoOK >=  filter.EstadoOK) && (filter.EstadoOK_To == null || o.EstadoOK <= filter.EstadoOK_To)
					  && (filter.EstadoOKIsNull == null || filter.EstadoOKIsNull == true || o.EstadoOK != null ) && (filter.EstadoOKIsNull == null || filter.EstadoOKIsNull == false || o.EstadoOK == null)
					  && (filter.IdEstadoSugerido == null || o.IdEstadoSugerido >=  filter.IdEstadoSugerido) && (filter.IdEstadoSugerido_To == null || o.IdEstadoSugerido <= filter.IdEstadoSugerido_To)
					  && (filter.IdEstadoSugeridoIsNull == null || filter.IdEstadoSugeridoIsNull == true || o.IdEstadoSugerido != null ) && (filter.IdEstadoSugeridoIsNull == null || filter.IdEstadoSugeridoIsNull == false || o.IdEstadoSugerido == null)
					  && (filter.ProcesoOk == null || o.ProcesoOk==filter.ProcesoOk)
					  //&& (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso==filter.IdProceso)
					  && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == true || o.IdProceso != null ) && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == false || o.IdProceso == null)
					  && (filter.FinalidadFuncionOk == null || o.FinalidadFuncionOk==filter.FinalidadFuncionOk)
					  && (filter.IdClasificacionFuncional == null || filter.IdClasificacionFuncional == 0 || o.IdClasificacionFuncional==filter.IdClasificacionFuncional)
					  && (filter.IdClasificacionFuncionalIsNull == null || filter.IdClasificacionFuncionalIsNull == true || o.IdClasificacionFuncional != null ) && (filter.IdClasificacionFuncionalIsNull == null || filter.IdClasificacionFuncionalIsNull == false || o.IdClasificacionFuncional == null)
					  && (filter.ReqDictamen == null || o.ReqDictamen==filter.ReqDictamen)
					  && (filter.Comenatrio == null || filter.Comenatrio.Trim() == string.Empty || filter.Comenatrio.Trim() == "%"  || (filter.Comenatrio.EndsWith("%") && filter.Comenatrio.StartsWith("%") && (o.Comenatrio.Contains(filter.Comenatrio.Replace("%", "")))) || (filter.Comenatrio.EndsWith("%") && o.Comenatrio.StartsWith(filter.Comenatrio.Replace("%",""))) || (filter.Comenatrio.StartsWith("%") && o.Comenatrio.EndsWith(filter.Comenatrio.Replace("%",""))) || o.Comenatrio == filter.Comenatrio )
					  //&& (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.FechaEstado == null || filter.FechaEstado == DateTime.MinValue || o.FechaEstado >=  filter.FechaEstado) && (filter.FechaEstado_To == null || filter.FechaEstado_To == DateTime.MinValue || o.FechaEstado <= filter.FechaEstado_To)
					  && (filter.FechaEstadoIsNull == null || filter.FechaEstadoIsNull == true || o.FechaEstado != null ) && (filter.FechaEstadoIsNull == null || filter.FechaEstadoIsNull == false || o.FechaEstado == null)
					  && (filter.LocalizacionOK == null || o.LocalizacionOK==filter.LocalizacionOK)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoCalidadResult> QueryResult(ProyectoCalidadFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				   join _t2  in this.Context.FinalidadFuncions on o.IdClasificacionFuncional equals _t2.IdFinalidadFuncion into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.Procesos on o.IdProceso equals _t3.IdProceso into tt3 from t3 in tt3.DefaultIfEmpty()
				    join t4  in this.Context.Proyectos on o.IdProyecto equals t4.IdProyecto   
				   join _t5  in this.Context.ProyectoTipos on o.IdProyectoTipo equals _t5.IdProyectoTipo into tt5 from t5 in tt5.DefaultIfEmpty()
				   select new ProyectoCalidadResult(){
					 IdProyectoCalidad=o.IdProyectoCalidad
					 ,IdProyecto=o.IdProyecto
					 ,DenominacionOK=o.DenominacionOK
					 ,DenominacionSugerida=o.DenominacionSugerida
					 ,DenominacionOriginal=o.DenominacionOriginal
					 ,ProyectoTipoOk=o.ProyectoTipoOk
					 ,IdProyectoTipo=o.IdProyectoTipo
					 ,EstadoOK=o.EstadoOK
					 ,IdEstadoSugerido=o.IdEstadoSugerido
					 ,ProcesoOk=o.ProcesoOk
					 ,IdProceso=o.IdProceso
					 ,FinalidadFuncionOk=o.FinalidadFuncionOk
					 ,IdClasificacionFuncional=o.IdClasificacionFuncional
					 ,ReqDictamen=o.ReqDictamen
					 ,Comenatrio=o.Comenatrio
					 ,IdEstado=o.IdEstado
					 ,FechaEstado=o.FechaEstado
					 ,LocalizacionOK=o.LocalizacionOK
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,ClasificacionFuncional_Codigo= t2!=null?(string)t2.Codigo:null	
						,ClasificacionFuncional_Denominacion= t2!=null?(string)t2.Denominacion:null	
						,ClasificacionFuncional_Activo= t2!=null?(bool?)t2.Activo:null	
						,ClasificacionFuncional_IdFinalidadFunciontipo= t2!=null?(int?)t2.IdFinalidadFunciontipo:null	
						,ClasificacionFuncional_IdFinalidadFuncionPadre= t2!=null?(int?)t2.IdFinalidadFuncionPadre:null	
						,ClasificacionFuncional_BreadcrumbId= t2!=null?(string)t2.BreadcrumbId:null	
						,ClasificacionFuncional_BreadcrumbOrden= t2!=null?(string)t2.BreadcrumbOrden:null	
						,ClasificacionFuncional_Nivel= t2!=null?(int?)t2.Nivel:null	
						,ClasificacionFuncional_Orden= t2!=null?(int?)t2.Orden:null	
						,ClasificacionFuncional_Descripcion= t2!=null?(string)t2.Descripcion:null	
						,ClasificacionFuncional_DescripcionInvertida= t2!=null?(string)t2.DescripcionInvertida:null	
						,ClasificacionFuncional_Seleccionable= t2!=null?(bool?)t2.Seleccionable:null	
						,ClasificacionFuncional_BreadcrumbCode= t2!=null?(string)t2.BreadcrumbCode:null	
						,ClasificacionFuncional_DescripcionCodigo= t2!=null?(string)t2.DescripcionCodigo:null	
						,Proceso_IdProyectoTipo= t3!=null?(int?)t3.IdProyectoTipo:null	
						,Proceso_Nombre= t3!=null?(string)t3.Nombre:null	
						,Proceso_Activo= t3!=null?(bool?)t3.Activo:null	
						,Proyecto_IdTipoProyecto= t4.IdTipoProyecto	
						,Proyecto_IdSubPrograma= t4.IdSubPrograma	
						,Proyecto_Codigo= t4.Codigo	
						,Proyecto_ProyectoDenominacion= t4.ProyectoDenominacion	
						,Proyecto_ProyectoSituacionActual= t4.ProyectoSituacionActual	
						,Proyecto_ProyectoDescripcion= t4.ProyectoDescripcion	
						,Proyecto_ProyectoObservacion= t4.ProyectoObservacion	
						,Proyecto_IdEstado= t4.IdEstado	
						,Proyecto_IdProceso= t4.IdProceso	
						,Proyecto_IdModalidadContratacion= t4.IdModalidadContratacion	
						,Proyecto_IdFinalidadFuncion= t4.IdFinalidadFuncion	
						,Proyecto_IdOrganismoPrioridad= t4.IdOrganismoPrioridad	
						,Proyecto_SubPrioridad= t4.SubPrioridad	
						,Proyecto_EsBorrador= t4.EsBorrador	
						,Proyecto_EsProyecto= t4.EsProyecto	
						,Proyecto_NroProyecto= t4.NroProyecto	
						,Proyecto_AnioCorriente= t4.AnioCorriente	
						,Proyecto_FechaInicioEjecucionCalculada= t4.FechaInicioEjecucionCalculada	
						,Proyecto_FechaFinEjecucionCalculada= t4.FechaFinEjecucionCalculada	
						,Proyecto_FechaAlta= t4.FechaAlta	
						,Proyecto_FechaModificacion= t4.FechaModificacion	
						,Proyecto_IdUsuarioModificacion= t4.IdUsuarioModificacion	
						,Proyecto_IdProyectoPlan= t4.IdProyectoPlan	
						,Proyecto_EvaluarValidaciones= t4.EvaluarValidaciones	
						,Proyecto_Activo= t4.Activo	
						,ProyectoTipo_Sigla= t5!=null?(string)t5.Sigla:null	
						,ProyectoTipo_Nombre= t5!=null?(string)t5.Nombre:null	
						,ProyectoTipo_Activo= t5!=null?(bool?)t5.Activo:null	
						,ProyectoTipo_Tipo= t5!=null?(string)t5.Tipo:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.ProyectoCalidad Copy(nc.ProyectoCalidad entity)
        {           
            nc.ProyectoCalidad _new = new nc.ProyectoCalidad();
		 _new.IdProyecto= entity.IdProyecto;
		 _new.DenominacionOK= entity.DenominacionOK;
		 _new.DenominacionSugerida= entity.DenominacionSugerida;
		 _new.DenominacionOriginal= entity.DenominacionOriginal;
		 _new.ProyectoTipoOk= entity.ProyectoTipoOk;
		 _new.IdProyectoTipo= entity.IdProyectoTipo;
		 _new.EstadoOK= entity.EstadoOK;
		 _new.IdEstadoSugerido= entity.IdEstadoSugerido;
		 _new.ProcesoOk= entity.ProcesoOk;
		 _new.IdProceso= entity.IdProceso;
		 _new.FinalidadFuncionOk= entity.FinalidadFuncionOk;
		 _new.IdClasificacionFuncional= entity.IdClasificacionFuncional;
		 _new.ReqDictamen= entity.ReqDictamen;
		 _new.Comenatrio= entity.Comenatrio;
		 _new.IdEstado= entity.IdEstado;
		 _new.FechaEstado= entity.FechaEstado;
		 _new.LocalizacionOK= entity.LocalizacionOK;
		return _new;			
        }
		public override int CopyAndSave(ProyectoCalidad entity,string renameFormat)
        {
            ProyectoCalidad  newEntity = Copy(entity);
            newEntity.DenominacionSugerida = string.Format(renameFormat,newEntity.DenominacionSugerida);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(ProyectoCalidad entity, int id)
        {            
            entity.IdProyectoCalidad = id;            
        }
		public override void Set(ProyectoCalidad source,ProyectoCalidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.DenominacionOK= source.DenominacionOK ;
		 target.DenominacionSugerida= source.DenominacionSugerida ;
		 target.DenominacionOriginal= source.DenominacionOriginal ;
		 target.ProyectoTipoOk= source.ProyectoTipoOk ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.EstadoOK= source.EstadoOK ;
		 target.IdEstadoSugerido= source.IdEstadoSugerido ;
		 target.ProcesoOk= source.ProcesoOk ;
		 target.IdProceso= source.IdProceso ;
		 target.FinalidadFuncionOk= source.FinalidadFuncionOk ;
		 target.IdClasificacionFuncional= source.IdClasificacionFuncional ;
		 target.ReqDictamen= source.ReqDictamen ;
		 target.Comenatrio= source.Comenatrio ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstado= source.FechaEstado ;
		 target.LocalizacionOK= source.LocalizacionOK ;
		 		  
		}
		public override void Set(ProyectoCalidadResult source,ProyectoCalidad target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.DenominacionOK= source.DenominacionOK ;
		 target.DenominacionSugerida= source.DenominacionSugerida ;
		 target.DenominacionOriginal= source.DenominacionOriginal ;
		 target.ProyectoTipoOk= source.ProyectoTipoOk ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.EstadoOK= source.EstadoOK ;
		 target.IdEstadoSugerido= source.IdEstadoSugerido ;
		 target.ProcesoOk= source.ProcesoOk ;
		 target.IdProceso= source.IdProceso ;
		 target.FinalidadFuncionOk= source.FinalidadFuncionOk ;
		 target.IdClasificacionFuncional= source.IdClasificacionFuncional ;
		 target.ReqDictamen= source.ReqDictamen ;
		 target.Comenatrio= source.Comenatrio ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstado= source.FechaEstado ;
		 target.LocalizacionOK= source.LocalizacionOK ;
		 
		}
		public override void Set(ProyectoCalidad source,ProyectoCalidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.DenominacionOK= source.DenominacionOK ;
		 target.DenominacionSugerida= source.DenominacionSugerida ;
		 target.DenominacionOriginal= source.DenominacionOriginal ;
		 target.ProyectoTipoOk= source.ProyectoTipoOk ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.EstadoOK= source.EstadoOK ;
		 target.IdEstadoSugerido= source.IdEstadoSugerido ;
		 target.ProcesoOk= source.ProcesoOk ;
		 target.IdProceso= source.IdProceso ;
		 target.FinalidadFuncionOk= source.FinalidadFuncionOk ;
		 target.IdClasificacionFuncional= source.IdClasificacionFuncional ;
		 target.ReqDictamen= source.ReqDictamen ;
		 target.Comenatrio= source.Comenatrio ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstado= source.FechaEstado ;
		 target.LocalizacionOK= source.LocalizacionOK ;
		 	
		}		
		public override void Set(ProyectoCalidadResult source,ProyectoCalidadResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyectoCalidad= source.IdProyectoCalidad ;
		 target.IdProyecto= source.IdProyecto ;
		 target.DenominacionOK= source.DenominacionOK ;
		 target.DenominacionSugerida= source.DenominacionSugerida ;
		 target.DenominacionOriginal= source.DenominacionOriginal ;
		 target.ProyectoTipoOk= source.ProyectoTipoOk ;
		 target.IdProyectoTipo= source.IdProyectoTipo ;
		 target.EstadoOK= source.EstadoOK ;
		 target.IdEstadoSugerido= source.IdEstadoSugerido ;
		 target.ProcesoOk= source.ProcesoOk ;
		 target.IdProceso= source.IdProceso ;
		 target.FinalidadFuncionOk= source.FinalidadFuncionOk ;
		 target.IdClasificacionFuncional= source.IdClasificacionFuncional ;
		 target.ReqDictamen= source.ReqDictamen ;
		 target.Comenatrio= source.Comenatrio ;
		 target.IdEstado= source.IdEstado ;
		 target.FechaEstado= source.FechaEstado ;
		 target.LocalizacionOK= source.LocalizacionOK ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.ClasificacionFuncional_Codigo= source.ClasificacionFuncional_Codigo;	
			target.ClasificacionFuncional_Denominacion= source.ClasificacionFuncional_Denominacion;	
			target.ClasificacionFuncional_Activo= source.ClasificacionFuncional_Activo;	
			target.ClasificacionFuncional_IdFinalidadFunciontipo= source.ClasificacionFuncional_IdFinalidadFunciontipo;	
			target.ClasificacionFuncional_IdFinalidadFuncionPadre= source.ClasificacionFuncional_IdFinalidadFuncionPadre;	
			target.ClasificacionFuncional_BreadcrumbId= source.ClasificacionFuncional_BreadcrumbId;	
			target.ClasificacionFuncional_BreadcrumbOrden= source.ClasificacionFuncional_BreadcrumbOrden;	
			target.ClasificacionFuncional_Nivel= source.ClasificacionFuncional_Nivel;	
			target.ClasificacionFuncional_Orden= source.ClasificacionFuncional_Orden;	
			target.ClasificacionFuncional_Descripcion= source.ClasificacionFuncional_Descripcion;	
			target.ClasificacionFuncional_DescripcionInvertida= source.ClasificacionFuncional_DescripcionInvertida;	
			target.ClasificacionFuncional_Seleccionable= source.ClasificacionFuncional_Seleccionable;	
			target.ClasificacionFuncional_BreadcrumbCode= source.ClasificacionFuncional_BreadcrumbCode;	
			target.ClasificacionFuncional_DescripcionCodigo= source.ClasificacionFuncional_DescripcionCodigo;	
			target.Proceso_IdProyectoTipo= source.Proceso_IdProyectoTipo;	
			target.Proceso_Nombre= source.Proceso_Nombre;	
			target.Proceso_Activo= source.Proceso_Activo;	
			target.Proyecto_IdTipoProyecto= source.Proyecto_IdTipoProyecto;	
			target.Proyecto_IdSubPrograma= source.Proyecto_IdSubPrograma;	
			target.Proyecto_Codigo= source.Proyecto_Codigo;	
			target.Proyecto_ProyectoDenominacion= source.Proyecto_ProyectoDenominacion;	
			target.Proyecto_ProyectoSituacionActual= source.Proyecto_ProyectoSituacionActual;	
			target.Proyecto_ProyectoDescripcion= source.Proyecto_ProyectoDescripcion;	
			target.Proyecto_ProyectoObservacion= source.Proyecto_ProyectoObservacion;	
			target.Proyecto_IdEstado= source.Proyecto_IdEstado;	
			target.Proyecto_IdProceso= source.Proyecto_IdProceso;	
			target.Proyecto_IdModalidadContratacion= source.Proyecto_IdModalidadContratacion;	
			target.Proyecto_IdFinalidadFuncion= source.Proyecto_IdFinalidadFuncion;	
			target.Proyecto_IdOrganismoPrioridad= source.Proyecto_IdOrganismoPrioridad;	
			target.Proyecto_SubPrioridad= source.Proyecto_SubPrioridad;	
			target.Proyecto_EsBorrador= source.Proyecto_EsBorrador;	
			target.Proyecto_EsProyecto= source.Proyecto_EsProyecto;	
			target.Proyecto_NroProyecto= source.Proyecto_NroProyecto;	
			target.Proyecto_AnioCorriente= source.Proyecto_AnioCorriente;	
			target.Proyecto_FechaInicioEjecucionCalculada= source.Proyecto_FechaInicioEjecucionCalculada;	
			target.Proyecto_FechaFinEjecucionCalculada= source.Proyecto_FechaFinEjecucionCalculada;	
			target.Proyecto_FechaAlta= source.Proyecto_FechaAlta;	
			target.Proyecto_FechaModificacion= source.Proyecto_FechaModificacion;	
			target.Proyecto_IdUsuarioModificacion= source.Proyecto_IdUsuarioModificacion;	
			target.Proyecto_IdProyectoPlan= source.Proyecto_IdProyectoPlan;	
			target.Proyecto_EvaluarValidaciones= source.Proyecto_EvaluarValidaciones;	
			target.Proyecto_Activo= source.Proyecto_Activo;	
			target.ProyectoTipo_Sigla= source.ProyectoTipo_Sigla;	
			target.ProyectoTipo_Nombre= source.ProyectoTipo_Nombre;	
			target.ProyectoTipo_Activo= source.ProyectoTipo_Activo;	
			target.ProyectoTipo_Tipo= source.ProyectoTipo_Tipo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(ProyectoCalidad source,ProyectoCalidad target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.DenominacionOK.Equals(target.DenominacionOK))return false;
		  if((source.DenominacionSugerida == null)?target.DenominacionSugerida!=null:  !( (target.DenominacionSugerida== String.Empty && source.DenominacionSugerida== null) || (target.DenominacionSugerida==null && source.DenominacionSugerida== String.Empty )) &&  !source.DenominacionSugerida.Trim().Replace ("\r","").Equals(target.DenominacionSugerida.Trim().Replace ("\r","")))return false;
			 if((source.DenominacionOriginal == null)?target.DenominacionOriginal!=null:  !( (target.DenominacionOriginal== String.Empty && source.DenominacionOriginal== null) || (target.DenominacionOriginal==null && source.DenominacionOriginal== String.Empty )) &&  !source.DenominacionOriginal.Trim().Replace ("\r","").Equals(target.DenominacionOriginal.Trim().Replace ("\r","")))return false;
			 if(!source.ProyectoTipoOk.Equals(target.ProyectoTipoOk))return false;
		  if((source.IdProyectoTipo == null)?(target.IdProyectoTipo.HasValue && target.IdProyectoTipo.Value > 0):!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
						  if((source.EstadoOK == null)?(target.EstadoOK.HasValue):!source.EstadoOK.Equals(target.EstadoOK))return false;
			 if((source.IdEstadoSugerido == null)?(target.IdEstadoSugerido.HasValue):!source.IdEstadoSugerido.Equals(target.IdEstadoSugerido))return false;
			 if(!source.ProcesoOk.Equals(target.ProcesoOk))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						  if(!source.FinalidadFuncionOk.Equals(target.FinalidadFuncionOk))return false;
		  if((source.IdClasificacionFuncional == null)?(target.IdClasificacionFuncional.HasValue && target.IdClasificacionFuncional.Value > 0):!source.IdClasificacionFuncional.Equals(target.IdClasificacionFuncional))return false;
						  if(!source.ReqDictamen.Equals(target.ReqDictamen))return false;
		  if((source.Comenatrio == null)?target.Comenatrio!=null:  !( (target.Comenatrio== String.Empty && source.Comenatrio== null) || (target.Comenatrio==null && source.Comenatrio== String.Empty )) &&  !source.Comenatrio.Trim().Replace ("\r","").Equals(target.Comenatrio.Trim().Replace ("\r","")))return false;
			 if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.FechaEstado == null)?(target.FechaEstado.HasValue):!source.FechaEstado.Equals(target.FechaEstado))return false;
			 if(!source.LocalizacionOK.Equals(target.LocalizacionOK))return false;
		 
		  return true;
        }
		public override bool Equals(ProyectoCalidadResult source,ProyectoCalidadResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyectoCalidad.Equals(target.IdProyectoCalidad))return false;
		  if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.DenominacionOK.Equals(target.DenominacionOK))return false;
		  if((source.DenominacionSugerida == null)?target.DenominacionSugerida!=null: !( (target.DenominacionSugerida== String.Empty && source.DenominacionSugerida== null) || (target.DenominacionSugerida==null && source.DenominacionSugerida== String.Empty )) && !source.DenominacionSugerida.Trim().Replace ("\r","").Equals(target.DenominacionSugerida.Trim().Replace ("\r","")))return false;
			 if((source.DenominacionOriginal == null)?target.DenominacionOriginal!=null: !( (target.DenominacionOriginal== String.Empty && source.DenominacionOriginal== null) || (target.DenominacionOriginal==null && source.DenominacionOriginal== String.Empty )) && !source.DenominacionOriginal.Trim().Replace ("\r","").Equals(target.DenominacionOriginal.Trim().Replace ("\r","")))return false;
			 if(!source.ProyectoTipoOk.Equals(target.ProyectoTipoOk))return false;
		  if((source.IdProyectoTipo == null)?(target.IdProyectoTipo.HasValue && target.IdProyectoTipo.Value > 0):!source.IdProyectoTipo.Equals(target.IdProyectoTipo))return false;
						  if((source.EstadoOK == null)?(target.EstadoOK.HasValue):!source.EstadoOK.Equals(target.EstadoOK))return false;
			 if((source.IdEstadoSugerido == null)?(target.IdEstadoSugerido.HasValue):!source.IdEstadoSugerido.Equals(target.IdEstadoSugerido))return false;
			 if(!source.ProcesoOk.Equals(target.ProcesoOk))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						  if(!source.FinalidadFuncionOk.Equals(target.FinalidadFuncionOk))return false;
		  if((source.IdClasificacionFuncional == null)?(target.IdClasificacionFuncional.HasValue && target.IdClasificacionFuncional.Value > 0):!source.IdClasificacionFuncional.Equals(target.IdClasificacionFuncional))return false;
						  if(!source.ReqDictamen.Equals(target.ReqDictamen))return false;
		  if((source.Comenatrio == null)?target.Comenatrio!=null: !( (target.Comenatrio== String.Empty && source.Comenatrio== null) || (target.Comenatrio==null && source.Comenatrio== String.Empty )) && !source.Comenatrio.Trim().Replace ("\r","").Equals(target.Comenatrio.Trim().Replace ("\r","")))return false;
			 if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.FechaEstado == null)?(target.FechaEstado.HasValue):!source.FechaEstado.Equals(target.FechaEstado))return false;
			 if(!source.LocalizacionOK.Equals(target.LocalizacionOK))return false;
		  if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if((source.ClasificacionFuncional_Codigo == null)?target.ClasificacionFuncional_Codigo!=null: !( (target.ClasificacionFuncional_Codigo== String.Empty && source.ClasificacionFuncional_Codigo== null) || (target.ClasificacionFuncional_Codigo==null && source.ClasificacionFuncional_Codigo== String.Empty )) &&   !source.ClasificacionFuncional_Codigo.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionFuncional_Denominacion == null)?target.ClasificacionFuncional_Denominacion!=null: !( (target.ClasificacionFuncional_Denominacion== String.Empty && source.ClasificacionFuncional_Denominacion== null) || (target.ClasificacionFuncional_Denominacion==null && source.ClasificacionFuncional_Denominacion== String.Empty )) &&   !source.ClasificacionFuncional_Denominacion.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionFuncional_Activo.Equals(target.ClasificacionFuncional_Activo))return false;
					  if((source.ClasificacionFuncional_IdFinalidadFunciontipo == null)?(target.ClasificacionFuncional_IdFinalidadFunciontipo.HasValue && target.ClasificacionFuncional_IdFinalidadFunciontipo.Value > 0):!source.ClasificacionFuncional_IdFinalidadFunciontipo.Equals(target.ClasificacionFuncional_IdFinalidadFunciontipo))return false;
									  if((source.ClasificacionFuncional_IdFinalidadFuncionPadre == null)?(target.ClasificacionFuncional_IdFinalidadFuncionPadre.HasValue && target.ClasificacionFuncional_IdFinalidadFuncionPadre.Value > 0):!source.ClasificacionFuncional_IdFinalidadFuncionPadre.Equals(target.ClasificacionFuncional_IdFinalidadFuncionPadre))return false;
									  if((source.ClasificacionFuncional_BreadcrumbId == null)?target.ClasificacionFuncional_BreadcrumbId!=null: !( (target.ClasificacionFuncional_BreadcrumbId== String.Empty && source.ClasificacionFuncional_BreadcrumbId== null) || (target.ClasificacionFuncional_BreadcrumbId==null && source.ClasificacionFuncional_BreadcrumbId== String.Empty )) &&   !source.ClasificacionFuncional_BreadcrumbId.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionFuncional_BreadcrumbOrden == null)?target.ClasificacionFuncional_BreadcrumbOrden!=null: !( (target.ClasificacionFuncional_BreadcrumbOrden== String.Empty && source.ClasificacionFuncional_BreadcrumbOrden== null) || (target.ClasificacionFuncional_BreadcrumbOrden==null && source.ClasificacionFuncional_BreadcrumbOrden== String.Empty )) &&   !source.ClasificacionFuncional_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionFuncional_Nivel == null)?(target.ClasificacionFuncional_Nivel.HasValue ):!source.ClasificacionFuncional_Nivel.Equals(target.ClasificacionFuncional_Nivel))return false;
						 if((source.ClasificacionFuncional_Orden == null)?(target.ClasificacionFuncional_Orden.HasValue ):!source.ClasificacionFuncional_Orden.Equals(target.ClasificacionFuncional_Orden))return false;
						 if((source.ClasificacionFuncional_Descripcion == null)?target.ClasificacionFuncional_Descripcion!=null: !( (target.ClasificacionFuncional_Descripcion== String.Empty && source.ClasificacionFuncional_Descripcion== null) || (target.ClasificacionFuncional_Descripcion==null && source.ClasificacionFuncional_Descripcion== String.Empty )) &&   !source.ClasificacionFuncional_Descripcion.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionFuncional_DescripcionInvertida == null)?target.ClasificacionFuncional_DescripcionInvertida!=null: !( (target.ClasificacionFuncional_DescripcionInvertida== String.Empty && source.ClasificacionFuncional_DescripcionInvertida== null) || (target.ClasificacionFuncional_DescripcionInvertida==null && source.ClasificacionFuncional_DescripcionInvertida== String.Empty )) &&   !source.ClasificacionFuncional_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.ClasificacionFuncional_Seleccionable.Equals(target.ClasificacionFuncional_Seleccionable))return false;
					  if((source.ClasificacionFuncional_BreadcrumbCode == null)?target.ClasificacionFuncional_BreadcrumbCode!=null: !( (target.ClasificacionFuncional_BreadcrumbCode== String.Empty && source.ClasificacionFuncional_BreadcrumbCode== null) || (target.ClasificacionFuncional_BreadcrumbCode==null && source.ClasificacionFuncional_BreadcrumbCode== String.Empty )) &&   !source.ClasificacionFuncional_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.ClasificacionFuncional_DescripcionCodigo == null)?target.ClasificacionFuncional_DescripcionCodigo!=null: !( (target.ClasificacionFuncional_DescripcionCodigo== String.Empty && source.ClasificacionFuncional_DescripcionCodigo== null) || (target.ClasificacionFuncional_DescripcionCodigo==null && source.ClasificacionFuncional_DescripcionCodigo== String.Empty )) &&   !source.ClasificacionFuncional_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.ClasificacionFuncional_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if(!source.Proceso_IdProyectoTipo.Equals(target.Proceso_IdProyectoTipo))return false;
					  if((source.Proceso_Nombre == null)?target.Proceso_Nombre!=null: !( (target.Proceso_Nombre== String.Empty && source.Proceso_Nombre== null) || (target.Proceso_Nombre==null && source.Proceso_Nombre== String.Empty )) &&   !source.Proceso_Nombre.Trim().Replace ("\r","").Equals(target.Proceso_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Proceso_Activo.Equals(target.Proceso_Activo))return false;
					  if(!source.Proyecto_IdTipoProyecto.Equals(target.Proyecto_IdTipoProyecto))return false;
					  if(!source.Proyecto_IdSubPrograma.Equals(target.Proyecto_IdSubPrograma))return false;
					  if(!source.Proyecto_Codigo.Equals(target.Proyecto_Codigo))return false;
					  if((source.Proyecto_ProyectoDenominacion == null)?target.Proyecto_ProyectoDenominacion!=null: !( (target.Proyecto_ProyectoDenominacion== String.Empty && source.Proyecto_ProyectoDenominacion== null) || (target.Proyecto_ProyectoDenominacion==null && source.Proyecto_ProyectoDenominacion== String.Empty )) &&   !source.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDenominacion.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoSituacionActual == null)?target.Proyecto_ProyectoSituacionActual!=null: !( (target.Proyecto_ProyectoSituacionActual== String.Empty && source.Proyecto_ProyectoSituacionActual== null) || (target.Proyecto_ProyectoSituacionActual==null && source.Proyecto_ProyectoSituacionActual== String.Empty )) &&   !source.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoDescripcion == null)?target.Proyecto_ProyectoDescripcion!=null: !( (target.Proyecto_ProyectoDescripcion== String.Empty && source.Proyecto_ProyectoDescripcion== null) || (target.Proyecto_ProyectoDescripcion==null && source.Proyecto_ProyectoDescripcion== String.Empty )) &&   !source.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoDescripcion.Trim().Replace ("\r","")))return false;
						 if((source.Proyecto_ProyectoObservacion == null)?target.Proyecto_ProyectoObservacion!=null: !( (target.Proyecto_ProyectoObservacion== String.Empty && source.Proyecto_ProyectoObservacion== null) || (target.Proyecto_ProyectoObservacion==null && source.Proyecto_ProyectoObservacion== String.Empty )) &&   !source.Proyecto_ProyectoObservacion.Trim().Replace ("\r","").Equals(target.Proyecto_ProyectoObservacion.Trim().Replace ("\r","")))return false;
						 if(!source.Proyecto_IdEstado.Equals(target.Proyecto_IdEstado))return false;
					  if((source.Proyecto_IdProceso == null)?(target.Proyecto_IdProceso.HasValue && target.Proyecto_IdProceso.Value > 0):!source.Proyecto_IdProceso.Equals(target.Proyecto_IdProceso))return false;
									  if((source.Proyecto_IdModalidadContratacion == null)?(target.Proyecto_IdModalidadContratacion.HasValue && target.Proyecto_IdModalidadContratacion.Value > 0):!source.Proyecto_IdModalidadContratacion.Equals(target.Proyecto_IdModalidadContratacion))return false;
									  if((source.Proyecto_IdFinalidadFuncion == null)?(target.Proyecto_IdFinalidadFuncion.HasValue && target.Proyecto_IdFinalidadFuncion.Value > 0):!source.Proyecto_IdFinalidadFuncion.Equals(target.Proyecto_IdFinalidadFuncion))return false;
									  if((source.Proyecto_IdOrganismoPrioridad == null)?(target.Proyecto_IdOrganismoPrioridad.HasValue && target.Proyecto_IdOrganismoPrioridad.Value > 0):!source.Proyecto_IdOrganismoPrioridad.Equals(target.Proyecto_IdOrganismoPrioridad))return false;
									  if((source.Proyecto_SubPrioridad == null)?(target.Proyecto_SubPrioridad.HasValue ):!source.Proyecto_SubPrioridad.Equals(target.Proyecto_SubPrioridad))return false;
						 if(!source.Proyecto_EsBorrador.Equals(target.Proyecto_EsBorrador))return false;
					  if((source.Proyecto_EsProyecto == null)?(target.Proyecto_EsProyecto.HasValue ):!source.Proyecto_EsProyecto.Equals(target.Proyecto_EsProyecto))return false;
						 if((source.Proyecto_NroProyecto == null)?(target.Proyecto_NroProyecto.HasValue ):!source.Proyecto_NroProyecto.Equals(target.Proyecto_NroProyecto))return false;
						 if((source.Proyecto_AnioCorriente == null)?(target.Proyecto_AnioCorriente.HasValue ):!source.Proyecto_AnioCorriente.Equals(target.Proyecto_AnioCorriente))return false;
						 if((source.Proyecto_FechaInicioEjecucionCalculada == null)?(target.Proyecto_FechaInicioEjecucionCalculada.HasValue ):!source.Proyecto_FechaInicioEjecucionCalculada.Equals(target.Proyecto_FechaInicioEjecucionCalculada))return false;
						 if((source.Proyecto_FechaFinEjecucionCalculada == null)?(target.Proyecto_FechaFinEjecucionCalculada.HasValue ):!source.Proyecto_FechaFinEjecucionCalculada.Equals(target.Proyecto_FechaFinEjecucionCalculada))return false;
						 if(!source.Proyecto_FechaAlta.Equals(target.Proyecto_FechaAlta))return false;
					  if(!source.Proyecto_FechaModificacion.Equals(target.Proyecto_FechaModificacion))return false;
					  if(!source.Proyecto_IdUsuarioModificacion.Equals(target.Proyecto_IdUsuarioModificacion))return false;
					  if((source.Proyecto_IdProyectoPlan == null)?(target.Proyecto_IdProyectoPlan.HasValue ):!source.Proyecto_IdProyectoPlan.Equals(target.Proyecto_IdProyectoPlan))return false;
						 if(!source.Proyecto_EvaluarValidaciones.Equals(target.Proyecto_EvaluarValidaciones))return false;
					  //if(!source.Proyecto_Activo.Equals(target.Proyecto_Activo))return false;
					  if((source.ProyectoTipo_Sigla == null)?target.ProyectoTipo_Sigla!=null: !( (target.ProyectoTipo_Sigla== String.Empty && source.ProyectoTipo_Sigla== null) || (target.ProyectoTipo_Sigla==null && source.ProyectoTipo_Sigla== String.Empty )) &&   !source.ProyectoTipo_Sigla.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.ProyectoTipo_Nombre == null)?target.ProyectoTipo_Nombre!=null: !( (target.ProyectoTipo_Nombre== String.Empty && source.ProyectoTipo_Nombre== null) || (target.ProyectoTipo_Nombre==null && source.ProyectoTipo_Nombre== String.Empty )) &&   !source.ProyectoTipo_Nombre.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ProyectoTipo_Activo.Equals(target.ProyectoTipo_Activo))return false;
					  if((source.ProyectoTipo_Tipo == null)?target.ProyectoTipo_Tipo!=null: !( (target.ProyectoTipo_Tipo== String.Empty && source.ProyectoTipo_Tipo== null) || (target.ProyectoTipo_Tipo==null && source.ProyectoTipo_Tipo== String.Empty )) &&   !source.ProyectoTipo_Tipo.Trim().Replace ("\r","").Equals(target.ProyectoTipo_Tipo.Trim().Replace ("\r","")))return false;
								
		  return true;
        }
		#endregion
    }
}
