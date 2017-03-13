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
    public class _EntidadTipoBusiness : EntityBusiness<EntidadTipo,EntidadTipoFilter,EntidadTipoResult,int>
    {        
		protected readonly EntidadTipoData Data = new EntidadTipoData();
        protected override IEntityData<EntidadTipo,EntidadTipoFilter,EntidadTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.EntidadTipo() { IdEntidadTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.EntidadTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdEntidadTipo != default(int),"InvalidField", "EntidadTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 5,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdEntidadTipo != default(int),"InvalidField", "EntidadTipo");
                DataHelper.ValidateForeignKey(entity.Safs.Any(), "El registro no se puede eliminar porque tiene al menos un Saf asociado", "EntidadTipo");    

				break;
            }
        }   
		
    }	
}
