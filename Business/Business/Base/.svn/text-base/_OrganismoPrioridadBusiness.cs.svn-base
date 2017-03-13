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
    public class _OrganismoPrioridadBusiness : EntityBusiness<OrganismoPrioridad,OrganismoPrioridadFilter,OrganismoPrioridadResult,int>
    {        
		protected readonly OrganismoPrioridadData Data = new OrganismoPrioridadData();
        protected override IEntityData<OrganismoPrioridad,OrganismoPrioridadFilter,OrganismoPrioridadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.OrganismoPrioridad() { IdOrganismoPrioridad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.OrganismoPrioridad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOrganismoPrioridad != default(int),"InvalidField", "OrganismoPrioridad");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 20,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOrganismoPrioridad != default(int),"InvalidField", "OrganismoPrioridad");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "OrganismoPrioridad");
               
				break;
            }
        }   
		
    }	
}
