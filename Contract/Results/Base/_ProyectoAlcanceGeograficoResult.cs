using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _ProyectoAlcanceGeograficoResult : IResult<int>
    {        
		public virtual int ID{get{return IdProyectoAlcanceGeografico;}}
		public int IdProyectoAlcanceGeografico{get;set;}
		public int IdProyecto{get;set;}
		public int IdClasificacionGeografica{get;set;}
        public int ClasificacionGeografica_IdClasificacionGeograficaTipo{get;set;}	
        public string ClasificacionGeografica_Descripcion{get;set;}	
					
		public virtual ProyectoAlcanceGeografico ToEntity()
		{
		   ProyectoAlcanceGeografico _ProyectoAlcanceGeografico = new ProyectoAlcanceGeografico();
		_ProyectoAlcanceGeografico.IdProyectoAlcanceGeografico = this.IdProyectoAlcanceGeografico;
		 _ProyectoAlcanceGeografico.IdProyecto = this.IdProyecto;
		 _ProyectoAlcanceGeografico.IdClasificacionGeografica = this.IdClasificacionGeografica;
		 
		  return _ProyectoAlcanceGeografico;
		}		
		public virtual void Set(ProyectoAlcanceGeografico entity)
		{		   
		 this.IdProyectoAlcanceGeografico= entity.IdProyectoAlcanceGeografico ;
		  this.IdProyecto= entity.IdProyecto ;
		  this.IdClasificacionGeografica= entity.IdClasificacionGeografica ;
		 		  
		}		
		public virtual bool Equals(ProyectoAlcanceGeografico entity)
        {
		   if(entity == null)return false;
         if(!entity.IdProyectoAlcanceGeografico.Equals(this.IdProyectoAlcanceGeografico))return false;
		  if(!entity.IdProyecto.Equals(this.IdProyecto))return false;
		  if(!entity.IdClasificacionGeografica.Equals(this.IdClasificacionGeografica))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("ProyectoAlcanceGeografico", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Proyecto","Proyecto_ProyectoDenominacion")
			,new DataColumnMapping("ClasificacionGeografica","ClasificacionGeografica_Nombre")
			}));
		}
	}
}
		