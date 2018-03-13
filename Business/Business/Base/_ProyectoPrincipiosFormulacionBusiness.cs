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
    public class _ProyectoPrincipiosFormulacionBusiness : EntityBusiness<ProyectoPrincipiosFormulacion,ProyectoPrincipiosFormulacionFilter,ProyectoPrincipiosFormulacionResult,int>
    {        
		protected readonly ProyectoPrincipiosFormulacionData Data = new ProyectoPrincipiosFormulacionData();
        protected override IEntityData<ProyectoPrincipiosFormulacion,ProyectoPrincipiosFormulacionFilter,ProyectoPrincipiosFormulacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoPrincipiosFormulacion() { IdProyectoPrincipiosFormulacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoPrincipiosFormulacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
                       DataHelper.Validate(entity.IdProyectoPrincipiosFormulacion != default(int),"InvalidField", "_ProyectoPrincipiosFormulacion");
                       DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "_Proyecto");
                   }				
				    DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "_Proyecto");
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoPrincipiosFormulacion != default(int),"InvalidField", "_ProyectoPrincipiosFormulacion");

				break;
            }
        }   
		
    }	
}
