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
    public class ProyectoCalidadCompose
    {
        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
            set { Proyecto.IdProyecto = value; }
        }
        public ProyectoCalidadResult CalidadActual { get; set; }
        public ProyectoCalidadResult CalidadSugerida { get; set; }

        public List<ProyectoLocalizacionResult> localizacionesActual = new List<ProyectoLocalizacionResult>();
        public List<ProyectoCalidadLocalizacionResult> localizacionesSugerida = new List<ProyectoCalidadLocalizacionResult>();

        public EstadoResult Estado { get; set; }
        public bool AdministrandoCalidad { get; set; }
        public bool AdministrandoPriorizacion { get; set; }
        public bool HabilitadoParaCambios { get; set; }

        public bool AceptadoDenominacion { get; set; }
        public bool AceptadoTipoProyecto { get; set; }
        public bool AceptadoEstado { get; set; }
        public bool AceptadoProceso { get; set; }
        public bool AceptadoFinalidad { get; set; }
        public bool AceptadoLocalizacion { get; set; }

        public bool SugerenciaAceptada
        {
            get { return AceptadoDenominacion || AceptadoEstado || AceptadoFinalidad || AceptadoProceso || AceptadoTipoProyecto || AceptadoLocalizacion; }
        }

        public ProyectoPrioridadResult ProyectoPrioridad { get; set; }

        public DataTable ToDatatableResumenEtapasEstimadas(int idProyecto, DetalleCalidadCompose datos, ref decimal totalGral)
        {
            DataTable table = new DataTable("EtapasEstimadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Inversión Física - Descripción", typeof(string)));
            table.Columns.Add(new DataColumn("Apertura", typeof(string)));

            // Agrega las columnas
            List<Int32> aniosUtilizados = new List<int>();
            foreach (ProyectoEtapaEstimadoResult linea in datos.EtapasEstimadas)
            {
                foreach (ProyectoEtapaEstimadoPeriodoResult punto in linea.Periodos)
                {
                    if (!aniosUtilizados.Contains(punto.Periodo))
                        aniosUtilizados.Add(punto.Periodo);
                }
            }
            Dictionary<Int32, Int32> dicAnios = new Dictionary<int, int>();
            foreach (Int32 periodo in (from n in aniosUtilizados orderby n select n))
            {
                table.Columns.Add(new DataColumn(periodo.ToString(), typeof(string )));
                dicAnios.Add(periodo, table.Columns.Count - 1);
            }

            // Acumula los datos por etapa
            foreach (ProyectoEtapaResult per in datos.Etapas)
            {
                DataRow row = table.NewRow();
                row[0] = per.ID;
                row[1] = per.Nombre;
                row[2] = per.Apertura;
                foreach (ProyectoEtapaEstimadoResult peer in datos.EtapasEstimadas.Where(e => e.IdProyectoEtapa == per.IdProyectoEtapa).ToList())
                {
                    foreach (ProyectoEtapaEstimadoPeriodoResult periodo in peer.Periodos)
                    {
                        if (dicAnios.ContainsKey(periodo.Periodo))
                        {
                            Int32 i = dicAnios[periodo.Periodo];
                            decimal val0 = row[i].ToString() == "" ? 0 : decimal.Parse(row[i].ToString());
                            decimal val1 = val0 + periodo.MontoCalculado;
                            row[i] = Math.Round(val1, 0).ToString("N0");
                            totalGral += periodo.MontoCalculado;
                        }
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }

        public DataTable ToDatatableResumenEtapasRealizadas(int p, DetalleCalidadCompose datos, ref decimal totalGral)
        {
            DataTable table = new DataTable("EtapasRealizadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Inversión Física - Descripción", typeof(string)));
            table.Columns.Add(new DataColumn("Apertura", typeof(string)));

            // Agrega las columnas
            List<Int32> aniosUtilizados = new List<int>();
            foreach (ProyectoEtapaRealizadoResult linea in datos.EtapasRealizadas)
            {
                foreach (ProyectoEtapaRealizadoPeriodoResult punto in linea.Periodos)
                {
                    if (!aniosUtilizados.Contains(punto.Periodo))
                        aniosUtilizados.Add(punto.Periodo);
                }
            }
            Dictionary<Int32, Int32> dicAnios = new Dictionary<int, int>();
            foreach (Int32 periodo in (from n in aniosUtilizados orderby n select n))
            {
                table.Columns.Add(new DataColumn(periodo.ToString(), typeof(string)));
                dicAnios.Add(periodo, table.Columns.Count - 1);
            }

            // Acumula los datos por etapa
            foreach (ProyectoEtapaResult per in datos.Etapas)
            {
                DataRow row = table.NewRow();
                row[0] = per.ID;
                row[1] = per.Nombre;
                row[2] = per.Apertura;
                foreach (ProyectoEtapaRealizadoResult peer in datos.EtapasRealizadas.Where(e => e.IdProyectoEtapa == per.IdProyectoEtapa).ToList())
                {
                    foreach (ProyectoEtapaRealizadoPeriodoResult periodo in peer.Periodos)
                    {
                        if (dicAnios.ContainsKey(periodo.Periodo))
                        {
                            Int32 i = dicAnios[periodo.Periodo];
                            decimal val0 = row[i].ToString() == "" ? 0 : decimal.Parse(row[i].ToString());
                            decimal val1 = val0 + periodo.MontoCalculado;
                            row[i] = Math.Round(val1, 0).ToString("N0");
                            totalGral += periodo.MontoCalculado;
                        }
                    }
                }
                table.Rows.Add(row);
            }

            return table;
        }
    }
}
