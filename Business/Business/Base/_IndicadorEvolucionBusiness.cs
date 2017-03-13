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
    public class _IndicadorEvolucionBusiness : EntityBusiness<IndicadorEvolucion,IndicadorEvolucionFilter,IndicadorEvolucionResult,int>
    {        
		protected readonly IndicadorEvolucionData Data = new IndicadorEvolucionData();
        protected override IEntityData<IndicadorEvolucion,IndicadorEvolucionFilter,IndicadorEvolucionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorEvolucion() { IdIndicadorEvolucion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorEvolucion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorEvolucion != default(int),"InvalidField", "IndicadorEvolucion");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");
DataHelper.Validate(entity.IdIndicadorEvolucionInstancia != default(int),"InvalidField", "IndicadorEvolucionInstancia");

                  }				
				DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");
DataHelper.Validate(entity.IdIndicadorEvolucionInstancia != default(int),"InvalidField", "IndicadorEvolucionInstancia");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorEvolucion != default(int),"InvalidField", "IndicadorEvolucion");

				break;
            }
        }   
		
    }	
}
