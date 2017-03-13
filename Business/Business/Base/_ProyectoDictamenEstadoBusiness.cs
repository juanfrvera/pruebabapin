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
    public class _ProyectoDictamenEstadoBusiness : EntityBusiness<ProyectoDictamenEstado,ProyectoDictamenEstadoFilter,ProyectoDictamenEstadoResult,int>
    {        
		protected readonly ProyectoDictamenEstadoData Data = new ProyectoDictamenEstadoData();
        protected override IEntityData<ProyectoDictamenEstado,ProyectoDictamenEstadoFilter,ProyectoDictamenEstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoDictamenEstado() { IdProyectoDictamenEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoDictamenEstado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoDictamenEstado != default(int),"InvalidField", "ProyectoDictamenEstado");
DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdProyectoDictamen != default(int),"InvalidField", "ProyectoDictamen");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoDictamenEstado != default(int),"InvalidField", "ProyectoDictamenEstado");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamens.Any(), "El registro no se puede eliminar porque tiene al menos un dictamen asociado", "ProyectoDictamenEstado");

				break;
            }
        }   
		
    }	
}
