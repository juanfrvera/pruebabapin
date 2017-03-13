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
    public class _ProyectoFileBusiness : EntityBusiness<ProyectoFile,ProyectoFileFilter,ProyectoFileResult,int>
    {        
		protected readonly ProyectoFileData Data = new ProyectoFileData();
        protected override IEntityData<ProyectoFile,ProyectoFileFilter,ProyectoFileResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoFile() { IdProyectoFile = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoFile entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoFile != default(int),"InvalidField", "ProyectoFile");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoFile != default(int),"InvalidField", "ProyectoFile");

				break;
            }
        }   
		
    }	
}
