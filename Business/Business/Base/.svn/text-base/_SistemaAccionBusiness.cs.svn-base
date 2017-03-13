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
    public class _SistemaAccionBusiness : EntityBusiness<SistemaAccion,SistemaAccionFilter,SistemaAccionResult,int>
    {        
		protected readonly SistemaAccionData Data = new SistemaAccionData();
        protected override IEntityData<SistemaAccion,SistemaAccionFilter,SistemaAccionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SistemaAccion() { IdSistemaAccion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SistemaAccion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSistemaAccion != default(int),"InvalidField", "SistemaAccion");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 50,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSistemaAccion != default(int),"InvalidField", "SistemaAccion");
                DataHelper.ValidateForeignKey(entity.Permisos.Any(), "El registro no se puede eliminar porque tiene al menos un permiso asociado", "SistemaAccion");
                DataHelper.ValidateForeignKey(entity.SistemaEntidadAccions.Any(), "El registro no se puede eliminar porque tiene al menos un sistema de entidad asociado", "SistemaAccion");

				break;
            }
        }   
		
    }	
}
