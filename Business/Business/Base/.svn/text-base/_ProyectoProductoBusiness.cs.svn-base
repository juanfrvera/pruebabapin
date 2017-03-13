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
    public class _ProyectoProductoBusiness : EntityBusiness<ProyectoProducto,ProyectoProductoFilter,ProyectoProductoResult,int>
    {        
		protected readonly ProyectoProductoData Data = new ProyectoProductoData();
        protected override IEntityData<ProyectoProducto,ProyectoProductoFilter,ProyectoProductoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoProducto() { IdProyectoProducto = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoProducto entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoProducto != default(int),"InvalidField", "ProyectoProducto");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdObjetivo != default(int),"InvalidField", "Objetivo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoProducto != default(int),"InvalidField", "ProyectoProducto");
                DataHelper.ValidateForeignKey(entity.ProyectoProductoProyectoEtapas.Any(), "El registro no se puede eliminar porque tiene al menos una etapa de proyecto asociada", "ProyectoProducto");

				break;
            }
        }   
		
    }	
}
