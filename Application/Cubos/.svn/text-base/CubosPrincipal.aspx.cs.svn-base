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

namespace UI.Web.Cubos
{
    public partial class CubosPrincipal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cmdGenerarCuboxTotal_Click(object sender, EventArgs e)
        {


            //Método que realiza la ejecución del Cubo x Total
            //para ello utiliza el store procedure : lanzador-CuboxTotal


            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec sp_Cubo_Inicia_CxT ";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 500; //Matias
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {

                //Ejecuta el comando
                con.Open();
                cmd.ExecuteNonQuery();
                lblStatusResultado.ForeColor = System.Drawing.Color.Green;
                lblStatusResultado.Font.Bold = true;
                lblStatusResultado.Text = "Se ha procesado correctamten Cubo x Total. Gracias!";
                con.Close();


            }
            catch (Exception)
            {

                con.Dispose();
                lblStatusResultado.ForeColor = System.Drawing.Color.Red;
                lblStatusResultado.Font.Bold = true;
                lblStatusResultado.Text = "Se ha detectado un error al procesar Cubo x Total. Por favor intente nuevamente. Gracias!";


            }


        }

        protected void cmdGenerarCuboxObjeto_Click(object sender, EventArgs e)
        {


            //Método que realiza la ejecución del Cubo x Objeto
            //para ello utiliza el store procedure : lanzador-CuboxObjeto


            string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            String strQuery = "exec sp_Cubo_Inicia_CxO ";
            SqlConnection con = new SqlConnection(strConexion);
            SqlCommand cmd = new SqlCommand();
            cmd.CommandTimeout = 1100; //Matias
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = strQuery;
            cmd.Connection = con;
            try
            {

                //Ejecuta el comando
                con.Open();
                cmd.ExecuteNonQuery();
                lblStatusResultado.ForeColor = System.Drawing.Color.Green;
                lblStatusResultado.Font.Bold = true;
                lblStatusResultado.Text = "Se ha procesado correctamten Cubo x Objeto. Gracias!";
                con.Close();
                
            }
            catch (Exception)
            {

                con.Dispose();
                lblStatusResultado.ForeColor = System.Drawing.Color.Red;
                lblStatusResultado.Font.Bold = true;
                lblStatusResultado.Text = "Se ha detectado un error al procesar Cubo x Objeto. Por favor intente nuevamente. Gracias!";


            }

        }
    }
}