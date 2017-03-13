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
    public class _PrestamoObjetivoEspecificoBusiness : EntityBusiness<PrestamoObjetivoEspecifico,PrestamoObjetivoEspecificoFilter,PrestamoObjetivoEspecificoResult,int>
    {        
		protected readonly PrestamoObjetivoEspecificoData Data = new PrestamoObjetivoEspecificoData();
        protected override IEntityData<PrestamoObjetivoEspecifico,PrestamoObjetivoEspecificoFilter,PrestamoObjetivoEspecificoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoObjetivoEspecifico() { IdPrestamoObjetivoEspecifico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoObjetivoEspecifico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoObjetivoEspecifico != default(int),"InvalidField", "PrestamoObjetivoEspecifico");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoObjetivoEspecifico != default(int),"InvalidField", "PrestamoObjetivoEspecifico");

				break;
            }
        }   
		
    }	
}
