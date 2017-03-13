﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_PrintPrestamo.ascx.cs" Inherits="UI.Web.WebControl_PrintPrestamo" %>

<style type="text/css">
    .style1
    {
        width: 50px;
    }
</style>

<asp:Panel ID="pnPopupImprimirReporte" runat="server" Width="600px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color:Gray;">
    <asp:Panel ID="pnPopupImprimirReporteDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td><asp:Literal ID="liTitle" runat="server" Text="Ficha de Proyecto" ></asp:Literal></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <table width="100%" >
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkSolapaGeneral" runat ="server" Text ="Solapa General" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkAlcanceGeografico" runat ="server" Text ="Alcance Geográfico" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkObjetivos" runat ="server" Text ="Objetivos" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    &nbsp;
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIncluyeEvolucionDeIndicadoresObjetivos" runat ="server" Text="Incluye Evolución de Indicadores" />
                    </td>                       
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkConvenio" runat ="server" Text="Convenio" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkComponentes" runat ="server" Text="Componentes" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkProducto" runat ="server" Text="Producto" />
                    </td>
                </tr>
                <tr>
                    <td class="style1">
                    &nbsp;
                    </td>
                    <td>
                        <asp:CheckBox ID="chkIncluyeDetalleDeEtapas" runat ="server" Text ="Incluye Detalle de Etapas" />
                    </td>
                </tr>
                
                <tr>
                    <td colspan="2">
                        <asp:CheckBox ID ="chkIntervencionDNIP" runat="server" Text="Intervención DNIP" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2">
                        <asp:CheckBox ID="chkAdjuntos" runat ="server" Text="Adjuntos" />
                    </td>
                </tr>
                <tr>
                    <td colspan ="2" align ="center" >
                        
                        <asp:Button ID="btImprimir" runat ="server" Text="Imprimir" 
                            onclick="btImprimir_Click" ValidationGroup="vgImprimirReporte"  />
                        <asp:Button ID="btExportar" runat ="server" Text="Exportar" 
                            onclick="btExportar_Click"  />
                        <asp:Button ID="btCancelar" runat ="server" Text="Cancelar" 
                            onclick="btCancelar_Click" />
                    </td>
                    
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>     
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupImprimirReporte" runat="server" CancelControlID="btPopup" PopupDragHandleControlID ="pnPopupImprimirReporteDragHandle"
    PopupControlID="pnPopupImprimirReporte" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />
</asp:Panel>
