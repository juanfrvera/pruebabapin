using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PerfilOficina
    {
        public int IdOficina { get; set; }
        public int IdPerfil { get; set; }
        public string Oficina_BreadcrumbId { get; set; }
    }
    [Serializable]
    public class UsuarioPerfilOficina
    {
        public int IdOficina { get; set; }
        public int IdPerfil { get; set; }
        public int IdUsuarioPerfil { get; set; }
        public bool UsuarioAccesoTotal { get; set; }
    }

	[Serializable]
    public class UsuarioOficinaPerfilResult : _UsuarioOficinaPerfilResult
    {
        public bool AgregadoPorDefault { get; set; }
    }

    [Serializable]
    public class UsuarioOficinaPerfilSimpleResult : IResult<int>
    {
        public virtual int ID { get { return IdUsuarioOficinaPerfil; } }
        public int IdUsuarioOficinaPerfil { get; set; }
        public int IdUsuario { get; set; }
        public int IdOficina { get; set; }
        public int IdPerfil { get; set; }
        public bool Activo { get; set; }
        public bool HeredaConsulta { get; set; }
        public bool HeredaEdicion { get; set; }
        public bool AccesoTotal { get; set; }

        public string Oficina_Nombre { get; set; }
        public string Oficina_BreadcrumbId { get; set; }        
        public string Perfil_Nombre { get; set; }
        public string Perfil_Codigo { get; set; } //Matias 20161202
        public bool AgregadoPorDefault { get; set; }

        public virtual DataTableMapping ToMapping()
        {
            throw new NotImplementedException();
        }
    }
}
