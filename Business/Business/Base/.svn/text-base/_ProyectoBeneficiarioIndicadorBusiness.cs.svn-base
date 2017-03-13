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
    public class _ProyectoBeneficiarioIndicadorBusiness : EntityBusiness<ProyectoBeneficiarioIndicador,ProyectoBeneficiarioIndicadorFilter,ProyectoBeneficiarioIndicadorResult,int>
    {        
		protected readonly ProyectoBeneficiarioIndicadorData Data = new ProyectoBeneficiarioIndicadorData();
        protected override IEntityData<ProyectoBeneficiarioIndicador,ProyectoBeneficiarioIndicadorFilter,ProyectoBeneficiarioIndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoBeneficiarioIndicador() { IdProyectoBeneficiarioIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoBeneficiarioIndicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoBeneficiarioIndicador != default(int),"InvalidField", "ProyectoBeneficiarioIndicador");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.Beneficiario!=null,"FieldIsNull","Beneficiario");
DataHelper.Validate(entity.Beneficiario.Trim().Length <= 500,"FieldInvalidLength","Beneficiario");
DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoBeneficiarioIndicador != default(int),"InvalidField", "ProyectoBeneficiarioIndicador");

				break;
            }
        }   
		
    }	
}
