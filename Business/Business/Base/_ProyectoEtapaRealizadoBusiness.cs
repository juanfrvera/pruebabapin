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
    public class _ProyectoEtapaRealizadoBusiness : EntityBusiness<ProyectoEtapaRealizado,ProyectoEtapaRealizadoFilter,ProyectoEtapaRealizadoResult,int>
    {        
		protected readonly ProyectoEtapaRealizadoData Data = new ProyectoEtapaRealizadoData();
        protected override IEntityData<ProyectoEtapaRealizado,ProyectoEtapaRealizadoFilter,ProyectoEtapaRealizadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaRealizado() { IdProyectoEtapaRealizado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaRealizado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaRealizado != default(int),"InvalidField", "ProyectoEtapaRealizado");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaRealizado != default(int),"InvalidField", "ProyectoEtapaRealizado");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaRealizadoPeriodos.Any(), "El registro no se puede eliminar porque tiene al menos un periodo asociado", "ProyectoEtapaRealizado");

				break;
            }
        }   
		
    }	
}
