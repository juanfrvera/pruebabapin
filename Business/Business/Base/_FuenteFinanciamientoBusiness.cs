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
    public class _FuenteFinanciamientoBusiness : EntityBusiness<FuenteFinanciamiento,FuenteFinanciamientoFilter,FuenteFinanciamientoResult,int>
    {        
		protected readonly FuenteFinanciamientoData Data = new FuenteFinanciamientoData();
        protected override IEntityData<FuenteFinanciamiento,FuenteFinanciamientoFilter,FuenteFinanciamientoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.FuenteFinanciamiento() { IdFuenteFinanciamiento = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.FuenteFinanciamiento entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
DataHelper.Validate(entity.IdFuenteFinanciamientoTipo != default(int),"InvalidField", "FuenteFinanciamientoTipo");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 2,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdFuenteFinanciamientoTipo != default(int),"InvalidField", "FuenteFinanciamientoTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
                DataHelper.ValidateForeignKey(entity.FuenteFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos una sub fuente de financiamiento asociada", "FuenteFinanciamiento");
                DataHelper.ValidateForeignKey(entity.PrestamoFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo financiero asociado", "FuenteFinanciamiento");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaEstimados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto estimada asociada", "FuenteFinanciamiento");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaRealizados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto realizada asociada", "FuenteFinanciamiento");
                DataHelper.ValidateForeignKey(entity.TransferenciaDetalles.Any(), "El registro no se puede eliminar porque tiene al menos un detalle de transferencia asociado", "FuenteFinanciamiento");

				break;
            }
        }   
		
    }	
}
