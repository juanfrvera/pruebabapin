<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="AdministracionCalidadPageEdit.aspx.cs"  Inherits="UI.Web.AdministracionCalidadPageEdit" EnableEventValidation ="false"  %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditAdministracionCalidad" Src="~/Calidad/AdministracionCalidadEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoCalidadTabPanel" Src="~/ControlsPersonal/WebControl_CalidadTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage"         Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoCalidadHead"          Src="~/ControlsPersonal/WebControl_ProyectoCalidadHead.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion"       Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
  <asp:UpdatePanel ID="upHeader" runat = "server" UpdateMode = "Conditional" >
       <ContentTemplate >
         <table width="100%">
            <tr>
                <td width="600px"><uc:ProyectoCalidadHead ID="proyectoCalidadHead" runat="server" /></td>
                <td align="right" valign="bottom" width="400px"><uc:PaggingInPage ID="paggingInPage" runat="server" /></td>
            </tr>
         </table>
   </ContentTemplate>
 </asp:UpdatePanel>
    <table >		 
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server" >
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionAdministracionCalidad" VisibleSaveAndNew="false" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr><td>&nbsp;</td></tr>
        <tr>
            <td>
              <%--  <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>--%>
                        <uc:EditAdministracionCalidad runat="server" ID="editAdministracionCalidad" ></uc:EditAdministracionCalidad>
              <%--      </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionAdministracionCalidad" runat="server" DisplayMode="BulletList" ValidationGroup="EditionAdministracionCalidad" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
    </table>
<uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
</asp:Content>
