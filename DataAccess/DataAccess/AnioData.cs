using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class AnioData : _AnioData 
    {
	   #region Singleton
	   private static volatile AnioData current;
	   private static object syncRoot = new Object();

	   //private AnioData() {}
	   public static AnioData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new AnioData();
				}
			 }
			 return current;
		  }
	   }

       #endregion
       public override string IdFieldName { get { return "IdAnio"; } }


   

    }
}
