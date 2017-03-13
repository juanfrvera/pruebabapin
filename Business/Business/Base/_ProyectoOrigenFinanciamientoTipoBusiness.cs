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
    public class _ProyectoOrigenFinanciamientoTipoBusiness : EntityBusiness<ProyectoOrigenFinanciamientoTipo,ProyectoOrigenFinanciamientoTipoFilter,ProyectoOrigenFinanciamientoTipoResult,int>
    {        
		protected readonly ProyectoOrigenFinanciamientoTipoData Data = new ProyectoOrigenFinanciamientoTipoData();
        protected override IEntityData<ProyectoOrigenFinanciamientoTipo,ProyectoOrigenFinanciamientoTipoFilter,ProyectoOrigenFinanciamientoTipoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoOrigenFinanciamientoTipo() { IdProyectoOrigenFinancianmientoTipo = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoOrigenFinanciamientoTipo entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoOrigenFinancianmientoTipo != default(int),"InvalidField", "ProyectoOrigenFinancianmientoTipo");

                  }				
				
                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoOrigenFinancianmientoTipo != default(int),"InvalidField", "ProyectoOrigenFinancianmientoTipo");
                DataHelper.ValidateForeignKey(entity.ProyectoOrigenFinanciamientos.Any(), "El registro no se puede eliminar porque tiene al menos un sub origen de financiamiento asociado", "ProyectoOrigenFinancianmientoTipo");

				break;
            }
        }   
		
    }	
}
