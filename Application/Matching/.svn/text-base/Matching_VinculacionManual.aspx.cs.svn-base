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
    public partial class Matching_VinculacionManual : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {


            /*Proceso para la carga del dropdown Jurisdiccion */

            if (!IsPostBack)
            {


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



        protected void cmdMatchingVinculados_Click(object sender, EventArgs e)
        {
            Response.Redirect("Matching_ProyectosNoVinculados.aspx");
        }

        private void LlenarGrillaResultados()
        {

            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            String strQuery = "select * from Matching_tmpProyectosCandidatos";

            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdProyectosAutomatch.DataSource = sqlOrigen;
            grdProyectosAutomatch.DataBind();



            grdProyectosAutomatch.Focus();





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

            LlenarGrillaResultados();
            this.grdProyectosAutomatch.DataBind();
        }


        protected void grdProyectosAutomatch_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Método que se utiliza para vincular el proyecto 


            int rowIndex = grdProyectosAutomatch.SelectedIndex;
            string IdentUnico = Request.QueryString["IdentUnicoSidif"].ToString();

            VincularProyectoManual(IdentUnico, Convert.ToInt32(grdProyectosAutomatch.DataKeys[rowIndex].Values[0].ToString()));





        }


        private void VincularProyectoManual(string IdentSifi, int CodBapin) {
            //Método que realiza la vinculación de manera manual
            //para ello utiliza el store procedure [sp_Matching_VincularProyecto]


            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec [sp_Matching_VincularProyecto] '" + IdentSifi + "'," + CodBapin + "," + UIContext.Current.ContextUser.User.IdUsuario;
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
                con.Close();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Ok", "alert('El proyecto se ha vinculado correctamente.' );", true);
                Response.Redirect("Matching_ProyectosNoVinculados.aspx");

            }
            catch (Exception)
            {

                con.Dispose();
                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje Error", "alert('Se ha producido un error al momento de realizar la vinculación, por favor intente nuevamente en unos instantes.' );", true);
                Response.Redirect("Matching_ProyectosNoVinculados.aspx");
            }


        }

        protected void cmdBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                //LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue),Convert.ToInt32(ddlMes.SelectedValue) ,strAper);

                LlenarGrillaResultadosFiltros(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "alert('Se ha producido un error al realizar la búsqueda. Por favor intente nuevamente. Muchas Gracias' );", true);
            }



        }




        private void LlenarGrillaResultadosFiltros(string CodJurisdic, string CodSaf, string CodProg, string CodSubpro)
        {
            //Proceso para llenar la grilla de resultados



            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] " + intEjercicio + ", " + intMes + ", " + AperturaProgra;
            String strQuery = string.Empty;

            if (CodJurisdic == "Todos") //Trae todos los proyectos de todas las Jurisdicciones
            {

                strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos";
            }
            else // En caso de selectar Una Jurisdicción 
            {

                if (CodSaf == "Todos") //Pregunta si busca todos los saf todos los SAF
                {
                    //Trae el código de Jurisdicción
                    strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos WHERE CodigoJurisdiccion='" + CodJurisdic + "';";
                }
                else //Si no elige todos los SAF
                {
                    if (CodProg == "Todos") //Si elije todos los Programas
                    {
                        //Traer Código de Jurisdicción y SAF 
                        strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos WHERE CodigoJurisdiccion='" + CodJurisdic + "' AND CodigoSAF='" + CodSaf + "';";
                    }
                    else //Valida que haya seleccionado un Programa
                    {
                        if (CodSubpro == "Todos")
                        {
                            //Traer los datos de Codigo de Jurisdicción, SAF, Programa
                            strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos WHERE CodigoJurisdiccion='" + CodJurisdic + "' AND CodigoSAF='" + CodSaf + "' AND CodigoPrograma='" + CodProg + "';";

                        }
                        else
                        {
                            strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos WHERE CodigoJurisdiccion='" + CodJurisdic + "' AND CodigoSAF='" + CodSaf + "' AND CodigoPrograma='" + CodProg + "' AND CodigoSubprograma='" + CodSubpro + "';";
                        }

                    }

                }

            }

            try
            {

                SqlDataSource sqlOrigen = new SqlDataSource();
                this.Page.Controls.Add(sqlOrigen);
                sqlOrigen.ConnectionString = strConexion;
                sqlOrigen.SelectCommand = strQuery;

                grdProyectosAutomatch.DataSource = sqlOrigen;
                grdProyectosAutomatch.DataBind();



                grdProyectosAutomatch.Focus();

            }
            catch (Exception)
            {


            }

        }

        private void LlenarGrillaResultadosFiltroBapin(string CodBapin) {

            //Proceso para llenar la grilla de resultados



            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] " + intEjercicio + ", " + intMes + ", " + AperturaProgra;
            String strQuery = string.Empty;
            strQuery = "SELECT * FROM Matching_tmpProyectosCandidatos where CodigoProyectoBAPIN='" + CodBapin + "'";


            try
            {

                SqlDataSource sqlOrigen = new SqlDataSource();
                this.Page.Controls.Add(sqlOrigen);
                sqlOrigen.ConnectionString = strConexion;
                sqlOrigen.SelectCommand = strQuery;

                grdProyectosAutomatch.DataSource = sqlOrigen;
                grdProyectosAutomatch.DataBind();



                grdProyectosAutomatch.Focus();

            }
            catch (Exception)
            {


            }

        }

        protected void cmdBuscarBapin_Click(object sender, EventArgs e)
        {


            try
            {
                //string strAper = ObtenerAperturaPresupuestariaFiltro(ddlJurisdiccion.SelectedValue, ddlSAF.SelectedValue, ddlPrograma.SelectedValue, ddlSubPrograma.SelectedValue);

                //LlenarGrillaResultados(Convert.ToInt32(ddlEjercicio.SelectedValue),Convert.ToInt32(ddlMes.SelectedValue) ,strAper);

                LlenarGrillaResultadosFiltroBapin(txtCodBapin.Text);

            }
            catch (Exception)
            {

                ClientScript.RegisterStartupScript(this.GetType(), "Mensaje", "alert('Se ha producido un error al realizar la búsqueda. Por favor intente nuevamente. Muchas Gracias' );", true);
            }




        }
    }
}