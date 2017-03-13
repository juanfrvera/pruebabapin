using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Contract.Base;
namespace Contract
{
	[Serializable]
    public class LanguageResult : _LanguageResult
    {
        public List<int> idActions =new List<int>(new int[]{16,17,18,19,20});

        public string IdActions
        {
            get { return string.Join(",", (from o in idActions select o.ToString()).ToArray()); }
        }
    }
}
