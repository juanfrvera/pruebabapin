<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProjectHistoricoReporte.ascx.cs" Inherits="UI.Web.WebControl_ProjectHistoricoReporte" %>
<script>
    function PleaseWaitButton(Control) {
        document.forms[0].submit();
        window.setTimeout("DisableButton('" + Control + "')", 0);
    }
    function DisableButton(buttonID) {
        $(buttonID).disabled = true;
        $(buttonID).value = "Procesando.. Espere por favor...";
    }
    function $(id) { return document.getElementById(id); }
</script>
<asp:Panel ID="pnPopupHistoryReport" runat="server" Width="700px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:UpdatePanel ID="upEdit" runat="server">
        <ContentTemplate>
            <ajaxToolkit:TabContainer ID="tcContainer" runat="server" Width="100%">
                <ajaxToolkit:TabPanel ID="tpHistoricoProyectos" runat="server" HeaderText="Copias históricas">
                    <ContentTemplate>
                        <asp:Panel ID="pnPopupHistoryReportDragHandle" runat="server" Style="cursor: move;">
                            <table width="100%" cellpadding="0" cellspacing="5">
                                <tr class="menutoppopup">
                                    <td>
                                        <asp:Literal ID="liTitle" runat="server" Text="Copias Históricas"></asp:Literal></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:Literal ID="liProyectoCodigo" runat="server" Text="BAPIN"></asp:Literal>:&nbsp;
                        <asp:Label ID="lblProyectoCodigo" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="liProyectoDenominacion" runat="server" Text="Denominación"></asp:Literal>:&nbsp;
                        <asp:Label ID="lblProyectoDenominacion" runat="server"></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td width="100%">
                                            <asp:Panel ID="pnSolapas" runat="server" GroupingText="Agregar">
                                                <table width="100%">
                                                    <tr>
                                                        <td>
                                                            <asp:Literal ID="liComentario" runat="server" Text="Comentario"></asp:Literal><br />
                                                            <asp:TextBox ID="txtComentario" runat="server" MaxLength="500" Width="90%" TextMode="MultiLine" Columns="60" Rows="5"></asp:TextBox>
                                                        </td>
                                                    </tr>
                                                    <tr>
                                                        <td align="center">
                                                            <asp:Button runat="server" ID="btAceptar" Text="Aceptar" CausesValidation="false" OnClick="btAceptar_Click" />
                                                            <asp:Button runat="server" ID="btCancelar" Text="Cerrar" CausesValidation="false" OnClick="btCancelar_Click" />
                                                        </td>
                                                    </tr>
                                                </table>
                                            </asp:Panel>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridReports" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID" OnRowCommand="Grid_RowCommand">
                                                <Columns>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy hh:mm}" HeaderStyle-Width="20%" />
                                                    <asp:BoundField DataField="Usuario_NombreUsuario" HeaderText="Usuario" HeaderStyle-Width="20%" />
                                                    <asp:TemplateField HeaderText="Comentario" HeaderStyle-Width="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComentarios" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Comentarios"),25) %>' ToolTip='<%# Eval("Comentarios") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                    <asp:TemplateField ItemStyle-HorizontalAlign="Right" HeaderStyle-Width="10%">
                                                        <ItemTemplate>
                                                            <asp:ImageButton ID="btRead" runat="server" src="../Images/imprimir.png" ToolTip='<%# Translate("Imprimir") %>' CommandName='<%# Command.SHOW_HISTORY_PRINT %>' CommandArgument='<%# Eval("ID")%>' CausesValidation="false" />
                                                            &nbsp;
				                        <asp:ImageButton ID="btDelete" runat="server" src="../Images/delete.jpg" ToolTip='<%# Translate("Eliminar") %>' CommandName='<%# Command.DELETE_HISTORY_PRINT %>' OnClientClick="return confirm('Está seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                        </ItemTemplate>
                                                        <ItemStyle Width="80px" />
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>

                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
                <ajaxToolkit:TabPanel ID="TabPanel1" runat="server" HeaderText="Histórico de estados de decisión">
                    <ContentTemplate>
                        <asp:Panel ID="pnPopupEstadoDesicionHistoricoDragHandle" runat="server" Style="cursor: move;">
                            <table width="100%" cellpadding="0" cellspacing="5">
                                <tr class="menutoppopup">
                                    <td>
                                        <asp:Literal ID="Literal1" runat="server" Text="Histórico de Estado de Decisión"></asp:Literal></td>
                                </tr>
                            </table>
                        </asp:Panel>
                        <asp:UpdatePanel ID="UpdatePanel1" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <table width="100%">
                                    <tr>
                                        <td>
                                            <asp:GridView ID="GridEstadoDesicionHistorico" runat="server" Width="100%" AutoGenerateColumns="False" DataKeyNames="ID">
                                                <Columns>
                                                    <asp:BoundField DataField="Fecha" HeaderText="Fecha" DataFormatString="{0:dd/MM/yyyy hh:mm}" HeaderStyle-Width="20%" />
                                                    <asp:BoundField DataField="EstadoDeDesicion_Nombre" HeaderText="Estado" HeaderStyle-Width="15%" />
                                                    <asp:BoundField DataField="Usuario_NombreUsuario" HeaderText="Usuario" HeaderStyle-Width="15%" />
                                                    <asp:TemplateField HeaderText="Comentario" HeaderStyle-Width="50%">
                                                        <ItemTemplate>
                                                            <asp:Label ID="lblComentarios" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("Observacion"),25) %>' ToolTip='<%# Eval("Observacion") %>'></asp:Label>
                                                        </ItemTemplate>
                                                    </asp:TemplateField>
                                                </Columns>
                                            </asp:GridView>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td align="center">
                                            <asp:Button runat="server" ID="btCerrarHistDecision" Text="Cerrar" CausesValidation="false" OnClick="btCancelarHistDecision_Click" />
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </ContentTemplate>
                </ajaxToolkit:TabPanel>
            </ajaxToolkit:TabContainer>

        </ContentTemplate>
    </asp:UpdatePanel>
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupHistoryReport" runat="server" CancelControlID="btPopup" PopupDragHandleControlID="pnPopupHistoryReportDragHandle"
        PopupControlID="pnPopupHistoryReport" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />

</asp:Panel>
