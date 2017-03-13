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
    public class _ProyectoFaseProyectoEtapaBusiness : EntityBusiness<ProyectoFaseProyectoEtapa,ProyectoFaseProyectoEtapaFilter,ProyectoFaseProyectoEtapaResult,int>
    {        
		protected readonly ProyectoFaseProyectoEtapaData Data = new ProyectoFaseProyectoEtapaData();
        protected override IEntityData<ProyectoFaseProyectoEtapa,ProyectoFaseProyectoEtapaFilter,ProyectoFaseProyectoEtapaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoFaseProyectoEtapa() { IdProyectoFaseProyectoEtapa = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoFaseProyectoEtapa entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoFaseProyectoEtapa != default(int),"InvalidField", "ProyectoFaseProyectoEtapa");
DataHelper.Validate(entity.IdProyectoFase != default(int),"InvalidField", "ProyectoFase");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");

                  }				
				DataHelper.Validate(entity.IdProyectoFase != default(int),"InvalidField", "ProyectoFase");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoFaseProyectoEtapa != default(int),"InvalidField", "ProyectoFaseProyectoEtapa");

				break;
            }
        }   
		
    }	
}
