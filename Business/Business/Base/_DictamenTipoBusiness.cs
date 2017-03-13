using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _DictamenTipoBusiness : EntityBusiness<DictamenTipo,DictamenTipoFilter,DictamenTipoResult,int>
    {        
		protected readonly DictamenTipoData Data = new DictamenTipoData();
        protected override IEntityData<DictamenTipo,DictamenTipoFilter,DictamenTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		
		public override void Validate(nc.DictamenTipo entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdDictamenTipo != default(int),"InvalidFiled", "DictamenTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FiledInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdDictamenTipo != default(int),"InvalidFiled", "DictamenTipo");

				break;
            }
        }   
		
    }	
}
