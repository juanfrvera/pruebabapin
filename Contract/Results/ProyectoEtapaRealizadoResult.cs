using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoEtapaRealizadoResult : IResult<int>
    {
        public string Fecha
        {
            get 
            {
                string fecha = "";
                if (this.Periodos.Count > 0)
                    fecha = this.Periodos[0].Fecha.ToShortDateString();
                return fecha;
            }
        }
        public string CodigoCompletoGasto
        {
            get { return this.ClasificacionGasto_CodigoCompleto; }
            set { this.ClasificacionGasto_CodigoCompleto = value; }
        }
        public string CodigoGasto
        {
            get { return this.ClasificacionGasto_Codigo; }
            set { this.ClasificacionGasto_Codigo = value; }
        }
        public string ObjetoGasto
        {
            get { return this.ClasificacionGasto_Nombre; }
            set { this.ClasificacionGasto_Nombre = value; }
        }
        public string FuenteFinanciemiento
        {
            get { return this.FuenteFinanciamiento_Nombre; }
            set { this.FuenteFinanciamiento_Nombre = value; }
        }
        public string OrigenFinanciemiento {get; set;}

        public decimal TotalRealizado
        {
            get
            {
                decimal rv = 0;
                foreach (ProyectoEtapaRealizadoPeriodoResult e in this.Periodos)
                    rv += e.MontoCalculado;
                return rv;
            }
        }
        public decimal TotalRealizadoAnioAnterior
        {
            get
            {
                decimal rv = 0;
                foreach (ProyectoEtapaRealizadoPeriodoResult e in this.Periodos)
                {
                    if (e.Periodo == DateTime.Now.Year-1)
                        rv += e.MontoCalculado;
                }
                return rv;
            }
        }
        

        public List<ProyectoEtapaRealizadoPeriodoResult> Periodos = new List<ProyectoEtapaRealizadoPeriodoResult>();

        	public virtual int ID{get{return IdProyectoEtapaRealizado;}}
		 public int IdProyectoEtapaRealizado{get;set;}
		 public int IdProyectoEtapa{get;set;}
		 public int IdClasificacionGasto{get;set;}
		 public int IdFuenteFinanciamiento{get;set;}
		 public int? IdMoneda{get;set;}
		 
         public string ClasificacionGasto_Codigo{get;set;}
         public string ClasificacionGasto_CodigoCompleto { get; set; }	
        public string ClasificacionGasto_Nombre{get;set;}	
    //public int ClasificacionGasto_IdClasificacionGastoTipo{get;set;}	
    //public int? ClasificacionGasto_IdCaracterEconomico{get;set;}	
    //public bool ClasificacionGasto_Activo{get;set;}	
    //public int? ClasificacionGasto_IdClasificacionGastoPadre{get;set;}	
    //public string ClasificacionGasto_BreadcrumbId{get;set;}	
    //public string ClasificacionGasto_BreadcrumbOrden{get;set;}	
    //public int? ClasificacionGasto_Nivel{get;set;}	
    //public int? ClasificacionGasto_Orden{get;set;}	
    //public string ClasificacionGasto_Descripcion{get;set;}	
    //public string ClasificacionGasto_DescripcionInvertida{get;set;}	
    //public int ClasificacionGasto_IdClasificacionGastoRubro{get;set;}	
    //public bool ClasificacionGasto_Seleccionable{get;set;}	
    //public string ClasificacionGasto_BreadcrumbCode{get;set;}	
    //public string ClasificacionGasto_DescripcionCodigo{get;set;}	
    //public string FuenteFinanciamiento_Codigo{get;set;}	
    public string FuenteFinanciamiento_Nombre{get;set;}	
    //public int FuenteFinanciamiento_IdFuenteFinanciamientoTipo{get;set;}	
    //public bool FuenteFinanciamiento_Activo{get;set;}	
    //public int? FuenteFinanciamiento_IdFuenteFinanciamientoPadre{get;set;}	
    //public string FuenteFinanciamiento_BreadcrumbId{get;set;}	
    //public string FuenteFinanciamiento_BreadcrumbOrden{get;set;}	
    //public int? FuenteFinanciamiento_Nivel{get;set;}	
    //public int? FuenteFinanciamiento_Orden{get;set;}	
    //public string FuenteFinanciamiento_Descripcion{get;set;}	
    //public string FuenteFinanciamiento_DescripcionInvertida{get;set;}	
    //public bool FuenteFinanciamiento_Seleccionable{get;set;}	
    //public string FuenteFinanciamiento_BreadcrumbCode{get;set;}	
    //public string FuenteFinanciamiento_DescripcionCodigo{get;set;}	
    //public string Moneda_Sigla{get;set;}	
    //public string Moneda_Nombre{get;set;}	
    //public bool? Moneda_Activo{get;set;}	
    //public bool? Moneda_Base{get;set;}	
    //public string ProyectoEtapa_Nombre{get;set;}	
    //public string ProyectoEtapa_CodigoVinculacion{get;set;}	
    //public int? ProyectoEtapa_IdEstado{get;set;}	
    //public DateTime? ProyectoEtapa_FechaInicioEstimada{get;set;}	
    //public DateTime? ProyectoEtapa_FechaFinEstimada{get;set;}	
    //public DateTime? ProyectoEtapa_FechaInicioRealizada{get;set;}	
    //public DateTime? ProyectoEtapa_FechaFinRealizada{get;set;}	
    //public int ProyectoEtapa_IdEtapa{get;set;}	
    //public int ProyectoEtapa_IdProyecto{get;set;}	
    //public int? ProyectoEtapa_NroEtapa{get;set;}	
					
		public virtual ProyectoEtapaRealizado ToEntity()
		{
		   ProyectoEtapaRealizado _ProyectoEtapaRealizado = new ProyectoEtapaRealizado();
		_ProyectoEtapaRealizado.IdProyectoEtapaRealizado = this.IdProyectoEtapaRealizado;
		 _ProyectoEtapaRealizado.IdProyectoEtapa = this.IdProyectoEtapa;
		 _ProyectoEtapaRealizado.IdClasificacionGasto = this.IdClasificacionGasto;
		 _ProyectoEtapaRealizado.IdFuenteFinanciamiento = this.IdFuenteFinanciamiento;
		 _ProyectoEtapaRealizado.IdMoneda = this.IdMoneda;
		 
		  return _ProyectoEtapaRealizado;
		}		
		public virtual void Set(ProyectoEtapaRealizado entity)
		{		   
		 this.IdProyectoEtapaRealizado= entity.IdProyectoEtapaRealizado ;
		  this.IdProyectoEtapa= entity.IdProyectoEtapa ;
		  this.IdClasificacionGasto= entity.IdClasificacionGasto ;
		  this.IdFuenteFinanciamiento= entity.IdFuenteFinanciamiento ;
		  this.IdMoneda= entity.IdMoneda ;
		 		  
		}		
		public virtual bool Equals(ProyectoEtapaRealizado entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEtapaRealizado.Equals(this.IdProyectoEtapaRealizado))return false;
		  if(!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa))return false;
		  if(!entity.IdClasificacionGasto.Equals(this.IdClasificacionGasto))return false;
		  if(!entity.IdFuenteFinanciamiento.Equals(this.IdFuenteFinanciamiento))return false;
		  if((entity.IdMoneda == null)?(this.IdMoneda.HasValue && this.IdMoneda.Value > 0):!entity.IdMoneda.Equals(this.IdMoneda))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEtapaRealizado", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoEtapa","ProyectoEtapa_Nombre")
			,new DataColumnMapping("ClasificacionGasto","ClasificacionGasto_Nombre")
			,new DataColumnMapping("FuenteFinanciamiento","FuenteFinanciamiento_Nombre")
			,new DataColumnMapping("Moneda","Moneda_Nombre")
			}));
		}
    }
}
