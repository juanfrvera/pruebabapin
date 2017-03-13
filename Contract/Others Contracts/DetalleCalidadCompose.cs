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
    public class DetalleCalidadCompose
    {
        public Int32 IdProyecto { get; set; }
        public List<ProyectoEtapaResult> Etapas = new List<ProyectoEtapaResult>();
        public List<ProyectoEtapaEstimadoResult> EtapasEstimadas = new List<ProyectoEtapaEstimadoResult>();
        public List<ProyectoEtapaRealizadoResult> EtapasRealizadas = new List<ProyectoEtapaRealizadoResult>();
        public List<ProyectoIndicadorPriorizacionResult> Prioridades;

        public bool ActivoUltimoPlan { get; set; }
        public Int32 IdPeriodoUltimoPlan { get; set; }
        public string UltimoPlan { get; set; }
        public bool Art15 { get; set; }
        public string Dictamen { get; set; }
        public string UltPriorizacion { get; set; }
        public string UltPrioPeriodo { get; set; }
        public string PrioridadOrganismo { get; set; }
        public string SubPrioridad { get; set; }
    }
}