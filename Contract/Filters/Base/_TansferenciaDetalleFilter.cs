using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TansferenciaDetalleFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		public int? IdTansferenciaDetalle{get;set;}		
public int? IdTansferenciaDetalle_To{get;set;}		
public int? IdTransferencia{get;set;}		
public int? IdFuenteFinanciamiento{get;set;}		
public int? IdMoneda{get;set;}		
public int? IdFinalidadFuncion{get;set;}		
public int? IdClasificacionGeografica{get;set;}		
public decimal? Inicial{get;set;}		
public decimal? Inicial_To{get;set;}		
public decimal? Vigente{get;set;}		
public decimal? Vigente_To{get;set;}		
public decimal? Comprometido{get;set;}		
public decimal? Comprometido_To{get;set;}		
public decimal? Devengado{get;set;}		
public decimal? Devengado_To{get;set;}		
public decimal? Pagado{get;set;}		
public decimal? Pagado_To{get;set;}		

		#endregion
    }
}
