using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using System.Web;
using Contract;

namespace UI.Web.Services
{
    [ServiceContract]//(SessionMode = SessionMode.Allowed)
    interface IBapin
    {
        [OperationContract(Action = "*", ReplyAction = "*")]
        List<BapinResult> GetAllBapines(
            RequestMessage request
            );
    }
}

