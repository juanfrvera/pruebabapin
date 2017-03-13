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
    public class _SubConvenioTipoBusiness : EntityBusiness<SubConvenioTipo,SubConvenioTipoFilter,SubConvenioTipoResult,int>
    {        
		protected readonly SubConvenioTipoData Data = new SubConvenioTipoData();
        protected override IEntityData<SubConvenioTipo,SubConvenioTipoFilter,SubConvenioTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.SubConvenioTipo() { IdSubconvenioTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.SubConvenioTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdSubconvenioTipo != default(int),"InvalidField", "SubconvenioTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdSubconvenioTipo != default(int),"InvalidField", "SubconvenioTipo");
                DataHelper.ValidateForeignKey(entity.PrestamoSubConvenios.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo sub convenio asociado", "SubconvenioTipo");

				break;
            }
        }   
		
    }	
}
