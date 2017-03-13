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
    public class _ActividadPermisoBusiness : EntityBusiness<ActividadPermiso,ActividadPermisoFilter,ActividadPermisoResult,int>
    {        
		protected readonly ActividadPermisoData Data = new ActividadPermisoData();
        protected override IEntityData<ActividadPermiso,ActividadPermisoFilter,ActividadPermisoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ActividadPermiso() { IdActividadPermiso = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ActividadPermiso entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdActividadPermiso != default(int),"InvalidField", "ActividadPermiso");
DataHelper.Validate(entity.IdPermiso != default(int),"InvalidField", "Permiso");
DataHelper.Validate(entity.IdActividad != default(int),"InvalidField", "Actividad");

                  }				
				DataHelper.Validate(entity.IdPermiso != default(int),"InvalidField", "Permiso");
DataHelper.Validate(entity.IdActividad != default(int),"InvalidField", "Actividad");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdActividadPermiso != default(int),"InvalidField", "ActividadPermiso");
                    
				break;
            }
        }   
		
    }	
}
