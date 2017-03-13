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
    public class _ObjetivoIndicadorBusiness : EntityBusiness<ObjetivoIndicador,ObjetivoIndicadorFilter,ObjetivoIndicadorResult,int>
    {        
		protected readonly ObjetivoIndicadorData Data = new ObjetivoIndicadorData();
        protected override IEntityData<ObjetivoIndicador,ObjetivoIndicadorFilter,ObjetivoIndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ObjetivoIndicador() { IdObjetivoIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ObjetivoIndicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdObjetivoIndicador != default(int),"InvalidField", "ObjetivoIndicador");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                  }				
				DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdObjetivoIndicador != default(int),"InvalidField", "ObjetivoIndicador");

				break;
            }
        }   
		
    }	
}
