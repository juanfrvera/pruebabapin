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
    public class _ObjetivoBusiness : EntityBusiness<Objetivo,ObjetivoFilter,ObjetivoResult,int>
    {        
		protected readonly ObjetivoData Data = new ObjetivoData();
        protected override IEntityData<Objetivo,ObjetivoFilter,ObjetivoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Objetivo() { IdObjetivo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Objetivo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 500,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");
                DataHelper.ValidateForeignKey(entity.ObjetivoIndicadors.Any(), "El registro no se puede eliminar porque tiene al menos un indicador asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.ObjetivoSupuestos.Any(), "El registro no se puede eliminar porque tiene al menos un supuesto asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.PrestamoComponentes.Any(), "El registro no se puede eliminar porque tiene al menos un componente de prestamo asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.PrestamoObjetivoEspecificos.Any(), "El registro no se puede eliminar porque tiene al menos un objetivo especifico de prestamo asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.PrestamoObjetivos.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.ProgramaObjetivos.Any(), "El registro no se puede eliminar porque tiene al menos un programa asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.ProyectoProductos.Any(), "El registro no se puede eliminar porque tiene al menos un producto de proyecto asociado", "Objetivo");
                DataHelper.ValidateForeignKey(entity.ProyectoPropositos.Any(), "El registro no se puede eliminar porque tiene al menos un proposito de proyecto asociado", "Objetivo");
               
				break;
            }
        }   
		
    }	
}
