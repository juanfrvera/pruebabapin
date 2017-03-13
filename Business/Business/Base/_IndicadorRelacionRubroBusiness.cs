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
    public class _IndicadorRelacionRubroBusiness : EntityBusiness<IndicadorRelacionRubro,IndicadorRelacionRubroFilter,IndicadorRelacionRubroResult,int>
    {        
		protected readonly IndicadorRelacionRubroData Data = new IndicadorRelacionRubroData();
        protected override IEntityData<IndicadorRelacionRubro,IndicadorRelacionRubroFilter,IndicadorRelacionRubroResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorRelacionRubro() { IdIndicadorRelacionRubro = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorRelacionRubro entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorRelacionRubro != default(int),"InvalidField", "IndicadorRelacionRubro");
DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicadorRubro != default(int),"InvalidField", "IndicadorRubro");

                  }				
				DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicadorRubro != default(int),"InvalidField", "IndicadorRubro");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorRelacionRubro != default(int),"InvalidField", "IndicadorRelacionRubro");

				break;
            }
        }   
		
    }	
}
