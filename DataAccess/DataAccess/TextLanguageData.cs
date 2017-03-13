using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class TextLanguageData : _TextLanguageData 
    { 
	   #region Singleton
	   private static volatile TextLanguageData current;
	   private static object syncRoot = new Object();

	   //private TextLanguageData() {}
	   public static TextLanguageData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextLanguageData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdTextLanguage"; } }
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
                  //      ,UsuarioChecked_NombreCompleto = t3.NombreUsuario	
						}
                    ).AsQueryable();
        }
        #endregion
    }
}
