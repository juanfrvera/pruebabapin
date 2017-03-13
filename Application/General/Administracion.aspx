<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="Administracion.aspx.cs" Inherits="UI.Web.Administracion" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
     <table width="100%">
        <tr><td><div class="tablaTitulosBlanco"><asp:Literal ID="liParametrosGenerales" Text="Parametros Generales" runat="server" ></asp:Literal></div></td></tr>
    </table>   
     <table >    
        <tr>
            <td width="400px"  colspan="2" >
                <ul>
                    <li id="liCaracterEconomicoTipo"  runat="server"><asp:LinkButton ID ="btCaracterEconomicoTipo" runat = "server" OnClick="btCaracterEconomicoTipo_OnClick" Text="Tipo de Caracter Económico" ></asp:LinkButton></li>
                    <li id="liClasificacionGeograficaTipo"  runat="server"><asp:LinkButton ID ="btClasificacionGeograficaTipo" runat = "server" OnClick="btClasificacionGeograficaTipo_OnClick" Text="Tipo de Clasificación Geográfica" ></asp:LinkButton></li>
                    <li id="liFinalidadFuncionTipo"  runat="server"><asp:LinkButton ID ="btFinalidadFuncionTipo" runat = "server" OnClick="btFinalidadFuncionTipo_OnClick" Text="Tipo de Finalidad - Función" ></asp:LinkButton></li>
                </ul> 
            </td>
            <td width="400px" colspan="2" >
                <ul>
                    <li id="liClasificacionGastoTipo"  runat="server"><asp:LinkButton ID ="btClasificacionGastoTipo" runat = "server" OnClick="btClasificacionGastoTipo_OnClick" Text="Tipo de Clasificación del Gasto" ></asp:LinkButton></li>
                    <li id="liFuenteFinanciamientoTipo"  runat="server"><asp:LinkButton ID ="btFuenteFinanciamientoTipo" runat = "server" OnClick="btFuenteFinanciamientoTipo_OnClick" Text="Tipo de Fuente de Financiamiento" ></asp:LinkButton></li>
                    <li id="liMonedaCotizacion"  runat="server"><asp:LinkButton ID ="btMonedaCotizacion" runat = "server" OnClick="btMonedaCotizacion_OnClick" Text="Cotización de Moneda" ></asp:LinkButton></li>
                </ul>                   
            </td>            
        </tr>
    </table>
    <table width="100%">
        <tr><td><div class="tablaTitulosBlanco"><asp:Literal ID="liParametrosConfiguracion" Text="Parametros de Configuración" runat="server" ></asp:Literal></div></td></tr>
    </table>     
    <table >    
        <tr>
            <td width="200px"  >
                <ul>
                    <li id="liLanguage"  runat="server">
                        <asp:LinkButton ID ="btLanguage" runat = "server" OnClick="btLanguage_OnClick" Text="Lenguajes" ></asp:LinkButton>
                    </li>
                    <li id="liTextCategory"  runat="server">
                        <asp:LinkButton ID ="btTextCategory" runat = "server" OnClick="btTextCategory_OnClick" Text="Categoría de Textos" ></asp:LinkButton>
                    </li> 
                    <li id="liText"  runat="server">
                        <asp:LinkButton ID ="btText" runat = "server" OnClick="btText_OnClick" Text="Textos" ></asp:LinkButton>
                    </li>
                    <li id="liTextLanguage"  runat="server">
                        <asp:LinkButton ID ="btTextLanguage" runat = "server" OnClick="btTextLanguage_OnClick" Text="Textos Traducidos" ></asp:LinkButton>
                    </li>                
                </ul>            
            </td>
            <td width="200px" >
                <ul>
                    <li id="liNumeration"  runat="server">
                        <asp:LinkButton ID ="btNumeration" runat = "server" OnClick="btNumeration_OnClick" Text="Numeración" ></asp:LinkButton>
                    </li> 
                     <li id="liParameterCategory"  runat="server">
                        <asp:LinkButton ID ="btParameterCategory" runat = "server" OnClick="btParameterCategory_OnClick" Text="Categoría de Parametros" ></asp:LinkButton>
                    </li> 
                    <li id="liParameter"  runat="server">
                        <asp:LinkButton ID ="btParameter" runat = "server" OnClick="btParameter_OnClick" Text="Parametros" ></asp:LinkButton>
                    </li> 
                </ul>
            </td>
            <td width="200px" >
                <ul>
                    <li id="liSistemaEntidad"  runat="server">
                        <asp:LinkButton ID ="btSistemaEntidad" runat = "server" OnClick="btSistemaEntidad_OnClick" Text="Entidades" ></asp:LinkButton>
                    </li>
                    <li id="liSistemaAccion"  runat="server">
                        <asp:LinkButton ID ="btSistemaAccion" runat = "server" OnClick="btSistemaAccion_OnClick" Text="Acciones" ></asp:LinkButton>
                    </li> 
                    <li id="liEstado"  runat="server">
                        <asp:LinkButton ID ="btEstados" runat = "server" OnClick="btEstado_OnClick" Text="Estados" ></asp:LinkButton>
                    </li>
                     <li id="liConfigMensajes"  runat="server">
                        <asp:LinkButton ID ="btConfigMensajes" runat = "server" OnClick="btConfigMensajes_OnClick" Text="Configuración de mensajes" ></asp:LinkButton>
                    </li>
                   <%-- <li id="liSistemaEntidadAccion"  runat="server">
                        <asp:LinkButton ID ="btSistemaEntidadAccion" runat = "server" OnClick="btSistemaEntidadAccion_OnClick" Text="Acciones por Entidad" ></asp:LinkButton>
                    </li>
                    <li id="liSistemaEntidadEstado"  runat="server">
                        <asp:LinkButton ID ="btSistemaEntidadEstado" runat = "server" OnClick="btSistemaEntidadEstado_OnClick" Text="Estados por Entidad" ></asp:LinkButton>
                    </li>   
                     --%>            
                </ul>            
            </td>
            <td width="200px" >
                <ul>
                    <%--
                    <li id="liConfiguracion"  runat="server">
                        <asp:LinkButton ID ="btConfiguracion" runat = "server" OnClick="btConfiguracion_OnClick" Text="Configuración" ></asp:LinkButton>
                    </li>
                    <li id="liConfiguracionCategoria"  runat="server">
                        <asp:LinkButton ID ="btConfiguracionCategoria" runat = "server" OnClick="btConfiguracionCategoria_OnClick" Text="Categoría de Configuración" ></asp:LinkButton>
                    </li>
                    --%>
                     <li id="liSistemaCommand"  runat="server">
                        <asp:LinkButton ID ="btSistemaCommand" runat = "server" OnClick="btSistemaCommand_OnClick" Text="Excels desde Base de Datos" ></asp:LinkButton>
                    </li>          
                     <li id="liCacheManager"  runat="server">
                        <asp:LinkButton ID ="btCacheManager" runat = "server" OnClick="btCacheManager_OnClick" Text="Limpiar Caché" ></asp:LinkButton>
                    </li>         
                </ul>            
            </td>
        </tr>
    </table>
    <table width="100%">
        <tr><td><div class="tablaTitulosBlanco"><asp:Literal ID="liParametrosSeguridad" Text="Parametros de Seguridad" runat="server" ></asp:Literal></div></td></tr>
    </table>
    <table >    
        <tr>
            <%--
            <td width="200px" >
                <ul>
                    <li  id="liActividad"  runat="server">
                        <asp:LinkButton ID ="btActividad" runat = "server" OnClick="btActividad_OnClick" Text="Actividades"></asp:LinkButton>
                    </li>
                    <li  id="liPerfil"  runat="server">
                        <asp:LinkButton ID ="btPerfil" runat = "server" OnClick="btPerfil_OnClick" Text="Perfiles"></asp:LinkButton>
                    </li>                                
                </ul> 
            </td>
            --%>
            <td td width="200px">
                <ul>
                    <li  id="liPermiso"  runat="server">
                        <asp:LinkButton ID ="btPermiso" runat = "server" OnClick="btPermiso_OnClick" Text="Permisos"></asp:LinkButton>
                    </li>
                    <li   id="liAuditSession"  runat="server">
                        <asp:LinkButton ID ="btAuditSession" runat = "server" OnClick="btAuditSession_OnClick" Text="Auditoría de Sesiones"></asp:LinkButton>
                    </li>  
                    <li  id="liAuditOpereration"  runat="server">
                        <asp:LinkButton ID ="btAuditOpereration" runat = "server" OnClick="btAuditOperation_OnClick" Text="Auditoría de Operaciones"></asp:LinkButton>
                    </li> 
                </ul>
            </td>
        </tr>
    </table> 

    <table width="100%">
        <tr><td><div class="tablaTitulosBlanco"><asp:Literal ID="Literal1" Text="Configurar Cubos" runat="server" ></asp:Literal></div></td></tr>
        <tr>
            <td>
                <ul>
                    <li id="liMatching" runat="server">
                        <asp:LinkButton ID="btLinkButton" runat="server" OnClick="btLinkButton_Click" Text="Acceso a Cubos"></asp:LinkButton>
                    </li>
                </ul>
                
            </td>
        </tr>        
    </table>

    <table width="100%">
        <tr><td><div class="tablaTitulosBlanco"><asp:Literal ID="Literal2" Text="Configurar Matching" runat="server" ></asp:Literal></div></td></tr>
        
        <tr>
            <td>
                <ul>
                    <li id="li1" runat="server">
                        <asp:LinkButton ID="LinkButton1" runat="server" OnClick="btLinkButtonConfigurarMatching_Click" Text="Acceso a Matching"></asp:LinkButton>
                    </li>
                </ul>
                
            </td>
        </tr>       
        
    </table>


</asp:Content> 