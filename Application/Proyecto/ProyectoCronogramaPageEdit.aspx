<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoCronogramaPageEdit.aspx.cs" Inherits="UI.Web.ProyectoCronogramaPageEdit" EnableEventValidation="false"   %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoCronograma" Src="ProyectoCronogramaEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoTabPanel"      Src="~/ControlsPersonal/WebControl_ProyectoTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion"       Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage"         Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoHead"         Src="~/ControlsPersonal/WebControl_ProyectoHead.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<asp:UpdatePanel ID="upHeader" runat = "server" UpdateMode = "Conditional" >
    <ContentTemplate >     
    <table width="100%">
        <tr>
            <td width="570px"><uc:ProyectoHead ID="proyectoHead" runat="server" /></td>
            <td  align="right" valign="bottom" width="430px" ><uc:PaggingInPage ID="paggingInPage" runat="server" /></td>
        </tr>
     </table>
  </ContentTemplate>
 </asp:UpdatePanel>  
<uc:ProyectoTabPanel ID="proyectoTabPanel" runat="server" />
<div class="TabbedPanelsContentGroup">
<table width="100%">
    <tr>
        <td>
            <uc:EditProyectoCronograma runat="server" ID="editProyectoCronograma" ></uc:EditProyectoCronograma>
        </td>
    </tr>
	<tr>
	    <td>
	        <asp:ValidationSummary id="vsEditionProyectoCronograma" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoCronograma" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
	    </td>
	</tr>
	<tr>
	    <td>
	        <asp:ValidationSummary id="vsEditionProyectoCronogramaPopUpEtapasEstimadas" runat="server" DisplayMode="BulletList" ValidationGroup="vgEtapasEstimadas" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
	    </td>
	</tr>
	<tr>
        <td>
            <asp:UpdatePanel ID="upEditButtons" runat="server">
                <ContentTemplate>
                   <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionProyectoCronograma" VisibleSaveAndNew="false" ></uc:EditButtons >
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </td>
    </tr>		
</table>
</div>
<uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
</asp:Content>
