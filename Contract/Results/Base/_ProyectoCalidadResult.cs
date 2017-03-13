using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoCalidadResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoCalidad;}}
		 public int IdProyectoCalidad{get;set;}
		 public int IdProyecto{get;set;}
		 public bool DenominacionOK{get;set;}
		 public string DenominacionSugerida{get;set;}
		 public string DenominacionOriginal{get;set;}
		 public bool ProyectoTipoOk{get;set;}
		 public int? IdProyectoTipo{get;set;}
		 public int? EstadoOK{get;set;}
		 public int? IdEstadoSugerido{get;set;}
		 public bool ProcesoOk{get;set;}
		 public int? IdProceso{get;set;}
		 public bool FinalidadFuncionOk{get;set;}
		 public int? IdClasificacionFuncional{get;set;}
		 public bool ReqDictamen{get;set;}
		 public string Comenatrio{get;set;}
		 public int IdEstado{get;set;}
		 public DateTime? FechaEstado{get;set;}
		 public bool LocalizacionOK{get;set;}
		 
		 public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool Estado_Activo{get;set;}	
	public string ClasificacionFuncional_Codigo{get;set;}	
	public string ClasificacionFuncional_Denominacion{get;set;}	
	public bool? ClasificacionFuncional_Activo{get;set;}	
	public int? ClasificacionFuncional_IdFinalidadFunciontipo{get;set;}	
	public int? ClasificacionFuncional_IdFinalidadFuncionPadre{get;set;}	
	public string ClasificacionFuncional_BreadcrumbId{get;set;}	
	public string ClasificacionFuncional_BreadcrumbOrden{get;set;}	
	public int? ClasificacionFuncional_Nivel{get;set;}	
	public int? ClasificacionFuncional_Orden{get;set;}	
	public string ClasificacionFuncional_Descripcion{get;set;}	
	public string ClasificacionFuncional_DescripcionInvertida{get;set;}	
	public bool? ClasificacionFuncional_Seleccionable{get;set;}	
	public string ClasificacionFuncional_BreadcrumbCode{get;set;}	
	public string ClasificacionFuncional_DescripcionCodigo{get;set;}	
	public int? Proceso_IdProyectoTipo{get;set;}	
	public string Proceso_Nombre{get;set;}	
	public bool? Proceso_Activo{get;set;}	
	public int Proyecto_IdTipoProyecto{get;set;}	
	public int Proyecto_IdSubPrograma{get;set;}	
	public int Proyecto_Codigo{get;set;}	
	public string Proyecto_ProyectoDenominacion{get;set;}	
	public string Proyecto_ProyectoSituacionActual{get;set;}	
	public string Proyecto_ProyectoDescripcion{get;set;}	
	public string Proyecto_ProyectoObservacion{get;set;}	
	public int Proyecto_IdEstado{get;set;}	
	public int? Proyecto_IdProceso{get;set;}	
	public int? Proyecto_IdModalidadContratacion{get;set;}	
	public int? Proyecto_IdFinalidadFuncion{get;set;}	
	public int? Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? Proyecto_SubPrioridad{get;set;}	
	public bool Proyecto_EsBorrador{get;set;}	
	public bool? Proyecto_EsProyecto{get;set;}	
	public int? Proyecto_NroProyecto{get;set;}	
	public int? Proyecto_AnioCorriente{get;set;}	
	public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime Proyecto_FechaAlta{get;set;}	
	public DateTime Proyecto_FechaModificacion{get;set;}	
	public int Proyecto_IdUsuarioModificacion{get;set;}	
	public int? Proyecto_IdProyectoPlan{get;set;}	
	public bool Proyecto_EvaluarValidaciones{get;set;}	
	public string ProyectoTipo_Sigla{get;set;}	
	public string ProyectoTipo_Nombre{get;set;}	
	public bool? ProyectoTipo_Activo{get;set;}	
	public string ProyectoTipo_Tipo{get;set;}	
					
		public virtual ProyectoCalidad ToEntity()
		{
		   ProyectoCalidad _ProyectoCalidad = new ProyectoCalidad();
		_ProyectoCalidad.IdProyectoCalidad = this.IdProyectoCalidad;
		 _ProyectoCalidad.IdProyecto = this.IdProyecto;
		 _ProyectoCalidad.DenominacionOK = this.DenominacionOK;
		 _ProyectoCalidad.DenominacionSugerida = this.DenominacionSugerida;
		 _ProyectoCalidad.DenominacionOriginal = this.DenominacionOriginal;
		 _ProyectoCalidad.ProyectoTipoOk = this.ProyectoTipoOk;
		 _ProyectoCalidad.IdProyectoTipo = this.IdProyectoTipo;
		 _ProyectoCalidad.EstadoOK = this.EstadoOK;
		 _ProyectoCalidad.IdEstadoSugerido = this.IdEstadoSugerido;
		 _ProyectoCalidad.ProcesoOk = this.ProcesoOk;
		 _ProyectoCalidad.IdProceso = this.IdProceso;
		 _ProyectoCalidad.FinalidadFuncionOk = this.FinalidadFuncionOk;
		 _ProyectoCalidad.IdClasificacionFuncional = this.IdClasificacionFuncional;
		 _ProyectoCalidad.ReqDictamen = this.ReqDictamen;
		 _ProyectoCalidad.Comenatrio = this.Comenatrio;
		 _ProyectoCalidad.IdEstado = this.IdEstado;
		 _ProyectoCalidad.FechaEstado = this.FechaEstado;
		 _ProyectoCalidad.LocalizacionOK = this.LocalizacionOK;
		 
		  return _ProyectoCalidad;
		}		
		public virtual void Set(ProyectoCalidad entity)
		{		   
		 this.IdProyectoCalidad= entity.IdProyectoCalidad ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.DenominacionOK= entity.DenominacionOK ;
		  this.DenominacionSugerida= entity.DenominacionSugerida ;
		  this.DenominacionOriginal= entity.DenominacionOriginal ;
		  this.ProyectoTipoOk= entity.ProyectoTipoOk ;
		  this.IdProyectoTipo= entity.IdProyectoTipo ;
		  this.EstadoOK= entity.EstadoOK ;
		  this.IdEstadoSugerido= entity.IdEstadoSugerido ;
		  this.ProcesoOk= entity.ProcesoOk ;
		  this.IdProceso= entity.IdProceso ;
		  this.FinalidadFuncionOk= entity.FinalidadFuncionOk ;
		  this.IdClasificacionFuncional= entity.IdClasificacionFuncional ;
		  this.ReqDictamen= entity.ReqDictamen ;
		  this.Comenatrio= entity.Comenatrio ;
		  this.IdEstado= entity.IdEstado ;
		  this.FechaEstado= entity.FechaEstado ;
		  this.LocalizacionOK= entity.LocalizacionOK ;
		 		  
		}		
		public virtual bool Equals(ProyectoCalidad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoCalidad.Equals(this.IdProyectoCalidad))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.DenominacionOK.Equals(this.DenominacionOK))return false;
		  if((entity.DenominacionSugerida == null)?this.DenominacionSugerida!=null:!entity.DenominacionSugerida.Equals(this.DenominacionSugerida))return false;
			 if((entity.DenominacionOriginal == null)?this.DenominacionOriginal!=null:!entity.DenominacionOriginal.Equals(this.DenominacionOriginal))return false;
			 if(!entity.ProyectoTipoOk.Equals(this.ProyectoTipoOk))return false;
		  if((entity.IdProyectoTipo == null)?(this.IdProyectoTipo.HasValue && this.IdProyectoTipo.Value > 0):!entity.IdProyectoTipo.Equals(this.IdProyectoTipo))return false;
						  if((entity.EstadoOK == null)?this.EstadoOK!=null:!entity.EstadoOK.Equals(this.EstadoOK))return false;
			 if((entity.IdEstadoSugerido == null)?this.IdEstadoSugerido!=null:!entity.IdEstadoSugerido.Equals(this.IdEstadoSugerido))return false;
			 if(!entity.ProcesoOk.Equals(this.ProcesoOk))return false;
		  if((entity.IdProceso == null)?(this.IdProceso.HasValue && this.IdProceso.Value > 0):!entity.IdProceso.Equals(this.IdProceso))return false;
						  if(!entity.FinalidadFuncionOk.Equals(this.FinalidadFuncionOk))return false;
		  if((entity.IdClasificacionFuncional == null)?(this.IdClasificacionFuncional.HasValue && this.IdClasificacionFuncional.Value > 0):!entity.IdClasificacionFuncional.Equals(this.IdClasificacionFuncional))return false;
						  if(!entity.ReqDictamen.Equals(this.ReqDictamen))return false;
		  if((entity.Comenatrio == null)?this.Comenatrio!=null:!entity.Comenatrio.Equals(this.Comenatrio))return false;
			 if(!entity.IdEstado.Equals(this.IdEstado))return false;
		  if((entity.FechaEstado == null)?this.FechaEstado!=null:!entity.FechaEstado.Equals(this.FechaEstado))return false;
			 if(!entity.LocalizacionOK.Equals(this.LocalizacionOK))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoCalidad", new List<DataColumnMapping>( new DataColumnMapping[]{
		     new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("DenominacionOK","Denominacionok")
			,new DataColumnMapping("DenominacionSugerida","DenominacionSugerida")
			,new DataColumnMapping("DenominacionOriginal","DenominacionOriginal")
			,new DataColumnMapping("ProyectoTipoOk","ProyectoTipoOk")
			,new DataColumnMapping("ProyectoTipo","ProyectoTipo_Nombre")
			,new DataColumnMapping("EstadoOK","Estadook")
			,new DataColumnMapping("EstadoSugerido","IdEstadoSugerido")
			,new DataColumnMapping("ProcesoOk","ProcesoOk")
			,new DataColumnMapping("Proceso","Proceso_Nombre")
			,new DataColumnMapping("FinalidadFuncionOk","FinalidadFuncionOk")
			,new DataColumnMapping("ClasificacionFuncional","FinalidadFuncion_Descripcion")
			,new DataColumnMapping("ReqDictamen","ReqDictamen")
			,new DataColumnMapping("Comenatrio","Comenatrio")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("FechaEstado","FechaEstado","{0:dd/MM/yyyy}")
			,new DataColumnMapping("LocalizacionOK","Localizacionok")
			}));
		}
	}
}
		