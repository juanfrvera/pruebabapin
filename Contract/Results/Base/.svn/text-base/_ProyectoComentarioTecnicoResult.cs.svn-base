using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoComentarioTecnicoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoComentarioTecnico;}}
		 public int IdProyectoComentarioTecnico{get;set;}
		 public int? IdProyecto{get;set;}
		 public int IdComentarioTecnico{get;set;}
		 public string Observacion{get;set;} /*Es el comentario en si mismo*/
		 public int IdUsuario{get;set;}
		 public DateTime Fecha{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public int? IdPrestamo{get;set;}

         public bool GeneraComentarioTecnico { get; set; }
         public string ComentarioTecnico_Nombre{get;set;}	
	public bool ComentarioTecnico_Activo{get;set;}	
	public int? Prestamo_IdPrograma{get;set;}	
	public int? Prestamo_Numero{get;set;}	
	public string Prestamo_Denominacion{get;set;}	
	public string Prestamo_Descripcion{get;set;}	
	public string Prestamo_Observacion{get;set;}	
	public DateTime? Prestamo_FechaAlta{get;set;}	
	public DateTime? Prestamo_FechaModificacion{get;set;}	
	public int? Prestamo_IdUsuarioModificacion{get;set;}	
	public int? Prestamo_IdEstadoActual{get;set;}	
	public string Prestamo_ResponsablePolitico{get;set;}	
	public string Prestamo_ResponsableTecnico{get;set;}	
	public string Prestamo_CodigoVinculacion1{get;set;}	
	public string Prestamo_CodigoVinculacion2{get;set;}	
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
					
		public virtual ProyectoComentarioTecnico ToEntity()
		{
		   ProyectoComentarioTecnico _ProyectoComentarioTecnico = new ProyectoComentarioTecnico();
		_ProyectoComentarioTecnico.IdProyectoComentarioTecnico = this.IdProyectoComentarioTecnico;
		 _ProyectoComentarioTecnico.IdProyecto = this.IdProyecto;
		 _ProyectoComentarioTecnico.IdComentarioTecnico = this.IdComentarioTecnico;
		 _ProyectoComentarioTecnico.Observacion = this.Observacion;
		 _ProyectoComentarioTecnico.IdUsuario = this.IdUsuario;
		 _ProyectoComentarioTecnico.Fecha = this.Fecha;
		 _ProyectoComentarioTecnico.FechaAlta = this.FechaAlta;
		 _ProyectoComentarioTecnico.IdPrestamo = this.IdPrestamo;
		 
		  return _ProyectoComentarioTecnico;
		}		
		public virtual void Set(ProyectoComentarioTecnico entity)
		{		   
		 this.IdProyectoComentarioTecnico= entity.IdProyectoComentarioTecnico ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdComentarioTecnico= entity.IdComentarioTecnico ;
		  this.Observacion= entity.Observacion ;
		  this.IdUsuario= entity.IdUsuario ;
		  this.Fecha= entity.Fecha ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.IdPrestamo= entity.IdPrestamo ;
		 		  
		}		
		public virtual bool Equals(ProyectoComentarioTecnico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoComentarioTecnico.Equals(this.IdProyectoComentarioTecnico))return false;
		  if((entity.IdProyecto == null)?(this.IdProyecto.HasValue && this.IdProyecto.Value > 0):!entity.IdProyecto.Equals(this.IdProyecto))return false;
						  if(!entity.IdComentarioTecnico.Equals(this.IdComentarioTecnico))return false;
		  if((entity.Observacion == null)?this.Observacion!=null:!entity.Observacion.Equals(this.Observacion))return false;
			 if(!entity.IdUsuario.Equals(this.IdUsuario))return false;
		  if(!entity.Fecha.Equals(this.Fecha))return false;
		  if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if((entity.IdPrestamo == null)?(this.IdPrestamo.HasValue && this.IdPrestamo.Value > 0):!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoComentarioTecnico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ComentarioTecnico","ComentarioTecnico_Nombre")
			,new DataColumnMapping("Observacion","Observacion")
			,new DataColumnMapping("Usuario","IdUsuario")
			,new DataColumnMapping("Fecha","Fecha","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaAlta","FechaAlta","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			}));
		}
	}
}
		