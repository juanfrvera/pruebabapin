using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;

//Matias 20130702 - Tarea ExportTOpdf
//For converting HTML TO PDF- START
using System.Text;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using iTextSharp.text;
using iTextSharp.text.html;
using iTextSharp.text.pdf;
using iTextSharp.text.xml;
using iTextSharp.text.html.simpleparser;
using System.IO;
using System.util;
using System.Text.RegularExpressions;
//For converting HTML TO PDF- END
//FinMatias 20130702 - Tarea ExportTOpdf

namespace UI.Web.Graficos
{
    public partial class ProyectoGraficosZoom : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string graficoNro = Request.QueryString["grafico"];
                string graficoZoom = Convert.ToString(Session["Grafico" + graficoNro]);

                string leyenda = string.Empty;
                switch (graficoNro)
                {
                    case "1":
                        leyenda = "Provincia";
                        break;
                    case "2":
                        leyenda = "Fuente de Financiamiento";
                        break;
                    case "3":
                        leyenda = "Estado";
                        break;
                    case "4":
                        leyenda = "Finalidad & Función";
                        break;
                    case "5":
                        leyenda = "Proceso";
                        break;
                    case "6":
                        leyenda = "Modo Adjudicación";
                        break;
                    case "7":
                        leyenda = "Plan";
                        break;
                    case "8":
                        leyenda = "Fuente de Financiamiento";
                        break;
                    default:
                        leyenda = "Grafico";
                        break;
                }

                ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript",
                    string.Format("<script type=\"text/javascript\">drawVisualization({0},'{1}','{2}','{3}');</script>",
                    graficoZoom,
                    leyenda,
                    "Name,Value,Gender,Age",
                    "--Choose--"));

                string cantProyectos = Convert.ToString(Session["CantidadProyectos"]);
                string filtros = Convert.ToString(Session["Filtros"]);
                
                txtCantidadProyectos.Text = "Cant. Proyectos: " + cantProyectos;
                txtFiltros.Text = filtros;

                //Seteo los hidden fields para luego usarlos, de ser necesario, en el armado del PDF.
                txtCantidadProyectosHidden.Value = txtCantidadProyectos.Text;
                txtFiltrosHidden.Value = Convert.ToString(Session["FiltrosSinFormato"]);

            }
        }
        
        protected void btVolver_OnClick(object sender, EventArgs e)
        {
            //Session.Add("Grafico2", GetDataSerialized());
            //Response.Redirect(ResolveUrl("~/Proyecto/ProyectoPageList.aspx"));
        }

        protected void btImprimir_OnClick(object sender, EventArgs e)
        {

        }

    }


    

}