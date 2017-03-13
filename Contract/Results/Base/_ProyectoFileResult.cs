using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoFileResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoFile;}}
		 public int IdProyectoFile{get;set;}
		 public int? IdFile{get;set;}
		 public int? IdProyecto{get;set;}
		 
		 public DateTime? File_Date{get;set;}	
	public string File_FileType{get;set;}	
	public string File_FileName{get;set;}	
	public byte[] File_Data{get;set;}	
	public bool? File_Checked{get;set;}	
	public int? Proyecto_IdTipoProyecto{get;set;}	
	public int? Proyecto_IdSubPrograma{get;set;}	
	public int? Proyecto_Codigo{get;set;}	
	public string Proyecto_ProyectoDenominacion{get;set;}	
	public string Proyecto_ProyectoSituacionActual{get;set;}	
	public string Proyecto_ProyectoDescripcion{get;set;}	
	public string Proyecto_ProyectoObservacion{get;set;}	
	public int? Proyecto_IdEstado{get;set;}	
	public int? Proyecto_IdProceso{get;set;}	
	public int? Proyecto_IdModalidadContratacion{get;set;}	
	public int? Proyecto_IdFinalidadFuncion{get;set;}	
	public int? Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? Proyecto_SubPrioridad{get;set;}	
	public bool? Proyecto_EsBorrador{get;set;}	
	public bool? Proyecto_EsProyecto{get;set;}	
	public int? Proyecto_NroProyecto{get;set;}	
	public int? Proyecto_AnioCorriente{get;set;}	
	public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaAlta{get;set;}	
	public DateTime? Proyecto_FechaModificacion{get;set;}	
	public int? Proyecto_IdUsuarioModificacion{get;set;}	
	public int? Proyecto_IdProyectoPlan{get;set;}	
	public bool? Proyecto_EvaluarValidaciones{get;set;}	
					
		public virtual ProyectoFile ToEntity()
		{
		   ProyectoFile _ProyectoFile = new ProyectoFile();
		_ProyectoFile.IdProyectoFile = this.IdProyectoFile;
		 _ProyectoFile.IdFile = this.IdFile;
		 _ProyectoFile.IdProyecto = this.IdProyecto;
		 
		  return _ProyectoFile;
		}		
		public virtual void Set(ProyectoFile entity)
		{		   
		 this.IdProyectoFile= entity.IdProyectoFile ;
		  this.IdFile= entity.IdFile ;
		  this.IdProyecto= entity.IdProyecto ;
		 		  
		}		
		public virtual bool Equals(ProyectoFile entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoFile.Equals(this.IdProyectoFile))return false;
		  if((entity.IdFile == null)?(this.IdFile.HasValue && this.IdFile.Value > 0):!entity.IdFile.Equals(this.IdFile))return false;
						  if((entity.IdProyecto == null)?(this.IdProyecto.HasValue && this.IdProyecto.Value > 0):!entity.IdProyecto.Equals(this.IdProyecto))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoFile", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("File","FileInfo_FileType")
			,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			}));
		}
	}
}
		