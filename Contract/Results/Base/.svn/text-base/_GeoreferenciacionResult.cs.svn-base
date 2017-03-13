using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _GeoreferenciacionResult : IResult<int>
    {        
		public virtual int ID{get{return IdGeoreferenciacion;}}
		 public int IdGeoreferenciacion{get;set;}
		 public int IdGeoreferenciacionTipo{get;set;}
		 
		 public string GeoreferenciacionTipo_Nombre{get;set;}	
					
		public virtual Georeferenciacion ToEntity()
		{
		   Georeferenciacion _Georeferenciacion = new Georeferenciacion();
		_Georeferenciacion.IdGeoreferenciacion = this.IdGeoreferenciacion;
		 _Georeferenciacion.IdGeoreferenciacionTipo = this.IdGeoreferenciacionTipo;
		 
		  return _Georeferenciacion;
		}		
		public virtual void Set(Georeferenciacion entity)
		{		   
		 this.IdGeoreferenciacion= entity.IdGeoreferenciacion ;
		  this.IdGeoreferenciacionTipo= entity.IdGeoreferenciacionTipo ;
		 		  
		}		
		public virtual bool Equals(Georeferenciacion entity)
        {
		   if(entity == null)return false;
         if(!entity.IdGeoreferenciacion.Equals(this.IdGeoreferenciacion))return false;
		  if(!entity.IdGeoreferenciacionTipo.Equals(this.IdGeoreferenciacionTipo))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Georeferenciacion", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("GeoreferenciacionTipo","GeoreferenciacionTipo_Nombre")
			}));
		}
	}
}
		