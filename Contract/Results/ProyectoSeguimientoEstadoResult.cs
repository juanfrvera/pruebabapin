using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class ProyectoSeguimientoEstadoResult : _ProyectoSeguimientoEstadoResult
    {
        public bool GeneraComentarioTecnico { get; set; }
        public bool EnviarMensaje { get; set; }
        public string Persona_Apellido{ get; set; }
        public string Persona_Nombre { get; set; }
        public string Persona_ApellidoYNombre
        {
            get
            {
                return String.Format("{0} {1}", Persona_Apellido, Persona_Nombre);
            }
        }
        
    }
}
