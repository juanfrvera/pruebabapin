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
    public class _OficinaSafBusiness : EntityBusiness<OficinaSaf,OficinaSafFilter,OficinaSafResult,int>
    {        
		protected readonly OficinaSafData Data = new OficinaSafData();
        protected override IEntityData<OficinaSaf,OficinaSafFilter,OficinaSafResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.OficinaSaf() { IdOficinaSaf = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.OficinaSaf entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdOficinaSaf != default(int),"InvalidField", "OficinaSaf");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");

                  }				
				DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdSaf != default(int),"InvalidField", "Saf");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdOficinaSaf != default(int),"InvalidField", "OficinaSaf");
                DataHelper.ValidateForeignKey(entity.OficinaSafProgramas.Any(), "El registro no se puede eliminar porque tiene al menos un programa asociado", "OficinaSaf");
               
				break;
            }
        }   
		
    }	
}
