using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoOrigenFinanciamientoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoOrigenFinanciamiento;}}
		 public int IdProyectoOrigenFinanciamiento{get;set;}
		 public int IdProyecto{get;set;}
		 public int IdProyectoOrigenFinancianmientoTipo{get;set;}
		 public int? IdPrestamo{get;set;}
		 public int? IdTransferencia{get;set;}
		 
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
	public int Proyecto_IdTipoProyecto{get;set;}	
	public int Proyecto_IdSubPrograma{get;set;}	
	public int Proyecto_Codigo{get;set;}	
	public string Proyecto_ProyectoDenominacion{get;set;}	
	public string Proyecto_ProyectoSituacionActual{get;set;}	
	public string Proyecto_ProyectoDescripcion{get;set;}	
	public string Proyecto_ProyectoObservacion{get;set;}	
	public int Proyecto_IdEstado{get;set;}	
	public int? Proyecto_IdProceso{get;set;}	
	public int? Proyecto_IdModalidadContratacion{get;set;}	
	public int? Proyecto_IdFinalidadFuncion{get;set;}	
	public int? Proyecto_IdOrganismoPrioridad{get;set;}	
	public int? Proyecto_SubPrioridad{get;set;}	
	public bool Proyecto_EsBorrador{get;set;}	
	public bool? Proyecto_EsProyecto{get;set;}	
	public int? Proyecto_NroProyecto{get;set;}	
	public int? Proyecto_AnioCorriente{get;set;}	
	public DateTime? Proyecto_FechaInicioEjecucionCalculada{get;set;}	
	public DateTime? Proyecto_FechaFinEjecucionCalculada{get;set;}	
	public DateTime Proyecto_FechaAlta{get;set;}	
	public DateTime Proyecto_FechaModificacion{get;set;}	
	public int Proyecto_IdUsuarioModificacion{get;set;}	
	public int? Proyecto_IdProyectoPlan{get;set;}	
	public bool Proyecto_EvaluarValidaciones{get;set;}	
	public bool Proyecto_Activo{get;set;}	
	public string ProyectoOrigenFinancianmientoTipo_Nombre{get;set;}	
	public int? Transferencia_IdSubPrograma{get;set;}	
	public int? Transferencia_Proyecto{get;set;}	
	public int? Transferencia_Actividad{get;set;}	
	public int? Transferencia_Obra{get;set;}	
	public string Transferencia_Denominacion{get;set;}	
	public int? Transferencia_IdClasificacionGasto{get;set;}	
	public int? Transferencia_IdClasificacionGeografica{get;set;}	
	public bool? Transferencia_Activo{get;set;}	
					
		public virtual ProyectoOrigenFinanciamiento ToEntity()
		{
		   ProyectoOrigenFinanciamiento _ProyectoOrigenFinanciamiento = new ProyectoOrigenFinanciamiento();
		_ProyectoOrigenFinanciamiento.IdProyectoOrigenFinanciamiento = this.IdProyectoOrigenFinanciamiento;
		 _ProyectoOrigenFinanciamiento.IdProyecto = this.IdProyecto;
		 _ProyectoOrigenFinanciamiento.IdProyectoOrigenFinancianmientoTipo = this.IdProyectoOrigenFinancianmientoTipo;
		 _ProyectoOrigenFinanciamiento.IdPrestamo = this.IdPrestamo;
		 _ProyectoOrigenFinanciamiento.IdTransferencia = this.IdTransferencia;
		 
		  return _ProyectoOrigenFinanciamiento;
		}		
		public virtual void Set(ProyectoOrigenFinanciamiento entity)
		{		   
		 this.IdProyectoOrigenFinanciamiento= entity.IdProyectoOrigenFinanciamiento ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdProyectoOrigenFinancianmientoTipo= entity.IdProyectoOrigenFinancianmientoTipo ;
		  this.IdPrestamo= entity.IdPrestamo ;
		  this.IdTransferencia= entity.IdTransferencia ;
		 		  
		}		
		public virtual bool Equals(ProyectoOrigenFinanciamiento entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoOrigenFinanciamiento.Equals(this.IdProyectoOrigenFinanciamiento))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdProyectoOrigenFinancianmientoTipo.Equals(this.IdProyectoOrigenFinancianmientoTipo))return false;
		  if((entity.IdPrestamo == null)?(this.IdPrestamo.HasValue && this.IdPrestamo.Value > 0):!entity.IdPrestamo.Equals(this.IdPrestamo))return false;
						  if((entity.IdTransferencia == null)?(this.IdTransferencia.HasValue && this.IdTransferencia.Value > 0):!entity.IdTransferencia.Equals(this.IdTransferencia))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoOrigenFinanciamiento", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ProyectoOrigenFinancianmientoTipo","ProyectoOrigenFinanciamientoTipo_Nombre")
			,new DataColumnMapping("Prestamo","Prestamo_Descripcion")
			,new DataColumnMapping("Transferencia","Transferencia_Denominacion")
			}));
		}
	}
}
		