using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoFaseProyectoEtapaResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoFaseProyectoEtapa;}}
		 public int IdProyectoFaseProyectoEtapa{get;set;}
		 public int IdProyectoFase{get;set;}
		 public int IdProyectoEtapa{get;set;}
		 
		 public int ProyectoEtapa_IdFase{get;set;}	
	public string ProyectoEtapa_Codigo{get;set;}	
	public string ProyectoEtapa_Nombre{get;set;}	
	public int ProyectoEtapa_Orden{get;set;}	
	public bool ProyectoEtapa_Activo{get;set;}	
	public string ProyectoFase_Codigo{get;set;}	
	public string ProyectoFase_Nombre{get;set;}	
	public int ProyectoFase_Orden{get;set;}	
	public bool ProyectoFase_Activo{get;set;}	
					
		public virtual ProyectoFaseProyectoEtapa ToEntity()
		{
		   ProyectoFaseProyectoEtapa _ProyectoFaseProyectoEtapa = new ProyectoFaseProyectoEtapa();
		_ProyectoFaseProyectoEtapa.IdProyectoFaseProyectoEtapa = this.IdProyectoFaseProyectoEtapa;
		 _ProyectoFaseProyectoEtapa.IdProyectoFase = this.IdProyectoFase;
		 _ProyectoFaseProyectoEtapa.IdProyectoEtapa = this.IdProyectoEtapa;
		 
		  return _ProyectoFaseProyectoEtapa;
		}		
		public virtual void Set(ProyectoFaseProyectoEtapa entity)
		{		   
		 this.IdProyectoFaseProyectoEtapa= entity.IdProyectoFaseProyectoEtapa ;
		  this.IdProyectoFase= entity.IdProyectoFase ;
		  this.IdProyectoEtapa= entity.IdProyectoEtapa ;
		 		  
		}		
		public virtual bool Equals(ProyectoFaseProyectoEtapa entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoFaseProyectoEtapa.Equals(this.IdProyectoFaseProyectoEtapa))return false;
		  if(!entity.IdProyectoFase.Equals(this.IdProyectoFase))return false;
		  if(!entity.IdProyectoEtapa.Equals(this.IdProyectoEtapa))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoFaseProyectoEtapa", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("ProyectoFase","Fase_Nombre")
			,new DataColumnMapping("ProyectoEtapa","Etapa_Nombre")
			}));
		}
	}
}
		