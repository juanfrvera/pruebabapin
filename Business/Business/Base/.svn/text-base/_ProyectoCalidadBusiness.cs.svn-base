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
    public class _ProyectoCalidadBusiness : EntityBusiness<ProyectoCalidad,ProyectoCalidadFilter,ProyectoCalidadResult,int>
    {        
		protected readonly ProyectoCalidadData Data = new ProyectoCalidadData();
        protected override IEntityData<ProyectoCalidad,ProyectoCalidadFilter,ProyectoCalidadResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoCalidad() { IdProyectoCalidad = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoCalidad entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoCalidad != default(int),"InvalidField", "ProyectoCalidad");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoCalidad != default(int),"InvalidField", "ProyectoCalidad");
                DataHelper.ValidateForeignKey(entity.ProyectoCalidadLocalizacions.Any(), "El registro no se puede eliminar porque tiene al menos una localización asociada", "ProyectoCalidad");

				break;
            }
        }   
		
    }	
}
