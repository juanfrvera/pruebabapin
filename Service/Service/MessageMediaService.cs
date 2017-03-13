using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MessageMediaService : _MessageMediaService 
    {	  
	   #region Singleton
	   private static volatile MessageMediaService current;
	   private static object syncRoot = new Object();

	   //private MessageMediaService() {}
	   public static MessageMediaService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageMediaService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
