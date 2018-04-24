<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoPageList.aspx.cs" Inherits="UI.Web.ProyectoPageList" %>

<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="FilterProyecto" Src="ProyectoFilter.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListProyecto" Src="ProyectoList.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register TagPrefix="uc" TagName="Confirm" Src="~/Controls/WebControl_Confirm.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register TagPrefix="uc" TagName="Copy" Src="~/ControlsPersonal/WebControl_CopyProject.ascx" %>
<%@ Register TagPrefix="uc" TagName="VerReporte" Src="~/ControlsPersonal/WebControl_ProyectoVerReporte.ascx" %>
<%@ Register TagPrefix="uc" TagName="ImprimirProyecto" Src="~/ControlsPersonal/WebControl_PrintProyecto.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProjectHistoricoReporte" Src="~/ControlsPersonal/WebControl_ProjectHistoricoReporte.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProjectEstadoDesicionHistorico" Src="~/ControlsPersonal/WebControl_ProjectEstadoDesicionHistorico.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" GroupingText="Filtro" ID="pnlFilter">
                            <div>
                                <uc:FilterProyecto runat="server" ID="ftProyecto"></uc:FilterProyecto>
                            </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:ValidationSummary ID="vsFilterProyecto" runat="server" DisplayMode="BulletList"
                    ValidationGroup="FilterProyecto" ShowSummary="false"
                    ShowMessageBox="True"></asp:ValidationSummary>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upListButtons" runat="server">
                    <ContentTemplate>
                        <table>
                            <tr>
                                <td align="left" style="width: 658px">
                                    <asp:Button ID="btNew" runat="server" Text="Agregar" OnClick="btNew_OnClick" />
                                    <asp:Button ID="btExportExcel" runat="server" Text="Excel" OnClick="btExportExcel_OnClick" />
                                    <!-- German 20130425 - Graficos -->
                                    <asp:Button ID="btVisualizarGraficos" runat="server" Text="Graficos" OnClick="btVisualizarGraficos_OnClick" OnClientClick="this.form.target ='_blank';" />&nbsp;&nbsp;
                                 <!-- Fin German 20130425 - Graficos -->

                                    <!-- Reportes
                                    <asp:DropDownList ID="ddlReport" runat="server" CssClass="field_input" SkinID="AnchoLibre" Width="150px"></asp:DropDownList>
                                    <asp:Button ID="btOpenReport" runat="server" Text="Ver" OnClick="btOpenReport_OnClick" />&nbsp;&nbsp;
                                    -->

								 <asp:DropDownList ID="ddlStoreReport" runat="server" CssClass="field_input" SkinID="AnchoLibre" Width="150px"></asp:DropDownList>
                                    <asp:Button ID="btStoreReport" runat="server" Text="Ver" OnClick="btStoreReport_OnClick" />
                                </td>
                                <td align="right" style="width: 350px">
                                    <uc:PaggingButtons runat="server" ID="pgButtons" SearchVisible="true" ValidationGroup="FilterProyecto"></uc:PaggingButtons>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" style="width: 658px">
                                    <asp:Button ID="bExportTemplate" runat="server" Text="Exportar Proyectos (template)" Visible="false" OnClick="bExportTemplate_OnClick" />
                                    <asp:Button ID="bImportTemplate" runat="server" Text="Importar Proyectos (desde template)" Visible="false" OnClick="bImportTemplate_OnClick" />
                                </td>
                            </tr>
                            </table>                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGrilla" runat="server">
                    <ContentTemplate>
                        <uc:ListProyecto runat="server" ID="lstProyecto"></uc:ListProyecto>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <!-- POPUPS-->
    <uc:Confirm runat="server" ID="ucConfirm" />
    <uc:Copy runat="server" ID="ucCopy" />
    <uc:VerReporte runat="server" ID="ucVerReporte" />
    <uc:ImprimirProyecto runat="server" ID="ucImprimirProyecto"></uc:ImprimirProyecto>
    <uc:ProjectHistoricoReporte runat="server" ID="ucProjectHistoricoReporte"></uc:ProjectHistoricoReporte>
    <uc:ProjectEstadoDesicionHistorico runat="server" ID="ucProjectEstadoDesicionHistorico"></uc:ProjectEstadoDesicionHistorico>
    <!-- END POPUPS-->

</asp:Content>
