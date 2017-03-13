using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProgramaResult : IResult<int>
    {        
		public virtual int ID{get{return IdPrograma;}}
		 public int IdPrograma{get;set;}
		 public int IdSAF{get;set;}
		 public string Codigo{get;set;}
		 public string Nombre{get;set;}
		 public DateTime FechaAlta{get;set;}
		 public DateTime? FechaBaja{get;set;}
		 public bool Activo{get;set;}
		 public int? IdSectorialista{get;set;}
		 
		 public string SAF_Codigo{get;set;}	
	public string SAF_Denominacion{get;set;}	
	public int SAF_IdTipoOrganismo{get;set;}	
	public int? SAF_IdSector{get;set;}	
	public int? SAF_IdAdministracionTipo{get;set;}	
	public int? SAF_IdEntidadTipo{get;set;}	
	public int? SAF_IdJurisdiccion{get;set;}	
	public int? SAF_IdSubJurisdiccion{get;set;}	
	public DateTime SAF_FechaAlta{get;set;}	
	public DateTime? SAF_FechaBaja{get;set;}	
	public bool SAF_Activo{get;set;}	
	public string Sectorialista_NombreUsuario{get;set;}	
	public string Sectorialista_Clave{get;set;}	
	public bool? Sectorialista_Activo{get;set;}	
	public bool? Sectorialista_EsSectioralista{get;set;}	
	public int? Sectorialista_IdLanguage{get;set;}	
	public bool? Sectorialista_AccesoTotal{get;set;}	
					
		public virtual Programa ToEntity()
		{
		   Programa _Programa = new Programa();
		_Programa.IdPrograma = this.IdPrograma;
		 _Programa.IdSAF = this.IdSAF;
		 _Programa.Codigo = this.Codigo;
		 _Programa.Nombre = this.Nombre;
		 _Programa.FechaAlta = this.FechaAlta;
		 _Programa.FechaBaja = this.FechaBaja;
		 _Programa.Activo = this.Activo;
		 _Programa.IdSectorialista = this.IdSectorialista;
		 
		  return _Programa;
		}		
		public virtual void Set(Programa entity)
		{		   
		 this.IdPrograma= entity.IdPrograma ;
		  this.IdSAF= entity.IdSAF ;
		  this.Codigo= entity.Codigo ;
		  this.Nombre= entity.Nombre ;
		  this.FechaAlta= entity.FechaAlta ;
		  this.FechaBaja= entity.FechaBaja ;
		  this.Activo= entity.Activo ;
		  this.IdSectorialista= entity.IdSectorialista ;
		 		  
		}		
		public virtual bool Equals(Programa entity)
        {
		   if(entity == null)return false;
         if(!entity.IdPrograma.Equals(this.IdPrograma))return false;
		  if(!entity.IdSAF.Equals(this.IdSAF))return false;
		  if(!entity.Codigo.Equals(this.Codigo))return false;
		  if(!entity.Nombre.Equals(this.Nombre))return false;
		  if(!entity.FechaAlta.Equals(this.FechaAlta))return false;
		  if((entity.FechaBaja == null)?this.FechaBaja!=null:!entity.FechaBaja.Equals(this.FechaBaja))return false;
			 if(!entity.Activo.Equals(this.Activo))return false;
		  if((entity.IdSectorialista == null)?(this.IdSectorialista.HasValue && this.IdSectorialista.Value > 0):!entity.IdSectorialista.Equals(this.IdSectorialista))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Programa", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("SAF","Saf_Codigo")
			,new DataColumnMapping("Codigo","Codigo")
			}));
		}
	}
}
		