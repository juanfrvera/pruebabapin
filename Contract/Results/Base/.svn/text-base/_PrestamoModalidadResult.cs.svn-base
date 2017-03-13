using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoModalidadResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoModalidad;}}
		 public int IdPrestamoModalidad{get;set;}
		 public int IdPrestamoConvenio{get;set;}
		 public int IdModalidadFinanciera{get;set;}
		 public decimal Monto{get;set;}
		 
		 public int ModalidadFinanciera_IdOrganismoFinanciero{get;set;}	
	public string ModalidadFinanciera_Sigla{get;set;}	
	public string ModalidadFinanciera_Nombre{get;set;}	
	public bool ModalidadFinanciera_Activo{get;set;}	
	public int PrestamoConvenio_IdPrestamo{get;set;}	
	public int PrestamoConvenio_IdOrganismoFinanciero{get;set;}	
	public string PrestamoConvenio_Sigla{get;set;}	
	public int? PrestamoConvenio_Numero{get;set;}	
	public decimal PrestamoConvenio_MontoTotal{get;set;}	
	public decimal PrestamoConvenio_MontoPrestamo{get;set;}	
	public int PrestamoConvenio_IdMoneda{get;set;}	
	public string PrestamoConvenio_Observacion{get;set;}	
					
		public virtual PrestamoModalidad ToEntity()
		{
		   PrestamoModalidad _PrestamoModalidad = new PrestamoModalidad();
		_PrestamoModalidad.IdPrestamoModalidad = this.IdPrestamoModalidad;
		 _PrestamoModalidad.IdPrestamoConvenio = this.IdPrestamoConvenio;
		 _PrestamoModalidad.IdModalidadFinanciera = this.IdModalidadFinanciera;
		 _PrestamoModalidad.Monto = this.Monto;
		 
		  return _PrestamoModalidad;
		}		
		public virtual void Set(PrestamoModalidad entity)
		{		   
		 this.IdPrestamoModalidad= entity.IdPrestamoModalidad ;
		  this.IdPrestamoConvenio= entity.IdPrestamoConvenio ;
		  this.IdModalidadFinanciera= entity.IdModalidadFinanciera ;
		  this.Monto= entity.Monto ;
		 		  
		}		
		public virtual bool Equals(PrestamoModalidad entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoModalidad.Equals(this.IdPrestamoModalidad))return false;
		  if(!entity.IdPrestamoConvenio.Equals(this.IdPrestamoConvenio))return false;
		  if(!entity.IdModalidadFinanciera.Equals(this.IdModalidadFinanciera))return false;
		  if(!entity.Monto.Equals(this.Monto))return false;
		 
		  return true;
        }
        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
	}
}
		