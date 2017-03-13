using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _DictamenBusiness : EntityBusiness<Dictamen,DictamenFilter,DictamenResult,int>
    {        
		protected readonly DictamenData Data = new DictamenData();
        protected override IEntityData<Dictamen,DictamenFilter,DictamenResult,int> EntityData
        {
            get { return this.Data;}
        }
		
		public override void Validate(nc.Dictamen entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdDictamen != default(int),"InvalidFiled", "Dictamen");
DataHelper.Validate(entity.IdDictamenTipo != default(int),"InvalidFiled", "DictamenTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FiledInvalidLength","Nombre");
DataHelper.Validate(entity.IdDictamenTipo != default(int),"InvalidFiled", "DictamenTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdDictamen != default(int),"InvalidFiled", "Dictamen");

				break;
            }
        }   
		
    }	
}
