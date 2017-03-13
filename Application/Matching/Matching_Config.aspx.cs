using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;
using nc = Contract;
using Service;
using System.Configuration;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.IO;

namespace UI.Web.Matching
{
    public partial class Matching_Config : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrillaPeriodosDisponibles();
            LlenarGrillaPeriodosElegido();
        }

        private void LlenarGrillaPeriodosDisponibles()
        {

          /*Proceso para LLenar la grilla de periodos disponibles a la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
           
            String strQuery = "select pp.Activo,pp.IdPlanPeriodo,pp.Sigla,pp.AnioInicial,pp.AnioFinal,pt.Nombre from PlanPeriodo pp inner join PlanTipo pt on pp.IdPlanTipo=pt.IdPlanTipo where pp.IdPlanPeriodo not in (select IdPlanPeriodo from Matching_Config)";

            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdPlanPeriodoDisponibles.DataSource = sqlOrigen;
            grdPlanPeriodoDisponibles.DataBind();



            grdPlanPeriodoDisponibles.Focus();
           





        }

        private void LlenarGrillaPeriodosElegido() {

            /*Proceso para LLenar la grilla de periodos disponibles a la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

            String strQuery = "Select * from Matching_Config";

            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdPlanPeriodosElegidos.DataSource = sqlOrigen;
            grdPlanPeriodosElegidos.DataBind();



            grdPlanPeriodosElegidos.Focus();

        }
        protected void grdPlanPeriodoDisponibles_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPlanPeriodoDisponibles.PageIndex = e.NewPageIndex;
            LlenarGrillaPeriodosDisponibles();
             this.grdPlanPeriodoDisponibles.DataBind();
        }

        protected void grdPlanPeriodoDisponibles_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Función para poder agregar las columnas agrupadas "Periodos de tiempos Disponibles"
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Períodos Disponibles";
                HeaderCell.ColumnSpan = 7;
                HeaderGridRow.Cells.Add(HeaderCell);

                grdPlanPeriodoDisponibles.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

        }

        protected void grdPlanPeriodosElegidos_RowCreated(object sender, GridViewRowEventArgs e)
        {
            //Función para poder agregar las columnas agrupadas "Periodos de tiempos Disponibles"
            if (e.Row.RowType == DataControlRowType.Header)
            {
                GridView HeaderGrid = (GridView)sender;
                GridViewRow HeaderGridRow = new GridViewRow(0, 0, DataControlRowType.Header, DataControlRowState.Insert);
                TableCell HeaderCell = new TableCell();
                HeaderCell.Text = "Períodos a Procesar";
                HeaderCell.ColumnSpan = 7;
                HeaderGridRow.Cells.Add(HeaderCell);

                grdPlanPeriodosElegidos.Controls[0].Controls.AddAt(0, HeaderGridRow);

            }

        }

        protected void grdPlanPeriodoDisponibles_SelectedIndexChanged(object sender, EventArgs e)
        {


            int rowIndex = grdPlanPeriodoDisponibles.SelectedIndex;
            // string strIdentificador = grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString();

            IncorporarPlanPeriodoProcesamiento(grdPlanPeriodoDisponibles.DataKeys[rowIndex].Values[0].ToString());

        }

        private void IncorporarPlanPeriodoProcesamiento(string strIDPlanPeriodo) {

            //proceso que permite incorporar un periodo para ser considerado en el procesamiento del módulo Matching

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec [sp_Matching_Config_AgregarPeriodo] " +  Convert.ToInt64(strIDPlanPeriodo);
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {

                //Ejecuta el comando
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LlenarGrillaPeriodosElegido();
                LlenarGrillaPeriodosDisponibles();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Ok", "alert('El periodo se ha incorporado correctamente.' );", true);

            }
            catch (Exception)
            {

                con.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Error", "alert('Se ha producido un error al momento de realizar la eliminación, por favor intente nuevamente en unos instantes.' );", true);

            }



        }

        private void QuitarPlanPeriodoProcesamiento(string strIDPlanPeriodo) {

            //proceso que permite quitar un periodo para ser considerado en el procesamiento del módulo Matching

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec [sp_Matching_Config_QuitarPeriodo] " + Convert.ToInt64(strIDPlanPeriodo);
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {

                //Ejecuta el comando
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                LlenarGrillaPeriodosDisponibles();
                LlenarGrillaPeriodosElegido();

                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Ok", "alert('El periodo se ha quitado correctamente.' );", true);

            }
            catch (Exception)
            {

                con.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Error", "alert('Se ha producido un error al momento de realizar la eliminación, por favor intente nuevamente en unos instantes.' );", true);

            }



        }

        protected void grdPlanPeriodosElegidos_SelectedIndexChanged(object sender, EventArgs e)
        {
            int rowIndex = grdPlanPeriodosElegidos.SelectedIndex;
            QuitarPlanPeriodoProcesamiento(grdPlanPeriodosElegidos.DataKeys[rowIndex].Values[0].ToString());


        }

        protected void grdPlanPeriodosElegidos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdPlanPeriodosElegidos.PageIndex = e.NewPageIndex;
            LlenarGrillaPeriodosElegido();
            this.grdPlanPeriodosElegidos.DataBind();
        }
    }
}