using System;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.Script.Serialization;

namespace UI.Web.Graficos
{
    public partial class ProyectoGraficos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           if (!IsPostBack)
           {
               string grafico1 = Convert.ToString(Session["Grafico1"]);
               string grafico2 = Convert.ToString(Session["Grafico2"]);
               string grafico3 = Convert.ToString(Session["Grafico3"]);
               string grafico4 = Convert.ToString(Session["Grafico4"]);
               string grafico5 = Convert.ToString(Session["Grafico5"]);
               string grafico6 = Convert.ToString(Session["Grafico6"]);
               string grafico7 = Convert.ToString(Session["Grafico7"]);
               string grafico8 = Convert.ToString(Session["Grafico8"]);
               
               //Acomodo, en caso que existan, las tortas vacias.
               //En caso que no haya resultados les agrego un valor por default para poder levantar la torta.
               if (grafico1.Equals("[]"))
               {
                   grafico1 = "[{\"ColumnName\":\"Sin Provincias\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico2.Equals("[]"))
               {
                   grafico2 = "[{\"ColumnName\":\"Sin Localizaciones\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico3.Equals("[]"))
               {
                   grafico3 = "[{\"ColumnName\":\"Sin Estados\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico4.Equals("[]"))
               {
                   grafico4 = "[{\"ColumnName\":\"Sin Finalidades\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico5.Equals("[]"))
               {
                   grafico5 = "[{\"ColumnName\":\"Sin Procesos\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico6.Equals("[]"))
               {
                   grafico6 = "[{\"ColumnName\":\"Sin Adjudicaciones\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico7.Equals("[]"))
               {
                   grafico7 = "[{\"ColumnName\":\"Sin Planes\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }
               if (grafico8.Equals("[]"))
               {
                   grafico8 = "[{\"ColumnName\":\"Sin Fuentes de Financiamientos\",\"Value1\":1,\"Value2\":\"\",\"Value3\":0}]";
               }

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript",
                    string.Format("<script type=\"text/javascript\">drawVisualization({0},'{1}','{2}','{3}');</script>",
                    grafico1,
                    "Text Example",
                    "Name,Value,Gender,Age",
                    "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript2",
                   string.Format("<script type=\"text/javascript\">drawVisualization2({0},'{1}','{2}','{3}');</script>",
                   grafico2,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript3",
                   string.Format("<script type=\"text/javascript\">drawVisualization3({0},'{1}','{2}','{3}');</script>",
                   grafico3,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript4",
                   string.Format("<script type=\"text/javascript\">drawVisualization4({0},'{1}','{2}','{3}');</script>",
                   grafico4,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript5",
                   string.Format("<script type=\"text/javascript\">drawVisualization5({0},'{1}','{2}','{3}');</script>",
                   grafico5,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript6",
                   string.Format("<script type=\"text/javascript\">drawVisualization6({0},'{1}','{2}','{3}');</script>",
                   grafico6,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript7",
                   string.Format("<script type=\"text/javascript\">drawVisualization7({0},'{1}','{2}','{3}');</script>",
                   grafico7,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));

               ClientScript.RegisterStartupScript(this.GetType(), "TestInitPageScript8",
                   string.Format("<script type=\"text/javascript\">drawVisualization8({0},'{1}','{2}','{3}');</script>",
                   grafico8,
                   "Text Example",
                   "Name,Value,Gender,Age",
                   "--Choose--"));
               
               //German 20130615 - Tarea 69
               string cantProyectos = Convert.ToString(Session["CantidadProyectos"]);
               string filtros = Convert.ToString(Session["Filtros"]);
               
               txtCantidadProyectos.Text = "Cant. Proyectos: " + cantProyectos;
               txtFiltros.Text = filtros;
               //Fin German 20130615 - Tarea 69

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

        protected void btExportar_OnClick(object sender, EventArgs e)
        {
            
        }
    }

    public class DataItem
    {
        #region Internal Members

        private string _ColumnName = "";
        private double _Value1 = 0;
        private string _Value2 = null;
        private int _Value3 = 0;

        #endregion

        #region Public Properties

        public string ColumnName
        {
            get { return _ColumnName; }
            set { _ColumnName = value; }
        }
        public double Value1
        {
            get { return _Value1; }
            set { _Value1 = value; }
        }
        public string Value2
        {
            get { return _Value2; }
            set { _Value2 = value; }
        }
        public int Value3
        {
            get { return _Value3; }
            set { _Value3 = value; }
        }

        #endregion

        #region Constructors

        public DataItem(string columnName, double value1, string value2, int value3)
        {
            _ColumnName = columnName;
            _Value1 = value1;
            _Value2 = value2;
            _Value3 = value3;
        }

        #endregion
    }
}


