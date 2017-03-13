using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoEstadoAsociadoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		public int? IdPrestamoEstadoasociado{get;set;}		
public int? IdPrestamoEstadoasociado_To{get;set;}		
public int? IdPrestamo{get;set;}		
public int? IdEstado{get;set;}		
public DateTime? FechaEstimada{get;set;}		
public DateTime? FechaEstimada_To{get;set;}		
public bool? FechaRealizadaIsNull{get;set;}public DateTime? FechaRealizada{get;set;}		
public DateTime? FechaRealizada_To{get;set;}		

		#endregion
    }
}
