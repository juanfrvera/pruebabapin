using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class IndicadorEvolucionData : _IndicadorEvolucionData 
    {   
	   #region Singleton
	   private static volatile IndicadorEvolucionData current;
	   private static object syncRoot = new Object();

	   //private IndicadorEvolucionData() {}
	   public static IndicadorEvolucionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new IndicadorEvolucionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdIndicadorEvolucion"; } }


        /*
       protected override IQueryable<IndicadorEvolucion> Query(IndicadorEvolucionFilter filter)
       {
           return (from o in Query(filter)
                   where (filter.IdsIndicadores == null || filter.IdsIndicadores.Count == 0 || (filter.IdsIndicadores.Contains(o.IdIndicador)))
                   select o
                   ).AsQueryable();
       }	
        */
    }
}
