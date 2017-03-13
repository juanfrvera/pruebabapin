using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MessageMediaData : _MessageMediaData 
    {
	   #region Singleton
	   private static volatile MessageMediaData current;
	   private static object syncRoot = new Object();

	   //private MessageMediaData() {}
	   public static MessageMediaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageMediaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMessageMedia"; } }  
    }
}
