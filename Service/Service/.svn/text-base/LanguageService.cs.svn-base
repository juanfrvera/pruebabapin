using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;
using System.Collections;

namespace Service
{
    public class LanguageService : _LanguageService 
    {	  
	   #region Singleton
	   private static volatile LanguageService current;
	   private static object syncRoot = new Object();

	   //private LanguageService() {}
	   public static LanguageService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new LanguageService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       protected override object ExecuteAction(Language entity, string actionName, IContextUser contextUser, Hashtable args)
       {
           switch (actionName)
           {
               case ActionConfig.COMPLETE:
                      Business.Complete(entity, contextUser);
                   break;
           }
           return null;
       }
    }
}
