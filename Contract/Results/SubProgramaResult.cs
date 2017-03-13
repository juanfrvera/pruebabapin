using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class SubProgramaResult : _SubProgramaResult
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
                Int32 codigo;
                if (Int32.TryParse(Codigo, out codigo))
                    return codigo;
                else
                {
                    return 0;
                }
            }
        }
    }
}
