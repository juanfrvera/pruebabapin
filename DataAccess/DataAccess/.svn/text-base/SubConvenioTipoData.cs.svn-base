using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class SubConvenioTipoData : _SubConvenioTipoData 
    {  
	   #region Singleton
	   private static volatile SubConvenioTipoData current;
	   private static object syncRoot = new Object();

	   //private SubConvenioTipoData() {}
	   public static SubConvenioTipoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new SubConvenioTipoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdSubConvenioTipo"; } }
    }
}
