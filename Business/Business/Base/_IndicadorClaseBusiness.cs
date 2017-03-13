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
    public class _IndicadorClaseBusiness : EntityBusiness<IndicadorClase,IndicadorClaseFilter,IndicadorClaseResult,int>
    {        
		protected readonly IndicadorClaseData Data = new IndicadorClaseData();
        protected override IEntityData<IndicadorClase,IndicadorClaseFilter,IndicadorClaseResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.IndicadorClase() { IdIndicadorClase = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.IndicadorClase entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
DataHelper.Validate(entity.IdIndicadorTipo != default(int),"InvalidField", "IndicadorTipo");
DataHelper.Validate(entity.IdUnidad != default(int),"InvalidField", "Unidad");

                  }				
				DataHelper.Validate(entity.IdIndicadorTipo != default(int),"InvalidField", "IndicadorTipo");
DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 10,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 100,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdUnidad != default(int),"InvalidField", "Unidad");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdIndicadorClase != default(int),"InvalidField", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.IndicadorMedioVerificacions.Any(), "El registro no se puede eliminar porque tiene al menos un medio de verificación asociado", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.IndicadorRelacionRubros.Any(), "El registro no se puede eliminar porque tiene al menos un rubro asociado", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.ObjetivoIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un objetivo asociado", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.ProyectoBeneficioIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un beneficio de proyecto asociado", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.ProyectoIndicadorEconomicos.Any(), "El registro no se puede eliminar porque tiene al menos un indicador económico asociado", "IndicadorClase");
                DataHelper.ValidateForeignKey(entity.ProyectoIndicadorPriorizacions.Any(), "El registro no se puede eliminar porque tiene al menos un indicador de prioridad asociado", "IndicadorClase");
               
				break;
            }
        }   
		
    }	
}
