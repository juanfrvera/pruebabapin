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
    public class _GestionTipoBusiness : EntityBusiness<GestionTipo,GestionTipoFilter,GestionTipoResult,int>
    {        
		protected readonly GestionTipoData Data = new GestionTipoData();
        protected override IEntityData<GestionTipo,GestionTipoFilter,GestionTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.GestionTipo() { IdGestionTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.GestionTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdGestionTipo != default(int),"InvalidField", "GestionTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdGestionTipo != default(int),"InvalidField", "GestionTipo");

				break;
            }
        }   
		
    }	
}
