using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Web.Security;
using System.Configuration.Provider;
using System.Collections;

namespace Business
{

    public class UsuarioComposeBusiness : EntityComposeBusiness<UsuarioCompose, Usuario, UsuarioFilter, UsuarioResult, int>
    {
        #region Singleton
        private static volatile UsuarioComposeBusiness current;
        private static object syncRoot = new Object();
        public static UsuarioComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UsuarioComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness< Usuario, UsuarioFilter, UsuarioResult, int> EntityBusinessBase
        {
            get { return UsuarioBusiness.Current; }
        }
        #region Gets
        public override UsuarioCompose GetNew(UsuarioResult example)
        {
            UsuarioCompose compose = base.GetNew();
            compose.Usuario = example;
            compose.UsuarioOficinaPerfiles = new List<UsuarioOficinaPerfilResult>();
            return compose;
        }
        public override UsuarioCompose GetNew()
        {
            UsuarioResult example = new UsuarioResult();
            example.Activo = true;
            UsuarioBusiness.Current.Set(UsuarioBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(UsuarioCompose entity)
        {
            return entity.Usuario.IdUsuario;
        }
        public override UsuarioCompose GetById(int id)
        {
            UsuarioCompose compose = new UsuarioCompose();
            compose.Usuario = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { IdUsuario = id }).FirstOrDefault();
            compose.UsuarioOficinaPerfiles = UsuarioOficinaPerfilBusiness.Current.GetResult(new UsuarioOficinaPerfilFilter() { IdUsuario = id });
            return compose;

            
        }
        #endregion

        #region Actions
        public override void Add(UsuarioCompose entity, IContextUser contextUser)
        {
            try
            {
                //Crea el usuario
                Usuario usuario = entity.Usuario.ToEntity();
                UsuarioBusiness.Current.Add(usuario, contextUser);
                entity.Usuario.IdUsuario = usuario.IdUsuario;

                //Crea UsuarioOficinaPerfil 
                foreach (UsuarioOficinaPerfilResult uopr in entity.UsuarioOficinaPerfiles)
                {
                    UsuarioOficinaPerfil uop = uopr.ToEntity();
                    uop.IdUsuario = entity.Usuario.IdUsuario;
                    UsuarioOficinaPerfilBusiness.Current.Add(uop, contextUser);
                }
            }
            catch (Exception exception)
            {
                entity.Usuario.IdUsuario = 0;
                entity.UsuarioOficinaPerfiles.ForEach(i => i.IdUsuario = 0);
                throw exception;
            }

        }
        public override void Update(UsuarioCompose entity, IContextUser contextUser)
        {
            List<UsuarioOficinaPerfilResult> copy = UsuarioOficinaPerfilBusiness.Current.CopiesResult(entity.UsuarioOficinaPerfiles);
            try
            {
                Usuario Usuario = UsuarioBusiness.Current.GetById(entity.Usuario.IdUsuario);
                UsuarioBusiness.Current.Set(entity.Usuario, Usuario);
                UsuarioBusiness.Current.Update(Usuario, contextUser);
                //actualiza UsuarioOficinaPerfil


                //Elimino los que ya no forman parte
                List<int> actualIds = (from o in entity.UsuarioOficinaPerfiles where o.IdUsuarioOficinaPerfil> 0 select o.IdUsuarioOficinaPerfil).ToList();
                List<UsuarioOficinaPerfil> oldDetail = UsuarioOficinaPerfilBusiness.Current.GetList(new UsuarioOficinaPerfilFilter() { IdUsuario  = entity.Usuario.IdUsuario});
                List<UsuarioOficinaPerfil> deletets = (from o in oldDetail where !actualIds.Contains(o.IdUsuarioOficinaPerfil ) select o).ToList();
                UsuarioOficinaPerfilBusiness.Current.Delete(deletets, contextUser);

                foreach (UsuarioOficinaPerfilResult uopr in entity.UsuarioOficinaPerfiles)
                {
                    UsuarioOficinaPerfil uop = uopr.ToEntity();
                    if (uopr.IdUsuario < 1)
                    {
                        //Agrego los nuevos
                        uop.IdUsuario = Usuario.IdUsuario;
                        UsuarioOficinaPerfilBusiness.Current.Add(uop, contextUser);
                        uopr.IdUsuarioOficinaPerfil = uop.IdUsuarioOficinaPerfil;
                    }
                    else
                    {
                        //Actualizo los que quedan
                        UsuarioOficinaPerfilBusiness.Current.Delete(uop.IdUsuarioOficinaPerfil, contextUser);
                    }              
                }

                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (Exception exception)
            {
                entity.UsuarioOficinaPerfiles = copy;
                throw exception;
            }
        }
        public override void Delete(UsuarioCompose entity, IContextUser contextUser)
        {
            UsuarioOficinaPerfilBusiness.Current.Delete(new UsuarioOficinaPerfilFilter() { IdUsuario = entity.Usuario.IdUsuario }, contextUser);
            UsuarioBusiness.Current.Delete(entity.Usuario.IdUsuario, contextUser);
        }
        #endregion

        #region protected Methods
       
        #endregion

        #region Validations
        public override void Validate(UsuarioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            UsuarioBusiness.Current.Validate(UsuarioBusiness.Current.ToEntity(entity.Usuario), actionName, contextUser, args);
        }
        public override bool Can(UsuarioCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return UsuarioBusiness.Current.Can(UsuarioBusiness.Current.ToEntity(entity.Usuario), actionName, contextUser, args);
        }
        #endregion
    }
    
   

    public class UsuarioMembershipComposeBusiness : EntityBusiness<UsuarioMembershipCompose, UsuarioFilter, UsuarioResult, int>
    {
        #region Singleton
        private static volatile UsuarioMembershipComposeBusiness current;
        private static object syncRoot = new Object();

        //private UsuarioBusiness() {}
        public static UsuarioMembershipComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new UsuarioMembershipComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override bool Can(int id, string actionName, IContextUser contextUser,Hashtable args)
        {
            return UsuarioBusiness.Current.Can(new Usuario() { IdUsuario = id }, actionName, contextUser, args);
        }
        protected override IEntityData<UsuarioMembershipCompose, UsuarioFilter, UsuarioResult, int> EntityData
        {
            get { return null; }
        }
        public override UsuarioMembershipCompose GetNew(UsuarioResult example)
        {
            UsuarioMembershipCompose compose = base.GetNew();

            compose.Usuario = example;
            compose.MembershipUser = new MembershipUser(Membership.Provider.Name, "", "", null, null, null, true, false, DateTime.Now
                                         , DateTime.MinValue, DateTime.MinValue, DateTime.MinValue, DateTime.MinValue);
            compose.Roles = new List<RoleResult>();
            return compose;
        }
        public override UsuarioMembershipCompose GetNew()
        {
            UsuarioResult example = new UsuarioResult();
            example.Activo = true;
            return GetNew(example);
        }
        public override int GetId(UsuarioMembershipCompose entity)
        {
            return entity.Usuario.IdUsuario;
        }
        public override UsuarioMembershipCompose GetById(int id)
        {
            UsuarioMembershipCompose compose = new UsuarioMembershipCompose();
            compose.Usuario = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { IdUsuario = id }).FirstOrDefault();
            compose.MembershipUser = Membership.GetUser(compose.Usuario.NombreUsuario);
            //trae los roles
            compose.Roles = new List<RoleResult>();
            string[] rolesName = Roles.GetRolesForUser(compose.Usuario.NombreUsuario);
            foreach (string roleName in rolesName)
            {
                RoleResult role = new RoleResult() { RoleName = roleName, Selected = true };
                role.OLD = role.Clone();
                compose.Roles.Add(role);
            }
            //retorna el compose
            return compose;
        }
        public override List<UsuarioMembershipCompose> GetByIds(int[] ids)
        {
            throw new NotImplementedException();
        }
        public override ListPaged<UsuarioMembershipCompose> GetList()
        {
            throw new NotImplementedException();
        }
        public override void Add(List<UsuarioMembershipCompose> entities, IContextUser contextUser)
        {
            foreach (UsuarioMembershipCompose entity in entities)
                Add(entity, contextUser);
        }
        public override void Add(UsuarioMembershipCompose entity, IContextUser contextUser)
        {
            try
            {
                //Crea el usuario
                Usuario usuario = entity.Usuario.ToEntity();
                UsuarioBusiness.Current.Add(usuario, contextUser);
                entity.Usuario.IdUsuario = usuario.IdUsuario;
                //Crea el usuario en membership
                MembershipCreateStatus status;
                MembershipUser newMembershipUser = Membership.CreateUser(entity.Usuario.NombreUsuario, entity.NewPassword, entity.MembershipUser.Email, null, null, entity.Usuario.Activo, out status);
                DataHelper.Validate(status == MembershipCreateStatus.Success, Enum.GetName(typeof(MembershipCreateStatus), status));
                //agrega roles
                string[] rolesAsignar = (from o in entity.Roles where o.Selected == true select o.RoleName).ToArray();
                if (rolesAsignar.Length > 0)
                    Roles.AddUserToRoles(entity.Usuario.NombreUsuario, rolesAsignar);
            }
            catch (Exception exception)
            {
                entity.Usuario.IdUsuario = 0;
                throw exception;
            }
        }
        public override void Update(List<UsuarioMembershipCompose> entities, IContextUser contextUser)
        {
            foreach (UsuarioMembershipCompose entity in entities)
                Update(entity, contextUser);
        }
        public override void Update(UsuarioMembershipCompose entity, IContextUser contextUser)
        {
            try
            {
                //actualiza el usuario
                Usuario usuario = entity.Usuario.ToEntity();
                UsuarioBusiness.Current.Update(usuario, contextUser);
                //actualiza el usuario en membership
                //Membership.UpdateUser(entity.MembershipUser);
                MembershipUser memebershipUser = entity.MembershipUser;

                memebershipUser = new MembershipUser(Membership.Provider.Name, entity.Usuario.NombreUsuario, memebershipUser.ProviderUserKey,
                                                     memebershipUser.Email, memebershipUser.PasswordQuestion, memebershipUser.Comment, entity.Usuario.Activo,
                                                     !entity.Usuario.Activo, memebershipUser.CreationDate, memebershipUser.LastLoginDate,
                                                     memebershipUser.LastActivityDate, memebershipUser.LastPasswordChangedDate, memebershipUser.LastLockoutDate);
                Membership.UpdateUser(memebershipUser);
                string KeyUser = memebershipUser.ProviderUserKey.ToString();

                //cambia la password
                if (entity.NewPassword != null && entity.NewPassword.Trim() != string.Empty)
                {
                    string oldPassword = memebershipUser.ResetPassword();
                    memebershipUser.ChangePassword(oldPassword, entity.NewPassword);
                }
                //actualiza roles
                string[] rolesDesasignar = (from o in entity.Roles where o.OLD.Selected == true && o.Selected == false select o.RoleName).ToArray();
                string[] rolesAsignar = (from o in entity.Roles where o.OLD.Selected == false && o.Selected == true select o.RoleName).ToArray();
                if (rolesDesasignar.Length > 0)
                    Roles.RemoveUserFromRoles(entity.Usuario.NombreUsuario, rolesDesasignar);
                if (rolesAsignar.Length > 0)
                    Roles.AddUserToRoles(entity.Usuario.NombreUsuario, rolesAsignar);

                entity.MembershipUser = memebershipUser;
                SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
                Singletons.COUNT_CHANGES = 0;
            }
            catch (MembershipException exception)
            {
                throw new ValidationException(exception.Message);
            }
            catch (ProviderException exception)
            {
                throw new ValidationException(exception.Message);
            }
            catch (Exception exception)
            {
                throw exception;
            }

        }
        public override List<UsuarioMembershipCompose> Copies(UsuarioFilter filter, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override void Delete(UsuarioMembershipCompose entity, IContextUser contextUser)
        {
            try
            {
                string[] rolesDesasignar = (from o in entity.Roles where o.OLD.Selected == true select o.RoleName).ToArray();
                if (rolesDesasignar.Length > 0)
                    Roles.RemoveUserFromRoles(entity.Usuario.NombreUsuario, rolesDesasignar);
                Membership.DeleteUser(entity.Usuario.NombreUsuario);
                UsuarioBusiness.Current.Delete(entity.Usuario.IdUsuario, contextUser);
            }
            catch (MembershipException exception)
            {
                throw new ValidationException(exception.Message);
            }
            catch (ProviderException exception)
            {
                throw new ValidationException(exception.Message);
            }
            catch (Exception exception)
            {
                throw exception;
            }
        }
        public override void Delete(List<UsuarioMembershipCompose> entities, IContextUser contextUser)
        {
            foreach (UsuarioMembershipCompose entity in entities)
                Delete(entity, contextUser);
        }
        public override void Delete(int id, IContextUser contextUser)
        {
            UsuarioMembershipCompose compose = this.GetById(id);
            Delete(compose, contextUser);
        }
        public override void Delete(int[] ids, IContextUser contextUser)
        {
            foreach (int id in ids)
                Delete(id, contextUser);
        }
        public override UsuarioMembershipCompose FirstOrDefault(UsuarioFilter filter)
        {
            throw new NotImplementedException();
        }
        public override ListPaged<UsuarioMembershipCompose> GetList(UsuarioFilter filter)
        {
            throw new NotImplementedException();
        }
        public override ListPaged<UsuarioResult> GetResult()
        {
            return UsuarioBusiness.Current.GetResult();
        }
        public override ListPaged<UsuarioResult> GetResult(UsuarioFilter filter)
        {
            return UsuarioBusiness.Current.GetResult(filter);
        }
        public override void Delete(UsuarioFilter filter, IContextUser contextUser)
        {
            UsuarioBusiness.Current.Delete(filter, contextUser);
        }
        public override UsuarioMembershipCompose Copy(UsuarioMembershipCompose entity, IContextUser contextUser)
        {
            throw new NotImplementedException();
        }
        public override void Validate(UsuarioMembershipCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            UsuarioBusiness.Current.Validate(entity.Usuario.ToEntity(), actionName, contextUser, args);
        }
        public override bool Can(UsuarioMembershipCompose entity, string actionName, IContextUser contextUser,Hashtable args)
        {
            return UsuarioBusiness.Current.Can(entity.Usuario, actionName, contextUser, args);
        }
    } 
   
    public class UsuarioBusiness : _UsuarioBusiness 
    {   
	   #region Singleton
	   private static volatile UsuarioBusiness current;
	   private static object syncRoot = new Object();

	   //private UsuarioBusiness() {}
	   public static UsuarioBusiness Current
	   {
		  get 
		  {
			 if (current == null) 
			 {
				lock (syncRoot) 
				{
				   if (current == null) 
					   current = new UsuarioBusiness();
				}
			 }
			 return current;
		  }
	   }
	   #endregion

       public override Usuario GetNew()
       {
           Usuario usuario=  base.GetNew();
           usuario.Activo = true;
           return usuario; 
       }

       public virtual UsuarioResult GetResultById(int id)
       {
           return GetResult(new UsuarioFilter() { IdUsuario = id }).FirstOrDefault();
       }

       public string GetPerfilUser(string username)
       {
           UsuarioResult usuarioResult = GetResult(new UsuarioFilter() { NombreUsuario = username }).FirstOrDefault();
           UsuarioPerfilResult usuarioPerfilResul = new UsuarioPerfilBusiness().GetResult(new UsuarioPerfilFilter() { IdUsuario = usuarioResult.IdUsuario }).FirstOrDefault();
           PerfilResult perfilResult = new PerfilBusiness().GetResult(new PerfilFilter() { IdPerfil = usuarioPerfilResul.IdPerfil }).FirstOrDefault();

           return perfilResult.Codigo;
       }
    }
}
