using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class PrestamoResult : _PrestamoResult
    {
        public int IdUsuario { get; set; }
        public string Saf_Jurisdiccion { get; set; }
        public string Saf_Nombre { get; set; }
        public string Estado_Nombre { get; set; }
        public string Saf_Codigo { get; set; }
        public int IdOficina_Usuario { get; set; }
        public int Saf_Id { get; set; }
        public int OficinaBreadcrumbId { get; set; }
        public decimal? Monto { get; set; }
        public string OrganismoFinanciero_Nombre { get; set; }
        public string Nro_Bnc { get; set; }
        public string Sigla { get; set; }
        public decimal? MontoTotal { get; set; }

        private List<PerfilOficina> perfilOficinas;
        public List<PerfilOficina> PerfilOficinas
        {
            get
            {
                if (perfilOficinas == null) perfilOficinas = new List<PerfilOficina>();
                return perfilOficinas;
            }
            set { perfilOficinas = value; }
        }
        public string NumeroPrestamoBanco
        {
            get
            {
                if(Sigla != null && Nro_Bnc != null)
                    return String.Format("{0}-{1}", Sigla, Nro_Bnc);
                else
                    return "";
            }
        }

        public string Saf_SectorNombre { get; set; }
        public string Saf_AdministracionTipoNombre { get; set; }
        public string Saf_EntidadTipoNombre { get; set; }
        public string CodigoString { get { return Numero.ToString() ; } } //Matias 20140424 - Tarea 137

        public override DataTableMapping ToMapping()
        {
            return new DataTableMapping("Prestamo", new List<DataColumnMapping>(new DataColumnMapping[]
		   {new DataColumnMapping("JU","Saf_Jurisdiccion")
                ,new DataColumnMapping("SAF","Saf_Codigo")
                ,new DataColumnMapping("PR","Programa_Codigo")  
			    ,new DataColumnMapping("Número","Numero")
			    ,new DataColumnMapping("Denominación","Denominacion")
                ,new DataColumnMapping("Org. Financiero","OrganismoFinanciero_Nombre")
                ,new DataColumnMapping("Estado","Estado_Nombre")
                ,new DataColumnMapping("Nro Prest. Banco","NumeroPrestamoBanco")
			    ,new DataColumnMapping("Monto","Monto","{0:N0}")
                ,new DataColumnMapping("Monto Total","MontoTotal","{0:N0}")
			    ,new DataColumnMapping("Fecha de Estado","FechaAlta","{0:dd/MM/yyyy}")
			}));
        }

        public override bool Equals(object obj)
        {
            return this.Equals((PrestamoResult)obj);
        }
        public bool Equals(PrestamoResult obj)
        {
            return this.CodigoVinculacion1 == obj.CodigoVinculacion1 &&
                   this.CodigoVinculacion2 == obj.CodigoVinculacion2 &&
                   this.Denominacion == obj.Denominacion &&
                   this.Descripcion == obj.Descripcion &&
                   this.FechaAlta == obj.FechaAlta &&
                   this.IdEstadoActual == obj.IdEstadoActual &&
                   this.IdOficina_Usuario == obj.IdOficina_Usuario &&
                   this.IdPrestamo == obj.IdPrestamo &&
                   this.IdPrograma == obj.IdPrograma &&
                   this.Monto == obj.Monto &&
                   this.Nro_Bnc == obj.Nro_Bnc &&
                   this.Numero == obj.Numero &&
                   this.Observacion == obj.Observacion &&
                   this.ResponsablePolitico == obj.ResponsablePolitico &&
                   this.ResponsableTecnico == obj.ResponsableTecnico;
        }

    }

    [Serializable]
    public class PrestamoObjetivoReportResult
    {
        public int PrestamoObjetivo_ID { get; set; } //new
        public string ProgramaObjetivo_Nombre { get; set; }
        public string ProyectoObjetivo_Nombre { get; set; }
        public int ObjetivoSupuesto_Id { get; set; } //new
        public string ObjetivoSupuesto_Descripcion { get; set; }

        //Indicador
        public string Indicador_Sigla { get; set; }
        public string Indicador_Descripcion { get; set; }
        public string Unidad_Sigla { get; set; }
        public string Unidad_Descripcion { get; set; }
        public string Indicador_Observacion { get; set; }
        public string MedioVerificacion_Sigla { get; set; }
        public string MedioVerificacion_Nombre { get; set; }

        public string ClasificacionGeografica_Descripcion { get; set; }
        public int ClasificacionGeografica_ID { get; set; } //new
        public string IndicadorEvolucionInstancia_Nombre { get; set; }
        public DateTime? FechaEstimada { get; set; }
        public decimal? CantidadEstimada { get; set; }
        public DateTime? FechaReal { get; set; }
        public decimal? CantidadReal { get; set; }
        public int IdIndicadorEvolucion { get; set; }
        public int IdIndicador { get; set; }
    }

    [Serializable]
    public class PrestamoComponentesReportResult
    {
        public string Componente_Nombre { get; set; }
        public string SubComponente_Descripcion { get; set; }
        public string FuenteFinanciamiento_Nombre { get; set; }
        public decimal PrestamoFinanciamiento_Monto { get; set; }
    }

    [Serializable]
    public class PrestamoReportInfo { 
        public bool SolapaGeneral {get;set;}
        public bool AlcanceGeografico {get;set;}
        public bool Objetivos {get;set;}
        public bool IncluyeEvolucionDeIndicadoresObjetivos {get;set;}
        public bool Convenio { get; set; }
        public bool Componente { get; set; }
        public bool Producto{get;set;}
        public bool IntervencionDNIP {get;set;}
        public bool Adjuntos {get;set;}
        public int IdPrestamo { get; set; }    
    
    
    }
}
