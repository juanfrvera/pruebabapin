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
    public class _ProyectoRelacionTipoBusiness : EntityBusiness<ProyectoRelacionTipo,ProyectoRelacionTipoFilter,ProyectoRelacionTipoResult,int>
    {        
		protected readonly ProyectoRelacionTipoData Data = new ProyectoRelacionTipoData();
        protected override IEntityData<ProyectoRelacionTipo,ProyectoRelacionTipoFilter,ProyectoRelacionTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoRelacionTipo() { IdProyectoRelacionTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoRelacionTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoRelacionTipo != default(int),"InvalidField", "ProyectoRelacionTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoRelacionTipo != default(int),"InvalidField", "ProyectoRelacionTipo");
                DataHelper.ValidateForeignKey(entity.ProyectoRelacions.Any(), "El registro no se puede eliminar porque tiene al menos una relacion de proyecto asociada", "ProyectoRelacionTipo");

				break;
            }
        }   
		
    }	
}
