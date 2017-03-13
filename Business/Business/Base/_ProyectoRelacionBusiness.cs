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
    public class _ProyectoRelacionBusiness : EntityBusiness<ProyectoRelacion,ProyectoRelacionFilter,ProyectoRelacionResult,int>
    {        
		protected readonly ProyectoRelacionData Data = new ProyectoRelacionData();
        protected override IEntityData<ProyectoRelacion,ProyectoRelacionFilter,ProyectoRelacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoRelacion() { IdProyectoRelacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoRelacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoRelacion != default(int),"InvalidField", "ProyectoRelacion");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProyectoRelacionado != default(int),"InvalidField", "ProyectoRelacionado");
DataHelper.Validate(entity.IdProyectoRelacionTipo != default(int),"InvalidField", "ProyectoRelacionTipo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProyectoRelacionado != default(int),"InvalidField", "ProyectoRelacionado");
DataHelper.Validate(entity.IdProyectoRelacionTipo != default(int),"InvalidField", "ProyectoRelacionTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoRelacion != default(int),"InvalidField", "ProyectoRelacion");

				break;
            }
        }   
		
    }	
}
