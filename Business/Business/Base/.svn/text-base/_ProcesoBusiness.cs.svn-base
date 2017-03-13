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
    public class _ProcesoBusiness : EntityBusiness<Proceso,ProcesoFilter,ProcesoResult,int>
    {        
		protected readonly ProcesoData Data = new ProcesoData();
        protected override IEntityData<Proceso,ProcesoFilter,ProcesoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Proceso() { IdProceso = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Proceso entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProceso != default(int),"InvalidField", "Proceso");
DataHelper.Validate(entity.IdProyectoTipo != default(int),"InvalidField", "ProyectoTipo");

                  }				
				DataHelper.Validate(entity.IdProyectoTipo != default(int),"InvalidField", "ProyectoTipo");
DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProceso != default(int),"InvalidField", "Proceso");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidads.Any(), "El registro no se puede eliminar porque tiene al menos una calidad de proyecto asociada", "Proceso");
                DataHelper.ValidateForeignKey(entity.Proyectos.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "Proceso");
               
				break;
            }
        }   
		
    }	
}
