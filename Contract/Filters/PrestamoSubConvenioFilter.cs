using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class PrestamoSubConvenioFilter : _PrestamoSubConvenioFilter
    {
        private List<int> idsPrestamoConvenio;
        public List<int> IdsPrestamoConvenio
        {
            get
            {
                if (idsPrestamoConvenio == null) idsPrestamoConvenio = new List<int>();
                return idsPrestamoConvenio;
            }
            set { idsPrestamoConvenio = value; }
        }
    }
}
