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
    public class _PrioridadBusiness : EntityBusiness<Prioridad,PrioridadFilter,PrioridadResult,int>
    {        
		protected readonly PrioridadData Data = new PrioridadData();
        protected override IEntityData<Prioridad,PrioridadFilter,PrioridadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Prioridad() { IdPrioridad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Prioridad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrioridad != default(int),"InvalidField", "Prioridad");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 10,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrioridad != default(int),"InvalidField", "Prioridad");
                DataHelper.ValidateForeignKey(entity.ProyectoPrioridads.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "Prioridad");
               
				break;
            }
        }   
		
    }	
}
