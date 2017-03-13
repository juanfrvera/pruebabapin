using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
using System.Collections;
using System.Xml.Serialization; //Matias 20140611 - Tarea 148
namespace Contract
{
    [Serializable]
    public class ProyectoFilter : _ProyectoFilter
    {

        //Matias 20140512 - Tarea 133
        private Hashtable visualizacion;
        [XmlIgnore] //Matias 20140611 - Tarea 148
        public Hashtable Visualizacion
        {
            get
            {
                if (visualizacion == null) visualizacion = new Hashtable();
                return visualizacion;
            }
            set { visualizacion = value; }
        }

        public string VisualizacionToString()
        {
            string result = string.Empty;
            foreach (DictionaryEntry entry in visualizacion)
            {
                result = result + "<b>" + entry.Key + ": " + "</b>" + entry.Value + " + ";

            }
            result = result.Substring(0, result.Length - 2); //elimino el "+ " del final.
            return result;
        }

        //Matias 20130710 - No le agrego los tags html para luego poder meterlo dentro del PDF.
        public string VisualizacionSinFormatoToString()
        {
            string result = string.Empty;
            foreach (DictionaryEntry entry in visualizacion)
            {
                result = result + entry.Key + ": " + entry.Value + " + ";

            }
            result = result.Substring(0, result.Length - 2); //elimino el "+ " del final.
            return result;
        }
        //FinMatias 20140512 - Tarea 133
        
        public ProyectoReportFilter reportFilter { get; set; }
        public ProyectoPrintFilter printFilter { get; set; }

        private List<int> idsCalificacionDictamen;
        public List<int> IdsCalificacionDictamen
        {
            get {
                if (idsCalificacionDictamen == null) idsCalificacionDictamen = new List<int>();
                return idsCalificacionDictamen; }
            set { idsCalificacionDictamen = value; }
        }
        private List<int> idsEstado;
        public List<int> IdsEstado
        {
            get {
                if (idsEstado == null) idsEstado = new List<int>();
                return idsEstado; }
            set { idsEstado = value; }
        }
        private List<int> idsOficinaByUsuario;
        public List<int> IdsOficinaByUsuario
        {
            get
            {
                if (idsOficinaByUsuario == null) idsOficinaByUsuario = new List<int>();
                return idsOficinaByUsuario;
            }
            set { idsOficinaByUsuario = value; }
        }
        private List<int> idsOficinaPropiaByUsuario;
        public List<int> IdsOficinaPropiaByUsuario
        {
            get
            {
                if (idsOficinaPropiaByUsuario == null) idsOficinaPropiaByUsuario = new List<int>();
                return idsOficinaPropiaByUsuario;
            }
            set { idsOficinaPropiaByUsuario = value; }
        }
        private List<int> ids;
        public List<int> Ids
        {
            get
            {
                if (ids == null) ids = new List<int>();
                return ids;
            }
            set { ids = value; }
        }

        public int? IdSectorialista { get; set; }
        public int? IdSaf { get; set; }
        public int? IdJurisdiccion { get; set; }
        public int? IdPrograma { get; set; }
        public int? IdClasificacionGeografica { get; set; }
        public int? IdPlanTipo { get; set; }
        public int? IdPlanPeriodo { get; set; }
        public int? IdPlanVersion { get; set; }
        public int? IdPrioridad { get; set; }
        public int? IdProyectoCalificacion { get; set; }
        public int? Anio { get; set; } 
        
        public bool? RequiereArt15 { get; set; }
        public bool? Collapsed { get; set; }
        public bool? RequiereDictamen { get; set; }
        public bool? CalidadPendiente { get; set; }
        public int? IdOficina { get; set; }
        public int? IdRol { get; set; }
        public bool? IncluirOficinasInteriores { get; set; }
        public bool? IncluirClasificacionGeoInteriores { get; set; }
        public bool? IncluirFinalidadFunInteriores { get; set; }
        public int? IdProyectoSeguimiento { get; set; }
        public int? IdUsusarioLogeado { get; set; }
        public bool? UnicamentePorCodigo { get; set; }
        public int? ProyectoPlan { get; set; }

        public bool BuscarEnProyectoPlan { get; set; }

    }

    [Serializable]
    public class ProyectoReportFilter
    {
        public int IdReport { get; set; }
        public int AnioInicialCronograma { get; set; }
        public bool? SoloEstimados { get; set; }
        //public bool ConsideraAperturas { get; set; }
        public int IdFase { get; set; }
    }
    [Serializable ]
    public class ProyectoPrintFilter
    {
        public int  IdProyecto { get; set; }
        public bool SolapaGeneral {get;set;}
        public bool IncluyeDatosSecundarios { get; set; }
        public bool AlcanceGeografico { get; set; }
        public bool Objetivos { get; set; }
        public bool IncluyeEvolucionDeIndicadoresObjetivos { get; set; }
        public bool ProductoIntermedio { get; set; }
        public bool IncluyeDetalleDeEtapas { get; set; }
        public bool Cronograma { get; set; }
        public bool IncluyeDetallePorObjetoDelGastoYAnios { get; set; }
        public bool Evaluacion { get; set; }
        public bool IncluyeEvolucionDeIndicadoresEvaluacion { get; set; }
        public bool IntervencionDNIP { get; set; }
        public bool Adjuntos { get; set; }
        public bool Calidad { get; set; } //Matias 20170216 - Ticket #REQ792885

        public void SetAll(bool value)
        { 
            SolapaGeneral=value;
            IncluyeDatosSecundarios=value;
            AlcanceGeografico =  value;
            Objetivos = value;
            IncluyeEvolucionDeIndicadoresObjetivos = value;
            ProductoIntermedio = value;
            IncluyeDetalleDeEtapas = value;
            Cronograma =value;
            IncluyeDetallePorObjetoDelGastoYAnios = value;
            Evaluacion = value;
            IncluyeEvolucionDeIndicadoresEvaluacion = value;
            IntervencionDNIP = value;
            Adjuntos = value;
            Calidad = value; //Matias 20170216 - Ticket #REQ792885
        }

    }
}
