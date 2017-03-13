using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class OficinaSafProgramaService : _OficinaSafProgramaService 
    {	  
	   #region Singleton
	   private static volatile OficinaSafProgramaService current;
	   private static object syncRoot = new Object();

	   //private OficinaSafProgramaService() {}
	   public static OficinaSafProgramaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaSafProgramaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
