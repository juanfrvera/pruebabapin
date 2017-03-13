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
    public class _PrestamoFinanciamientoBusiness : EntityBusiness<PrestamoFinanciamiento,PrestamoFinanciamientoFilter,PrestamoFinanciamientoResult,int>
    {        
		protected readonly PrestamoFinanciamientoData Data = new PrestamoFinanciamientoData();
        protected override IEntityData<PrestamoFinanciamiento,PrestamoFinanciamientoFilter,PrestamoFinanciamientoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoFinanciamiento() { IdPrestamoFinanciamiento = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoFinanciamiento entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoFinanciamiento != default(int),"InvalidField", "PrestamoFinanciamiento");
DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");

                  }				
				DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoFinanciamiento != default(int),"InvalidField", "PrestamoFinanciamiento");

				break;
            }
        }   
		
    }	
}
