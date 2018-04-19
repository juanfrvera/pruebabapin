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
    public class _ProyectoEtapaInformacionPresupuestariaBusiness : EntityBusiness<ProyectoEtapaInformacionPresupuestaria,ProyectoEtapaInformacionPresupuestariaFilter,ProyectoEtapaInformacionPresupuestariaResult,int>
    {        
		protected readonly ProyectoEtapaInformacionPresupuestariaData Data = new ProyectoEtapaInformacionPresupuestariaData();
        protected override IEntityData<ProyectoEtapaInformacionPresupuestaria,ProyectoEtapaInformacionPresupuestariaFilter,ProyectoEtapaInformacionPresupuestariaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaInformacionPresupuestaria() { IdProyectoEtapaInformacionPresupuestaria = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaInformacionPresupuestaria entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestaria != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestaria");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.IdClasificacionGasto != default(int),"InvalidField", "ClasificacionGasto");
DataHelper.Validate(entity.IdFuenteFinanciamiento != default(int),"InvalidField", "FuenteFinanciamiento");
DataHelper.Validate(entity.IdMoneda != default(int),"InvalidField", "Moneda");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaInformacionPresupuestaria != default(int),"InvalidField", "ProyectoEtapaInformacionPresupuestaria");
                DataHelper.ValidateForeignKey(entity.ProyectoEtapaInformacionPresupuestariaPeriodos.Any(), "El registro no se puede eliminar porque tiene al menos un periodo asociado", "ProyectoEtapaInformacionPresupuestaria");

				break;
            }
        }   
		
    }	
}
