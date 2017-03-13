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
    public class _ModalidadFinancieraBusiness : EntityBusiness<ModalidadFinanciera,ModalidadFinancieraFilter,ModalidadFinancieraResult,int>
    {        
		protected readonly ModalidadFinancieraData Data = new ModalidadFinancieraData();
        protected override IEntityData<ModalidadFinanciera,ModalidadFinancieraFilter,ModalidadFinancieraResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ModalidadFinanciera() { IdModalidadFinanciera = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ModalidadFinanciera entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdModalidadFinanciera != default(int),"InvalidField", "ModalidadFinanciera");
DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");

                  }				
				DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");
DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 8,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdModalidadFinanciera != default(int),"InvalidField", "ModalidadFinanciera");
                    
				break;
            }
        }   
		
    }	
}
