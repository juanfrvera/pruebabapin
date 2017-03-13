using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamo;}}
		 public int IdPrestamo{get;set;}
		 public int IdPrograma{get;set;}
		 public int Numero{get;set;}
		 public string Denominacion{get;set;}
		 public string Descripcion{get;set;}
		 public string Observacion{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime FechaModificacion{get;set;}
		 public int IdUsuarioModificacion{get;set;}
		 public int? IdEstadoActual{get;set;}
		 public string ResponsablePolitico{get;set;}
		 public string ResponsableTecnico{get;set;}
		 public string CodigoVinculacion1{get;set;}
		 public string CodigoVinculacion2{get;set;}
		 public bool Activo{get;set;}
		 
		 public int Programa_IdSAF{get;set;}	
	public string Programa_Codigo{get;set;}	
	public string Programa_Nombre{get;set;}	
	public DateTime Programa_FechaAlta{get;set;}	
	public DateTime? Programa_FechaBaja{get;set;}	
	public bool Programa_Activo{get;set;}	
	public int? Programa_IdSectorialista{get;set;}	
					
		public virtual Prestamo ToEntity()
		{
		   Prestamo _Prestamo = new Prestamo();
		_Prestamo.IdPrestamo = this.IdPrestamo;
		 _Prestamo.IdPrograma = this.IdPrograma;
		 _Prestamo.Numero = this.Numero;
		 _Prestamo.Denominacion = this.Denominacion;
		 _Prestamo.Descripcion = this.Descripcion;
		 _Prestamo.Observacion = this.Observacion;
		 _Prestamo.FechaAlta = this.FechaAlta;
		 _Prestamo.FechaModificacion = this.FechaModificacion;
		 _Prestamo.IdUsuarioModificacion = this.IdUsuarioModificacion;
		 _Prestamo.IdEstadoActual = this.IdEstadoActual;
		 _Prestamo.ResponsablePolitico = this.ResponsablePolitico;
		 _Prestamo.ResponsableTecnico = this.ResponsableTecnico;
		 _Prestamo.CodigoVinculacion1 = this.CodigoVinculacion1;
		 _Prestamo.CodigoVinculacion2 = this.CodigoVinculacion2;
		 _Prestamo.Activo = this.Activo;
		 
		  return _Prestamo;
		}		
		public virtual void Set(Prestamo entity)
		{		   
		 this.IdPrestamo= entity.IdPrestamo ;
		  this.IdPrograma= entity.IdPrograma ;
		  this.Numero= entity.Numero ;
		  this.Denominacion= entity.Denominacion ;
		  this.Descripcion= entity.Descripcion ;
		  this.Observacion= entity.Observacion ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaModificacion= entity.FechaModificacion ;
		  this.IdUsuarioModificacion= entity.IdUsuarioModificacion ;
		  this.IdEstadoActual= entity.IdEstadoActual ;
		  this.ResponsablePolitico= entity.ResponsablePolitico ;
		  this.ResponsableTecnico= entity.ResponsableTecnico ;
		  this.CodigoVinculacion1= entity.CodigoVinculacion1 ;
		  this.CodigoVinculacion2= entity.CodigoVinculacion2 ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Prestamo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdPrograma.Equals(this.IdPrograma))return false;
		  if(!entity.Numero.Equals(this.Numero))return false;
		  if(!entity.Denominacion.Equals(this.Denominacion))return false;
		  if((entity.Descripcion == null)?this.Descripcion!=null:!entity.Descripcion.Equals(this.Descripcion))return false;
			 if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			 if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if(!entity.FechaModificacion.Equals(this.FechaModificacion))return false;
		  if(!entity.IdUsuarioModificacion.Equals(this.IdUsuarioModificacion))return false;
		  if((entity.IdEstadoActual == null)?this.IdEstadoActual!=null:!entity.IdEstadoActual.Equals(this.IdEstadoActual))return false;
			 if((entity.ResponsablePolitico == null)?this.ResponsablePolitico!=null:!entity.ResponsablePolitico.Equals(this.ResponsablePolitico))return false;
			 if((entity.ResponsableTecnico == null)?this.ResponsableTecnico!=null:!entity.ResponsableTecnico.Equals(this.ResponsableTecnico))return false;
			 if((entity.CodigoVinculacion1 == null)?this.CodigoVinculacion1!=null:!entity.CodigoVinculacion1.Equals(this.CodigoVinculacion1))return false;
			 if((entity.CodigoVinculacion2 == null)?this.CodigoVinculacion2!=null:!entity.CodigoVinculacion2.Equals(this.CodigoVinculacion2))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Prestamo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Programa","Programa_Nombre")
			,new DataColumnMapping("Numero","Numero")
			,new DataColumnMapping("Denominacion","Denominacion")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaModificacion","FechaModificacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioModificacion","IdUsuarioModificacion")
			,new DataColumnMapping("EstadoActual","IdEstadoActual")
			,new DataColumnMapping("ResponsablePolitico","ResponsablePolitico")
			,new DataColumnMapping("ResponsableTecnico","ResponsableTecnico")
			,new DataColumnMapping("CodigoVinculacion1","CodigoVinculacion1")
			,new DataColumnMapping("CodigoVinculacion2","CodigoVinculacion2")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		