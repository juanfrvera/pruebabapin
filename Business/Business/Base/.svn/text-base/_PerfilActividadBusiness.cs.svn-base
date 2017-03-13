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
    public class _PerfilActividadBusiness : EntityBusiness<PerfilActividad,PerfilActividadFilter,PerfilActividadResult,int>
    {        
		protected readonly PerfilActividadData Data = new PerfilActividadData();
        protected override IEntityData<PerfilActividad,PerfilActividadFilter,PerfilActividadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PerfilActividad() { IdPerfilActividad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PerfilActividad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPerfilActividad != default(int),"InvalidField", "PerfilActividad");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");
DataHelper.Validate(entity.IdActividad != default(int),"InvalidField", "Actividad");

                  }				
				DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");
DataHelper.Validate(entity.IdActividad != default(int),"InvalidField", "Actividad");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPerfilActividad != default(int),"InvalidField", "PerfilActividad");

				break;
            }
        }   
		
    }	
}
