using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Security;
using System.Xml.Serialization;

namespace Contract
{
    [Serializable]
    public class ProgramaCompose
    {

        public int IdPrograma { get; set; }
        public ProgramaResult Programa { get; set; }

        private List<SubProgramaResult> subProgramas;
        public List<SubProgramaResult> SubProgramas
        {
            get
            {
                if (subProgramas == null)
                    subProgramas = new List<SubProgramaResult>();
                return subProgramas;
            }
            set { subProgramas = value; }
        }

    }
}
