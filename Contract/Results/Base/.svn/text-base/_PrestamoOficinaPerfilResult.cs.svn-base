using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoOficinaPerfilResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoOficinaPerfil;}}
		 public int IdPrestamoOficinaPerfil{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdOficina{get;set;}
		 public int IdPerfil{get;set;}
		 
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
	public string Perfil_Nombre{get;set;}	
	public int Perfil_IdPerfilTipo{get;set;}	
	public bool Perfil_Activo{get;set;}	
	public bool Perfil_EsDefault{get;set;}	
	public string Perfil_Codigo{get;set;}	
	public int Prestamo_IdPrograma{get;set;}	
	public int Prestamo_Numero{get;set;}	
	public string Prestamo_Denominacion{get;set;}	
	public string Prestamo_Descripcion{get;set;}	
	public string Prestamo_Observacion{get;set;}	
	public DateTime Prestamo_FechaAlta{get;set;}	
	public DateTime Prestamo_FechaModificacion{get;set;}	
	public int Prestamo_IdUsuarioModificacion{get;set;}	
	public int? Prestamo_IdEstadoActual{get;set;}	
	public string Prestamo_ResponsablePolitico{get;set;}	
	public string Prestamo_ResponsableTecnico{get;set;}	
	public string Prestamo_CodigoVinculacion1{get;set;}	
	public string Prestamo_CodigoVinculacion2{get;set;}	
					
		public virtual PrestamoOficinaPerfil ToEntity()
		{
		   PrestamoOficinaPerfil _PrestamoOficinaPerfil = new PrestamoOficinaPerfil();
		_PrestamoOficinaPerfil.IdPrestamoOficinaPerfil = this.IdPrestamoOficinaPerfil;
		 _PrestamoOficinaPerfil.IdPrestamo = this.IdPrestamo;
		 _PrestamoOficinaPerfil.IdOficina = this.IdOficina;
		 _PrestamoOficinaPerfil.IdPerfil = this.IdPerfil;
		 
		  return _PrestamoOficinaPerfil;
		}		
		public virtual void Set(PrestamoOficinaPerfil entity)
		{		   
		 this.IdPrestamoOficinaPerfil= entity.IdPrestamoOficinaPerfil ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdOficina= entity.IdOficina ;
		  this.IdPerfil= entity.IdPerfil ;
		 		  
		}		
		public virtual bool Equals(PrestamoOficinaPerfil entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoOficinaPerfil.Equals(this.IdPrestamoOficinaPerfil))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdOficina.Equals(this.IdOficina))return false;
		  if(!entity.IdPerfil.Equals(this.IdPerfil))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoOficinaPerfil", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Oficina","Oficina_Nombre")
			,new DataColumnMapping("Perfil","Perfil_Nombre")
			}));
		}
	}
}
		