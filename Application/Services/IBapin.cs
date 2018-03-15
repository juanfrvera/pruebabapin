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
        [OperationContract]
        List<BapinResult> GetAllBapines(
            RequestMessage request
            );
    }
    /*
     * 
            long ejercicio, 
            List<estadoBapinType> estado, 
            long jurisdiccion, 
            long bapin, 
            long saf, 
            List<long> programa
      bindingConfiguration="WSHttpBinding_MyService"
     */
}

