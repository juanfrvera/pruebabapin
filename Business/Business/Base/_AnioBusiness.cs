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
    public class _AnioBusiness : EntityBusiness<Anio,AnioFilter,AnioResult,int>
    {        
		protected readonly AnioData Data = new AnioData();
        protected override IEntityData<Anio,AnioFilter,AnioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Anio() { IdAnio = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Anio entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdAnio != default(int),"InvalidField", "Anio");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 4,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdAnio != default(int),"InvalidField", "Anio");

				break;
            }
        }   
		
    }	
}
