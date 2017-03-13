using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class MessageSendFilter : _MessageSendFilter
    {


        #region Private
        private string _Subject;
        #endregion
        #region Properties
        public int? IdMessage { get; set; }
        public int? IdUserFrom { get; set; }
        public int? IdPriority { get; set; }
        public string Subject
        {
            get
            {
                if (_Subject == null) _Subject = string.Empty;
                return _Subject;
            }
            set { _Subject = value; }
        }
        public DateTime? StartDate { get; set; }
        public DateTime? StartDate_To { get; set; }
        public bool? SendDateIsNull { get; set; }public DateTime? SendDate { get; set; }
        public DateTime? SendDate_To { get; set; }
        public bool? IsManual { get; set; }
        public bool? IsRecibido { get; set; }
        public bool? IdProyectoIsNull { get; set; }public int? IdProyecto { get; set; }
        #endregion

        /// <summary>
        /// Solo para visualizacion NO PARA FILTRO
        /// </summary>
        public string UserFrom_NombreCompleto { get; set; }
        /// <summary>
        /// Solo para visualizacion NO PARA FILTRO
        /// </summary>
        public string UserTo_NombreCompleto { get; set; }
        /// <summary>
        /// Solo para visualizacion NO PARA FILTRO
        /// </summary>
        public string Project_Denominacion { get; set; }
        public int? Project_Codigo { get; set; }


        public int? UsuarioBandeja { get; set; }
        public bool? EsPrimeraEjecucion { get; set; } //No llega a la capa de datos
    }
}
