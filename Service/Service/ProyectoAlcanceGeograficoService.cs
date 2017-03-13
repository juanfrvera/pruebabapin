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
    public class ProyectoAlcanceGeograficoService : _ProyectoAlcanceGeograficoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoAlcanceGeograficoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoAlcanceGeograficoService() {}
	   public static ProyectoAlcanceGeograficoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoAlcanceGeograficoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
    public class ProyectoAlcanceGeograficoComposeService : EntityComposeService<ProyectoAlcanceGeograficoCompose, ProyectoFilter, ProyectoResult, int>
    {
        #region Singleton
        private static volatile ProyectoAlcanceGeograficoComposeService current;
        private static object syncRoot = new Object();

        public static ProyectoAlcanceGeograficoComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoAlcanceGeograficoComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoAlcanceGeograficoComposeService"; } }

        protected readonly ProyectoAlcanceGeograficoComposeBusiness Business = ProyectoAlcanceGeograficoComposeBusiness.Current ;
        protected override IEntityBusiness<ProyectoAlcanceGeograficoCompose, ProyectoFilter, ProyectoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoService.Current.Execute(id, actionName, contextUser, args);
        }

        public ProyectoAlcanceGeograficoCompose GetById(Int32 idProyecto)
        {
            return ProyectoAlcanceGeograficoComposeBusiness.Current.GetById(idProyecto);
        }
    }
}
