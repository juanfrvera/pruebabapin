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
    public class _MonedaCotizacionBusiness : EntityBusiness<MonedaCotizacion,MonedaCotizacionFilter,MonedaCotizacionResult,int>
    {        
		protected readonly MonedaCotizacionData Data = new MonedaCotizacionData();
        protected override IEntityData<MonedaCotizacion,MonedaCotizacionFilter,MonedaCotizacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.MonedaCotizacion() { IdMonedaCotizacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.MonedaCotizacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMonedaCotizacion != default(int),"InvalidField", "MonedaCotizacion");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                  }				
				DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMonedaCotizacion != default(int),"InvalidField", "MonedaCotizacion");

				break;
            }
        }   
		
    }	
}
