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
    public class _PrestamoSubComponenteBusiness : EntityBusiness<PrestamoSubComponente,PrestamoSubComponenteFilter,PrestamoSubComponenteResult,int>
    {        
		protected readonly PrestamoSubComponenteData Data = new PrestamoSubComponenteData();
        protected override IEntityData<PrestamoSubComponente,PrestamoSubComponenteFilter,PrestamoSubComponenteResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoSubComponente() { IdPrestamoSubComponente = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoSubComponente entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoSubComponente != default(int),"InvalidField", "PrestamoSubComponente");
DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");

                  }				
				DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
DataHelper.Validate(entity.Descripcion!=null,"FieldIsNull","Descripcion");
DataHelper.Validate(entity.Descripcion.Trim().Length <= 500,"FieldInvalidLength","Descripcion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoSubComponente != default(int),"InvalidField", "PrestamoSubComponente");
                DataHelper.ValidateForeignKey(entity.PrestamoFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos un financiamiento asociado", "PrestamoSubComponente");
                DataHelper.ValidateForeignKey(entity.PrestamoProductos.Any(), "El registro no se puede eliminar porque tiene al menos un producto asociado", "PrestamoSubComponente");
               
				break;
            }
        }   
		
    }	
}
