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
    public class _PrestamoEstadoBusiness : EntityBusiness<PrestamoEstado,PrestamoEstadoFilter,PrestamoEstadoResult,int>
    {        
		protected readonly PrestamoEstadoData Data = new PrestamoEstadoData();
        protected override IEntityData<PrestamoEstado,PrestamoEstadoFilter,PrestamoEstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoEstado() { IdPrestamoEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoEstado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoEstado != default(int),"InvalidField", "PrestamoEstado");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.FechaEstimada > new DateTime(1900,1,1) ,"InvalidField", "FechaEstimada");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoEstado != default(int),"InvalidField", "PrestamoEstado");

				break;
            }
        }   
		
    }	
}
