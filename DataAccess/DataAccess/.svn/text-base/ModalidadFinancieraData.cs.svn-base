using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ModalidadFinancieraData : _ModalidadFinancieraData 
    {
	   #region Singleton
	   private static volatile ModalidadFinancieraData current;
	   private static object syncRoot = new Object();

	   //private ModalidadFinancieraData() {}
	   public static ModalidadFinancieraData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadFinancieraData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdModalidadFinanciera"; } }    
    }
}
