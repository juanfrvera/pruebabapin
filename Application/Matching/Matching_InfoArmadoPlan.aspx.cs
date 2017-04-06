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
    public partial class Matching_InfoArmadoPlan : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {

                if (!IsPostBack)
                {
                    /* Proceso para la carga del Dropdown de ejercicio*/
                    LlenarDropDownEjercicio();
                    /*Proceso para llenar el DropDown del Mes*/
                    LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));

                }


            }
            catch (Exception)
            {

                
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
            String strQuery = "select distinct MesSidif from Matching_InfoPresupuestoAgrupado where EjercicioPresupuestario=" + intEjercicioPresup + "  order by 1 DESC";
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

        private void ExportarExcelAgrupado()
        {
            //Método para exportar la información para el armado de plan Agrupado
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("yyyyMMdd") + "_" +"InfoParaArmadoPlanTotales.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = ObtenerDatosAgrupados(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()), Convert.ToInt32(ddlMes.SelectedValue.ToString()));
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }

            Response.End();
         }
        private void ExportarExcelSidifNoVinculado()
        {
            //Método para exportar la información para el armado de plan Agrupado
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("yyyyMMdd") + "_" + "InfoParaArmadoPlanSidifNoVinculados.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = ObtenerDatosSidifNoVinculados(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()), Convert.ToInt32(ddlMes.SelectedValue.ToString()));
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }

            Response.End();
        }
        private void ExportarExcelSidifVinculados()
        {
            //Método para exportar la información para el armado de plan Agrupado
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("yyyyMMdd") + "_" + "InfoParaArmadoPlanSidifVinculados.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = ObtenerDatosSidifVinculados(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()), Convert.ToInt32(ddlMes.SelectedValue.ToString()));
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }

            Response.End();
        }

        private void ExportarExcelSidifVinculadosND()
        {
            //Método para exportar la información para el armado de plan Agrupado
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", string.Format("attachment; filename={0}", DateTime.Now.ToString("yyyyMMdd") + "_" + "InfoParaArmadoPlanSidifVinculadosND.xls"));
            Response.ContentType = "application/ms-excel";
            DataTable dt = ObtenerDatosSidifVinculadosND(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()), Convert.ToInt32(ddlMes.SelectedValue.ToString()));
            string str = string.Empty;
            foreach (DataColumn dtcol in dt.Columns)
            {
                Response.Write(str + dtcol.ColumnName);
                str = "\t";
            }
            Response.Write("\n");
            foreach (DataRow dr in dt.Rows)
            {
                str = "";
                for (int j = 0; j < dt.Columns.Count; j++)
                {
                    Response.Write(str + Convert.ToString(dr[j]));
                    str = "\t";
                }
                Response.Write("\n");
            }

            Response.End();
        }

        private DataTable ObtenerDatosAgrupados(Int32 EjercicioPresup, Int32 MesProceso)
        {
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec sp_Matching_GenerarAgrupadoArmadoPlan " + EjercicioPresup +"," + MesProceso;
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            DataTable dt = new DataTable();
            try
            {
                con.Open();
              
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();

                
            }
            catch (Exception)
            {
                
              
            }

            return dt;

        }


        private DataTable ObtenerDatosSidifNoVinculados(Int32 EjercicioPresup, Int32 MesProceso)
        {
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "SELECT * from Matching_InfoPresupuestoAgrupado where EjercicioPresupuestario =" + EjercicioPresup +" and MesSidif = " + MesProceso +" and IdentificadorProyectoSidif not in  (Select IdentificadorProyectoSidif from Matching_ProyectosVinculados where EjercicioPresupuestario = " + EjercicioPresup+ "and MesSidif = "+MesProceso+") and IdentificadorProyectoSidif not in (Select IdentificadorProyectoSidif from Matching_ProyectosVinculadosND where EjercicioPresupuestario = "+EjercicioPresup+" and MesSidif = "+MesProceso+")";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();


            }
            catch (Exception)
            {


            }

            return dt;

        }

        private DataTable ObtenerDatosSidifVinculados(Int32 EjercicioPresup, Int32 MesProceso)
        {
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "SELECT * from Matching_ProyectosVinculados where EjercicioPresupuestario =" + EjercicioPresup + " and MesSidif = " + MesProceso + " and IdentificadorProyectoSidif not in (Select IdentificadorProyectoSidif from Matching_ProyectosVinculadosND where EjercicioPresupuestario = " + EjercicioPresup + " and MesSidif = " + MesProceso + ")";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();


            }
            catch (Exception)
            {


            }

            return dt;

        }

        private DataTable ObtenerDatosSidifVinculadosND(Int32 EjercicioPresup, Int32 MesProceso)
        {
            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "SELECT * from Matching_ProyectosVinculadosND where EjercicioPresupuestario =" + EjercicioPresup + " and MesSidif = " + MesProceso + " and IdentificadorProyectoSidif not in (Select IdentificadorProyectoSidif from Matching_ProyectosVinculados where EjercicioPresupuestario = " + EjercicioPresup + " and MesSidif = " + MesProceso + ")";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            DataTable dt = new DataTable();
            try
            {
                con.Open();

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                con.Close();


            }
            catch (Exception)
            {


            }

            return dt;

        }



        protected void ddlEjercicio_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                LlenarDropdownMes(Convert.ToInt32(ddlEjercicio.SelectedValue.ToString()));
            }
            catch (Exception)
            {

                
            }
            
        }

        protected void cmdArmPlanAgrup_Click(object sender, EventArgs e)
        {
            ExportarExcelAgrupado(); //Info Sidif Totales Agrupados

        }

        protected void cmdInfoSidifNoVinculado_Click(object sender, EventArgs e)
        {
            ExportarExcelSidifNoVinculado(); // Info Totales Sidif No Vinculados

        }

        protected void cmdInfoSidifVinculados_Click(object sender, EventArgs e)
        {
            ExportarExcelSidifVinculados(); // Info Totales Sidif  Vinculados

        }

        protected void cmdInfoSidifVinculadosND_Click(object sender, EventArgs e)
        {
            ExportarExcelSidifVinculadosND(); // Info Totales Sidif  Vinculados ND

        }

        protected void cmdVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matching/Matching_Principal.aspx");
        }
    }
}