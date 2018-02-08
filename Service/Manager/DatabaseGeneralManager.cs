using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using nc = Contract;
using Service;
using System.Data.SqlClient;
using Business;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Service
{


    public class DatabaseGeneralManager
    {
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

        public static string ConsultarBapines(string strConexion, long ejercicio, string estado, long jurisdiccion, long bapin, long saf, string programas)
        {
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
            cmd.Parameters["@estado"].Value = estado;
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
            if (programas.Equals(string.Empty))
                cmd.Parameters["@programas"].Value = System.DBNull.Value;
            else
            {
                cmd.Parameters["@programas"].Value = programas;
            }

            // Connection open
            con.Open();

            table.Load(cmd.ExecuteReader());

            ds.Tables.Add(table);

            con.Close();

            return ds.GetXml();
        }
    }
}
