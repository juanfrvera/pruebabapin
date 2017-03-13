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
    public class _PrestamoFileBusiness : EntityBusiness<PrestamoFile,PrestamoFileFilter,PrestamoFileResult,int>
    {        
		protected readonly PrestamoFileData Data = new PrestamoFileData();
        protected override IEntityData<PrestamoFile,PrestamoFileFilter,PrestamoFileResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoFile() { IdPrestamoFile = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoFile entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoFile != default(int),"InvalidField", "PrestamoFile");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdFile != default(int),"InvalidField", "File");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdFile != default(int),"InvalidField", "File");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoFile != default(int),"InvalidField", "PrestamoFile");

				break;
            }
        }   
		
    }	
}
