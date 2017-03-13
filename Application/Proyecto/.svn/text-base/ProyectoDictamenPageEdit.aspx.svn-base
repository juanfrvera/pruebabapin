<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoDictamenPageEdit.aspx.cs" Inherits="UI.Web.ProyectoDictamenPageEdit" EnableEventValidation="false"  %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoDictamen" Src="ProyectoDictamenEdit.ascx" %>
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
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <uc:EditProyectoDictamen runat="server" ID="editProyectoDictamen" ></uc:EditProyectoDictamen>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionProyectoDictamen" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoDictamen" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionProyectoDictamen" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
    </table>
    <uc:ConfirmarAccion ID="confirmarAccion"  runat="server" />

</asp:Content>
