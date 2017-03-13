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
    public class _ProyectoOficinaPerfilBusiness : EntityBusiness<ProyectoOficinaPerfil,ProyectoOficinaPerfilFilter,ProyectoOficinaPerfilResult,int>
    {        
		protected readonly ProyectoOficinaPerfilData Data = new ProyectoOficinaPerfilData();
        protected override IEntityData<ProyectoOficinaPerfil,ProyectoOficinaPerfilFilter,ProyectoOficinaPerfilResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.ProyectoOficinaPerfil() { IdProyectoOficinaPerfil = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.ProyectoOficinaPerfil entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdProyectoOficinaPerfil != default(int),"InvalidField", "ProyectoOficinaPerfil");
DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                  }				
				DataHelper.Validate(entity.IdProyecto != default(int),"InvalidField", "Proyecto");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdProyectoOficinaPerfil != default(int),"InvalidField", "ProyectoOficinaPerfil");
                DataHelper.ValidateForeignKey(entity.ProyectoOficinaPerfilFuncionarios.Any(), "El registro no se puede eliminar porque tiene al menos un funcionario asociado", "ProyectoOficinaPerfil");

				break;
            }
        }   
		
    }	
}
