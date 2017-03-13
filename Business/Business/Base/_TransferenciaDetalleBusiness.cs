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
    public class _TransferenciaDetalleBusiness : EntityBusiness<TransferenciaDetalle,TransferenciaDetalleFilter,TransferenciaDetalleResult,int>
    {        
		protected readonly TransferenciaDetalleData Data = new TransferenciaDetalleData();
        protected override IEntityData<TransferenciaDetalle,TransferenciaDetalleFilter,TransferenciaDetalleResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.TransferenciaDetalle() { IdTransferenciaDetalle = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.TransferenciaDetalle entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdTransferenciaDetalle != default(int),"InvalidField", "TransferenciaDetalle");
DataHelper.Validate(entity.IdTransferencia != default(int),"InvalidField", "Transferencia");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");
DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");

                  }				
				DataHelper.Validate(entity.IdTransferencia != default(int),"InvalidField", "Transferencia");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");
DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdTransferenciaDetalle != default(int),"InvalidField", "TransferenciaDetalle");

				break;
            }
        }   
		
    }	
}
