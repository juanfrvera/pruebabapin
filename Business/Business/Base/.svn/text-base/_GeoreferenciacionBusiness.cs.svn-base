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
    public class _GeoreferenciacionBusiness : EntityBusiness<Georeferenciacion,GeoreferenciacionFilter,GeoreferenciacionResult,int>
    {        
		protected readonly GeoreferenciacionData Data = new GeoreferenciacionData();
        protected override IEntityData<Georeferenciacion,GeoreferenciacionFilter,GeoreferenciacionResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Georeferenciacion() { IdGeoreferenciacion = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Georeferenciacion entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");
DataHelper.Validate(entity.IdGeoreferenciacionTipo != default(int),"InvalidField", "GeoreferenciacionTipo");

                  }				
				DataHelper.Validate(entity.IdGeoreferenciacionTipo != default(int),"InvalidField", "GeoreferenciacionTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdGeoreferenciacion != default(int),"InvalidField", "Georeferenciacion");
                DataHelper.ValidateForeignKey(entity.GeoreferenciacionPuntos.Any(), "El registro no se puede eliminar porque tiene al menos un punto asociado", "Georeferenciacion");
                DataHelper.ValidateForeignKey(entity.ProyectoGeoreferenciacions.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto asociado", "Georeferenciacion");

				break;
            }
        }   
		
    }	
}
