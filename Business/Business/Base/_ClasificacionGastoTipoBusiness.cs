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
    public class _ClasificacionGastoTipoBusiness : EntityBusiness<ClasificacionGastoTipo,ClasificacionGastoTipoFilter,ClasificacionGastoTipoResult,int>
    {        
		protected readonly ClasificacionGastoTipoData Data = new ClasificacionGastoTipoData();
        protected override IEntityData<ClasificacionGastoTipo,ClasificacionGastoTipoFilter,ClasificacionGastoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ClasificacionGastoTipo() { IdClasificacionGastoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ClasificacionGastoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacionGastoTipo != default(int),"InvalidField", "ClasificacionGastoTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacionGastoTipo != default(int),"InvalidField", "ClasificacionGastoTipo");
                DataHelper.ValidateForeignKey(entity.ClasificacionGastos.Any(), "El registro no se puede eliminar porque tiene al menos una clasificación de gastos asociada", "ClasificacionGastoTipo");
				
				break;
            }
        }   
		
    }	
}
