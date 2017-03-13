using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _SubProcesoResult : IResult<int>
    {        
		public virtual int ID{get{return IdSubProceso;}}
		 public int IdSubProceso{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public int Orden{get;set;}
		 public bool Activo{get;set;}
		 public int? IdProceso{get;set;}
		 
		 public int? Proceso_IdProyectoTipo{get;set;}	
	public string Proceso_Nombre{get;set;}	
	public bool? Proceso_Activo{get;set;}	
					
		public virtual SubProceso ToEntity()
		{
		   SubProceso _SubProceso = new SubProceso();
		_SubProceso.IdSubProceso = this.IdSubProceso;
		 _SubProceso.Codigo = this.Codigo;
		 _SubProceso.Nombre = this.Nombre;
		 _SubProceso.Orden = this.Orden;
		 _SubProceso.Activo = this.Activo;
		 _SubProceso.IdProceso = this.IdProceso;
		 
		  return _SubProceso;
		}		
		public virtual void Set(SubProceso entity)
		{		   
		 this.IdSubProceso= entity.IdSubProceso ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.Orden= entity.Orden ;
		  this.Activo= entity.Activo ;
		  this.IdProceso= entity.IdProceso ;
		 		  
		}		
		public virtual bool Equals(SubProceso entity)
        {
		   if(entity == null)return false;
         if(!entity.IdSubProceso.Equals(this.IdSubProceso))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Orden.Equals(this.Orden))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdProceso == null)?(this.IdProceso.HasValue && this.IdProceso.Value > 0):!entity.IdProceso.Equals(this.IdProceso))return false;
						 
		  return true;
        }
	}
}
		