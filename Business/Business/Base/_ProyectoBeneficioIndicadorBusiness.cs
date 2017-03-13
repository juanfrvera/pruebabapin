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
    public class _ProyectoBeneficioIndicadorBusiness : EntityBusiness<ProyectoBeneficioIndicador,ProyectoBeneficioIndicadorFilter,ProyectoBeneficioIndicadorResult,int>
    {        
		protected readonly ProyectoBeneficioIndicadorData Data = new ProyectoBeneficioIndicadorData();
        protected override IEntityData<ProyectoBeneficioIndicador,ProyectoBeneficioIndicadorFilter,ProyectoBeneficioIndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoBeneficioIndicador() { IdProyectoBeneficioIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoBeneficioIndicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoBeneficioIndicador != default(int),"InvalidField", "ProyectoBeneficioIndicador");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoBeneficioIndicador != default(int),"InvalidField", "ProyectoBeneficioIndicador");

				break;
            }
        }   
		
    }	
}
