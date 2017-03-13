using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _IndicadorDetalleBusiness : EntityBusiness<IndicadorDetalle,IndicadorDetalleFilter,IndicadorDetalleResult,int>
    {        
		protected readonly IndicadorDetalleData Data = new IndicadorDetalleData();
        protected override IEntityData<IndicadorDetalle,IndicadorDetalleFilter,IndicadorDetalleResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return Can(new nc.IndicadorDetalle() { IdIndicadorDetalle = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorDetalle entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorDetalle != default(int),"InvalidFiled", "IndicadorDetalle");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorDetalle != default(int),"InvalidFiled", "IndicadorDetalle");

				break;
            }
        }   
		
    }	
}
