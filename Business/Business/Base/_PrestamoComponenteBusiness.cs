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
    public class _PrestamoComponenteBusiness : EntityBusiness<PrestamoComponente,PrestamoComponenteFilter,PrestamoComponenteResult,int>
    {        
		protected readonly PrestamoComponenteData Data = new PrestamoComponenteData();
        protected override IEntityData<PrestamoComponente,PrestamoComponenteFilter,PrestamoComponenteResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoComponente() { IdPrestamoComponente = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoComponente entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoComponente != default(int),"InvalidField", "PrestamoComponente");
                DataHelper.ValidateForeignKey(entity.PrestamoFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos un financiamiento asociado", "PrestamoComponente");
                DataHelper.ValidateForeignKey(entity.PrestamoProductos.Any(), "El registro no se puede eliminar porque tiene al menos un producto asociado", "PrestamoComponente");
                DataHelper.ValidateForeignKey(entity.PrestamoSubComponentes.Any(), "El registro no se puede eliminar porque tiene al menos un sub componente asociado", "PrestamoComponente");   

				break;
            }
        }   
		
    }	
}
