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
    public class _UsuarioBusiness : EntityBusiness<Usuario,UsuarioFilter,UsuarioResult,int>
    {        
		protected readonly UsuarioData Data = new UsuarioData();
        protected override IEntityData<Usuario,UsuarioFilter,UsuarioResult,int> EntityData
        {
            get { return this.Data;}
        }
		public override bool Can(int id, string actionName, IContextUser contextUser, Hashtable args)
        {
            return Can(new nc.Usuario() { IdUsuario = id }, actionName, contextUser, args);
        }
		public override void Validate(nc.Usuario entity,string actionName, IContextUser contextUser, Hashtable args)
        {           
            base.Validate(entity, actionName,contextUser,args);			
            switch (actionName)
            { 
                case ActionConfig.CREATE:
				case ActionConfig.UPDATE:
				   if (actionName != ActionConfig.CREATE)
				   {
				DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");
DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");

                  }				
				DataHelper.Validate(entity.NombreUsuario!=null,"FieldIsNull","NombreUsuario");
DataHelper.Validate(entity.NombreUsuario.Trim().Length <= 50,"FieldInvalidLength","NombreUsuario");
DataHelper.Validate(entity.Clave!=null,"FieldIsNull","Clave");
DataHelper.Validate(entity.Clave.Trim().Length <= 50,"FieldInvalidLength","Clave");
DataHelper.Validate(entity.IdLanguage != default(int),"InvalidField", "Language");

                break;				
				case ActionConfig.READ:
				case ActionConfig.DELETE:
				DataHelper.Validate(entity.IdUsuario != default(int),"InvalidField", "Usuario");
                DataHelper.ValidateForeignKey(entity.EstadoDeDesicionHistoricos.Any(), "El registro no se puede eliminar porque tiene al menos un estado de desición asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.Messages.Any(), "El registro no se puede eliminar porque tiene al menos un mensaje asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.MessageSends.Any(), "El registro no se puede eliminar porque tiene al menos un mensaje enviado asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.PrestamoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado de dictamen de prestamo asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.Programas.Any(), "El registro no se puede eliminar porque tiene al menos un programa asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.ProyectoDictamenEstados.Any(), "El registro no se puede eliminar porque tiene al menos un estado de dictamen de proyecto asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.ProyectoOficinaPerfilFuncionarios.Any(), "El registro no se puede eliminar porque tiene al menos un funcionario asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientoEstados.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de estado de proyecto asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.ProyectoSeguimientos.Any(), "El registro no se puede eliminar porque tiene al menos un seguimiento de proyecto asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.TextLanguages.Any(), "El registro no se puede eliminar porque tiene al menos un lenguaje de texto asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.Texts.Any(), "El registro no se puede eliminar porque tiene al menos un texto asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.UsuarioOficinaPerfils.Any(), "El registro no se puede eliminar porque tiene al menos prefil de oficina asociado", "Usuario");
                DataHelper.ValidateForeignKey(entity.UsuarioPerfils.Any(), "El registro no se puede eliminar porque tiene al menos prefil de usuario asociado", "Usuario");
				
                break;
            }
        }   
		
    }	
}
