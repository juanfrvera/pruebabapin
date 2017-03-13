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
    public class _FinalidadFuncionTipoBusiness : EntityBusiness<FinalidadFuncionTipo,FinalidadFuncionTipoFilter,FinalidadFuncionTipoResult,int>
    {        
		protected readonly FinalidadFuncionTipoData Data = new FinalidadFuncionTipoData();
        protected override IEntityData<FinalidadFuncionTipo,FinalidadFuncionTipoFilter,FinalidadFuncionTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.FinalidadFuncionTipo() { IdFinalidadFuncionTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.FinalidadFuncionTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdFinalidadFuncionTipo != default(int),"InvalidField", "FinalidadFuncionTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdFinalidadFuncionTipo != default(int),"InvalidField", "FinalidadFuncionTipo");
                DataHelper.ValidateForeignKey(entity.FinalidadFuncions.Any(), "El registro no se puede eliminar porque tiene al menos una finalidad-función asociada", "FinalidadFuncionTipo");

				break;
            }
        }   
		
    }	
}
