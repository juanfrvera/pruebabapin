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
    public class _PrestamoDictamenEstadoBusiness : EntityBusiness<PrestamoDictamenEstado,PrestamoDictamenEstadoFilter,PrestamoDictamenEstadoResult,int>
    {        
		protected readonly PrestamoDictamenEstadoData Data = new PrestamoDictamenEstadoData();
        protected override IEntityData<PrestamoDictamenEstado,PrestamoDictamenEstadoFilter,PrestamoDictamenEstadoResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoDictamenEstado() { IdPrestamoDictamenEstado = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoDictamenEstado entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoDictamenEstado != default(int),"InvalidField", "PrestamoDictamenEstado");
DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdPrestamoDictamen != default(int),"InvalidField", "PrestamoDictamen");
DataHelper.Validate(entity.IdEstado != default(int),"InvalidField", "Estado");
DataHelper.Validate(entity.Fecha > new DateTime(1900,1,1) ,"InvalidField", "Fecha");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoDictamenEstado != default(int),"InvalidField", "PrestamoDictamenEstado");

				break;
            }
        }   
		
    }	
}
