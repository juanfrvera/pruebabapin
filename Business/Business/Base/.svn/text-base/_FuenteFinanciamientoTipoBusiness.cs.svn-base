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
    public class _FuenteFinanciamientoTipoBusiness : EntityBusiness<FuenteFinanciamientoTipo,FuenteFinanciamientoTipoFilter,FuenteFinanciamientoTipoResult,int>
    {        
		protected readonly FuenteFinanciamientoTipoData Data = new FuenteFinanciamientoTipoData();
        protected override IEntityData<FuenteFinanciamientoTipo,FuenteFinanciamientoTipoFilter,FuenteFinanciamientoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.FuenteFinanciamientoTipo() { IdFuenteFinanciamientoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.FuenteFinanciamientoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdFuenteFinanciamientoTipo != default(int),"InvalidField", "FuenteFinanciamientoTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdFuenteFinanciamientoTipo != default(int),"InvalidField", "FuenteFinanciamientoTipo");
                DataHelper.ValidateForeignKey(entity.FuenteFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos una fuente de financiamiento asociada", "FuenteFinanciamientoTipo");

				break;
            }
        }   
		
    }	
}
