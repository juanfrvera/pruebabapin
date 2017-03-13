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
    public class _ProyectoSeguimientoFileBusiness : EntityBusiness<ProyectoSeguimientoFile,ProyectoSeguimientoFileFilter,ProyectoSeguimientoFileResult,int>
    {        
		protected readonly ProyectoSeguimientoFileData Data = new ProyectoSeguimientoFileData();
        protected override IEntityData<ProyectoSeguimientoFile,ProyectoSeguimientoFileFilter,ProyectoSeguimientoFileResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoSeguimientoFile() { IdProyectoSeguimientoFile = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoSeguimientoFile entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoSeguimientoFile != default(int),"InvalidField", "ProyectoSeguimientoFile");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoSeguimientoFile != default(int),"InvalidField", "ProyectoSeguimientoFile");

				break;
            }
        }   
		
    }	
}
