<%@ Page Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoDictamenFactibilidadPageEdit.aspx.cs" Inherits="UI.Web.ProyectoDictamenFactibilidadPageEdit" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoDictamenFactibilidad" Src="~/Proyecto/ProyectoDictamenFactibilidadEdit.ascx"%>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoDictamenTabPanel"      Src="~/ControlsPersonal/WebControl_ProyectoDictamenTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion"               Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage"                 Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoDictamenHead"         Src="~/ControlsPersonal/WebControl_ProyectoDictamenHead.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <asp:UpdatePanel ID="upHeader" runat = "server" UpdateMode = "Conditional" >
       <ContentTemplate >
    <table width="100%">
        <tr>
            <td width="650px"><uc:ProyectoDictamenHead ID="proyectoDictamenHead" runat="server" /></td>
            <td  align="right" valign="bottom" width="350px" ><uc:PaggingInPage ID="paggingInPage" runat="server" /></td>
        </tr>
    </table>
     </ContentTemplate>
 </asp:UpdatePanel> 
    <uc:ProyectoDictamenTabPanel ID="proyectoDictamenTabPanel" runat="server" />
    <div class="TabbedPanelsContentGroup">
    <table >		 
		<tr><td>&nbsp;</td></tr>
        <tr>
            <td>
              
                <uc:EditProyectoDictamenFactibilidad runat="server" ID="editProyectoDictamenFactibilidad" ></uc:EditProyectoDictamenFactibilidad>
              
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionEditProyectoDictamenFactibilidad" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoDictamenFactibilidad" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionProyectoDictamenFactibilidad" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
    </table>
    <uc:ConfirmarAccion ID="confirmarAccion"  runat="server" />

</asp:Content>
