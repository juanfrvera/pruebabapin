using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;
using System.Data;

namespace Contract
{
    [Serializable]
    public class ProyectoProductoIntermedioCompose
    {
        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }
        public bool EsProyecto { get; set; }
        public Int32 NroProyecto { get; set; }
        public bool MarcaPlan { get; set; }
        public bool EsEquipamientoBasico { get; set; }
        public Int32 EtapasCantidadMaxima { get; set; }
        public List<ProyectoEtapaResult> Etapas = new List<ProyectoEtapaResult>();

        private List<ProyectoEtapaIndicadorCompose> indicadoresEtapa;
        public List<ProyectoEtapaIndicadorCompose> IndicadoresEtapa
        {
            get
            {
                if (indicadoresEtapa == null)
                    indicadoresEtapa = new List<ProyectoEtapaIndicadorCompose>();
                return indicadoresEtapa;
            }
            set { indicadoresEtapa = value; }
        }
    }

    [Serializable]
    public class ProyectoEtapaIndicadorCompose : IndicadoresEvolucionCompose
    {
        public Int32 ID
        {
            get { return Indicador.ID; }
        }
        public string Descripcion
        {
            get { return Indicador.Descripcion; }
        }
        public string Contratista
        {
            get { return Indicador.Contratista; }
        }
        public string MedioDeVerificacion
        {
            get { return Indicador.MedioDeVerificacion; }
        }
        public string NroExpediente
        {
            get { return Indicador.NroExpediente; }
        }
        public decimal MontoContrato
        {
            get { return Indicador.MontoContrato == null ? 0 : (decimal)Indicador.MontoContrato; }
        }

        ProyectoEtapaIndicadorResult indicador;
        public ProyectoEtapaIndicadorResult Indicador
        {
            get
            {
                if (indicador == null)
                    indicador = new ProyectoEtapaIndicadorResult();
                return indicador;
            }
            set { indicador = value; }
        }

        // Hereda una colección de Indicador Evolucion
        // EVOLUCIONES
    }
}