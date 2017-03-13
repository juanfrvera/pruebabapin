<%@ Page Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoAdjuntarPageList.aspx.cs" Inherits="UI.Web.ProyectoAdjuntarPageList" EnableEventValidation="false"  %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="ProyectoAdjuntarEdit" Src="ProyectoAdjuntarEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoTabPanel" Src="~/ControlsPersonal/WebControl_ProyectoTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion" Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage" Src="~/Controls/WebControlPaggingInPage.ascx" %>
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
           <asp:Panel ID="pnEdicionArchivo" runat="server">
                <asp:UpdatePanel ID="upEditArchivo" runat="server" UpdateMode="Conditional" >
               <ContentTemplate>
                    <uc:ProyectoAdjuntarEdit runat="server" ID="editProyectoAdjuntar" ></uc:ProyectoAdjuntarEdit>
                </ContentTemplate>
                <Triggers >
                    <asp:PostBackTrigger  ControlID ="editProyectoAdjuntar"  />
                </Triggers>
                </asp:UpdatePanel>                    
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td>
            <asp:ValidationSummary ID="vsFilterProyectoAdjuntar" runat="server" DisplayMode="BulletList"
                ValidationGroup="FilterProyectoAdjuntar" ShowSummary="false"
                ShowMessageBox="True"></asp:ValidationSummary>
        </td>
    </tr>
    <tr>
	    <td>
	        <asp:ValidationSummary id="vsFilterProyectoAdjuntarPopUp" runat="server" DisplayMode="BulletList" ValidationGroup="vgProyectoFiles" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
	    </td>
	</tr>
	<tr>
        <td>
            <asp:UpdatePanel ID="upEditButtons" runat="server">
                <ContentTemplate>
                   <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionProyectoAlcanceGeografico"  VisibleSaveAndNew="false" ></uc:EditButtons >
                </ContentTemplate>
            </asp:UpdatePanel>
            <br />
        </td>
    </tr>		
</table>
</div>
<uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
</asp:Content>