using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OrganismoTipoService : _OrganismoTipoService 
    {	  
	   #region Singleton
	   private static volatile OrganismoTipoService current;
	   private static object syncRoot = new Object();

	   //private OrganismoTipoService() {}
	   public static OrganismoTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OrganismoTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
