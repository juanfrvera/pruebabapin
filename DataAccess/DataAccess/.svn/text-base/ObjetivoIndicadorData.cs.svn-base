using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class ObjetivoIndicadorData : _ObjetivoIndicadorData 
    { 
	   #region Singleton
	   private static volatile ObjetivoIndicadorData current;
	   private static object syncRoot = new Object();

	   //private ObjetivoIndicadorData() {}
	   public static ObjetivoIndicadorData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new ObjetivoIndicadorData();
				}
			 }
			 return current;
		  }
	   }


       protected override IQueryable<ObjetivoIndicadorResult> QueryResult(ObjetivoIndicadorFilter filter)
       {
           return (from o in Query(filter)
                   join t1 in this.Context.Indicadors on o.IdIndicador equals t1.IdIndicador
                   join t2 in this.Context.IndicadorClases on o.IdIndicadorClase equals t2.IdIndicadorClase
                   join t3 in this.Context.Objetivos on o.IdObjetivo equals t3.IdObjetivo
                   //join _t1 in this.Context.Prestamos on o.IdPrestamo equals _t1.IdPrestamo into tt1 from t1 in tt1.DefaultIfEmpty()
                   join _t4 in this.Context.MedioVerificacions on t1.IdMedioVerificacion equals _t4.IdMedioVerificacion into tt4 from t4 in tt4.DefaultIfEmpty()
                   //join t4 in this.Context.MedioVerificacions on t1.IdMedioVerificacion equals t4.IdMedioVerificacion
                   //join t5 in this.Context.UnidadMedidas on t2.IdUnidad equals t5.IdUnidadMedida
                   join _t5 in this.Context.UnidadMedidas on t2.IdUnidad equals _t5.IdUnidadMedida into tt5 from t5 in tt5.DefaultIfEmpty()
                   select new ObjetivoIndicadorResult()
                   {
                       IdObjetivoIndicador = o.IdObjetivoIndicador
                       ,
                       IdObjetivo = o.IdObjetivo
                       ,
                       IdIndicadorClase = o.IdIndicadorClase
                       ,
                       IdIndicador = o.IdIndicador
                       ,
                       Indicador_IdMedioVerificacion = t1.IdMedioVerificacion
                       ,
                       Indicador_Observacion = t1.Observacion
                       ,
                       IndicadorClase_IdIndicadorTipo = t2.IdIndicadorTipo
                       ,
                       IndicadorClase_Sigla = t2.Sigla
                       ,
                       IndicadorClase_Nombre = t2.Nombre
                       ,
                       IndicadorClase_IdUnidad = t2.IdUnidad
                       ,
                       IndicadorClase_RangoInicial = t2.RangoInicial
                       ,
                       IndicadorClase_RangoFinal = t2.RangoFinal
                       ,
                       IndicadorClase_Activo = t2.Activo
                       ,
                       Objetivo_Nombre = t3.Nombre
                       ,
                       Indicador_MedioVerificacion= t4!=null?(string)t4.Nombre:null
                       ,
                       IndicadorClase_Unidad = t5 != null ? (string)t5.Nombre : null
                       //,
                       //IdIndicadorRubro = (from r in this.Context.IndicadorRelacionRubros
                       //                    where o.IdIndicadorClase == r.IdIndicadorClase
                       //                    select r.IdIndicadorRubro).FirstOrDefault()
                       //German 20140511 - Tarea 124
                       ,
                       IdIndicadorRubro = t1.IdIndicadorRubro
                       , DetalleMedioVerificacion = t1.DetalleMedioVerificacion
                       //German 20140511 - Tarea 124
                   }
                     ).AsQueryable();
       }


       #endregion
       public override string IdFieldName { get { return "IdObjetivoIndicador"; } }  
    }
}
