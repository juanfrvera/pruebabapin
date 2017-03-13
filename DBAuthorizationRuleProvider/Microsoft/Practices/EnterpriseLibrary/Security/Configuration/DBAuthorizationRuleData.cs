namespace Microsoft.Practices.EnterpriseLibrary.Security.Configuration
{
    using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
    using Microsoft.Practices.EnterpriseLibrary.Security;
    using System;
    using System.Configuration;

    public class DBAuthorizationRuleData : NamedConfigurationElement, IAuthorizationRule
    {
        private const string descriptionProperty = "description";
        private const string expressionProperty = "expression";
        private string id;

        public DBAuthorizationRuleData()
        {
        }

        public DBAuthorizationRuleData(string id, string name, string expression, string description) : base(name)
        {
            this.id = id;
            this.Expression = expression;
            this.Description = description;
        }

        [ConfigurationProperty("description", IsRequired=false)]
        public string Description
        {
            get
            {
                return (string) base["description"];
            }
            set
            {
                base["description"] = value;
            }
        }

        [ConfigurationProperty("expression", IsRequired=false)]
        public string Expression
        {
            get
            {
                return (string) base["expression"];
            }
            set
            {
                base["expression"] = value;
            }
        }

        public string Id
        {
            get
            {
                return this.id;
            }
            set
            {
                this.id = value;
            }
        }
    }
}

