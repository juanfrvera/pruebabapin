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
    public class _PerfilBusiness : EntityBusiness<Perfil,PerfilFilter,PerfilResult,int>
    {        
		protected readonly PerfilData Data = new PerfilData();
        protected override IEntityData<Perfil,PerfilFilter,PerfilResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Perfil() { IdPerfil = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Perfil entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");
DataHelper.Validate(entity.IdPerfilTipo != default(int),"InvalidField", "PerfilTipo");

                  }				
				DataHelper.Validate(entity.Nombre!=null,"FieldIsNull","Nombre");
DataHelper.Validate(entity.Nombre.Trim().Length <= 50,"FieldInvalidLength","Nombre");
DataHelper.Validate(entity.IdPerfilTipo != default(int),"InvalidField", "PerfilTipo");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdPerfil != default(int),"InvalidField", "Perfil");
                DataHelper.ValidateForeignKey(entity.PerfilActividads.Any(), "El registro no se puede eliminar porque tiene al menos una actividad asociada", "Perfil");
                DataHelper.ValidateForeignKey(entity.PrestamoOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un prestamo de oficina asociado", "Perfil");
                DataHelper.ValidateForeignKey(entity.ProyectoOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un proyecto de oficina asociado", "Perfil");
                DataHelper.ValidateForeignKey(entity.UsuarioOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un usuario de oficina asociado", "Perfil");
                DataHelper.ValidateForeignKey(entity.UsuarioPerfils.Any(), "El registro no se puede eliminar porque tiene al menos un perfil de usuario asociado", "Perfil");
               
				break;
            }
        }   
		
    }	
}
