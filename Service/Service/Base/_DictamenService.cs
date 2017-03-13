using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using nc=Contract;
using Business;

namespace Service.Base
{
    public class _DictamenService : EntityService<nc.Dictamen,nc.DictamenFilter,nc.DictamenResult,int>
    {        
		protected readonly DictamenBusiness Business = new DictamenBusiness();
        protected override IEntityBusiness<nc.Dictamen,nc.DictamenFilter,nc.DictamenResult,int> EntityBusiness
        {
            get { return this.Business;}
        }		
		public override string ServiceName{get { return "DictamenService"; }}
    }	
}
