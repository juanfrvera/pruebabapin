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
    public class _PermisoBusiness : EntityBusiness<Permiso,PermisoFilter,PermisoResult,int>
    {        
		protected readonly PermisoData Data = new PermisoData();
        protected override IEntityData<Permiso,PermisoFilter,PermisoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Permiso() { IdPermiso = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Permiso entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPermiso != default(int),"InvalidField", "Permiso");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 200,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 100,"FieldInvalidLength","Codigo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPermiso != default(int),"InvalidField", "Permiso");

				break;
            }
        }   
		
    }	
}
