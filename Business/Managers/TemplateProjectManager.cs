using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using OfficeOpenXml;
using System.Data.Linq;
using Contract;
using Core;
using Business;

namespace Business.Managers
{
    public class TemplateProjectManager
    {
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
