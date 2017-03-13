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
    public class _UnidadMedidaBusiness : EntityBusiness<UnidadMedida,UnidadMedidaFilter,UnidadMedidaResult,int>
    {        
		protected readonly UnidadMedidaData Data = new UnidadMedidaData();
        protected override IEntityData<UnidadMedida,UnidadMedidaFilter,UnidadMedidaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.UnidadMedida() { IdUnidadMedida = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.UnidadMedida entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdUnidadMedida != default(int),"InvalidField", "UnidadMedida");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 10,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdUnidadMedida != default(int),"InvalidField", "UnidadMedida");

				break;
            }
        }   
		
    }	
}
