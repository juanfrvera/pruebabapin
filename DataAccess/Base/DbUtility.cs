using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Reflection;
using System.Threading;
using System.Web;
using System.Runtime.Serialization;
using Contract;

namespace DataAccess
{
    using System;
    using System.Linq.Expressions;
    using System.IO;
    using System.Data.Linq.Mapping;
    using System.Security.Principal;
    using System.Data;
    using System.Data.SqlClient;
    using System.Configuration;

    public class DbUtility
    {
        #region Singleton
        private static volatile DbUtility current;
        private static object syncRoot = new Object();
        private DbUtility() { }
        public static DbUtility Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new DbUtility();
                    }
                }
                return current;
            }
        }
        #endregion
               
        public SqlConnection CreateConnection()
        {
            string connectionString = "";
            string keyConnectionString = "Contract.Properties.Settings.BAPIN3ConnectionString";
            try
            {
                System.Configuration.ConnectionStringSettingsCollection config = System.Configuration.ConfigurationManager.ConnectionStrings;
                connectionString = config[keyConnectionString].ConnectionString;
                return new SqlConnection(connectionString);
            }
            catch (Exception exception)
            {
                DataHelper.Validate(false, "No se pudo realizar la conexion establecida en:"+keyConnectionString);
                return null;
            }
        }
        #region Get
        public DataTable Get(string commandText)
        {
            return Get(commandText, CommandType.StoredProcedure, null);
        }
        public DataTable Get(string commandText, CommandType commandType)
        {
            return Get(commandText, commandType, null);
        }
        public DataTable Get(string commandText, object _object)
        {
            return Get(commandText, CommandType.StoredProcedure, _object);
        }
        public DataTable Get(string commandText, CommandType commandType, object _object)
        {
            DataTable dt = null;
            try
            {
                SqlCommand command = CreateCommand(commandText, commandType, _object);
                DataHelper.Validate(command != null, "No se pudo ejecutar el comando:" + commandText);
                if (command == null) return null;
                //ejecuta el comando    
                using (SqlDataReader dr = command.ExecuteReader(CommandBehavior.CloseConnection))
                {
                    dt = new DataTable();
                    dt.Load(dr);
                }
            }
            catch (Exception exception)
            {
                DataHelper.Validate(false,exception.Message);
            }
            return dt;  
        }
        #endregion
        #region Execute
        public void Execute(string commandText)
        {
            Execute(commandText, CommandType.StoredProcedure, null);
        }
        public void Execute(string commandText, CommandType commandType)
        {
            Execute(commandText, commandType, null);
        }
        public void Execute(string commandText, object _object)
        {
            Execute(commandText, CommandType.StoredProcedure, _object);
        }
        public void Execute(string commandText, CommandType commandType, object _object)
        {        
            try
            {
                SqlCommand command = CreateCommand(commandText, commandType, _object);
                DataHelper.Validate(command != null, "InvalidStoreName");
                command.ExecuteNonQuery();
            }
            catch (Exception exception)
            {
             DataHelper.Validate(false, exception.Message);
            }  
        }
        #endregion

        protected SqlCommand CreateCommand(string commandText, CommandType commandType, object _object)
        {
            try
            {
                SqlConnection connection = CreateConnection();
                DataHelper.Validate(connection != null, "No se pudo conectar a la base de datos");

                SqlCommand command = connection.CreateCommand();
                command.CommandType = commandType;
                command.CommandText = commandText;

                connection.Open();

                if (_object != null)
                {
                    SqlCommandBuilder.DeriveParameters(command);
                    // Populate the Input Parameters With Values Provided        
                    foreach (SqlParameter parameter in command.Parameters)
                        if (parameter.Direction == ParameterDirection.Input || parameter.Direction == ParameterDirection.InputOutput)
                        {
                            object value = GetValue(_object, parameter.ParameterName.Replace("@", ""));
                            if (value != null)
                                parameter.Value = value;
                        }
                }
                return command;
            }
            catch (Exception exception)
            {
                DataHelper.Validate(false, exception.Message);
                return null;
            }
        }
        protected object GetValue(object _object, string propertyName)
        {
            PropertyInfo fValue = (from f in _object.GetType().GetProperties()
                                   where f.Name == propertyName
                                   select f).FirstOrDefault();
            if (fValue == null) return null;
            return fValue.GetValue(_object, null);
        }
        
    }
}


