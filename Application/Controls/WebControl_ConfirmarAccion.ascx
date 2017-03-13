<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ConfirmarAccion.ascx.cs" Inherits="UI.Web.WebControl_ConfirmarAccion" %>
<asp:UpdatePanel ID="upDatos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelPopupAcciones" runat="server" Width="550px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <table cellspacing="10px" style="width:100%;">
                <tr>
                    <td>
                        <asp:Panel ID="AccionesPopupDragHandle" runat="server" Style="cursor: move;">
                            <table width="100%" cellpadding="0" cellspacing="5">
                                <tr class="menutoppopup">
                                    <td><asp:Label ID="lblTitulo" runat="server" ></asp:Label></td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td style="text-align:center;">
                        <div style="float:none;overflow:hidden;padding:25px;margin: 0 Auto;">
                            <asp:Label ID="lblMensaje" runat="server" ></asp:Label>
                        </div>
                    </td>
                </tr>
                <tr>
                    <td align="center">
                        <asp:Button runat="server" ID="btAceptar" Text="Si" CausesValidation="false"
                            OnClick="btAceptar_Click" />
                        <asp:Button runat="server" ID="btCancelar" Text="No" CausesValidation="false"
                            OnClick="btCancelar_Click" />
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
