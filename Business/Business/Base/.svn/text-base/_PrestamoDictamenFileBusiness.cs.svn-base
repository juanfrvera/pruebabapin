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
    public class _PrestamoDictamenFileBusiness : EntityBusiness<PrestamoDictamenFile,PrestamoDictamenFileFilter,PrestamoDictamenFileResult,int>
    {        
		protected readonly PrestamoDictamenFileData Data = new PrestamoDictamenFileData();
        protected override IEntityData<PrestamoDictamenFile,PrestamoDictamenFileFilter,PrestamoDictamenFileResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoDictamenFile() { IdPrestamoDictamenFile = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoDictamenFile entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoDictamenFile != default(int),"InvalidField", "PrestamoDictamenFile");
DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");
DataHelper.Validate(entity.IdFile != default(int),"InvalidField", "File");

                  }				
				DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");
DataHelper.Validate(entity.IdFile != default(int),"InvalidField", "File");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoDictamenFile != default(int),"InvalidField", "PrestamoDictamenFile");

				break;
            }
        }   
		
    }	
}
