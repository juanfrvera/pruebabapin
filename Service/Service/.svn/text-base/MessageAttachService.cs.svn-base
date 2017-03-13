using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class MessageAttachService : _MessageAttachService 
    {	  
	   #region Singleton
	   private static volatile MessageAttachService current;
	   private static object syncRoot = new Object();

	   //private MessageAttachService() {}
	   public static MessageAttachService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageAttachService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
