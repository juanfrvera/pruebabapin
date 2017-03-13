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
    public class _ProyectoDictamenBusiness : EntityBusiness<ProyectoDictamen,ProyectoDictamenFilter,ProyectoDictamenResult,int>
    {        
		protected readonly ProyectoDictamenData Data = new ProyectoDictamenData();
        protected override IEntityData<ProyectoDictamen,ProyectoDictamenFilter,ProyectoDictamenResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoDictamen() { IdProyectoDictamen = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoDictamen entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");

                  }				
				DataHelper.Validate(entity.FechaEstado > new DateTime(1900,1,1) ,"InvalidField", "FechaEstado");
DataHelper.Validate(entity.Denominacion!=null,"FieldIsNull","Denominacion");
DataHelper.Validate(entity.Denominacion.Trim().Length <= 500,"FieldInvalidLength","Denominacion");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado asociado", "ProyectoDictamen");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamenSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento asociado", "ProyectoDictamen");

				break;
            }
        }   
		
    }	
}
