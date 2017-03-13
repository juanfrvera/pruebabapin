using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class PrestamoProductoData : _PrestamoProductoData 
    { 
	   #region Singleton
	   private static volatile PrestamoProductoData current;
	   private static object syncRoot = new Object();

	   //private PrestamoProductoData() {}
	   public static PrestamoProductoData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new PrestamoProductoData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdPrestamoProducto"; } } 

       public List<PrestamoProductoResult> GetResultByPrestamoId(int id)
       {
           return (from p in this.Table
                   join c in this.Context.PrestamoComponentes on p.IdPrestamoComponente equals c.IdPrestamoComponente
                   join y in this.Context.Proyectos on p.IdProyecto equals y.IdProyecto into aux
                   from yt in aux.DefaultIfEmpty()
                   join sc in this.Context.PrestamoSubComponentes on p.IdPrestamoSubComponente equals sc.IdPrestamoSubComponente into aux2
                   from sct in aux2.DefaultIfEmpty()
                   /*Matias 20170222 - Ticket #REQ217514*/
                   join e in this.Context.Estados on yt.IdEstado equals e.IdEstado into auxEstado
                   from et in auxEstado.DefaultIfEmpty()
                   /*FinMatias 20170222 - Ticket #REQ217514*/

                   where c.IdPrestamo == id
                   select new PrestamoProductoResult()
                   {
                       IdPrestamoProducto = p.IdPrestamoProducto,
                       IdPrestamoComponente = p.IdPrestamoComponente,
                       IdPrestamoSubComponente = p.IdPrestamoSubComponente,
                       Descripcion = p.Descripcion,
                       MontoPrestamo = p.MontoPrestamo,
                       MontoContraparte = p.MontoContraparte,
                       InicioGestion = p.InicioGestion,
                       NegociarAutorizacion = p.NegociarAutorizacion,
                       Ejecucion = p.Ejecucion,
                       IdProyecto = p.IdProyecto,
                       IdProyectoOrigenFinanciamiento = p.IdProyectoOrigenFinanciamiento,
                       Proyecto_Codigo = yt == null ? null : (int?)yt.Codigo,
                       Proyecto_ProyectoDenominacion = yt == null ? null : yt.ProyectoDenominacion,
                       
                       // Propiedades para el listado
                       Componente = c.Objetivo.Nombre,
                       SubComponente = sct.IdPrestamoSubComponente > 0 ? sct.Descripcion : "",
                       MContraparte = string.Format("{0:F2}", p.MontoContraparte),
                       MPrestamo = string.Format("{0:F2}",p.MontoPrestamo),
                       StrIGestion =  p.InicioGestion == true? SolutionContext.Current.TextManager.Translate("Si") : 
                                                               SolutionContext.Current.TextManager.Translate("No"),
                       StrANegociar = p.NegociarAutorizacion == true ? SolutionContext.Current.TextManager.Translate("Si") :
                                                                       SolutionContext.Current.TextManager.Translate("No"),
                       StrEjecucion = p.Ejecucion == true ? SolutionContext.Current.TextManager.Translate("Si") :
                                                            SolutionContext.Current.TextManager.Translate("No"),
                       
                       //Matias 20140429 - Tarea 145
                       //BAPIN = yt.NroProyecto != null ? yt.Codigo.ToString() : ""
                       BAPIN = yt.Codigo != null ? yt.Codigo.ToString() : "",
                       //FinMatias 20140429 - Tarea 145
                       ProyectoEstado = et.IdEstado != null ? et.Nombre : ""  /*Matias 20170222 - Ticket #REQ217514*/
                   
                   }).ToList();
       }

       public List<PrestamoProducto> GetByPrestamoId(int id)
       {
           return (from p in this.Table
                   join c in this.Context.PrestamoComponentes on p.IdPrestamoComponente equals c.IdPrestamoComponente
                   where c.IdPrestamo == id
                   select p).ToList();
       }

        protected override IQueryable<PrestamoProductoResult> QueryResult(PrestamoProductoFilter filter)
        {
            return (from o in Query(filter)
                    join t1 in this.Context.PrestamoComponentes on o.IdPrestamoComponente equals t1.IdPrestamoComponente
                    join _t2 in this.Context.PrestamoSubComponentes on o.IdPrestamoSubComponente equals _t2.IdPrestamoSubComponente into tt2
                    from t2 in tt2.DefaultIfEmpty()
                    join _t3 in this.Context.Proyectos on o.IdProyecto equals _t3.IdProyecto into tt3
                    from t3 in tt3.DefaultIfEmpty()
                    where ( filter.IdPrestamo == null || filter.IdPrestamo == 0 || filter.IdPrestamo == t1.IdPrestamo )
				   select new PrestamoProductoResult(){
					 IdPrestamoProducto=o.IdPrestamoProducto
					 ,IdPrestamoComponente=o.IdPrestamoComponente
					 ,IdPrestamoSubComponente=o.IdPrestamoSubComponente
					 ,Descripcion=o.Descripcion
					 ,MontoPrestamo=o.MontoPrestamo
					 ,MontoContraparte=o.MontoContraparte
					 ,InicioGestion=o.InicioGestion
					 ,NegociarAutorizacion=o.NegociarAutorizacion
					 ,Ejecucion=o.Ejecucion
					 ,IdProyecto=o.IdProyecto
                     ,IdProyectoOrigenFinanciamiento= o.IdProyectoOrigenFinanciamiento
					 ,PrestamoComponente_IdPrestamo= t1.IdPrestamo	
						,PrestamoComponente_IdObjetivo= t1.IdObjetivo	
						,PrestamoSubComponente_IdPrestamoComponente= t2!=null?(int?)t2.IdPrestamoComponente:null	
						,PrestamoSubComponente_Descripcion= t2!=null?(string)t2.Descripcion:null	
                        
						}
                    ).AsQueryable();
        }
    }
}
