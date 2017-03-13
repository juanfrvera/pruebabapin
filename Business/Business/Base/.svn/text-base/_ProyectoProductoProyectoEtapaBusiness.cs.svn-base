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
    public class _ProyectoProductoProyectoEtapaBusiness : EntityBusiness<ProyectoProductoProyectoEtapa,ProyectoProductoProyectoEtapaFilter,ProyectoProductoProyectoEtapaResult,int>
    {        
		protected readonly ProyectoProductoProyectoEtapaData Data = new ProyectoProductoProyectoEtapaData();
        protected override IEntityData<ProyectoProductoProyectoEtapa,ProyectoProductoProyectoEtapaFilter,ProyectoProductoProyectoEtapaResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoProductoProyectoEtapa() { IdProyectoProductoProyectoEtapa = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoProductoProyectoEtapa entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoProductoProyectoEtapa != default(int),"InvalidField", "ProyectoProductoProyectoEtapa");
DataHelper.Validate(entity.IdProyectoProducto != default(int),"InvalidField", "ProyectoProducto");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");

                  }				
				DataHelper.Validate(entity.IdProyectoProducto != default(int),"InvalidField", "ProyectoProducto");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoProductoProyectoEtapa != default(int),"InvalidField", "ProyectoProductoProyectoEtapa");

				break;
            }
        }   
		
    }	
}
