using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ProyectoLocalizacionData : _ProyectoLocalizacionData 
    { 
	   #region Singleton
	   private static volatile ProyectoLocalizacionData current;
	   private static object syncRoot = new Object();

	   //private ProyectoLocalizacionData() {}
	   public static ProyectoLocalizacionData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ProyectoLocalizacionData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdProyectoLocalizacion"; } }

       public void DeleteBranch(int idProyecto, int idClasificacionGeografica)
       {
           List<int> branch = (from cg in this.Context.ClasificacionGeograficas
                                                   where cg.BreadcrumbId.StartsWith("."+idClasificacionGeografica+".")
                                                   select cg.IdClasificacionGeografica).ToList();

           List<ProyectoLocalizacion> deletes = (from pl in this.Table
                                                where pl.IdProyecto == idProyecto
                                                   && branch.Contains(pl.IdClasificacionGeografica)
                                               select pl).ToList();

           ProyectoLocalizacionData.Current.Delete(deletes);
       }
       protected override IQueryable<ProyectoLocalizacion> Query(ProyectoLocalizacionFilter filter)
       {
           return (from o in base.Query(filter)
            where (filter.IdsProyecto == null || filter.IdsProyecto.Count == 0 || filter.IdsProyecto.Contains(o.IdProyecto)
                )
            select o
            ).AsQueryable();
                 
       }
    }
}
