using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using Business;
using Contract;

namespace Service
{
    public class ServiceHelper
    {
        public static void Validate(bool condition, string errorMessage)
        {
            if (!condition)
                throw new ValidationException(errorMessage);                
        }
        public static void ReloadContext()
        {
            BusinessHelper.ReloadContext();
        }

    }
}
