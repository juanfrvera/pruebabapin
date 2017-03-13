using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _TextCategoryBusiness : EntityBusiness<TextCategory,TextCategoryFilter,TextCategoryResult,int>
    {        
		protected readonly TextCategoryData Data = new TextCategoryData();
        protected override IEntityData<TextCategory,TextCategoryFilter,TextCategoryResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.TextCategory() { IdTextCategory = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.TextCategory entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdTextCategory != default(int),"InvalidField", "TextCategory");

                  }				
				DataHelper.Validate(entity.Name!=null,"FieldIsNull","Name");
DataHelper.Validate(entity.Name.Trim().Length <= 70,"FieldInvalidLength","Name");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdTextCategory != default(int),"InvalidField", "TextCategory");
                DataHelper.ValidateForeignKey(entity.Texts.Any(), "El registro no se puede eliminar porque tiene al menos un texto asociado", "TextCategory");

				break;
            }
        }   
		
    }	
}
