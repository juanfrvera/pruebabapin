using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class ProgramaService : _ProgramaService 
    {	  
	   #region Singleton
	   private static volatile ProgramaService current;
	   private static object syncRoot = new Object();

	   //private ProgramaService() {}
	   public static ProgramaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
       public virtual ProgramaResult GetResultById(int id)
       {
           return Business.GetResultById(id);
       }

    }
}
