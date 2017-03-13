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
    public class _PrestamoDesembolsoBusiness : EntityBusiness<PrestamoDesembolso,PrestamoDesembolsoFilter,PrestamoDesembolsoResult,int>
    {        
		protected readonly PrestamoDesembolsoData Data = new PrestamoDesembolsoData();
        protected override IEntityData<PrestamoDesembolso,PrestamoDesembolsoFilter,PrestamoDesembolsoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoDesembolso() { IdPrestamoDesembolso = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoDesembolso entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoDesembolso != default(int),"InvalidField", "PrestamoDesembolso");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoDesembolso != default(int),"InvalidField", "PrestamoDesembolso");

				break;
            }
        }   
		
    }	
}
