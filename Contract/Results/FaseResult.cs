using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class FaseResult : _FaseResult
    {
        public string Descripcion
        {
            get
            {
                return "Fase " + this.Codigo + ": " + this.Nombre;
            }
        }
    }
}
