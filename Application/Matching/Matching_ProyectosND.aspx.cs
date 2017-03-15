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
    public partial class Matching_ProyectosND : System.Web.UI.Page
    {
        public string strAperturaPresupArchivo { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {

            /*Proceso para la carga del dropdown Jurisdiccion */

            if (!IsPostBack)
            {
                /* Proceso para la carga del Dropdown de ejercicio*/
                LlenarDropDownEjercicio();
                /*Proceso para llenar el DropDown del Mes*/
                LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));



                ddlJurisdiccion.AppendDataBoundItems = true;
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
                String strQuery = "exec [dbo].[sp_Matching_Filtro_Jurisdiccion]";
                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlJurisdiccion.DataSource = cmd.ExecuteReader();

                    ddlJurisdiccion.DataTextField = "Descripcion";
                    ddlJurisdiccion.DataValueField = "Codigo";
                    ddlJurisdiccion.DataBind();
                    ddlJurisdiccion.Items.Add("Todos");
                    ddlJurisdiccion.Items[0].Selected = true;
                    ddlJurisdiccion_SelectedIndexChanged(this, EventArgs.Empty);

                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }

            try
            {
                /* Proceso para la carga del Dropdown de ejercicio*/
                //LlenarDropDownEjercicio();
            }
            catch (Exception)
            {


            }




        }

        protected void cmdVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matching/Matching_Principal.aspx");
        }

        private void LlenarGrillaResultados()
        {

            //Obtengo Fecha última actualización

      //      lblUltimaActualizacion.Text = ObtenerUltimaActualizacion();

            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            String strQuery = "Select * from Matching_ProyectosVinculadosND";

            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdProyectosND.DataSource = sqlOrigen;
            grdProyectosND.DataBind();



            grdProyectosND.Focus();
          






        }
        protected void grdProyectosND_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            //Método para la gestión del páginado de los resultados
            grdProyectosND.PageIndex = e.NewPageIndex;

            LlenarGrillaResultadosFiltros(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);
            this.grdProyectosND.DataBind();
        }

        protected void grdProyectosND_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Metodo para setear el estilo de presentación 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.ToolTip = "Seleccionar la última fila";
            }
        }

        private void LlenarDropDownEjercicio()
        {
            //Proceso para Llenar los datos del Ejercicio
            ddlEjercicio.Items.Clear();
            ddlEjercicio.AppendDataBoundItems = true;
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "select Distinct EjercicioPresupuestario from Matching_ProyectosVinculadosND";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlEjercicio.DataSource = cmd.ExecuteReader();
                ddlEjercicio.DataTextField = "EjercicioPresupuestario";
                ddlEjercicio.DataValueField = "EjercicioPresupuestario";
                ddlEjercicio.DataBind();
                //ddlEjercicio.Items[0].Selected = true;
            }
            catch (Exception ex)
            {
                con.Close();
                con.Dispose();
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        private void LlenarDropdownMes(Int32 intEjercicioPresup)
        {

            /*Proceso para llenar el dropdown del mes*/
            ddlMes.Items.Clear();
            ddlMes.AppendDataBoundItems = true;
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "select distinct MesSidif from Matching_ProyectosVinculadosND where EjercicioPresupuestario=" + intEjercicioPresup ;
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {
                con.Open();
                ddlMes.DataSource = cmd.ExecuteReader();
                ddlMes.DataTextField = "MesSidif";
                ddlMes.DataValueField = "MesSidif";
                ddlMes.DataBind();

            }
            catch (Exception ex)
            {
                con.Close();
                con.Dispose();
            }
            finally
            {
                con.Close();
                con.Dispose();
            }

        }

        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Proceso para la carga de datos del dropdwon ddlSaf*/

            if (ddlJurisdiccion.SelectedValue == "Todos")
            {
                ddlSAF.Enabled = false;
                ddlPrograma.Enabled = false;
                ddlSubPrograma.Enabled = false;
                lblJurisdiccion.Text = "Todos";
            }

            else

            {
                ddlSAF.Enabled = true;
                ddlPrograma.Enabled = true;
                ddlSubPrograma.Enabled = true;
                /* Eliminar items de dropdowns*/
                ddlSAF.Items.Clear();
                ddlPrograma.Items.Clear();
                ddlSubPrograma.Items.Clear();


                ddlSAF.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_SAF @intIdJurisdiccion";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@intIdJurisdiccion",
                    ddlJurisdiccion.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlSAF.DataSource = cmd.ExecuteReader();
                    ddlSAF.DataTextField = "Descripcion";
                    ddlSAF.DataValueField = "Codigo";
                    ddlSAF.DataBind();
                    if (ddlSAF.Items.Count > 0)
                    {
                        ddlSAF.Enabled = true;
                        ddlSAF.Items.Add("Todos");
                        ddlSAF.Items[0].Selected = true;
                        ddlSAF_SelectedIndexChanged(this, EventArgs.Empty);
                        lblJurisdiccion.Text = ddlJurisdiccion.SelectedValue.ToString();
                    }
                    else
                    {
                        // ddlSAF.Enabled = false;
                        //ddlPrograma.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }


            }

            ddlSAF.Focus();
        }
        protected void ddlSAF_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlSAF.SelectedValue == "Todos")
            {
                ddlPrograma.Enabled = false;
                ddlSubPrograma.Enabled = false;

            }
            else
            {

                ddlPrograma.Enabled = true;


                /*Proceso para la carga de datos del dropdwon ddlPrograma*/

                /* Eliminar items de dropdowns*/
                ddlPrograma.Items.Clear();
                ddlSubPrograma.Items.Clear();
                ddlPrograma.Enabled = true;
                ddlSubPrograma.Enabled = true;

                ddlPrograma.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_Programa @CodSaf";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CodSaf",
                    ddlSAF.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlPrograma.DataSource = cmd.ExecuteReader();
                    ddlPrograma.DataTextField = "Descripcion";
                    ddlPrograma.DataValueField = "Codigo";
                    ddlPrograma.DataBind();
                    if (ddlPrograma.Items.Count > 0)
                    {
                        ddlPrograma.Enabled = true;
                        ddlPrograma.Items.Add("Todos");
                        ddlPrograma.Items[0].Selected = true;
                        ddlPrograma_SelectedIndexChanged(this, EventArgs.Empty);
                        lblSaf.Text = ddlSAF.SelectedItem.ToString();

                    }
                    else
                    {
                        //ddlPrograma.Enabled = false;
                        //ddlSubPrograma.Enabled = false;
                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }

            }


            ddlPrograma.Focus();
        }
        protected void ddlPrograma_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (ddlPrograma.SelectedValue == "Todos")
            {
                ddlSubPrograma.Enabled = false;
            }
            else
            {

                /*Proceso para la carga de datos del dropdwon ddlSubPrograma*/

                /* Eliminar items de dropdowns*/
                ddlSubPrograma.Enabled = true;
                ddlSubPrograma.Items.Clear();


                ddlSubPrograma.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_SubPrograma @CodPrograma, @CodSAF";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CodPrograma",
                    ddlPrograma.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@CodSAF", ddlSAF.SelectedValue);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlSubPrograma.DataSource = cmd.ExecuteReader();
                    ddlSubPrograma.DataTextField = "Descripcion";
                    ddlSubPrograma.DataValueField = "Codigo";
                    ddlSubPrograma.DataBind();
                    if (ddlSubPrograma.Items.Count > 0)
                    {
                        ddlSubPrograma.Enabled = true;
                        ddlSubPrograma.Items.Add("Todos");
                        ddlSubPrograma.Items[0].Selected = true;
                        lblPrograma.Text = ddlPrograma.SelectedItem.ToString();
                    }
                    else
                    {


                    }
                }
                catch (Exception ex)
                {
                    con.Close();
                    con.Dispose();
                }
                finally
                {
                    con.Close();
                    con.Dispose();
                }


            }

            ddlSubPrograma.Focus();
        }


        private void LlenarGrillaResultadosFiltros(int intEjercicio, int intMes, string CodJurisdic, string CodSaf, string CodProg, string CodSubpro)
        {
            //Proceso para llenar la grilla de resultados
           /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] " + intEjercicio + ", " + intMes + ", " + AperturaProgra;
            String strQuery = string.Empty;

            if (CodJurisdic == "Todos") //Trae todos los proyectos de todas las Jurisdicciones
            {

                strQuery = "SELECT * FROM Matching_ProyectosVinculadosND WHERE EjercicioPresupuestario = " + intEjercicio + " AND MesSidif = " + intMes;
            }
            else // En caso de selectar Una Jurisdicción 
            {

                if (CodSaf == "Todos") //Pregunta si busca todos los saf todos los SAF
                {
                    //Trae el código de Jurisdicción
                    strQuery = "SELECT * FROM Matching_ProyectosVinculadosND WHERE EjercicioPresupuestario = " + intEjercicio + " AND MesSidif = " + intMes + " AND CodJurisdiccion='" + CodJurisdic + "';";
                }
                else //Si no elige todos los SAF
                {
                    if (CodProg == "Todos") //Si elije todos los Programas
                    {
                        //Traer Código de Jurisdicción y SAF 
                        strQuery = "SELECT * FROM Matching_ProyectosVinculadosND WHERE EjercicioPresupuestario = " + intEjercicio + " AND MesSidif = " + intMes + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "';";
                    }
                    else //Valida que haya seleccionado un Programa
                    {
                        if (CodSubpro == "Todos")
                        {
                            //Traer los datos de Codigo de Jurisdicción, SAF, Programa
                            strQuery = "SELECT * FROM Matching_ProyectosVinculadosND WHERE EjercicioPresupuestario = " + intEjercicio + " AND MesSidif = " + intMes + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "' AND CodPrograma='" + CodProg + "';";

                        }
                        else
                        {
                            strQuery = "SELECT * FROM Matching_ProyectosVinculadosND WHERE EjercicioPresupuestario = " + intEjercicio + " AND MesSidif = " + intMes + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "' AND CodPrograma='" + CodProg + "' AND CodSubprograma='" + CodSubpro + "';";
                        }

                    }

                }

            }


            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdProyectosND.DataSource = sqlOrigen;
            grdProyectosND.DataBind();



            grdProyectosND.Focus();
            this.strAperturaPresupArchivo = CodJurisdic + CodSaf + CodProg + CodSubpro;
            lblAperturaPresup.Text = CodJurisdic + CodSaf + CodProg + CodSubpro;






        }

        private void ExportarExcel(string AperturaPresup)
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") + "_" + AperturaPresup + "_MatchingProyectosVinculadosND.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdProyectosND.AllowPaging = false;

                //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                //LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), strAper);
                LlenarGrillaResultadosFiltros(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                grdProyectosND.HeaderRow.BackColor = System.Drawing.Color.White;
                //grdProyectosND.Columns[9].Visible = false;

                foreach (TableCell cell in grdProyectosND.HeaderRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                }
                foreach (GridViewRow row in grdProyectosND.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdProyectosND.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdProyectosND.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdProyectosND.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";


                Response.Write(style);
                Response.Output.Write(sw.ToString());
                Response.Flush();
                Response.End();

            }
        }


        protected void cmdExportarExcel_Click(object sender, EventArgs e)
        {
            //Método para exportar a excel el resultado de la grilla
            if (grdProyectosND.Rows.Count > 0)
            {
                lblExportExcel.ForeColor = System.Drawing.Color.Green;
                lblExportExcel.Text = "Se ha descargado el archivo correctamente, por favor verifique en la carpeta de descarga de su navegador.";

                //Exporta a Excel únicamente si hay resultados
                ExportarExcel(lblAperturaPresup.Text);
              }

            else
            {
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Error", "alert('No se han encontrado registros para exportar a Excel.' );", true);
                lblExportExcel.ForeColor = System.Drawing.Color.Red;
                lblExportExcel.Text = "No se ha podido descargar el archivo, por favor intente nuevamente.";

            }


        }


        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifica que el control se haya renderizado*/
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            /* ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "alert('IdJurisd: " + ddlJurisdiccion.SelectedValue + "- IdSaf:" 
                 + ddlSAF.SelectedValue + "- IdPrograma: " + ddlPrograma.SelectedValue + " IdSubprograma: " + ddlSubPrograma.SelectedValue + "' );", true);
                 */
            try
            {
                lblAperturaPresup.Text = string.Empty;
                LlenarGrillaResultadosFiltros(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "alert('Se ha producido un error al realizar la búsqueda. Por favor intente nuevamente. Muchas Gracias' );", true);
            }



        }

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));
        }
    }
}