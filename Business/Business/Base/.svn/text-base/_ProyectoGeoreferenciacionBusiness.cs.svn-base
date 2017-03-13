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
    public class _ProyectoGeoreferenciacionBusiness : EntityBusiness<ProyectoGeoreferenciacion,ProyectoGeoreferenciacionFilter,ProyectoGeoreferenciacionResult,int>
    {        
		protected readonly ProyectoGeoreferenciacionData Data = new ProyectoGeoreferenciacionData();
        protected override IEntityData<ProyectoGeoreferenciacion,ProyectoGeoreferenciacionFilter,ProyectoGeoreferenciacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoGeoreferenciacion() { IdProyectoGeoreferenciacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoGeoreferenciacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoGeoreferenciacion != default(int),"InvalidField", "ProyectoGeoreferenciacion");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoGeoreferenciacion != default(int),"InvalidField", "ProyectoGeoreferenciacion");

				break;
            }
        }   
		
    }	
}
