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
    public class _ProyectoDemoraBusiness : EntityBusiness<ProyectoDemora,ProyectoDemoraFilter,ProyectoDemoraResult,int>
    {        
		protected readonly ProyectoDemoraData Data = new ProyectoDemoraData();
        protected override IEntityData<ProyectoDemora,ProyectoDemoraFilter,ProyectoDemoraResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoDemora() { IdProyectoDemora = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoDemora entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoDemora != default(int),"InvalidField", "ProyectoDemora");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.Justificacion!=null,"FieldIsNull","Justificacion");
DataHelper.Validate(entity.Justificacion.Trim().Length <= 8000,"FieldInvalidLength","Justificacion");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoDemora != default(int),"InvalidField", "ProyectoDemora");

				break;
            }
        }   
		
    }	
}
