using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoSubComponenteData : _PrestamoSubComponenteData 
    { 
	   #region Singleton
	   private static volatile PrestamoSubComponenteData current;
	   private static object syncRoot = new Object();

	   //private PrestamoSubComponenteData() {}
	   public static PrestamoSubComponenteData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoSubComponenteData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoSubComponente"; } } 

       public List<PrestamoSubComponenteResult> GetResultByPrestamoId(int id)
       {
           return (from s in this.Table
                   join c in this.Context.PrestamoComponentes on s.IdPrestamoComponente equals c.IdPrestamoComponente
                   where c.IdPrestamo == id
                   select new PrestamoSubComponenteResult ()
                   { 
                       Descripcion = s.Descripcion,
                       IdPrestamoComponente = s.IdPrestamoComponente,
                       IdPrestamoSubComponente = s.IdPrestamoSubComponente
                   }
                   ).ToList();
       }
       public List<PrestamoSubComponente> GetByPrestamoId(int id)
       {
           return (from s in this.Table
                   join c in this.Context.PrestamoComponentes on s.IdPrestamoComponente equals c.IdPrestamoComponente
                   where c.IdPrestamo == id
                   select s).ToList();
       }
    }
}
