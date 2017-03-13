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

    public static class LinqUtility

    {
        /// <summary>        
        /// Dictionary key for the DataContext in HttpContext.Current.Items        
        /// </summary>        
        private const string DATACONTEXT_ITEMS_KEY = "DataClassesDataContext";

        private static object syncRoot = new Object();
        
        [ThreadStatic]
        private static DataClassesDataContext context;
        public static DataClassesDataContext Context
        {
            get
            {
                if (HttpContext.Current == null)
                {
                    if (context == null)
                    {
                        context = new DataClassesDataContext();
                    }
                    return context;
                }
                else
                {
                    // si trabajamos en un contexto web usamos HttpContext.Current.Items para instanciar el objeto
                    //HttpContext.Current.Items es threadsafe y se mantiene por todo el request
                    if (!HttpContext.Current.Items.Contains(DATACONTEXT_ITEMS_KEY))
                    {
                        HttpContext.Current.Items[DATACONTEXT_ITEMS_KEY] = new DataClassesDataContext();
                    }
                    return (DataClassesDataContext)HttpContext.Current.Items[DATACONTEXT_ITEMS_KEY];
                }
            }
        }
        public static void ReloadContext()
        {
            if (HttpContext.Current == null)
            {
                if (context != null)
                {
                    context.Dispose();
                    context = new DataClassesDataContext();
                }
            }
            else
            {
                if (HttpContext.Current.Items.Contains(DATACONTEXT_ITEMS_KEY))
                {
                    ((DataClassesDataContext)HttpContext.Current.Items[DATACONTEXT_ITEMS_KEY]).Dispose();
                    HttpContext.Current.Items[DATACONTEXT_ITEMS_KEY] = new DataClassesDataContext();
                }
            }
        }
        public static void CopiarAtributos(Object origen, Object destino)
        {
            foreach (PropertyInfo po in origen.GetType().GetProperties())
            {

                object[] cu = po.GetCustomAttributes(false);
                if (cu.Length > 0)
                {
                    ColumnAttribute ca = cu[0] as ColumnAttribute;
                    if (ca == null && cu.Length>1) ca = cu[1] as ColumnAttribute;
                    if (ca != null)
                    {
                        po.SetValue(destino, po.GetValue(origen, null), null);
                    }
                }
            }
        }
    } 
}


