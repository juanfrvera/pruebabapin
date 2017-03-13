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
    public class _TransferenciaBusiness : EntityBusiness<Transferencia,TransferenciaFilter,TransferenciaResult,int>
    {        
		protected readonly TransferenciaData Data = new TransferenciaData();
        protected override IEntityData<Transferencia,TransferenciaFilter,TransferenciaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Transferencia() { IdTransferencia = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Transferencia entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdTransferencia != default(int),"InvalidField", "Transferencia");
DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");

                  }				
				DataHelper.Validate(entity.IdSubPrograma != default(int),"InvalidField", "SubPrograma");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 500,"FieldInvalidLength","Denominacion");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdTransferencia != default(int),"InvalidField", "Transferencia");
                DataHelper.ValidateForeignKey(entity.ProyectoOrigenFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos un origen de financiamiento asociado", "Transferencia");
                DataHelper.ValidateForeignKey(entity.TransferenciaDetalles.Any(), "El registro no se puede eliminar porque tiene al menos un detalle de transferencia asociado", "Transferencia");

				break;
            }
        }   
		
    }	
}
