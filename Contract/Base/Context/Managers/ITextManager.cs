using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public interface ITextManager: IRefresh 
    {
        string Translate(string code);
        string Translate(string code,string languageCode);
        //void Refresh();
    }
}
