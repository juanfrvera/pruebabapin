using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OrganismoFinancieroService : _OrganismoFinancieroService 
    {	  
	   #region Singleton
	   private static volatile OrganismoFinancieroService current;
	   private static object syncRoot = new Object();

	   //private OrganismoFinancieroService() {}
	   public static OrganismoFinancieroService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoFinancieroService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
