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
    public class _PrestamoOficinaFuncionarioBusiness : EntityBusiness<PrestamoOficinaFuncionario,PrestamoOficinaFuncionarioFilter,PrestamoOficinaFuncionarioResult,int>
    {        
		protected readonly PrestamoOficinaFuncionarioData Data = new PrestamoOficinaFuncionarioData();
        protected override IEntityData<PrestamoOficinaFuncionario,PrestamoOficinaFuncionarioFilter,PrestamoOficinaFuncionarioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoOficinaFuncionario() { IdPrestamoOficinaPerfilFuncionario = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoOficinaFuncionario entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoOficinaPerfilFuncionario != default(int),"InvalidField", "PrestamoOficinaPerfilFuncionario");
DataHelper.Validate(entity.IdPrestamoOficinaPerfil != default(int),"InvalidField", "PrestamoOficinaPerfil");

                  }				
				DataHelper.Validate(entity.IdPrestamoOficinaPerfil != default(int),"InvalidField", "PrestamoOficinaPerfil");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoOficinaPerfilFuncionario != default(int),"InvalidField", "PrestamoOficinaPerfilFuncionario");

				break;
            }
        }   
		
    }	
}
