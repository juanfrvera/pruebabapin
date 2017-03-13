namespace Microsoft.Practices.EnterpriseLibrary.Security.Configuration
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
    using Microsoft.Practices.EnterpriseLibrary.Data;
    using Microsoft.Practices.EnterpriseLibrary.Security;
    using Microsoft.Practices.ObjectBuilder;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Common;

    public class DbAuthorizationRuleProviderAssembler : IAssembler<IAuthorizationProvider, AuthorizationProviderData>
    {
        public IAuthorizationProvider Assemble(IBuilderContext context, AuthorizationProviderData objectConfiguration, IConfigurationSource configurationSource, ConfigurationReflectionCache reflectionCache)
        {
            DbAuthorizationRuleProviderData data = objectConfiguration;
            IDictionary<string, IAuthorizationRule> authorizationRules = new Dictionary<string, IAuthorizationRule>();
            Database db = DatabaseFactory.CreateDatabase(data.connectionStringName);
            string str = "aspnet_Rules_GetAllRules";
            DbCommand storedProcCommand = db.GetStoredProcCommand(str);
            DbParameter parameter = storedProcCommand.CreateParameter();
            parameter.ParameterName = "@Aplicacion";
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = data.applicationName;
            storedProcCommand.Parameters.Add(parameter);
            using (IDataReader reader = db.ExecuteReader(storedProcCommand))
            {
                while (reader.Read())
                {
                    authorizationRules.Add(reader["RuleName"].ToString(), new DBAuthorizationRuleData(reader["RuleId"].ToString(), reader["RuleName"].ToString(), reader["Expression"].ToString(), reader.IsDBNull(reader.GetOrdinal("Description")) ? "" : reader["Description"].ToString()));
                }
            }
            return new DbAuthorizationRuleProvider(db, authorizationRules);
        }
    }
}

