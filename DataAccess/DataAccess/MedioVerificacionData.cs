using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class MedioVerificacionData : _MedioVerificacionData 
    {
	   #region Singleton
	   private static volatile MedioVerificacionData current;
	   private static object syncRoot = new Object();

	   //private MedioVerificacionData() {}
	   public static MedioVerificacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new MedioVerificacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdMedioVerificacion"; } }   
    }
}
