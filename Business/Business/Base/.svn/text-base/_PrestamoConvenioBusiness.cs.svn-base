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
    public class _PrestamoConvenioBusiness : EntityBusiness<PrestamoConvenio,PrestamoConvenioFilter,PrestamoConvenioResult,int>
    {        
		protected readonly PrestamoConvenioData Data = new PrestamoConvenioData();
        protected override IEntityData<PrestamoConvenio,PrestamoConvenioFilter,PrestamoConvenioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoConvenio() { IdPrestamoConvenio = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoConvenio entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoConvenio != default(int),"InvalidField", "PrestamoConvenio");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdOrganismoFinanciero != default(int),"InvalidField", "OrganismoFinanciero");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoConvenio != default(int),"InvalidField", "PrestamoConvenio");

				break;
            }
        }   
		
    }	
}
