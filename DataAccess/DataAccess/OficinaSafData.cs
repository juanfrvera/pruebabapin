using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class OficinaSafData : _OficinaSafData
    {
	   #region Singleton
	   private static volatile OficinaSafData current;
	   private static object syncRoot = new Object();

	   //private OficinaSafData() {}
	   public static OficinaSafData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new OficinaSafData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdOficinaSaf"; } }  
       #region Query
       protected override IQueryable<OficinaSaf> Query(OficinaSafFilter filter)
       {
           return (from o in this.Table
                   where (filter.IdOficinaSaf == null || filter.IdOficinaSaf == 0 || o.IdOficinaSaf == filter.IdOficinaSaf)
                   && (filter.IdOficina == null || filter.IdOficina == 0 || o.IdOficina == filter.IdOficina)
                   && (filter.IdSaf == null || filter.IdSaf == 0 || o.IdSaf == filter.IdSaf)
                   && (filter.Saf_Activo == null || o.Saf.Activo == filter.Saf_Activo)
                   select o
                   ).AsQueryable();
       }
    #endregion
    }
}
