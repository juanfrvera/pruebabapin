using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using nc=Contract;

namespace Business.Base
{
    public class _PrestamoEstadoAsociadoBusiness : EntityBusiness<PrestamoEstadoAsociado,PrestamoEstadoAsociadoFilter,PrestamoEstadoAsociadoResult,int>
    {        
		protected readonly PrestamoEstadoAsociadoData Data = new PrestamoEstadoAsociadoData();
        protected override IEntityData<PrestamoEstadoAsociado,PrestamoEstadoAsociadoFilter,PrestamoEstadoAsociadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		
		public override void Validate(nc.PrestamoEstadoAsociado entity,string actionName, IContextUser contextUser, params string[] args)
        {           
            base.Validate(entity, actionName,contextUser);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoEstadoasociado != default(int),"InvalidFiled", "PrestamoEstadoasociado");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidFiled", "Prestamo");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidFiled", "Estado");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidFiled", "Prestamo");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidFiled", "Estado");
DataHelper.Validate(entity.FechaEstimada > new DateTime(1900,1,1) ,"InvalidFiled", "FechaEstimada");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoEstadoasociado != default(int),"InvalidFiled", "PrestamoEstadoasociado");

				break;
            }
        }   
		
    }	
}
