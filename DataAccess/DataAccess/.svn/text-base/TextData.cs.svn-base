using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess.Base;

namespace DataAccess
{
    public class TextData : _TextData 
    { 
	   #region Singleton
	   private static volatile TextData current;
	   private static object syncRoot = new Object();

	   //private TextData() {}
	   public static TextData Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new TextData();
				}
			 }
			 return current;
		  }
	   }
       #endregion
       public override string IdFieldName { get { return "IdText"; } }
       public override ListPaged<SimpleResult<int>> GetSimpleList(TextFilter filter)
       {
           return ListPaged<SimpleResult<int>>((from o in QueryResult(filter) select new SimpleResult<int> { ID = o.IdText, Text = o.Code }).AsQueryable(), filter);
       }
        #region Query
		protected override IQueryable<Text> Query(TextFilter filter)
        {
			return (from o in this.Table
                      where (filter.IdText == null || filter.IdText == 0 || o.IdText==filter.IdText)
					  && (filter.Code == null || filter.Code.Trim() == string.Empty || filter.Code.Trim() == "%"  || (filter.Code.EndsWith("%") && filter.Code.StartsWith("%") && (o.Code.Contains(filter.Code.Replace("%", "")))) || (filter.Code.EndsWith("%") && o.Code.StartsWith(filter.Code.Replace("%",""))) || (filter.Code.StartsWith("%") && o.Code.EndsWith(filter.Code.Replace("%",""))) || o.Code == filter.Code )
					  && (filter.Description == null || filter.Description.Trim() == string.Empty || filter.Description.Trim() == "%"  || (filter.Description.EndsWith("%") && filter.Description.StartsWith("%") && (o.Description.Contains(filter.Description.Replace("%", "")))) || (filter.Description.EndsWith("%") && o.Description.StartsWith(filter.Description.Replace("%",""))) || (filter.Description.StartsWith("%") && o.Description.EndsWith(filter.Description.Replace("%",""))) || o.Description == filter.Description )
					  && (filter.IdTextCategory == null || filter.IdTextCategory == 0 || o.IdTextCategory==filter.IdTextCategory)
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
        protected override IQueryable<TextResult> QueryResult(TextFilter filter)
        {
		  return (from o in Query(filter)					
					 join t1  in this.Context.TextCategories on o.IdTextCategory equals t1.IdTextCategory   
				   join _t2  in this.Context.Usuarios on o.IdUsuarioChecked equals _t2.IdUsuario into tt2 from t2 in tt2.DefaultIfEmpty()
				   select new TextResult(){
					 IdText=o.IdText
					 ,Code=o.Code
					 ,Description=o.Description
					 ,IdTextCategory=o.IdTextCategory
					 ,IsAutomaticLoad=o.IsAutomaticLoad
					 ,StartDate=o.StartDate
					 ,Checked=o.Checked
					 ,CheckedDate=o.CheckedDate
					 ,IdUsuarioChecked=o.IdUsuarioChecked
					,TextCategory_Name= t1.Name	
						,TextCategory_Description= t1.Description	
						,UsuarioChecked_NombreUsuario= t2!=null?(string)t2.NombreUsuario:null	
						,UsuarioChecked_Clave= t2!=null?(string)t2.Clave:null	
						,UsuarioChecked_Activo= t2!=null?(bool?)t2.Activo:null	
						,UsuarioChecked_EsSectioralista= t2!=null?(bool?)t2.EsSectioralista:null	
						,UsuarioChecked_IdLanguage= t2!=null?(int?)t2.IdLanguage:null	
						}
                    ).AsQueryable();
        }
		#endregion
    }
}
