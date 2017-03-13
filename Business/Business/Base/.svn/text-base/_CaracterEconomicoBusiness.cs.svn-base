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
    public class _CaracterEconomicoBusiness : EntityBusiness<CaracterEconomico,CaracterEconomicoFilter,CaracterEconomicoResult,int>
    {        
		protected readonly CaracterEconomicoData Data = new CaracterEconomicoData();
        protected override IEntityData<CaracterEconomico,CaracterEconomicoFilter,CaracterEconomicoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.CaracterEconomico() { IdCaracterEconomico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.CaracterEconomico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdCaracterEconomico != default(int),"InvalidField", "CaracterEconomico");
DataHelper.Validate(entity.IdCaracterEconomicoTipo != default(int),"InvalidField", "CaracterEconomicoTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 3,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdCaracterEconomicoTipo != default(int),"InvalidField", "CaracterEconomicoTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdCaracterEconomico != default(int),"InvalidField", "CaracterEconomico");
                DataHelper.ValidateForeignKey(entity.CaracterEconomicos.Any(), "El registro no se puede eliminar porque tiene al menos un sub caracter económico asociado", "CaracterEconomico");
				
                break;
            }
        }   
		
    }	
}
