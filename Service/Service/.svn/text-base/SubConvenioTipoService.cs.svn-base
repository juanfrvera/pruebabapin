using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SubConvenioTipoService : _SubConvenioTipoService 
    {	  
	   #region Singleton
	   private static volatile SubConvenioTipoService current;
	   private static object syncRoot = new Object();

	   //private SubConvenioTipoService() {}
	   public static SubConvenioTipoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubConvenioTipoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
