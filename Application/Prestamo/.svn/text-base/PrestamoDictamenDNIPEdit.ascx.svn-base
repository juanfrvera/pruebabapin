<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenDNIPEdit.ascx.cs"
    Inherits="UI.Web.PrestamoDictamenSolapaEdit" %>
<%@ Register TagPrefix="uc" TagName="PrestamoDictamen" Src="~/Prestamo/PrestamoDictamenEdit.ascx" %>
<asp:Panel ID="pnlPrestamoDictamen" runat="server" GroupingText="Dictamen">
    <table>
        <tr>
            <td>
                <asp:GridView ID="gridDictamen" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    AllowPaging="True" OnRowCommand="GridDictamen_RowCommand" OnPageIndexChanging="GridDictamen_PageIndexChanging"
                    OnSorting="GridDictamen_Sorting" AllowSorting="True" EmptyDataText="No hay Dictamenes"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Expediente" DataField="Expediente" SortExpression="Expediente" />
                        <asp:BoundField HeaderText="Calificacion" DataField="Calificacion" SortExpression="Calificacion" />
                        <asp:BoundField HeaderText="Fecha" DataField="FechaAlta" SortExpression="FechaAlta" />
                        <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal" SortExpression="MontoTotal" />
                        <asp:BoundField HeaderText="Monto Prestamo" DataField="MontoPrestamo" SortExpression="MontoPrestamo" />
                        <asp:BoundField HeaderText="Observacion" DataField="CalificacionObservacion" SortExpression="CalificacionObservacion" />
                        <asp:BoundField HeaderText="Recomendacion" DataField="CalificacionRecomendacion" SortExpression="CalificacionRecomendacion" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>

<asp:Panel ID="PopUpDictamen" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="DictamenPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpDictamen" runat="server" Text="Dictamen" />
                </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnDictamen" DefaultButton="btCancelDictamen" runat="server">
        <asp:UpdatePanel ID="upDictamenPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlProyecto" runat="server" ScrollBars="Vertical" Height="500px">
                                <uc:PrestamoDictamen ID="pDictamen" runat="server" />
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelDictamen" Text="Cerrar" OnClick="btCancelDictamen1_Click" 
                                runat="server" Width="60px"  />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDictamen" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="DictamenPopUpDragHandle" PopupControlID="PopUpDictamen"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
