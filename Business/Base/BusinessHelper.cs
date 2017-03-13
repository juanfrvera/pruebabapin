using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ServiceModel;
using DataAccess;
using Contract;

namespace Business
{
    public class BusinessHelper
    {
        public static void Validate(bool condition, string errorMessage)
        {
            if (!condition)
                throw new ValidationException(errorMessage);
        }
        public static void ReloadContext()
        {
            LinqUtility.ReloadContext();
        }

    }
}
