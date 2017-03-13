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
    public class _ClasificacionGastoRubroBusiness : EntityBusiness<ClasificacionGastoRubro,ClasificacionGastoRubroFilter,ClasificacionGastoRubroResult,int>
    {        
		protected readonly ClasificacionGastoRubroData Data = new ClasificacionGastoRubroData();
        protected override IEntityData<ClasificacionGastoRubro,ClasificacionGastoRubroFilter,ClasificacionGastoRubroResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ClasificacionGastoRubro() { IdClasificacionGastoRubro = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ClasificacionGastoRubro entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacionGastoRubro != default(int),"InvalidField", "ClasificacionGastoRubro");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacionGastoRubro != default(int),"InvalidField", "ClasificacionGastoRubro");
                DataHelper.ValidateForeignKey(entity.ClasificacionGastos.Any(), "El registro no se puede eliminar porque tiene al menos una clasificación de gastos asociada", "ClasificacionGastoRubro");
				
				break;
            }
        }   
		
    }	
}
