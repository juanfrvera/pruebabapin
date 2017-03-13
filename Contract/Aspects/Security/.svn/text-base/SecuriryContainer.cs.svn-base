using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;

namespace Contract
{
    public class SecurityRuleContainerSection : ConfigurationSection
    {
        private const string containersProperty = "containers";
        [ConfigurationProperty(containersProperty, IsRequired = true)]
        public NamedElementCollection<SecurityRuleContainer> Containers
        {
            get { return (NamedElementCollection<SecurityRuleContainer>)base[containersProperty]; }
        }
    }

    public class SecurityRuleContainer : NamedConfigurationElement
    {
        private const string ruleProperty = "rule";
        [ConfigurationProperty(ruleProperty, IsRequired = false)]
        public string Rule
        {
            get { return (string)base[ruleProperty]; }
            set { base[ruleProperty] = value; }
        }

        private const string itemsProperty = "items";
        [ConfigurationProperty(itemsProperty, IsRequired = false)]
        public NamedElementCollection<SecurityRuleItem> Items
        {
            get { return (NamedElementCollection<SecurityRuleItem>)base[itemsProperty]; }
        }
    }
    public class SecurityRuleItem : NamedConfigurationElement
    {
        private const string ruleProperty = "rule";
        [ConfigurationProperty(ruleProperty, IsRequired = true)]
        public string Rule
        {
            get { return (string)base[ruleProperty]; }
            set { base[ruleProperty] = value; }
        }

        private const string typeNameProperty = "typeName";
        [ConfigurationProperty(typeNameProperty, IsRequired = false)]
        public string TypeName
        {
            get { return (string)base[typeNameProperty]; }
            set { base[typeNameProperty] = value; }
        }

        private const string permisoProperty = "permiso";
        [ConfigurationProperty(permisoProperty, IsRequired = false)]
        public string PermisoCode
        {
            get { return (string)base[permisoProperty]; }
            set { base[permisoProperty] = value; }
        }

        private const string actionNameProperty = "action";
        [ConfigurationProperty(actionNameProperty, IsRequired = false)]
        public string ActionName
        {
            get { return (string)base[actionNameProperty]; }
            set { base[actionNameProperty] = value; }
        }
    }    
}
