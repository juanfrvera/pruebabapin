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
    public class _CaracterEconomicoTipoBusiness : EntityBusiness<CaracterEconomicoTipo,CaracterEconomicoTipoFilter,CaracterEconomicoTipoResult,int>
    {        
		protected readonly CaracterEconomicoTipoData Data = new CaracterEconomicoTipoData();
        protected override IEntityData<CaracterEconomicoTipo,CaracterEconomicoTipoFilter,CaracterEconomicoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.CaracterEconomicoTipo() { IdCaracterEconomicoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.CaracterEconomicoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdCaracterEconomicoTipo != default(int),"InvalidField", "CaracterEconomicoTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdCaracterEconomicoTipo != default(int),"InvalidField", "CaracterEconomicoTipo");
                DataHelper.ValidateForeignKey(entity.CaracterEconomicos.Any(), "El registro no se puede eliminar porque tiene al menos un caracter económico asociado", "CaracterEconomicoTipo");
				
				break;
            }
        }   
		
    }	
}
