using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OrganismoPrioridadService : _OrganismoPrioridadService 
    {	  
	   #region Singleton
	   private static volatile OrganismoPrioridadService current;
	   private static object syncRoot = new Object();

	   //private OrganismoPrioridadService() {}
	   public static OrganismoPrioridadService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoPrioridadService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
