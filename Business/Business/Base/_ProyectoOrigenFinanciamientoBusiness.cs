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
    public class _ProyectoOrigenFinanciamientoBusiness : EntityBusiness<ProyectoOrigenFinanciamiento,ProyectoOrigenFinanciamientoFilter,ProyectoOrigenFinanciamientoResult,int>
    {        
		protected readonly ProyectoOrigenFinanciamientoData Data = new ProyectoOrigenFinanciamientoData();
        protected override IEntityData<ProyectoOrigenFinanciamiento,ProyectoOrigenFinanciamientoFilter,ProyectoOrigenFinanciamientoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoOrigenFinanciamiento() { IdProyectoOrigenFinanciamiento = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoOrigenFinanciamiento entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoOrigenFinanciamiento != default(int),"InvalidField", "ProyectoOrigenFinanciamiento");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProyectoOrigenFinancianmientoTipo != default(int),"InvalidField", "ProyectoOrigenFinancianmientoTipo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdProyectoOrigenFinancianmientoTipo != default(int),"InvalidField", "ProyectoOrigenFinancianmientoTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoOrigenFinanciamiento != default(int),"InvalidField", "ProyectoOrigenFinanciamiento");

				break;
            }
        }   
		
    }	
}
