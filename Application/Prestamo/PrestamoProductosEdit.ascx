<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoProductosEdit.ascx.cs"
    Inherits="UI.Web.PrestamoProductosEdit" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<div class="TabbedPanelsContent">
    <asp:Panel ID="pnlProyectoFiles" runat="server" GroupingText="Productos">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                        <tr>
                            <td align="right">
                                <asp:UpdatePanel ID="pnlAgregarProducto" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarProducto" runat="server" Text="Agregar" OnClick="btAgregarProducto_Click"
                                            TabIndex="2" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="upGridProductos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridProductos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    AllowPaging="True" OnRowCommand="GridProductos_RowCommand" AllowSorting="True"
                    OnSorting="GridProductos_Sorting" OnPageIndexChanging="GridProductos_PageIndexChanging"
                    EmptyDataText="No hay Productos definidos" Width="99%">
                    <Columns>
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" SortExpression="Descripcion"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                        <asp:BoundField HeaderText="Componente" DataField="Componente" SortExpression="Componente"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                        <asp:BoundField HeaderText="SubComponente" DataField="SubComponente" SortExpression="SubComponente"
                            ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                        <asp:BoundField HeaderText="Monto Contraparte" DataField="MontoContraparte" SortExpression="MontoContraparte"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ItemStyle-Width="100px" />
                        <asp:BoundField HeaderText="Monto Préstamo" DataField="MontoPrestamo" SortExpression="MontoPrestamo"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ItemStyle-Width="100px" />
                       <%-- <asp:BoundField HeaderText="Ini. Gestión" DataField="StrIGestion" SortExpression="StrIGestion"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" />
                        <asp:BoundField HeaderText="Aut. Negociar" DataField="StrANegociar" SortExpression="StrANegociar"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" />--%>
                        <asp:BoundField HeaderText="Proyecto Código" DataField="BAPIN" SortExpression="BAPIN"
                            ItemStyle-HorizontalAlign="Center" />
                         <%--<asp:BoundField HeaderText="Ejecución" DataField="StrEjecucion" SortExpression="StrEjecucion"
                            ItemStyle-HorizontalAlign="Center" ItemStyle-Width="40px" />--%>
                        <asp:BoundField HeaderText="Proyecto Estado" DataField="ProyectoEstado" SortExpression="ProyectoEstado"
                            ItemStyle-HorizontalAlign="Left" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    OnClick="GridImageButton_Click" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'
                                    CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    OnClick="GridImageButton_Click" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                    CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</div>
<%--PANEL ALTA PRODUCTOS --%>
<asp:Panel ID="PopUpProductos" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProductosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpProductos" runat="server" Text="Producto" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProductos" DefaultButton="btSaveProductos" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upProductosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td align="left" colspan="7" valign="middle">
                            <asp:Literal runat="server" ID="litDescripcion" Text="Descripción"></asp:Literal><br />
                            <br />
                            <asp:TextBox runat="server" ID="txtDescripcion" TextMode="MultiLine" Rows="3" Width="740px"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"
                            ValidationGroup="vgProductos" Text="*" Width="5px" Height="5px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal runat="server" ID="litComponente" Text="Componente"></asp:Literal>
                        </td>
                        <td valign="top" align="left" style="width: 1px">

                        </td>
                        <td valign="top">
                            <asp:DropDownList runat="server" ID="ddlComponentes" SkinID ="AnchoLibre" Width ="250px"   AutoPostBack="true"  OnSelectedIndexChanged="ddlComponenetes_OnSelectedIndexChanged">
                            </asp:DropDownList>
                            <asp:RequiredFieldValidator ID="rfvComponentes" runat="server" ControlToValidate="ddlComponentes"
                                ValidationGroup="vgProductos" Text="*" Width="1px" Height="1px" InitialValue="0"></asp:RequiredFieldValidator>                            
                        </td>
                        <td>
                            <asp:Literal runat="server" ID="litSubcomponente" Text="Subcomponente"></asp:Literal>
                        </td>
                        <td valign="top">
                            &nbsp;
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="ddlSubComponentes" SkinID ="AnchoLibre" Width ="250px" >
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litMContraparte" Text="Monto Contraparte" runat="server"></asp:Literal>
                        </td>
                        <td valign="top" align="left" style="width: 1px">

                        </td>
                        <td valign="top">
                            <cc:NumericTextBox runat="server" ID="txtMontoContraparte" InputType="PositiveInteger" UseSeparadorMiles="true" 
                                Width="100px"></cc:NumericTextBox>
                            <asp:RequiredFieldValidator ID="rfvMontoContraparte" runat="server" ControlToValidate="txtMontoContraparte"
                                ValidationGroup="vgProductos" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>                                
                        </td>
                        <td>
                            <asp:Literal ID="litMPrestamo" Text="Monto Prestamo" runat="server"></asp:Literal>
                        </td>
                        <td valign="top" align="left" style="width: 1px">

                        </td>
                        <td valign="top">
                            <cc:NumericTextBox runat="server" ID="txtMontoPrestamo" InputType="PositiveInteger" UseSeparadorMiles="true" 
                                Width="100px"></cc:NumericTextBox>
                            <asp:RequiredFieldValidator ID="rfvMontoPrestamo" runat="server" ControlToValidate="txtMontoPrestamo"
                                ValidationGroup="vgProductos" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>                                
                        </td>
                    </tr>
                    <!-- Matias 20140429 - Tarea 142
                    <tr>
                        <td colspan="7">
                            <asp:Panel ID="Panel1" runat="server" GroupingText="Estados" Width="750px">
                                <table width="100%">
                                    <tr>
                                        <td width="30%">
                                            <asp:Literal ID="litGestion" Text="Inició Gestión" runat="server"></asp:Literal>
                                        </td>
                                        <td width="70%">
                                            <asp:CheckBox ID="cbGestion" runat="server" AutoPostBack="true" OnCheckedChanged="limpiarMensaje_OnCheckedChanged">
                                            </asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litAutorizacion" Text="Autorización a Negocios" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="cbAutorizacion" runat="server" AutoPostBack="true" OnCheckedChanged="limpiarMensaje_OnCheckedChanged">
                                            </asp:CheckBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="litEjecucion" Text="Ejecución" runat="server"></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:CheckBox ID="cbEjecucion" runat="server" AutoPostBack="true" OnCheckedChanged="limpiarMensaje_OnCheckedChanged">
                                            </asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                    </tr>
                    Matias 20140429 - Tarea 142-->
                    <tr>
                        <td colspan="7">
                        <br />
                        </td>
                    </tr> 
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="5">                   
                    <tr>
                        <td width="100px">                        
                           <asp:Literal ID="litBapin" Text="Nro. Proyecto" runat="server"></asp:Literal>
                        </td>
                        <td  width="50px">
                            <asp:TextBox ID="txtBAPIN" 
                                 min="1"  runat="server" Width="50px"></asp:TextBox>
                        </td>
                        <td align="left" width="20px"><asp:RegularExpressionValidator ID="revBAPIN" runat="server"   ControlToValidate="txtBAPIN"  ValidationGroup="vgProductos"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
                        <td class="filaInput" style=" width:80px" >
                        <asp:Button ID="btSearchProyecto" runat="server" Text="Buscar" OnClick="btSearchProyecto_Click" /> 
                        </td>
                        <td align="left" width="480px">
                        <asp:Label runat="server" ID="lbProyectoDenominacion"></asp:Label>
                        </td>
                    </tr>
                    <tr>                    
                        <td align="center" colspan="5" style="color: Red; margin: 10px">
                        <br />
                            <asp:Label ID="lblErrorProducto" runat="server" Text="" Visible ="false"></asp:Label>
                        </td>
                    </tr>                                            
                </table>
<br />
<br />
<br />
                <table width="100%" cellpadding="0" cellspacing="5">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveProductos" Text="Aceptar" OnClick="btSaveProducto_Click" runat="server"
                                ValidationGroup="vgProductos" />
                            <asp:Button ID="btNewProductos" Text="Aceptar y Agregar Nuevo" OnClick="btNewProducto_Click"
                                runat="server" ValidationGroup="vgProductos" />
                            <asp:Button ID="btCancelProductos" Text="Cerrar" OnClick="btCancelProducto_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProductos" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="ProductosPopUpDragHandle" PopupControlID="PopUpProductos"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
