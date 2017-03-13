using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ComentarioTecnicoData : _ComentarioTecnicoData 
    {
	   #region Singleton
	   private static volatile ComentarioTecnicoData current;
	   private static object syncRoot = new Object();

	   //private ComentarioTecnicoData() {}
	   public static ComentarioTecnicoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ComentarioTecnicoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdComentarioTecnico"; } }  
    }
}
