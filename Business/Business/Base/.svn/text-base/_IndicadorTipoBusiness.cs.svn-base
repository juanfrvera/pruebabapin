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
    public class _IndicadorTipoBusiness : EntityBusiness<IndicadorTipo,IndicadorTipoFilter,IndicadorTipoResult,int>
    {        
		protected readonly IndicadorTipoData Data = new IndicadorTipoData();
        protected override IEntityData<IndicadorTipo,IndicadorTipoFilter,IndicadorTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorTipo() { IdIndicadorTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorTipo != default(int),"InvalidField", "IndicadorTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 20,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorTipo != default(int),"InvalidField", "IndicadorTipo");
                DataHelper.ValidateForeignKey(entity.IndicadorClases.Any(), "El registro no se puede eliminar porque tiene al menos un indicador asociado", "IndicadorTipo");
               
				break;
            }
        }   
		
    }	
}
