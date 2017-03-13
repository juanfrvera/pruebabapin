using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SubJurisdiccionData : _SubJurisdiccionData 
    { 
	   #region Singleton
	   private static volatile SubJurisdiccionData current;
	   private static object syncRoot = new Object();

	   //private SubJurisdiccionData() {}
	   public static SubJurisdiccionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubJurisdiccionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSubJurisdiccion"; } } 
    }
}
