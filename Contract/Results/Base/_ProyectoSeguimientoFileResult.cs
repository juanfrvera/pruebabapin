using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoSeguimientoFileResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoSeguimientoFile;}}
		 public int IdProyectoSeguimientoFile{get;set;}
		 public int? IdProyectoSeguimiento{get;set;}
		 public int? IdFile{get;set;}
		 
		 public DateTime? File_Date{get;set;}	
	public string File_FileType{get;set;}	
	public string File_FileName{get;set;}	
	public byte[] File_Data{get;set;}	
	public bool? File_Checked{get;set;}	
	public int? ProyectoSeguimiento_IdSaf{get;set;}	
	public string ProyectoSeguimiento_Denominacion{get;set;}	
	public string ProyectoSeguimiento_Ruta{get;set;}	
	public string ProyectoSeguimiento_Malla{get;set;}	
	public int? ProyectoSeguimiento_IdAnalista{get;set;}	
	public int? ProyectoSeguimiento_IdProyectoSeguimientoAnterior{get;set;}	
					
		public virtual ProyectoSeguimientoFile ToEntity()
		{
		   ProyectoSeguimientoFile _ProyectoSeguimientoFile = new ProyectoSeguimientoFile();
		_ProyectoSeguimientoFile.IdProyectoSeguimientoFile = this.IdProyectoSeguimientoFile;
		 _ProyectoSeguimientoFile.IdProyectoSeguimiento = this.IdProyectoSeguimiento;
		 _ProyectoSeguimientoFile.IdFile = this.IdFile;
		 
		  return _ProyectoSeguimientoFile;
		}		
		public virtual void Set(ProyectoSeguimientoFile entity)
		{		   
		 this.IdProyectoSeguimientoFile= entity.IdProyectoSeguimientoFile ;
		  this.IdProyectoSeguimiento= entity.IdProyectoSeguimiento ;
		  this.IdFile= entity.IdFile ;
		 		  
		}		
		public virtual bool Equals(ProyectoSeguimientoFile entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoSeguimientoFile.Equals(this.IdProyectoSeguimientoFile))return false;
		  if((entity.IdProyectoSeguimiento == null)?(this.IdProyectoSeguimiento.HasValue && this.IdProyectoSeguimiento.Value > 0):!entity.IdProyectoSeguimiento.Equals(this.IdProyectoSeguimiento))return false;
						  if((entity.IdFile == null)?(this.IdFile.HasValue && this.IdFile.Value > 0):!entity.IdFile.Equals(this.IdFile))return false;
						 
		  return true;
        }
	}
}
		