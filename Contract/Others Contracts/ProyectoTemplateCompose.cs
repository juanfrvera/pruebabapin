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
    public class ProyectoTemplateCompose
    {
        public ProyectoResult proyecto {get;set;}
        public ProyectoEtapaResult ProyectoEtapa = new ProyectoEtapaResult();
        public OficinaResult Oficina = new OficinaResult();

        public string idProyecto
        {
            get
            {
                return proyecto.ID.ToString();
            }
        }

        public string codigo
        {
            get
            {
                return proyecto.Codigo.ToString();
            }
        }

        public string saf
        {
            get
            {
                return string.Format("{0} - {1} ({2})", proyecto.Saf_Codigo, proyecto.Saf_Nombre, proyecto.IdSAF);
            }
        }

        public string programa
        {
            get
            {
                //PROGRAMA = string.Format("{0} - {1} ({2})", x.Programa.Codigo, x.Programa.Nombre, x.Programa.IdPrograma.ToString().ToUpper()),                
                return string.Format("{0} - {1} ({2})", proyecto.Programa_Codigo, proyecto.Programa_Nombre, proyecto.IdPrograma.ToString().ToUpper());
            }
        }

        public string subPrograma
        {
            get
            {
                //SUBPROGRAMA = string.Format("{0} - {1} ({2})", x.Codigo, x.Nombre, x.IdSubPrograma.ToString().ToUpper())
                return string.Format("{0} - {1} ({2})", proyecto.SubPrograma_Codigo, proyecto.SubPrograma_Nombre, proyecto.IdSubPrograma.ToString().ToUpper());
            }
        }

        public string proyectoTipo
        {
            get
            {
                //string.Format("{0} ({1})", x.Nombre, x.IdProyectoTipo.ToString().ToUpper())
                return string.Format("{0} ({1})", proyecto.TipoProyecto_Nombre, proyecto.IdTipoProyecto.ToString().ToUpper());
            }
        }

        public string proceso
        {
            get
            {
                //string.Format("{0} ({1})", x.Nombre, x.IdProceso.ToString().ToUpper())
                return (proyecto.IdProceso.HasValue) ? string.Format("{0} ({1})", proyecto.Proceso, proyecto.IdProceso.ToString().ToUpper()) : string.Empty;
            }
        }

        public string ProyectoDenominacion
        {
            get
            {
                return proyecto.ProyectoDenominacion;
            }
        }

        public string estadoFinanciero
        {
            get
            {
                //string.Format("{0} ({1})", x.Nombre, x.IdSistemaEntidadEstado.ToString().ToUpper())
                return string.Format("{0} ({1})", proyecto.Estado_Nombre, proyecto.Estado_IdEstadoTipo.ToString().ToUpper());
            }
        }

        public string finalidadFuncion
        {
            get
            {
                //string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdFinalidadFuncion.ToString().ToUpper())
                return string.Format("{0} ({1})", proyecto.FinalidadFuncion_BreadcrumbCode, proyecto.IdFinalidadFuncion.ToString().ToUpper());
            }
        }

        public string prioridad
        {
            get
            {
               //Tipo prioridad
               //string.Format("{0} ({1})", x.Nombre, x.IdOrganismoPrioridad.ToString().ToUpper()
               return string.Format("{0} ({1})", proyecto.OrganismoPrioridad_Nombre, proyecto.IdOrganismoPrioridad.ToString().ToUpper());
            }
        }

        public string numeroPrioridad
        {
            get
            {
                return "NO IMPLEMENTADO NP";
            }
        }



        public string esPYPresup
        {
            get
            {
                return "NO IMPLEMENTADO PY";
            }
        }


        public string codigoProyecto
        {
            get
            {
                return "NO IMPLEMENTADO Cp";
            }
        }


        public string categoriaPresupuestaria
        {
            get
            {
                return "NO IMPLEMENTADO Cpre";
            }
        }

        public string codigoPresupuestario
        {
            get
            {
                return "NO IMPLEMENTADO codpre";
            }
        }

        public string descripcion
        {
            get
            {
                return "NO IMPLEMENTADO desc";
            }
        }

        public string oficina
        {
            get
            {
               //oficina
               //string.Format("{0} - ({1})", x.Descripcion, x.IdOficina.ToString().ToUpper())
                return string.Format("{0} ({1})", Oficina.Descripcion, proyecto.IdOficina_Usuario.ToString().ToUpper());
            }
        }        

        public string localizacion
        {
            get
            {
               //Localizacion
               //string.Format("{0} ({1})", x.Nombre, x.IdClasificacionGeografica.ToString().ToUpper())
               //return string.Format("{0} ({1})", proyecto.Localizacion, proyecto.Programa_IdSectorialista.ToString().ToUpper());
               return "NO IMPLEMENTADO loca " + proyecto.Localizacion;
            }
        }        

        //Cronograma de Gastos - Fase Ejecución (ingreso de fechas)			
        //Fecha Inicio Estimada	Fecha Fin Estimada	Fecha Inicio Realizada	Fecha Fin Realizada
        public DateTime? fechaInicioEstimada
        {
            get
            {
                return (ProyectoEtapa != null) ? ProyectoEtapa.FechaInicioEstimada : null;
            }
        }
        public DateTime? fechaFinEstimada
        {
            get
            {
                return (ProyectoEtapa != null) ? ProyectoEtapa.FechaFinEstimada : null;
            }
        }
        public DateTime? FechaInicioRealizada
        {
            get
            {
                return (ProyectoEtapa != null) ? ProyectoEtapa.FechaInicioRealizada : null;
            }
        }
        public DateTime? fechaFinRealizada
        {
            get
            {
                return (ProyectoEtapa != null) ? ProyectoEtapa.FechaFinRealizada : null;
            }
        } 

        public string clasificacionGasto
        {
            get
            {
               //Clasificacion del gasto
               //string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdClasificacionGasto.ToString().ToUpper())
                return "NO IMPLEMENTADO clag";
            }
        }

        public string fuenteFinanciamientoGasto
        {
            get
            {
               //Fuente Financiamiento del gasto
               //string.Format("{0} - {1} ({2})", x.BreadcrumbCode, x.Descripcion, x.IdFuenteFinanciamiento.ToString().ToUpper())
                return "NO IMPLEMENTADO ff";
            }
        }

        public string moneda
        {
            get
            {
                //Moneda
                //string.Format("{0} - ({1})", x.Nombre, x.IdMoneda.ToString().ToUpper()))
                return "NO IMPLEMENTADO mon";
            }
        }

        public string anio
        {
            get
            {
                return "NO IMPLEMENTADO an";
            }
        }

        public string monto
        {
            get
            {
                return "NO IMPLEMENTADO mon";
            }
        }
    }
}
