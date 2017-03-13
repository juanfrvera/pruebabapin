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
    public class _IndicadorRubroBusiness : EntityBusiness<IndicadorRubro,IndicadorRubroFilter,IndicadorRubroResult,int>
    {        
		protected readonly IndicadorRubroData Data = new IndicadorRubroData();
        protected override IEntityData<IndicadorRubro,IndicadorRubroFilter,IndicadorRubroResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorRubro() { IdIndicadorRubro = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorRubro entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorRubro != default(int),"InvalidField", "IndicadorRubro");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorRubro != default(int),"InvalidField", "IndicadorRubro");
                DataHelper.ValidateForeignKey(entity.IndicadorRelacionRubros.Any(), "El registro no se puede eliminar porque tiene al menos un indicador asociado", "IndicadorRubro");
               
				break;
            }
        }   
		
    }	
}
