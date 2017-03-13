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
    public class _PrestamoSubConvenioBusiness : EntityBusiness<PrestamoSubConvenio,PrestamoSubConvenioFilter,PrestamoSubConvenioResult,int>
    {        
		protected readonly PrestamoSubConvenioData Data = new PrestamoSubConvenioData();
        protected override IEntityData<PrestamoSubConvenio,PrestamoSubConvenioFilter,PrestamoSubConvenioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoSubConvenio() { IdPrestamoSubConvenio = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoSubConvenio entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoSubConvenio != default(int),"InvalidField", "PrestamoSubConvenio");
DataHelper.Validate(entity.IdPrestamoConvenio != default(int),"InvalidField", "PrestamoConvenio");
DataHelper.Validate(entity.IdTipoSubConvenio != default(int),"InvalidField", "TipoSubConvenio");

                  }				
				DataHelper.Validate(entity.IdPrestamoConvenio != default(int),"InvalidField", "PrestamoConvenio");
DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 10,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Descripcion!=null,"FieldIsNull","Descripcion");
DataHelper.Validate(entity.Descripcion.Trim().Length <= 500,"FieldInvalidLength","Descripcion");
DataHelper.Validate(entity.IdTipoSubConvenio != default(int),"InvalidField", "TipoSubConvenio");
DataHelper.Validate(entity.Contraparte!=null,"FieldIsNull","Contraparte");
DataHelper.Validate(entity.Contraparte.Trim().Length <= 500,"FieldInvalidLength","Contraparte");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.Ejecutor!=null,"FieldIsNull","Ejecutor");
DataHelper.Validate(entity.Ejecutor.Trim().Length <= 500,"FieldInvalidLength","Ejecutor");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoSubConvenio != default(int),"InvalidField", "PrestamoSubConvenio");
                DataHelper.ValidateForeignKey(entity.Observaciones.Any(), "El registro no se puede eliminar porque tiene al menos una observacion asociada", "PrestamoSubConvenio");
               
				break;
            }
        }   
		
    }	
}
