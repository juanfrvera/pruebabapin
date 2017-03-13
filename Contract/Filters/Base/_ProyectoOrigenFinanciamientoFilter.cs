using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _ProyectoOrigenFinanciamientoFilter : Filter
    {   
		#region Private
		
		#endregion
		#region Properties
		[DataMember(Name = "IdProyectoOrigenFinanciamiento", IsRequired = false)]public int? IdProyectoOrigenFinanciamiento{get;set;}		
[DataMember(Name = "IdProyectoOrigenFinanciamiento_To", IsRequired = false)]		
public int? IdProyectoOrigenFinanciamiento_To{get;set;}		
[DataMember(Name = "IdProyecto", IsRequired = false)]public int? IdProyecto{get;set;}		
[DataMember(Name = "IdProyectoOrigenFinancianmientoTipo", IsRequired = false)]public int? IdProyectoOrigenFinancianmientoTipo{get;set;}		
[DataMember(Name = "IdPrestamoIsNull", IsRequired = false)]
			  public bool? IdPrestamoIsNull{get;set;}[DataMember(Name = "IdPrestamo", IsRequired = false)]public int? IdPrestamo{get;set;}		
[DataMember(Name = "IdTransferenciaIsNull", IsRequired = false)]
			  public bool? IdTransferenciaIsNull{get;set;}[DataMember(Name = "IdTransferencia", IsRequired = false)]public int? IdTransferencia{get;set;}		

		#endregion
    }
}
