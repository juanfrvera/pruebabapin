using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoPropositoData : _ProyectoPropositoData 
    { 
	   #region Singleton
	   private static volatile ProyectoPropositoData current;
	   private static object syncRoot = new Object();

	   //private ProyectoPropositoData() {}
	   public static ProyectoPropositoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoPropositoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoProposito"; } }
    }
}
