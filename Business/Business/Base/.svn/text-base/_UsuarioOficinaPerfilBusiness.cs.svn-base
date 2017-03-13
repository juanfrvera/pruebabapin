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
    public class _UsuarioOficinaPerfilBusiness : EntityBusiness<UsuarioOficinaPerfil,UsuarioOficinaPerfilFilter,UsuarioOficinaPerfilResult,int>
    {        
		protected readonly UsuarioOficinaPerfilData Data = new UsuarioOficinaPerfilData();
        protected override IEntityData<UsuarioOficinaPerfil,UsuarioOficinaPerfilFilter,UsuarioOficinaPerfilResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.UsuarioOficinaPerfil() { IdUsuarioOficinaPerfil = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.UsuarioOficinaPerfil entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdUsuarioOficinaPerfil != default(int),"InvalidField", "UsuarioOficinaPerfil");
DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                  }				
				DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdUsuarioOficinaPerfil != default(int),"InvalidField", "UsuarioOficinaPerfil");

				break;
            }
        }   
		
    }	
}
