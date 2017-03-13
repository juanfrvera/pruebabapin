using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoSubConvenioResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoSubConvenio;}}
		 public int IdPrestamoSubConvenio{get;set;}
		 public int IdPrestamoConvenio{get;set;}
		 public string Codigo{get;set;}
		 public string Descripcion{get;set;}
		 public int IdTipoSubConvenio{get;set;}
		 public string Contraparte{get;set;}
		 public decimal MontoTotal{get;set;}
		 public decimal MontoPrestamo{get;set;}
		 public DateTime Fecha{get;set;}
		 public string Ejecutor{get;set;}
		 public string Observaciones{get;set;}
		 
		 public int PrestamoConvenio_IdPrestamo{get;set;}	
	public int PrestamoConvenio_IdOrganismoFinanciero{get;set;}	
	public string PrestamoConvenio_Sigla{get;set;}	
	public string PrestamoConvenio_Numero{get;set;}	
	public decimal PrestamoConvenio_MontoTotal{get;set;}	
	public decimal PrestamoConvenio_MontoPrestamo{get;set;}	
	public int PrestamoConvenio_IdMoneda{get;set;}	
	public string PrestamoConvenio_Observacion{get;set;}	
	public int? PrestamoConvenio_IdModalidadFinanciera{get;set;}	
	public string PrestamoConvenio_DatosModalidadFinanciera{get;set;}	
	public string TipoSubConvenio_Nombre{get;set;}	
	public bool TipoSubConvenio_Activo{get;set;}	
					
		public virtual PrestamoSubConvenio ToEntity()
		{
		   PrestamoSubConvenio _PrestamoSubConvenio = new PrestamoSubConvenio();
		_PrestamoSubConvenio.IdPrestamoSubConvenio = this.IdPrestamoSubConvenio;
		 _PrestamoSubConvenio.IdPrestamoConvenio = this.IdPrestamoConvenio;
		 _PrestamoSubConvenio.Codigo = this.Codigo;
		 _PrestamoSubConvenio.Descripcion = this.Descripcion;
		 _PrestamoSubConvenio.IdTipoSubConvenio = this.IdTipoSubConvenio;
		 _PrestamoSubConvenio.Contraparte = this.Contraparte;
		 _PrestamoSubConvenio.MontoTotal = this.MontoTotal;
		 _PrestamoSubConvenio.MontoPrestamo = this.MontoPrestamo;
		 _PrestamoSubConvenio.Fecha = this.Fecha;
		 _PrestamoSubConvenio.Ejecutor = this.Ejecutor;
		 _PrestamoSubConvenio.Observaciones = this.Observaciones;
		 
		  return _PrestamoSubConvenio;
		}		
		public virtual void Set(PrestamoSubConvenio entity)
		{		   
		 this.IdPrestamoSubConvenio= entity.IdPrestamoSubConvenio ;
		  this.IdPrestamoConvenio= entity.IdPrestamoConvenio ;
		  this.Codigo= entity.Codigo ;
		  this.Descripcion= entity.Descripcion ;
		  this.IdTipoSubConvenio= entity.IdTipoSubConvenio ;
		  this.Contraparte= entity.Contraparte ;
		  this.MontoTotal= entity.MontoTotal ;
		  this.MontoPrestamo= entity.MontoPrestamo ;
		  this.Fecha= entity.Fecha ;
		  this.Ejecutor= entity.Ejecutor ;
		  this.Observaciones= entity.Observaciones ;
		 		  
		}		
		public virtual bool Equals(PrestamoSubConvenio entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoSubConvenio.Equals(this.IdPrestamoSubConvenio))return false;
		  if(!entity.IdPrestamoConvenio.Equals(this.IdPrestamoConvenio))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Descripcion.Equals(this.Descripcion))return false;
		  if(!entity.IdTipoSubConvenio.Equals(this.IdTipoSubConvenio))return false;
		  if(!entity.Contraparte.Equals(this.Contraparte))return false;
		  if(!entity.MontoTotal.Equals(this.MontoTotal))return false;
		  if(!entity.MontoPrestamo.Equals(this.MontoPrestamo))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.Ejecutor.Equals(this.Ejecutor))return false;
		  if((entity.Observaciones == null)?this.Observaciones!=null:!entity.Observaciones.Equals(this.Observaciones))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoSubConvenio", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoConvenio","PrestamoConvenio_Sigla")
			,new DataColumnMapping("Codigo","Codigo")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("TipoSubConvenio","SubConvenioTipo_Nombre")
			,new DataColumnMapping("Contraparte","Contraparte")
			,new DataColumnMapping("MontoTotal","MontoTotal")
			,new DataColumnMapping("MontoPrestamo","MontoPrestamo")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Ejecutor","Ejecutor")
			,new DataColumnMapping("Observaciones","Observaciones")
			}));
		}
	}
}
		