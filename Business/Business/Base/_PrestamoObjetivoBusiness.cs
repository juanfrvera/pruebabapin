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
    public class _PrestamoObjetivoBusiness : EntityBusiness<PrestamoObjetivo,PrestamoObjetivoFilter,PrestamoObjetivoResult,int>
    {        
		protected readonly PrestamoObjetivoData Data = new PrestamoObjetivoData();
        protected override IEntityData<PrestamoObjetivo,PrestamoObjetivoFilter,PrestamoObjetivoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoObjetivo() { IdPrestamoObjetivo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoObjetivo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoObjetivo != default(int),"InvalidField", "PrestamoObjetivo");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoObjetivo != default(int),"InvalidField", "PrestamoObjetivo");

				break;
            }
        }   
		
    }	
}
