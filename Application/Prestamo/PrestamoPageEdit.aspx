<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PrestamoPageEdit.aspx.cs" Inherits="UI.Web.PrestamoPageEdit" EnableEventValidation="false" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditPrestamo"         Src="PrestamoEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons"          Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoTabPanel"      Src="~/ControlsPersonal/WebControl_PrestamoTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion"       Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage"         Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoHead"          Src="~/ControlsPersonal/WebControl_PrestamoHead.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">    
<asp:UpdatePanel ID="upHeader" runat = "server" UpdateMode = "Conditional" >
       <ContentTemplate >
        <table width="100%">
            <tr>
                <td width="650px"><uc:PrestamoHead ID="prestamoHead" runat="server" /></td>
                <td  align="right" valign="bottom" width="350px" ><uc:PaggingInPage ID="paggingInPage" runat="server" /></td>
            </tr>
        </table> 
  </ContentTemplate>
 </asp:UpdatePanel>   
    <uc:PrestamoTabPanel ID="prestamoTabPanel" runat="server" />
    <div class="TabbedPanelsContentGroup">
    <table >		 
		<tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <uc:EditPrestamo runat="server" ID="editPrestamo" ></uc:EditPrestamo>
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionPrestamo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionPrestamo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
 <%--               <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>--%>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionPrestamo" ></uc:EditButtons >
<%--                    </ContentTemplate>
                </asp:UpdatePanel>--%>
            </td>
        </tr>		
    </table>
    </div>
    <uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
</asp:Content>
