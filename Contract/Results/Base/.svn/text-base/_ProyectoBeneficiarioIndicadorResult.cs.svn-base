using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoBeneficiarioIndicadorResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoBeneficiarioIndicador;}}
		 public int IdProyectoBeneficiarioIndicador{get;set;}
		 public int IdProyecto{get;set;}
		 public string Beneficiario{get;set;}
		 public bool Indirecto{get;set;}
		 public int IdIndicador{get;set;}

         public int? Indicador_IdMedioVerificacion { get; set; }
         public string Indicador_Observacion { get; set; }
         public int Proyecto_IdTipoProyecto { get; set; }
         public int Proyecto_IdSubPrograma { get; set; }
         public int Proyecto_Codigo { get; set; }
         public string Proyecto_ProyectoDenominacion { get; set; }
         public string Proyecto_ProyectoSituacionActual { get; set; }
         public string Proyecto_ProyectoDescripcion { get; set; }
         public string Proyecto_ProyectoObservacion { get; set; }
         public int Proyecto_IdEstado { get; set; }
         public int? Proyecto_IdProceso { get; set; }
         public int? Proyecto_IdModalidadContratacion { get; set; }
         public int? Proyecto_IdFinalidadFuncion { get; set; }
         public int? Proyecto_IdOrganismoPrioridad { get; set; }
         public int? Proyecto_SubPrioridad { get; set; }
         public bool Proyecto_EsBorrador { get; set; }
         public bool? Proyecto_EsProyecto { get; set; }
         public int? Proyecto_NroProyecto { get; set; }
         public int? Proyecto_AnioCorriente { get; set; }
         public DateTime? Proyecto_FechaInicioEjecucionCalculada { get; set; }
         public DateTime? Proyecto_FechaFinEjecucionCalculada { get; set; }
         public DateTime Proyecto_FechaAlta { get; set; }
         public DateTime Proyecto_FechaModificacion { get; set; }
         public int Proyecto_IdUsuarioModificacion { get; set; }
         public int? Proyecto_IdProyectoPlan { get; set; }
         public bool Proyecto_EvaluarValidaciones { get; set; }	
					
		public virtual ProyectoBeneficiarioIndicador ToEntity()
		{
		   ProyectoBeneficiarioIndicador _ProyectoBeneficiarioIndicador = new ProyectoBeneficiarioIndicador();
		_ProyectoBeneficiarioIndicador.IdProyectoBeneficiarioIndicador = this.IdProyectoBeneficiarioIndicador;
		 _ProyectoBeneficiarioIndicador.IdProyecto = this.IdProyecto;
		 _ProyectoBeneficiarioIndicador.Beneficiario = this.Beneficiario;
		 _ProyectoBeneficiarioIndicador.Indirecto = this.Indirecto;
		 _ProyectoBeneficiarioIndicador.IdIndicador = this.IdIndicador;
		 
		  return _ProyectoBeneficiarioIndicador;
		}		
		public virtual void Set(ProyectoBeneficiarioIndicador entity)
		{		   
		 this.IdProyectoBeneficiarioIndicador= entity.IdProyectoBeneficiarioIndicador ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.Beneficiario= entity.Beneficiario ;
		  this.Indirecto= entity.Indirecto ;
		  this.IdIndicador= entity.IdIndicador ;
		 		  
		}		
		public virtual bool Equals(ProyectoBeneficiarioIndicador entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoBeneficiarioIndicador.Equals(this.IdProyectoBeneficiarioIndicador))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.Beneficiario.Equals(this.Beneficiario))return false;
		  if(!entity.Indirecto.Equals(this.Indirecto))return false;
		  if(!entity.IdIndicador.Equals(this.IdIndicador))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoBeneficiarioIndicador", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("Beneficiario","Beneficiario")
			,new DataColumnMapping("Indirecto","Indirecto")
			,new DataColumnMapping("Indicador","Indicador_Observacion")
			}));
		}
	}
}
		