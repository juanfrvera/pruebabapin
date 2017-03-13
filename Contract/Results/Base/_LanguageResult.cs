using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _LanguageResult : IResult<int>
    {        
		public virtual int ID{get{return IdLanguage;}}
		 public int IdLanguage{get;set;}
		 public string Name{get;set;}
		 public string Code{get;set;}
		 
		 				
		public virtual Language ToEntity()
		{
		   Language _Language = new Language();
		_Language.IdLanguage = this.IdLanguage;
		 _Language.Name = this.Name;
		 _Language.Code = this.Code;
		 
		  return _Language;
		}		
		public virtual void Set(Language entity)
		{		   
		 this.IdLanguage= entity.IdLanguage ;
		  this.Name= entity.Name ;
		  this.Code= entity.Code ;
		 		  
		}		
		public virtual bool Equals(Language entity)
        {
		   if(entity == null)return false;
         if(!entity.IdLanguage.Equals(this.IdLanguage))return false;
		  if((entity.Name == null)?this.Name!=null:!entity.Name.Equals(this.Name))return false;
			 if((entity.Code == null)?this.Code!=null:!entity.Code.Equals(this.Code))return false;
			
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Language", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Name","Name")
			,new DataColumnMapping("Code","Code")
			}));
		}
	}
}
		