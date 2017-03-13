using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _PrestamoDictamenFileResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrestamoDictamenFile;}}
		 public int IdPrestamoDictamenFile{get;set;}
		 public int IdPrestamoDictamen{get;set;}
		 public int IdFile{get;set;}
		 
		 public DateTime? File_Date{get;set;}	
	public string File_FileType{get;set;}	
	public string File_FileName{get;set;}	
	public byte[] File_Data{get;set;}	
	public bool? File_Checked{get;set;}	
	public string PrestamoDictamen_Expediente{get;set;}	
	public int PrestamoDictamen_IDOrganismo{get;set;}	
	public string PrestamoDictamen_OrganismoDetalle{get;set;}	
	public string PrestamoDictamen_Denominacion{get;set;}	
	public int PrestamoDictamen_IdGestionTipo{get;set;}	
	public int PrestamoDictamen_IdOrganismoFinanciero{get;set;}	
	public decimal? PrestamoDictamen_MontoTotal{get;set;}	
	public decimal? PrestamoDictamen_MontoPrestamo{get;set;}	
	public decimal? PrestamoDictamen_MontoContraparteLocal{get;set;}	
	public decimal? PrestamoDictamen_MontoOtros{get;set;}	
	public int? PrestamoDictamen_IdAnalista{get;set;}	
	public int? PrestamoDictamen_IdPrestamo{get;set;}	
	public int? PrestamoDictamen_IdPrestamoDictamenRelacionado{get;set;}	
	public string PrestamoDictamen_Comentario{get;set;}	
	public int? PrestamoDictamen_IDPrestamoCalificacion{get;set;}	
	public DateTime? PrestamoDictamen_CalificacionFecha{get;set;}	
	public string PrestamoDictamen_CalificacionITecnico{get;set;}	
	public DateTime? PrestamoDictamen_CalificacionITFecha{get;set;}	
	public string PrestamoDictamen_CalificacionNotaDNIP{get;set;}	
	public string PrestamoDictamen_CalificacionObservacion{get;set;}	
	public string PrestamoDictamen_CalificacionRecomendacion{get;set;}	
	public DateTime PrestamoDictamen_FechaAlta{get;set;}	
	public DateTime PrestamoDictamen_FechaModificacion{get;set;}	
	public int PrestamoDictamen_IDUsuarioModificacion{get;set;}	
	public int? PrestamoDictamen_IdEstado{get;set;}	
	public DateTime? PrestamoDictamen_FechaEstado{get;set;}	
					
		public virtual PrestamoDictamenFile ToEntity()
		{
		   PrestamoDictamenFile _PrestamoDictamenFile = new PrestamoDictamenFile();
		_PrestamoDictamenFile.IdPrestamoDictamenFile = this.IdPrestamoDictamenFile;
		 _PrestamoDictamenFile.IdPrestamoDictamen = this.IdPrestamoDictamen;
		 _PrestamoDictamenFile.IdFile = this.IdFile;
		 
		  return _PrestamoDictamenFile;
		}		
		public virtual void Set(PrestamoDictamenFile entity)
		{		   
		 this.IdPrestamoDictamenFile= entity.IdPrestamoDictamenFile ;
		  this.IdPrestamoDictamen= entity.IdPrestamoDictamen ;
		  this.IdFile= entity.IdFile ;
		 		  
		}		
		public virtual bool Equals(PrestamoDictamenFile entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrestamoDictamenFile.Equals(this.IdPrestamoDictamenFile))return false;
		  if(!entity.IdPrestamoDictamen.Equals(this.IdPrestamoDictamen))return false;
		  if(!entity.IdFile.Equals(this.IdFile))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("PrestamoDictamenFile", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("PrestamoDictamen","PrestamoDictamen_Expediente")
			,new DataColumnMapping("File","FileInfo_FileType")
			}));
		}
	}
}
		