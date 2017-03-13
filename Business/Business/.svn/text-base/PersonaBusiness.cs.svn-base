using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract;
using DataAccess;
using Business.Base;
using System.Collections;

namespace Business
{
    public class PersonaBusiness : _PersonaBusiness
    {
        #region Singleton
        private static volatile PersonaBusiness current;
        private static object syncRoot = new Object();

        //private PersonaBusiness() {}
        public static PersonaBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PersonaBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        public override void Validate(Persona entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            // base.Validate(entity, actionName, contextUser);
            switch (actionName)
            {
                case ActionConfig.CREATE:
                case ActionConfig.UPDATE:
                    if (actionName != ActionConfig.CREATE)
                    {
                        DataHelper.Validate(entity.IdPersona != default(int), "InvalidField", "Persona");
                    }
                    DataHelper.Validate(entity.Nombre != null, "FiledIsNull", "Nombre");
                    DataHelper.Validate(entity.Nombre.Trim().Length <= 70, "FiledInvalidLength", "Nombre");
                    DataHelper.Validate(entity.Apellido != null, "FiledIsNull", "Apellido");
                    DataHelper.Validate(entity.Apellido.Trim().Length <= 70, "FiledInvalidLength", "Apellido");
                    DataHelper.Validate(entity.Sexo != null, "FiledIsNull", "Sexo");
                    DataHelper.Validate(entity.Sexo.Trim().Length <= 1, "FiledInvalidLength", "Sexo");
                    DataHelper.Validate(entity.EnviarEMail == false || (entity.EMailLaboral != null && entity.EMailLaboral.Trim() != string.Empty), "InvalidField", "EMail Laboral");
                    DataHelper.Validate(entity.EsContacto == true || entity.EsUsuario == true, "Debe seleccionar al menos una opcion de Contacto ó Usuario");

                    break;
                case ActionConfig.READ:
                case ActionConfig.DELETE:
                    DataHelper.Validate(entity.IdPersona != default(int), "InvalidField", "Persona");

                    break;
            }
        }
        public override void Add(Persona entity, IContextUser contextUser)
        {
            entity.FechaAlta = DateTime.Now;
            entity.FechaUltMod = DateTime.Now;
            base.Add(entity, contextUser);
        }
        public override void Update(Persona entity, IContextUser contextUser)
        {
            entity.FechaUltMod = DateTime.Now;
            base.Update(entity, contextUser);
            SingletonsBusiness.COUNT_CHANGES += Singletons.COUNT_CHANGES;
            Singletons.COUNT_CHANGES = 0;
        }

        public override Persona GetNew()
        {
            Persona persona = base.GetNew();
            persona.Activo = true;
            persona.Sexo = "M";
            persona.EsUsuario = true;
            persona.EsContacto = true; //Matias 20131203 - Tarea 87 - Tildar EsContacto x defecto.
            return persona;
        }
        public override void Delete(int id, IContextUser contextUser)
        {
            UsuarioOficinaPerfilBusiness.Current.Delete(new UsuarioOficinaPerfilFilter() { IdUsuario = id }, contextUser);
            UsuarioPerfilBusiness.Current.Delete(new UsuarioPerfilFilter() { IdUsuario = id }, contextUser);
            UsuarioBusiness.Current.Delete(new UsuarioFilter() { IdUsuario = id }, contextUser);
            base.Delete(id, contextUser);
        }

    }

    public class PersonaComposeBusiness : EntityComposeBusiness<PersonaCompose, Persona, PersonaFilter, PersonaResult, int>
    {
        #region Singleton
        private static volatile PersonaComposeBusiness current;
        private static object syncRoot = new Object();
        public static PersonaComposeBusiness Current
        {
            get
            {
                if (current == null)
                {
                    lock (syncRoot)
                    {
                        if (current == null)
                            current = new PersonaComposeBusiness();
                    }
                }
                return current;
            }
        }
        #endregion

        protected override EntityBusiness<Persona, PersonaFilter, PersonaResult, int> EntityBusinessBase
        {
            get { return PersonaBusiness.Current; }
        }
        #region Gets
        public override PersonaCompose GetNew(PersonaResult example)
        {
            PersonaCompose compose = base.GetNew();
            compose.Persona = example;
            compose.Usuario = new UsuarioResult();
            UsuarioBusiness.Current.Set(UsuarioBusiness.Current.GetNew(), compose.Usuario, false);
            compose.UsuarioOficinaPerfiles = new List<UsuarioOficinaPerfilResult>();
            compose.UsuarioPerfiles = ToUsuarioPerfil(PerfilBusiness.Current.GetResult(new PerfilFilter() { IdPerfilTipo = (short)PerfilTipoEnum.Sistema }), compose.Usuario);

            return compose;
        }
        public override PersonaCompose GetNew()
        {
            PersonaResult example = new PersonaResult();
            example.Activo = true;
            PersonaBusiness.Current.Set(PersonaBusiness.Current.GetNew(), example);
            return GetNew(example);
        }
        public override int GetId(PersonaCompose entity)
        {
            return entity.Persona.IdPersona;
        }
        public override PersonaCompose GetById(int id)
        {
            PersonaCompose compose = new PersonaCompose();
            compose.Persona = PersonaBusiness.Current.GetResult(new PersonaFilter() { IdPersona = id }).FirstOrDefault();
            compose.Usuario = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { IdUsuario = id }).FirstOrDefault();
            compose.UsuarioOficinaPerfiles = UsuarioOficinaPerfilBusiness.Current.GetResult(new UsuarioOficinaPerfilFilter() { IdUsuario = id });
            //obtiene los permisos asociados y los que no estan asociados
            List<PerfilResult> perfiles = PerfilBusiness.Current.GetResult(new PerfilFilter() { IdPerfilTipo = (short)PerfilTipoEnum.Sistema });
            List<UsuarioPerfilResult> perfilUsuario = UsuarioPerfilBusiness.Current.GetResult(new UsuarioPerfilFilter() { IdUsuario = id });
            //Matias 20131210 - Tarea 98
            /*
              List<UsuarioPerfilResult> unselected = (from a in perfiles 
                                                      where !(from pa in perfilUsuario  select pa.IdPerfil).Contains(a.IdPerfil)
                                                      && a.IdPerfilTipo == (short)PerfilTipoEnum.Sistema 
                                                      select ToUsuarioPerfiles(a, compose.Usuario)).ToList();
              perfilUsuario.AddRange(unselected);
              compose.UsuarioPerfiles = perfilUsuario ;
              return compose;
            */
            List<UsuarioPerfilResult> unselected;
            if (compose.Usuario != null)
            {
                unselected = (from a in perfiles
                              where !(from pa in perfilUsuario select pa.IdPerfil).Contains(a.IdPerfil)
                              && a.IdPerfilTipo == (short)PerfilTipoEnum.Sistema
                              select ToUsuarioPerfiles(a, compose.Usuario)).ToList();
                perfilUsuario.AddRange(unselected);
                compose.UsuarioPerfiles = perfilUsuario;
            }
            else
            {
                compose.Usuario = new UsuarioResult();
                UsuarioBusiness.Current.Set(UsuarioBusiness.Current.GetNew(), compose.Usuario, false);
                compose.UsuarioOficinaPerfiles = new List<UsuarioOficinaPerfilResult>();
                compose.UsuarioPerfiles = ToUsuarioPerfil(PerfilBusiness.Current.GetResult(new PerfilFilter() { IdPerfilTipo = (short)PerfilTipoEnum.Sistema }), compose.Usuario);
            }
            return compose;
            //FinMatias 20131210 - Tarea 98

        }
        #endregion

        #region Actions
        public override void Add(PersonaCompose entity, IContextUser contextUser)
        {
            try
            {


                //Crea el usuario
                Persona persona = entity.Persona.ToEntity();
                PersonaBusiness.Current.Add(persona, contextUser);
                entity.Persona.IdPersona = persona.IdPersona;

                if (entity.Persona.EsUsuario)
                {
                    //Crea el usuario
                    if (!entity.Persona.Activo)
                        entity.Usuario.Activo = false;
                    entity.Usuario.IdUsuario = entity.Persona.IdPersona;
                    Usuario usuario = entity.Usuario.ToEntity();
                    UsuarioBusiness.Current.Add(usuario, contextUser);
                    entity.Usuario.IdUsuario = usuario.IdUsuario;

                    //Crea UsuarioOficinaPerfil 
                    foreach (UsuarioOficinaPerfilResult uopr in entity.UsuarioOficinaPerfiles)
                    {
                        uopr.IdUsuario = entity.Usuario.IdUsuario;
                        UsuarioOficinaPerfil uop = uopr.ToEntity();
                        UsuarioOficinaPerfilBusiness.Current.Add(uop, contextUser);
                        uopr.IdUsuarioOficinaPerfil = uop.IdUsuarioOficinaPerfil;
                    }

                    //Crea UsuarioPerfil

                    foreach (UsuarioPerfilResult perfil in entity.UsuarioPerfiles)
                    {
                        if (perfil.Selected && perfil.IdUsuarioPerfil < 1)
                        {
                            UsuarioPerfil usuarioPerfil = UsuarioPerfilBusiness.Current.GetNew();
                            usuarioPerfil.IdPerfil = perfil.IdPerfil;
                            usuarioPerfil.IdUsuario = entity.Usuario.IdUsuario;
                            UsuarioPerfilBusiness.Current.Add(usuarioPerfil, contextUser);
                            perfil.IdUsuarioPerfil = usuarioPerfil.IdUsuarioPerfil;
                        }
                    }
                }
            }
            catch (Exception exception)
            {
                entity.Persona.IdPersona = 0;
                entity.Usuario.IdUsuario = 0;
                entity.UsuarioOficinaPerfiles.ForEach(i => i.IdUsuario = 0);
                entity.UsuarioPerfiles.ForEach(i => i.IdUsuario = 0);
                throw exception;
            }

        }
        public override void Update(PersonaCompose entity, IContextUser contextUser)
        {
            List<UsuarioOficinaPerfilResult> copy = UsuarioOficinaPerfilBusiness.Current.CopiesResult(entity.UsuarioOficinaPerfiles);
            try
            {
                Persona persona = PersonaBusiness.Current.GetById(entity.Persona.IdPersona);
                PersonaBusiness.Current.Set(entity.Persona, persona);
                PersonaBusiness.Current.Update(persona, contextUser);

                if (entity.Persona.EsUsuario)
                {
                    if (!entity.Persona.Activo)
                        entity.Usuario.Activo = false;
                    if (entity.Usuario.IdUsuario <= 0)
                    {
                        entity.Usuario.IdUsuario = entity.Persona.IdPersona;
                        Usuario usuario = entity.Usuario.ToEntity();
                        UsuarioBusiness.Current.Add(usuario, contextUser);
                    }
                    else
                    {
                        Usuario Usuario = UsuarioBusiness.Current.GetById(entity.Usuario.IdUsuario);
                        UsuarioBusiness.Current.Set(entity.Usuario, Usuario);
                        UsuarioBusiness.Current.Update(Usuario, contextUser);
                    }
                    //actualiza UsuarioOficinaPerfil

                    //Elimino los que ya no forman parte
                    List<int> actualIds = (from o in entity.UsuarioOficinaPerfiles where o.IdUsuarioOficinaPerfil > 0 select o.IdUsuarioOficinaPerfil).ToList();
                    List<UsuarioOficinaPerfil> oldDetail = UsuarioOficinaPerfilBusiness.Current.GetList(new UsuarioOficinaPerfilFilter() { IdUsuario = entity.Usuario.IdUsuario });
                    List<UsuarioOficinaPerfil> deletets = (from o in oldDetail where !actualIds.Contains(o.IdUsuarioOficinaPerfil) select o).ToList();
                    UsuarioOficinaPerfilBusiness.Current.Delete(deletets, contextUser);

                    foreach (UsuarioOficinaPerfilResult uopr in entity.UsuarioOficinaPerfiles)
                    {

                        if (uopr.IdUsuario < 1)
                        {
                            UsuarioOficinaPerfil uop = uopr.ToEntity();
                            //Agrego los nuevos
                            uop.IdUsuario = entity.Usuario.IdUsuario;
                            UsuarioOficinaPerfilBusiness.Current.Add(uop, contextUser);
                            uopr.IdUsuarioOficinaPerfil = uop.IdUsuarioOficinaPerfil;
                        }
                        else
                        {
                            UsuarioOficinaPerfil uop = uopr.ToEntity();
                            uop.IdOficina = uopr.IdOficina;
                            uop.IdPerfil = uopr.IdPerfil;
                            uop.IdUsuario = entity.Usuario.IdUsuario;
                            UsuarioOficinaPerfilBusiness.Current.Update(uop, contextUser);
                        }

                    }
                    foreach (UsuarioPerfilResult usuarioPerfilResult in entity.UsuarioPerfiles)
                    {
                        if (usuarioPerfilResult.Selected && usuarioPerfilResult.IdUsuarioPerfil < 1)
                        {
                            UsuarioPerfil usuarioPerfil = UsuarioPerfilBusiness.Current.GetNew();
                            usuarioPerfil.IdPerfil = usuarioPerfilResult.IdPerfil;
                            //Matias 20131213 - Tarea 99
                            //usuarioPerfil.IdUsuario =  usuarioPerfilResult.IdUsuario ;
                            usuarioPerfil.IdUsuario = entity.Usuario.IdUsuario;
                            //FinMatias 20131213 - Tarea 99
                            UsuarioPerfilBusiness.Current.Add(usuarioPerfil, contextUser);
                            usuarioPerfilResult.IdUsuarioPerfil = usuarioPerfil.IdUsuarioPerfil;
                        }
                        if (!usuarioPerfilResult.Selected && usuarioPerfilResult.IdUsuarioPerfil > 1)
                        {
                            UsuarioPerfilBusiness.Current.Delete(usuarioPerfilResult.IdUsuarioPerfil, contextUser);
                        }
                    }

                }
                else
                {
                    //Busco los usuarios asociados y los elimino
                    //Matias 20131210 - Tarea 99
                    /* 
                    * Falta eliminar los registros de la tabla UsuarioPerfil (asociados al usuario a eliminar).
                     * * 
                     * +Tablas a limpiar: deberia limpiar todas las tablas que tengan referencias a "Usuario.IdUsuario"
                     * SistemaReporteHistorico
                    */
                    ProyectoOficinaPerfilFuncionarioBusiness.Current.Delete(new ProyectoOficinaPerfilFuncionarioFilter() { IdUsuario = entity.Persona.IdPersona }, contextUser);
                    UsuarioPerfilBusiness.Current.Delete(new UsuarioPerfilFilter() { IdUsuario = entity.Persona.IdPersona }, contextUser);
                    //FinMatias 20131210 - Tarea 99
                    UsuarioOficinaPerfilBusiness.Current.Delete(new UsuarioOficinaPerfilFilter() { IdUsuario = entity.Persona.IdPersona }, contextUser);
                    UsuarioBusiness.Current.Delete(new UsuarioFilter() { IdUsuario = entity.Persona.IdPersona }, contextUser);
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
        public override void Delete(PersonaCompose entity, IContextUser contextUser)
        {
            PersonaBusiness.Current.Delete(entity.Persona.IdPersona, contextUser);
        }
        #endregion

        #region protected Methods

        #endregion

        #region Validations
        public override void Validate(PersonaCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            base.Validate(entity, actionName, contextUser, args);
            PersonaBusiness.Current.Validate(PersonaBusiness.Current.ToEntity(entity.Persona), actionName, contextUser, args);
            if (entity.Persona.EsUsuario)
            {
                UsuarioBusiness.Current.Validate(UsuarioBusiness.Current.ToEntity(entity.Usuario), actionName, contextUser, args);
                DataHelper.Validate(!string.IsNullOrEmpty(entity.Usuario.NombreUsuario), "Debe completar el Nombre de Usuario");
                DataHelper.Validate(!string.IsNullOrEmpty(entity.Usuario.Clave), "Debe completar la Clave");
                //Matias 20170206 - Ticket #ER804897
                if (!string.IsNullOrEmpty(entity.Usuario.NombreUsuario))
                {
                    //UsuarioResult usuarioResult = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { NombreUsuario = entity.Usuario.NombreUsuario }).FirstOrDefault();
                    //if (usuarioResult != null && usuarioResult.IdUsuario != entity.Usuario.IdUsuario)
                    //{
                    //    DataHelper.Validate(!usuarioResult.NombreUsuario.Equals(entity.Usuario.NombreUsuario), "Nombre de Usuario existente");
                    //}
                    List<UsuarioResult> usuariosResult = UsuarioBusiness.Current.GetResult(new UsuarioFilter() { NombreUsuario = entity.Usuario.NombreUsuario });
                    foreach (UsuarioResult usuarioResult in usuariosResult)
                    {
                        if (usuarioResult.IdUsuario != entity.Usuario.IdUsuario)
                        {
                            DataHelper.Validate(!usuarioResult.NombreUsuario.Equals(entity.Usuario.NombreUsuario), "Nombre de Usuario existente");
                        }
                    }
                }
                //FinMatias 20170206 - Ticket #ER804897
            }
            else
            {
                DataHelper.Validate(entity.Persona.EsContacto, "Debe ser Contacto, Usuario o ambos.");
            }
            if (entity.Persona.EnviarNota.HasValue && entity.Persona.EnviarNota.Value)
                DataHelper.Validate(entity.Persona.Domicilio != null && entity.Persona.CodPostal != null && entity.Persona.IdClasificacionGeografica != null, "Al estar chequeada la opción Enviar Nota, los campos Domicilio, Código Postal y Alcance Geográfico son obligatorios'");
            if (entity.Persona.EnviarEMail.HasValue && entity.Persona.EnviarEMail.Value)
                DataHelper.Validate(entity.Persona.EMailLaboral != null, "Al estar chequeada la opción Enviar Mail, el campo e-mail Laboral es obligatorio'");

        }

        public override bool Can(PersonaCompose entity, string actionName, IContextUser contextUser, Hashtable args)
        {
            if (entity.Persona.EsUsuario)
                return UsuarioBusiness.Current.Can(UsuarioBusiness.Current.ToEntity(entity.Usuario), actionName, contextUser, args);
            return PersonaBusiness.Current.Can(PersonaBusiness.Current.ToEntity(entity.Persona), actionName, contextUser, args);

        }
        #endregion

        #region protected Methods
        protected List<UsuarioPerfilResult> ToUsuarioPerfil(List<PerfilResult> perfiles, UsuarioResult usuario)
        {
            List<UsuarioPerfilResult> target = new List<UsuarioPerfilResult>(perfiles.Count);
            foreach (PerfilResult perfil in perfiles)
                target.Add(ToUsuarioPerfiles(perfil, usuario));
            return target;
        }
        protected UsuarioPerfilResult ToUsuarioPerfiles(PerfilResult perfil, UsuarioResult usuario)
        {
            UsuarioPerfilResult target = new UsuarioPerfilResult();
            target.IdPerfil = perfil.IdPerfil;
            target.IdUsuario = usuario.IdUsuario;
            target.Selected = false;
            target.Perfil_Nombre = perfil.Nombre;
            return target;
        }
        #endregion
    }

}
