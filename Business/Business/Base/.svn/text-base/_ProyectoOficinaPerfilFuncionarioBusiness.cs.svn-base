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
    public class _ProyectoOficinaPerfilFuncionarioBusiness : EntityBusiness<ProyectoOficinaPerfilFuncionario,ProyectoOficinaPerfilFuncionarioFilter,ProyectoOficinaPerfilFuncionarioResult,int>
    {        
		protected readonly ProyectoOficinaPerfilFuncionarioData Data = new ProyectoOficinaPerfilFuncionarioData();
        protected override IEntityData<ProyectoOficinaPerfilFuncionario,ProyectoOficinaPerfilFuncionarioFilter,ProyectoOficinaPerfilFuncionarioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoOficinaPerfilFuncionario() { IdProyectoOficinaPerfilFuncionario = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoOficinaPerfilFuncionario entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoOficinaPerfilFuncionario != default(int),"InvalidField", "ProyectoOficinaPerfilFuncionario");
DataHelper.Validate(entity.IdProyectoOficinaPerfil != default(int),"InvalidField", "ProyectoOficinaPerfil");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdProyectoOficinaPerfil != default(int),"InvalidField", "ProyectoOficinaPerfil");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoOficinaPerfilFuncionario != default(int),"InvalidField", "ProyectoOficinaPerfilFuncionario");

				break;
            }
        }   
		
    }	
}
