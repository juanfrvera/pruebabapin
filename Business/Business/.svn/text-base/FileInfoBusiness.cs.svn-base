using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;

namespace Business
{
    public class FileInfoBusiness : _FileInfoBusiness 
    {   
	   #region Singleton
	   private static volatile FileInfoBusiness current;
	   private static object syncRoot = new Object();

	   //private FileInfoBusiness() {}
	   public static FileInfoBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FileInfoBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion
    }
}
