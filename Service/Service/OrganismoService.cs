using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OrganismoService : _OrganismoService 
    {	  
	   #region Singleton
	   private static volatile OrganismoService current;
	   private static object syncRoot = new Object();

	   //private OrganismoService() {}
	   public static OrganismoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
