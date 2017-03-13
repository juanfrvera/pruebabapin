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
    public class _MonedaBusiness : EntityBusiness<Moneda,MonedaFilter,MonedaResult,int>
    {        
		protected readonly MonedaData Data = new MonedaData();
        protected override IEntityData<Moneda,MonedaFilter,MonedaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Moneda() { IdMoneda = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Moneda entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                  }				
				DataHelper.Validate(entity.Sigla!=null,"FieldIsNull","Sigla");
DataHelper.Validate(entity.Sigla.Trim().Length <= 5,"FieldInvalidLength","Sigla");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 20,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");
                DataHelper.ValidateForeignKey(entity.MonedaCotizacions.Any(), "El registro no se puede eliminar porque tiene al menos una cotización asociada", "Moneda");
                DataHelper.ValidateForeignKey(entity.PrestamoConvenios.Any(), "El registro no se puede eliminar porque tiene al menos un convenio de prestamo asociado", "Moneda");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaEstimados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto estimada asociada", "Moneda");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaRealizados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto realizada asociada", "Moneda");
                DataHelper.ValidateForeignKey(entity.TransferenciaDetalles.Any(), "El registro no se puede eliminar porque tiene al menos un detalle de transferencia asociado", "Moneda");
               
				break;
            }
        }   
		
    }	
}
