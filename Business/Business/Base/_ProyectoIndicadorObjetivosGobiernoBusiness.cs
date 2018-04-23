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
    public class _ProyectoIndicadorObjetivosGobiernoBusiness : EntityBusiness<ProyectoIndicadorObjetivosGobierno,ProyectoIndicadorObjetivosGobiernoFilter,ProyectoIndicadorObjetivosGobiernoResult,int>
    {        
		protected readonly ProyectoIndicadorObjetivosGobiernoData Data = new ProyectoIndicadorObjetivosGobiernoData();
        protected override IEntityData<ProyectoIndicadorObjetivosGobierno,ProyectoIndicadorObjetivosGobiernoFilter,ProyectoIndicadorObjetivosGobiernoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoIndicadorObjetivosGobierno() { IdProyectoIndicadorObjetivosGobierno = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoIndicadorObjetivosGobierno entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoIndicadorObjetivosGobierno != default(int),"InvalidField", "ProyectoIndicadorObjetivosGobierno");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoIndicadorObjetivosGobierno != default(int),"InvalidField", "ProyectoIndicadorObjetivosGobierno");

				break;
            }
        }   
		
    }	
}
