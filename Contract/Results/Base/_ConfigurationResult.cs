using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ConfigurationResult : IResult<int>
    {        
		public virtual int ID{get{return IdConfiguration;}}
		 public int IdConfiguration{get;set;}
		 public string Name{get;set;}
		 public string Code{get;set;}
		 public string Description{get;set;}
		 public int IdConfigurationCategory{get;set;}
		 public bool Active{get;set;}
		 public int? IdSistemaEntidad{get;set;}
		 public int? IdEstado{get;set;}
		 public string StringValue{get;set;}
		 public decimal? NumberValue{get;set;}
		 public DateTime? DateValue{get;set;}
		 public bool BooleanValue{get;set;}
		 
		 public string ConfigurationCategory_Name{get;set;}	
	public string Estado_Nombre{get;set;}	
	public string Estado_Codigo{get;set;}	
	public int? Estado_Orden{get;set;}	
	public string Estado_Descripcion{get;set;}	
	public bool? Estado_Activo{get;set;}	
	public string SistemaEntidad_Codigo{get;set;}	
	public string SistemaEntidad_Nombre{get;set;}	
	public string SistemaEntidad_EntidadTipo{get;set;}	
	public string SistemaEntidad_EntidadClase{get;set;}	
	public string SistemaEntidad_EntidadClaseBase{get;set;}	
	public bool? SistemaEntidad_Activo{get;set;}	
	public bool? SistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? SistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual Configuration ToEntity()
		{
		   Configuration _Configuration = new Configuration();
		_Configuration.IdConfiguration = this.IdConfiguration;
		 _Configuration.Name = this.Name;
		 _Configuration.Code = this.Code;
		 _Configuration.Description = this.Description;
		 _Configuration.IdConfigurationCategory = this.IdConfigurationCategory;
		 _Configuration.Active = this.Active;
		 _Configuration.IdSistemaEntidad = this.IdSistemaEntidad;
		 _Configuration.IdEstado = this.IdEstado;
		 _Configuration.StringValue = this.StringValue;
		 _Configuration.NumberValue = this.NumberValue;
		 _Configuration.DateValue = this.DateValue;
		 _Configuration.BooleanValue = this.BooleanValue;
		 
		  return _Configuration;
		}		
		public virtual void Set(Configuration entity)
		{		   
		 this.IdConfiguration= entity.IdConfiguration ;
		  this.Name= entity.Name ;
		  this.Code= entity.Code ;
		  this.Description= entity.Description ;
		  this.IdConfigurationCategory= entity.IdConfigurationCategory ;
		  this.Active= entity.Active ;
		  this.IdSistemaEntidad= entity.IdSistemaEntidad ;
		  this.IdEstado= entity.IdEstado ;
		  this.StringValue= entity.StringValue ;
		  this.NumberValue= entity.NumberValue ;
		  this.DateValue= entity.DateValue ;
		  this.BooleanValue= entity.BooleanValue ;
		 		  
		}		
		public virtual bool Equals(Configuration entity)
        {
		   if(entity == null)return false;
         if(!entity.IdConfiguration.Equals(this.IdConfiguration))return false;
		  if(!entity.Name.Equals(this.Name))return false;
		  if(!entity.Code.Equals(this.Code))return false;
		  if((entity.Description == null)?this.Description!=null:!entity.Description.Equals(this.Description))return false;
			 if(!entity.IdConfigurationCategory.Equals(this.IdConfigurationCategory))return false;
		  if(!entity.Active.Equals(this.Active))return false;
		  if((entity.IdSistemaEntidad == null)?(this.IdSistemaEntidad.HasValue && this.IdSistemaEntidad.Value > 0):!entity.IdSistemaEntidad.Equals(this.IdSistemaEntidad))return false;
						  if((entity.IdEstado == null)?(this.IdEstado.HasValue && this.IdEstado.Value > 0):!entity.IdEstado.Equals(this.IdEstado))return false;
						  if((entity.StringValue == null)?this.StringValue!=null:!entity.StringValue.Equals(this.StringValue))return false;
			 if((entity.NumberValue == null)?this.NumberValue!=null:!entity.NumberValue.Equals(this.NumberValue))return false;
			 if((entity.DateValue == null)?this.DateValue!=null:!entity.DateValue.Equals(this.DateValue))return false;
			 if(!entity.BooleanValue.Equals(this.BooleanValue))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Configuration", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Code","Code")
			,new DataColumnMapping("Description","Description")
			,new DataColumnMapping("ConfigurationCategory","ConfigurationCategory_Name")
			,new DataColumnMapping("Active","Active")
			,new DataColumnMapping("SistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("Estado","Estado_Nombre")
			,new DataColumnMapping("StringValue","StringValue")
			,new DataColumnMapping("NumberValue","NumberValue")
			,new DataColumnMapping("DateValue","DateValue","{0:dd/MM/yyyy}")
			,new DataColumnMapping("BooleanValue","BooleanValue")
			}));
		}
	}
}
		