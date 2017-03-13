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
    public class _ProyectoSeguimientoLocalizacionBusiness : EntityBusiness<ProyectoSeguimientoLocalizacion,ProyectoSeguimientoLocalizacionFilter,ProyectoSeguimientoLocalizacionResult,int>
    {        
		protected readonly ProyectoSeguimientoLocalizacionData Data = new ProyectoSeguimientoLocalizacionData();
        protected override IEntityData<ProyectoSeguimientoLocalizacion,ProyectoSeguimientoLocalizacionFilter,ProyectoSeguimientoLocalizacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoSeguimientoLocalizacion() { IdProyectoSeguimientoLocalizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoSeguimientoLocalizacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoSeguimientoLocalizacion != default(int),"InvalidField", "ProyectoSeguimientoLocalizacion");
DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdCalificacionGeografica != default(int),"InvalidField", "CalificacionGeografica");

                  }				
				DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");
DataHelper.Validate(entity.IdCalificacionGeografica != default(int),"InvalidField", "CalificacionGeografica");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoSeguimientoLocalizacion != default(int),"InvalidField", "ProyectoSeguimientoLocalizacion");

				break;
            }
        }   
		
    }	
}
