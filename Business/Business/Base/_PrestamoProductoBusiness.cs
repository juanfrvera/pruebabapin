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
    public class _PrestamoProductoBusiness : EntityBusiness<PrestamoProducto,PrestamoProductoFilter,PrestamoProductoResult,int>
    {        
		protected readonly PrestamoProductoData Data = new PrestamoProductoData();
        protected override IEntityData<PrestamoProducto,PrestamoProductoFilter,PrestamoProductoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoProducto() { IdPrestamoProducto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoProducto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoProducto != default(int),"InvalidField", "PrestamoProducto");
DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");

                  }				
				DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
DataHelper.Validate(entity.Descripcion!=null,"FieldIsNull","Descripcion");
DataHelper.Validate(entity.Descripcion.Trim().Length <= 500,"FieldInvalidLength","Descripcion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoProducto != default(int),"InvalidField", "PrestamoProducto");

				break;
            }
        }   
		
    }	
}
