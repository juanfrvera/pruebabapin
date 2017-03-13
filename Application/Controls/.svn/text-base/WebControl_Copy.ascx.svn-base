<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_Copy.ascx.cs" Inherits="UI.Web.WebControl_Copy" %>
<asp:Panel ID="pnPopupCopy" runat="server" Width="400px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color:Gray;">
    <asp:Panel ID="pnPopupCopyDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td><asp:Literal ID="liTitle" runat="server" Text="Copiar" ></asp:Literal></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <table width="100%" >
                <tr>
                    <td><asp:Literal ID="liNombre" runat="server" Text="Nuevo Nombre" ></asp:Literal></td>
                    <td><asp:TextBox ID="txtNombre" runat="server" Width="200px" ></asp:TextBox></td>
                </tr>           
                <tr>
                    <td align ="center" colspan="2" >
                        <asp:Button runat="server" ID="btAceptar" Text="Aceptar" CausesValidation ="false"  OnClick="btAceptar_Click" />
                        <asp:Button runat="server" ID="btCancelar" Text="Cancelar" CausesValidation ="false"  OnClick="btCancelar_Click" />
                    </td>
                </tr>
            </table> 
        </ContentTemplate>
    </asp:UpdatePanel>     
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupCopy" runat="server" CancelControlID="btPopup" PopupDragHandleControlID ="pnPopupCopyDragHandle"
    PopupControlID="pnPopupCopy" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />
</asp:Panel>

