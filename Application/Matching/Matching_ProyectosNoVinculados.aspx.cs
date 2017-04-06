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
    public partial class Matching_ProyectosNoVinculados : System.Web.UI.Page
    {
        string strAperturaPresupArchivo = "";
        protected void Page_Load(object sender, EventArgs e)
        {
            /*Proceso para la carga del dropdown Jurisdiccion */

            if (!IsPostBack)
            {
                /* Proceso para la carga del Dropdown de ejercicio*/
                LlenarDropDownEjercicio();
                LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));



                ddlJurisdiccion.AppendDataBoundItems = true;
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
                String strQuery = "exec [sp_Matching_Filtro_NoVinculado_Jurisdiccion]";
                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlJurisdiccion.Items.Add("Todos");
                    ddlJurisdiccion.DataSource = cmd.ExecuteReader();
                    ddlJurisdiccion.DataTextField = "Descripcion";
                    ddlJurisdiccion.DataValueField = "CodJurisdiccion";
                    ddlJurisdiccion.DataBind();
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

            

        }

        protected void ddlJurisdiccion_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*Proceso para la carga de datos del dropdwon ddlSaf*/


            if (ddlJurisdiccion.SelectedValue == "Todos")
            {
                ddlSAF.Enabled = false;
                ddlPrograma.Enabled = false;
                ddlSubPrograma.Enabled = false;
                //lblJurisdiccion.Text = "Todo";
            }

            else

            {
                /* Eliminar items de dropdowns*/
                ddlSAF.Items.Clear();
                ddlPrograma.Items.Clear();
                ddlSubPrograma.Items.Clear();


                ddlSAF.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_NoVinculado_SAF @CodJurisdiccion";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CodJurisdiccion",
                    ddlJurisdiccion.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlSAF.DataSource = cmd.ExecuteReader();
                    ddlSAF.DataTextField = "Descripcion";
                    ddlSAF.DataValueField = "CodSaf";
                    ddlSAF.DataBind();
                    if (ddlSAF.Items.Count > 0)
                    {
                        ddlSAF.Items.Add("Todos");
                        ddlSAF.Enabled = true;
                        ddlSAF.Items[0].Selected = true;
                        ddlSAF_SelectedIndexChanged(this, EventArgs.Empty);

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

            /*Proceso para la carga de datos del dropdwon ddlPrograma*/

            if (ddlSAF.SelectedValue == "Todos")
            {
                ddlPrograma.Enabled = false;
                ddlSubPrograma.Enabled = false;

            }
            else
            {

                ddlPrograma.Enabled = true;
                /* Eliminar items de dropdowns*/
                ddlPrograma.Items.Clear();
                ddlSubPrograma.Items.Clear();
                ddlPrograma.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_NoVinculado_Programa @CodSAF";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CodSAF",
                    ddlSAF.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlPrograma.DataSource = cmd.ExecuteReader();
                    ddlPrograma.DataTextField = "Descripcion";
                    ddlPrograma.DataValueField = "CodPrograma";
                    ddlPrograma.DataBind();
                    if (ddlPrograma.Items.Count > 0)
                    {
                        ddlPrograma.Items.Add("Todos");
                        ddlPrograma.Enabled = true;
                        ddlPrograma.Items[0].Selected = true;
                        ddlPrograma_SelectedIndexChanged(this, EventArgs.Empty);
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


            /*Proceso para la carga de datos del dropdwon ddlSubPrograma*/
            if (ddlPrograma.SelectedValue == "Todos")
            {
                ddlSubPrograma.Enabled = false;
            }
            else
            {



                /* Eliminar items de dropdowns*/

                ddlSubPrograma.Items.Clear();
                ddlSubPrograma.Enabled = true;

                ddlSubPrograma.AppendDataBoundItems = true;

                String strQuery = "exec sp_Matching_Filtro_NoVinculado_SubPrograma @CodPrograma";
                string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;

                SqlConnection con = new SqlConnection(strConexion);
                SqlCommand cmd = new SqlCommand();
                cmd.Parameters.AddWithValue("@CodPrograma",
                    ddlPrograma.SelectedItem.Value);
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = strQuery;
                cmd.Connection = con;
                try
                {
                    con.Open();
                    ddlSubPrograma.DataSource = cmd.ExecuteReader();
                    ddlSubPrograma.DataTextField = "Descripcion";
                    ddlSubPrograma.DataValueField = "CodSubprograma";
                    ddlSubPrograma.DataBind();
                    if (ddlSubPrograma.Items.Count > 0)
                    {
                        ddlSubPrograma.Items.Add("Todos");
                        ddlSubPrograma.Enabled = true;
                        ddlSubPrograma.Items[0].Selected = true;

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

                
                ddlSubPrograma.Focus();
            }
        }


        private void LlenarDropDownEjercicio()
        {
            //Proceso para Llenar los datos del Ejercicio
            ddlEjercicio.Items.Clear();
            ddlEjercicio.AppendDataBoundItems = true;
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "select Distinct EjercicioPresupuestario from Matching_InfoPresupuestoAgrupado order by 1 DESC";
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
                ddlEjercicio.Items[0].Selected = true;
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

        private void LlenarDropdownMes(Int32 intEjercicioPresupuestario)
        {

            /*Proceso para llenar el dropdown del mes*/
            ddlMes.Items.Clear();
            ddlMes.AppendDataBoundItems = true;
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "select distinct MesSidif from Matching_InfoPresupuestoAgrupado where EjercicioPresupuestario=" + intEjercicioPresupuestario + "order by 1 DESC";
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
                ddlMes.Items[1].Selected = true;
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

        private string ObtenerUltimaActualizacion()
        {
            /*Proceso para obtener la fecha de la última actualización*/

            string strUltAct = string.Empty;


            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "select MAX(FechaActualizacion) as FechaUltimaActualizacion from [Matching_RegistroActualizacionProceso]";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader sqlLector = cmd.ExecuteReader();

                if (sqlLector.HasRows)
                {
                    while (sqlLector.Read())
                    {
                        strUltAct = sqlLector[0].ToString();
                    }

                }

                else
                {
                    strUltAct = "-";
                }
                sqlLector.Close();


            }
            catch (Exception ex)
            {
                strUltAct = "-";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return strUltAct;

        }

        protected void cmdMatchingVinculados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Matching_Principal.aspx");
        }

        private string ObtenerAperturaPresupuestariaFiltro(string intIdJurisdiccion, string intIdSaf, string intIdPrograma, string intIDSubprograma)
        {
            string strApertura = string.Empty;


            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "EXEC sp_Matching_Filtro_AperturaPresupuestaria " + intIdJurisdiccion + ", " + intIdSaf + ", " + intIdPrograma + ", " + (string.IsNullOrEmpty(intIDSubprograma) ? "-" : intIDSubprograma);
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;

            try
            {
                con.Open();
                SqlDataReader sqlLector = cmd.ExecuteReader();

                if (sqlLector.HasRows)
                {
                    while (sqlLector.Read())
                    {
                        strApertura = sqlLector.GetString(0);
                    }

                }

                else
                {
                    strApertura = "#";
                }
                sqlLector.Close();


            }
            catch (Exception ex)
            {
                strApertura = "#";
            }
            finally
            {
                con.Close();
                con.Dispose();
            }
            return strApertura;
        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {

            try
            {
                //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue,ddlSAF.SelectedValue,ddlPrograma.SelectedValue,ddlSubPrograma.SelectedValue);

            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "alert('Se ha producido un error al realizar la búsqueda. Por favor intente nuevamente. Muchas Gracias' );", true);
            }
          
        }

        protected void grdProyectosAutomatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Método que se utiliza para vincular el proyecto 


            int rowIndex = grdProyectosAutomatch.SelectedIndex;
            Response.Redirect("Matching_VinculacionManual.aspx?IdentUnicoSidif=" + grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString());
         //   lblID.Text = grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString();

            // string strIdentificador = grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString();

            // DesvincularProyecto(grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString());


        }
        private void LlenarGrillaResultados(int intEjercicio, int intMes, string CodJurisdic, string CodSaf, string CodProg, string CodSubpro)
        {

            //Obtengo Fecha última actualización

            lblUltimaActualizacion.Text = ObtenerUltimaActualizacion();

            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            String strQuery = string.Empty;

            if (CodJurisdic == "Todos") //Trae todos los proyectos de todas las Jurisdicciones
            {

                strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in  (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados) AND IdentificadorProyectoSidif not in (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculadosND)  AND MesSidif = " + intMes + " AND EjercicioPresupuestario =" + intEjercicio + ";";
            }
            else // En caso de selectar Una Jurisdicción 
            {

                if (CodSaf == "Todos") //Pregunta si busca todos los saf todos los SAF
                {
                    //Trae el código de Jurisdicción
                    strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in  (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados) AND IdentificadorProyectoSidif not in (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculadosND)  AND MesSidif = " + intMes + " AND EjercicioPresupuestario =" + intEjercicio + " AND CodJurisdiccion='" + CodJurisdic + "';";
                }
                else //Si no elige todos los SAF
                {
                    if (CodProg == "Todos") //Si elije todos los Programas
                    {
                        //Traer Código de Jurisdicción y SAF 
                        strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in  (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados) AND IdentificadorProyectoSidif not in (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculadosND)  AND MesSidif = " + intMes + " AND EjercicioPresupuestario =" + intEjercicio + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "';";
                    }
                    else //Valida que haya seleccionado un Programa
                    {
                        if (CodSubpro == "Todos")
                        {
                            //Traer los datos de Codigo de Jurisdicción, SAF, Programa
                            strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in  (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados) AND IdentificadorProyectoSidif not in (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculadosND)  AND MesSidif = " + intMes + " AND EjercicioPresupuestario =" + intEjercicio + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "' AND CodPrograma='" + CodProg + "';";

                        }
                        else
                        {
                            strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where IdentificadorProyectoSidif not in  (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculados) AND IdentificadorProyectoSidif not in (SELECT  IdentificadorProyectoSidif FROM Matching_ProyectosVinculadosND)  AND MesSidif = " + intMes + " AND EjercicioPresupuestario =" + intEjercicio + " AND CodJurisdiccion='" + CodJurisdic + "' AND CodSAF='" + CodSaf + "' AND CodPrograma='" + CodProg + "' AND CodSubprograma='" + CodSubpro + "';";
                        }

                    }

                }
            }

                SqlDataSource sqlOrigen = new SqlDataSource();
                this.Page.Controls.Add(sqlOrigen);
                sqlOrigen.ConnectionString = strConexion;
                sqlOrigen.SelectCommand = strQuery;

                grdProyectosAutomatch.DataSource = sqlOrigen;
                grdProyectosAutomatch.DataBind();

                grdProyectosAutomatch.Focus();
                strAperturaPresupArchivo = CodJurisdic + CodSaf + CodProg + CodSubpro;
            }
        


        protected void grdProyectosAutomatch_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //Metodo para setear el estilo de presentación 
            if (e.Row.RowType == DataControlRowType.DataRow)
            {

                e.Row.ToolTip = "Seleccionar la última fila";
            }
        }

        protected void grdProyectosAutomatch_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            //Método para la gestión del páginado de los resultados
            grdProyectosAutomatch.PageIndex = e.NewPageIndex;
            //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

            LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue,ddlPrograma.SelectedValue,ddlSubPrograma.SelectedValue);
            this.grdProyectosAutomatch.DataBind();
        }



        private void ExportarExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") +"_" + strAperturaPresupArchivo +"_MatchingProyectosNoVinculados.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdProyectosAutomatch.AllowPaging = false;

                //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue), Convert.ToInt32(ddlMes.SelectedValue), ddlJurisdiccion.SelectedValue,ddlSAF.SelectedValue,ddlPrograma.SelectedValue,ddlSubPrograma.SelectedValue);

                grdProyectosAutomatch.HeaderRow.BackColor = System.Drawing.Color.White;
                grdProyectosAutomatch.Columns[13].Visible = false;

                foreach (TableCell cell in grdProyectosAutomatch.HeaderRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                }
                foreach (GridViewRow row in grdProyectosAutomatch.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdProyectosAutomatch.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdProyectosAutomatch.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdProyectosAutomatch.RenderControl(hw);

                //style to format numbers to string
                string style = @"<style> .textmode { } </style>";
                Response.Write(style);
                Response.Output.Write(sw.ToString());
                lblExportExcel.ForeColor = System.Drawing.Color.Green;
                lblExportExcel.Text = "Se ha descargado el archivo correctamente. Podrá encontrarlo en el directorio descargas de su navegador. ";
                lblExportExcel.Visible = true;
                Response.Flush();
                Response.End();
                
              
            }
        }


        protected void cmdExportarExcel_Click(object sender, EventArgs e)
        {
            //Método para exportar a excel el resultado de la grilla
            if (grdProyectosAutomatch.Rows.Count > 0)
            {
                //Exporta a Excel únicamente si hay resultados
                ExportarExcel();
              

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

        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));
        }
    }
}