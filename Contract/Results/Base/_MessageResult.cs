using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _MessageResult : IResult<int>
    {        
		public virtual int ID{get{return IdMessage;}}
		 public int IdMessage{get;set;}
		 public int IdMediaFrom{get;set;}
		 public int IdUserFrom{get;set;}
		 public int IdPriority{get;set;}
		 public string Subject{get;set;}
		 public string Body{get;set;}
		 public DateTime StartDate{get;set;}
		 public DateTime? SendDate{get;set;}
		 public bool IsManual{get;set;}
		 public int? IdProyecto{get;set;}
		 
		 public string MediaFrom_Name{get;set;}	
	public string MediaFrom_Img{get;set;}	
	public string Priority_Name{get;set;}	
	public string Priority_Img{get;set;}	
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
	public string UserFrom_NombreUsuario{get;set;}	
	public string UserFrom_Clave{get;set;}	
	public bool UserFrom_Activo{get;set;}	
	public bool UserFrom_EsSectioralista{get;set;}	
	public int UserFrom_IdLanguage{get;set;}	
	public bool UserFrom_AccesoTotal{get;set;}	
					
		public virtual Message ToEntity()
		{
		   Message _Message = new Message();
		_Message.IdMessage = this.IdMessage;
		 _Message.IdMediaFrom = this.IdMediaFrom;
		 _Message.IdUserFrom = this.IdUserFrom;
		 _Message.IdPriority = this.IdPriority;
		 _Message.Subject = this.Subject;
		 _Message.Body = this.Body;
		 _Message.StartDate = this.StartDate;
		 _Message.SendDate = this.SendDate;
		 _Message.IsManual = this.IsManual;
		 _Message.IdProyecto = this.IdProyecto;
		 
		  return _Message;
		}		
		public virtual void Set(Message entity)
		{		   
		 this.IdMessage= entity.IdMessage ;
		  this.IdMediaFrom= entity.IdMediaFrom ;
		  this.IdUserFrom= entity.IdUserFrom ;
		  this.IdPriority= entity.IdPriority ;
		  this.Subject= entity.Subject ;
		  this.Body= entity.Body ;
		  this.StartDate= entity.StartDate ;
		  this.SendDate= entity.SendDate ;
		  this.IsManual= entity.IsManual ;
		  this.IdProyecto= entity.IdProyecto ;
		 		  
		}		
		public virtual bool Equals(Message entity)
        {
		   if(entity == null)return false;
         if(!entity.IdMessage.Equals(this.IdMessage))return false;
		  if(!entity.IdMediaFrom.Equals(this.IdMediaFrom))return false;
		  if(!entity.IdUserFrom.Equals(this.IdUserFrom))return false;
		  if(!entity.IdPriority.Equals(this.IdPriority))return false;
		  if(!entity.Subject.Equals(this.Subject))return false;
		  if((entity.Body == null)?this.Body!=null:!entity.Body.Equals(this.Body))return false;
			 if(!entity.StartDate.Equals(this.StartDate))return false;
		  if((entity.SendDate == null)?this.SendDate!=null:!entity.SendDate.Equals(this.SendDate))return false;
			 if(!entity.IsManual.Equals(this.IsManual))return false;
		  if((entity.IdProyecto == null)?(this.IdProyecto.HasValue && this.IdProyecto.Value > 0):!entity.IdProyecto.Equals(this.IdProyecto))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Message", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("MediaFrom","MessageMedia_Name")
			,new DataColumnMapping("UserFrom","Usuario_NombreUsuario")
			,new DataColumnMapping("Priority","Priority_Name")
			,new DataColumnMapping("Subject","Subject")
			,new DataColumnMapping("Body","Body")
			,new DataColumnMapping("StartDate","StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("SendDate","SendDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("IsManual","IsManual")
			,new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			}));
		}
	}
}
		