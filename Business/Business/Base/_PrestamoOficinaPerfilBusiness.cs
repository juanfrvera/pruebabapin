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
    public class _PrestamoOficinaPerfilBusiness : EntityBusiness<PrestamoOficinaPerfil,PrestamoOficinaPerfilFilter,PrestamoOficinaPerfilResult,int>
    {        
		protected readonly PrestamoOficinaPerfilData Data = new PrestamoOficinaPerfilData();
        protected override IEntityData<PrestamoOficinaPerfil,PrestamoOficinaPerfilFilter,PrestamoOficinaPerfilResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.PrestamoOficinaPerfil() { IdPrestamoOficinaPerfil = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.PrestamoOficinaPerfil entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPrestamoOficinaPerfil != default(int),"InvalidField", "PrestamoOficinaPerfil");
DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                  }				
				DataHelper.Validate(entity.IdPrestamo != default(int),"InvalidField", "Prestamo");
DataHelper.Validate(entity.IdOficina != default(int),"InvalidField", "Oficina");
DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPrestamoOficinaPerfil != default(int),"InvalidField", "PrestamoOficinaPerfil");
                DataHelper.ValidateForeignKey(entity.PrestamoOficinaFuncionarios.Any(), "El registro no se puede eliminar porque tiene al menos un funcionario asociado", "PrestamoOficinaPerfil");
               
				break;
            }
        }   
		
    }	
}
