using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ModalidadContratacionData : _ModalidadContratacionData
    {
	   #region Singleton
	   private static volatile ModalidadContratacionData current;
	   private static object syncRoot = new Object();

	   //private ModalidadContratacionData() {}
	   public static ModalidadContratacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ModalidadContratacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdModalidadContratacion"; } }   
    }
}
