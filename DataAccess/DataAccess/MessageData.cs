using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MessageData : _MessageData 
    {    
	   #region Singleton
	   private static volatile MessageData current;
	   private static object syncRoot = new Object();

	   //private MessageData() {}
	   public static MessageData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MessageData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMessage"; } } 
    }
}
