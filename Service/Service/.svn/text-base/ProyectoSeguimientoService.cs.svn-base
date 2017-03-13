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
    public class ProyectoSeguimientoService : _ProyectoSeguimientoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoSeguimientoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoSeguimientoService() {}
	   public static ProyectoSeguimientoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoSeguimientoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }

    public class ProyectoSeguimientoComposeService : EntityComposeService<ProyectoSeguimientoCompose, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int>
    {
        #region Singleton
        private static volatile ProyectoSeguimientoComposeService current;
        private static object syncRoot = new Object();

        //private SolicitudService() {}
        public static ProyectoSeguimientoComposeService Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new ProyectoSeguimientoComposeService();
                    }
                }
                return current;
            }
        }
        #endregion

        public override string ServiceName { get { return "ProyectoSeguimientoComposeService"; } }

        protected readonly ProyectoSeguimientoComposeBusiness Business = ProyectoSeguimientoComposeBusiness.Current;
        protected override IEntityBusiness<ProyectoSeguimientoCompose, ProyectoSeguimientoFilter, ProyectoSeguimientoResult, int> EntityBusiness
        {
            get { return this.Business; }
        }
        protected override object ExecuteAction(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return ProyectoSeguimientoService.Current.Execute(id, actionName, contextUser, args);
        }
        public List<ProyectoSeguimientoLocalizacionResult> AlcanceGeograficoToProyectoSeguimientoLocalizacion()
        {
            return Business.AlcanceGeograficoToProyectoSeguimientoLocalizacion();
        }
        public List<ProyectoSeguimientoLocalizacionResult> AlcanceGeograficoToProyectoSeguimientoLocalizacion(List<Int32> Ids)
        {
            return Business.AlcanceGeograficoToProyectoSeguimientoLocalizacion(Ids);
        }
    }

}
