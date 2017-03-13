using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Xml.Serialization;
using System.IO;
using System.Collections;

namespace Service
{
    public class UsuarioComposeService : EntityComposeService<UsuarioCompose, UsuarioFilter, UsuarioResult, int>
    {
        #region Singleton
        private static volatile UsuarioComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static UsuarioComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UsuarioComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "UsuarioComposeService"; } }

        protected readonly UsuarioComposeBusiness Business = new UsuarioComposeBusiness();
        protected override IEntityBusiness<UsuarioCompose, UsuarioFilter, UsuarioResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return UsuarioService.Current.Execute(id, actionName, contextUser, args);
        }

        public static string GetPerfilUser(string username)
        {
           return new UsuarioBusiness().GetPerfilUser(username);
          
        }
    }

    public class UsuarioMembershipComposeService : EntityComposeService<UsuarioMembershipCompose, UsuarioFilter, UsuarioResult, int>
    {
        #region Singleton
        private static volatile UsuarioMembershipComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static UsuarioMembershipComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UsuarioMembershipComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "UsuarioComposeService"; } }

        protected readonly UsuarioMembershipComposeBusiness Business = new UsuarioMembershipComposeBusiness();
        protected override IEntityBusiness<UsuarioMembershipCompose, UsuarioFilter, UsuarioResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return UsuarioService.Current.Execute(id, actionName, contextUser, args);
        }       
    }
    
    public class UsuarioService : _UsuarioService 
    {	  
	   #region Singleton
	   private static volatile UsuarioService current;
	   private static object syncRoot = new Object();

	   //private UsuarioService() {}
	   public static UsuarioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public virtual UsuarioResult GetResultById(int id)
       {
           return Business.GetResultById(id);
       }

    }
}
