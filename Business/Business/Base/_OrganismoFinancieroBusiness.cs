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
    public class _OrganismoFinancieroBusiness : EntityBusiness<OrganismoFinanciero,OrganismoFinancieroFilter,OrganismoFinancieroResult,int>
    {        
		protected readonly OrganismoFinancieroData Data = new OrganismoFinancieroData();
        protected override IEntityData<OrganismoFinanciero,OrganismoFinancieroFilter,OrganismoFinancieroResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.OrganismoFinanciero() { IdOrganismoFinanciero = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.OrganismoFinanciero entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 8,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");
                DataHelper.ValidateForeignKey(entity.ModalidadFinancieras.Any(), "El registro no se puede eliminar porque tiene al menos una modalidad financiera asociada", "OrganismoFinanciero");
                DataHelper.ValidateForeignKey(entity.PrestamoConvenios.Any(), "El registro no se puede eliminar porque tiene al menos un convenio de prestamo asociado", "OrganismoFinanciero");
               
				break;
            }
        }   
		
    }	
}
