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
    public partial class Matching_ProyectosBapinPlanSinSidif : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            LlenarGrillaResultados();
        }

        private void LlenarGrillaResultados()
        {

            //Obtengo Fecha última actualización

            //      lblUltimaActualizacion.Text = ObtenerUltimaActualizacion();

            /*Proceso para LLenar de Resultados por la búsqueda de los datos de la grilla*/

            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //String strQuery = "EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'";
            String strQuery = "select CodigoProyectoBAPIN as Bapin,AperturaProgramaticaSeparada as AperProg,ProyectoDenominacion as Denominacion,(CodigoJurisdiccion +'-' + Nombre) as Jurisdiccion, (CodigoSAF + '-' + SAF_Denominacion) as SAF,(CodigoPrograma +'-'+ Programa) as Programa, (CodigoSubprograma + '-' +SubPrograma) as SubPrograma  from [dbo].[vw_Matching_ProyectosBapinesMarcaPlan_SinSidif]";

            SqlDataSource sqlOrigen = new SqlDataSource();
            this.Page.Controls.Add(sqlOrigen);
            sqlOrigen.ConnectionString = strConexion;
            sqlOrigen.SelectCommand = strQuery;

            grdProyectosBapinSinSidif.DataSource = sqlOrigen;
            grdProyectosBapinSinSidif.DataBind();
            grdProyectosBapinSinSidif.Focus();
            
        }

        protected void grdProyectosBapinSinSidif_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            grdProyectosBapinSinSidif.PageIndex = e.NewPageIndex;

            LlenarGrillaResultados();
            this.grdProyectosBapinSinSidif.DataBind();
        }


        private void ExportarExcel()
        {
            Response.Clear();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment;filename=" + DateTime.Now.ToString("yyyyMMdd") + "__MatchingProyectosBapinSinSidif.xls");
            Response.Charset = "";
            Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            using (StringWriter sw = new StringWriter())
            {
                HtmlTextWriter hw = new HtmlTextWriter(sw);

                //To Export all pages
                grdProyectosBapinSinSidif.AllowPaging = false;

                LlenarGrillaResultados();

            grdProyectosBapinSinSidif.HeaderRow.BackColor = System.Drawing.Color.White;
            
                foreach (TableCell cell in grdProyectosBapinSinSidif.HeaderRow.Cells)
                {
                    cell.BackColor = System.Drawing.Color.White;
                }
                foreach (GridViewRow row in grdProyectosBapinSinSidif.Rows)
                {
                    row.BackColor = System.Drawing.Color.White;
                    foreach (TableCell cell in row.Cells)
                    {
                        if (row.RowIndex % 2 == 0)
                        {
                            cell.BackColor = grdProyectosBapinSinSidif.AlternatingRowStyle.BackColor;
                        }
                        else
                        {
                            cell.BackColor = grdProyectosBapinSinSidif.RowStyle.BackColor;
                        }
                        cell.CssClass = "textmode";
                    }
                }

                grdProyectosBapinSinSidif.RenderControl(hw);

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
            if (grdProyectosBapinSinSidif.Rows.Count > 0)
            {
                lblExportExcel.ForeColor = System.Drawing.Color.Green;
                lblExportExcel.Text = "Se ha descargado el archivo correctamente, por favor verifique en la carpeta de descarga de su navegador.";

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

        protected void cmdVolver_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Matching/Matching_Principal.aspx");
        }

        public override void VerifyRenderingInServerForm(Control control)
        {
            /* Verifica que el control se haya renderizado*/
        }

    }
}