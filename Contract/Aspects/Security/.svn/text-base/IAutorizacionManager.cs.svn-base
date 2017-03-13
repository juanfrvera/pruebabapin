using System;
using System.Collections.Generic;
using System.Security.Principal;
namespace Contract
{
    public interface IAutorizacionManager
    {
        bool Authorize(IPrincipal principal, string rule);
        string[] AutorizarContenedor(IPrincipal principal, string containerName);
        List<string[]> AutorizarItemsContenedor(IPrincipal principal, string ruleName);
        List<string[]> AutorizarTodoContenedor(IPrincipal principal);
        void ShowError(string message);
    }
}
