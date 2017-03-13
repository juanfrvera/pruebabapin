using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MessageSendService : _MessageSendService 
    {	  
	   #region Singleton
	   private static volatile MessageSendService current;
	   private static object syncRoot = new Object();

	   //private MessageSendService() {}
	   public static MessageSendService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageSendService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
