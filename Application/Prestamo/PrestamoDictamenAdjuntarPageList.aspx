﻿<%@ Page Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PrestamoDictamenAdjuntarPageList.aspx.cs" Inherits="UI.Web.PrestamoDictamenAdjuntarPageList" EnableEventValidation="false" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="PrestamoDictamenAdjuntarEdit" Src="PrestamoDictamenAdjuntarEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoDictamenTabPanel" Src="~/ControlsPersonal/WebControl_PrestamoDictamenTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion" Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage" Src="~/Controls/WebControlPaggingInPage.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoDictamenHead"         Src="~/ControlsPersonal/WebControl_PrestamoDictamenHead.ascx" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <asp:UpdatePanel ID="upHeader" runat = "server" UpdateMode = "Conditional" >
       <ContentTemplate >
        <table width="100%">
            <tr>
                <td width="650px"><uc:PrestamoDictamenHead ID="prestamoDictamenHead" runat="server" /></td>
                <td  align="right" valign="bottom" width="350px" ><uc:PaggingInPage ID="paggingInPage" runat="server" /></td>
            </tr>
        </table>
       </ContentTemplate>
    </asp:UpdatePanel> 
    <uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
    <uc:PrestamoDictamenTabPanel ID="PrestamoDictamenTabPanel" runat="server" />
    <div class="TabbedPanelsContentGroup">
    <table width="100%">
        <tr>
            <td>
               <asp:Panel ID="pnEdicionArchivo" runat="server">
                   <asp:UpdatePanel ID="upEditArchivo" runat="server" UpdateMode="Conditional" >
                   <ContentTemplate>
                        <uc:PrestamoDictamenAdjuntarEdit runat="server" ID="editPrestamoDictamenAdjuntar" ></uc:PrestamoDictamenAdjuntarEdit>
                    </ContentTemplate>
                    <Triggers >
                        <asp:PostBackTrigger  ControlID ="editPrestamoDictamenAdjuntar"  />
                    </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterPrestamoDictamenAdjuntar" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterPrestamoDictamenAdjuntar" ShowSummary="false"
                    ShowMessageBox="True"></asp:ValidationSummary>
            </td>
        </tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionPrestamoDictamenAlcanceGeografico"  VisibleSaveAndNew="false" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>		
    </table>
    </div>
</asp:Content>