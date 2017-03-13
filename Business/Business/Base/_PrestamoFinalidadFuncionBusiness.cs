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
    public class _PrestamoFinalidadFuncionBusiness : EntityBusiness<PrestamoFinalidadFuncion,PrestamoFinalidadFuncionFilter,PrestamoFinalidadFuncionResult,int>
    {        
		protected readonly PrestamoFinalidadFuncionData Data = new PrestamoFinalidadFuncionData();
        protected override IEntityData<PrestamoFinalidadFuncion,PrestamoFinalidadFuncionFilter,PrestamoFinalidadFuncionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoFinalidadFuncion() { IdPrestamoFinalidadFuncion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoFinalidadFuncion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoFinalidadFuncion != default(int),"InvalidField", "PrestamoFinalidadFuncion");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoFinalidadFuncion != default(int),"InvalidField", "PrestamoFinalidadFuncion");

				break;
            }
        }   
		
    }	
}
