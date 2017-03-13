using System;
using System.Collections.Generic;
using System.Linq;
using System.Data.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using nd=DataAccess;

namespace DataAccess.Base
{
    public abstract class _TextLanguageData : EntityData<TextLanguage,TextLanguageFilter,TextLanguageResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.TextLanguage entity)
		{			
			return entity.IdTextLanguage;
		}		
		public override TextLanguage GetByEntity(TextLanguage entity)
        {
            return this.GetById(entity.IdTextLanguage);
        }
        public override TextLanguage GetById(int id)
        {
            return (from o in this.Table where o.IdTextLanguage == id select o).FirstOrDefault();
        }
		#endregion
		#region Query
		protected override IQueryable<TextLanguage> Query(TextLanguageFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdTextLanguage == null || o.IdTextLanguage >=  filter.IdTextLanguage) && (filter.IdTextLanguage_To == null || o.IdTextLanguage <= filter.IdTextLanguage_To)
					  && (filter.IdText == null || filter.IdText == 0 || o.IdText==filter.IdText)
					  && (filter.IdLanguage == null || filter.IdLanguage == 0 || o.IdLanguage==filter.IdLanguage)
					  && (filter.TranslateText == null || filter.TranslateText.Trim() == string.Empty || filter.TranslateText.Trim() == "%"  || (filter.TranslateText.EndsWith("%") && filter.TranslateText.StartsWith("%") && (o.TranslateText.Contains(filter.TranslateText.Replace("%", "")))) || (filter.TranslateText.EndsWith("%") && o.TranslateText.StartsWith(filter.TranslateText.Replace("%",""))) || (filter.TranslateText.StartsWith("%") && o.TranslateText.EndsWith(filter.TranslateText.Replace("%",""))) || o.TranslateText == filter.TranslateText )
					  && (filter.IsAutomaticLoad == null || o.IsAutomaticLoad==filter.IsAutomaticLoad)
					  && (filter.StartDate == null || filter.StartDate == DateTime.MinValue || o.StartDate >=  filter.StartDate) && (filter.StartDate_To == null || filter.StartDate_To == DateTime.MinValue || o.StartDate <= filter.StartDate_To)
					  && (filter.Checked == null || o.Checked==filter.Checked)
					  && (filter.CheckedDate == null || filter.CheckedDate == DateTime.MinValue || o.CheckedDate >=  filter.CheckedDate) && (filter.CheckedDate_To == null || filter.CheckedDate_To == DateTime.MinValue || o.CheckedDate <= filter.CheckedDate_To)
					  && (filter.CheckedDateIsNull == null || filter.CheckedDateIsNull == true || o.CheckedDate != null ) && (filter.CheckedDateIsNull == null || filter.CheckedDateIsNull == false || o.CheckedDate == null)
					  && (filter.IdUsuarioChecked == null || filter.IdUsuarioChecked == 0 || o.IdUsuarioChecked==filter.IdUsuarioChecked)
					  && (filter.IdUsuarioCheckedIsNull == null || filter.IdUsuarioCheckedIsNull == true || o.IdUsuarioChecked != null ) && (filter.IdUsuarioCheckedIsNull == null || filter.IdUsuarioCheckedIsNull == false || o.IdUsuarioChecked == null)
					  select o
                    ).AsQueryable();
        }	
        protected override IQueryable<TextLanguageResult> QueryResult(TextLanguageFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.Languages on o.IdLanguage equals t1.IdLanguage   
				    join t2  in this.Context.Texts on o.IdText equals t2.IdText   
				   join _t3  in this.Context.Usuarios on o.IdUsuarioChecked equals _t3.IdUsuario into tt3 from t3 in tt3.DefaultIfEmpty()
				   select new TextLanguageResult(){
					 IdTextLanguage=o.IdTextLanguage
					 ,IdText=o.IdText
					 ,IdLanguage=o.IdLanguage
					 ,TranslateText=o.TranslateText
					 ,IsAutomaticLoad=o.IsAutomaticLoad
					 ,StartDate=o.StartDate
					 ,Checked=o.Checked
					 ,CheckedDate=o.CheckedDate
					 ,IdUsuarioChecked=o.IdUsuarioChecked
					,Language_Name= t1.Name	
						,Language_Code= t1.Code	
						,Text_Code= t2.Code	
						,Text_Description= t2.Description	
						,Text_IdTextCategory= t2.IdTextCategory	
						,Text_IsAutomaticLoad= t2.IsAutomaticLoad	
						,Text_StartDate= t2.StartDate	
						,Text_Checked= t2.Checked	
						,Text_CheckedDate= t2.CheckedDate	
						,Text_IdUsuarioChecked= t2.IdUsuarioChecked	
						,UsuarioChecked_NombreUsuario= t3!=null?(string)t3.NombreUsuario:null	
						,UsuarioChecked_Clave= t3!=null?(string)t3.Clave:null	
						,UsuarioChecked_Activo= t3!=null?(bool?)t3.Activo:null	
						,UsuarioChecked_EsSectioralista= t3!=null?(bool?)t3.EsSectioralista:null	
						,UsuarioChecked_IdLanguage= t3!=null?(int?)t3.IdLanguage:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.TextLanguage Copy(nc.TextLanguage entity)
        {           
            nc.TextLanguage _new = new nc.TextLanguage();
		 _new.IdText= entity.IdText;
		 _new.IdLanguage= entity.IdLanguage;
		 _new.TranslateText= entity.TranslateText;
		 _new.IsAutomaticLoad= entity.IsAutomaticLoad;
		 _new.StartDate= entity.StartDate;
		 _new.Checked= entity.Checked;
		 _new.CheckedDate= entity.CheckedDate;
		 _new.IdUsuarioChecked= entity.IdUsuarioChecked;
		return _new;			
        }
		#endregion
		#region Set
		public override void SetId(TextLanguage entity, int id)
        {            
            entity.IdTextLanguage = id;            
        }
		public override void Set(TextLanguage source,TextLanguage target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextLanguage= source.IdTextLanguage ;
		 target.IdText= source.IdText ;
		 target.IdLanguage= source.IdLanguage ;
		 target.TranslateText= source.TranslateText ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 		  
		}
		public override void Set(TextLanguageResult source,TextLanguage target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextLanguage= source.IdTextLanguage ;
		 target.IdText= source.IdText ;
		 target.IdLanguage= source.IdLanguage ;
		 target.TranslateText= source.TranslateText ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 
		}
		public override void Set(TextLanguage source,TextLanguageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextLanguage= source.IdTextLanguage ;
		 target.IdText= source.IdText ;
		 target.IdLanguage= source.IdLanguage ;
		 target.TranslateText= source.TranslateText ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 	
		}		
		public override void Set(TextLanguageResult source,TextLanguageResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdTextLanguage= source.IdTextLanguage ;
		 target.IdText= source.IdText ;
		 target.IdLanguage= source.IdLanguage ;
		 target.TranslateText= source.TranslateText ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 target.Language_Name= source.Language_Name;	
			target.Language_Code= source.Language_Code;	
			target.Text_Code= source.Text_Code;	
			target.Text_Description= source.Text_Description;	
			target.Text_IdTextCategory= source.Text_IdTextCategory;	
			target.Text_IsAutomaticLoad= source.Text_IsAutomaticLoad;	
			target.Text_StartDate= source.Text_StartDate;	
			target.Text_Checked= source.Text_Checked;	
			target.Text_CheckedDate= source.Text_CheckedDate;	
			target.Text_IdUsuarioChecked= source.Text_IdUsuarioChecked;	
			target.UsuarioChecked_NombreUsuario= source.UsuarioChecked_NombreUsuario;	
			target.UsuarioChecked_Clave= source.UsuarioChecked_Clave;	
			target.UsuarioChecked_Activo= source.UsuarioChecked_Activo;	
			target.UsuarioChecked_EsSectioralista= source.UsuarioChecked_EsSectioralista;	
			target.UsuarioChecked_IdLanguage= source.UsuarioChecked_IdLanguage;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(TextLanguage source,TextLanguage target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTextLanguage.Equals(target.IdTextLanguage))return false;
		  if(!source.IdText.Equals(target.IdText))return false;
		  if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if(!source.TranslateText.Equals(target.TranslateText))return false;
		  if(!source.IsAutomaticLoad.Equals(target.IsAutomaticLoad))return false;
		  if(!source.StartDate.Equals(target.StartDate))return false;
		  if(!source.Checked.Equals(target.Checked))return false;
		  if((source.CheckedDate == null)?target.CheckedDate!=null:!source.CheckedDate.Equals(target.CheckedDate))return false;
			 if((source.IdUsuarioChecked == null)?(target.IdUsuarioChecked.HasValue && target.IdUsuarioChecked.Value > 0):!source.IdUsuarioChecked.Equals(target.IdUsuarioChecked))return false;
						 
		  return true;
        }
		public override bool Equals(TextLanguageResult source,TextLanguageResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdTextLanguage.Equals(target.IdTextLanguage))return false;
		  if(!source.IdText.Equals(target.IdText))return false;
		  if(!source.IdLanguage.Equals(target.IdLanguage))return false;
		  if(!source.TranslateText.Equals(target.TranslateText))return false;
		  if(!source.IsAutomaticLoad.Equals(target.IsAutomaticLoad))return false;
		  if(!source.StartDate.Equals(target.StartDate))return false;
		  if(!source.Checked.Equals(target.Checked))return false;
		  if((source.CheckedDate == null)?target.CheckedDate!=null:!source.CheckedDate.Equals(target.CheckedDate))return false;
			 if((source.IdUsuarioChecked == null)?(target.IdUsuarioChecked.HasValue && target.IdUsuarioChecked.Value > 0):!source.IdUsuarioChecked.Equals(target.IdUsuarioChecked))return false;
						  if(!source.Language_Name.Equals(target.Language_Name))return false;
					  if(!source.Language_Code.Equals(target.Language_Code))return false;
					  if(!source.Text_Code.Equals(target.Text_Code))return false;
					  if(!source.Text_Description.Equals(target.Text_Description))return false;
					  if(!source.Text_IdTextCategory.Equals(target.Text_IdTextCategory))return false;
					  if(!source.Text_IsAutomaticLoad.Equals(target.Text_IsAutomaticLoad))return false;
					  if(!source.Text_StartDate.Equals(target.Text_StartDate))return false;
					  if(!source.Text_Checked.Equals(target.Text_Checked))return false;
					  if((source.Text_CheckedDate == null)?target.Text_CheckedDate!=null:!source.Text_CheckedDate.Equals(target.Text_CheckedDate))return false;
						 if((source.Text_IdUsuarioChecked == null)?(target.Text_IdUsuarioChecked.HasValue && target.Text_IdUsuarioChecked.Value > 0):!source.Text_IdUsuarioChecked.Equals(target.Text_IdUsuarioChecked))return false;
									  if(!source.UsuarioChecked_NombreUsuario.Equals(target.UsuarioChecked_NombreUsuario))return false;
					  if(!source.UsuarioChecked_Clave.Equals(target.UsuarioChecked_Clave))return false;
					  if(!source.UsuarioChecked_Activo.Equals(target.UsuarioChecked_Activo))return false;
					  if(!source.UsuarioChecked_EsSectioralista.Equals(target.UsuarioChecked_EsSectioralista))return false;
					  if(!source.UsuarioChecked_IdLanguage.Equals(target.UsuarioChecked_IdLanguage))return false;
					 		
		  return true;
        }
		#endregion
    }
}
