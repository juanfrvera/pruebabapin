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
    public class _PerfilTipoBusiness : EntityBusiness<PerfilTipo,PerfilTipoFilter,PerfilTipoResult,int>
    {        
		protected readonly PerfilTipoData Data = new PerfilTipoData();
        protected override IEntityData<PerfilTipo,PerfilTipoFilter,PerfilTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PerfilTipo() { IdPerfilTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PerfilTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPerfilTipo != default(int),"InvalidField", "PerfilTipo");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPerfilTipo != default(int),"InvalidField", "PerfilTipo");
                DataHelper.ValidateForeignKey(entity.Perfils.Any(), "El registro no se puede eliminar porque tiene al menos un perfil asociado", "PerfilTipo");   

				break;
            }
        }   
		
    }	
}
