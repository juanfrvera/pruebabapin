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
    public class _SistemaEntidadAccionBusiness : EntityBusiness<SistemaEntidadAccion,SistemaEntidadAccionFilter,SistemaEntidadAccionResult,int>
    {        
		protected readonly SistemaEntidadAccionData Data = new SistemaEntidadAccionData();
        protected override IEntityData<SistemaEntidadAccion,SistemaEntidadAccionFilter,SistemaEntidadAccionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaEntidadAccion() { IdSistemaEntidadAccion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaEntidadAccion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaEntidadAccion != default(int),"InvalidField", "SistemaEntidadAccion");
DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
DataHelper.Validate(entity.IdSistemaAccion != default(int),"InvalidField", "SistemaAccion");

                  }				
				DataHelper.Validate(entity.IdSistemaEntidad != default(int),"InvalidField", "SistemaEntidad");
DataHelper.Validate(entity.IdSistemaAccion != default(int),"InvalidField", "SistemaAccion");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaEntidadAccion != default(int),"InvalidField", "SistemaEntidadAccion");

				break;
            }
        }   
		
    }	
}
