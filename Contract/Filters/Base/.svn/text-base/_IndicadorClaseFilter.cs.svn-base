using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _IndicadorClaseFilter : Filter
    {   
		#region Private
		private string _Sigla;
		 private string _Nombre;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdIndicadorClase", IsRequired = false)]public int? IdIndicadorClase{get;set;}		
[DataMember(Name = "IdIndicadorTipo", IsRequired = false)]public int? IdIndicadorTipo{get;set;}		

		  [DataMember(Name = "Sigla", IsRequired = false)]
		  public string Sigla
		  {
		   get{ if(_Sigla==null)_Sigla= string.Empty;
				return _Sigla; 
				}
		   set{ _Sigla=value;}
		  }
		 
		  [DataMember(Name = "Nombre", IsRequired = false)]
		  public string Nombre
		  {
		   get{ if(_Nombre==null)_Nombre= string.Empty;
				return _Nombre; 
				}
		   set{ _Nombre=value;}
		  }
		 [DataMember(Name = "IdUnidad", IsRequired = false)]public int? IdUnidad{get;set;}		
[DataMember(Name = "RangoInicialIsNull", IsRequired = false)]
			  public bool? RangoInicialIsNull{get;set;}[DataMember(Name = "RangoInicial", IsRequired = false)]public int? RangoInicial{get;set;}		
[DataMember(Name = "RangoInicial_To", IsRequired = false)]		
public int? RangoInicial_To{get;set;}		
[DataMember(Name = "RangoFinalIsNull", IsRequired = false)]
			  public bool? RangoFinalIsNull{get;set;}[DataMember(Name = "RangoFinal", IsRequired = false)]public int? RangoFinal{get;set;}		
[DataMember(Name = "RangoFinal_To", IsRequired = false)]		
public int? RangoFinal_To{get;set;}		
[DataMember(Name = "Activo", IsRequired = false)]public bool? Activo{get;set;}		

		#endregion
    }
}
