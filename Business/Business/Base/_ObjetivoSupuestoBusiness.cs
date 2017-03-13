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
    public class _ObjetivoSupuestoBusiness : EntityBusiness<ObjetivoSupuesto,ObjetivoSupuestoFilter,ObjetivoSupuestoResult,int>
    {        
		protected readonly ObjetivoSupuestoData Data = new ObjetivoSupuestoData();
        protected override IEntityData<ObjetivoSupuesto,ObjetivoSupuestoFilter,ObjetivoSupuestoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ObjetivoSupuesto() { IdObjetivoSupuesto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ObjetivoSupuesto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdObjetivoSupuesto != default(int),"InvalidField", "ObjetivoSupuesto");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");
DataHelper.Validate(entity.Descripcion!=null,"FieldIsNull","Descripcion");
DataHelper.Validate(entity.Descripcion.Trim().Length <= 500,"FieldInvalidLength","Descripcion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdObjetivoSupuesto != default(int),"InvalidField", "ObjetivoSupuesto");

				break;
            }
        }   
		
    }	
}
