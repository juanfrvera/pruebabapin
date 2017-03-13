using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]

    public class ProyectoSeguimientoResult : IResult<int>
    {        
         public string UltimoEstadoNombre { get; set; }
         public string Analista_ApellidoYNombre { get; set; }
		 public virtual int ID{get{return IdProyectoSeguimiento;}}
		 public int IdProyectoSeguimiento{get;set;}
		 public int IdSaf{get;set;}
		 public string Denominacion{get;set;}
		 public string Ruta{get;set;}
		 public string Malla{get;set;}
		 public int IdAnalista{get;set;}
		 public int? IdProyectoSeguimientoAnterior{get;set;}
		 public int? IdProyectoSeguimientoEstadoUltimo{get;set;}
		 
      
        public string ProyectoSeguimientoAnterior_Denominacion{get;set;}	
  
        public string Saf_Codigo{get;set;}	
        public string Saf_Denominacion{get;set;}
        public string Saf_CodigoDenominacion
        {
            get {
                return String.Format("{0}-{1}", Saf_Codigo, Saf_Denominacion);
            }
        }

        public DateTime? ProyectoSeguimientoEstadoUltimo_Fecha{get;set;}	
        public string ProyectoSeguimientoEstadoUltimo_Observacion{get;set;}	
        public int? ProyectoSeguimientoEstadoUltimo_IdUsuario{get;set;}
        public int? ProyectoSeguimientoEstadoUltimo_IdEstado { get; set; }
        public string ProyectoSeguimientoEstadoUltimo_UsuarioApellidoYNombre { get; set; }
        public string ProyectoSeguimientoEstadoUltimo_EstadoNombre { get; set; }

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
        public virtual void Set(ProyectoSeguimiento entity)
        {
            this.IdProyectoSeguimiento = entity.IdProyectoSeguimiento;
            this.IdSaf = entity.IdSaf;
            this.Denominacion = entity.Denominacion;
            this.Ruta = entity.Ruta;
            this.Malla = entity.Malla;
            this.IdAnalista = entity.IdAnalista;
            this.IdProyectoSeguimientoAnterior = entity.IdProyectoSeguimientoAnterior;
            this.IdProyectoSeguimientoEstadoUltimo = entity.IdProyectoSeguimientoEstadoUltimo;

        }
        public virtual bool Equals(ProyectoSeguimiento entity)
        {
            if (entity == null) return false;
            if (!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento)) return false;
            if (!entity.IdSaf.Equals(this.IdSaf)) return false;
            if (!entity.Denominacion.Equals(this.Denominacion)) return false;
            if ((entity.Ruta == null) ? this.Ruta != null : !entity.Ruta.Equals(this.Ruta)) return false;
            if ((entity.Malla == null) ? this.Malla != null : !entity.Malla.Equals(this.Malla)) return false;
            if (!entity.IdAnalista.Equals(this.IdAnalista)) return false;
            if ((entity.IdProyectoSeguimientoAnterior == null) ? (this.IdProyectoSeguimientoAnterior.HasValue && this.IdProyectoSeguimientoAnterior.Value > 0) : !entity.IdProyectoSeguimientoAnterior.Equals(this.IdProyectoSeguimientoAnterior)) return false;
            if ((entity.IdProyectoSeguimientoEstadoUltimo == null) ? (this.IdProyectoSeguimientoEstadoUltimo.HasValue && this.IdProyectoSeguimientoEstadoUltimo.Value > 0) : !entity.IdProyectoSeguimientoEstadoUltimo.Equals(this.IdProyectoSeguimientoEstadoUltimo)) return false;

            return true;
        }
    		
	    public virtual DataTableMapping ToMapping()
	    {
	        return new DataTableMapping("ProyectoSeguimiento", new List<DataColumnMapping>( new DataColumnMapping[]{
            
             new DataColumnMapping("Nro. Secuencia","IdProyectoSeguimiento")
            ,new DataColumnMapping("Saf","Saf_Codigo")
            ,new DataColumnMapping("Saf Denominacion","Saf_Denominacion")
		    ,new DataColumnMapping("Denominacion","Denominacion")
		    ,new DataColumnMapping("Ruta","Ruta")
		    ,new DataColumnMapping("Malla","Malla")
		    ,new DataColumnMapping("Analista","Analista_ApellidoYNombre")
		    //,new DataColumnMapping("ProyectoSeguimientoEstadoUltimo","ProyectoSeguimientoEstado_Observacion")
		    ,new DataColumnMapping("Fecha UltimoEstado","ProyectoSeguimientoEstadoUltimo_Fecha","{0:dd/MM/yyyy}")
            ,new DataColumnMapping("Observacion Ultimo Estado","ProyectoSeguimientoEstadoUltimo_Observacion")
            ,new DataColumnMapping("Usuario Ultimo Estado","ProyectoSeguimientoEstadoUltimo_UsuarioApellidoYNombre")
            ,new DataColumnMapping("Nombre Ultimo Esado","ProyectoSeguimientoEstadoUltimo_EstadoNombre")
            
            }));
	    }
    }
}
		
