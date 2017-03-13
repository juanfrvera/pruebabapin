using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoConvenioResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoConvenio;}}
		 public int IdPrestamoConvenio{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdOrganismoFinanciero{get;set;}
		 public string Sigla{get;set;}
		 public string Numero{get;set;}
		 public decimal MontoTotal{get;set;}
		 public decimal MontoPrestamo{get;set;}
		 public int IdMoneda{get;set;}
		 public string Observacion{get;set;}
		 public int? IdModalidadFinanciera{get;set;}
		 public string DatosModalidadFinanciera{get;set;}
		 
		 public string Moneda_Sigla{get;set;}	
	public string Moneda_Nombre{get;set;}	
	public bool Moneda_Activo{get;set;}	
	public bool Moneda_Base{get;set;}	
	public string OrganismoFinanciero_Sigla{get;set;}	
	public string OrganismoFinanciero_Nombre{get;set;}	
	public bool OrganismoFinanciero_Activo{get;set;}	
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
	public bool Prestamo_Activo{get;set;}	
					
		public virtual PrestamoConvenio ToEntity()
		{
		   PrestamoConvenio _PrestamoConvenio = new PrestamoConvenio();
		_PrestamoConvenio.IdPrestamoConvenio = this.IdPrestamoConvenio;
		 _PrestamoConvenio.IdPrestamo = this.IdPrestamo;
		 _PrestamoConvenio.IdOrganismoFinanciero = this.IdOrganismoFinanciero;
		 _PrestamoConvenio.Sigla = this.Sigla;
		 _PrestamoConvenio.Numero = this.Numero;
		 _PrestamoConvenio.MontoTotal = this.MontoTotal;
		 _PrestamoConvenio.MontoPrestamo = this.MontoPrestamo;
		 _PrestamoConvenio.IdMoneda = this.IdMoneda;
		 _PrestamoConvenio.Observacion = this.Observacion;
		 _PrestamoConvenio.IdModalidadFinanciera = this.IdModalidadFinanciera;
		 _PrestamoConvenio.DatosModalidadFinanciera = this.DatosModalidadFinanciera;
		 
		  return _PrestamoConvenio;
		}		
		public virtual void Set(PrestamoConvenio entity)
		{		   
		 this.IdPrestamoConvenio= entity.IdPrestamoConvenio ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdOrganismoFinanciero= entity.IdOrganismoFinanciero ;
		  this.Sigla= entity.Sigla ;
		  this.Numero= entity.Numero ;
		  this.MontoTotal= entity.MontoTotal ;
		  this.MontoPrestamo= entity.MontoPrestamo ;
		  this.IdMoneda= entity.IdMoneda ;
		  this.Observacion= entity.Observacion ;
		  this.IdModalidadFinanciera= entity.IdModalidadFinanciera ;
		  this.DatosModalidadFinanciera= entity.DatosModalidadFinanciera ;
		 		  
		}		
		public virtual bool Equals(PrestamoConvenio entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoConvenio.Equals(this.IdPrestamoConvenio))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdOrganismoFinanciero.Equals(this.IdOrganismoFinanciero))return false;
		  if((entity.Sigla == null)?this.Sigla!=null:  !( (this.Sigla== String.Empty && entity.Sigla== null) || (this.Sigla==null && entity.Sigla== String.Empty )) &&  !entity.Sigla.Trim().Replace ("\r","").Equals(this.Sigla.Trim().Replace ("\r","")))return false;
			 if((entity.Numero == null)?this.Numero!=null:  !( (this.Numero== String.Empty && entity.Numero== null) || (this.Numero==null && entity.Numero== String.Empty )) &&  !entity.Numero.Trim().Replace ("\r","").Equals(this.Numero.Trim().Replace ("\r","")))return false;
			 if(!entity.MontoTotal.Equals(this.MontoTotal))return false;
		  if(!entity.MontoPrestamo.Equals(this.MontoPrestamo))return false;
		  if(!entity.IdMoneda.Equals(this.IdMoneda))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:  !( (this.Observacion== String.Empty && entity.Observacion== null) || (this.Observacion==null && entity.Observacion== String.Empty )) &&  !entity.Observacion.Trim().Replace ("\r","").Equals(this.Observacion.Trim().Replace ("\r","")))return false;
			 if((entity.IdModalidadFinanciera == null)?(this.IdModalidadFinanciera.HasValue):!entity.IdModalidadFinanciera.Equals(this.IdModalidadFinanciera))return false;
			 if((entity.DatosModalidadFinanciera == null)?this.DatosModalidadFinanciera!=null:  !( (this.DatosModalidadFinanciera== String.Empty && entity.DatosModalidadFinanciera== null) || (this.DatosModalidadFinanciera==null && entity.DatosModalidadFinanciera== String.Empty )) &&  !entity.DatosModalidadFinanciera.Trim().Replace ("\r","").Equals(this.DatosModalidadFinanciera.Trim().Replace ("\r","")))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoConvenio", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("OrganismoFinanciero","OrganismoFinanciero_Nombre")
			,new DataColumnMapping("Sigla","Sigla")
			,new DataColumnMapping("Numero","Numero")
			,new DataColumnMapping("MontoTotal","MontoTotal")
			,new DataColumnMapping("MontoPrestamo","MontoPrestamo")
			,new DataColumnMapping("Moneda","Moneda_Nombre")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("ModalidadFinanciera","IdModalidadFinanciera")
			,new DataColumnMapping("DatosModalidadFinanciera","DatosModalidadFinanciera")
			}));
		}
	}
}
		