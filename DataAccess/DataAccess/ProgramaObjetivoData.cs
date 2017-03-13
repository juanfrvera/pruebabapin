using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProgramaObjetivoData : _ProgramaObjetivoData 
    {
	   #region Singleton
	   private static volatile ProgramaObjetivoData current;
	   private static object syncRoot = new Object();

	   //private ProgramaObjetivoData() {}
	   public static ProgramaObjetivoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProgramaObjetivoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProgramaObjetivo"; } }
    }
}
