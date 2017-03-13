<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProjectEstadoDesicionHistorico.ascx.cs" Inherits="UI.Web.WebControl_ProjectEstadoDesicionHistorico" %>
<script>
 function PleaseWaitButton(Control) {
    document.forms[0].submit();
    window.setTimeout("DisableButton('" + Control + "')", 0);
}
function DisableButton(buttonID) {
    $(buttonID).disabled=true;
    $(buttonID).value = "Procesando.. Espere por favor...";
}
function $(id){return document.getElementById(id);}
</script>
<asp:Panel ID="pnPopupEstadoDesicionHistorico" runat="server" Width="700px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color:Gray;">
    <asp:Panel ID="pnPopupEstadoDesicionHistoricoDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td><asp:Literal ID="liTitle" runat="server" Text="Histórico de Estado de Decisión" ></asp:Literal></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <table width="100%" >
                <tr>
                   <td>
                      <asp:GridView ID="GridEstadoDesicionHistorico" runat="server"  Width="100%" AutoGenerateColumns="False" DataKeyNames="ID"  >
                            <Columns> 
                                <asp:BoundField DataField="Fecha" HeaderText="Fecha"  DataFormatString="{0:dd/MM/yyyy hh:mm}" HeaderStyle-Width="20%"  />
                                <asp:BoundField DataField="EstadoDeDesicion_Nombre" HeaderText="Estado"  HeaderStyle-Width="15%"  />
	                            <asp:BoundField DataField="Usuario_NombreUsuario" HeaderText="Usuario"  HeaderStyle-Width="15%"  />
	                            <asp:TemplateField   HeaderText="Comentario"  HeaderStyle-Width="50%"  >            
                                        <ItemTemplate>
                                            <asp:Label ID="lblComentarios" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Observacion"),25) %>' ToolTip='<%# Eval("Observacion") %>'  ></asp:Label>
                                        </ItemTemplate>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>                    
                    </td>
                </tr>
                <tr>
                    <td align ="center"  >
                        <asp:Button runat="server" ID="btCancelar" Text="Cerrar" CausesValidation ="false"  OnClick="btCancelar_Click" />
                    </td>
                </tr>
            </table> 
        </ContentTemplate>
    </asp:UpdatePanel>     
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupEstadoDesicionHistorico" runat="server" CancelControlID="btPopup" PopupDragHandleControlID ="pnPopupEstadoDesicionHistoricoDragHandle"
    PopupControlID="pnPopupEstadoDesicionHistorico" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />
</asp:Panel>

