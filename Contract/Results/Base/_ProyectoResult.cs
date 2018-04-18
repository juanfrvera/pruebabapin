using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyecto;}}
		 public int IdProyecto{get;set;}
		 public int IdTipoProyecto{get;set;}
		 public int IdSubPrograma{get;set;}
		 public int Codigo{get;set;}
		 public string ProyectoDenominacion{get;set;}
		 public string ProyectoSituacionActual{get;set;}
		 public string ProyectoDescripcion{get;set;}
		 public string ProyectoObservacion{get;set;}
		 public int IdEstado{get;set;}
		 public int? IdProceso{get;set;}
		 public int? IdModalidadContratacion{get;set;}
		 public int? IdFinalidadFuncion{get;set;}
		 public int? IdOrganismoPrioridad{get;set;}
		 public int? SubPrioridad{get;set;}
		 public bool EsBorrador{get;set;}
		 public bool? EsProyecto{get;set;}
		 public int? NroProyecto{get;set;}
		 public int? AnioCorriente{get;set;}
         public int? AnioCorrienteEstimado { get; set; }
         public int? AnioCorrienteRealizado { get; set; }
		 public DateTime? FechaInicioEjecucionCalculada{get;set;}
		 public DateTime? FechaFinEjecucionCalculada{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime FechaModificacion{get;set;}
		 public int IdUsuarioModificacion{get;set;}
		 public int? IdProyectoPlan{get;set;}
		 public bool EvaluarValidaciones{get;set;}
		 public bool Activo{get;set;}
		 public int? IdEstadoDeDesicion{get;set;}
         public bool? EsPPP { get; set; }
         public int? NroActividad { get; set; }
         public int? NroObra { get; set; }
         public int? NroProyectoEjecucion { get; set; }
         public int? NroActividadEjecucion { get; set; }
         public int? NroObraEjecucion { get; set; }
         public int? IdSubProgramaEjecucion { get; set; }

		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public string EstadoDeDesicion_Nombre{get;set;}	
	public string EstadoDeDesicion_Codigo{get;set;}	
	public int? EstadoDeDesicion_Orden{get;set;}	
	public string EstadoDeDesicion_Descripcion{get;set;}	
	public bool? EstadoDeDesicion_Activo{get;set;}	
	public string FinalidadFuncion_Codigo{get;set;}	
	public string FinalidadFuncion_Denominacion{get;set;}	
	public bool? FinalidadFuncion_Activo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFunciontipo{get;set;}	
	public int? FinalidadFuncion_IdFinalidadFuncionPadre{get;set;}	
	public string FinalidadFuncion_BreadcrumbId{get;set;}	
	public string FinalidadFuncion_BreadcrumbOrden{get;set;}	
	public int? FinalidadFuncion_Nivel{get;set;}	
	public int? FinalidadFuncion_Orden{get;set;}	
	public string FinalidadFuncion_Descripcion{get;set;}	
	public string FinalidadFuncion_DescripcionInvertida{get;set;}	
	public bool? FinalidadFuncion_Seleccionable{get;set;}	
	public string FinalidadFuncion_BreadcrumbCode{get;set;}	
	public string FinalidadFuncion_DescripcionCodigo{get;set;}	
	public string ModalidadContratacion_Nombre{get;set;}	
	public bool? ModalidadContratacion_Activo{get;set;}	
	public string OrganismoPrioridad_Nombre{get;set;}	
	public bool? OrganismoPrioridad_Activo{get;set;}	
	public int? Proceso_IdProyectoTipo{get;set;}	
	public string Proceso_Nombre{get;set;}	
	public bool? Proceso_Activo{get;set;}	
	public string TipoProyecto_Sigla{get;set;}	
	public string TipoProyecto_Nombre{get;set;}	
	public bool TipoProyecto_Activo{get;set;}	
	public string TipoProyecto_Tipo{get;set;}	
	public int SubPrograma_IdPrograma{get;set;}	
	public string SubPrograma_Codigo{get;set;}	
	public string SubPrograma_Nombre{get;set;}	
	public DateTime SubPrograma_FechaAlta{get;set;}	
	public DateTime? SubPrograma_FechaBaja{get;set;}	
	public bool SubPrograma_Activo{get;set;}	
					
		public virtual Proyecto ToEntity()
		{
		   Proyecto _Proyecto = new Proyecto();
		_Proyecto.IdProyecto = this.IdProyecto;
		 _Proyecto.IdTipoProyecto = this.IdTipoProyecto;
		 _Proyecto.IdSubPrograma = this.IdSubPrograma;
		 _Proyecto.Codigo = this.Codigo;
		 _Proyecto.ProyectoDenominacion = this.ProyectoDenominacion;
		 _Proyecto.ProyectoSituacionActual = this.ProyectoSituacionActual;
		 _Proyecto.ProyectoDescripcion = this.ProyectoDescripcion;
		 _Proyecto.ProyectoObservacion = this.ProyectoObservacion;
		 _Proyecto.IdEstado = this.IdEstado;
		 _Proyecto.IdProceso = this.IdProceso;
		 _Proyecto.IdModalidadContratacion = this.IdModalidadContratacion;
		 _Proyecto.IdFinalidadFuncion = this.IdFinalidadFuncion;
		 _Proyecto.IdOrganismoPrioridad = this.IdOrganismoPrioridad;
		 _Proyecto.SubPrioridad = this.SubPrioridad;
		 _Proyecto.EsBorrador = this.EsBorrador;
		 _Proyecto.EsProyecto = this.EsProyecto;
		 _Proyecto.NroProyecto = this.NroProyecto;
		 _Proyecto.AnioCorriente = this.AnioCorriente;
         _Proyecto.AnioCorrienteEstimado = this.AnioCorrienteEstimado;
         _Proyecto.AnioCorrienteRealizado = this.AnioCorrienteRealizado;
		 _Proyecto.FechaInicioEjecucionCalculada = this.FechaInicioEjecucionCalculada;
		 _Proyecto.FechaFinEjecucionCalculada = this.FechaFinEjecucionCalculada;
		 _Proyecto.FechaAlta = this.FechaAlta;
		 _Proyecto.FechaModificacion = this.FechaModificacion;
		 _Proyecto.IdUsuarioModificacion = this.IdUsuarioModificacion;
		 _Proyecto.IdProyectoPlan = this.IdProyectoPlan;
		 _Proyecto.EvaluarValidaciones = this.EvaluarValidaciones;
		 _Proyecto.Activo = this.Activo;
		 _Proyecto.IdEstadoDeDesicion = this.IdEstadoDeDesicion;
         _Proyecto.EsPPP = this.EsPPP;
         _Proyecto.NroActividad = this.NroActividad;
         _Proyecto.NroObra = this.NroObra;
         _Proyecto.NroProyectoEjecucion = this.NroProyectoEjecucion;
         _Proyecto.NroActividadEjecucion = this.NroActividadEjecucion;
         _Proyecto.NroObraEjecucion = this.NroObraEjecucion;
         _Proyecto.IdSubProgramaEjecucion = this.IdSubProgramaEjecucion;

		  return _Proyecto;
		}		
		public virtual void Set(Proyecto entity)
		{		   
		 this.IdProyecto= entity.IdProyecto ;
		  this.IdTipoProyecto= entity.IdTipoProyecto ;
		  this.IdSubPrograma= entity.IdSubPrograma ;
		  this.Codigo= entity.Codigo ;
		  this.ProyectoDenominacion= entity.ProyectoDenominacion ;
		  this.ProyectoSituacionActual= entity.ProyectoSituacionActual ;
		  this.ProyectoDescripcion= entity.ProyectoDescripcion ;
		  this.ProyectoObservacion= entity.ProyectoObservacion ;
		  this.IdEstado= entity.IdEstado ;
		  this.IdProceso= entity.IdProceso ;
		  this.IdModalidadContratacion= entity.IdModalidadContratacion ;
		  this.IdFinalidadFuncion= entity.IdFinalidadFuncion ;
		  this.IdOrganismoPrioridad= entity.IdOrganismoPrioridad ;
		  this.SubPrioridad= entity.SubPrioridad ;
		  this.EsBorrador= entity.EsBorrador ;
		  this.EsProyecto= entity.EsProyecto ;
		  this.NroProyecto= entity.NroProyecto ;
		  this.AnioCorriente= entity.AnioCorriente ;
          this.AnioCorrienteEstimado = entity.AnioCorrienteEstimado;
          this.AnioCorrienteRealizado = entity.AnioCorrienteRealizado;
		  this.FechaInicioEjecucionCalculada= entity.FechaInicioEjecucionCalculada ;
		  this.FechaFinEjecucionCalculada= entity.FechaFinEjecucionCalculada ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaModificacion= entity.FechaModificacion ;
		  this.IdUsuarioModificacion= entity.IdUsuarioModificacion ;
		  this.IdProyectoPlan= entity.IdProyectoPlan ;
		  this.EvaluarValidaciones= entity.EvaluarValidaciones ;
		  this.Activo= entity.Activo ;
		  this.IdEstadoDeDesicion= entity.IdEstadoDeDesicion ;
          this.EsPPP = entity.EsPPP;
          this.NroActividad = entity.NroActividad;
          this.NroObra = entity.NroObra;
          this.NroProyectoEjecucion = entity.NroProyectoEjecucion;
          this.NroActividadEjecucion = entity.NroActividadEjecucion;
          this.NroObraEjecucion = entity.NroObraEjecucion;
          this.IdSubProgramaEjecucion = entity.IdSubProgramaEjecucion;
		}		
		public virtual bool Equals(Proyecto entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdTipoProyecto.Equals(this.IdTipoProyecto))return false;
		  if(!entity.IdSubPrograma.Equals(this.IdSubPrograma))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.ProyectoDenominacion.Equals(this.ProyectoDenominacion))return false;
		  if((entity.ProyectoSituacionActual == null)?this.ProyectoSituacionActual!=null:!entity.ProyectoSituacionActual.Equals(this.ProyectoSituacionActual))return false;
			 if((entity.ProyectoDescripcion == null)?this.ProyectoDescripcion!=null:!entity.ProyectoDescripcion.Equals(this.ProyectoDescripcion))return false;
			 if((entity.ProyectoObservacion == null)?this.ProyectoObservacion!=null:!entity.ProyectoObservacion.Equals(this.ProyectoObservacion))return false;
			 if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if((entity.IdProceso == null)?(this.IdProceso.HasValue && this.IdProceso.Value > 0):!entity.IdProceso.Equals(this.IdProceso))return false;
						  if((entity.IdModalidadContratacion == null)?(this.IdModalidadContratacion.HasValue && this.IdModalidadContratacion.Value > 0):!entity.IdModalidadContratacion.Equals(this.IdModalidadContratacion))return false;
						  if((entity.IdFinalidadFuncion == null)?(this.IdFinalidadFuncion.HasValue && this.IdFinalidadFuncion.Value > 0):!entity.IdFinalidadFuncion.Equals(this.IdFinalidadFuncion))return false;
						  if((entity.IdOrganismoPrioridad == null)?(this.IdOrganismoPrioridad.HasValue && this.IdOrganismoPrioridad.Value > 0):!entity.IdOrganismoPrioridad.Equals(this.IdOrganismoPrioridad))return false;
						  if((entity.SubPrioridad == null)?this.SubPrioridad!=null:!entity.SubPrioridad.Equals(this.SubPrioridad))return false;
			 if(!entity.EsBorrador.Equals(this.EsBorrador))return false;
		  if((entity.EsProyecto == null)?this.EsProyecto!=null:!entity.EsProyecto.Equals(this.EsProyecto))return false;
			 if((entity.NroProyecto == null)?this.NroProyecto!=null:!entity.NroProyecto.Equals(this.NroProyecto))return false;
			 if((entity.AnioCorriente == null)?this.AnioCorriente!=null:!entity.AnioCorriente.Equals(this.AnioCorriente))return false;
             if ((entity.AnioCorrienteEstimado == null) ? this.AnioCorrienteEstimado != null : !entity.AnioCorrienteEstimado.Equals(this.AnioCorrienteEstimado)) return false;
             if ((entity.AnioCorrienteRealizado == null) ? this.AnioCorrienteRealizado != null : !entity.AnioCorrienteRealizado.Equals(this.AnioCorrienteRealizado)) return false;
			 if((entity.FechaInicioEjecucionCalculada == null)?this.FechaInicioEjecucionCalculada!=null:!entity.FechaInicioEjecucionCalculada.Equals(this.FechaInicioEjecucionCalculada))return false;
			 if((entity.FechaFinEjecucionCalculada == null)?this.FechaFinEjecucionCalculada!=null:!entity.FechaFinEjecucionCalculada.Equals(this.FechaFinEjecucionCalculada))return false;
			 if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if(!entity.FechaModificacion.Equals(this.FechaModificacion))return false;
		  if(!entity.IdUsuarioModificacion.Equals(this.IdUsuarioModificacion))return false;
		  if((entity.IdProyectoPlan == null)?this.IdProyectoPlan!=null:!entity.IdProyectoPlan.Equals(this.IdProyectoPlan))return false;
			 if(!entity.EvaluarValidaciones.Equals(this.EvaluarValidaciones))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdEstadoDeDesicion == null)?(this.IdEstadoDeDesicion.HasValue && this.IdEstadoDeDesicion.Value > 0):!entity.IdEstadoDeDesicion.Equals(this.IdEstadoDeDesicion))return false;
          if ((entity.EsPPP == null) ? this.EsPPP != null : !entity.EsPPP.Equals(this.EsPPP)) return false;
          if ((entity.NroActividad == null) ? this.NroActividad != null : !entity.NroActividad.Equals(this.NroActividad)) return false;
          if ((entity.NroObra == null) ? this.NroObra != null : !entity.NroObra.Equals(this.NroObra)) return false;
          if ((entity.NroProyectoEjecucion == null) ? this.NroProyectoEjecucion != null : !entity.NroProyectoEjecucion.Equals(this.NroProyectoEjecucion)) return false;
          if ((entity.NroActividadEjecucion == null) ? this.NroActividadEjecucion != null : !entity.NroActividadEjecucion.Equals(this.NroActividadEjecucion)) return false;
          if ((entity.NroObraEjecucion == null) ? this.NroObraEjecucion != null : !entity.NroObraEjecucion.Equals(this.NroObraEjecucion)) return false;
          if ((entity.IdSubProgramaEjecucion == null) ? this.IdSubProgramaEjecucion != null : !entity.IdSubProgramaEjecucion.Equals(this.IdSubProgramaEjecucion)) return false;
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Proyecto", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("TipoProyecto","ProyectoTipo_Nombre")
			,new DataColumnMapping("SubPrograma","SubPrograma_Nombre")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("ProyectoDenominacion","ProyectoDenominacion")
			,new DataColumnMapping("ProyectoSituacionActual","ProyectoSituacionActual")
			,new DataColumnMapping("ProyectoDescripcion","ProyectoDescripcion")
			,new DataColumnMapping("ProyectoObservacion","ProyectoObservacion")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("Proceso","Proceso_Nombre")
			,new DataColumnMapping("ModalidadContratacion","ModalidadContratacion_Nombre")
			,new DataColumnMapping("FinalidadFuncion","FinalidadFuncion_Descripcion")
			,new DataColumnMapping("OrganismoPrioridad","OrganismoPrioridad_Nombre")
			,new DataColumnMapping("SubPrioridad","SubPrioridad")
			,new DataColumnMapping("EsBorrador","EsBorrador")
			,new DataColumnMapping("EsProyecto","EsProyecto")
			,new DataColumnMapping("NroProyecto","NroProyecto")
			,new DataColumnMapping("AnioCorriente","AnioCorriente")
            ,new DataColumnMapping("AnioCorrienteEstimado","AnioCorrienteEstimado")
            ,new DataColumnMapping("AnioCorrienteRealizado","AnioCorrienteRealizado")
			,new DataColumnMapping("FechaInicioEjecucionCalculada","FechaInicioEjecucionCalculada","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaFinEjecucionCalculada","FechaFinEjecucionCalculada","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaModificacion","FechaModificacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioModificacion","IdUsuarioModificacion")
			,new DataColumnMapping("ProyectoPlan","IdProyectoPlan")
			,new DataColumnMapping("EvaluarValidaciones","EvaluarValidaciones")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("EstadoDeDesicion","EstadoDeDesicion_Nombre")
            ,new DataColumnMapping("EsPPP","EsPPP")
            ,new DataColumnMapping("NroActividad","NroActividad")
            ,new DataColumnMapping("NroObra","NroObra")
            ,new DataColumnMapping("NroProyectoEjecucion","NroProyectoEjecucion")
            ,new DataColumnMapping("NroActividadEjecucion","NroActividadEjecucion")
            ,new DataColumnMapping("NroObraEjecucion","NroObraEjecucion")
            ,new DataColumnMapping("IdSubProgramaEjecucion","IdSubProgramaEjecucion")
			}));
		}
	}
}
		