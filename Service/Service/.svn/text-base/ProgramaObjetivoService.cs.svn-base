using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProgramaObjetivoService : _ProgramaObjetivoService 
    {	  
	   #region Singleton
	   private static volatile ProgramaObjetivoService current;
	   private static object syncRoot = new Object();

	   //private ProgramaObjetivoService() {}
	   public static ProgramaObjetivoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaObjetivoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
