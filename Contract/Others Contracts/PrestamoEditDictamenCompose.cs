using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class PrestamoEditDictamenCompose
    {
        public PrestamoResult Prestamo { get; set; }
        public Int32 IdPrestamo
        {
            get { return Prestamo != null ? Prestamo.IdPrestamo : 0; }
        }
        public List<PrestamoDictamenResult> Dictamenes = new List<PrestamoDictamenResult>();
        private List<ProyectoComentarioTecnicoResult> proyectoComentarioTecnico;
        public List<ProyectoComentarioTecnicoResult> ProyectoComentarioTecnico
        {
            get
            {
                if (proyectoComentarioTecnico == null)
                    proyectoComentarioTecnico = new List<ProyectoComentarioTecnicoResult>();
                return proyectoComentarioTecnico;
            }
            set { proyectoComentarioTecnico = value; }
        }

    }

    [Serializable]
    public class PrestamoDictamenCompose
    {

        public PrestamoDictamenResult Dictamen { get; set; }
        public Int32 IdPrestamoDictamen
        {
            get { return Dictamen != null ? Dictamen.IdPrestamoDictamen : 0; }
        }

        private List<PrestamoDictamenEstadoResult> estados;
        public List<PrestamoDictamenEstadoResult> Estados
        {
            get
            {
                if (estados == null)
                    estados = new List<PrestamoDictamenEstadoResult>();
                return estados;
            }
            set { estados = value; }
        }

    }

}
