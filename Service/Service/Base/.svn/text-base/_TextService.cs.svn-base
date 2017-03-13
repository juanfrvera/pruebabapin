using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _TextService : EntityService<nc.Text,nc.TextFilter,nc.TextResult,int>
    {        
		protected readonly TextBusiness Business = new TextBusiness();
        protected override IEntityBusiness<nc.Text,nc.TextFilter,nc.TextResult,int> EntityBusiness
        {
            get { return this.Business;}
        }
    }	
}
