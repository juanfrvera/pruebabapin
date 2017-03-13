using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class SubProgramaService : _SubProgramaService 
    {	  
	   #region Singleton
	   private static volatile SubProgramaService current;
	   private static object syncRoot = new Object();

	   //private SubProgramaService() {}
	   public static SubProgramaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubProgramaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
