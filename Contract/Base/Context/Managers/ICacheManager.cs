using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Contract
{
    public interface ICacheBySessionManager
    {
        object this[string name] { get; set; }
    }
    public interface ICacheByApplicationManager
    {
        object this[string name] { get; set; }
    }
}
