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
    public abstract class _TextData : EntityData<Text,TextFilter,TextResult,int>
    { 		
		#region Context        
        public  DataClassesDataContext Context
        {
            get { return LinqUtility.Context;}
        }
        #endregion		
		#region Get
		public override int GetId(nc.Text entity)
		{			
			return entity.IdText;
		}		
		public override Text GetByEntity(Text entity)
        {
            return this.GetById(entity.IdText);
        }
        public override Text GetById(int id)
        {
            return (from o in this.Table where o.IdText == id select o).FirstOrDefault();
        }
		#endregion
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
						,UsuarioChecked_AccesoTotal= t2!=null?(bool?)t2.AccesoTotal:null	
						}
                    ).AsQueryable();
        }
		#endregion
		#region Copy
		public override nc.Text Copy(nc.Text entity)
        {           
            nc.Text _new = new nc.Text();
		 _new.Code= entity.Code;
		 _new.Description= entity.Description;
		 _new.IdTextCategory= entity.IdTextCategory;
		 _new.IsAutomaticLoad= entity.IsAutomaticLoad;
		 _new.StartDate= entity.StartDate;
		 _new.Checked= entity.Checked;
		 _new.CheckedDate= entity.CheckedDate;
		 _new.IdUsuarioChecked= entity.IdUsuarioChecked;
		return _new;			
        }
		public override int CopyAndSave(Text entity,string renameFormat)
        {
            Text  newEntity = Copy(entity);
            newEntity.Code = string.Format(renameFormat,newEntity.Code);
            Add(newEntity);
			return GetId(newEntity);
        }
		#endregion
		#region Set
		public override void SetId(Text entity, int id)
        {            
            entity.IdText = id;            
        }
		public override void Set(Text source,Text target,bool hadSetId)
		{		   
		if(hadSetId)target.IdText= source.IdText ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdTextCategory= source.IdTextCategory ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 		  
		}
		public override void Set(TextResult source,Text target,bool hadSetId)
		{		   
		if(hadSetId)target.IdText= source.IdText ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdTextCategory= source.IdTextCategory ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 
		}
		public override void Set(Text source,TextResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdText= source.IdText ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdTextCategory= source.IdTextCategory ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 	
		}		
		public override void Set(TextResult source,TextResult target,bool hadSetId)
		{		   
		if(hadSetId)target.IdText= source.IdText ;
		 target.Code= source.Code ;
		 target.Description= source.Description ;
		 target.IdTextCategory= source.IdTextCategory ;
		 target.IsAutomaticLoad= source.IsAutomaticLoad ;
		 target.StartDate= source.StartDate ;
		 target.Checked= source.Checked ;
		 target.CheckedDate= source.CheckedDate ;
		 target.IdUsuarioChecked= source.IdUsuarioChecked ;
		 target.TextCategory_Name= source.TextCategory_Name;	
			target.TextCategory_Description= source.TextCategory_Description;	
			target.UsuarioChecked_NombreUsuario= source.UsuarioChecked_NombreUsuario;	
			target.UsuarioChecked_Clave= source.UsuarioChecked_Clave;	
			target.UsuarioChecked_Activo= source.UsuarioChecked_Activo;	
			target.UsuarioChecked_EsSectioralista= source.UsuarioChecked_EsSectioralista;	
			target.UsuarioChecked_IdLanguage= source.UsuarioChecked_IdLanguage;	
			target.UsuarioChecked_AccesoTotal= source.UsuarioChecked_AccesoTotal;	
					
		}
		#endregion			
		#region Equals
		public override bool Equals(Text source,Text target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdText.Equals(target.IdText))return false;
		  if((source.Code == null)?target.Code!=null:  !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) &&  !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null:  !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) &&  !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdTextCategory.Equals(target.IdTextCategory))return false;
		  if(!source.IsAutomaticLoad.Equals(target.IsAutomaticLoad))return false;
		  if(!source.StartDate.Equals(target.StartDate))return false;
		  if(!source.Checked.Equals(target.Checked))return false;
		  if((source.CheckedDate == null)?(target.CheckedDate.HasValue):!source.CheckedDate.Equals(target.CheckedDate))return false;
			 if((source.IdUsuarioChecked == null)?(target.IdUsuarioChecked.HasValue && target.IdUsuarioChecked.Value > 0):!source.IdUsuarioChecked.Equals(target.IdUsuarioChecked))return false;
						 
		  return true;
        }
		public override bool Equals(TextResult source,TextResult target)
        {
		   if(source == null && target == null)return true;
		   if(source == null )return false;
		   if(target == null)return false;
         if(!source.IdText.Equals(target.IdText))return false;
		  if((source.Code == null)?target.Code!=null: !( (target.Code== String.Empty && source.Code== null) || (target.Code==null && source.Code== String.Empty )) && !source.Code.Trim().Replace ("\r","").Equals(target.Code.Trim().Replace ("\r","")))return false;
			 if((source.Description == null)?target.Description!=null: !( (target.Description== String.Empty && source.Description== null) || (target.Description==null && source.Description== String.Empty )) && !source.Description.Trim().Replace ("\r","").Equals(target.Description.Trim().Replace ("\r","")))return false;
			 if(!source.IdTextCategory.Equals(target.IdTextCategory))return false;
		  if(!source.IsAutomaticLoad.Equals(target.IsAutomaticLoad))return false;
		  if(!source.StartDate.Equals(target.StartDate))return false;
		  if(!source.Checked.Equals(target.Checked))return false;
		  if((source.CheckedDate == null)?(target.CheckedDate.HasValue):!source.CheckedDate.Equals(target.CheckedDate))return false;
			 if((source.IdUsuarioChecked == null)?(target.IdUsuarioChecked.HasValue && target.IdUsuarioChecked.Value > 0):!source.IdUsuarioChecked.Equals(target.IdUsuarioChecked))return false;
						  if((source.TextCategory_Name == null)?target.TextCategory_Name!=null: !( (target.TextCategory_Name== String.Empty && source.TextCategory_Name== null) || (target.TextCategory_Name==null && source.TextCategory_Name== String.Empty )) &&   !source.TextCategory_Name.Trim().Replace ("\r","").Equals(target.TextCategory_Name.Trim().Replace ("\r","")))return false;
						 if((source.TextCategory_Description == null)?target.TextCategory_Description!=null: !( (target.TextCategory_Description== String.Empty && source.TextCategory_Description== null) || (target.TextCategory_Description==null && source.TextCategory_Description== String.Empty )) &&   !source.TextCategory_Description.Trim().Replace ("\r","").Equals(target.TextCategory_Description.Trim().Replace ("\r","")))return false;
						 if((source.UsuarioChecked_NombreUsuario == null)?target.UsuarioChecked_NombreUsuario!=null: !( (target.UsuarioChecked_NombreUsuario== String.Empty && source.UsuarioChecked_NombreUsuario== null) || (target.UsuarioChecked_NombreUsuario==null && source.UsuarioChecked_NombreUsuario== String.Empty )) &&   !source.UsuarioChecked_NombreUsuario.Trim().Replace ("\r","").Equals(target.UsuarioChecked_NombreUsuario.Trim().Replace ("\r","")))return false;
						 if((source.UsuarioChecked_Clave == null)?target.UsuarioChecked_Clave!=null: !( (target.UsuarioChecked_Clave== String.Empty && source.UsuarioChecked_Clave== null) || (target.UsuarioChecked_Clave==null && source.UsuarioChecked_Clave== String.Empty )) &&   !source.UsuarioChecked_Clave.Trim().Replace ("\r","").Equals(target.UsuarioChecked_Clave.Trim().Replace ("\r","")))return false;
						 if(!source.UsuarioChecked_Activo.Equals(target.UsuarioChecked_Activo))return false;
					  if(!source.UsuarioChecked_EsSectioralista.Equals(target.UsuarioChecked_EsSectioralista))return false;
					  if(!source.UsuarioChecked_IdLanguage.Equals(target.UsuarioChecked_IdLanguage))return false;
					  if(!source.UsuarioChecked_AccesoTotal.Equals(target.UsuarioChecked_AccesoTotal))return false;
					 		
		  return true;
        }
		#endregion
    }
}
