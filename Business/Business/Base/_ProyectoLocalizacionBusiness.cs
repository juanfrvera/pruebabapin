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
    public class _ProyectoLocalizacionBusiness : EntityBusiness<ProyectoLocalizacion,ProyectoLocalizacionFilter,ProyectoLocalizacionResult,int>
    {        
		protected readonly ProyectoLocalizacionData Data = new ProyectoLocalizacionData();
        protected override IEntityData<ProyectoLocalizacion,ProyectoLocalizacionFilter,ProyectoLocalizacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoLocalizacion() { IdProyectoLocalizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoLocalizacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoLocalizacion != default(int),"InvalidField", "ProyectoLocalizacion");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoLocalizacion != default(int),"InvalidField", "ProyectoLocalizacion");

				break;
            }
        }   
		
    }	
}
