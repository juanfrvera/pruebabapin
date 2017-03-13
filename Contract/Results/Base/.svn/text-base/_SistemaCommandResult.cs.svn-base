using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SistemaCommandResult : IResult<int>
    {        
		public virtual int ID{get{return IdSistemaCommand;}}
		 public int IdSistemaCommand{get;set;}
		 public string Nombre{get;set;}
		 public string Descripcion{get;set;}
		 public int IdsistemaEntidad{get;set;}
		 public string CommandText{get;set;}
		 public int CommandType{get;set;}
		 public bool Activo{get;set;}
		 
		 public string sistemaEntidad_Codigo{get;set;}	
	public string sistemaEntidad_Nombre{get;set;}	
	public string sistemaEntidad_EntidadTipo{get;set;}	
	public string sistemaEntidad_EntidadClase{get;set;}	
	public string sistemaEntidad_EntidadClaseBase{get;set;}	
	public bool sistemaEntidad_Activo{get;set;}	
	public bool? sistemaEntidad_IncluirSeguridad{get;set;}	
	public bool? sistemaEntidad_IncluirConfiguracion{get;set;}	
					
		public virtual SistemaCommand ToEntity()
		{
		   SistemaCommand _SistemaCommand = new SistemaCommand();
		_SistemaCommand.IdSistemaCommand = this.IdSistemaCommand;
		 _SistemaCommand.Nombre = this.Nombre;
		 _SistemaCommand.Descripcion = this.Descripcion;
		 _SistemaCommand.IdsistemaEntidad = this.IdsistemaEntidad;
		 _SistemaCommand.CommandText = this.CommandText;
		 _SistemaCommand.CommandType = this.CommandType;
		 _SistemaCommand.Activo = this.Activo;
		 
		  return _SistemaCommand;
		}		
		public virtual void Set(SistemaCommand entity)
		{		   
		 this.IdSistemaCommand= entity.IdSistemaCommand ;
		  this.Nombre= entity.Nombre ;
		  this.Descripcion= entity.Descripcion ;
		  this.IdsistemaEntidad= entity.IdsistemaEntidad ;
		  this.CommandText= entity.CommandText ;
		  this.CommandType= entity.CommandType ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(SistemaCommand entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSistemaCommand.Equals(this.IdSistemaCommand))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if(!entity.IdsistemaEntidad.Equals(this.IdsistemaEntidad))return false;
		  if(!entity.CommandText.Equals(this.CommandText))return false;
		  if(!entity.CommandType.Equals(this.CommandType))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("SistemaCommand", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("sistemaEntidad","SistemaEntidad_Nombre")
			,new DataColumnMapping("CommandText","CommandText")
			,new DataColumnMapping("CommandType","CommandType")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		