using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _NumerationResult : IResult<int>
    {        
		public virtual int ID{get{return IdNumeration;}}
		 public int IdNumeration{get;set;}
		 public string Code{get;set;}
		 public int Lastvalue{get;set;}
		 
		 				
		public virtual Numeration ToEntity()
		{
		   Numeration _Numeration = new Numeration();
		_Numeration.IdNumeration = this.IdNumeration;
		 _Numeration.Code = this.Code;
		 _Numeration.Lastvalue = this.Lastvalue;
		 
		  return _Numeration;
		}		
		public virtual void Set(Numeration entity)
		{		   
		 this.IdNumeration= entity.IdNumeration ;
		  this.Code= entity.Code ;
		  this.Lastvalue= entity.Lastvalue ;
		 		  
		}		
		public virtual bool Equals(Numeration entity)
        {
		   if(entity == null)return false;
         if(!entity.IdNumeration.Equals(this.IdNumeration))return false;
		  if((entity.Code == null)?this.Code!=null:!entity.Code.Equals(this.Code))return false;
			 if(!entity.Lastvalue.Equals(this.Lastvalue))return false;
		 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Numeration", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Code","Code")
			,new DataColumnMapping("Lastvalue","Lastvalue")
			}));
		}
	}
}
		