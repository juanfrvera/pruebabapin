using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;
using System.Data.Common;
using System.Data.SqlClient;
using Business;
using Business.Managers;

using System.Data;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Configuration;
using System.Xml;
//using log4net;

namespace Service
{


    public class DatabaseGeneralManager
    {
        //private static readonly ILog Log = LogManager.GetLogger(typeof(TemplateHandler));

        #region singleton
        private static readonly object padlock = new object();
        private static DatabaseGeneralManager current;
        private DatabaseGeneralManager() { }
        public static DatabaseGeneralManager Current
        {
            get
            {
                if (current == null)
                    lock (padlock)
                    {
                        if (current == null)
                            current = new DatabaseGeneralManager();
                    }
                return current;
            }
        }
        #endregion

        public static DataSet ConsultarBapines(string strConexion, long ejercicio, List<string> estados, long jurisdiccion, long bapin, long saf, List<long> programas)
        {
            var estadosList = String.Join("|", estados);
            var programasList = string.Empty;
            if (programas != null && programas.Count > 0)
            {
                programasList = String.Join("|", programas);
            }

            DataSet ds = new DataSet("Bapines");
            DataTable table = new DataTable("Bapin");

            // Connection create
            SqlConnection con = new SqlConnection(strConexion);

            // Sql command
            SqlCommand cmd = new SqlCommand("dbo.spConsultarBapines", con);
            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.Add(new SqlParameter("@ejercicio", SqlDbType.BigInt));
            cmd.Parameters["@ejercicio"].Value = ejercicio;
            cmd.Parameters.Add(new SqlParameter("@estado", SqlDbType.VarChar));
            cmd.Parameters["@estado"].Value = estadosList;
            cmd.Parameters.Add(new SqlParameter("@jurisdiccion", SqlDbType.BigInt));
            cmd.Parameters["@jurisdiccion"].Value = jurisdiccion;
            cmd.Parameters.Add(new SqlParameter("@bapin", SqlDbType.BigInt));
            cmd.Parameters.Add(new SqlParameter("@saf", SqlDbType.BigInt));
            cmd.Parameters.Add(new SqlParameter("@programas", SqlDbType.VarChar));

            if (bapin < 1)
                cmd.Parameters["@bapin"].Value = System.DBNull.Value;
            else
            {
                cmd.Parameters["@bapin"].Value = bapin;
            }
            if (saf < 1)
                cmd.Parameters["@saf"].Value = System.DBNull.Value;
            else
            {
                cmd.Parameters["@saf"].Value = saf;
            }
            if (programasList.Equals(string.Empty))
                cmd.Parameters["@programas"].Value = System.DBNull.Value;
            else
            {
                cmd.Parameters["@programas"].Value = programasList;
            }

            // Connection open
            con.Open();

            table.Load(cmd.ExecuteReader());

            ds.Tables.Add(table);

            con.Close();

            return ds;
            //return ds.GetXml();
        }

        public static void ActualizarBapines(string strConexion)
        {
            var datosBapinType = new DatosBapinType();
            //, EstadoBapinType.PLAN_SEGUN_EJECUCION, EstadoBapinType.PLAN
            //Response.Redirect(GeneralPath + "AdministracionTemplate.aspx", false);

            //string strConexion = ConfigurationManager.ConnectionStrings["Contract.Properties.Settings.BAPIN3ConnectionString"].ConnectionString;
            //SqlConnection sqlCon = new SqlConnection(strConexion);

            // Connection create
            SqlConnection sqlCon = new SqlConnection(strConexion);

            try
            {

                using (DbCommand command = sqlCon.CreateCommand())
                {
                    command.CommandType = CommandType.Text;
                    command.CommandText = "TRUNCATE TABLE [BAPIN].[dbo].[wsONPConsultaAPG]";

                    sqlCon.Open();
                    command.ExecuteNonQuery();
                }

                DbTransaction trans = sqlCon.BeginTransaction();

                var juris = JurisdiccionService.Current.GetResultFromList(new nc.JurisdiccionFilter() { Activo = true });
                var valuesEstados = Enum.GetValues(typeof(EstadoBapinType));
                var hasValues = false;
                foreach (var jurisdiccion in juris)
                {
                    foreach (var estado in valuesEstados)
                    {
                        datosBapinType.ejercicio = DateTime.Now.Year + 1;
                        datosBapinType.jurisdiccion = jurisdiccion.ID;
                        datosBapinType.estados = new EstadoBapinType?[] { (EstadoBapinType)estado };


                        var bapines = EsidifManager.ConsultarAPGBapines(datosBapinType);
                        XmlDocument xd = new XmlDocument();
                        xd.LoadXml(bapines);

                        if (xd.ChildNodes[0] != null && xd.ChildNodes[0].ChildNodes[0] != null)
                        {
                            using (DbCommand commandT = sqlCon.CreateCommand())
                            {
                                commandT.CommandType = CommandType.StoredProcedure;
                                commandT.CommandText = "sp_ONPConsultaAPG";
                                commandT.Parameters.Add(
                                  new SqlParameter("@MyXML", SqlDbType.Xml)
                                  {
                                      Value = new SqlXml(new XmlTextReader(xd.FirstChild.InnerXml
                                                 , XmlNodeType.Element, null))
                                  });

                                commandT.Transaction = trans;
                                commandT.ExecuteNonQuery();
                            }
                            hasValues = true;
                        }
                    }
                }

                if (hasValues)
                {
                    using (DbCommand commandT = sqlCon.CreateCommand())
                    {
                        commandT.CommandType = CommandType.StoredProcedure;
                        commandT.CommandText = "sp_ONPConsultaAPG_UpdateProyectos";
                        commandT.Transaction = trans;
                        commandT.ExecuteNonQuery();
                    }
                }

                trans.Commit();
                sqlCon.Close();
            }
            catch (Exception)
            {
                sqlCon.Close();
                throw;
            }
        }
    }
}
