using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class PrestamoProductosCompose
    {
        public PrestamoResult Prestamo { get; set; }
        public Int32 IdPrestamo
        {
            get { return Prestamo != null ? Prestamo.IdPrestamo : 0; }
        }
        public List<PrestamoProductoResult> Productos = new List<PrestamoProductoResult>();
    }
} 
