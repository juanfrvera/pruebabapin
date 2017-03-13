using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoOficinaFuncionarioFilter : _PrestamoOficinaFuncionarioFilter
    {
        public Int32? IdPrestamo { get; set; }
    }
}
