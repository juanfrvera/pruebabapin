using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Controls
{
    public interface IUserInterfaceMessage
    {
        void DisplayError(string message);
        void DisplayInfo(string message);
    }
}
