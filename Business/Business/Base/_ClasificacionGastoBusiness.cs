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
    public class _ClasificacionGastoBusiness : EntityBusiness<ClasificacionGasto,ClasificacionGastoFilter,ClasificacionGastoResult,int>
    {        
		protected readonly ClasificacionGastoData Data = new ClasificacionGastoData();
        protected override IEntityData<ClasificacionGasto,ClasificacionGastoFilter,ClasificacionGastoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ClasificacionGasto() { IdClasificacionGasto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ClasificacionGasto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
DataHelper.Validate(entity.IdClasificacionGastoTipo != default(int),"InvalidField", "ClasificacionGastoTipo");
DataHelper.Validate(entity.IdClasificacionGastoRubro != default(int),"InvalidField", "ClasificacionGastoRubro");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 4,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 90,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdClasificacionGastoTipo != default(int),"InvalidField", "ClasificacionGastoTipo");
DataHelper.Validate(entity.IdClasificacionGastoRubro != default(int),"InvalidField", "ClasificacionGastoRubro");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
                DataHelper.ValidateForeignKey(entity.ClasificacionGastos.Any(), "El registro no se puede eliminar porque tiene al menos una sub clasificacion de gasto asociada", "ClasificacionGasto");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaEstimados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto estimada asociada", "ClasificacionGasto");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaRealizados.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto realizada asociada", "ClasificacionGasto");
                DataHelper.ValidateForeignKey(entity.Transferencias.Any(), "El registro no se puede eliminar porque tiene al menos una transferencia asociada", "ClasificacionGasto");
				
				break;
            }
        }   
		
    }	
}
