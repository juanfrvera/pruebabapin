using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoPrincipiosFormulacionFilter : Filter
    {   
		#region Private
		private string _NecesidadASatisfacer;
        private string _ObjetivoDelProyecto;
        private string _ProductoOServicio;
        private string _Alternativas;
        private string _PorqueAlternativa;
        private string _DescripcionTecnica;
        private string _VidaUtil;
        private string _CoberturaTerritorial;
        private string _CoberturaPoblacional;

        private string _CoberturaBeneficiariosIndirectos;
        private string _CoberturaBeneficiariosDirectos;
        private bool? _DificultadesRiesgos;
        private string _DificultadesRiesgosEnumeracion;
        private bool? _DimensionesCostosDimensionados;
        private bool? _DimensionesCostosValidados;
        private string _DimensionesCostosEnte;
        private bool? _RequiereIntevencion;
        private string _RequiereIntevencionAutoridad;
        private int? _RequiereIntevencionEstado;

        //Agregado Juan
        private string _RelacionProyectoMetodologia;

        private string _ObservacionesDNIP;

		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoPrincipiosFormulacion", IsRequired = false)]
        public int? IdProyectoPrincipiosFormulacion{get;set;}		
        [DataMember(Name = "IdProyectoPrincipiosFormulacion_To", IsRequired = false)]		
        public int? IdProyectoPrincipiosFormulacion_To{get;set;}		
        [DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		

        [DataMember(Name = "NecesidadASatisfacer", IsRequired = false)]
        public string NecesidadASatisfacer
        {
            get{ if(_NecesidadASatisfacer==null)_NecesidadASatisfacer= string.Empty;
	            return _NecesidadASatisfacer; 
	            }
            set{ _NecesidadASatisfacer=value;}
        }

        [DataMember(Name = "ObjetivoDelProyecto", IsRequired = false)]
        public string ObjetivoDelProyecto
        {
            get
            {
                if (_ObjetivoDelProyecto == null) _ObjetivoDelProyecto = string.Empty;
                return _ObjetivoDelProyecto;
            }
            set { _ObjetivoDelProyecto = value; }
        }
		 
        [DataMember(Name = "ProductoOServicio", IsRequired = false)]
        public string ProductoOServicio
        {
            get{ if(_ProductoOServicio==null)_ProductoOServicio= string.Empty;
	            return _ProductoOServicio; 
	            }
            set{ _ProductoOServicio=value;}
        }
		 
        [DataMember(Name = "Alternativas", IsRequired = false)]
        public string Alternativas
        {
            get{ if(_Alternativas==null)_Alternativas= string.Empty;
	            return _Alternativas; 
	            }
            set{ _Alternativas=value;}
        }
		 
        [DataMember(Name = "PorqueAlternativa", IsRequired = false)]
        public string PorqueAlternativa
        {
            get{ if(_PorqueAlternativa==null)_PorqueAlternativa= string.Empty;
	            return _PorqueAlternativa; 
	            }
            set{ _PorqueAlternativa=value;}
        }
		 
        [DataMember(Name = "DescripcionTecnica", IsRequired = false)]
        public string DescripcionTecnica
        {
            get{ if(_DescripcionTecnica==null)_DescripcionTecnica= string.Empty;
	            return _DescripcionTecnica; 
	            }
            set{ _DescripcionTecnica=value;}
        }
		 
        [DataMember(Name = "VidaUtil", IsRequired = false)]
        public string VidaUtil
        {
            get{ if(_VidaUtil==null)_VidaUtil= string.Empty;
	            return _VidaUtil; 
	            }
            set{ _VidaUtil=value;}
        }
		 
        [DataMember(Name = "CoberturaTerritorial", IsRequired = false)]
        public string CoberturaTerritorial
        {
            get{ if(_CoberturaTerritorial==null)_CoberturaTerritorial= string.Empty;
	            return _CoberturaTerritorial; 
	            }
            set{ _CoberturaTerritorial=value;}
        }
		 
        [DataMember(Name = "CoberturaPoblacional", IsRequired = false)]
        public string CoberturaPoblacional
        {
            get{ if(_CoberturaPoblacional==null)_CoberturaPoblacional= string.Empty;
	            return _CoberturaPoblacional; 
	            }
            set{ _CoberturaPoblacional=value;}
        }

        [DataMember(Name = "CoberturaBeneficiariosIndirectos", IsRequired = false)]
        public string CoberturaBeneficiariosIndirectos
        {
            get
            {
                if (_CoberturaBeneficiariosIndirectos == null) _CoberturaBeneficiariosIndirectos = string.Empty;
                return _CoberturaBeneficiariosIndirectos;
            }
            set { _CoberturaBeneficiariosIndirectos = value; }
        }

        [DataMember(Name = "CoberturaBeneficiariosDirectos", IsRequired = false)]
        public string CoberturaBeneficiariosDirectos
        {
            get
            {
                if (_CoberturaBeneficiariosDirectos == null) _CoberturaBeneficiariosDirectos = string.Empty;
                return _CoberturaBeneficiariosDirectos;
            }
            set { _CoberturaBeneficiariosDirectos = value; }
        }

        [DataMember(Name = "DificultadesRiesgos", IsRequired = false)]
        public bool? DificultadesRiesgos { get; set; }

        [DataMember(Name = "DificultadesRiesgosEnumeracion", IsRequired = false)]
        public string DificultadesRiesgosEnumeracion
        {
            get
            {
                if (_DificultadesRiesgosEnumeracion == null) _DificultadesRiesgosEnumeracion = string.Empty;
                return _DificultadesRiesgosEnumeracion;
            }
            set { _DificultadesRiesgosEnumeracion = value; }
        }

        [DataMember(Name = "DimensionesCostosDimensionados", IsRequired = false)]
        public bool? DimensionesCostosDimensionados { get; set; }

        [DataMember(Name = "DimensionesCostosValidados", IsRequired = false)]
        public bool? DimensionesCostosValidados { get; set; }

        [DataMember(Name = "DimensionesCostosEnte", IsRequired = false)]
        public string DimensionesCostosEnte
        {
            get
            {
                if (_DimensionesCostosEnte == null) _DimensionesCostosEnte = string.Empty;
                return _DimensionesCostosEnte;
            }
            set { _DimensionesCostosEnte = value; }
        }

        [DataMember(Name = "RequiereIntevencion", IsRequired = false)]
        public bool? RequiereIntevencion { get; set; }

        [DataMember(Name = "RequiereIntevencionAutoridad", IsRequired = false)]
        public string RequiereIntevencionAutoridad
        {
            get
            {
                if (_RequiereIntevencionAutoridad == null) _RequiereIntevencionAutoridad = string.Empty;
                return _RequiereIntevencionAutoridad;
            }
            set { _RequiereIntevencionAutoridad = value; }
        }

        [DataMember(Name = "RequiereIntevencionEstado", IsRequired = false)]
        public int? RequiereIntevencionEstado { get; set; }

        //Agregado Juan
        [DataMember(Name = "RelacionProyectoMetodologia", IsRequired = false)]
        public string RelacionProyectoMetodologia
        {
            get
            {
                if (_RelacionProyectoMetodologia == null) _RelacionProyectoMetodologia = string.Empty;
                return _RelacionProyectoMetodologia;
            }
            set { _RelacionProyectoMetodologia = value; }
        }

        [DataMember(Name = "ObservacionesDNIP", IsRequired = false)]
        public string ObservacionesDNIP
        {
            get
            {
                if (_ObservacionesDNIP == null) _ObservacionesDNIP = string.Empty;
                return _ObservacionesDNIP;
            }
            set { _ObservacionesDNIP = value; }
        }
		#endregion
    }
}
