using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class TextCategoryData : _TextCategoryData 
    { 
	   #region Singleton
	   private static volatile TextCategoryData current;
	   private static object syncRoot = new Object();

	   //private TextCategoryData() {}
	   public static TextCategoryData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextCategoryData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdTextCategory"; } }
    }
}
