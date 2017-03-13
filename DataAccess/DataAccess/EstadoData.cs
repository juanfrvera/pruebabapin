using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class EstadoData : _EstadoData
    {
	   #region Singleton
	   private static volatile EstadoData current;
	   private static object syncRoot = new Object();

	   //private EstadoData() {}
	   public static EstadoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new EstadoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdEstado"; } }

       protected override IQueryable<Estado> Query(EstadoFilter filter)
       {
           var a = (from o in base.Query(filter)
                   where (filter.IdEstado == null || filter.IdEstado == 0 || filter.IdEstado == o.IdEstado)
                      && (filter.IdSistemaEntidad == null || filter.IdSistemaEntidad == 0 || (from ses in this.Context.SistemaEntidadEstados where ses.IdSistemaEntidad == filter.IdSistemaEntidad select ses.IdEstado).Contains(o.IdEstado))
                      && (filter.EntidadTipo == null || filter.EntidadTipo == string.Empty || (from ses in  this.Context.SistemaEntidadEstados 
                                                                                              where  (from e in this.Context.SistemaEntidads 
                                                                                                      where e.EntidadTipo == filter.EntidadTipo 
                                                                                                      select e.IdSistemaEntidad).Contains(ses.IdSistemaEntidad) 
                                                                                              select ses.IdEstado).Contains(o.IdEstado))
                     && (filter.EntidadClase == null || filter.EntidadClase == string.Empty || (from ses in this.Context.SistemaEntidadEstados
                                                                                             where (from e in this.Context.SistemaEntidads
                                                                                                    where e.EntidadClase == filter.EntidadClase
                                                                                                    select e.IdSistemaEntidad).Contains(ses.IdSistemaEntidad)
                                                                                             select ses.IdEstado).Contains(o.IdEstado)) 
                   orderby o.Orden
                   select o                   
                   ).AsQueryable();


           return a;
       }
    }
}
