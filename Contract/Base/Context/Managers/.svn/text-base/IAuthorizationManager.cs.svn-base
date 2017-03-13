using System;
using Contract;
using System.Collections.Generic;
namespace Contract
{
    public interface IAuthorizationManager: IRefresh 
    {
        bool Authorize(IContextUser contextUser, string permisionCode);
        bool Authorize(List<List<PermisoSimpleResult>> permisosByPerfiles, string permisionCode);

        bool AuthorizeByType(IContextUser contextUser, string typeName);
        bool AuthorizeByType(IContextUser contextUser, string typeName, string actionName);
        bool AuthorizeByType(IContextUser contextUser, string typeName, string actionName, int? idEstado);
        bool AuthorizeByType(List<List<PermisoSimpleResult>> perfiles, string typeName, string actionName, int? idEstado);

        bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina);
        bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina, string actionName);
        bool AuthorizeByOffice(IContextUser contextUser, string typeName, int idOficina, string actionName, int? idEstado);
        bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas);
        bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas, string actionName);
        bool AuthorizeByOffice(IContextUser contextUser, string typeName, List<PerfilOficina> perfilOficinas, string actionName, int? idEstado);
        
        string[] GetOptions(IContextUser contextUser, string containerName);
        string[] GetOptions(List<List<PermisoSimpleResult>> perfiles, string containerName);

       // void Refresh();
    }
}
