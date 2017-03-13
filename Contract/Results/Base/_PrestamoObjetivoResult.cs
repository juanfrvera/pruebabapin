using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoObjetivoResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoObjetivo;}}
		 public int IdPrestamoObjetivo{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdObjetivo{get;set;}
		 
		 public string Objetivo_Nombre{get;set;}	
    //public int Prestamo_IdPrograma{get;set;}	
    //public int Prestamo_Numero{get;set;}	
    //public string Prestamo_Denominacion{get;set;}	
    //public string Prestamo_Descripcion{get;set;}	
    //public string Prestamo_Observacion{get;set;}	
    //public DateTime Prestamo_FechaAlta{get;set;}	
    //public DateTime Prestamo_FechaModificacion{get;set;}	
    //public int Prestamo_IdUsuarioModificacion{get;set;}	
    //public int? Prestamo_IdEstadoActual{get;set;}	
    //public string Prestamo_ResponsablePolitico{get;set;}	
    //public string Prestamo_ResponsableTecnico{get;set;}	
    //public string Prestamo_CodigoVinculacion1{get;set;}	
    //public string Prestamo_CodigoVinculacion2{get;set;}	
					
		public virtual PrestamoObjetivo ToEntity()
		{
		   PrestamoObjetivo _PrestamoObjetivo = new PrestamoObjetivo();
		_PrestamoObjetivo.IdPrestamoObjetivo = this.IdPrestamoObjetivo;
		 _PrestamoObjetivo.IdPrestamo = this.IdPrestamo;
		 _PrestamoObjetivo.IdObjetivo = this.IdObjetivo;
		 
		  return _PrestamoObjetivo;
		}		
		public virtual void Set(PrestamoObjetivo entity)
		{		   
		 this.IdPrestamoObjetivo= entity.IdPrestamoObjetivo ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdObjetivo= entity.IdObjetivo ;
		 		  
		}		
		public virtual bool Equals(PrestamoObjetivo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoObjetivo.Equals(this.IdPrestamoObjetivo))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdObjetivo.Equals(this.IdObjetivo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoObjetivo", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Objetivo","Objetivo_Nombre")
			}));
		}
	}
}
		