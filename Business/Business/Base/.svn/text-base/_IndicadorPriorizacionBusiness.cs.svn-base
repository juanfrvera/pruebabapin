using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _IndicadorPriorizacionBusiness : EntityBusiness<IndicadorPriorizacion,IndicadorPriorizacionFilter,IndicadorPriorizacionResult,int>
    {        
		protected readonly IndicadorPriorizacionData Data = new IndicadorPriorizacionData();
        protected override IEntityData<IndicadorPriorizacion,IndicadorPriorizacionFilter,IndicadorPriorizacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return Can(new nc.IndicadorPriorizacion() { IdIndicadorPriorizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorPriorizacion entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorPriorizacion != default(int),"InvalidFiled", "IndicadorPriorizacion");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FiledIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 8,"FiledInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FiledInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorPriorizacion != default(int),"InvalidFiled", "IndicadorPriorizacion");

				break;
            }
        }   
		
    }	
}
