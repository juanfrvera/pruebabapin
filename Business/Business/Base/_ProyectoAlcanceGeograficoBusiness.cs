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
    public class _ProyectoAlcanceGeograficoBusiness : EntityBusiness<ProyectoAlcanceGeografico,ProyectoAlcanceGeograficoFilter,ProyectoAlcanceGeograficoResult,int>
    {        
		protected readonly ProyectoAlcanceGeograficoData Data = new ProyectoAlcanceGeograficoData();
        protected override IEntityData<ProyectoAlcanceGeografico,ProyectoAlcanceGeograficoFilter,ProyectoAlcanceGeograficoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoAlcanceGeografico() { IdProyectoAlcanceGeografico = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoAlcanceGeografico entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoAlcanceGeografico != default(int),"InvalidField", "ProyectoAlcanceGeografico");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdClasificacionGeografica != default(int),"InvalidField", "ClasificacionGeografica");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoAlcanceGeografico != default(int),"InvalidField", "ProyectoAlcanceGeografico");

				break;
            }
        }   
		
    }	
}
