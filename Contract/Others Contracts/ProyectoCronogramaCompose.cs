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
    public class ProyectoCronogramaCompose
    {
        public ProyectoResult Proyecto { get; set; }
        public Int32 IdProyecto
        {
            get { return Proyecto != null ? Proyecto.IdProyecto : 0; }
        }
        public Int32 IdFase { get; set; }
        public Int32? ProyectoAnioCorriente { get; set; }
        public Int32? ProyectoAnioCorrienteEstimado { get; set; }
        public Int32? ProyectoAnioCorrienteRealizado { get; set; }
        public List<ProyectoEtapaResult> Etapas = new List<ProyectoEtapaResult>();
        public List<ProyectoEtapaEstimadoResult> EtapasEstimadas = new List<ProyectoEtapaEstimadoResult>();
        public List<ProyectoEtapaRealizadoResult> EtapasRealizadas = new List<ProyectoEtapaRealizadoResult>();
        public List<ProyectoEtapaInformacionPresupuestariaResult> EtapasInformacionPresupuestarias = new List<ProyectoEtapaInformacionPresupuestariaResult>();

        // Informacion Adicional
        public Int32 ProyectoAnioReferencia { get; set; }
        public Int32? ProyectoIdProceso { get; set; }
        public Int32? ProyectoIdTipoPlan { get; set; }

        /*
        public DataTable ToDatatableEtapasEstimadas(int idProyectoEtapa)
        {
            List<ProyectoEtapaEstimadoResult> list = EtapasEstimadas.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();
            
            DataTable table = new DataTable("EtapasEstimadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Cód.",typeof(string)));
            table.Columns.Add(new DataColumn("Obj.del Gasto",typeof(string)));
            table.Columns.Add(new DataColumn("F.Financiamiento",typeof(string)));
            
            if(list.Count > 0)
            {
                // Calcular Periodos utilizados
                List<Int32> aniosUtilizados = new List<int>();
                foreach (ProyectoEtapaEstimadoResult linea in list)
                {
                    foreach (ProyectoEtapaEstimadoPeriodoResult punto in linea.Periodos)
                    {
                        if (!aniosUtilizados.Contains(punto.Periodo)
                            && punto.MontoCalculado > 0)  /// CON ESTA LINEA SOLO PONE COLUMNAS CON MONTOS
                            aniosUtilizados.Add(punto.Periodo);
                    }
                }

                Dictionary<Int32, Int32> dicAnios = new Dictionary<int, int>();
                foreach (Int32 periodo in (from n in aniosUtilizados orderby n select n))
                {
                    table.Columns.Add(new DataColumn(periodo.ToString(), typeof(string)));
                    dicAnios.Add(periodo, table.Columns.Count - 1);
                }

                foreach (ProyectoEtapaEstimadoResult item in list)
                {
                    DataRow row = table.NewRow();
                    row[0] = item.ID;
                    row[1] = item.CodigoCompletoGasto;
                    row[2] = item.ObjetoGasto;
                    row[3] = item.FuenteFinanciemiento;
                    for (int y = 4; y < table.Columns.Count; y++)
                    {
                        row[y] = 0;
                    }


                    foreach (ProyectoEtapaEstimadoPeriodoResult periodo in item.Periodos)
                    {
                        if (dicAnios.ContainsKey(periodo.Periodo))
                        {
                            Int32 i = dicAnios[periodo.Periodo];
                            row[i] = periodo.MontoCalculado.ToString("N0");
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }
        */

        public DataTable ToDatatableEtapasEstimadasPeriodos(int idProyectoEtapa)
        {
            List<ProyectoEtapaEstimadoResult> list = EtapasEstimadas.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();

            DataTable table = new DataTable("EtapasEstimadasPeriodoso");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("ObjDelGasto", typeof(string)));
            table.Columns.Add(new DataColumn("FFinanciamiento", typeof(string)));

            /*if (list.Count > 0)
            {
                foreach (ProyectoEtapaEstimadoResult item in list)
                {
                    foreach (ProyectoEtapaEstimadoPeriodoResult periodo in item.Periodos)
                    {
                        if (periodo.Monto > 0)
                        {
                            DataRow row = table.NewRow();
                            row[0] = item.ID;
                            row[1] = item.ObjetoGasto;
                            row[2] = item.FuenteFinanciemiento;
                            row[3] = periodo.Monto;
                            table.Rows.Add(row);
                        }
                    }
                }
            }*/
            return table;
        }

        public DataTable ToDatatableEtapasInformacionPresupuestariasPeriodos(int idProyectoEtapa)
        {                                                                      
            List<ProyectoEtapaInformacionPresupuestariaResult> list = EtapasInformacionPresupuestarias.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();

            DataTable table = new DataTable("EtapasInformacionPresupuestariasPeriodoso");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("ObjDelGasto", typeof(string)));
            table.Columns.Add(new DataColumn("FFinanciamiento", typeof(string)));

            table.Columns.Add(new DataColumn("MontoInicial", typeof(string)));
            table.Columns.Add(new DataColumn("MontoVigente", typeof(string)));
            table.Columns.Add(new DataColumn("MontoDevengado", typeof(string)));
            table.Columns.Add(new DataColumn("MontoVigenteEstimativo", typeof(string)));

            if (list.Count > 0)
            {
                foreach (ProyectoEtapaInformacionPresupuestariaResult item in list)
                {
                    foreach (ProyectoEtapaInformacionPresupuestariaPeriodoResult periodo in item.Periodos)
                    {
                        if (periodo.MontoInicial > 0 || periodo.MontoVigente > 0 || periodo.MontoDevengado > 0)
                        {
                            DataRow row = table.NewRow();
                            row[0] = item.ID;
                            row[1] = item.ObjetoGasto;
                            row[2] = item.FuenteFinanciemiento;
                            row[3] = periodo.MontoInicial.ToString("N0");
                            row[4] = periodo.MontoVigente.ToString("N0");
                            row[5] = periodo.MontoDevengado.ToString("N0");
                            row[6] = periodo.MontoVigenteEstimativo;
                            table.Rows.Add(row);
                        }
                    }
                }
            }
            return table;
        }
        
        //Matias 20170214 - Ticket #REQ318684
        public DataTable ToDatatableEtapasEstimadasDinamico(int idProyectoEtapa, int filterAnio)
        {
            List<ProyectoEtapaEstimadoResult> list = EtapasEstimadas.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();

            DataTable table = new DataTable("EtapasEstimadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Cód.", typeof(string)));
            table.Columns.Add(new DataColumn("Obj.del Gasto", typeof(string)));
            table.Columns.Add(new DataColumn("F.Financiamiento", typeof(string)));

            if (list.Count > 0)
            {
                // Calcular Periodos utilizados
                List<Int32> aniosUtilizados = new List<int>();
                foreach (ProyectoEtapaEstimadoResult linea in list)
                {
                    foreach (ProyectoEtapaEstimadoPeriodoResult punto in linea.Periodos)
                    {
                        if (!aniosUtilizados.Contains(punto.Periodo)
                            && punto.MontoCalculado > 0)  /// CON ESTA LINEA SOLO PONE COLUMNAS CON MONTOS
                            aniosUtilizados.Add(punto.Periodo);
                    }
                }

                Dictionary<Int32, Int32> dicAnios = new Dictionary<int, int>();
                foreach (Int32 periodo in (from n in aniosUtilizados orderby n select n))
                {
                    table.Columns.Add(new DataColumn(periodo.ToString(), typeof(string)));
                    dicAnios.Add(periodo, table.Columns.Count - 1);
                }

                foreach (ProyectoEtapaEstimadoResult item in list)
                {
                    DataRow row = table.NewRow();
                    row[0] = item.ID;
                    row[1] = item.CodigoCompletoGasto;
                    row[2] = item.ObjetoGasto;
                    row[3] = item.FuenteFinanciemiento;
                    for (int y = 4; y < table.Columns.Count; y++)
                    {
                        row[y] = 0;
                    }

                    foreach (ProyectoEtapaEstimadoPeriodoResult periodo in item.Periodos)
                    {
                        if (dicAnios.ContainsKey(periodo.Periodo))
                        {
                            Int32 i = dicAnios[periodo.Periodo];
                            row[i] = periodo.MontoCalculado.ToString("N0");
                        }
                    }
                    table.Rows.Add(row);
                }
            }

            // Proceso table y dejo solo, de las columnas con gastos, las 4 relacionadas a los años a filtrar.
            // Columnas: filterAnio-1, filterAnio, filterAnio+1 y filterAnio+2
            DataTable tableDinamica = table.Copy();
            foreach (DataColumn column in table.Columns)
            {

                if (column.Caption != "ID" && column.Caption != "Cód." && column.Caption != "Obj.del Gasto" && column.Caption != "F.Financiamiento"
                    && column.Caption != (filterAnio - 1).ToString() && column.Caption != filterAnio.ToString() && column.Caption != (filterAnio + 1).ToString() && column.Caption != (filterAnio + 2).ToString())
                { 
                    // Elimino la columna
                    // Tengpo que eliminar la columna de que TENGA EL MISMO CAPTION!
                    tableDinamica.Columns.Remove(column.Caption);
                }
            }
            
            //return table; Matias
            return tableDinamica;
        }
        //FinMatias 20170214 - Ticket #REQ318684

        public DataTable ToDatatableEtapasRealizadas(int idProyectoEtapa)
        {
            List<ProyectoEtapaRealizadoResult> list = EtapasRealizadas.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();

            DataTable table = new DataTable("EtapasRealizadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Fecha", typeof(string)));
            table.Columns.Add(new DataColumn("Cód.",typeof(string)));
            table.Columns.Add(new DataColumn("Obj.del Gasto",typeof(string)));
            table.Columns.Add(new DataColumn("F.Financiamiento",typeof(string)));

            if (Etapas.Where(e => e.IdProyectoEtapa == idProyectoEtapa).Count() > 0)
            {
                ProyectoEtapaResult etapa = Etapas.Where(e => e.IdProyectoEtapa == idProyectoEtapa).Single();
                Int32 Desde = etapa.FechaInicioRealizada != null ? ((DateTime)etapa.FechaInicioRealizada).Year :
                              etapa.FechaInicioRealizada != null ? ((DateTime)etapa.FechaInicioRealizada).Year :
                              DateTime.Now.Year;
                Int32 Hasta = etapa.FechaFinRealizada != null ? ((DateTime)etapa.FechaFinRealizada).Year :
                              etapa.FechaFinRealizada != null ? ((DateTime)etapa.FechaFinRealizada).Year :
                              DateTime.Now.Year;
                int i = 5;
                Dictionary<int, int> columnas = new Dictionary<int, int>();
                for (Int32 anio = Desde; anio <= Hasta; anio++)
                {
                    /// CON ESTA LINEA SOLO PONE COLUMNAS CON MONTOS
                    bool conMontoEsePeriodo = list.Where(x => x.Periodos.Count == 1 && x.Periodos[0].Periodo == anio && x.Periodos[0].MontoCalculado > 0).ToList().Count > 0;
                    if (conMontoEsePeriodo)
                    {
                        table.Columns.Add(new DataColumn(anio.ToString(), typeof(string)));
                        columnas.Add(anio, i);
                        i++;
                    }
                }

                foreach (ProyectoEtapaRealizadoResult item in list)
                {
                    DataRow row = table.NewRow();
                    row[0] = item.ID;
                    row[1] = item.Fecha;
                    row[2] = item.CodigoCompletoGasto;
                    row[3] = item.ObjetoGasto;
                    row[4] = item.FuenteFinanciemiento;
                    for (int y = 5; y < table.Columns.Count; y++)
                    {
                        row[y] = 0;
                    }


                    foreach (ProyectoEtapaRealizadoPeriodoResult periodo in item.Periodos)
                    {
                        if (columnas.Count > 0)
                        {
                            int key = columnas[periodo.Periodo];
                            row[key] = periodo.MontoCalculado.ToString("N0");
                        }
                    }
                    table.Rows.Add(row);
                }
            }
            return table;
        }

        //Matias 20170215 - Ticket #REQ318684
        public DataTable ToDatatableEtapasRealizadasDinamico(int idProyectoEtapa, int filterAnio)
        {
            List<ProyectoEtapaRealizadoResult> list = EtapasRealizadas.Where(i => i.IdProyectoEtapa == idProyectoEtapa).ToList();

            DataTable table = new DataTable("EtapasRealizadas");
            table.Columns.Add(new DataColumn("ID", typeof(int)));
            table.Columns.Add(new DataColumn("Fecha", typeof(string)));
            table.Columns.Add(new DataColumn("Cód.", typeof(string)));
            table.Columns.Add(new DataColumn("Obj.del Gasto", typeof(string)));
            table.Columns.Add(new DataColumn("F.Financiamiento", typeof(string)));

            if (Etapas.Where(e => e.IdProyectoEtapa == idProyectoEtapa).Count() > 0)
            {
                ProyectoEtapaResult etapa = Etapas.Where(e => e.IdProyectoEtapa == idProyectoEtapa).Single();
                Int32 Desde = etapa.FechaInicioRealizada != null ? ((DateTime)etapa.FechaInicioRealizada).Year :
                              etapa.FechaInicioRealizada != null ? ((DateTime)etapa.FechaInicioRealizada).Year :
                              DateTime.Now.Year;
                Int32 Hasta = etapa.FechaFinRealizada != null ? ((DateTime)etapa.FechaFinRealizada).Year :
                              etapa.FechaFinRealizada != null ? ((DateTime)etapa.FechaFinRealizada).Year :
                              DateTime.Now.Year;
                int i = 5;
                Dictionary<int, int> columnas = new Dictionary<int, int>();
                for (Int32 anio = Desde; anio <= Hasta; anio++)
                {
                    /// CON ESTA LINEA SOLO PONE COLUMNAS CON MONTOS
                    bool conMontoEsePeriodo = list.Where(x => x.Periodos.Count == 1 && x.Periodos[0].Periodo == anio && x.Periodos[0].MontoCalculado > 0).ToList().Count > 0;
                    if (conMontoEsePeriodo)
                    {
                        table.Columns.Add(new DataColumn(anio.ToString(), typeof(string)));
                        columnas.Add(anio, i);
                        i++;
                    }
                }

                foreach (ProyectoEtapaRealizadoResult item in list)
                {
                    DataRow row = table.NewRow();
                    row[0] = item.ID;
                    row[1] = item.Fecha;
                    row[2] = item.CodigoCompletoGasto;
                    row[3] = item.ObjetoGasto;
                    row[4] = item.FuenteFinanciemiento;
                    for (int y = 5; y < table.Columns.Count; y++)
                    {
                        row[y] = 0;
                    }


                    foreach (ProyectoEtapaRealizadoPeriodoResult periodo in item.Periodos)
                    {
                        if (columnas.Count > 0)
                        {
                            int key = columnas[periodo.Periodo];
                            row[key] = periodo.MontoCalculado.ToString("N0");
                        }
                    }
                    table.Rows.Add(row);
                }
            }

            // Proceso table y dejo solo, de las columnas con gastos, las 3 relacionadas a los años a filtrar.
            // Columnas: filterAnio-1, filterAnio, filterAnio+1 y filterAnio+2
            DataTable tableDinamica = table.Copy();
            foreach (DataColumn column in table.Columns)
            {

                if (column.Caption != "ID" && column.Caption != "Fecha" && column.Caption != "Cód." && column.Caption != "Obj.del Gasto" && column.Caption != "F.Financiamiento"
                    && column.Caption != (filterAnio - 1).ToString() && column.Caption != filterAnio.ToString() && column.Caption != (filterAnio + 1).ToString() /*&& column.Caption != (filterAnio + 2).ToString()*/ )
                {
                    // Elimino la columna
                    // Tengpo que eliminar la columna de que TENGA EL MISMO CAPTION!
                    tableDinamica.Columns.Remove(column.Caption);
                }
            }

            //return table; Matias
            return tableDinamica;            
        }
        //FinMatias 20170215 - Ticket #REQ318684
    }

    [Serializable]
    public class CronogramaTotalPorAnio
    {
        public int Anio { get; set; }
        public decimal Estimado { get; set; }
        public decimal Realizado { get; set; }
        public string NombreFase { get; set; }
    }
}
