<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ReportPopup.ascx.cs" Inherits="UI.Web.WebControl_ReportPopup" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=10.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<asp:UpdatePanel ID="upDatos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelPopupAcciones" runat="server" Width="550px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <table cellspacing="10px" style="width:100%;">
                <tr>
                    <td>
                        <asp:Panel ID="AccionesPopupDragHandle" runat="server" Style="cursor: move;">
                            <table width="100%" cellpadding="0" cellspacing="5">
                                <tr class="menutoppopup">
                                    <td>
                                        <asp:Label ID="lblTitulo" runat="server" Enabled="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>                
                <tr style="border-style:solid">
                    <td>
                        <asp:Panel ID="pnlReport" runat = "server" ScrollBars ="Vertical" >
                            <rsweb:ReportViewer ID="reportView" runat="server" Width="100%" ShowRefreshButton="False" AsyncRendering="false"   Style="margin-bottom: 30px;"  />
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="padding-top: 30px" align ="right" >
                        <asp:Button ID="btCancelar" runat = "server" Text ="Cancelar" OnClick="btCancel_Click"/>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mpeWindow" runat="server" CancelControlID="btnhiddenpopup"
            PopupDragHandleControlID="AccionesPopupDragHandle" PopupControlID="PanelPopupAcciones"
            OkControlID="btnhiddenpopup" TargetControlID="btnhiddenpopup" BackgroundCssClass="modalBackground" />
        <asp:Button ID="btnhiddenpopup" runat="server" Text="Button" Style="display: none" />
    </ContentTemplate>
</asp:UpdatePanel>


