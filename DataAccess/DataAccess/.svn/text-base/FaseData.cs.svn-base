using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class FaseData : _FaseData 
    {
	   #region Singleton
	   private static volatile FaseData current;
	   private static object syncRoot = new Object();

	   //private FaseData() {}
	   public static FaseData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new FaseData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdFase"; } } 
    }
}
