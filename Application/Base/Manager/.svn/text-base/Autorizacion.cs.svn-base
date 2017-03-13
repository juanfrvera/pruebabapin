using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Principal;
using System.Web.Security;
using System.Configuration;

using Microsoft.Practices.EnterpriseLibrary.Security;
using Microsoft.Practices.EnterpriseLibrary.Common.Configuration;
using Contract;
using System.Web;

namespace UI.Web
{
    #region OLD
    /*
    public class Autorizacion
    {
        #region Atributos
        private IPrincipal principal;
        private const string CHAR_SPLIT = "|";
        // Singleton
        //private static DbAuthorizationRuleProvider autProvider = (DbAuthorizationRuleProvider)AuthorizationFactory.GetAuthorizationProvider("DBAuthorizationRuleProvider");
        private static ContainerSection containerSection = ((ContainerSection)ConfigurationManager.GetSection("uiConfiguration"));


        private static DbAuthorizationRuleProvider autProvider;
        public static DbAuthorizationRuleProvider AutProvider
        {
            get {
                if (autProvider == null)
                { 
                    IAuthorizationProvider provider =  AuthorizationFactory.GetAuthorizationProvider("DBAuthorizationRuleProvider");
                    DbAuthorizationRuleProvider dbProvider = provider as DbAuthorizationRuleProvider;
                    if (dbProvider == null)
                                  throw new Exception("DBAuthorizationRuleProvider no implementa  DbAuthorizationRuleProvider");
                    autProvider = dbProvider;
                }                
                return autProvider; }
            set { autProvider = value; }
        }


        public static AuthorizationProvider AuthorizationProvider
        {
            get { return Autorizacion.AutProvider; }
        }
        #endregion Atributos

        #region Metodos 

        // Constructor
        public Autorizacion(IPrincipal principal)
        {
            //containerSection = ((ContainerSection)ConfigurationManager.GetSection("uiConfiguration"));
            if (principal == null)
                throw new ArgumentNullException("principal");

            this.principal = principal;            
        }

        /// <summary>
        /// autorizar una regla para el principal
        /// </summary>
        /// <param name="regla"></param>
        /// <returns></returns>
        public bool Autorizar(string regla)
        {
            //obtener el autorizador segun aplicacion
            return AutProvider.Authorize(principal, regla);
        }

        /// <summary>
        /// Obtiene el contenedor de la configuracion y autoriza todos sus items
        /// </summary>
        /// <param name="containerName">nombre del contenedor a autorizar</param>
        /// <returns>un string[] con los items no autorizados del contenedor</returns>
        public string[] AutorizarContenedor(string containerName)
        {
            string[] result = default(string[]);

            if (containerSection.Containers.Contains(containerName))
            {
                // Obtener un container de la seccion
                Container container = containerSection.Containers.Get(containerName);
                if (!(String.IsNullOrEmpty(container.Rule)))
                {
                    //Si tiene rule asociada, validar autorizacion del contenedor
                    if (!this.Autorizar(container.Rule))
                    {
                        //no esta autorizado a cargar este contenedor
                        throw new Exception("Contenedor no autorizado");
                    }
                }

                // Generar array items NO autorizados
                StringBuilder sb = new StringBuilder();
                string separador = "";
                foreach (Item item in container.Items)
                {
                    // Valida la autorizacion para la regla asociada al control
                    if (!this.Autorizar(item.Rule))
                    {
                        // Si no esta autorizado retornar el nombre del control NO autorizado
                        sb.Append(separador + item.Name);
                        separador = CHAR_SPLIT;
                    }
                }
                if (sb.Length > 0)
                    // Transforma string builder en string[]
                    result = sb.ToString().Split(CHAR_SPLIT.ToCharArray());
            }
            return result;
        }

        /// <summary>
        /// Obtiene todos las reglas de los contenedores y las autoriza
        /// </summary>
        /// <returns>un List de string[] con los rules, index 0 rulename y index 1 valor de autorizacion</returns>
        public List<string[]> AutorizarTodoContenedor()
        {
            List<string[]> result = new List<string[]>();
            List<string> control = new List<string>();
            string sItem;

            foreach (Container container in containerSection.Containers)
            {
                if (!(String.IsNullOrEmpty(container.Rule)))
                {
                    //si ya fue incluida
                    if (!control.Contains(container.Rule))
                    {
                        //si tiene rule asociada, validar autorizacion del contenedor
                        if (this.Autorizar(container.Rule))
                            //esta autorizado a cargar este contenedor
                            sItem = container.Rule + CHAR_SPLIT + "S";
                        else
                            sItem = container.Rule + CHAR_SPLIT + "N";

                        result.Add(sItem.Split(CHAR_SPLIT.ToCharArray()));
                        control.Add(container.Rule);
                    }
                }
            }

            return result;
        }

        /// <summary>
        /// Obtiene todos las reglas de un contenedor y las autoriza
        /// </summary>
        /// <returns>un List de string[] con los rules, index 0 rulename y index 1 valor de autorizacion</returns>
        public List<string[]> AutorizarItemsContenedor(string ruleName)
        {
            List<string[]> result = new List<string[]>();
            List<string> control = new List<string>();
            string sItem;

            foreach (Container container in containerSection.Containers)
            {
                if (!(String.IsNullOrEmpty(container.Rule)))
                {
                    //si esta incluida
                    if (container.Rule == ruleName)
                    {
                        foreach (Item item in container.Items)
                        {
                            if (!control.Contains(item.Rule))
                            {
                                //si tiene rule asociada, validar autorizacion del contenedor
                                if (this.Autorizar(item.Rule))
                                    //esta autorizado a cargar este contenedor
                                    sItem = item.Rule + CHAR_SPLIT + "S";
                                else
                                    sItem = item.Rule + CHAR_SPLIT + "N";

                                result.Add(sItem.Split(CHAR_SPLIT.ToCharArray()));
                                control.Add(item.Rule);
                            }
                        }
                    }
                }
            }

            return result;
        }

        #endregion
    }
    */
    #endregion

    #region OLD
    //public class UIWebAutorizacionManager : IAutorizacionManager
    //{
    //    #region singleton
    //    private static readonly object padlock = new object();
    //    private static UIWebAutorizacionManager current;
    //    public static UIWebAutorizacionManager Current
    //    {
    //        get
    //        {
    //            if (current == null)
    //                lock (padlock)
    //                {
    //                    if (current == null)
    //                        current = new UIWebAutorizacionManager();
    //                }
    //            return current;
    //        }
    //    }
    //    #endregion

    //    #region Properties
    //    //protected IPrincipal principal;
    //    protected const string CHAR_SPLIT = "|";
    //    //protected static DbAuthorizationRuleProvider authorizationProvider;
    //    //public DbAuthorizationRuleProvider AuthorizationProvider
    //    //{
    //    //    get
    //    //    {
    //    //        if (authorizationProvider == null)
    //    //        {
    //    //            IAuthorizationProvider provider = AuthorizationFactory.GetAuthorizationProvider("DBAuthorizationRuleProvider");
    //    //            DbAuthorizationRuleProvider dbProvider = provider as DbAuthorizationRuleProvider;
    //    //            if (dbProvider == null)
    //    //                throw new Exception("DBAuthorizationRuleProvider no implementa  DbAuthorizationRuleProvider");
    //    //            authorizationProvider = dbProvider;
    //    //        }
    //    //        return authorizationProvider;
    //    //    }
    //    //    set { authorizationProvider = value; }
    //    //}
    //    protected static SecurityRuleContainerSection containerSection;
    //    protected static SecurityRuleContainerSection ContainerSection
    //    {
    //        get
    //        {
    //            if (containerSection == null)
    //            {
    //                containerSection = ConfigurationManager.GetSection("SecurityRuleConfiguration") as SecurityRuleContainerSection;
    //            }
    //            return containerSection;
    //        }
    //        set { containerSection = value; }
    //    }
    //    #endregion

    //    #region Contructor
    //    //public UIWebAutorizacionManager(IPrincipal principal)
    //    //{
    //    //    if (principal == null)
    //    //        throw new ArgumentNullException("principal");
    //    //    this.principal = principal;
    //    //}
    //    #endregion

    //    #region Methods

    //    public void ShowError(string message)
    //    {
    //        UIContext.Current.SetValue(UIContext.Current.PageError, UIContext.Current.PARAMETER_ERROR_MESSAGE, message);
    //        HttpContext.Current.Response.Redirect(UIContext.Current.PageError, false);
    //    }

    //    /// <summary>
    //    /// autorizar una regla para el principal
    //    /// </summary>
    //    /// <param name="regla"></param>
    //    /// <returns></returns>
    //    public bool Authorize(IPrincipal principal, string rule)
    //    {
    //        //obtener el autorizador segun aplicacion
    //        return AuthorizationProvider.Authorize(principal, rule);
    //    }

    //    /// <summary>
    //    /// Obtiene el contenedor de la configuracion y autoriza todos sus items
    //    /// </summary>
    //    /// <param name="containerName">nombre del contenedor a autorizar</param>
    //    /// <returns>un string[] con los items no autorizados del contenedor</returns>
    //    public string[] AutorizarContenedor(IPrincipal principal, string containerName)
    //    {
    //        string[] result = default(string[]);

    //        if (ContainerSection.Containers.Contains(containerName))
    //        {
    //            // Obtener un container de la seccion
    //            SecurityRuleContainer container = ContainerSection.Containers.Get(containerName);
    //            if (!(String.IsNullOrEmpty(container.Rule)))
    //            {
    //                //Si tiene rule asociada, validar autorizacion del contenedor
    //                if (!this.Authorize(principal, container.Rule))
    //                {
    //                    //no esta autorizado a cargar este contenedor
    //                    throw new Exception("Contenedor no autorizado");
    //                }
    //            }

    //            // Generar array items NO autorizados
    //            StringBuilder sb = new StringBuilder();
    //            string separador = "";
    //            foreach (SecurityRuleItem item in container.Items)
    //            {
    //                // Valida la autorizacion para la regla asociada al control
    //                if (this.Authorize(principal, item.Rule))
    //                {
    //                    // Si no esta autorizado retornar el nombre del control NO autorizado
    //                    sb.Append(separador + item.Name);
    //                    separador = CHAR_SPLIT;
    //                }
    //            }
    //            if (sb.Length > 0)
    //                // Transforma string builder en string[]
    //                result = sb.ToString().Split(CHAR_SPLIT.ToCharArray());
    //        }
    //        return result;
    //    }

    //    /// <summary>
    //    /// Obtiene todos las reglas de los contenedores y las autoriza
    //    /// </summary>
    //    /// <returns>un List de string[] con los rules, index 0 rulename y index 1 valor de autorizacion</returns>
    //    public List<string[]> AutorizarTodoContenedor(IPrincipal principal)
    //    {
    //        List<string[]> result = new List<string[]>();
    //        List<string> control = new List<string>();
    //        string sItem;

    //        foreach (SecurityRuleContainer container in ContainerSection.Containers)
    //        {
    //            if (!(String.IsNullOrEmpty(container.Rule)))
    //            {
    //                //si ya fue incluida
    //                if (!control.Contains(container.Rule))
    //                {
    //                    //si tiene rule asociada, validar autorizacion del contenedor
    //                    if (this.Authorize(principal, container.Rule))
    //                        //esta autorizado a cargar este contenedor
    //                        sItem = container.Rule + CHAR_SPLIT + "S" + CHAR_SPLIT + container.Name;
    //                    else
    //                        sItem = container.Rule + CHAR_SPLIT + "N" + CHAR_SPLIT + container.Name;

    //                    result.Add(sItem.Split(CHAR_SPLIT.ToCharArray()));
    //                    control.Add(container.Rule);
    //                }
    //            }
    //        }

    //        return result;
    //    }

    //    /// <summary>
    //    /// Obtiene todos las reglas de un contenedor y las autoriza
    //    /// </summary>
    //    /// <returns>un List de string[] con los rules, index 0 rulename y index 1 valor de autorizacion</returns>
    //    public List<string[]> AutorizarItemsContenedor(IPrincipal principal, string ruleName)
    //    {
    //        List<string[]> result = new List<string[]>();
    //        List<string> control = new List<string>();
    //        string sItem;

    //        foreach (SecurityRuleContainer container in ContainerSection.Containers)
    //        {
    //            if (!(String.IsNullOrEmpty(container.Rule)))
    //            {
    //                //si esta incluida
    //                if (container.Rule == ruleName)
    //                {
    //                    foreach (SecurityRuleItem item in container.Items)
    //                    {
    //                        if (!control.Contains(item.Rule))
    //                        {
    //                            //si tiene rule asociada, validar autorizacion del contenedor
    //                            if (this.Authorize(principal, item.Rule))
    //                                //esta autorizado a cargar este contenedor
    //                                sItem = item.Rule + CHAR_SPLIT + "S" + CHAR_SPLIT + item.Name;
    //                            else
    //                                sItem = item.Rule + CHAR_SPLIT + "N" + CHAR_SPLIT + item.Name;

    //                            result.Add(sItem.Split(CHAR_SPLIT.ToCharArray()));
    //                            control.Add(item.Rule);
    //                        }
    //                    }
    //                }
    //            }
    //        }

    //        return result;
    //    }

    //    #endregion
    //}
    #endregion
}
