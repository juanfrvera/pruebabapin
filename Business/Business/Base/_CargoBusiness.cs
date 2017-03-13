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
    public class _CargoBusiness : EntityBusiness<Cargo,CargoFilter,CargoResult,int>
    {        
		protected readonly CargoData Data = new CargoData();
        protected override IEntityData<Cargo,CargoFilter,CargoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Cargo() { IdCargo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Cargo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdCargo != default(int),"InvalidField", "Cargo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 70,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 5,"FieldInvalidLength","Codigo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdCargo != default(int),"InvalidField", "Cargo");
                DataHelper.ValidateForeignKey(entity.Personas.Any(), "El registro no se puede eliminar porque tiene al menos una persona asociada", "Cargo");
				
				break;
            }
        }   
		
    }	
}
