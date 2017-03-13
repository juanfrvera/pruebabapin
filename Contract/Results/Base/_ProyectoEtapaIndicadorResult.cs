using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEtapaIndicadorResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoEtapaIndicador;}}
		 public int IdProyectoEtapaIndicador{get;set;}
		 public int IdProyectoEtapa{get;set;}
		 public string Descripcion{get;set;}
		 public int? IdUnidadMedia{get;set;}
		 public int? IdIndicador{get;set;}
		 public string NroExpediente{get;set;}
		 public DateTime? FechaLicitacion{get;set;}
		 public DateTime? FechaContratacion{get;set;}
		 public string Contratista{get;set;}
		 public DateTime? FechaInicioObra{get;set;}
		 public string PlazoEjecucion{get;set;}
		 public int? IdMoneda{get;set;}
		 public int? Magnitud{get;set;}
		 public decimal? MontoContrato{get;set;}
		 public decimal? MontoVigente{get;set;}
		 
		 public int? Indicador_IdMedioVerificacion{get;set;}	
	public string Indicador_Observacion{get;set;}	
	public string ProyectoEtapa_Nombre{get;set;}	
	public string ProyectoEtapa_CodigoVinculacion{get;set;}	
	public int? ProyectoEtapa_IdEstado{get;set;}	
	public DateTime? ProyectoEtapa_FechaInicioEstimada{get;set;}	
	public DateTime? ProyectoEtapa_FechaFinEstimada{get;set;}	
	public DateTime? ProyectoEtapa_FechaInicioRealizada{get;set;}	
	public DateTime? ProyectoEtapa_FechaFinRealizada{get;set;}	
	public int ProyectoEtapa_IdEtapa{get;set;}	
	public int ProyectoEtapa_IdProyecto{get;set;}	
	public int? ProyectoEtapa_NroEtapa{get;set;}	
					
		public virtual ProyectoEtapaIndicador ToEntity()
		{
		   ProyectoEtapaIndicador _ProyectoEtapaIndicador = new ProyectoEtapaIndicador();
		_ProyectoEtapaIndicador.IdProyectoEtapaIndicador = this.IdProyectoEtapaIndicador;
		 _ProyectoEtapaIndicador.IdProyectoEtapa = this.IdProyectoEtapa;
		 _ProyectoEtapaIndicador.Descripcion = this.Descripcion;
		 _ProyectoEtapaIndicador.IdUnidadMedia = this.IdUnidadMedia;
		 _ProyectoEtapaIndicador.IdIndicador = this.IdIndicador;
		 _ProyectoEtapaIndicador.NroExpediente = this.NroExpediente;
		 _ProyectoEtapaIndicador.FechaLicitacion = this.FechaLicitacion;
		 _ProyectoEtapaIndicador.FechaContratacion = this.FechaContratacion;
		 _ProyectoEtapaIndicador.Contratista = this.Contratista;
		 _ProyectoEtapaIndicador.FechaInicioObra = this.FechaInicioObra;
		 _ProyectoEtapaIndicador.PlazoEjecucion = this.PlazoEjecucion;
		 _ProyectoEtapaIndicador.IdMoneda = this.IdMoneda;
		 _ProyectoEtapaIndicador.Magnitud = this.Magnitud;
		 _ProyectoEtapaIndicador.MontoContrato = this.MontoContrato;
		 _ProyectoEtapaIndicador.MontoVigente = this.MontoVigente;
		 
		  return _ProyectoEtapaIndicador;
		}		
		public virtual void Set(ProyectoEtapaIndicador entity)
		{		   
		 this.IdProyectoEtapaIndicador= entity.IdProyectoEtapaIndicador ;
		  this.IdProyectoEtapa= entity.IdProyectoEtapa ;
		  this.Descripcion= entity.Descripcion ;
		  this.IdUnidadMedia= entity.IdUnidadMedia ;
		  this.IdIndicador= entity.IdIndicador ;
		  this.NroExpediente= entity.NroExpediente ;
		  this.FechaLicitacion= entity.FechaLicitacion ;
		  this.FechaContratacion= entity.FechaContratacion ;
		  this.Contratista= entity.Contratista ;
		  this.FechaInicioObra= entity.FechaInicioObra ;
		  this.PlazoEjecucion= entity.PlazoEjecucion ;
		  this.IdMoneda= entity.IdMoneda ;
		  this.Magnitud= entity.Magnitud ;
		  this.MontoContrato= entity.MontoContrato ;
		  this.MontoVigente= entity.MontoVigente ;
		 		  
		}		
		public virtual bool Equals(ProyectoEtapaIndicador entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEtapaIndicador.Equals(this.IdProyectoEtapaIndicador))return false;
		  if(!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa))return false;
		  if(!entity.Descripcion.Equals(this.Descripcion))return false;
		  if((entity.IdUnidadMedia == null)?this.IdUnidadMedia!=null:!entity.IdUnidadMedia.Equals(this.IdUnidadMedia))return false;
			 if((entity.IdIndicador == null)?(this.IdIndicador.HasValue && this.IdIndicador.Value > 0):!entity.IdIndicador.Equals(this.IdIndicador))return false;
						  if((entity.NroExpediente == null)?this.NroExpediente!=null:!entity.NroExpediente.Equals(this.NroExpediente))return false;
			 if((entity.FechaLicitacion == null)?this.FechaLicitacion!=null:!entity.FechaLicitacion.Equals(this.FechaLicitacion))return false;
			 if((entity.FechaContratacion == null)?this.FechaContratacion!=null:!entity.FechaContratacion.Equals(this.FechaContratacion))return false;
			 if((entity.Contratista == null)?this.Contratista!=null:!entity.Contratista.Equals(this.Contratista))return false;
			 if((entity.FechaInicioObra == null)?this.FechaInicioObra!=null:!entity.FechaInicioObra.Equals(this.FechaInicioObra))return false;
			 if((entity.PlazoEjecucion == null)?this.PlazoEjecucion!=null:!entity.PlazoEjecucion.Equals(this.PlazoEjecucion))return false;
			 if((entity.IdMoneda == null)?this.IdMoneda!=null:!entity.IdMoneda.Equals(this.IdMoneda))return false;
			 if((entity.Magnitud == null)?this.Magnitud!=null:!entity.Magnitud.Equals(this.Magnitud))return false;
			 if((entity.MontoContrato == null)?this.MontoContrato!=null:!entity.MontoContrato.Equals(this.MontoContrato))return false;
			 if((entity.MontoVigente == null)?this.MontoVigente!=null:!entity.MontoVigente.Equals(this.MontoVigente))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEtapaIndicador", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapa","ProyectoEtapa_Nombre")
			,new DataColumnMapping("Descripcion","Descripcion")
			,new DataColumnMapping("UnidadMedia","IdUnidadMedia")
			,new DataColumnMapping("Indicador","Indicador_Observacion")
			,new DataColumnMapping("NroExpediente","NroExpediente")
			,new DataColumnMapping("FechaLicitacion","FechaLicitacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("FechaContratacion","FechaContratacion","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Contratista","Contratista")
			,new DataColumnMapping("FechaInicioObra","FechaInicioObra","{0:dd/MM/yyyy}")
			,new DataColumnMapping("PlazoEjecucion","PlazoEjecucion")
			,new DataColumnMapping("Moneda","IdMoneda")
			,new DataColumnMapping("Magnitud","Magnitud")
			,new DataColumnMapping("MontoContrato","MontoContrato")
			,new DataColumnMapping("MontoVigente","MontoVigente")
			}));
		}

	}
}
		