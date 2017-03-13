<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProyectoIntervencionDNIPEdit.aspx.cs" Inherits="UI.Web.ProyectoIntervencionDNIPEdit" MasterPageFile="~/App_Shared/General.Master" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc" TagName="EditProyectoIntervencionDNIP"          Src="~/Pages/ProyectoIntervencionDNIP.ascx" %>
<%@ Register Tagprefix="uc" TagName="EditButtons"                           Src="~/Controls/WebControlEditionButtons2.ascx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    
    
    <table >		 
		<tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <uc:EditProyectoIntervencionDNIP runat="server" ID="editProyectoIntervencionDNIP" ></uc:EditProyectoIntervencionDNIP>
            </td>
        </tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
    </table>
    
</asp:Content>
