using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using Business;
using Service.Base;

namespace Service
{
    public class FileInfoService : _FileInfoService 
    {	  
	   #region Singleton
	   private static volatile FileInfoService current;
	   private static object syncRoot = new Object();

	   //private FileInfoService() {}
	   public static FileInfoService Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FileInfoService();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override EntityServiceBehaviour Behaviour
       {
           get
           {
               return new EntityServiceBehaviour() { Audit = false , EntityIsSerializable = false };
           }
       }
    }
}
