using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoOficinaPerfilData : _PrestamoOficinaPerfilData
    {
	   #region Singleton
	   private static volatile PrestamoOficinaPerfilData current;
	   private static object syncRoot = new Object();

	   //private PrestamoOficinaPerfilData() {}
	   public static PrestamoOficinaPerfilData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoOficinaPerfilData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoOficinaPerfil"; } } 

       protected override IQueryable<PrestamoOficinaPerfil> Query(PrestamoOficinaPerfilFilter filter)
       {
           return (from o in base.Query(filter)
                   join t2 in this.Context.Perfils on o.IdPerfil equals t2.IdPerfil
                   where (filter.IdsPrestamo == null || filter.IdsPrestamo.Count == 0 || filter.IdsPrestamo.Contains(o.IdPrestamo)) &&
                         (filter.CodigoPerfil == null || filter.CodigoPerfil.Trim() == "" || t2.Codigo == filter.CodigoPerfil)
                   select o).AsQueryable();
       }
    }
}
