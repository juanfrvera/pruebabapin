using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TextLanguageResult : IResult<int>
    {        
		public virtual int ID{get{return IdTextLanguage;}}
		 public int IdTextLanguage{get;set;}
		 public int IdText{get;set;}
		 public int IdLanguage{get;set;}
		 public string TranslateText{get;set;}
		 public bool IsAutomaticLoad{get;set;}
		 public DateTime StartDate{get;set;}
		 public bool Checked{get;set;}
		 public DateTime? CheckedDate{get;set;}
		 public int? IdUsuarioChecked{get;set;}
		 
		 public string Language_Name{get;set;}	
	public string Language_Code{get;set;}	
	public string Text_Code{get;set;}	
	public string Text_Description{get;set;}	
	public int Text_IdTextCategory{get;set;}	
	public bool Text_IsAutomaticLoad{get;set;}	
	public DateTime Text_StartDate{get;set;}	
	public bool Text_Checked{get;set;}	
	public DateTime? Text_CheckedDate{get;set;}	
	public int? Text_IdUsuarioChecked{get;set;}	
	public string UsuarioChecked_NombreUsuario{get;set;}	
	public string UsuarioChecked_Clave{get;set;}	
	public bool? UsuarioChecked_Activo{get;set;}	
	public bool? UsuarioChecked_EsSectioralista{get;set;}	
	public int? UsuarioChecked_IdLanguage{get;set;}	
					
		public virtual TextLanguage ToEntity()
		{
		   TextLanguage _TextLanguage = new TextLanguage();
		_TextLanguage.IdTextLanguage = this.IdTextLanguage;
		 _TextLanguage.IdText = this.IdText;
		 _TextLanguage.IdLanguage = this.IdLanguage;
		 _TextLanguage.TranslateText = this.TranslateText;
		 _TextLanguage.IsAutomaticLoad = this.IsAutomaticLoad;
		 _TextLanguage.StartDate = this.StartDate;
		 _TextLanguage.Checked = this.Checked;
		 _TextLanguage.CheckedDate = this.CheckedDate;
		 _TextLanguage.IdUsuarioChecked = this.IdUsuarioChecked;
		 
		  return _TextLanguage;
		}		
		public virtual void Set(TextLanguage entity)
		{		   
		 this.IdTextLanguage= entity.IdTextLanguage ;
		  this.IdText= entity.IdText ;
		  this.IdLanguage= entity.IdLanguage ;
		  this.TranslateText= entity.TranslateText ;
		  this.IsAutomaticLoad= entity.IsAutomaticLoad ;
		  this.StartDate= entity.StartDate ;
		  this.Checked= entity.Checked ;
		  this.CheckedDate= entity.CheckedDate ;
		  this.IdUsuarioChecked= entity.IdUsuarioChecked ;
		 		  
		}		
		public virtual bool Equals(TextLanguage entity)
        {
		   if(entity == null)return false;
         if(!entity.IdTextLanguage.Equals(this.IdTextLanguage))return false;
		  if(!entity.IdText.Equals(this.IdText))return false;
		  if(!entity.IdLanguage.Equals(this.IdLanguage))return false;
		  if(!entity.TranslateText.Equals(this.TranslateText))return false;
		  if(!entity.IsAutomaticLoad.Equals(this.IsAutomaticLoad))return false;
		  if(!entity.StartDate.Equals(this.StartDate))return false;
		  if(!entity.Checked.Equals(this.Checked))return false;
		  if((entity.CheckedDate == null)?this.CheckedDate!=null:!entity.CheckedDate.Equals(this.CheckedDate))return false;
			 if((entity.IdUsuarioChecked == null)?(this.IdUsuarioChecked.HasValue && this.IdUsuarioChecked.Value > 0):!entity.IdUsuarioChecked.Equals(this.IdUsuarioChecked))return false;
						 
		  return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
	}
}
		