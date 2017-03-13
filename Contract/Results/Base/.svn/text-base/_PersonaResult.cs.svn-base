using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PersonaResult : IResult<int>
    {        
		public virtual int ID{get{return IdPersona;}}
		 public int IdPersona{get;set;}
		 public bool EsUsuario{get;set;}
		 public bool EsContacto{get;set;}
		 public string Nombre{get;set;}
		 public string Apellido{get;set;}
		 public string NombreCompleto{get;set;}
		 public int IdOficina{get;set;}
		 public int? IdCargo{get;set;}
		 public string Telefono{get;set;}
		 public string TelefonoLaboral{get;set;}
		 public string Fax{get;set;}
		 public string EMailPersonal{get;set;}
		 public string EMailLaboral{get;set;}
		 public string CargoEspecifico{get;set;}
		 public string NivelJerarquico{get;set;}
		 public string Domicilio{get;set;}
		 public string CodPostal{get;set;}
		 public int? IdClasificacionGeografica{get;set;}
		 public string Sexo{get;set;}
		 public bool? EnviarEMail{get;set;}
		 public bool? EnviarNota{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime? FechaBaja{get;set;}
		 public bool Activo{get;set;}
		 public DateTime FechaUltMod{get;set;}
		 public int IdUsuarioUltMod{get;set;}
		 
		 public string Cargo_Nombre{get;set;}	
	public bool? Cargo_Activo{get;set;}	
	public string Cargo_Codigo{get;set;}	
	public string ClasificacionGeografica_Codigo{get;set;}	
	public string ClasificacionGeografica_Nombre{get;set;}	
	public int? ClasificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
	public int? ClasificacionGeografica_IdClasificacionGeograficaPadre{get;set;}	
	public bool? ClasificacionGeografica_Activo{get;set;}	
	public string ClasificacionGeografica_Descripcion{get;set;}	
	public string ClasificacionGeografica_BreadcrumbId{get;set;}	
	public string ClasificacionGeografica_BreadcrumOrden{get;set;}	
	public int? ClasificacionGeografica_Orden{get;set;}	
	public int? ClasificacionGeografica_Nivel{get;set;}	
	public string ClasificacionGeografica_DescripcionInvertida{get;set;}	
	public bool? ClasificacionGeografica_Seleccionable{get;set;}	
	public string ClasificacionGeografica_BreadcrumbCode{get;set;}	
	public string ClasificacionGeografica_DescripcionCodigo{get;set;}	
	public string Oficina_Nombre{get;set;}	
	public string Oficina_Codigo{get;set;}	
	public bool Oficina_Activo{get;set;}	
	public bool Oficina_Visible{get;set;}	
	public int? Oficina_IdOficinaPadre{get;set;}	
	public int? Oficina_IdSaf{get;set;}	
	public string Oficina_BreadcrumbId{get;set;}	
	public string Oficina_BreadcrumbOrden{get;set;}	
	public int Oficina_Nivel{get;set;}	
	public int? Oficina_Orden{get;set;}	
	public string Oficina_Descripcion{get;set;}	
	public string Oficina_DescripcionInvertida{get;set;}	
	public bool Oficina_Seleccionable{get;set;}	
	public string Oficina_BreadcrumbCode{get;set;}	
	public string Oficina_DescripcionCodigo{get;set;}	
					
		public virtual Persona ToEntity()
		{
		   Persona _Persona = new Persona();
		_Persona.IdPersona = this.IdPersona;
		 _Persona.EsUsuario = this.EsUsuario;
		 _Persona.EsContacto = this.EsContacto;
		 _Persona.Nombre = this.Nombre;
		 _Persona.Apellido = this.Apellido;
		 _Persona.NombreCompleto = this.NombreCompleto;
		 _Persona.IdOficina = this.IdOficina;
		 _Persona.IdCargo = this.IdCargo;
		 _Persona.Telefono = this.Telefono;
		 _Persona.TelefonoLaboral = this.TelefonoLaboral;
		 _Persona.Fax = this.Fax;
		 _Persona.EMailPersonal = this.EMailPersonal;
		 _Persona.EMailLaboral = this.EMailLaboral;
		 _Persona.CargoEspecifico = this.CargoEspecifico;
		 _Persona.NivelJerarquico = this.NivelJerarquico;
		 _Persona.Domicilio = this.Domicilio;
		 _Persona.CodPostal = this.CodPostal;
		 _Persona.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 _Persona.Sexo = this.Sexo;
		 _Persona.EnviarEMail = this.EnviarEMail;
		 _Persona.EnviarNota = this.EnviarNota;
		 _Persona.FechaAlta = this.FechaAlta;
		 _Persona.FechaBaja = this.FechaBaja;
		 _Persona.Activo = this.Activo;
		 _Persona.FechaUltMod = this.FechaUltMod;
		 _Persona.IdUsuarioUltMod = this.IdUsuarioUltMod;
		 
		  return _Persona;
		}		
		public virtual void Set(Persona entity)
		{		   
		 this.IdPersona= entity.IdPersona ;
		  this.EsUsuario= entity.EsUsuario ;
		  this.EsContacto= entity.EsContacto ;
		  this.Nombre= entity.Nombre ;
		  this.Apellido= entity.Apellido ;
		  this.NombreCompleto= entity.NombreCompleto ;
		  this.IdOficina= entity.IdOficina ;
		  this.IdCargo= entity.IdCargo ;
		  this.Telefono= entity.Telefono ;
		  this.TelefonoLaboral= entity.TelefonoLaboral ;
		  this.Fax= entity.Fax ;
		  this.EMailPersonal= entity.EMailPersonal ;
		  this.EMailLaboral= entity.EMailLaboral ;
		  this.CargoEspecifico= entity.CargoEspecifico ;
		  this.NivelJerarquico= entity.NivelJerarquico ;
		  this.Domicilio= entity.Domicilio ;
		  this.CodPostal= entity.CodPostal ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		  this.Sexo= entity.Sexo ;
		  this.EnviarEMail= entity.EnviarEMail ;
		  this.EnviarNota= entity.EnviarNota ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaBaja= entity.FechaBaja ;
		  this.Activo= entity.Activo ;
		  this.FechaUltMod= entity.FechaUltMod ;
		  this.IdUsuarioUltMod= entity.IdUsuarioUltMod ;
		 		  
		}		
		public virtual bool Equals(Persona entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPersona.Equals(this.IdPersona))return false;
		  if(!entity.EsUsuario.Equals(this.EsUsuario))return false;
		  if(!entity.EsContacto.Equals(this.EsContacto))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Apellido.Equals(this.Apellido))return false;
		  if((entity.NombreCompleto == null)?this.NombreCompleto!=null:!entity.NombreCompleto.Equals(this.NombreCompleto))return false;
			 if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if((entity.IdCargo == null)?(this.IdCargo.HasValue && this.IdCargo.Value > 0):!entity.IdCargo.Equals(this.IdCargo))return false;
						  if((entity.Telefono == null)?this.Telefono!=null:!entity.Telefono.Equals(this.Telefono))return false;
			 if((entity.TelefonoLaboral == null)?this.TelefonoLaboral!=null:!entity.TelefonoLaboral.Equals(this.TelefonoLaboral))return false;
			 if((entity.Fax == null)?this.Fax!=null:!entity.Fax.Equals(this.Fax))return false;
			 if((entity.EMailPersonal == null)?this.EMailPersonal!=null:!entity.EMailPersonal.Equals(this.EMailPersonal))return false;
			 if((entity.EMailLaboral == null)?this.EMailLaboral!=null:!entity.EMailLaboral.Equals(this.EMailLaboral))return false;
			 if((entity.CargoEspecifico == null)?this.CargoEspecifico!=null:!entity.CargoEspecifico.Equals(this.CargoEspecifico))return false;
			 if((entity.NivelJerarquico == null)?this.NivelJerarquico!=null:!entity.NivelJerarquico.Equals(this.NivelJerarquico))return false;
			 if((entity.Domicilio == null)?this.Domicilio!=null:!entity.Domicilio.Equals(this.Domicilio))return false;
			 if((entity.CodPostal == null)?this.CodPostal!=null:!entity.CodPostal.Equals(this.CodPostal))return false;
			 if((entity.IdClasificacionGeografica == null)?(this.IdClasificacionGeografica.HasValue && this.IdClasificacionGeografica.Value > 0):!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
						  if(!entity.Sexo.Equals(this.Sexo))return false;
		  if((entity.EnviarEMail == null)?this.EnviarEMail!=null:!entity.EnviarEMail.Equals(this.EnviarEMail))return false;
			 if((entity.EnviarNota == null)?this.EnviarNota!=null:!entity.EnviarNota.Equals(this.EnviarNota))return false;
			 if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if((entity.FechaBaja == null)?this.FechaBaja!=null:!entity.FechaBaja.Equals(this.FechaBaja))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		  if(!entity.FechaUltMod.Equals(this.FechaUltMod))return false;
		  if(!entity.IdUsuarioUltMod.Equals(this.IdUsuarioUltMod))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Persona", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("EsUsuario","EsUsuario")
			,new DataColumnMapping("EsContacto","EsContacto")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Apellido","Apellido")
			,new DataColumnMapping("NombreCompleto","NombreCompleto")
			,new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Cargo","Cargo_Nombre")
			,new DataColumnMapping("Telefono","Telefono")
			,new DataColumnMapping("TelefonoLaboral","TelefonoLaboral")
			,new DataColumnMapping("Fax","Fax")
			,new DataColumnMapping("EMailPersonal","EmailPersonal")
			,new DataColumnMapping("EMailLaboral","EmailLaboral")
			,new DataColumnMapping("CargoEspecifico","CargoEspecifico")
			,new DataColumnMapping("NivelJerarquico","NivelJerarquico")
			,new DataColumnMapping("Domicilio","Domicilio")
			,new DataColumnMapping("CodPostal","CodPostal")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			,new DataColumnMapping("Sexo","Sexo")
			,new DataColumnMapping("EnviarEMail","EnviareMail")
			,new DataColumnMapping("EnviarNota","EnviarNota")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaBaja","FechaBaja","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Activo","Activo")
			,new DataColumnMapping("FechaUltMod","FechaUltMod","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioUltMod","IdUsuarioUltMod")
			}));
		}
	}
}
		