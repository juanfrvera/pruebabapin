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
    public class _GeoreferenciacionPuntoBusiness : EntityBusiness<GeoreferenciacionPunto,GeoreferenciacionPuntoFilter,GeoreferenciacionPuntoResult,int>
    {        
		protected readonly GeoreferenciacionPuntoData Data = new GeoreferenciacionPuntoData();
        protected override IEntityData<GeoreferenciacionPunto,GeoreferenciacionPuntoFilter,GeoreferenciacionPuntoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.GeoreferenciacionPunto() { IdGeoreferenciacionPunto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.GeoreferenciacionPunto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdGeoreferenciacionPunto != default(int),"InvalidField", "GeoreferenciacionPunto");
DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");

                  }				
				DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdGeoreferenciacionPunto != default(int),"InvalidField", "GeoreferenciacionPunto");

				break;
            }
        }   
		
    }	
}
