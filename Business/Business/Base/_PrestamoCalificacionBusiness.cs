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
    public class _PrestamoCalificacionBusiness : EntityBusiness<PrestamoCalificacion,PrestamoCalificacionFilter,PrestamoCalificacionResult,int>
    {        
		protected readonly PrestamoCalificacionData Data = new PrestamoCalificacionData();
        protected override IEntityData<PrestamoCalificacion,PrestamoCalificacionFilter,PrestamoCalificacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoCalificacion() { IdPrestamoCalificacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoCalificacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoCalificacion != default(int),"InvalidField", "PrestamoCalificacion");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoCalificacion != default(int),"InvalidField", "PrestamoCalificacion");

				break;
            }
        }   
		
    }	
}
