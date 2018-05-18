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
<%@ Register Tagprefix="uc"  TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%">
        <tr>
            <td>
                <asp:Button ID="btNew" runat="server" Text="Cargar nuevo proyecto" OnClick="btNew_OnClick" />
            </td>
        </tr>
        <tr>
            <td>
                <!-- Reportes
                <table  border="0" cellspacing="0" cellpadding="0">
                    <tr>
                        <td align="right">
                            <asp:DropDownList ID="ddlReport" runat="server" style="margin:0;padding:0;" CssClass="field_input" SkinID="AnchoLibre" Width="150px"></asp:DropDownList>
                        </td>
                        <td>
                            <asp:Button ID="btOpenReport" runat="server" style="height:20px;" Text="Ver" OnClick="btOpenReport_OnClick" />
                        </td>
                    </tr>
                </table>
                 -->
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
                        <asp:Panel runat="server" GroupingText="Filtro de Búsqueda" ID="pnlFilter">
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
                        <table border="0">
                            <tr>
                                <td align="left" style="width: 200px; vertical-align:middle;">
                                    <asp:Button ID="btExportExcel" runat="server" Text="Exportar" OnClick="btExportExcel_OnClick" />
                                    <!-- German 20130425 - Graficos -->
                                    <asp:Button ID="btVisualizarGraficos" runat="server" Text="Gráficos" OnClick="btVisualizarGraficos_OnClick" OnClientClick="this.form.target ='_blank';" />&nbsp;&nbsp;
                                    <!-- Fin German 20130425 - Graficos -->
                                </td>
                                <td style="width: 500px" >
                                    <table  border="0" cellspacing="0" cellpadding="0">
                                        <tr>
                                            <td align="right"><asp:DropDownList ID="ddlStoreReport" style="margin:0;padding:0;" runat="server" CssClass="field_input" SkinID="AnchoLibre"></asp:DropDownList>
                                        </td>
                                        <td>
                                            <asp:Button ID="btStoreReport" style="height:20px;" runat="server" Text="Ver" OnClick="btStoreReport_OnClick" />
                                        </td>
                                        </tr>
                                    </table>
                                </td>
                                <td align="right" style="width: 500px">
                                    <uc:PaggingButtons runat="server" ID="pgButtons" SearchVisible="true" ValidationGroup="FilterProyecto"></uc:PaggingButtons>
                                </td>
                            </tr>
                            <tr>
                                <td align="left" colspan="3">
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

    <%--PANEL IMPORT TEMPLATE--%>
    <asp:Panel ID="PopUpTemplateFiles" runat="server" Width="800px" Style="background-color: #ffffff;
        border: solid 2px #ffffff; border-color: Gray;">
        <asp:Panel ID="TemplateFilesPopUpDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutoppopup">
                    <td>
                        <th align="center" height="10">
                            <asp:Label ID="headerPopUpTemplateFiles" runat="server" Text="Importar proyectos" />
                        </th>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnTemplateFiles" DefaultButton="btSaveTemplateFiles" Height="150px" runat="server">
            <asp:UpdatePanel ID="upTemplateFilesPopUp"  runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100%">
                        <tr>
                            <td style="width:80px">&nbsp;</td>
                            <td style="width:460px">
                                <table width="100%">
                                    <tr>
                                        <td align="left" ><asp:Literal ID="litArchivo" runat="server" Text="Archivo" ></asp:Literal></td>
	                                    <td align="left" ><uc:FileUploadWC ID="fuArchivo" runat="server" ></uc:FileUploadWC></td>
                                    </tr>                                                                                  
                                    <tr>
                                        <td colspan='2' align="center"><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" ></asp:Label><br/></td>
                                    </tr>
                                     <tr>
                                        <td align="center"  colspan="2" >                                
                                            <asp:Button ID="btSaveTemplateFiles" Text="Aceptar" OnClick="btSaveTemplateFile_Click" runat="server" ValidationGroup="vgTemplateFiles" />
                                            <asp:Button ID="btCancelTemplateFiles" Text="Cerrar" OnClick="btCancelTemplateFile_Click" runat="server" Width="60px" />                                
                                        </td>
                                    </tr>
                                </table>
                            </td>  
                            <td style="width:40px">&nbsp;</td>                      
                        </tr>
                    </table>
                </ContentTemplate>
                <Triggers>
                    <asp:PostBackTrigger ControlID="btSaveTemplateFiles" />
                </Triggers>
            </asp:UpdatePanel>
        </asp:Panel>
        <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderTemplateFiles" runat="server" CancelControlID="Button2"
            PopupDragHandleControlID="TemplateFilesPopUpDragHandle" PopupControlID="PopUpTemplateFiles"
            OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
    </asp:Panel>
</asp:Content>
