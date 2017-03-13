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
    public class _ProyectoDictamenSeguimientoBusiness : EntityBusiness<ProyectoDictamenSeguimiento,ProyectoDictamenSeguimientoFilter,ProyectoDictamenSeguimientoResult,int>
    {        
		protected readonly ProyectoDictamenSeguimientoData Data = new ProyectoDictamenSeguimientoData();
        protected override IEntityData<ProyectoDictamenSeguimiento,ProyectoDictamenSeguimientoFilter,ProyectoDictamenSeguimientoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoDictamenSeguimiento() { IdProyectoDictamenSeguimiento = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoDictamenSeguimiento entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoDictamenSeguimiento != default(int),"InvalidField", "ProyectoDictamenSeguimiento");
DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");
DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");

                  }				
				DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");
DataHelper.Validate(entity.IdProyectoSeguimiento != default(int),"InvalidField", "ProyectoSeguimiento");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoDictamenSeguimiento != default(int),"InvalidField", "ProyectoDictamenSeguimiento");

				break;
            }
        }   
		
    }	
}
