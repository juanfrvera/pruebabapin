using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
    [Serializable]
    public class ObjetivoSupuestoFilter : _ObjetivoSupuestoFilter
    {
        private List<int> idsObjetivos;
        public List<int> IdsObjetivos
        {
            get {
                if (idsObjetivos == null) idsObjetivos = new List<int>();
                return idsObjetivos;
                 }
            set { idsObjetivos = value; }
        }
    }
}
