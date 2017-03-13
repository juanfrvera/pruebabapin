<%@ Page Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoAdjuntarPageList.aspx.cs" Inherits="UI.Web.ProyectoSeguimientoAdjuntarPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="ProyectoSeguimientoAdjuntarEdit" Src="ProyectoSeguimientoAdjuntarEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoSeguimientoTabPanel" Src="~/ControlsPersonal/WebControl_ProyectoSeguimientoTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="ConfirmarAccion" Src="~/Controls/WebControl_ConfirmarAccion.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingInPage" Src="~/Controls/WebControlPaggingInPage.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <uc:ConfirmarAccion ID="confirmarAccion" runat="server" />
    <uc:PaggingInPage ID="paggingInPage" runat="server" />
    <uc:ProyectoSeguimientoTabPanel ID="ProyectoSeguimientoTabPanel" runat="server" />
    <div class="TabbedPanelsContentGroup">
    <table width="100%">
        <tr>
            <td>
               <asp:Panel ID="pnEdicionArchivo" runat="server">
                   <asp:UpdatePanel ID="upEditArchivo" runat="server" UpdateMode="Conditional" >
                   <ContentTemplate>
                        <uc:ProyectoSeguimientoAdjuntarEdit runat="server" ID="editProyectoSeguimientoAdjuntar" ></uc:ProyectoSeguimientoAdjuntarEdit>
                    </ContentTemplate>
                    <Triggers >
                        <asp:PostBackTrigger  ControlID ="editProyectoSeguimientoAdjuntar"  />
                    </Triggers>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionProyectoSeguimientoAlcanceGeografico"  VisibleSaveAndNew="false" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
                <br />
            </td>
        </tr>		
    </table>
    </div>
</asp:Content>