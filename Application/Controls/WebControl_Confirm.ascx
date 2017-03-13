<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_Confirm.ascx.cs" Inherits="UI.Web.WebControl_Confirm" %>
<asp:UpdatePanel ID="upDatos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="PanelPopupAcciones" runat="server" Width="550px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
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
                        <td>
                            <asp:Literal ID="liObservaciones" Text="Observaciones" runat="server" ></asp:Literal> <br />
                            <asp:TextBox ID="txObservaciones" runat="server" TextMode="MultiLine" Rows="9" Columns="60" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button runat="server" ID="Button1" Text="Aceptar" CausesValidation="false"
                                OnClick="btAceptar_Click" />
                            <asp:Button runat="server" ID="Button2" Text="Cancelar" CausesValidation="false"
                                OnClick="btCancelar_Click" />
                        </td>
                    </tr>
                </table>
             </ContentTemplate>
            </asp:UpdatePanel> 
        </asp:Panel>
        <ajaxToolkit:ModalPopupExtender ID="mpeWindow" runat="server" CancelControlID="btnhiddenpopup"
            PopupDragHandleControlID="AccionesPopupDragHandle" PopupControlID="PanelPopupAcciones"
            OkControlID="btnhiddenpopup" TargetControlID="btnhiddenpopup" BackgroundCssClass="modalBackground" />
        <asp:Button ID="btnhiddenpopup" runat="server" Text="Button" Style="display: none" />
    </ContentTemplate>
</asp:UpdatePanel>

