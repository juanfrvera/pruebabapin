using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProcesoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProceso;}}
		 public int IdProceso{get;set;}
		 public int IdProyectoTipo{get;set;}
		 public string Nombre{get;set;}
		 public bool Activo{get;set;}
		 
		 public string ProyectoTipo_Sigla{get;set;}	
	public string ProyectoTipo_Nombre{get;set;}	
	public bool ProyectoTipo_Activo{get;set;}	
	public string ProyectoTipo_Tipo{get;set;}	
					
		public virtual Proceso ToEntity()
		{
		   Proceso _Proceso = new Proceso();
		_Proceso.IdProceso = this.IdProceso;
		 _Proceso.IdProyectoTipo = this.IdProyectoTipo;
		 _Proceso.Nombre = this.Nombre;
		 _Proceso.Activo = this.Activo;
		 
		  return _Proceso;
		}		
		public virtual void Set(Proceso entity)
		{		   
		 this.IdProceso= entity.IdProceso ;
		  this.IdProyectoTipo= entity.IdProyectoTipo ;
		  this.Nombre= entity.Nombre ;
		  this.Activo= entity.Activo ;
		 		  
		}		
		public virtual bool Equals(Proceso entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProceso.Equals(this.IdProceso))return false;
		  if(!entity.IdProyectoTipo.Equals(this.IdProyectoTipo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.Activo.Equals(this.Activo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Proceso", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoTipo","ProyectoTipo_Nombre")
			,new DataColumnMapping("Nombre","Nombre")
			,new DataColumnMapping("Activo","Activo")
			}));
		}
	}
}
		