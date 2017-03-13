using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _SubProcesoBusiness : EntityBusiness<SubProceso,SubProcesoFilter,SubProcesoResult,int>
    {        
		protected readonly SubProcesoData Data = new SubProcesoData();
        protected override IEntityData<SubProceso,SubProcesoFilter,SubProcesoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return Can(new nc.SubProceso() { IdSubProceso = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SubProceso entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSubProceso != default(int),"InvalidFiled", "SubProceso");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FiledIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 1,"FiledInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FiledInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSubProceso != default(int),"InvalidFiled", "SubProceso");

				break;
            }
        }   
		
    }	
}
