using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoIndicadorEconomicoFilter : Filter
    {   
		#region Private
		private string _Observacion;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoIndicadorEconomico", IsRequired = false)]public int? IdProyectoIndicadorEconomico{get;set;}		
[DataMember(Name = "IdProyectoIndicadorEconomico_To", IsRequired = false)]		
public int? IdProyectoIndicadorEconomico_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdIndicadorClase", IsRequired = false)]public int? IdIndicadorClase{get;set;}		
[DataMember(Name = "ValorIsNull", IsRequired = false)]
			  public bool? ValorIsNull{get;set;}[DataMember(Name = "Valor", IsRequired = false)]public decimal? Valor{get;set;}		
[DataMember(Name = "Valor_To", IsRequired = false)]		
public decimal? Valor_To{get;set;}		
[DataMember(Name = "AnioIsNull", IsRequired = false)]
			  public bool? AnioIsNull{get;set;}[DataMember(Name = "Anio", IsRequired = false)]public int? Anio{get;set;}		
[DataMember(Name = "Anio_To", IsRequired = false)]		
public int? Anio_To{get;set;}		

		  [DataMember(Name = "Observacion", IsRequired = false)]
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
