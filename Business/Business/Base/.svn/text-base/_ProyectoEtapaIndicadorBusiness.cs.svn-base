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
    public class _ProyectoEtapaIndicadorBusiness : EntityBusiness<ProyectoEtapaIndicador,ProyectoEtapaIndicadorFilter,ProyectoEtapaIndicadorResult,int>
    {        
		protected readonly ProyectoEtapaIndicadorData Data = new ProyectoEtapaIndicadorData();
        protected override IEntityData<ProyectoEtapaIndicador,ProyectoEtapaIndicadorFilter,ProyectoEtapaIndicadorResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoEtapaIndicador() { IdProyectoEtapaIndicador = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoEtapaIndicador entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoEtapaIndicador != default(int),"InvalidField", "ProyectoEtapaIndicador");
DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");

                  }				
				DataHelper.Validate(entity.IdProyectoEtapa != default(int),"InvalidField", "ProyectoEtapa");
DataHelper.Validate(entity.Descripcion!=null,"FieldIsNull","Descripcion");
DataHelper.Validate(entity.Descripcion.Trim().Length <= 500,"FieldInvalidLength","Descripcion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoEtapaIndicador != default(int),"InvalidField", "ProyectoEtapaIndicador");

				break;
            }
        }   
		
    }	
}
