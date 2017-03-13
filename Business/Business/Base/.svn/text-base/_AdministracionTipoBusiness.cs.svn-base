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
    public class _AdministracionTipoBusiness : EntityBusiness<AdministracionTipo,AdministracionTipoFilter,AdministracionTipoResult,int>
    {        
		protected readonly AdministracionTipoData Data = new AdministracionTipoData();
        protected override IEntityData<AdministracionTipo,AdministracionTipoFilter,AdministracionTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.AdministracionTipo() { IdAdministracionTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.AdministracionTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdAdministracionTipo != default(int),"InvalidField", "AdministracionTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 4,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdAdministracionTipo != default(int),"InvalidField", "AdministracionTipo");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un Saf asociado", "AdministracionTipo");

				break;
            }
        }   
		
    }	
}
