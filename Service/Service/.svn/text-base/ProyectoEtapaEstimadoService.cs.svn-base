using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaEstimadoService : _ProyectoEtapaEstimadoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaEstimadoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaEstimadoService() {}
	   public static ProyectoEtapaEstimadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaEstimadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public bool ValidarEtapasEstimadas(ProyectoEtapaEstimadoResult ActualProyectoEtapaEstimada, ProyectoCronogramaCompose Entity, Int32 IdResult)
       {
           return ProyectoEtapaEstimadoBusiness.Current.ValidarEtapasEstimadas(ActualProyectoEtapaEstimada, Entity, IdResult);
       }
    }
}
