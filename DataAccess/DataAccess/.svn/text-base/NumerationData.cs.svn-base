using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class NumerationData : _NumerationData 
    {
	   #region Singleton
	   private static volatile NumerationData current;
	   private static object syncRoot = new Object();

	   //private NumerationData() {}
	   public static NumerationData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new NumerationData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdNumeration"; } }

       private static readonly Object lockObject = new Object();//Matias 20161025 - Variable para implementar LOCK al momento de generar un nuevo codigo BAPIN
       
       public int GetNext(string code)
       {
           lock (lockObject) //Matias 20161025 - Variable para implementar LOCK al momento de generar un nuevo codigo BAPIN
           {
               Numeration numeration = this.FirstOrDefault(new NumerationFilter() { Code = code });
               DataHelper.Validate(numeration != null, "InvalidNumeration");
               numeration.Lastvalue = numeration.Lastvalue + 1;
               this.Update(numeration);
               return numeration.Lastvalue;
           }
       }
    }
}
