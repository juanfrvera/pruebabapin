using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;
using System.Collections;

namespace Business.Base
{
    public class _TextLanguageBusiness : EntityBusiness<TextLanguage,TextLanguageFilter,TextLanguageResult,int>
    {        
		protected readonly TextLanguageData Data = new TextLanguageData();
        protected override IEntityData<TextLanguage,TextLanguageFilter,TextLanguageResult,int> EntityData
        {
            get { return this.Data;}
        }
        public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.TextLanguage() { IdTextLanguage = id }, actionName, contextUser, args);
        }
        public override void Validate(nc.TextLanguage entity, string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdTextLanguage != default(int),"InvalidField", "TextLanguage");
DataHelper.Validate(entity.IdText != default(int),"InvalidField", "Text");
DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");

                  }				
				DataHelper.Validate(entity.IdText != default(int),"InvalidField", "Text");
DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");
DataHelper.Validate(entity.TranslateText!=null,"FiledIsNull","TranslateText");
DataHelper.Validate(entity.TranslateText.Trim().Length <= 2147483647,"FiledInvalidLength","TranslateText");
DataHelper.Validate(entity.StartDate > new DateTime(1900,1,1) ,"InvalidField", "StartDate");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdTextLanguage != default(int),"InvalidField", "TextLanguage");
                DataHelper.ValidateForeignKey(entity.TranslateText.Any(), "El registro no se puede eliminar porque tiene al menos una traduccion asociada", "TextLanguage");

				break;
            }
        }   
		
    }	
}
