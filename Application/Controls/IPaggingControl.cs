using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Contract;

namespace UI.Web
{
    public interface IPaggingControl
    {
        Paged GetPagging();
        void LoadPagging();
        void ResetPagging();
        Paged Pagging{get;set;}

    }
}



