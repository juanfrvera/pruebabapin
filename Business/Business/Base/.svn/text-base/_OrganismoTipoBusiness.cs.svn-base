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
    public class _OrganismoTipoBusiness : EntityBusiness<OrganismoTipo,OrganismoTipoFilter,OrganismoTipoResult,int>
    {        
		protected readonly OrganismoTipoData Data = new OrganismoTipoData();
        protected override IEntityData<OrganismoTipo,OrganismoTipoFilter,OrganismoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.OrganismoTipo() { IdOrganismoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.OrganismoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOrganismoTipo != default(int),"InvalidField", "OrganismoTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 25,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOrganismoTipo != default(int),"InvalidField", "OrganismoTipo");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un saf asociado", "OrganismoTipo");
               
				break;
            }
        }   
		
    }	
}
