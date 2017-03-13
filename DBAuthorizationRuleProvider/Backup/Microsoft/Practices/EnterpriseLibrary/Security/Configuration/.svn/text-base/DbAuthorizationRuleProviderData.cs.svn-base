namespace Microsoft.Practices.EnterpriseLibrary.Security.Configuration
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration.ObjectBuilder;
    using System;
    using System.Configuration;

    [Assembler(typeof(DbAuthorizationRuleProviderAssembler))]
    public class DbAuthorizationRuleProviderData : AuthorizationProviderData
    {
        private const string applicationNameProperty = "applicationName";
        private const string connectionStringNameProperty = "connectionStringName";

        public DbAuthorizationRuleProviderData()
        {
        }

        public DbAuthorizationRuleProviderData(string name) : base(name, typeof(IAuthorizationRule))
        {
        }

        [ConfigurationProperty("applicationName", IsRequired=true)]
        public string applicationName
        {
            get
            {
                return (string) base["applicationName"];
            }
            set
            {
                base["applicationName"] = value;
            }
        }

        [ConfigurationProperty("connectionStringName", IsRequired=true)]
        public string connectionStringName
        {
            get
            {
                return (string) base["connectionStringName"];
            }
            set
            {
                base["connectionStringName"] = value;
            }
        }
    }
}

