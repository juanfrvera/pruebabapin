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
    public class _OrganismoBusiness : EntityBusiness<Organismo,OrganismoFilter,OrganismoResult,int>
    {        
		protected readonly OrganismoData Data = new OrganismoData();
        protected override IEntityData<Organismo,OrganismoFilter,OrganismoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Organismo() { IdOrganismo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Organismo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOrganismo != default(int),"InvalidField", "Organismo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 255,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOrganismo != default(int),"InvalidField", "Organismo");

				break;
            }
        }   
		
    }	
}
