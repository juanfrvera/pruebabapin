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
    public class _ProyectoCalidadLocalizacionBusiness : EntityBusiness<ProyectoCalidadLocalizacion,ProyectoCalidadLocalizacionFilter,ProyectoCalidadLocalizacionResult,int>
    {        
		protected readonly ProyectoCalidadLocalizacionData Data = new ProyectoCalidadLocalizacionData();
        protected override IEntityData<ProyectoCalidadLocalizacion,ProyectoCalidadLocalizacionFilter,ProyectoCalidadLocalizacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoCalidadLocalizacion() { IdProyectoCalidadLocalizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoCalidadLocalizacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoCalidadLocalizacion != default(int),"InvalidField", "ProyectoCalidadLocalizacion");
DataHelper.Validate(entity.IdProyectoCalidad != default(int),"InvalidField", "ProyectoCalidad");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                  }				
				DataHelper.Validate(entity.IdProyectoCalidad != default(int),"InvalidField", "ProyectoCalidad");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoCalidadLocalizacion != default(int),"InvalidField", "ProyectoCalidadLocalizacion");

				break;
            }
        }   
		
    }	
}
