using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class PersonaService : _PersonaService 
    {	  
	   #region Singleton
	   private static volatile PersonaService current;
	   private static object syncRoot = new Object();

	   //private PersonaService() {}
	   public static PersonaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PersonaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
    public class PersonaComposeService : EntityComposeService<PersonaCompose, PersonaFilter, PersonaResult, int>
    {
        #region Singleton
        private static volatile PersonaComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static PersonaComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PersonaComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PersonaComposeService"; } }

        protected readonly PersonaComposeBusiness Business = new PersonaComposeBusiness();
        protected override IEntityBusiness<PersonaCompose, PersonaFilter, PersonaResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PersonaService.Current.Execute(id, actionName, contextUser, args);
        }
    }

}
