<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PrestamoEditDictamenPageEdit.aspx.cs" Inherits="UI.Web.PrestamoEditDictamenPageEdit" MasterPageFile="~/App_Shared/General.Master" EnableEventValidation="false"  %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc" TagName="EditPrestamoEditDictamen"          Src="~/Prestamo/PrestamoEditDictamenEdit.ascx" %>
<%@ Register Tagprefix="uc" TagName="EditButtons"                           Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoTabPanel" Src="~/ControlsPersonal/WebControl_PrestamoTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion" Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage" Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoHead"         Src="~/ControlsPersonal/WebControl_PrestamoHead.ascx" %>

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
    <uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
    <uc:PrestamoTabPanel ID="PrestamoTabPanel" runat="server" />
     <div class="TabbedPanelsContentGroup">
    <table width="100%">		 
        <tr>
            <td>
                <uc:EditPrestamoEditDictamen runat="server" ID="editPrestamoEditDictamen" ></uc:EditPrestamoEditDictamen>
            </td>
        </tr>
		<tr>
            <td>        
               <uc:EditButtons runat="server" ID="editButtons"  ></uc:EditButtons >
            </td>
        </tr>		
    </table>
    </div>
</asp:Content>
