using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _LanguageService : EntityService<nc.Language,nc.LanguageFilter,nc.LanguageResult,int>
    {        
		protected readonly LanguageBusiness Business = new LanguageBusiness();
        protected override IEntityBusiness<nc.Language,nc.LanguageFilter,nc.LanguageResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
