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
    public class _FinalidadFuncionBusiness : EntityBusiness<FinalidadFuncion,FinalidadFuncionFilter,FinalidadFuncionResult,int>
    {        
		protected readonly FinalidadFuncionData Data = new FinalidadFuncionData();
        protected override IEntityData<FinalidadFuncion,FinalidadFuncionFilter,FinalidadFuncionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.FinalidadFuncion() { IdFinalidadFuncion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.FinalidadFuncion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");

                  }				
				DataHelper.Validate(entity.Codigo!=null,"FieldIsNull","Codigo");
DataHelper.Validate(entity.Codigo.Trim().Length <= 3,"FieldInvalidLength","Codigo");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 50,"FieldInvalidLength","Denominacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdFinalidadFuncion != default(int),"InvalidField", "FinalidadFuncion");
                DataHelper.ValidateForeignKey(entity.FinalidadFuncions.Any(), "El registro no se puede eliminar porque tiene al menos una sub finalidad-función asociada", "FinalidadFuncion");
                DataHelper.ValidateForeignKey(entity.PrestamoFinalidadFuncions.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "FinalidadFuncion");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidads.Any(), "El registro no se puede eliminar porque tiene al menos una calidad de asociada", "FinalidadFuncion");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "FinalidadFuncion");
                DataHelper.ValidateForeignKey(entity.TransferenciaDetalles.Any(), "El registro no se puede eliminar porque tiene al menos un detalle de transferencia asociado", "FinalidadFuncion");

				break;
            }
        }   
		
    }	
}
