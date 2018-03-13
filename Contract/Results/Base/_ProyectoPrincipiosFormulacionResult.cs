using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoPrincipiosFormulacionResult : IResult<int>
    {
        public virtual int ID{get{return IdProyectoPrincipiosFormulacion;}}
		public int IdProyectoPrincipiosFormulacion{get;set;}
		public int IdProyecto{get;set;}
        public string NecesidadASatisfacer { get; set; }
        public string ObjetivoDelProyecto { get; set; }
        public string ProductoOServicio { get; set; }
        public string Alternativas { get; set; }
        public string PorqueAlternativa { get; set; }
        public string DescripcionTecnica { get; set; }
        public string VidaUtil { get; set; }
        public string CoberturaTerritorial { get; set; }
        public string CoberturaPoblacional { get; set; }
        public string CoberturaBeneficiariosDirectos { get; set; }
        public string CoberturaBeneficiariosIndirectos { get; set; }
        public bool? DificultadesRiesgos { get; set; }
        public string DificultadesRiesgosEnumeracion { get; set; }
        public bool? DimensionesCostosDimensionados { get; set; }
        public bool? DimensionesCostosValidados { get; set; }
        public string DimensionesCostosEnte { get; set; }
        public bool? RequiereIntevencion { get; set; }
        public string RequiereIntevencionAutoridad { get; set; }
        public int? RequiereIntevencionEstado { get; set; }
		 
		public int _Proyecto_IdTipoProyecto{get;set;}	
        public int _Proyecto_IdSubPrograma{get;set;}	
        public int _Proyecto_Codigo{get;set;}	
        public string _Proyecto_ProyectoDenominacion{get;set;}	
        public string _Proyecto_ProyectoSituacionActual{get;set;}	
        public string _Proyecto_ProyectoDescripcion{get;set;}	
        public string _Proyecto_ProyectoObservacion{get;set;}	
        public int _Proyecto_IdEstado{get;set;}	
        public int? _Proyecto_IdProceso{get;set;}	
        public int? _Proyecto_IdModalidadContratacion{get;set;}	
        public int? _Proyecto_IdFinalidadFuncion{get;set;}	
        public int? _Proyecto_IdOrganismoPrioridad{get;set;}	
        public int? _Proyecto_SubPrioridad{get;set;}	
        public bool _Proyecto_EsBorrador{get;set;}	
        public bool? _Proyecto_EsProyecto{get;set;}	
        public int? _Proyecto_NroProyecto{get;set;}	
        public int? _Proyecto_AnioCorriente{get;set;}	
        public DateTime? _Proyecto_FechaInicioEjecucionCalculada{get;set;}	
        public DateTime? _Proyecto_FechaFinEjecucionCalculada{get;set;}	
        public DateTime _Proyecto_FechaAlta{get;set;}	
        public DateTime _Proyecto_FechaModificacion{get;set;}	
        public int _Proyecto_IdUsuarioModificacion{get;set;}	
        public int? _Proyecto_IdProyectoPlan{get;set;}	
        public bool _Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoPrincipiosFormulacion ToEntity()
		{   
            ProyectoPrincipiosFormulacion _ProyectoPrincipiosFormulacion = new ProyectoPrincipiosFormulacion();
            _ProyectoPrincipiosFormulacion.IdProyectoPrincipiosFormulacion = this.IdProyectoPrincipiosFormulacion;
            _ProyectoPrincipiosFormulacion.IdProyecto = this.IdProyecto;
            _ProyectoPrincipiosFormulacion.NecesidadASatisfacer = this.NecesidadASatisfacer;
            _ProyectoPrincipiosFormulacion.ObjetivoDelProyecto = this.ObjetivoDelProyecto;
            _ProyectoPrincipiosFormulacion.ProductoOServicio = this.ProductoOServicio;
            _ProyectoPrincipiosFormulacion.Alternativas = this.Alternativas;
            _ProyectoPrincipiosFormulacion.PorqueAlternativa = this.PorqueAlternativa;
            _ProyectoPrincipiosFormulacion.DescripcionTecnica = this.DescripcionTecnica;
            _ProyectoPrincipiosFormulacion.VidaUtil = this.VidaUtil;
            _ProyectoPrincipiosFormulacion.CoberturaTerritorial = this.CoberturaTerritorial;
            _ProyectoPrincipiosFormulacion.CoberturaPoblacional = this.CoberturaPoblacional;
            _ProyectoPrincipiosFormulacion.CoberturaBeneficiariosDirectos = this.CoberturaBeneficiariosDirectos;
            _ProyectoPrincipiosFormulacion.CoberturaBeneficiariosIndirectos = this.CoberturaBeneficiariosIndirectos;
            _ProyectoPrincipiosFormulacion.DificultadesRiesgos = this.DificultadesRiesgos;
            _ProyectoPrincipiosFormulacion.DificultadesRiesgosEnumeracion = this.DificultadesRiesgosEnumeracion;
            _ProyectoPrincipiosFormulacion.DimensionesCostosDimensionados = this.DimensionesCostosDimensionados;
            _ProyectoPrincipiosFormulacion.DimensionesCostosValidados = this.DimensionesCostosValidados;
            _ProyectoPrincipiosFormulacion.DimensionesCostosEnte = this.DimensionesCostosEnte;
            _ProyectoPrincipiosFormulacion.RequiereIntevencion = this.RequiereIntevencion;
            _ProyectoPrincipiosFormulacion.RequiereIntevencionAutoridad = this.RequiereIntevencionAutoridad;
            _ProyectoPrincipiosFormulacion.RequiereIntevencionEstado = this.RequiereIntevencionEstado;
		 
		  return _ProyectoPrincipiosFormulacion;
		}		
		public virtual void Set(ProyectoPrincipiosFormulacion entity)
		{		   
		 this.IdProyectoPrincipiosFormulacion= entity.IdProyectoPrincipiosFormulacion ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.NecesidadASatisfacer= entity.NecesidadASatisfacer ;
          this.ObjetivoDelProyecto = entity.ObjetivoDelProyecto;
		  this.ProductoOServicio= entity.ProductoOServicio ;
		  this.Alternativas= entity.Alternativas ;
		  this.PorqueAlternativa= entity.PorqueAlternativa ;
		  this.DescripcionTecnica= entity.DescripcionTecnica ;
		  this.VidaUtil= entity.VidaUtil ;
		  this.CoberturaTerritorial= entity.CoberturaTerritorial ;
		  this.CoberturaPoblacional= entity.CoberturaPoblacional ;
		  this.CoberturaBeneficiariosDirectos= entity.CoberturaBeneficiariosDirectos ;
		  this.CoberturaBeneficiariosIndirectos= entity.CoberturaBeneficiariosIndirectos ;
          this.DificultadesRiesgos = entity.DificultadesRiesgos;
          this.DificultadesRiesgosEnumeracion = entity.DificultadesRiesgosEnumeracion;
          this.DimensionesCostosDimensionados = entity.DimensionesCostosDimensionados;
          this.DimensionesCostosValidados = entity.DimensionesCostosValidados;
          this.DimensionesCostosEnte = entity.DimensionesCostosEnte;
          this.RequiereIntevencion = entity.RequiereIntevencion;
          this.RequiereIntevencionAutoridad = entity.RequiereIntevencionAutoridad;
          this.RequiereIntevencionEstado = entity.RequiereIntevencionEstado;
		 		  
		}		
		public virtual bool Equals(ProyectoPrincipiosFormulacion entity)
        {
            if(entity == null)return false;
            if(!entity.IdProyectoPrincipiosFormulacion.Equals(this.IdProyectoPrincipiosFormulacion))return false;
            if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
            if((entity.NecesidadASatisfacer == null)?this.NecesidadASatisfacer!=null:!entity.NecesidadASatisfacer.Equals(this.NecesidadASatisfacer))return false;
            if ((entity.ObjetivoDelProyecto == null) ? this.ObjetivoDelProyecto != null : !entity.ObjetivoDelProyecto.Equals(this.ObjetivoDelProyecto)) return false;
            if((entity.ProductoOServicio == null)?this.ProductoOServicio!=null:!entity.ProductoOServicio.Equals(this.ProductoOServicio))return false;
            if((entity.Alternativas == null)?this.Alternativas!=null:!entity.Alternativas.Equals(this.Alternativas))return false;
            if((entity.PorqueAlternativa == null)?this.PorqueAlternativa!=null:!entity.PorqueAlternativa.Equals(this.PorqueAlternativa))return false;
            if((entity.DescripcionTecnica == null)?this.DescripcionTecnica!=null:!entity.DescripcionTecnica.Equals(this.DescripcionTecnica))return false;
            if((entity.VidaUtil == null)?this.VidaUtil!=null:!entity.VidaUtil.Equals(this.VidaUtil))return false;
            if((entity.CoberturaTerritorial == null)?this.CoberturaTerritorial!=null:!entity.CoberturaTerritorial.Equals(this.CoberturaTerritorial))return false;
            if((entity.CoberturaPoblacional == null)?this.CoberturaPoblacional!=null:!entity.CoberturaPoblacional.Equals(this.CoberturaPoblacional))return false;
            if((entity.CoberturaBeneficiariosDirectos == null)?this.CoberturaBeneficiariosDirectos!=null:!entity.CoberturaBeneficiariosDirectos.Equals(this.CoberturaBeneficiariosDirectos))return false;
            if((entity.CoberturaBeneficiariosIndirectos == null)?this.CoberturaBeneficiariosIndirectos!=null:!entity.CoberturaBeneficiariosIndirectos.Equals(this.CoberturaBeneficiariosIndirectos))return false;
            if ((entity.DificultadesRiesgos == null) ? this.DificultadesRiesgos != null : !entity.DificultadesRiesgos.Equals(this.DificultadesRiesgos)) return false;
            if ((entity.DificultadesRiesgosEnumeracion == null) ? this.DificultadesRiesgosEnumeracion != null : !entity.DificultadesRiesgosEnumeracion.Equals(this.DificultadesRiesgosEnumeracion)) return false;
            if ((entity.DimensionesCostosDimensionados == null) ? this.DimensionesCostosDimensionados != null : !entity.DimensionesCostosDimensionados.Equals(this.DimensionesCostosDimensionados)) return false;
            if ((entity.DimensionesCostosValidados == null) ? this.DimensionesCostosValidados != null : !entity.DimensionesCostosValidados.Equals(this.DimensionesCostosValidados)) return false;
            if ((entity.DimensionesCostosEnte == null) ? this.DimensionesCostosEnte != null : !entity.DimensionesCostosEnte.Equals(this.DimensionesCostosEnte)) return false;
            if ((entity.RequiereIntevencion == null) ? this.RequiereIntevencion != null : !entity.RequiereIntevencion.Equals(this.RequiereIntevencion)) return false;
            if ((entity.RequiereIntevencionAutoridad == null) ? this.RequiereIntevencionAutoridad != null : !entity.RequiereIntevencionAutoridad.Equals(this.RequiereIntevencionAutoridad)) return false;
            if ((entity.RequiereIntevencionEstado == null) ? this.RequiereIntevencionEstado != null : !entity.RequiereIntevencionEstado.Equals(this.RequiereIntevencionEstado)) return false;
            
            return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
            return new DataTableMapping("ProyectoPrincipiosFormulacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		    new DataColumnMapping("_Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("NecesidadASatisfacer","NecesidadASatisfacer")
            ,new DataColumnMapping("ObjetivoDelProyecto","ObjetivoDelProyecto")
			,new DataColumnMapping("ProductoOServicio","ProductoOServicio")
			,new DataColumnMapping("Alternativas","Alternativas")
			,new DataColumnMapping("PorqueAlternativa","PorqueAlternativa")
			,new DataColumnMapping("DescripcionTecnica","DescripcionTecnica")
			,new DataColumnMapping("VidaUtil","VidaUtil")
			,new DataColumnMapping("CoberturaTerritorial","CoberturaTerritorial")
			,new DataColumnMapping("CoberturaPoblacional","CoberturaPoblacional")
			,new DataColumnMapping("CoberturaBeneficiariosDirectos","CoberturaBeneficiariosDirectos")
			,new DataColumnMapping("CoberturaBeneficiariosIndirectos","CoberturaBeneficiariosIndirectos")
            ,new DataColumnMapping("DificultadesRiesgos","DificultadesRiesgos")
            ,new DataColumnMapping("DificultadesRiesgosEnumeracion","DificultadesRiesgosEnumeracion")
            ,new DataColumnMapping("DimensionesCostosDimensionados","DimensionesCostosDimensionados")
            ,new DataColumnMapping("DimensionesCostosValidados","DimensionesCostosValidados")
            ,new DataColumnMapping("DimensionesCostosEnte","DimensionesCostosEnte")
            ,new DataColumnMapping("RequiereIntevencion","RequiereIntevencion")
            ,new DataColumnMapping("RequiereIntevencionAutoridad","RequiereIntevencionAutoridad")
            ,new DataColumnMapping("RequiereIntevencionEstado","RequiereIntevencionEstado")
			}));
		}
	}
}
		