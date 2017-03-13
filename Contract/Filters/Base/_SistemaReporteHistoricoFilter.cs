using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
namespace Contract.Base
{
	[Serializable, DataContract]
    public abstract class _SistemaReporteHistoricoFilter : Filter
    {   
		#region Private
		private string _EntityId;
		 private string _FilterData;
		 private string _Comentarios;
		 private string _Data;
		 
		#endregion
		#region Properties
		[DataMember(Name = "IdSistemaReporteHistorico", IsRequired = false)]public int? IdSistemaReporteHistorico{get;set;}		
[DataMember(Name = "IdSistemaReporteHistorico_To", IsRequired = false)]		
public int? IdSistemaReporteHistorico_To{get;set;}		
[DataMember(Name = "IdSistemaReporte", IsRequired = false)]public int? IdSistemaReporte{get;set;}		

		  [DataMember(Name = "EntityId", IsRequired = false)]
		  public string EntityId
		  {
		   get{ if(_EntityId==null)_EntityId= string.Empty;
				return _EntityId; 
				}
		   set{ _EntityId=value;}
		  }
		 
		  [DataMember(Name = "FilterData", IsRequired = false)]
		  public string FilterData
		  {
		   get{ if(_FilterData==null)_FilterData= string.Empty;
				return _FilterData; 
				}
		   set{ _FilterData=value;}
		  }
		 [DataMember(Name = "Fecha", IsRequired = false)]public DateTime? Fecha{get;set;}		
[DataMember(Name = "Fecha_To", IsRequired = false)]		
public DateTime? Fecha_To{get;set;}		
[DataMember(Name = "IdUsuario", IsRequired = false)]public int? IdUsuario{get;set;}		

		  [DataMember(Name = "Comentarios", IsRequired = false)]
		  public string Comentarios
		  {
		   get{ if(_Comentarios==null)_Comentarios= string.Empty;
				return _Comentarios; 
				}
		   set{ _Comentarios=value;}
		  }
		 
		  [DataMember(Name = "Data", IsRequired = false)]
		  public string Data
		  {
		   get{ if(_Data==null)_Data= string.Empty;
				return _Data; 
				}
		   set{ _Data=value;}
		  }
		 
		#endregion
    }
}
