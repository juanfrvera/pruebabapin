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
    public class PrestamoConvenioService : _PrestamoConvenioService 
    {	  
	   #region Singleton
	   private static volatile PrestamoConvenioService current;
	   private static object syncRoot = new Object();

	   //private PrestamoConvenioService() {}
	   public static PrestamoConvenioService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoConvenioService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
    public class PrestamoConvenioComposeService : EntityComposeService<PrestamoConvenioCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoConvenioComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoConvenioComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoConvenioComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoConvenioComposeService"; } }

        protected readonly PrestamoConvenioComposeBusiness Business = PrestamoConvenioComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoConvenioCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoConvenioCompose GetById(Int32 idProyecto)
        {
            return PrestamoConvenioComposeBusiness.Current.GetById(idProyecto);
        }
    }
}
