using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoFileResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoFile;}}
		 public int IdPrestamoFile{get;set;}
		 public int IdPrestamo{get;set;}
		 public int IdFile{get;set;}
		 
		 public DateTime? File_Date{get;set;}	
	public string File_FileType{get;set;}	
	public string File_FileName{get;set;}	
	public byte[] File_Data{get;set;}	
	public bool? File_Checked{get;set;}	
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
					
		public virtual PrestamoFile ToEntity()
		{
		   PrestamoFile _PrestamoFile = new PrestamoFile();
		_PrestamoFile.IdPrestamoFile = this.IdPrestamoFile;
		 _PrestamoFile.IdPrestamo = this.IdPrestamo;
		 _PrestamoFile.IdFile = this.IdFile;
		 
		  return _PrestamoFile;
		}		
		public virtual void Set(PrestamoFile entity)
		{		   
		 this.IdPrestamoFile= entity.IdPrestamoFile ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdFile= entity.IdFile ;
		 		  
		}		
		public virtual bool Equals(PrestamoFile entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoFile.Equals(this.IdPrestamoFile))return false;
		  if(!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
		  if(!entity.IdFile.Equals(this.IdFile))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoFile", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("File","FileInfo_FileType")
			}));
		}
	}
}
		