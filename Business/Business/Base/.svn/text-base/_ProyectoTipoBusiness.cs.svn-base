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
    public class _ProyectoTipoBusiness : EntityBusiness<ProyectoTipo,ProyectoTipoFilter,ProyectoTipoResult,int>
    {        
		protected readonly ProyectoTipoData Data = new ProyectoTipoData();
        protected override IEntityData<ProyectoTipo,ProyectoTipoFilter,ProyectoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoTipo() { IdProyectoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoTipo != default(int),"InvalidField", "ProyectoTipo");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 3,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.Tipo!=null,"FieldIsNull","Tipo");
DataHelper.Validate(entity.Tipo.Trim().Length <= 1,"FieldInvalidLength","Tipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoTipo != default(int),"InvalidField", "ProyectoTipo");
                DataHelper.ValidateForeignKey(entity.Procesos.Any(), "El tipo de proyecto no se puede eliminar porque tiene al menos un proceso asociado", "Tipo de proyecto");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El tipo de proyecto no se puede eliminar porque tiene al menos un proyecto asociado", "Tipo de proyecto");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidads.Any(), "El tipo de proyecto no se puede eliminar porque tiene al menos una calidad de proyecto asociada", "Tipo de proyecto");

                break;
            }
        }   
		
    }	
}
