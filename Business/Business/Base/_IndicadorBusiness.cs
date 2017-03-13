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
    public class _IndicadorBusiness : EntityBusiness<Indicador,IndicadorFilter,IndicadorResult,int>
    {        
		protected readonly IndicadorData Data = new IndicadorData();
        protected override IEntityData<Indicador,IndicadorFilter,IndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Indicador() { IdIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Indicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicador != default(int),"InvalidField", "Indicador");
                DataHelper.ValidateForeignKey(entity.IndicadorEvolucions.Any(), "El registro no se puede eliminar porque tiene al menos una evolucion de indicador asociada", "Indicador");
                DataHelper.ValidateForeignKey(entity.ObjetivoIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un objetivo de indicador asociado", "Indicador");
                DataHelper.ValidateForeignKey(entity.ProyectoBeneficiarioIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto beneficiario asociado", "Indicador");
                DataHelper.ValidateForeignKey(entity.ProyectoBeneficioIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto de beneficio asociado", "Indicador");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto asociada", "Indicador");

				break;
            }
        }   
		
    }	
}
