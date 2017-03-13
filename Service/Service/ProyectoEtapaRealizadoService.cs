using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProyectoEtapaRealizadoService : _ProyectoEtapaRealizadoService 
    {	  
	   #region Singleton
	   private static volatile ProyectoEtapaRealizadoService current;
	   private static object syncRoot = new Object();

	   //private ProyectoEtapaRealizadoService() {}
	   public static ProyectoEtapaRealizadoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoEtapaRealizadoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public bool ValidarEtapasRealizadas(ProyectoEtapaRealizadoResult ActualProyectoEtapaRealizada, ProyectoCronogramaCompose Entity, Int32 IdResult)
       {
           return ProyectoEtapaRealizadoBusiness.Current.ValidarEtapasRealizadas(ActualProyectoEtapaRealizada, Entity, IdResult);
       }
    }
}
