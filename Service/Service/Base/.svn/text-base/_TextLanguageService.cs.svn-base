using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _TextLanguageService : EntityService<nc.TextLanguage,nc.TextLanguageFilter,nc.TextLanguageResult,int>
    {        
		protected readonly TextLanguageBusiness Business = new TextLanguageBusiness();
        protected override IEntityBusiness<nc.TextLanguage,nc.TextLanguageFilter,nc.TextLanguageResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
