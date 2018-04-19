using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaInformacionPresupuestariaPeriodoService : _ProyectoEtapaInformacionPresupuestariaPeriodoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaInformacionPresupuestariaPeriodoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaInformacionPresupuestariaPeriodoService() {}
	   public static ProyectoEtapaInformacionPresupuestariaPeriodoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaInformacionPresupuestariaPeriodoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
