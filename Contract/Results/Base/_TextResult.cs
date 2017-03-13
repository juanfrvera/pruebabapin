using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
namespace Contract.Base
{
	[Serializable]
    public abstract class _TextResult : IResult<int>
    {        
		public virtual int ID{get{return IdText;}}
		 public int IdText{get;set;}
		 public string Code{get;set;}
		 public string Description{get;set;}
		 public int IdTextCategory{get;set;}
		 public bool IsAutomaticLoad{get;set;}
		 public DateTime StartDate{get;set;}
		 public bool Checked{get;set;}
		 public DateTime? CheckedDate{get;set;}
		 public int? IdUsuarioChecked{get;set;}
		 
		 public string TextCategory_Name{get;set;}	
	public string TextCategory_Description{get;set;}	
	public string UsuarioChecked_NombreUsuario{get;set;}	
	public string UsuarioChecked_Clave{get;set;}	
	public bool? UsuarioChecked_Activo{get;set;}	
	public bool? UsuarioChecked_EsSectioralista{get;set;}	
	public int? UsuarioChecked_IdLanguage{get;set;}	
	public bool? UsuarioChecked_AccesoTotal{get;set;}	
					
		public virtual Text ToEntity()
		{
		   Text _Text = new Text();
		_Text.IdText = this.IdText;
		 _Text.Code = this.Code;
		 _Text.Description = this.Description;
		 _Text.IdTextCategory = this.IdTextCategory;
		 _Text.IsAutomaticLoad = this.IsAutomaticLoad;
		 _Text.StartDate = this.StartDate;
		 _Text.Checked = this.Checked;
		 _Text.CheckedDate = this.CheckedDate;
		 _Text.IdUsuarioChecked = this.IdUsuarioChecked;
		 
		  return _Text;
		}		
		public virtual void Set(Text entity)
		{		   
		 this.IdText= entity.IdText ;
		  this.Code= entity.Code ;
		  this.Description= entity.Description ;
		  this.IdTextCategory= entity.IdTextCategory ;
		  this.IsAutomaticLoad= entity.IsAutomaticLoad ;
		  this.StartDate= entity.StartDate ;
		  this.Checked= entity.Checked ;
		  this.CheckedDate= entity.CheckedDate ;
		  this.IdUsuarioChecked= entity.IdUsuarioChecked ;
		 		  
		}		
		public virtual bool Equals(Text entity)
        {
		   if(entity == null)return false;
         if(!entity.IdText.Equals(this.IdText))return false;
		  if(!entity.Code.Equals(this.Code))return false;
		  if((entity.Description == null)?this.Description!=null:!entity.Description.Equals(this.Description))return false;
			 if(!entity.IdTextCategory.Equals(this.IdTextCategory))return false;
		  if(!entity.IsAutomaticLoad.Equals(this.IsAutomaticLoad))return false;
		  if(!entity.StartDate.Equals(this.StartDate))return false;
		  if(!entity.Checked.Equals(this.Checked))return false;
		  if((entity.CheckedDate == null)?this.CheckedDate!=null:!entity.CheckedDate.Equals(this.CheckedDate))return false;
			 if((entity.IdUsuarioChecked == null)?(this.IdUsuarioChecked.HasValue && this.IdUsuarioChecked.Value > 0):!entity.IdUsuarioChecked.Equals(this.IdUsuarioChecked))return false;
						 
		  return true;
        }
		
		public virtual DataTableMapping ToMapping()
		{
		    return new DataTableMapping("Text", new List<DataColumnMapping>( new DataColumnMapping[]{
		new DataColumnMapping("Code","Code")
			,new DataColumnMapping("Description","Description")
			,new DataColumnMapping("TextCategory","TextCategory_Name")
			,new DataColumnMapping("IsAutomaticLoad","IsAutomaticLoad")
			,new DataColumnMapping("StartDate","StartDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("Checked","Checked")
			,new DataColumnMapping("CheckedDate","CheckedDate","{0:dd/MM/yyyy}")
			,new DataColumnMapping("UsuarioChecked","Usuario_NombreUsuario")
			}));
		}
	}
}
		