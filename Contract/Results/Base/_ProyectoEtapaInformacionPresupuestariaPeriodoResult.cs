using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoEtapaInformacionPresupuestariaPeriodoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoEtapaInformacionPresupuestariaPeriodo;}}
		 public int IdProyectoEtapaInformacionPresupuestariaPeriodo{get;set;}
		 public int IdProyectoEtapaInformacionPresupuestaria{get;set;}
		 public int Periodo{get;set;}
         public decimal MontoInicial{ get; set; }
         public decimal MontoVigente { get; set; }
         public decimal MontoDevengado { get; set; }
         public bool MontoVigenteEstimativo { get; set; }
		 
		 public int ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapa{get;set;}	
	public int ProyectoEtapaInformacionPresupuestaria_IdClasificacionGasto{get;set;}	
	public int ProyectoEtapaInformacionPresupuestaria_IdFuenteFinanciamiento{get;set;}	
	public int ProyectoEtapaInformacionPresupuestaria_IdMoneda{get;set;}	
					
		public virtual ProyectoEtapaInformacionPresupuestariaPeriodo ToEntity()
		{
		   ProyectoEtapaInformacionPresupuestariaPeriodo _ProyectoEtapaInformacionPresupuestariaPeriodo = new ProyectoEtapaInformacionPresupuestariaPeriodo();
		_ProyectoEtapaInformacionPresupuestariaPeriodo.IdProyectoEtapaInformacionPresupuestariaPeriodo = this.IdProyectoEtapaInformacionPresupuestariaPeriodo;
		 _ProyectoEtapaInformacionPresupuestariaPeriodo.IdProyectoEtapaInformacionPresupuestaria = this.IdProyectoEtapaInformacionPresupuestaria;
		 _ProyectoEtapaInformacionPresupuestariaPeriodo.Periodo = this.Periodo;
         _ProyectoEtapaInformacionPresupuestariaPeriodo.MontoInicial = this.MontoInicial;
         _ProyectoEtapaInformacionPresupuestariaPeriodo.MontoVigente = this.MontoVigente;
         _ProyectoEtapaInformacionPresupuestariaPeriodo.MontoDevengado = this.MontoDevengado;
         _ProyectoEtapaInformacionPresupuestariaPeriodo.MontoVigenteEstimativo = this.MontoVigenteEstimativo;
		 
		  return _ProyectoEtapaInformacionPresupuestariaPeriodo;
		}		
		public virtual void Set(ProyectoEtapaInformacionPresupuestariaPeriodo entity)
		{		   
		 this.IdProyectoEtapaInformacionPresupuestariaPeriodo= entity.IdProyectoEtapaInformacionPresupuestariaPeriodo ;
		  this.IdProyectoEtapaInformacionPresupuestaria= entity.IdProyectoEtapaInformacionPresupuestaria ;
		  this.Periodo= entity.Periodo ;
          this.MontoInicial = entity.MontoInicial;
          this.MontoVigente = entity.MontoVigente;
          this.MontoDevengado = entity.MontoDevengado;
          this.MontoVigenteEstimativo = entity.MontoVigenteEstimativo;
		 		  
		}		
		public virtual bool Equals(ProyectoEtapaInformacionPresupuestariaPeriodo entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoEtapaInformacionPresupuestariaPeriodo.Equals(this.IdProyectoEtapaInformacionPresupuestariaPeriodo))return false;
		  if(!entity.IdProyectoEtapaInformacionPresupuestaria.Equals(this.IdProyectoEtapaInformacionPresupuestaria))return false;
		  if(!entity.Periodo.Equals(this.Periodo))return false;
             if (!entity.MontoInicial.Equals(this.MontoInicial)) return false;
             if (!entity.MontoVigente.Equals(this.MontoVigente)) return false;
             if (!entity.MontoDevengado.Equals(this.MontoDevengado)) return false;
             if (!entity.MontoVigenteEstimativo.Equals(this.MontoVigenteEstimativo)) return false;
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoEtapaInformacionPresupuestariaPeriodo", 
                new List<DataColumnMapping>( new DataColumnMapping[]{
		    new DataColumnMapping("ProyectoEtapaInformacionPresupuestaria","ProyectoEtapaInformacionPresupuestaria_IdProyectoEtapaInformacionPresupuestaria")
			,new DataColumnMapping("Periodo","Periodo")
            ,new DataColumnMapping("MontoInicial","MontoInicial")
            ,new DataColumnMapping("MontoVigente","MontoVigente")
            ,new DataColumnMapping("MontoDevengado","MontoDevengado")
            ,new DataColumnMapping("MontoVigenteEstimativo","MontoVigenteEstimativo")
			}));
		}
	}
}
		