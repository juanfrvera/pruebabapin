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
    public class _UsuarioPerfilBusiness : EntityBusiness<UsuarioPerfil,UsuarioPerfilFilter,UsuarioPerfilResult,int>
    {        
		protected readonly UsuarioPerfilData Data = new UsuarioPerfilData();
        protected override IEntityData<UsuarioPerfil,UsuarioPerfilFilter,UsuarioPerfilResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.UsuarioPerfil() { IdUsuarioPerfil = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.UsuarioPerfil entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdUsuarioPerfil != default(int),"InvalidField", "UsuarioPerfil");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                  }				
				DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdUsuarioPerfil != default(int),"InvalidField", "UsuarioPerfil");

				break;
            }
        }   
		
    }	
}
