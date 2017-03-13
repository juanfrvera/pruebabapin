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
    public abstract class _ProyectoData : EntityData<Proyecto,ProyectoFilter,ProyectoResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Proyecto entity)
		{			
			return entity.IdProyecto;
		}		
		public override Proyecto GetByEntity(Proyecto entity)
        {
            return this.GetById(entity.IdProyecto);
        }
        public override Proyecto GetById(int id)
        {
            return (from o in this.Table where o.IdProyecto == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<Proyecto> Query(ProyectoFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdProyecto == null || filter.IdProyecto == 0 || o.IdProyecto==filter.IdProyecto)
					  && (filter.IdTipoProyecto == null || filter.IdTipoProyecto == 0 || o.IdTipoProyecto==filter.IdTipoProyecto)
					  && (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || o.IdSubPrograma==filter.IdSubPrograma)
					  && (filter.Codigo == null || o.Codigo >=  filter.Codigo) && (filter.Codigo_To == null || o.Codigo <= filter.Codigo_To)
					  && (filter.ProyectoDenominacion == null || filter.ProyectoDenominacion.Trim() == string.Empty || filter.ProyectoDenominacion.Trim() == "%"  || (filter.ProyectoDenominacion.EndsWith("%") && filter.ProyectoDenominacion.StartsWith("%") && (o.ProyectoDenominacion.Contains(filter.ProyectoDenominacion.Replace("%", "")))) || (filter.ProyectoDenominacion.EndsWith("%") && o.ProyectoDenominacion.StartsWith(filter.ProyectoDenominacion.Replace("%",""))) || (filter.ProyectoDenominacion.StartsWith("%") && o.ProyectoDenominacion.EndsWith(filter.ProyectoDenominacion.Replace("%",""))) || o.ProyectoDenominacion == filter.ProyectoDenominacion )
					  && (filter.ProyectoSituacionActual == null || filter.ProyectoSituacionActual.Trim() == string.Empty || filter.ProyectoSituacionActual.Trim() == "%"  || (filter.ProyectoSituacionActual.EndsWith("%") && filter.ProyectoSituacionActual.StartsWith("%") && (o.ProyectoSituacionActual.Contains(filter.ProyectoSituacionActual.Replace("%", "")))) || (filter.ProyectoSituacionActual.EndsWith("%") && o.ProyectoSituacionActual.StartsWith(filter.ProyectoSituacionActual.Replace("%",""))) || (filter.ProyectoSituacionActual.StartsWith("%") && o.ProyectoSituacionActual.EndsWith(filter.ProyectoSituacionActual.Replace("%",""))) || o.ProyectoSituacionActual == filter.ProyectoSituacionActual )
					  && (filter.ProyectoDescripcion == null || filter.ProyectoDescripcion.Trim() == string.Empty || filter.ProyectoDescripcion.Trim() == "%"  || (filter.ProyectoDescripcion.EndsWith("%") && filter.ProyectoDescripcion.StartsWith("%") && (o.ProyectoDescripcion.Contains(filter.ProyectoDescripcion.Replace("%", "")))) || (filter.ProyectoDescripcion.EndsWith("%") && o.ProyectoDescripcion.StartsWith(filter.ProyectoDescripcion.Replace("%",""))) || (filter.ProyectoDescripcion.StartsWith("%") && o.ProyectoDescripcion.EndsWith(filter.ProyectoDescripcion.Replace("%",""))) || o.ProyectoDescripcion == filter.ProyectoDescripcion )
					  && (filter.ProyectoObservacion == null || filter.ProyectoObservacion.Trim() == string.Empty || filter.ProyectoObservacion.Trim() == "%"  || (filter.ProyectoObservacion.EndsWith("%") && filter.ProyectoObservacion.StartsWith("%") && (o.ProyectoObservacion.Contains(filter.ProyectoObservacion.Replace("%", "")))) || (filter.ProyectoObservacion.EndsWith("%") && o.ProyectoObservacion.StartsWith(filter.ProyectoObservacion.Replace("%",""))) || (filter.ProyectoObservacion.StartsWith("%") && o.ProyectoObservacion.EndsWith(filter.ProyectoObservacion.Replace("%",""))) || o.ProyectoObservacion == filter.ProyectoObservacion )
					  && (filter.IdEstado == null || filter.IdEstado == 0 || o.IdEstado==filter.IdEstado)
					  && (filter.IdProceso == null || filter.IdProceso == 0 || o.IdProceso==filter.IdProceso)
					  && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == true || o.IdProceso != null ) && (filter.IdProcesoIsNull == null || filter.IdProcesoIsNull == false || o.IdProceso == null)
					  && (filter.IdModalidadContratacion == null || filter.IdModalidadContratacion == 0 || o.IdModalidadContratacion==filter.IdModalidadContratacion)
					  && (filter.IdModalidadContratacionIsNull == null || filter.IdModalidadContratacionIsNull == true || o.IdModalidadContratacion != null ) && (filter.IdModalidadContratacionIsNull == null || filter.IdModalidadContratacionIsNull == false || o.IdModalidadContratacion == null)
					  && (filter.IdFinalidadFuncion == null || filter.IdFinalidadFuncion == 0 || o.IdFinalidadFuncion==filter.IdFinalidadFuncion)
					  && (filter.IdFinalidadFuncionIsNull == null || filter.IdFinalidadFuncionIsNull == true || o.IdFinalidadFuncion != null ) && (filter.IdFinalidadFuncionIsNull == null || filter.IdFinalidadFuncionIsNull == false || o.IdFinalidadFuncion == null)
					  && (filter.IdOrganismoPrioridad == null || filter.IdOrganismoPrioridad == 0 || o.IdOrganismoPrioridad==filter.IdOrganismoPrioridad)
					  && (filter.IdOrganismoPrioridadIsNull == null || filter.IdOrganismoPrioridadIsNull == true || o.IdOrganismoPrioridad != null ) && (filter.IdOrganismoPrioridadIsNull == null || filter.IdOrganismoPrioridadIsNull == false || o.IdOrganismoPrioridad == null)
					  && (filter.SubPrioridad == null || o.SubPrioridad >=  filter.SubPrioridad) && (filter.SubPrioridad_To == null || o.SubPrioridad <= filter.SubPrioridad_To)
					  && (filter.SubPrioridadIsNull == null || filter.SubPrioridadIsNull == true || o.SubPrioridad != null ) && (filter.SubPrioridadIsNull == null || filter.SubPrioridadIsNull == false || o.SubPrioridad == null)
					  && (filter.EsBorrador == null || o.EsBorrador==filter.EsBorrador)
					  && (filter.EsProyecto == null || o.EsProyecto==filter.EsProyecto)
					  && (filter.EsProyectoIsNull == null || filter.EsProyectoIsNull == true || o.EsProyecto != null ) && (filter.EsProyectoIsNull == null || filter.EsProyectoIsNull == false || o.EsProyecto == null)
					  && (filter.NroProyecto == null || o.NroProyecto >=  filter.NroProyecto) && (filter.NroProyecto_To == null || o.NroProyecto <= filter.NroProyecto_To)
					  && (filter.NroProyectoIsNull == null || filter.NroProyectoIsNull == true || o.NroProyecto != null ) && (filter.NroProyectoIsNull == null || filter.NroProyectoIsNull == false || o.NroProyecto == null)
					  && (filter.AnioCorriente == null || o.AnioCorriente >=  filter.AnioCorriente) && (filter.AnioCorriente_To == null || o.AnioCorriente <= filter.AnioCorriente_To)
					  && (filter.AnioCorrienteIsNull == null || filter.AnioCorrienteIsNull == true || o.AnioCorriente != null ) && (filter.AnioCorrienteIsNull == null || filter.AnioCorrienteIsNull == false || o.AnioCorriente == null)
					  && (filter.FechaInicioEjecucionCalculada == null || filter.FechaInicioEjecucionCalculada == DateTime.MinValue || o.FechaInicioEjecucionCalculada >=  filter.FechaInicioEjecucionCalculada) && (filter.FechaInicioEjecucionCalculada_To == null || filter.FechaInicioEjecucionCalculada_To == DateTime.MinValue || o.FechaInicioEjecucionCalculada <= filter.FechaInicioEjecucionCalculada_To)
					  && (filter.FechaInicioEjecucionCalculadaIsNull == null || filter.FechaInicioEjecucionCalculadaIsNull == true || o.FechaInicioEjecucionCalculada != null ) && (filter.FechaInicioEjecucionCalculadaIsNull == null || filter.FechaInicioEjecucionCalculadaIsNull == false || o.FechaInicioEjecucionCalculada == null)
					  && (filter.FechaFinEjecucionCalculada == null || filter.FechaFinEjecucionCalculada == DateTime.MinValue || o.FechaFinEjecucionCalculada >=  filter.FechaFinEjecucionCalculada) && (filter.FechaFinEjecucionCalculada_To == null || filter.FechaFinEjecucionCalculada_To == DateTime.MinValue || o.FechaFinEjecucionCalculada <= filter.FechaFinEjecucionCalculada_To)
					  && (filter.FechaFinEjecucionCalculadaIsNull == null || filter.FechaFinEjecucionCalculadaIsNull == true || o.FechaFinEjecucionCalculada != null ) && (filter.FechaFinEjecucionCalculadaIsNull == null || filter.FechaFinEjecucionCalculadaIsNull == false || o.FechaFinEjecucionCalculada == null)
					  && (filter.FechaAlta == null || filter.FechaAlta == DateTime.MinValue || o.FechaAlta >=  filter.FechaAlta) && (filter.FechaAlta_To == null || filter.FechaAlta_To == DateTime.MinValue || o.FechaAlta <= filter.FechaAlta_To)
					  && (filter.FechaModificacion == null || filter.FechaModificacion == DateTime.MinValue || o.FechaModificacion >=  filter.FechaModificacion) && (filter.FechaModificacion_To == null || filter.FechaModificacion_To == DateTime.MinValue || o.FechaModificacion <= filter.FechaModificacion_To)
					  && (filter.IdUsuarioModificacion == null || o.IdUsuarioModificacion >=  filter.IdUsuarioModificacion) && (filter.IdUsuarioModificacion_To == null || o.IdUsuarioModificacion <= filter.IdUsuarioModificacion_To)
					  && (filter.IdProyectoPlan == null || o.IdProyectoPlan >=  filter.IdProyectoPlan) && (filter.IdProyectoPlan_To == null || o.IdProyectoPlan <= filter.IdProyectoPlan_To)
					  && (filter.IdProyectoPlanIsNull == null || filter.IdProyectoPlanIsNull == true || o.IdProyectoPlan != null ) && (filter.IdProyectoPlanIsNull == null || filter.IdProyectoPlanIsNull == false || o.IdProyectoPlan == null)
					  && (filter.EvaluarValidaciones == null || o.EvaluarValidaciones==filter.EvaluarValidaciones)
					  && (filter.Activo == null || o.Activo==filter.Activo)
					  && (filter.IdEstadoDeDesicion == null || filter.IdEstadoDeDesicion == 0 || o.IdEstadoDeDesicion==filter.IdEstadoDeDesicion)
					  && (filter.IdEstadoDeDesicionIsNull == null || filter.IdEstadoDeDesicionIsNull == true || o.IdEstadoDeDesicion != null ) && (filter.IdEstadoDeDesicionIsNull == null || filter.IdEstadoDeDesicionIsNull == false || o.IdEstadoDeDesicion == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<ProyectoResult> QueryResult(ProyectoFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Estados on o.IdEstado equals t1.IdEstado   
				   join _t2  in this.Context.EstadoDeDesicions on o.IdEstadoDeDesicion equals _t2.IdEstadoDeDesicion into tt2 from t2 in tt2.DefaultIfEmpty()
				   join _t3  in this.Context.FinalidadFuncions on o.IdFinalidadFuncion equals _t3.IdFinalidadFuncion into tt3 from t3 in tt3.DefaultIfEmpty()
				   join _t4  in this.Context.ModalidadContratacions on o.IdModalidadContratacion equals _t4.IdModalidadContratacion into tt4 from t4 in tt4.DefaultIfEmpty()
				   join _t5  in this.Context.OrganismoPrioridads on o.IdOrganismoPrioridad equals _t5.IdOrganismoPrioridad into tt5 from t5 in tt5.DefaultIfEmpty()
				   join _t6  in this.Context.Procesos on o.IdProceso equals _t6.IdProceso into tt6 from t6 in tt6.DefaultIfEmpty()
				    join t7  in this.Context.ProyectoTipos on o.IdTipoProyecto equals t7.IdProyectoTipo   
				    join t8  in this.Context.SubProgramas on o.IdSubPrograma equals t8.IdSubPrograma   
				   select new ProyectoResult(){
					 IdProyecto=o.IdProyecto
					 ,IdTipoProyecto=o.IdTipoProyecto
					 ,IdSubPrograma=o.IdSubPrograma
					 ,Codigo=o.Codigo
					 ,ProyectoDenominacion=o.ProyectoDenominacion
					 ,ProyectoSituacionActual=o.ProyectoSituacionActual
					 ,ProyectoDescripcion=o.ProyectoDescripcion
					 ,ProyectoObservacion=o.ProyectoObservacion
					 ,IdEstado=o.IdEstado
					 ,IdProceso=o.IdProceso
					 ,IdModalidadContratacion=o.IdModalidadContratacion
					 ,IdFinalidadFuncion=o.IdFinalidadFuncion
					 ,IdOrganismoPrioridad=o.IdOrganismoPrioridad
					 ,SubPrioridad=o.SubPrioridad
					 ,EsBorrador=o.EsBorrador
					 ,EsProyecto=o.EsProyecto
					 ,NroProyecto=o.NroProyecto
					 ,AnioCorriente=o.AnioCorriente
					 ,FechaInicioEjecucionCalculada=o.FechaInicioEjecucionCalculada
					 ,FechaFinEjecucionCalculada=o.FechaFinEjecucionCalculada
					 ,FechaAlta=o.FechaAlta
					 ,FechaModificacion=o.FechaModificacion
					 ,IdUsuarioModificacion=o.IdUsuarioModificacion
					 ,IdProyectoPlan=o.IdProyectoPlan
					 ,EvaluarValidaciones=o.EvaluarValidaciones
					 ,Activo=o.Activo
					 ,IdEstadoDeDesicion=o.IdEstadoDeDesicion
					,Estado_Nombre= t1.Nombre	
						,Estado_Codigo= t1.Codigo	
						,Estado_Orden= t1.Orden	
						,Estado_Descripcion= t1.Descripcion	
						,Estado_Activo= t1.Activo	
						,EstadoDeDesicion_Nombre= t2!=null?(string)t2.Nombre:null	
						,EstadoDeDesicion_Codigo= t2!=null?(string)t2.Codigo:null	
						,EstadoDeDesicion_Orden= t2!=null?(int?)t2.Orden:null	
						,EstadoDeDesicion_Descripcion= t2!=null?(string)t2.Descripcion:null	
						,EstadoDeDesicion_Activo= t2!=null?(bool?)t2.Activo:null	
						,FinalidadFuncion_Codigo= t3!=null?(string)t3.Codigo:null	
						,FinalidadFuncion_Denominacion= t3!=null?(string)t3.Denominacion:null	
						,FinalidadFuncion_Activo= t3!=null?(bool?)t3.Activo:null	
						,FinalidadFuncion_IdFinalidadFunciontipo= t3!=null?(int?)t3.IdFinalidadFunciontipo:null	
						,FinalidadFuncion_IdFinalidadFuncionPadre= t3!=null?(int?)t3.IdFinalidadFuncionPadre:null	
						,FinalidadFuncion_BreadcrumbId= t3!=null?(string)t3.BreadcrumbId:null	
						,FinalidadFuncion_BreadcrumbOrden= t3!=null?(string)t3.BreadcrumbOrden:null	
						,FinalidadFuncion_Nivel= t3!=null?(int?)t3.Nivel:null	
						,FinalidadFuncion_Orden= t3!=null?(int?)t3.Orden:null	
						,FinalidadFuncion_Descripcion= t3!=null?(string)t3.Descripcion:null	
						,FinalidadFuncion_DescripcionInvertida= t3!=null?(string)t3.DescripcionInvertida:null	
						,FinalidadFuncion_Seleccionable= t3!=null?(bool?)t3.Seleccionable:null	
						,FinalidadFuncion_BreadcrumbCode= t3!=null?(string)t3.BreadcrumbCode:null	
						,FinalidadFuncion_DescripcionCodigo= t3!=null?(string)t3.DescripcionCodigo:null	
						,ModalidadContratacion_Nombre= t4!=null?(string)t4.Nombre:null	
						,ModalidadContratacion_Activo= t4!=null?(bool?)t4.Activo:null	
						,OrganismoPrioridad_Nombre= t5!=null?(string)t5.Nombre:null	
						,OrganismoPrioridad_Activo= t5!=null?(bool?)t5.Activo:null	
						,Proceso_IdProyectoTipo= t6!=null?(int?)t6.IdProyectoTipo:null	
						,Proceso_Nombre= t6!=null?(string)t6.Nombre:null	
						,Proceso_Activo= t6!=null?(bool?)t6.Activo:null	
						,TipoProyecto_Sigla= t7.Sigla	
						,TipoProyecto_Nombre= t7.Nombre	
						,TipoProyecto_Activo= t7.Activo	
						,TipoProyecto_Tipo= t7.Tipo	
						,SubPrograma_IdPrograma= t8.IdPrograma	
						,SubPrograma_Codigo= t8.Codigo	
						,SubPrograma_Nombre= t8.Nombre	
						,SubPrograma_FechaAlta= t8.FechaAlta	
						,SubPrograma_FechaBaja= t8.FechaBaja	
						,SubPrograma_Activo= t8.Activo	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Proyecto Copy(nc.Proyecto entity)
        {           
            nc.Proyecto _new = new nc.Proyecto();
		 _new.IdTipoProyecto= entity.IdTipoProyecto;
		 _new.IdSubPrograma= entity.IdSubPrograma;
		 _new.Codigo= entity.Codigo;
		 _new.ProyectoDenominacion= entity.ProyectoDenominacion;
		 _new.ProyectoSituacionActual= entity.ProyectoSituacionActual;
		 _new.ProyectoDescripcion= entity.ProyectoDescripcion;
		 _new.ProyectoObservacion= entity.ProyectoObservacion;
		 _new.IdEstado= entity.IdEstado;
		 _new.IdProceso= entity.IdProceso;
		 _new.IdModalidadContratacion= entity.IdModalidadContratacion;
		 _new.IdFinalidadFuncion= entity.IdFinalidadFuncion;
		 _new.IdOrganismoPrioridad= entity.IdOrganismoPrioridad;
		 _new.SubPrioridad= entity.SubPrioridad;
		 _new.EsBorrador= entity.EsBorrador;
		 _new.EsProyecto= entity.EsProyecto;
		 _new.NroProyecto= entity.NroProyecto;
		 _new.AnioCorriente= entity.AnioCorriente;
		 _new.FechaInicioEjecucionCalculada= entity.FechaInicioEjecucionCalculada;
		 _new.FechaFinEjecucionCalculada= entity.FechaFinEjecucionCalculada;
		 _new.FechaAlta= entity.FechaAlta;
		 _new.FechaModificacion= entity.FechaModificacion;
		 _new.IdUsuarioModificacion= entity.IdUsuarioModificacion;
		 _new.IdProyectoPlan= entity.IdProyectoPlan;
		 _new.EvaluarValidaciones= entity.EvaluarValidaciones;
		 _new.Activo= entity.Activo;
		 _new.IdEstadoDeDesicion= entity.IdEstadoDeDesicion;
		return _new;			
        }
		public override int CopyAndSave(Proyecto entity,string renameFormat)
        {
            Proyecto  newEntity = Copy(entity);
            newEntity.ProyectoDenominacion = string.Format(renameFormat,newEntity.ProyectoDenominacion);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Proyecto entity, int id)
        {            
            entity.IdProyecto = id;            
        }
		public override void Set(Proyecto source,Proyecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyecto= source.IdProyecto ;
		 target.IdTipoProyecto= source.IdTipoProyecto ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Codigo= source.Codigo ;
		 target.ProyectoDenominacion= source.ProyectoDenominacion ;
		 target.ProyectoSituacionActual= source.ProyectoSituacionActual ;
		 target.ProyectoDescripcion= source.ProyectoDescripcion ;
		 target.ProyectoObservacion= source.ProyectoObservacion ;
		 target.IdEstado= source.IdEstado ;
		 target.IdProceso= source.IdProceso ;
		 target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.SubPrioridad= source.SubPrioridad ;
		 target.EsBorrador= source.EsBorrador ;
		 target.EsProyecto= source.EsProyecto ;
		 target.NroProyecto= source.NroProyecto ;
		 target.AnioCorriente= source.AnioCorriente ;
		 target.FechaInicioEjecucionCalculada= source.FechaInicioEjecucionCalculada ;
		 target.FechaFinEjecucionCalculada= source.FechaFinEjecucionCalculada ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.EvaluarValidaciones= source.EvaluarValidaciones ;
		 target.Activo= source.Activo ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 		  
		}
		public override void Set(ProyectoResult source,Proyecto target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyecto= source.IdProyecto ;
		 target.IdTipoProyecto= source.IdTipoProyecto ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Codigo= source.Codigo ;
		 target.ProyectoDenominacion= source.ProyectoDenominacion ;
		 target.ProyectoSituacionActual= source.ProyectoSituacionActual ;
		 target.ProyectoDescripcion= source.ProyectoDescripcion ;
		 target.ProyectoObservacion= source.ProyectoObservacion ;
		 target.IdEstado= source.IdEstado ;
		 target.IdProceso= source.IdProceso ;
		 target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.SubPrioridad= source.SubPrioridad ;
		 target.EsBorrador= source.EsBorrador ;
		 target.EsProyecto= source.EsProyecto ;
		 target.NroProyecto= source.NroProyecto ;
		 target.AnioCorriente= source.AnioCorriente ;
		 target.FechaInicioEjecucionCalculada= source.FechaInicioEjecucionCalculada ;
		 target.FechaFinEjecucionCalculada= source.FechaFinEjecucionCalculada ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.EvaluarValidaciones= source.EvaluarValidaciones ;
		 target.Activo= source.Activo ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 
		}
		public override void Set(Proyecto source,ProyectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyecto= source.IdProyecto ;
		 target.IdTipoProyecto= source.IdTipoProyecto ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Codigo= source.Codigo ;
		 target.ProyectoDenominacion= source.ProyectoDenominacion ;
		 target.ProyectoSituacionActual= source.ProyectoSituacionActual ;
		 target.ProyectoDescripcion= source.ProyectoDescripcion ;
		 target.ProyectoObservacion= source.ProyectoObservacion ;
		 target.IdEstado= source.IdEstado ;
		 target.IdProceso= source.IdProceso ;
		 target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.SubPrioridad= source.SubPrioridad ;
		 target.EsBorrador= source.EsBorrador ;
		 target.EsProyecto= source.EsProyecto ;
		 target.NroProyecto= source.NroProyecto ;
		 target.AnioCorriente= source.AnioCorriente ;
		 target.FechaInicioEjecucionCalculada= source.FechaInicioEjecucionCalculada ;
		 target.FechaFinEjecucionCalculada= source.FechaFinEjecucionCalculada ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.EvaluarValidaciones= source.EvaluarValidaciones ;
		 target.Activo= source.Activo ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 	
		}		
		public override void Set(ProyectoResult source,ProyectoResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdProyecto= source.IdProyecto ;
		 target.IdTipoProyecto= source.IdTipoProyecto ;
		 target.IdSubPrograma= source.IdSubPrograma ;
		 target.Codigo= source.Codigo ;
		 target.ProyectoDenominacion= source.ProyectoDenominacion ;
		 target.ProyectoSituacionActual= source.ProyectoSituacionActual ;
		 target.ProyectoDescripcion= source.ProyectoDescripcion ;
		 target.ProyectoObservacion= source.ProyectoObservacion ;
		 target.IdEstado= source.IdEstado ;
		 target.IdProceso= source.IdProceso ;
		 target.IdModalidadContratacion= source.IdModalidadContratacion ;
		 target.IdFinalidadFuncion= source.IdFinalidadFuncion ;
		 target.IdOrganismoPrioridad= source.IdOrganismoPrioridad ;
		 target.SubPrioridad= source.SubPrioridad ;
		 target.EsBorrador= source.EsBorrador ;
		 target.EsProyecto= source.EsProyecto ;
		 target.NroProyecto= source.NroProyecto ;
		 target.AnioCorriente= source.AnioCorriente ;
		 target.FechaInicioEjecucionCalculada= source.FechaInicioEjecucionCalculada ;
		 target.FechaFinEjecucionCalculada= source.FechaFinEjecucionCalculada ;
		 target.FechaAlta= source.FechaAlta ;
		 target.FechaModificacion= source.FechaModificacion ;
		 target.IdUsuarioModificacion= source.IdUsuarioModificacion ;
		 target.IdProyectoPlan= source.IdProyectoPlan ;
		 target.EvaluarValidaciones= source.EvaluarValidaciones ;
		 target.Activo= source.Activo ;
		 target.IdEstadoDeDesicion= source.IdEstadoDeDesicion ;
		 target.Estado_Nombre= source.Estado_Nombre;	
			target.Estado_Codigo= source.Estado_Codigo;	
			target.Estado_Orden= source.Estado_Orden;	
			target.Estado_Descripcion= source.Estado_Descripcion;	
			target.Estado_Activo= source.Estado_Activo;	
			target.EstadoDeDesicion_Nombre= source.EstadoDeDesicion_Nombre;	
			target.EstadoDeDesicion_Codigo= source.EstadoDeDesicion_Codigo;	
			target.EstadoDeDesicion_Orden= source.EstadoDeDesicion_Orden;	
			target.EstadoDeDesicion_Descripcion= source.EstadoDeDesicion_Descripcion;	
			target.EstadoDeDesicion_Activo= source.EstadoDeDesicion_Activo;	
			target.FinalidadFuncion_Codigo= source.FinalidadFuncion_Codigo;	
			target.FinalidadFuncion_Denominacion= source.FinalidadFuncion_Denominacion;	
			target.FinalidadFuncion_Activo= source.FinalidadFuncion_Activo;	
			target.FinalidadFuncion_IdFinalidadFunciontipo= source.FinalidadFuncion_IdFinalidadFunciontipo;	
			target.FinalidadFuncion_IdFinalidadFuncionPadre= source.FinalidadFuncion_IdFinalidadFuncionPadre;	
			target.FinalidadFuncion_BreadcrumbId= source.FinalidadFuncion_BreadcrumbId;	
			target.FinalidadFuncion_BreadcrumbOrden= source.FinalidadFuncion_BreadcrumbOrden;	
			target.FinalidadFuncion_Nivel= source.FinalidadFuncion_Nivel;	
			target.FinalidadFuncion_Orden= source.FinalidadFuncion_Orden;	
			target.FinalidadFuncion_Descripcion= source.FinalidadFuncion_Descripcion;	
			target.FinalidadFuncion_DescripcionInvertida= source.FinalidadFuncion_DescripcionInvertida;	
			target.FinalidadFuncion_Seleccionable= source.FinalidadFuncion_Seleccionable;	
			target.FinalidadFuncion_BreadcrumbCode= source.FinalidadFuncion_BreadcrumbCode;	
			target.FinalidadFuncion_DescripcionCodigo= source.FinalidadFuncion_DescripcionCodigo;	
			target.ModalidadContratacion_Nombre= source.ModalidadContratacion_Nombre;	
			target.ModalidadContratacion_Activo= source.ModalidadContratacion_Activo;	
			target.OrganismoPrioridad_Nombre= source.OrganismoPrioridad_Nombre;	
			target.OrganismoPrioridad_Activo= source.OrganismoPrioridad_Activo;	
			target.Proceso_IdProyectoTipo= source.Proceso_IdProyectoTipo;	
			target.Proceso_Nombre= source.Proceso_Nombre;	
			target.Proceso_Activo= source.Proceso_Activo;	
			target.TipoProyecto_Sigla= source.TipoProyecto_Sigla;	
			target.TipoProyecto_Nombre= source.TipoProyecto_Nombre;	
			target.TipoProyecto_Activo= source.TipoProyecto_Activo;	
			target.TipoProyecto_Tipo= source.TipoProyecto_Tipo;	
			target.SubPrograma_IdPrograma= source.SubPrograma_IdPrograma;	
			target.SubPrograma_Codigo= source.SubPrograma_Codigo;	
			target.SubPrograma_Nombre= source.SubPrograma_Nombre;	
			target.SubPrograma_FechaAlta= source.SubPrograma_FechaAlta;	
			target.SubPrograma_FechaBaja= source.SubPrograma_FechaBaja;	
			target.SubPrograma_Activo= source.SubPrograma_Activo;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Proyecto source,Proyecto target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdTipoProyecto.Equals(target.IdTipoProyecto))return false;
		  if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if((source.ProyectoDenominacion == null)?target.ProyectoDenominacion!=null:  !( (target.ProyectoDenominacion== String.Empty && source.ProyectoDenominacion== null) || (target.ProyectoDenominacion==null && source.ProyectoDenominacion== String.Empty )) &&  !source.ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.ProyectoDenominacion.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoSituacionActual == null)?target.ProyectoSituacionActual!=null:  !( (target.ProyectoSituacionActual== String.Empty && source.ProyectoSituacionActual== null) || (target.ProyectoSituacionActual==null && source.ProyectoSituacionActual== String.Empty )) &&  !source.ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoDescripcion == null)?target.ProyectoDescripcion!=null:  !( (target.ProyectoDescripcion== String.Empty && source.ProyectoDescripcion== null) || (target.ProyectoDescripcion==null && source.ProyectoDescripcion== String.Empty )) &&  !source.ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.ProyectoDescripcion.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoObservacion == null)?target.ProyectoObservacion!=null:  !( (target.ProyectoObservacion== String.Empty && source.ProyectoObservacion== null) || (target.ProyectoObservacion==null && source.ProyectoObservacion== String.Empty )) &&  !source.ProyectoObservacion.Trim().Replace ("\r","").Equals(target.ProyectoObservacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						  if((source.IdModalidadContratacion == null)?(target.IdModalidadContratacion.HasValue && target.IdModalidadContratacion.Value > 0):!source.IdModalidadContratacion.Equals(target.IdModalidadContratacion))return false;
						  if((source.IdFinalidadFuncion == null)?(target.IdFinalidadFuncion.HasValue && target.IdFinalidadFuncion.Value > 0):!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
						  if((source.IdOrganismoPrioridad == null)?(target.IdOrganismoPrioridad.HasValue && target.IdOrganismoPrioridad.Value > 0):!source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad))return false;
						  if((source.SubPrioridad == null)?(target.SubPrioridad.HasValue):!source.SubPrioridad.Equals(target.SubPrioridad))return false;
			 if(!source.EsBorrador.Equals(target.EsBorrador))return false;
		  if((source.EsProyecto == null)?(target.EsProyecto.HasValue):!source.EsProyecto.Equals(target.EsProyecto))return false;
			 if((source.NroProyecto == null)?(target.NroProyecto.HasValue):!source.NroProyecto.Equals(target.NroProyecto))return false;
			 if((source.AnioCorriente == null)?(target.AnioCorriente.HasValue):!source.AnioCorriente.Equals(target.AnioCorriente))return false;
			 if((source.FechaInicioEjecucionCalculada == null)?(target.FechaInicioEjecucionCalculada.HasValue):!source.FechaInicioEjecucionCalculada.Equals(target.FechaInicioEjecucionCalculada))return false;
			 if((source.FechaFinEjecucionCalculada == null)?(target.FechaFinEjecucionCalculada.HasValue):!source.FechaFinEjecucionCalculada.Equals(target.FechaFinEjecucionCalculada))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion))return false;
		  if((source.IdProyectoPlan == null)?(target.IdProyectoPlan.HasValue):!source.IdProyectoPlan.Equals(target.IdProyectoPlan))return false;
			 if(!source.EvaluarValidaciones.Equals(target.EvaluarValidaciones))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdEstadoDeDesicion == null)?(target.IdEstadoDeDesicion.HasValue && target.IdEstadoDeDesicion.Value > 0):!source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion))return false;
						 
		  return true;
        }
		public override bool Equals(ProyectoResult source,ProyectoResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdProyecto.Equals(target.IdProyecto))return false;
		  if(!source.IdTipoProyecto.Equals(target.IdTipoProyecto))return false;
		  if(!source.IdSubPrograma.Equals(target.IdSubPrograma))return false;
		  if(!source.Codigo.Equals(target.Codigo))return false;
		  if((source.ProyectoDenominacion == null)?target.ProyectoDenominacion!=null: !( (target.ProyectoDenominacion== String.Empty && source.ProyectoDenominacion== null) || (target.ProyectoDenominacion==null && source.ProyectoDenominacion== String.Empty )) && !source.ProyectoDenominacion.Trim().Replace ("\r","").Equals(target.ProyectoDenominacion.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoSituacionActual == null)?target.ProyectoSituacionActual!=null: !( (target.ProyectoSituacionActual== String.Empty && source.ProyectoSituacionActual== null) || (target.ProyectoSituacionActual==null && source.ProyectoSituacionActual== String.Empty )) && !source.ProyectoSituacionActual.Trim().Replace ("\r","").Equals(target.ProyectoSituacionActual.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoDescripcion == null)?target.ProyectoDescripcion!=null: !( (target.ProyectoDescripcion== String.Empty && source.ProyectoDescripcion== null) || (target.ProyectoDescripcion==null && source.ProyectoDescripcion== String.Empty )) && !source.ProyectoDescripcion.Trim().Replace ("\r","").Equals(target.ProyectoDescripcion.Trim().Replace ("\r","")))return false;
			 if((source.ProyectoObservacion == null)?target.ProyectoObservacion!=null: !( (target.ProyectoObservacion== String.Empty && source.ProyectoObservacion== null) || (target.ProyectoObservacion==null && source.ProyectoObservacion== String.Empty )) && !source.ProyectoObservacion.Trim().Replace ("\r","").Equals(target.ProyectoObservacion.Trim().Replace ("\r","")))return false;
			 if(!source.IdEstado.Equals(target.IdEstado))return false;
		  if((source.IdProceso == null)?(target.IdProceso.HasValue && target.IdProceso.Value > 0):!source.IdProceso.Equals(target.IdProceso))return false;
						  if((source.IdModalidadContratacion == null)?(target.IdModalidadContratacion.HasValue && target.IdModalidadContratacion.Value > 0):!source.IdModalidadContratacion.Equals(target.IdModalidadContratacion))return false;
						  if((source.IdFinalidadFuncion == null)?(target.IdFinalidadFuncion.HasValue && target.IdFinalidadFuncion.Value > 0):!source.IdFinalidadFuncion.Equals(target.IdFinalidadFuncion))return false;
						  if((source.IdOrganismoPrioridad == null)?(target.IdOrganismoPrioridad.HasValue && target.IdOrganismoPrioridad.Value > 0):!source.IdOrganismoPrioridad.Equals(target.IdOrganismoPrioridad))return false;
						  if((source.SubPrioridad == null)?(target.SubPrioridad.HasValue):!source.SubPrioridad.Equals(target.SubPrioridad))return false;
			 if(!source.EsBorrador.Equals(target.EsBorrador))return false;
		  if((source.EsProyecto == null)?(target.EsProyecto.HasValue):!source.EsProyecto.Equals(target.EsProyecto))return false;
			 if((source.NroProyecto == null)?(target.NroProyecto.HasValue):!source.NroProyecto.Equals(target.NroProyecto))return false;
			 if((source.AnioCorriente == null)?(target.AnioCorriente.HasValue):!source.AnioCorriente.Equals(target.AnioCorriente))return false;
			 if((source.FechaInicioEjecucionCalculada == null)?(target.FechaInicioEjecucionCalculada.HasValue):!source.FechaInicioEjecucionCalculada.Equals(target.FechaInicioEjecucionCalculada))return false;
			 if((source.FechaFinEjecucionCalculada == null)?(target.FechaFinEjecucionCalculada.HasValue):!source.FechaFinEjecucionCalculada.Equals(target.FechaFinEjecucionCalculada))return false;
			 if(!source.FechaAlta.Equals(target.FechaAlta))return false;
		  if(!source.FechaModificacion.Equals(target.FechaModificacion))return false;
		  if(!source.IdUsuarioModificacion.Equals(target.IdUsuarioModificacion))return false;
		  if((source.IdProyectoPlan == null)?(target.IdProyectoPlan.HasValue):!source.IdProyectoPlan.Equals(target.IdProyectoPlan))return false;
			 if(!source.EvaluarValidaciones.Equals(target.EvaluarValidaciones))return false;
		  if(!source.Activo.Equals(target.Activo))return false;
		  if((source.IdEstadoDeDesicion == null)?(target.IdEstadoDeDesicion.HasValue && target.IdEstadoDeDesicion.Value > 0):!source.IdEstadoDeDesicion.Equals(target.IdEstadoDeDesicion))return false;
						  if((source.Estado_Nombre == null)?target.Estado_Nombre!=null: !( (target.Estado_Nombre== String.Empty && source.Estado_Nombre== null) || (target.Estado_Nombre==null && source.Estado_Nombre== String.Empty )) &&   !source.Estado_Nombre.Trim().Replace ("\r","").Equals(target.Estado_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.Estado_Codigo == null)?target.Estado_Codigo!=null: !( (target.Estado_Codigo== String.Empty && source.Estado_Codigo== null) || (target.Estado_Codigo==null && source.Estado_Codigo== String.Empty )) &&   !source.Estado_Codigo.Trim().Replace ("\r","").Equals(target.Estado_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Orden.Equals(target.Estado_Orden))return false;
					  if((source.Estado_Descripcion == null)?target.Estado_Descripcion!=null: !( (target.Estado_Descripcion== String.Empty && source.Estado_Descripcion== null) || (target.Estado_Descripcion==null && source.Estado_Descripcion== String.Empty )) &&   !source.Estado_Descripcion.Trim().Replace ("\r","").Equals(target.Estado_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.Estado_Activo.Equals(target.Estado_Activo))return false;
					  if((source.EstadoDeDesicion_Nombre == null)?target.EstadoDeDesicion_Nombre!=null: !( (target.EstadoDeDesicion_Nombre== String.Empty && source.EstadoDeDesicion_Nombre== null) || (target.EstadoDeDesicion_Nombre==null && source.EstadoDeDesicion_Nombre== String.Empty )) &&   !source.EstadoDeDesicion_Nombre.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Nombre.Trim().Replace ("\r","")))return false;
						 if((source.EstadoDeDesicion_Codigo == null)?target.EstadoDeDesicion_Codigo!=null: !( (target.EstadoDeDesicion_Codigo== String.Empty && source.EstadoDeDesicion_Codigo== null) || (target.EstadoDeDesicion_Codigo==null && source.EstadoDeDesicion_Codigo== String.Empty )) &&   !source.EstadoDeDesicion_Codigo.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Codigo.Trim().Replace ("\r","")))return false;
						 if(!source.EstadoDeDesicion_Orden.Equals(target.EstadoDeDesicion_Orden))return false;
					  if((source.EstadoDeDesicion_Descripcion == null)?target.EstadoDeDesicion_Descripcion!=null: !( (target.EstadoDeDesicion_Descripcion== String.Empty && source.EstadoDeDesicion_Descripcion== null) || (target.EstadoDeDesicion_Descripcion==null && source.EstadoDeDesicion_Descripcion== String.Empty )) &&   !source.EstadoDeDesicion_Descripcion.Trim().Replace ("\r","").Equals(target.EstadoDeDesicion_Descripcion.Trim().Replace ("\r","")))return false;
						 if(!source.EstadoDeDesicion_Activo.Equals(target.EstadoDeDesicion_Activo))return false;
					  if((source.FinalidadFuncion_Codigo == null)?target.FinalidadFuncion_Codigo!=null: !( (target.FinalidadFuncion_Codigo== String.Empty && source.FinalidadFuncion_Codigo== null) || (target.FinalidadFuncion_Codigo==null && source.FinalidadFuncion_Codigo== String.Empty )) &&   !source.FinalidadFuncion_Codigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_Denominacion == null)?target.FinalidadFuncion_Denominacion!=null: !( (target.FinalidadFuncion_Denominacion== String.Empty && source.FinalidadFuncion_Denominacion== null) || (target.FinalidadFuncion_Denominacion==null && source.FinalidadFuncion_Denominacion== String.Empty )) &&   !source.FinalidadFuncion_Denominacion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Denominacion.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncion_Activo.Equals(target.FinalidadFuncion_Activo))return false;
					  if((source.FinalidadFuncion_IdFinalidadFunciontipo == null)?(target.FinalidadFuncion_IdFinalidadFunciontipo.HasValue && target.FinalidadFuncion_IdFinalidadFunciontipo.Value > 0):!source.FinalidadFuncion_IdFinalidadFunciontipo.Equals(target.FinalidadFuncion_IdFinalidadFunciontipo))return false;
									  if((source.FinalidadFuncion_IdFinalidadFuncionPadre == null)?(target.FinalidadFuncion_IdFinalidadFuncionPadre.HasValue && target.FinalidadFuncion_IdFinalidadFuncionPadre.Value > 0):!source.FinalidadFuncion_IdFinalidadFuncionPadre.Equals(target.FinalidadFuncion_IdFinalidadFuncionPadre))return false;
									  if((source.FinalidadFuncion_BreadcrumbId == null)?target.FinalidadFuncion_BreadcrumbId!=null: !( (target.FinalidadFuncion_BreadcrumbId== String.Empty && source.FinalidadFuncion_BreadcrumbId== null) || (target.FinalidadFuncion_BreadcrumbId==null && source.FinalidadFuncion_BreadcrumbId== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbId.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_BreadcrumbOrden == null)?target.FinalidadFuncion_BreadcrumbOrden!=null: !( (target.FinalidadFuncion_BreadcrumbOrden== String.Empty && source.FinalidadFuncion_BreadcrumbOrden== null) || (target.FinalidadFuncion_BreadcrumbOrden==null && source.FinalidadFuncion_BreadcrumbOrden== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbOrden.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_Nivel == null)?(target.FinalidadFuncion_Nivel.HasValue ):!source.FinalidadFuncion_Nivel.Equals(target.FinalidadFuncion_Nivel))return false;
						 if((source.FinalidadFuncion_Orden == null)?(target.FinalidadFuncion_Orden.HasValue ):!source.FinalidadFuncion_Orden.Equals(target.FinalidadFuncion_Orden))return false;
						 if((source.FinalidadFuncion_Descripcion == null)?target.FinalidadFuncion_Descripcion!=null: !( (target.FinalidadFuncion_Descripcion== String.Empty && source.FinalidadFuncion_Descripcion== null) || (target.FinalidadFuncion_Descripcion==null && source.FinalidadFuncion_Descripcion== String.Empty )) &&   !source.FinalidadFuncion_Descripcion.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_Descripcion.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_DescripcionInvertida == null)?target.FinalidadFuncion_DescripcionInvertida!=null: !( (target.FinalidadFuncion_DescripcionInvertida== String.Empty && source.FinalidadFuncion_DescripcionInvertida== null) || (target.FinalidadFuncion_DescripcionInvertida==null && source.FinalidadFuncion_DescripcionInvertida== String.Empty )) &&   !source.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionInvertida.Trim().Replace ("\r","")))return false;
						 if(!source.FinalidadFuncion_Seleccionable.Equals(target.FinalidadFuncion_Seleccionable))return false;
					  if((source.FinalidadFuncion_BreadcrumbCode == null)?target.FinalidadFuncion_BreadcrumbCode!=null: !( (target.FinalidadFuncion_BreadcrumbCode== String.Empty && source.FinalidadFuncion_BreadcrumbCode== null) || (target.FinalidadFuncion_BreadcrumbCode==null && source.FinalidadFuncion_BreadcrumbCode== String.Empty )) &&   !source.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_BreadcrumbCode.Trim().Replace ("\r","")))return false;
						 if((source.FinalidadFuncion_DescripcionCodigo == null)?target.FinalidadFuncion_DescripcionCodigo!=null: !( (target.FinalidadFuncion_DescripcionCodigo== String.Empty && source.FinalidadFuncion_DescripcionCodigo== null) || (target.FinalidadFuncion_DescripcionCodigo==null && source.FinalidadFuncion_DescripcionCodigo== String.Empty )) &&   !source.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","").Equals(target.FinalidadFuncion_DescripcionCodigo.Trim().Replace ("\r","")))return false;
						 if((source.ModalidadContratacion_Nombre == null)?target.ModalidadContratacion_Nombre!=null: !( (target.ModalidadContratacion_Nombre== String.Empty && source.ModalidadContratacion_Nombre== null) || (target.ModalidadContratacion_Nombre==null && source.ModalidadContratacion_Nombre== String.Empty )) &&   !source.ModalidadContratacion_Nombre.Trim().Replace ("\r","").Equals(target.ModalidadContratacion_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.ModalidadContratacion_Activo.Equals(target.ModalidadContratacion_Activo))return false;
					  if((source.OrganismoPrioridad_Nombre == null)?target.OrganismoPrioridad_Nombre!=null: !( (target.OrganismoPrioridad_Nombre== String.Empty && source.OrganismoPrioridad_Nombre== null) || (target.OrganismoPrioridad_Nombre==null && source.OrganismoPrioridad_Nombre== String.Empty )) &&   !source.OrganismoPrioridad_Nombre.Trim().Replace ("\r","").Equals(target.OrganismoPrioridad_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.OrganismoPrioridad_Activo.Equals(target.OrganismoPrioridad_Activo))return false;
					  if(!source.Proceso_IdProyectoTipo.Equals(target.Proceso_IdProyectoTipo))return false;
					  if((source.Proceso_Nombre == null)?target.Proceso_Nombre!=null: !( (target.Proceso_Nombre== String.Empty && source.Proceso_Nombre== null) || (target.Proceso_Nombre==null && source.Proceso_Nombre== String.Empty )) &&   !source.Proceso_Nombre.Trim().Replace ("\r","").Equals(target.Proceso_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.Proceso_Activo.Equals(target.Proceso_Activo))return false;
					  if((source.TipoProyecto_Sigla == null)?target.TipoProyecto_Sigla!=null: !( (target.TipoProyecto_Sigla== String.Empty && source.TipoProyecto_Sigla== null) || (target.TipoProyecto_Sigla==null && source.TipoProyecto_Sigla== String.Empty )) &&   !source.TipoProyecto_Sigla.Trim().Replace ("\r","").Equals(target.TipoProyecto_Sigla.Trim().Replace ("\r","")))return false;
						 if((source.TipoProyecto_Nombre == null)?target.TipoProyecto_Nombre!=null: !( (target.TipoProyecto_Nombre== String.Empty && source.TipoProyecto_Nombre== null) || (target.TipoProyecto_Nombre==null && source.TipoProyecto_Nombre== String.Empty )) &&   !source.TipoProyecto_Nombre.Trim().Replace ("\r","").Equals(target.TipoProyecto_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.TipoProyecto_Activo.Equals(target.TipoProyecto_Activo))return false;
					  if((source.TipoProyecto_Tipo == null)?target.TipoProyecto_Tipo!=null: !( (target.TipoProyecto_Tipo== String.Empty && source.TipoProyecto_Tipo== null) || (target.TipoProyecto_Tipo==null && source.TipoProyecto_Tipo== String.Empty )) &&   !source.TipoProyecto_Tipo.Trim().Replace ("\r","").Equals(target.TipoProyecto_Tipo.Trim().Replace ("\r","")))return false;
						 if(!source.SubPrograma_IdPrograma.Equals(target.SubPrograma_IdPrograma))return false;
					  if((source.SubPrograma_Codigo == null)?target.SubPrograma_Codigo!=null: !( (target.SubPrograma_Codigo== String.Empty && source.SubPrograma_Codigo== null) || (target.SubPrograma_Codigo==null && source.SubPrograma_Codigo== String.Empty )) &&   !source.SubPrograma_Codigo.Trim().Replace ("\r","").Equals(target.SubPrograma_Codigo.Trim().Replace ("\r","")))return false;
						 if((source.SubPrograma_Nombre == null)?target.SubPrograma_Nombre!=null: !( (target.SubPrograma_Nombre== String.Empty && source.SubPrograma_Nombre== null) || (target.SubPrograma_Nombre==null && source.SubPrograma_Nombre== String.Empty )) &&   !source.SubPrograma_Nombre.Trim().Replace ("\r","").Equals(target.SubPrograma_Nombre.Trim().Replace ("\r","")))return false;
						 if(!source.SubPrograma_FechaAlta.Equals(target.SubPrograma_FechaAlta))return false;
					  if((source.SubPrograma_FechaBaja == null)?(target.SubPrograma_FechaBaja.HasValue ):!source.SubPrograma_FechaBaja.Equals(target.SubPrograma_FechaBaja))return false;
						 if(!source.SubPrograma_Activo.Equals(target.SubPrograma_Activo))return false;
					 		
		  return true;
        }
		#endregion
    }
}
