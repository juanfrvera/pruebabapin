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
    public class _IndicadorMedioVerificacionBusiness : EntityBusiness<IndicadorMedioVerificacion,IndicadorMedioVerificacionFilter,IndicadorMedioVerificacionResult,int>
    {        
		protected readonly IndicadorMedioVerificacionData Data = new IndicadorMedioVerificacionData();
        protected override IEntityData<IndicadorMedioVerificacion,IndicadorMedioVerificacionFilter,IndicadorMedioVerificacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorMedioVerificacion() { IdIndicadorMedioVerificacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorMedioVerificacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorMedioVerificacion != default(int),"InvalidField", "IndicadorMedioVerificacion");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");
DataHelper.Validate(entity.IdMedioVerificacion != default(int),"InvalidField", "MedioVerificacion");

                  }				
				DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");
DataHelper.Validate(entity.IdMedioVerificacion != default(int),"InvalidField", "MedioVerificacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorMedioVerificacion != default(int),"InvalidField", "IndicadorMedioVerificacion");

				break;
            }
        }   
		
    }	
}
