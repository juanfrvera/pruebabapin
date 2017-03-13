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
    public class _ProyectoPropositoBusiness : EntityBusiness<ProyectoProposito,ProyectoPropositoFilter,ProyectoPropositoResult,int>
    {        
		protected readonly ProyectoPropositoData Data = new ProyectoPropositoData();
        protected override IEntityData<ProyectoProposito,ProyectoPropositoFilter,ProyectoPropositoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoProposito() { IdProyectoProposito = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoProposito entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoProposito != default(int),"InvalidField", "ProyectoProposito");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoProposito != default(int),"InvalidField", "ProyectoProposito");

				break;
            }
        }   
		
    }	
}
