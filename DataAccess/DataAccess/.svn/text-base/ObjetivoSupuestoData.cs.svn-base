using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ObjetivoSupuestoData : _ObjetivoSupuestoData
    {
	   #region Singleton
	   private static volatile ObjetivoSupuestoData current;
	   private static object syncRoot = new Object();

	   //private ObjetivoSupuestoData() {}
	   public static ObjetivoSupuestoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoSupuestoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdObjetivoSupuesto"; } }   

       protected override IQueryable<ObjetivoSupuesto> Query(ObjetivoSupuestoFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdObjetivoSupuesto == null || o.IdObjetivoSupuesto >= filter.IdObjetivoSupuesto) && (filter.IdObjetivoSupuesto_To == null || o.IdObjetivoSupuesto <= filter.IdObjetivoSupuesto_To)
                   && (filter.IdObjetivo == null || filter.IdObjetivo == 0 || o.IdObjetivo == filter.IdObjetivo)
                   && (filter.Descripcion == null || filter.Descripcion.Trim() == string.Empty || filter.Descripcion.Trim() == "%" || (filter.Descripcion.EndsWith("%") && filter.Descripcion.StartsWith("%") && (o.Descripcion.Contains(filter.Descripcion.Replace("%", "")))) || (filter.Descripcion.EndsWith("%") && o.Descripcion.StartsWith(filter.Descripcion.Replace("%", ""))) || (filter.Descripcion.StartsWith("%") && o.Descripcion.EndsWith(filter.Descripcion.Replace("%", ""))) || o.Descripcion == filter.Descripcion)
                   && (filter.IdsObjetivos == null || filter.IdsObjetivos.Count == 0|| (filter.IdsObjetivos.Contains(o.IdObjetivo)))
                   select o
                   ).AsQueryable();
       }
    }
}
