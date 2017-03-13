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
    public class _IndicadorEvolucionInstanciaBusiness : EntityBusiness<IndicadorEvolucionInstancia,IndicadorEvolucionInstanciaFilter,IndicadorEvolucionInstanciaResult,int>
    {        
		protected readonly IndicadorEvolucionInstanciaData Data = new IndicadorEvolucionInstanciaData();
        protected override IEntityData<IndicadorEvolucionInstancia,IndicadorEvolucionInstanciaFilter,IndicadorEvolucionInstanciaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorEvolucionInstancia() { IdIndicadorEvolucionInstancia = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorEvolucionInstancia entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorEvolucionInstancia != default(int),"InvalidField", "IndicadorEvolucionInstancia");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorEvolucionInstancia != default(int),"InvalidField", "IndicadorEvolucionInstancia");
                DataHelper.ValidateForeignKey(entity.IndicadorEvolucions.Any(), "El registro no se puede eliminar porque tiene al menos un indicador de evolución asociado", "IndicadorEvolucionInstancia");
               
				break;
            }
        }   
		
    }	
}
