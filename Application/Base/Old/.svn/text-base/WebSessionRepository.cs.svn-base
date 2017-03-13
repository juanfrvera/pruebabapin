using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Contract;
using System.Web;

namespace UI.Web
{
    #region OLD 
    /*
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
    }    
    public static class SessionRepository
    {
        private const string PRINCIPAL = "Principal";
        private const string ENTIDAD = "Entidad";

        public static CustomPrincipal Principal
        {
            get
            {
                return (CustomPrincipal)HttpContext.Current.Session[PRINCIPAL];
            }
            set
            {
                HttpContext.Current.Session.Add(PRINCIPAL, value);
            }
        }

        public static CustomIdentity Identity
        {
            get
            {
                return (CustomIdentity)Principal.Identity;
            }
        }
    }
    */
    #endregion
       
    //public class WebSessionRepository : ISessionRepository
    //{
    //    #region Singleton
    //    private static volatile WebSessionRepository current;
    //    private static object syncRoot = new Object();

    //    public static WebSessionRepository Current
    //    {
    //        get
    //        {
    //            if (current == null)
    //            {
    //                lock (syncRoot)
    //                {
    //                    if (current == null)
    //                        current = new WebSessionRepository();
    //                }
    //            }
    //            return current;
    //        }
    //    }
    //    #endregion

    //    private const string PRINCIPAL = "Principal";
    //    private const string ENTIDAD = "Entidad";

    //    public CustomPrincipal Principal
    //    {
    //        get
    //        {
    //            if (HttpContext.Current.Session == null)return null;
    //            return HttpContext.Current.Session[PRINCIPAL] as CustomPrincipal;
    //        }
    //        set
    //        {
    //            HttpContext.Current.Session.Add(PRINCIPAL, value);
    //        }
    //    }
    //    public CustomIdentity Identity
    //    {
    //        get
    //        {
    //            if (Principal == null) return null;
    //            return Principal.Identity as CustomIdentity;
    //        }
    //    }
    //}

}

