using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _IndicadorObjetivoBusiness : EntityBusiness<IndicadorObjetivo,IndicadorObjetivoFilter,IndicadorObjetivoResult,int>
    {        
		protected readonly IndicadorObjetivoData Data = new IndicadorObjetivoData();
        protected override IEntityData<IndicadorObjetivo,IndicadorObjetivoFilter,IndicadorObjetivoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, params string[] args)
        {
            return Can(new nc.IndicadorObjetivo() { IdIndicadorPriorizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorObjetivo entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorPriorizacion != default(int),"InvalidFiled", "IndicadorPriorizacion");
DataHelper.Validate(entity.IdUnidadMedida != default(int),"InvalidFiled", "UnidadMedida");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FiledIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 8,"FiledInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FiledIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FiledInvalidLength","Nombre");
DataHelper.Validate(entity.IdUnidadMedida != default(int),"InvalidFiled", "UnidadMedida");
DataHelper.Validate(entity.Funcion!=null,"FiledIsNull","Funcion");
DataHelper.Validate(entity.Funcion.Trim().Length <= 50,"FiledInvalidLength","Funcion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorPriorizacion != default(int),"InvalidFiled", "IndicadorPriorizacion");

				break;
            }
        }   
		
    }	
}
