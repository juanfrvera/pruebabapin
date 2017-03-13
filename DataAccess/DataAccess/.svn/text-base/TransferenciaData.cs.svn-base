using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class TransferenciaData : _TransferenciaData 
    { 
	   #region Singleton
	   private static volatile TransferenciaData current;
	   private static object syncRoot = new Object();

	   //private TransferenciaData() {}
	   public static TransferenciaData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TransferenciaData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdTransferencia"; } }

       protected override IQueryable<Transferencia> Query(TransferenciaFilter filter)
       {
           return (from o in this.Table
                   join t3 in this.Context.SubProgramas on o.IdSubPrograma equals t3.IdSubPrograma   
                   join t4 in this.Context.Programas on t3.IdPrograma equals t4.IdPrograma
                   join t5 in this.Context.Safs on t4.IdSAF equals t5.IdSaf
                   join t6 in this.Context.Jurisdiccions on t5.IdJurisdiccion equals t6.IdJurisdiccion
                   where (filter.IdTransferencia == null || filter.IdTransferencia == 0 || o.IdTransferencia == filter.IdTransferencia)
                   && (filter.IdSubPrograma == null || filter.IdSubPrograma == 0 || o.IdSubPrograma == filter.IdSubPrograma)
                   && (filter.Proyecto == null || o.Proyecto >= filter.Proyecto) && (filter.Proyecto_To == null || o.Proyecto <= filter.Proyecto_To)
                   && (filter.Actividad == null || o.Actividad >= filter.Actividad) && (filter.Actividad_To == null || o.Actividad <= filter.Actividad_To)
                   && (filter.Obra == null || o.Obra >= filter.Obra) && (filter.Obra_To == null || o.Obra <= filter.Obra_To)
                   && (filter.Denominacion == null || filter.Denominacion.Trim() == string.Empty || filter.Denominacion.Trim() == "%" || (filter.Denominacion.EndsWith("%") && filter.Denominacion.StartsWith("%") && (o.Denominacion.Contains(filter.Denominacion.Replace("%", "")))) || (filter.Denominacion.EndsWith("%") && o.Denominacion.StartsWith(filter.Denominacion.Replace("%", ""))) || (filter.Denominacion.StartsWith("%") && o.Denominacion.EndsWith(filter.Denominacion.Replace("%", ""))) || o.Denominacion == filter.Denominacion)
                   && (filter.IdClasificacionGasto == null || filter.IdClasificacionGasto == 0 || o.IdClasificacionGasto == filter.IdClasificacionGasto)
                   && (filter.IdClasificacionGeografica == null || filter.IdClasificacionGeografica == 0 || o.IdClasificacionGeografica == filter.IdClasificacionGeografica)
                   && (filter.IdPrograma == null || filter.IdPrograma == 0 || t4.IdPrograma == filter.IdPrograma)
                   && (filter.IdSaf == null || filter.IdSaf == 0 || t5.IdSaf == filter.IdSaf)
                   && (filter.IdJurisdiccion == null || filter.IdJurisdiccion == 0 || t6.IdJurisdiccion == filter.IdJurisdiccion)
                   && (filter.Activo == null || o.Activo == filter.Activo)

                   select o
                   ).AsQueryable();
       }

        protected override IQueryable<TransferenciaResult> QueryResult(TransferenciaFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.ClasificacionGastos on o.IdClasificacionGasto equals t1.IdClasificacionGasto   
				    join t2  in this.Context.ClasificacionGeograficas on o.IdClasificacionGeografica equals t2.IdClasificacionGeografica   
				    join t3  in this.Context.SubProgramas on o.IdSubPrograma equals t3.IdSubPrograma   
				    join t4 in this.Context.Programas on t3.IdPrograma equals  t4.IdPrograma
                    join t5 in this.Context.Safs on t4.IdSAF equals t5.IdSaf
                    join t6 in this.Context.Jurisdiccions on t5.IdJurisdiccion equals t6.IdJurisdiccion
                  select new TransferenciaResult(){
                     Codigo= (t6.Codigo + "." + t5.Codigo + "." + t4.Codigo + "." + o.Actividad + "/" + t2.Codigo + "/" + t1.Codigo),
					 IdTransferencia=o.IdTransferencia
					 ,IdSubPrograma=o.IdSubPrograma
					 ,Proyecto=o.Proyecto
					 ,Actividad=o.Actividad
					 ,Obra=o.Obra
					 ,Denominacion=o.Denominacion
					 ,IdClasificacionGasto=o.IdClasificacionGasto
					 ,IdClasificacionGeografica=o.IdClasificacionGeografica
					 ,Activo=o.Activo
					,ClasificacionGasto_Codigo= t1.Codigo	
						,ClasificacionGasto_Nombre= t1.Nombre	
						,ClasificacionGasto_IdClasificacionGastoTipo= t1.IdClasificacionGastoTipo	
						,ClasificacionGasto_IdCaracterEconomico= t1.IdCaracterEconomico	
						,ClasificacionGasto_Activo= t1.Activo	
						,ClasificacionGasto_IdClasificacionGastoPadre= t1.IdClasificacionGastoPadre	
						,ClasificacionGasto_BreadcrumbId= t1.BreadcrumbId	
						,ClasificacionGasto_BreadcrumbOrden= t1.BreadcrumbOrden	
						,ClasificacionGasto_Nivel= t1.Nivel	
						,ClasificacionGasto_Orden= t1.Orden	
						,ClasificacionGasto_Descripcion= t1.Descripcion	
						,ClasificacionGasto_DescripcionInvertida= t1.DescripcionInvertida	
						,ClasificacionGasto_IdClasificacionGastoRubro= t1.IdClasificacionGastoRubro	
						,ClasificacionGasto_Seleccionable= t1.Seleccionable	
						,ClasificacionGasto_BreadcrumbCode= t1.BreadcrumbCode	
						,ClasificacionGasto_DescripcionCodigo= t1.DescripcionCodigo	
						,ClasificacionGeografica_Codigo= t2.Codigo	
						,ClasificacionGeografica_Nombre= t2.Nombre	
						,ClasificacionGeografica_IdClasificacionGeograficaTipo= t2.IdClasificacionGeograficaTipo	
						,ClasificacionGeografica_IdClasificacionGeograficaPadre= t2.IdClasificacionGeograficaPadre	
						,ClasificacionGeografica_Activo= t2.Activo	
						,ClasificacionGeografica_Descripcion= t2.Descripcion	
						,ClasificacionGeografica_BreadcrumbId= t2.BreadcrumbId	
						,ClasificacionGeografica_BreadcrumOrden= t2.BreadcrumOrden	
						,ClasificacionGeografica_Orden= t2.Orden	
						,ClasificacionGeografica_Nivel= t2.Nivel	
						,ClasificacionGeografica_DescripcionInvertida= t2.DescripcionInvertida	
						,ClasificacionGeografica_Seleccionable= t2.Seleccionable	
						,ClasificacionGeografica_BreadcrumbCode= t2.BreadcrumbCode	
						,ClasificacionGeografica_DescripcionCodigo= t2.DescripcionCodigo	
						,SubPrograma_IdPrograma= t3.IdPrograma	
						,SubPrograma_Codigo= t3.Codigo	
						,SubPrograma_Nombre= t3.Nombre	
						,SubPrograma_FechaAlta= t3.FechaAlta	
						,SubPrograma_FechaBaja= t3.FechaBaja	
						,SubPrograma_Activo= t3.Activo
	                    ,Programa = t4.Codigo + " " + t4.Nombre
                        ,Saf = t5.Codigo
                        ,Jurisdiccion = t6.Codigo
                        ,ActividadDenominacion = o.Actividad + " - " + o.Denominacion
                        ,ObjetivoGasto = t1.Codigo + " - " + t1.Nombre
						}
                    ).AsQueryable();
        }
    }
}
