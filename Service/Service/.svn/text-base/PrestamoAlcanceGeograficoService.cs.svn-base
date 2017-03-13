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
    public class PrestamoAlcanceGeograficoService : _PrestamoAlcanceGeograficoService 
    {	  
	   #region Singleton
	   private static volatile PrestamoAlcanceGeograficoService current;
	   private static object syncRoot = new Object();

	   //private PrestamoAlcanceGeograficoService() {}
	   public static PrestamoAlcanceGeograficoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoAlcanceGeograficoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
    public class PrestamoAlcanceGeograficoComposeService : EntityComposeService<PrestamoAlcanceGeograficoCompose, PrestamoFilter, PrestamoResult, int>
    {
        #region Singleton
        private static volatile PrestamoAlcanceGeograficoComposeService current;
        private static object syncRoot = new Object();

        public static PrestamoAlcanceGeograficoComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PrestamoAlcanceGeograficoComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "PrestamoAlcanceGeograficoComposeService"; } }

        protected readonly PrestamoAlcanceGeograficoComposeBusiness Business = PrestamoAlcanceGeograficoComposeBusiness.Current;
        protected override IEntityBusiness<PrestamoAlcanceGeograficoCompose, PrestamoFilter, PrestamoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return PrestamoService.Current.Execute(id, actionName, contextUser, args);
        }

        public PrestamoAlcanceGeograficoCompose GetById(Int32 idPrestamo)
        {
            return PrestamoAlcanceGeograficoComposeBusiness.Current.GetById(idPrestamo);
        }
    }
}
