using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SectorData : _SectorData 
    { 
	   #region Singleton
	   private static volatile SectorData current;
	   private static object syncRoot = new Object();

	   //private SectorData() {}
	   public static SectorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SectorData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSector"; } } 
    }
}
