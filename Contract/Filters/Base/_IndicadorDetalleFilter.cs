using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _IndicadorDetalleFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		public int? IdIndicadorDetalle{get;set;}		
public bool? IdMedioVerificacionIsNull{get;set;}public int? IdMedioVerificacion{get;set;}		
public string Observacion
		  {
		   get{ if(_Observacion==null)_Observacion= string.Empty;
				return _Observacion; 
				}
		   set{ _Observacion=value;}
		  }
		 
		#endregion
    }
}
