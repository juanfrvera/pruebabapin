using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class UsuarioResult : IResult<int>
    {        
        public virtual int ID { get { return IdUsuario; } }
        public int IdUsuario { get; set; }
        public string NombreUsuario { get; set; }
        public string NombreCompleto { get; set; }
        public string Clave { get; set; }
        public bool Activo { get; set; }
        public bool AccesoTotal { get; set; }
        public bool EsSectioralista { get; set; }
        public int IdLanguage { get; set; }

        public string Language_Name { get; set; }
        public string Language_Code { get; set; }
        public bool Persona_EsUsuario { get; set; }
        public bool Persona_EsContacto { get; set; }
        public string Persona_Nombre { get; set; }
        public string Persona_Apellido { get; set; }
        public string Persona_NombreCompleto { get; set; }
        public int Persona_IdOficina { get; set; }
        public int? Persona_IdCargo { get; set; }
        public string Persona_Telefono { get; set; }
        public string Persona_TelefonoLaboral { get; set; }
        public string Persona_Fax { get; set; }
        public string Persona_EMailPersonal { get; set; }
        public string Persona_EMailLaboral { get; set; }
        public string Persona_CargoEspecifico { get; set; }
        public string Persona_NivelJerarquico { get; set; }
        public string Persona_Domicilio { get; set; }
        public string Persona_CodPostal { get; set; }
        public int? Persona_IdProvincia { get; set; }
        public int? Persona_IdLocalidad { get; set; }
        public string Persona_Sexo { get; set; }
        public bool? Persona_EnviarEMail { get; set; }
        public bool? Persona_EnviarNota { get; set; }
        public DateTime Persona_FechaAlta { get; set; }
        public DateTime? Persona_FechaBaja { get; set; }
        public bool Persona_Activo { get; set; }
        public DateTime Persona_FechaUltMod { get; set; }
        public int Persona_IdUsuarioUltMod { get; set; }

        public string NombreYApellido {

            get {
                return String.Format("{0} {1}", Persona_Nombre, Persona_Apellido);            
            }
        }
        public string ApellidoYNombre
        {

            get
            {
                return String.Format("{0} {1}", Persona_Apellido, Persona_Nombre);
            }
        }
        public bool Selected { get; set; }


        public virtual Usuario ToEntity()
        {
            Usuario _Usuario = new Usuario();
            _Usuario.IdUsuario = this.IdUsuario;
            _Usuario.NombreUsuario = this.NombreUsuario;
            _Usuario.Clave = this.Clave;
            _Usuario.Activo = this.Activo;
            _Usuario.EsSectioralista = this.EsSectioralista;
            _Usuario.IdLanguage = this.IdLanguage;

            return _Usuario;
        }
        public virtual void Set(Usuario entity)
        {
            this.IdUsuario = entity.IdUsuario;
            this.NombreUsuario = entity.NombreUsuario;
            this.Clave = entity.Clave;
            this.Activo = entity.Activo;
            this.EsSectioralista = entity.EsSectioralista;
            this.IdLanguage = entity.IdLanguage;

        }
        public virtual bool Equals(Usuario entity)
        {
            if (entity == null) return false;
            if (!entity.IdUsuario.Equals(this.IdUsuario)) return false;
            if (!entity.NombreUsuario.Equals(this.NombreUsuario)) return false;
            if (!entity.Clave.Equals(this.Clave)) return false;
            if (!entity.Activo.Equals(this.Activo)) return false;
            if (!entity.EsSectioralista.Equals(this.EsSectioralista)) return false;
            if (!entity.IdLanguage.Equals(this.IdLanguage)) return false;

            return true;
        }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
