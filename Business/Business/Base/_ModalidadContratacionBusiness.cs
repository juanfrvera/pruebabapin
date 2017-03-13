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
    public class _ModalidadContratacionBusiness : EntityBusiness<ModalidadContratacion,ModalidadContratacionFilter,ModalidadContratacionResult,int>
    {        
		protected readonly ModalidadContratacionData Data = new ModalidadContratacionData();
        protected override IEntityData<ModalidadContratacion,ModalidadContratacionFilter,ModalidadContratacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ModalidadContratacion() { IdModalidadContratacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ModalidadContratacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdModalidadContratacion != default(int),"InvalidField", "ModalidadContratacion");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdModalidadContratacion != default(int),"InvalidField", "ModalidadContratacion");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "ModalidadContratacion");
                
				break;
            }
        }   
		
    }	
}
