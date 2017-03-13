using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class JurisdiccionResult : _JurisdiccionResult
    {
        public string CodigoNombre
        {
            get
            {
                return String.Format("{0}-{1}", Codigo, Nombre);
            }
        }
        public Int32 CodigoInt
        {
            get
            {
                Int32 cod ;
                if (Int32.TryParse(Codigo, out  cod))
                    return cod;
                else
                    return 0;
            }
        }
    }
}
