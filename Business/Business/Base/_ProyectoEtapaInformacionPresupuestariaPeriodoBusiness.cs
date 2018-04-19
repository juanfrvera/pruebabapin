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
    public class _ProyectoEtapaInformacionPresupuestariaPeriodoBusiness : EntityBusiness<ProyectoEtapaInformacionPresupuestariaPeriodo,ProyectoEtapaInformacionPresupuestariaPeriodoFilter,ProyectoEtapaInformacionPresupuestariaPeriodoResult,int>
    {        
		protected readonly ProyectoEtapaInformacionPresupuestariaPeriodoData Data = new ProyectoEtapaInformacionPresupuestariaPeriodoData();
        protected override IEntityData<ProyectoEtapaInformacionPresupuestariaPeriodo,ProyectoEtapaInformacionPresupuestariaPeriodoFilter,ProyectoEtapaInformacionPresupuestariaPeriodoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaInformacionPresupuestariaPeriodo() { IdProyectoEtapaInformacionPresupuestariaPeriodo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaInformacionPresupuestariaPeriodo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestariaPeriodo != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestariaPeriodo");
DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestaria != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestaria");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestaria != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestaria");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestariaPeriodo != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestariaPeriodo");

				break;
            }
        }   
		
    }	
}
