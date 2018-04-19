using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaInformacionPresupuestariaService : _ProyectoEtapaInformacionPresupuestariaService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaInformacionPresupuestariaService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaInformacionPresupuestariaService() {}
	   public static ProyectoEtapaInformacionPresupuestariaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaInformacionPresupuestariaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public bool ValidarEtapasInformacionPresupuestarias(ProyectoEtapaInformacionPresupuestariaResult ActualProyectoEtapaInformacionPresupuestaria, ProyectoCronogramaCompose Entity, Int32 IdResult)
       {
           return ProyectoEtapaInformacionPresupuestariaBusiness.Current.ValidarEtapasInformacionPresupuestarias(ActualProyectoEtapaInformacionPresupuestaria, Entity, IdResult);
       }
    }
}
