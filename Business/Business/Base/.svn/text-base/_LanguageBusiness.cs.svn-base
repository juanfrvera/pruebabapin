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
    public class _LanguageBusiness : EntityBusiness<Language,LanguageFilter,LanguageResult,int>
    {        
		protected readonly LanguageData Data = new LanguageData();
        protected override IEntityData<Language,LanguageFilter,LanguageResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Language() { IdLanguage = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Language entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");

				break;
            }
        }   
		
    }	
}
