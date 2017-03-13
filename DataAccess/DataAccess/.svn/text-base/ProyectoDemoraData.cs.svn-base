using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoDemoraData : _ProyectoDemoraData
    {
	   #region Singleton
	   private static volatile ProyectoDemoraData current;
	   private static object syncRoot = new Object();

	   //private ProyectoDemoraData() {}
	   public static ProyectoDemoraData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoDemoraData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoDemora"; } }
    }
}
