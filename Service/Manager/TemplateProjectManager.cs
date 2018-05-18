using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;
using OfficeOpenXml;
using System.Data.Linq;
using Contract;
using Core;
using Business;
using System.Data;
using System.Data.OleDb;
using System.Web.UI.WebControls;
using System.IO;
using System.Web;
using Business;

namespace Service
{
    public class CodigoResponse
    {
        public string CodigoInterno;
        public string CodigoBapin;
    }

    public class TemplateProjectManager
    {
        public static void UpdateProjects(int idFile, FileUpload fuArchivo)
        {
            //Save file path 
            string path = string.Concat(HttpContext.Current.Server.MapPath("~/TempFiles/"), fuArchivo.FileName);
            //Save File as Temp then you can delete it if you want 
            fuArchivo.SaveAs(path);
            string excelConnectionString = string.Format("Provider=Microsoft.ACE.OLEDB.12.0;Data Source={0};Extended Properties=Excel 8.0", path);

            //string myConnection = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=\"Excel 12.0 Xml;HDR=YES\"";
            OleDbConnection conn = new OleDbConnection(excelConnectionString);
            string strSQL = "SELECT * FROM [Proyectos$]";
            OleDbCommand cmd = new OleDbCommand(strSQL, conn);
            DataSet dataset = new DataSet();
            OleDbDataAdapter adapter = new OleDbDataAdapter(cmd);
            adapter.Fill(dataset);

            //Remove 4 row
            dataset.Tables[0].Rows.Remove(dataset.Tables[0].Rows[0]);
            dataset.Tables[0].Rows.Remove(dataset.Tables[0].Rows[0]);
            dataset.Tables[0].Rows.Remove(dataset.Tables[0].Rows[0]);
            dataset.Tables[0].Rows.Remove(dataset.Tables[0].Rows[0]);
            //dataset.Tables[0].Rows.Remove(dataset.Tables[0].Rows[0]);

            var newDataTable = dataset.Tables[0].AsEnumerable()
                                .Where(r => //(r[0] != null || r[1] != null || r[2] != null || r[3] != null || r[4] != null || r[5] != null || r[6] != null || r[7] != null || r[8] != null || r[9] != null || r[10] != null || r[11] != null || r[12] != null) && 
                                        string.Format("{0}{1}{2}{3}{4}{5}{6}{7}{8}{9}{10}{11}{12}", r[0], r[1], r[2], r[3], r[4], r[5], r[6], r[7], r[8], r[9], r[10], r[11], r[12]) != string.Empty)
                                .OrderBy(r => r[0].ToString())
                                .ThenBy(r => r[1].ToString())
                                .CopyToDataTable();

            var templateFileInfo = FileInfoBusiness.Current.GetById(idFile);

            MemoryStream stream = new MemoryStream();
            byte[] templateByte = templateFileInfo.Data.ToArray();
            stream.Write(templateByte, 0, templateByte.Length);

            //agrupar por todas las columnas que deben ser iguales
            var grupoColumnasIguales = from rowtable in newDataTable.AsEnumerable()
                          group rowtable by new
                          {
                              CodigoInterno = rowtable[0].ToString(),
                              CodigoBapin = rowtable[1].ToString(),
                              Saf = rowtable[2].ToString(),
                              Programa = rowtable[3].ToString(),
                              SubPrograma = rowtable[4].ToString(),
                              Denominacion = rowtable[5].ToString(),
                              Contribucion = rowtable[6].ToString(),
                              Etapa = rowtable[7].ToString(),
                              ModalidadContratacion = rowtable[8].ToString(),
                              FinalidadFuncion = rowtable[9].ToString(),
                              Oficina = rowtable[10].ToString(),
                              Localización = rowtable[11].ToString(),
                              EsPPP = rowtable[12].ToString(),
                              //EstadoFinanciero seria la 13 que no se agrupa
                              FechaInicioEstimada = rowtable[14].ToString(),
                              FechaFinEstimada = rowtable[15].ToString(),
                              FechaInicioRealizada = rowtable[16].ToString(),
                              FechaFinRealizada = rowtable[17].ToString(),
                          } into grp
                          select new CodigoResponse
                          {
                              CodigoInterno = grp.Key.CodigoInterno,
                              CodigoBapin = grp.Key.CodigoBapin
                          };

            //agrupar por todas las columnas que deben ser iguales y sumar objeto gasto y periodo
            var grupoColumnasObjetoGastoAnio = from rowtable in newDataTable.AsEnumerable()
                                       group rowtable by new
                                       {
                                           CodigoInterno = rowtable[0].ToString(),
                                           CodigoBapin = rowtable[1].ToString(),
                                           Saf = rowtable[2].ToString(),
                                           Programa = rowtable[3].ToString(),
                                           SubPrograma = rowtable[4].ToString(),
                                           Denominacion = rowtable[5].ToString(),
                                           Contribucion = rowtable[6].ToString(),
                                           Etapa = rowtable[7].ToString(),
                                           ModalidadContratacion = rowtable[8].ToString(),
                                           FinalidadFuncion = rowtable[9].ToString(),
                                           Oficina = rowtable[10].ToString(),
                                           Localización = rowtable[11].ToString(),
                                           EsPPP = rowtable[12].ToString(),
                                           //EstadoFinanciero seria la 13 que no se agrupa
                                           FechaInicioEstimada = rowtable[14].ToString(),
                                           FechaFinEstimada = rowtable[15].ToString(),
                                           FechaInicioRealizada = rowtable[16].ToString(),
                                           FechaFinRealizada = rowtable[17].ToString(),
                                           //
                                           ObjetoDelGasto = rowtable[18].ToString(),
                                           AnioPeriodo = rowtable[21].ToString()
                                       } into grp
                                       select new CodigoResponse
                                       {
                                           CodigoInterno = grp.Key.CodigoInterno,
                                           CodigoBapin = grp.Key.CodigoBapin
                                       };

            using (ExcelPackage package = new ExcelPackage(stream))
            {
                //Worksheet BD
                var worksheetBD = package.Workbook.Worksheets.Where(x => x.Name == "Proyectos").FirstOrDefault();

                //clean All data
                worksheetBD.Cells["A6:X20005"].Value = "";

                //fill with data ordered
                worksheetBD.Cells["A6"].LoadFromDataTable(newDataTable, false);

                worksheetBD.Cells["X4"].Value = "Procesado";
                worksheetBD.Cells["X5"].Value = string.Format("{0} {1}", DateTime.Now.ToLongDateString(), DateTime.Now.ToLongTimeString());

                //foreach
                var start = 6; //worksheetBD.Dimension.Start; start.Row;
                var end = 20005; //worksheetBD.Dimension.End; end.Row
                var dimensionEnd = worksheetBD.Dimension.End;
                const string errorValidacionIdVacios = "No se informa codigo interno ni código bapin";
                const string errorValidacionIdAmbos = "Se informa codigo interno y código bapin al mismo tiempo";
                const string errorDistintosDatosGeneralesOFechas = "Datos generales o fechas de gastos no coinciden en todas las filas del proyecto";
                const string errorDatosGeneralesObligatorios = "Datos generales obligatorios";
                const string errorEstadoFinancieroObligatorio = "Estado financiero obligatorio";                
                const string errorFechasCronogramaInvalida = "Cronograma de Gastos, fechas inválidas";
                const string errorFechasCronogramaEstimadosDatosInvalidos = "Cronograma de Gastos - Estimados, datos inválidos o incompletos";
                const string errorGastosPeriodosRepetidos = "Cronograma de Gastos - Estimados repetidos";
                const string okInsertado = "Nuevo Proyecto agregado Bapin:";
                const string okEditado = "Proyecto existente editado";
                for (int row = start; row <= end && (worksheetBD.Cells[row, 1] != null || worksheetBD.Cells[row, 2] != null); row++)
                { // Row by row...
                    
                    if (string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 1].Text) && string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 2].Text))
                    {
                        worksheetBD.Cells["X" + row].Value = errorValidacionIdVacios;
                        continue;
                    }
                    else if (!string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 1].Text) && !string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 2].Text))
                    {
                        worksheetBD.Cells["X" + row].Value = errorValidacionIdAmbos;
                        continue;
                    }

                    if (!ValidateDatosGeneralesObligatorios(worksheetBD,row))
                    {
                        worksheetBD.Cells["X" + row].Value = errorDatosGeneralesObligatorios;
                        continue;
                    }

                    if (!ValidateEstadoFinancieroObligatorio(worksheetBD, row))
                    {
                        worksheetBD.Cells["X" + row].Value = errorEstadoFinancieroObligatorio;
                        continue;
                    }

                    if (!ValidateDates(worksheetBD.Cells["O" + row].Text, worksheetBD.Cells["P" + row].Text, worksheetBD.Cells["Q" + row].Text, worksheetBD.Cells["R" + row].Text))
                    {
                        worksheetBD.Cells["X" + row].Value = errorFechasCronogramaInvalida;
                        continue;
                    }

                    if (!ValidateGastosEstimados(worksheetBD, row))
                    {
                        worksheetBD.Cells["X" + row].Value = errorFechasCronogramaEstimadosDatosInvalidos;
                        continue;
                    }

                    ProyectoResult proyectoResult = new ProyectoResult();
                    //**************** PROYECTO NUEVOS ****************//
                    if (!string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 1].Text) && string.IsNullOrWhiteSpace(worksheetBD.Cells[row, 2].Text))
                    {
                        var qProyectoIds = worksheetBD.Cells["A6:A20005"].Where(x => x.Text != null && x.Text == worksheetBD.Cells[row, 1].Text).Count();

                        //Si tengo una sola fila o todas son iguales de la A a la M y de la O a la R es porque puedo insertar
                        if (qProyectoIds == 1 || ValidateRowGroup(worksheetBD, row, grupoColumnasIguales, false))
                        {
                            if (ValidateRowGroupGastosEstimados(worksheetBD, row, qProyectoIds, grupoColumnasObjetoGastoAnio, false))
                            {
                                proyectoResult.IdProyecto = -1;
                                worksheetBD.Cells["X" + row].Value = okInsertado;// +proyectoGeneralCompose.proyecto.IdProyecto;
                            }
                            else
                            {
                                worksheetBD.Cells["X" + row].Value = errorGastosPeriodosRepetidos;
                            }
                        }
                        else
                        {
                            worksheetBD.Cells["X" + row].Value = errorDistintosDatosGeneralesOFechas;
                        }
                    }
                    else
                    {
                        //**************** PROYECTO EDITAR ****************//
                        var qProyectoCodigos = worksheetBD.Cells["B6:B20005"].Where(x => x.Text != null && x.Text == worksheetBD.Cells[row, 2].Text).Count();

                        //Si tengo una sola fila o todas son iguales de la A a la M y de la O a la R es porque puedo insertar
                        if (qProyectoCodigos == 1 || ValidateRowGroup(worksheetBD, row, grupoColumnasIguales, true))
                        {
                            if (ValidateRowGroupGastosEstimados(worksheetBD, row, qProyectoCodigos,grupoColumnasObjetoGastoAnio, true))
                            {
                                proyectoResult = ProyectoService.Current.GetResult(new ProyectoFilter() { Codigo = Int32.Parse(worksheetBD.Cells["B" + row].Text) }).FirstOrDefault();
                                worksheetBD.Cells["X" + row].Value = okEditado;
                            }
                            else
                            {
                                worksheetBD.Cells["X" + row].Value = errorGastosPeriodosRepetidos;
                            }
                        }
                        else
                        {
                            worksheetBD.Cells["X" + row].Value = errorDistintosDatosGeneralesOFechas;
                        }
                    }

                    //Armar proyecto
                    proyectoResult.IdSAF = Int32.Parse(Regex.Match(worksheetBD.Cells["C" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.IdPrograma = Int32.Parse(Regex.Match(worksheetBD.Cells["D" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.IdSubPrograma = Int32.Parse(Regex.Match(worksheetBD.Cells["E" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.ProyectoDenominacion = worksheetBD.Cells["F" + row].Text;
                    //Contribucion
                    proyectoResult.IdProceso = Int32.Parse(Regex.Match(worksheetBD.Cells["G" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    //Etapa
                    proyectoResult.IdEstado = Int32.Parse(Regex.Match(worksheetBD.Cells["H" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.IdModalidadContratacion = Int32.Parse(Regex.Match(worksheetBD.Cells["I" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.IdFinalidadFuncion = Int32.Parse(Regex.Match(worksheetBD.Cells["J" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.IdOficina_Usuario = Int32.Parse(Regex.Match(worksheetBD.Cells["K" + row].Text, @"\(([^)]*)\)").Groups[1].Value);
                    proyectoResult.EsPPP = (worksheetBD.Cells["M" + row].Text.Equals("Si")) ? true : false;

                    var localizaciones = new List<ProyectoLocalizacionResult>();
                    var firstLocalization = ProyectoLocalizacionService.Current.GetResult(new ProyectoLocalizacionFilter() { IdClasificacionGeografica = Int32.Parse(Regex.Match(worksheetBD.Cells["L" + row].Text, @"\(([^)]*)\)").Groups[1].Value) }).FirstOrDefault();
                    localizaciones.Add(firstLocalization);

                    ProyectoGeneralCompose proyectoGeneralCompose = new ProyectoGeneralCompose()
                    {
                        proyecto = proyectoResult,
                        Localizaciones = localizaciones
                    };

                    ProyectoCronogramaCompose proyectoCronogramaCompose = new ProyectoCronogramaCompose()
                    {
                        Proyecto = proyectoResult,
                    };

                    if (proyectoResult.IdProyecto <= 0)
                    {
                        //Create Project
                        //ProyectoService.Current.Add(proyectoResult.ToEntity(), null);
                    }
                    else
                    {
                        //Edit Project
                        //ProyectoService.Current.Update(proyectoResult.ToEntity(), null);
                    }
                }

                worksheetBD.Cells["N:X"].AutoFitColumns();
                templateFileInfo.Data = package.GetAsByteArray();
            }

            templateFileInfo.Date = DateTime.Now;
            FileInfoBusiness.Current.Update(templateFileInfo, null);
        }

        private static bool ValidateDatosGeneralesObligatorios(ExcelWorksheet worksheetBD, int row)
        {
            if (string.IsNullOrWhiteSpace(worksheetBD.Cells["C" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["D" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["E" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["F" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["G" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["H" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["I" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["J" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["K" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["L" + row].Text) 
                || string.IsNullOrWhiteSpace(worksheetBD.Cells["M" + row].Text))
            {
                return false;
            }
            return true;
        }

        private static bool ValidateEstadoFinancieroObligatorio(ExcelWorksheet worksheetBD, int row)
        {
            if (string.IsNullOrWhiteSpace(worksheetBD.Cells["N" + row].Text))
            {
                return false;
            }
            return true;
        }

        private static bool ValidateGastosEstimados(ExcelWorksheet worksheetBD, int row)
        {
            string objetoGasto = worksheetBD.Cells["S" + row].Text;
            string fteFinanciamiento = worksheetBD.Cells["T" + row].Text;
            string moneda = worksheetBD.Cells["U" + row].Text;
            string anio = worksheetBD.Cells["V" + row].Text; 
            string monto = worksheetBD.Cells["W" + row].Text;

            string fechaInicioEstimada = worksheetBD.Cells["O" + row].Text;
            string fechaFinEstimada = worksheetBD.Cells["P" + row].Text;
            DateTime FechaInicioEstimada = string.IsNullOrWhiteSpace(fechaInicioEstimada) ? DateTime.MinValue : DateTime.Parse(fechaInicioEstimada);
            DateTime FechaFinEstimada = string.IsNullOrWhiteSpace(fechaFinEstimada) ? DateTime.MaxValue : DateTime.Parse(fechaFinEstimada);
            
            if (string.IsNullOrWhiteSpace(objetoGasto + fteFinanciamiento + moneda + anio + monto))
            {
                return true;
            }
            else if (string.IsNullOrWhiteSpace(objetoGasto) || string.IsNullOrWhiteSpace(fteFinanciamiento) || string.IsNullOrWhiteSpace(moneda) || string.IsNullOrWhiteSpace(anio) || string.IsNullOrWhiteSpace(monto))
            {
                return false;
            }

            try
            {
                Double? _anio = Double.Parse(anio);
                Double? _monto = Double.Parse(monto);
                if (FechaInicioEstimada.Year > _anio || FechaFinEstimada.Year < _anio)
                {
                    //Periodo fuera de las fechas de inicio
                    return false;
                }

                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ValidateDates(string fechaInicioEstimada, string fechaFinEstimada, string fechaInicioRealizada, string fechaFinRealizada)
        {
            if(string.IsNullOrWhiteSpace(fechaInicioEstimada+fechaFinEstimada+fechaInicioRealizada+fechaFinRealizada))
            {
                return true;
            }

            if ( (string.IsNullOrWhiteSpace(fechaInicioEstimada) || string.IsNullOrWhiteSpace(fechaFinEstimada)) &&
                (string.IsNullOrWhiteSpace(fechaInicioRealizada) || string.IsNullOrWhiteSpace(fechaFinRealizada)))
            {
                return true;
            }

            try
            {
                DateTime? FechaInicioEstimada = string.IsNullOrWhiteSpace(fechaInicioEstimada) ? DateTime.MinValue : DateTime.Parse(fechaInicioEstimada);
                DateTime? FechaFinEstimada = string.IsNullOrWhiteSpace(fechaFinEstimada) ? DateTime.MaxValue : DateTime.Parse(fechaFinEstimada);
                DateTime? FechaInicioRealizada = string.IsNullOrWhiteSpace(fechaInicioRealizada) ? DateTime.MinValue : DateTime.Parse(fechaInicioRealizada);
                DateTime? FechaFinRealizada = string.IsNullOrWhiteSpace(fechaFinRealizada) ? DateTime.MaxValue : DateTime.Parse(fechaFinRealizada);
                if (FechaFinEstimada < FechaInicioEstimada || FechaFinRealizada < FechaInicioRealizada)
                {
                    return false;
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        private static bool ValidateRowGroup(ExcelWorksheet worksheetBD, int row, IEnumerable<CodigoResponse> grupoColumnasIguales, bool isEdit)
        {
            var index = 1;          //CodigoInterno
            if (isEdit) index = 2;  //CodigoBapin

            //Cantidad agrupada
            var queryProyectoGenerales = 0;

            if (index == 1)
            {
                //create
                queryProyectoGenerales = grupoColumnasIguales.Where(x => x.CodigoInterno == worksheetBD.Cells[row, index].Text).ToList().Count();
            }
            else
            {
                //edit
                queryProyectoGenerales = grupoColumnasIguales.Where(x => x.CodigoBapin == worksheetBD.Cells[row, index].Text).ToList().Count();
            }

            //Si tengo una sola fila o todas son iguales de la A a la M y de la O a la R es porque puedo insertar
            if (queryProyectoGenerales == 1)
            {
                return true;
            }
            return false;
        }

        private static bool ValidateRowGroupGastosEstimados(ExcelWorksheet worksheetBD, int row, int qRows, IEnumerable<CodigoResponse> grupoColumnasObjetoGastoAnio, bool isEdit)
        {
            var index = 1;          //CodigoInterno
            if (isEdit) index = 2;  //CodigoBapin

            //Cantidad agrupada
            var queryProyectoGastosEstimados = 0;

            if (index == 1)
            {
                //create
                queryProyectoGastosEstimados = grupoColumnasObjetoGastoAnio.Where(x => x.CodigoInterno == worksheetBD.Cells[row, index].Text).ToList().Count();
            }
            else
            {
                //edit
                queryProyectoGastosEstimados = grupoColumnasObjetoGastoAnio.Where(x => x.CodigoBapin == worksheetBD.Cells[row, index].Text).ToList().Count();
            }

            //los gastos-anio deben ser igual a la cantidad de filas 
            if (queryProyectoGastosEstimados == qRows)
            {
                return true;
            }
            return false;
        }

        public static void UpdateTemplateProjects(int idLastTemplateVersion)
        {
            var templateFileInfo = FileInfoBusiness.Current.GetById(idLastTemplateVersion);

                MemoryStream stream = new MemoryStream();
                byte[] templateByte = templateFileInfo.Data.ToArray();
                stream.Write(templateByte, 0, templateByte.Length);

                using (ExcelPackage package = new ExcelPackage(stream))
                {
                    //Worksheet BD
                    
                    var worksheetBD = package.Workbook.Worksheets.Where(x => x.Name == "BD").FirstOrDefault();
                    //package.Workbook.CreateVBAProject();
                    //Get new data
                    List<Programa> programas = ProgramaBusiness.Current.GetList(new ProgramaFilter() { Activo = true }).Where(s => s.Saf.Activo = true).ToList();
                    List<SubPrograma> subProgramas = SubProgramaBusiness.Current.GetList(new SubProgramaFilter() { Activo = true });
                    List<Saf> safs = SafBusiness.Current.GetList(new SafFilter() { Activo = true });
                    List<ProyectoTipo> proyectoTipos = ProyectoTipoBusiness.Current.GetList(new ProyectoTipoFilter() { Activo = true });
                    List<Proceso> procesos = ProcesoBusiness.Current.GetList(new ProcesoFilter() { Activo = true });
                    List<SistemaEntidadEstado> sistemaEntidadEstadoProyectos = SistemaEntidadEstadoBusiness.Current.GetList(new SistemaEntidadEstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto });
                    List<SistemaEntidadEstado> sistemaEntidadEstadoFinancieros = SistemaEntidadEstadoBusiness.Current.GetList(new SistemaEntidadEstadoFilter() { Activo = true, IdSistemaEntidad = (int)SistemaEntidadEnum.Proyecto_Etapa });
                    List<FinalidadFuncion> finalidadFunciones = FinalidadFuncionBusiness.Current.GetList(new FinalidadFuncionFilter() { Activo = true, Seleccionable = true });
                    List<OrganismoPrioridad> organismoPrioridades = OrganismoPrioridadBusiness.Current.GetList(new OrganismoPrioridadFilter() { Activo = true });
                    List<Oficina> oficinas = OficinaBusiness.Current.GetList(new OficinaFilter() { Activo = true, Seleccionable = true });
                    List<ClasificacionGeografica> clasificacionGeograficas = ClasificacionGeograficaBusiness.Current.GetList(new ClasificacionGeograficaFilter() { Activo = true, IdClasificacionGeograficaTipo = 1 });
                    List<ClasificacionGasto> clasificacionGastos = ClasificacionGastoBusiness.Current.GetList(new ClasificacionGastoFilter() { Activo = true, Seleccionable = true });
                    List<FuenteFinanciamiento> fuenteFinanciamientos = FuenteFinanciamientoBusiness.Current.GetList(new FuenteFinanciamientoFilter() { Activo = true, Seleccionable = true });
                    List<Moneda> monedas = MonedaBusiness.Current.GetList(new MonedaFilter() { Activo = true });
                    List<ModalidadContratacion> modalidadContrataciones = ModalidadContratacionBusiness.Current.GetList(new ModalidadContratacionFilter() { Activo = true });
                    
                    //Clear column data and reload data
                    ExcelHelper.ClearData(worksheetBD, "A2", 1);
                    ExcelHelper.ClearData(worksheetBD, "B2", 2);
                    ExcelHelper.ClearData(worksheetBD, "D2", 4);
                    ExcelHelper.ClearData(worksheetBD, "E2", 5);
                    ExcelHelper.ClearData(worksheetBD, "F2", 6);
                    ExcelHelper.ClearData(worksheetBD, "H2", 8);
                    ExcelHelper.ClearData(worksheetBD, "N2", 14);
                    ExcelHelper.ClearData(worksheetBD, "P2", 16);
                    ExcelHelper.ClearData(worksheetBD, "Q2", 17);
                    ExcelHelper.ClearData(worksheetBD, "S2", 19);
                    ExcelHelper.ClearData(worksheetBD, "U2", 21);
                    ExcelHelper.ClearData(worksheetBD, "W2", 23);
                    ExcelHelper.ClearData(worksheetBD, "Z2", 26);
                    ExcelHelper.ClearData(worksheetBD, "AE2", 31);
                    ExcelHelper.ClearData(worksheetBD, "AJ2", 36);
                    ExcelHelper.ClearData(worksheetBD, "AN2", 40);
                    ExcelHelper.ClearData(worksheetBD, "AP2", 42);

                    //Clear named ranged
                    //package.Workbook.Names = new ExcelNamedRangeCollection();

                    //A “SAF” + B “Programa”                
                    worksheetBD.Cells["A1"].Value = "SAF " + DateTime.Now.ToLongDateString();                  
                    var programaSafRange = worksheetBD.Cells["A2:A" + (programas.Count + 1)];
                    var programasOrdenados = programas.Select(x => new
                    {
                        SAF = string.Format("{0} - {1} ({2})", x.Saf.Codigo, x.Saf.Denominacion, x.IdSAF),
                        PROGRAMA = string.Format("{0} - {1} ({2})", x.Codigo, x.Nombre, x.IdPrograma.ToString().ToUpper()),
                    }).OrderBy(x => x.SAF).ThenBy(x => x.PROGRAMA);
                    programaSafRange.LoadFromCollection(programasOrdenados.Select(x => x.SAF).ToArray());
                    var programaRange = worksheetBD.Cells["B2:B" + (programas.Count + 1)];
                    programaRange.LoadFromCollection(programasOrdenados.Select(x => x.PROGRAMA).ToArray());
                    package.Workbook.Names["SAF_Relacion_S_P_SP"].Address = programaSafRange.Address;

                    //D “SAF” + E “Programa” + F “Subprograma”
                    var subProgramaSafRange = worksheetBD.Cells["D2:D" + (subProgramas.Count + 1)];
                    var subProgramaProgramaRange = worksheetBD.Cells["E2:E" + (subProgramas.Count + 1)];
                    var subProgramaRange = worksheetBD.Cells["F2:F" + (subProgramas.Count + 1)];
                    var subprogramasOrdenados = subProgramas.Select(x => new
                    {
                        SAF = string.Format("{0} - {1} ({2})", x.Programa.Saf.Codigo, x.Programa.Saf.Denominacion, x.Programa.IdSAF.ToString().ToUpper()),
                        PROGRAMA = string.Format("{0} - {1} ({2})", x.Programa.Codigo, x.Programa.Nombre, x.Programa.IdPrograma.ToString().ToUpper()),
                        SUBPROGRAMA = string.Format("{0} - {1} ({2})", x.Codigo, x.Nombre, x.IdSubPrograma.ToString().ToUpper())
                    }).OrderBy(x => x.SAF).ThenBy(x => x.PROGRAMA).ThenBy(x => x.SUBPROGRAMA);
                    subProgramaSafRange.LoadFromCollection(subprogramasOrdenados.Select(x => x.SAF).ToArray());
                    subProgramaProgramaRange.LoadFromCollection(subprogramasOrdenados.Select(x => x.PROGRAMA).ToArray());
                    subProgramaRange.LoadFromCollection(subprogramasOrdenados.Select(x => x.SUBPROGRAMA).ToArray());
                    package.Workbook.Names["Programa_Relacion_P_S"].Address = subProgramaProgramaRange.Address;

                    //H “SAF”
                    var safRange = worksheetBD.Cells["H2:H" + (safs.Count + 1)];
                    var safValues = safs.Select(x => string.Format("{0} - {1} ({2})", x.Codigo, x.Denominacion, x.IdSaf.ToString().ToUpper())).OrderBy(x => x).ToArray();
                    safRange.LoadFromCollection(safValues);
                    package.Workbook.Names["SAF"].Address = safRange.Address;

                    //La imputacion presupuestaria es autocalculada 
                    //N “ImputacionPresupuestaria” “ex TipoProyecto”.
                    //var proyectoTipoRange = worksheetBD.Cells["N2:N" + (proyectoTipos.Count + 1)];
                    //var proyectoTipoValues = proyectoTipos.Select(x => string.Format("{0} ({1})", x.Nombre, x.IdProyectoTipo.ToString().ToUpper())).OrderBy(x => x).ToArray();
                    //proyectoTipoRange.LoadFromCollection(proyectoTipoValues);
                    //package.Workbook.Names["TipoProyecto"].Address = proyectoTipoRange.Address;

                    //La imputacion presupuestaria es autocalculada 
                    //N “ModalidadDeContratacion”.
                    var modalidadDeContratacionRange = worksheetBD.Cells["N2:N" + (modalidadContrataciones.Count + 1)];
                    var modalidadDeContratacionValues = modalidadContrataciones.Select(x => string.Format("{0} ({1})", x.Nombre, x.IdModalidadContratacion.ToString().ToUpper())).OrderBy(x => x).ToArray();
                    modalidadDeContratacionRange.LoadFromCollection(modalidadDeContratacionValues);
                    package.Workbook.Names["ModalidadDeContratacion"].Address = modalidadDeContratacionRange.Address;

                    //P “Etapa”.
                    var sistemaEntidadEstadoProyectoRange = worksheetBD.Cells["P2:P" + (sistemaEntidadEstadoProyectos.Count + 1)];
                    var sistemaEntidadEstadoProyectoValues = sistemaEntidadEstadoProyectos.Select(x => string.Format("{0} ({1})", x.Nombre, x.IdEstado.ToString().ToUpper())).OrderBy(x => x).ToArray();
                    sistemaEntidadEstadoProyectoRange.LoadFromCollection(sistemaEntidadEstadoProyectoValues);
                    package.Workbook.Names["Etapa"].Address = sistemaEntidadEstadoProyectoRange.Address;

                    //Q “Proceso” (antes enganchado conP “TipoProyecto”)
                    var procesosOrdenados = procesos.Select(x => new
                    {
                        //TIPOPROYECTO = string.Format("{0} ({1})", x.ProyectoTipo.Nombre, x.ProyectoTipo.IdProyectoTipo.ToString().ToUpper()),
                        PROCESO = string.Format("{0} ({1})", x.Nombre, x.IdProceso.ToString().ToUpper()),
                    }).OrderBy(x => x.PROCESO); //x => x.TIPOPROYECTO).ThenBy(
                    //var procesosProyectoTipoRange = worksheetBD.Cells["P2:P" + (procesos.Count + 1)];
                    //procesosProyectoTipoRange.LoadFromCollection(procesosOrdenados.Select(x => x.TIPOPROYECTO).ToArray());
                    var procesoRange = worksheetBD.Cells["Q2:Q" + (procesos.Count + 1)];
                    procesoRange.LoadFromCollection(procesosOrdenados.Select(x => x.PROCESO).ToArray());
                    package.Workbook.Names["Contribucion"].Address = procesoRange.Address;
                    //package.Workbook.Names["TipoProyecto_Relacion_TP_P"].Address = procesosProyectoTipoRange.Address;
                    
                    //S “EstadoFinanciero”.
                    var sistemaEntidadEstadoFinancieroRange = worksheetBD.Cells["S2:S" + (sistemaEntidadEstadoFinancieros.Count + 1)];
                    var sistemaEntidadEstadoFinancieroValues = sistemaEntidadEstadoFinancieros.Select(x => string.Format("{0} ({1})", x.Nombre, x.IdEstado.ToString().ToUpper())).OrderBy(x => x).ToArray();
                    sistemaEntidadEstadoFinancieroRange.LoadFromCollection(sistemaEntidadEstadoFinancieroValues);
                    package.Workbook.Names["EstadoFinanciero"].Address = sistemaEntidadEstadoFinancieroRange.Address;

                    //U “FinalidadFuncion”.
                    var finalidadFuncionesRange = worksheetBD.Cells["U2:U" + (finalidadFunciones.Count + 1)];
                    var finalidadFuncionesValues = finalidadFunciones.OrderBy(x => x.BreadcrumbCode).Select(x => string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdFinalidadFuncion.ToString().ToUpper())).ToArray();
                    finalidadFuncionesRange.LoadFromCollection(finalidadFuncionesValues);
                    package.Workbook.Names["FinalidadFuncion"].Address = finalidadFuncionesRange.Address;

                    //W “Prioridad”.
                    var organismoPrioridadesRange = worksheetBD.Cells["W2:W" + (organismoPrioridades.Count + 1)];
                    var organismoPrioridadesValues = organismoPrioridades.OrderBy(x => x.Nombre).Select(x => string.Format("{0} ({1})", x.Nombre, x.IdOrganismoPrioridad.ToString().ToUpper())).ToArray();
                    organismoPrioridadesRange.LoadFromCollection(organismoPrioridadesValues);
                    package.Workbook.Names["Prioridad"].Address = organismoPrioridadesRange.Address;

                    //Z “Oficina”.
                    var oficinasRange = worksheetBD.Cells["Z2:Z" + (oficinas.Count + 1)];
                    var oficinasValues = oficinas.OrderBy(x => x.Descripcion).Select(x => string.Format("{0} ({1})", x.Descripcion, x.IdOficina.ToString().ToUpper())).ToArray();
                    oficinasRange.LoadFromCollection(oficinasValues);
                    package.Workbook.Names["Oficina"].Address = oficinasRange.Address;

                    //AE “ClasificacionGeografica”.                   
                    var clasificacionGeograficasRange = worksheetBD.Cells["AE2:AE" + (clasificacionGeograficas.Count + 1)];
                    var clasificacionGeograficasValues = clasificacionGeograficas.OrderBy(x => x.Nombre).Select(x => string.Format("{0} ({1})", x.Nombre, x.IdClasificacionGeografica.ToString().ToUpper())).ToArray();
                    clasificacionGeograficasRange.LoadFromCollection(clasificacionGeograficasValues);
                    package.Workbook.Names["ClasificacionGeografica"].Address = clasificacionGeograficasRange.Address;

                    //AJ “ClasificacionGasto”.                   
                    var clasificacionGastosRange = worksheetBD.Cells["AJ2:AJ" + (clasificacionGastos.Count + 1)];
                    var clasificacionGastosValues = clasificacionGastos.OrderBy(x => x.BreadcrumbCode).Select(x => string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdClasificacionGasto.ToString().ToUpper())).ToArray();
                    clasificacionGastosRange.LoadFromCollection(clasificacionGastosValues);
                    package.Workbook.Names["ClasificacionGasto"].Address = clasificacionGastosRange.Address;

                    //AN “FuenteFinanciamiento”.                    
                    var fuenteFinanciamientosRange = worksheetBD.Cells["AN2:AN" + (fuenteFinanciamientos.Count + 1)];
                    var fuenteFinanciamientosValues = fuenteFinanciamientos.OrderBy(x => x.BreadcrumbCode).Select(x => string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdFuenteFinanciamiento.ToString().ToUpper())).ToArray();
                    fuenteFinanciamientosRange.LoadFromCollection(fuenteFinanciamientosValues);
                    package.Workbook.Names["FuenteFinanciamiento"].Address = fuenteFinanciamientosRange.Address;

                    //AP “Moneda”.                      
                    var monedasRange = worksheetBD.Cells["AP2:AP" + (monedas.Count + 1)];
                    var monedasValues = monedas.OrderBy(x => x.Nombre).Select(x => string.Format("{0} ({1})", x.Nombre, x.IdMoneda.ToString().ToUpper())).ToArray();
                    monedasRange.LoadFromCollection(monedasValues);
                    package.Workbook.Names["Moneda"].Address = monedasRange.Address;

                    templateFileInfo.Data = package.GetAsByteArray();
                }

                templateFileInfo.Date = DateTime.Now;
                FileInfoBusiness.Current.Update(templateFileInfo, null);
        }    
    }
}
