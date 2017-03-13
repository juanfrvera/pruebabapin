using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoSeguimientoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoSeguimiento;}}
		 public int IdProyectoSeguimiento{get;set;}
		 public int IdSaf{get;set;}
		 public string Denominacion{get;set;}
		 public string Ruta{get;set;}
		 public string Malla{get;set;}
		 public int IdAnalista{get;set;}
		 public int? IdProyectoSeguimientoAnterior{get;set;}
		 public int? IdProyectoSeguimientoEstadoUltimo{get;set;}
		 
         //public int? ProyectoSeguimientoAnterior_IdSaf{get;set;}	
    public string ProyectoSeguimientoAnterior_Denominacion{get;set;}	
    //public string ProyectoSeguimientoAnterior_Ruta{get;set;}	
    //public string ProyectoSeguimientoAnterior_Malla{get;set;}	
    //public int? ProyectoSeguimientoAnterior_IdAnalista{get;set;}	
    //public int? ProyectoSeguimientoAnterior_IdProyectoSeguimientoAnterior{get;set;}	
    //public int? ProyectoSeguimientoAnterior_IdProyectoSeguimientoEstadoUltimo{get;set;}	
    //public int? ProyectoSeguimientoEstadoUltimo_IdProyectoSeguimiento{get;set;}	
    public int? ProyectoSeguimientoEstadoUltimo_IdEstado{get;set;}	
    //public DateTime? ProyectoSeguimientoEstadoUltimo_Fecha{get;set;}	
    //public string ProyectoSeguimientoEstadoUltimo_Observacion{get;set;}	
    //public int? ProyectoSeguimientoEstadoUltimo_IdUsuario{get;set;}	
    public string Saf_Codigo{get;set;}	
    public string Saf_Denominacion{get;set;}	
    //public int Saf_IdTipoOrganismo{get;set;}	
    //public int? Saf_IdSector{get;set;}	
    //public int? Saf_IdAdministracionTipo{get;set;}	
    //public int? Saf_IdEntidadTipo{get;set;}	
    //public int? Saf_IdJurisdiccion{get;set;}	
    //public int? Saf_IdSubJurisdiccion{get;set;}	
    //public DateTime Saf_FechaAlta{get;set;}	
    //public DateTime? Saf_FechaBaja{get;set;}	
    //public bool Saf_Activo{get;set;}	
    //public string Analista_NombreUsuario{get;set;}	
    //public string Analista_Clave{get;set;}	
    //public bool Analista_Activo{get;set;}	
    //public bool Analista_EsSectioralista{get;set;}	
    //public int Analista_IdLanguage{get;set;}	
    //public bool Analista_AccesoTotal{get;set;}	

    public virtual ProyectoSeguimiento ToEntity()
    {
        ProyectoSeguimiento _ProyectoSeguimiento = new ProyectoSeguimiento();
        _ProyectoSeguimiento.IdProyectoSeguimiento = this.IdProyectoSeguimiento;
        _ProyectoSeguimiento.IdSaf = this.IdSaf;
        _ProyectoSeguimiento.Denominacion = this.Denominacion;
        _ProyectoSeguimiento.Ruta = this.Ruta;
        _ProyectoSeguimiento.Malla = this.Malla;
        _ProyectoSeguimiento.IdAnalista = this.IdAnalista;
        _ProyectoSeguimiento.IdProyectoSeguimientoAnterior = this.IdProyectoSeguimientoAnterior;
        _ProyectoSeguimiento.IdProyectoSeguimientoEstadoUltimo = this.IdProyectoSeguimientoEstadoUltimo;

        return _ProyectoSeguimiento;
    }		
    //    public virtual void Set(ProyectoSeguimiento entity)
    //    {		   
    //     this.IdProyectoSeguimiento= entity.IdProyectoSeguimiento ;
    //      this.IdSaf= entity.IdSaf ;
    //      this.Denominacion= entity.Denominacion ;
    //      this.Ruta= entity.Ruta ;
    //      this.Malla= entity.Malla ;
    //      this.IdAnalista= entity.IdAnalista ;
    //      this.IdProyectoSeguimientoAnterior= entity.IdProyectoSeguimientoAnterior ;
    //      this.IdProyectoSeguimientoEstadoUltimo= entity.IdProyectoSeguimientoEstadoUltimo ;
		 		  
    //    }		
    //    public virtual bool Equals(ProyectoSeguimiento entity)
    //    {
    //       if(entity == null)return false;
    //     if(!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento))return false;
    //      if(!entity.IdSaf.Equals(this.IdSaf))return false;
    //      if(!entity.Denominacion.Equals(this.Denominacion))return false;
    //      if((entity.Ruta == null)?this.Ruta!=null:!entity.Ruta.Equals(this.Ruta))return false;
    //         if((entity.Malla == null)?this.Malla!=null:!entity.Malla.Equals(this.Malla))return false;
    //         if(!entity.IdAnalista.Equals(this.IdAnalista))return false;
    //      if((entity.IdProyectoSeguimientoAnterior == null)?(this.IdProyectoSeguimientoAnterior.HasValue && this.IdProyectoSeguimientoAnterior.Value > 0):!entity.IdProyectoSeguimientoAnterior.Equals(this.IdProyectoSeguimientoAnterior))return false;
    //                      if((entity.IdProyectoSeguimientoEstadoUltimo == null)?(this.IdProyectoSeguimientoEstadoUltimo.HasValue && this.IdProyectoSeguimientoEstadoUltimo.Value > 0):!entity.IdProyectoSeguimientoEstadoUltimo.Equals(this.IdProyectoSeguimientoEstadoUltimo))return false;
						 
    //      return true;
    //    }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoSeguimiento", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Saf","Saf_Codigo")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("Ruta","Ruta")
			,new DataColumnMapping("Malla","Malla")
			,new DataColumnMapping("Analista","Usuario_NombreUsuario")
			,new DataColumnMapping("ProyectoSeguimientoAnterior","ProyectoSeguimiento_Denominacion")
			,new DataColumnMapping("ProyectoSeguimientoEstadoUltimo","ProyectoSeguimientoEstado_Observacion")
			}));
		}
	}
}
		