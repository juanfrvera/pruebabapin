<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoAlcanceGeograficoEdit.ascx.cs" Inherits="UI.Web.ProyectoAlcanceGeograficoEdit" %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>

<div class="TabbedPanelsContent">
    <asp:Panel ID="pnlLocalizacionGeografica" runat="server" GroupingText="Localización Geográfica">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                        <tr>
                            <td align="right">
                                <asp:UpdatePanel ID="pnlAgregarLocalizacion" runat="server" UpdateMode="Conditional">
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarLocalizacion" runat="server" Text="Agregar" OnClick="btAgregarLocalizacion_Click" TabIndex="1" />
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="upGridLocalizaciones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridLocalizaciones" runat="server"
                    AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True"
                    OnRowCommand="GridLocalizaciones_RowCommand"
                    AllowSorting="True" OnSorting="GridLocalizaciones_Sorting"
                    OnPageIndexChanging="GridLocalizaciones_PageIndexChanging"
                    EmptyDataText="No hay Localizaciones definidas"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Descripción" DataField="Descripcion" SortExpression="Descripcion" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                            <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                            <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <div class="CollapsiblePanelTab">
                    <span id="spanAlcance">
                        <asp:Label ID="lblAlcanceGeografico" runat="server" Text="Alcance Geográfico"></asp:Label>
                        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                    </span>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeAlcanceGeografico" runat="Server"
                        TargetControlID="pnlAlcanceGeografico"
                        Collapsed="True"
                        ExpandControlID="spanAlcance"
                        CollapseControlID="spanAlcance"
                        AutoCollapse="False"
                        AutoExpand="False"
                        ExpandDirection="Vertical" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlAlcanceGeografico" runat="server">
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:UpdatePanel ID="pnlAgregarAlcance" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Button ID="btAgregarAlcance" runat="server" Text="Agregar" OnClick="btAgregarAlcance_Click" TabIndex="2" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="upGridAlcances" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gridAlcances" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True"
                                OnRowCommand="GridAlcances_RowCommand"
                                AllowSorting="True" OnSorting="GridAlcances_Sorting"
                                OnPageIndexChanging="GridAlcances_PageIndexChanging"
                                EmptyDataText="No hay Alcances geográficos definidos"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" SortExpression="Descripcion" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                            &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <div class="CollapsiblePanelTab">
                    <span id="spanGeoref">
                        <asp:Label ID="lblGeoreferenciacion" runat="server" Text="Georeferenciación"></asp:Label>
                        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                    </span>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeGeoreferenciacion" runat="Server"
                        TargetControlID="pnlGeoreferenciacion"
                        Collapsed="True"
                        ExpandControlID="spanGeoref"
                        CollapseControlID="spanGeoref"
                        AutoCollapse="False"
                        AutoExpand="False"
                        ExpandDirection="Vertical" />
                </div>
            </td>
        </tr>
        <tr>
            <td>
                <asp:Panel ID="pnlGeoreferenciacion" runat="server">
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td>
                                <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                                    <tr>
                                        <td align="right">
                                            <asp:UpdatePanel ID="pnlAgregarGeoreferenciacion" runat="server" UpdateMode="Conditional">
                                                <ContentTemplate>
                                                    <asp:Button ID="btAgregarGeoreferenciacion" runat="server" Text="Agregar" OnClick="btAgregarGeoreferenciacion_Click" TabIndex="2" />
                                                </ContentTemplate>
                                            </asp:UpdatePanel>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <asp:UpdatePanel ID="upGridGeoreferenciaciones" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:GridView ID="gridGeoreferenciaciones" runat="server"
                                AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True"
                                OnRowCommand="GridGeoreferenciaciones_RowCommand"
                                AllowSorting="True" OnSorting="GridGeoreferenciaciones_Sorting"
                                OnPageIndexChanging="GridGeoreferenciaciones_PageIndexChanging"
                                EmptyDataText="No hay Georeferenciaciones definidos"
                                Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Tipo" DataField="NombreTipo" SortExpression="NombreTipo" />
                                    <asp:BoundField HeaderText="Descripción" DataField="Descripcion" SortExpression="Descripcion" />
                                    <asp:BoundField HeaderText="Orden: Latitud:Longitud" DataField="Detalle" SortExpression="Detalle" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                            &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</div>

<%--PANEL ALTA LOCALIZACIONES --%>
<asp:Panel ID="PopUpLocalizaciones" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="LocalizacionesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpLocalizaciones" runat="server" Text="Localización" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnLocalizaciones" DefaultButton="btSaveLocalizaciones" Height="100px" runat="server">
        <asp:UpdatePanel ID="upLocalizacionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table>
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px"></td>
                                    <td>
                                        <asp:Literal ID="ltLocalizacion" Text="Localización:" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <uc:TreeLocalizacion runat="server" ID="tsLocalizacion" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"></uc:TreeLocalizacion>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveLocalizaciones" Text="Aceptar" OnClick="btSaveLocalizacion_Click" runat="server" ValidationGroup="vgLocalizaciones" />
                            <asp:Button ID="btNewLocalizaciones" Text="Aceptar y Agregar Nuevo" OnClick="btNewLocalizacion_Click" runat="server" ValidationGroup="vgLocalizaciones" />
                            <asp:Button ID="btCancelLocalizaciones" Text="Cerrar" OnClick="btCancelLocalizacion_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderLocalizaciones" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="LocalizacionesPopUpDragHandle" PopupControlID="PopUpLocalizaciones"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA ALCANCES --%>
<asp:Panel ID="PopUpAlcances" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="AlcancesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpAlcances" runat="server" Text="Alcance Geográfico" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnAlcances" DefaultButton="btSaveAlcances" runat="server">
        <asp:UpdatePanel ID="upAlcancesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <td style="width: 62px"></td>
                                <td>
                                    <asp:Literal ID="Literal1" Text="Alcance Geográfico:" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <uc:TreeLocalizacion runat="server" ID="tsAlcanceGeografico" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"></uc:TreeLocalizacion>
                                </td>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveAlcances" Text="Aceptar" OnClick="btSaveAlcance_Click" runat="server" ValidationGroup="vgAlcances" />
                            <asp:Button ID="btNewAlcances" Text="Aceptar y Agregar Nuevo" OnClick="btNewAlcance_Click" runat="server" ValidationGroup="vgAlcances" />
                            <asp:Button ID="btCancelAlcances" Text="Cerrar" OnClick="btCancelAlcance_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>

            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderAlcances" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="AlcancesPopUpDragHandle" PopupControlID="PopUpAlcances"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA GEOREFERENCIACIONES --%>
<asp:Panel ID="PopUpGeoreferenciaciones" runat="server" Width="650px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="GeoreferenciacionesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpGeoreferenciaciones" runat="server" Text="Georeferenciación" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnGeoreferenciaciones" runat="server">
        <asp:UpdatePanel ID="upGeoreferenciacionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" style="text-align: center;">
                    <tr>
                        <td>
                            <table width="75%">
                                <tr>
                                    <td style="width: 1px"></td>
                                    <td style="text-align: left;">
                                        <asp:Literal ID="liTipoGeo" Text="Tipo :" runat="server"></asp:Literal>
                                        <asp:RadioButton runat="server" ID="rbPunto" GroupName="Tipo" Text="Punto" OnCheckedChanged="rbGeoTipo_OnCheckedChanged" AutoPostBack="true" Checked="true" />
                                        <asp:RadioButton runat="server" ID="rbLinea" GroupName="Tipo" Text="Línea" OnCheckedChanged="rbGeoTipo_OnCheckedChanged" AutoPostBack="true" />
                                        <asp:RadioButton runat="server" ID="rbPoligono" GroupName="Tipo" Text="Polígono" OnCheckedChanged="rbGeoTipo_OnCheckedChanged" AutoPostBack="true" />
                                    </td>
                                    <td>
                                        <asp:Literal ID="ltPuntoDescripcion" Text="Descripción : " runat="server"></asp:Literal>
                                        <asp:TextBox runat="server" ID="txtDescricpion" Width="150px" MaxLength='100'></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:GridView ID="GridPuntos" runat="server" Width="100%" DataKeyNames="ID"
                                            AutoGenerateColumns="False" AllowSorting="True">
                                            <Columns>
                                                <asp:BoundField DataField="Orden" HeaderText="Orden" SortExpression="Orden" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="Latitud" HeaderText="Latitud" SortExpression="Latitud" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:BoundField DataField="Longitud" HeaderText="Longitud" SortExpression="Longitud" DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right" />
                                                <asp:TemplateField ItemStyle-HorizontalAlign="Right">
                                                    <ItemTemplate>
                                                        <asp:ImageButton ID="btDeletePunto" runat="server" src="../Images/delete.jpg" ToolTip='<%# Translate("Eliminar") %>' OnClick="btDeletePunto_Click" CausesValidation="false" CommandArgument='<%#Eval("ID")%>' />
                                                    </ItemTemplate>
                                                    <ItemStyle Width="80px" />
                                                </asp:TemplateField>
                                            </Columns>
                                        </asp:GridView>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">&nbsp;</td>
                                </tr>
                                <tr>
                                <tr>
                                    <td colspan="3" align="left">
                                        <table width="100%">
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="ltPuntoOrden" Text="Orden : " runat="server"></asp:Literal></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtOrden" Width="70px" Text="1"></asp:TextBox></td>
                                                <td style="text-align: center; width: 20px">
                                                    <asp:RegularExpressionValidator ID="revOrdenGeo" runat="server" ControlToValidate="txtOrden" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvOrdenGeo" runat="server" ControlToValidate="txtOrden" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></td>
                                                <td colspan='3'></td>
                                            </tr>
                                            <tr>
                                                <td>
                                                    <asp:Literal ID="ltPuntoLongitud" Text="Longitud : " runat="server"></asp:Literal></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtLongitud" Width="70px"></asp:TextBox></td>
                                                <td style="text-align: center; width: 20px">
                                                    <asp:RegularExpressionValidator ID="revLongitudGeo" runat="server" ControlToValidate="txtLongitud" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvLongitudGeo" runat="server" ControlToValidate="txtLongitud" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Literal ID="ltPuntoLatitud" Text="Latitud : " runat="server"></asp:Literal></td>
                                                <td>
                                                    <asp:TextBox runat="server" ID="txtLatitud" Width="70px"></asp:TextBox></td>
                                                <td style="text-align: center; width: 20px">
                                                    <asp:RegularExpressionValidator ID="revLatitudGeo" runat="server" ControlToValidate="txtLatitud" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                                    <asp:RequiredFieldValidator ID="rfvLatitudGeo" runat="server" ControlToValidate="txtLatitud" ValidationGroup="vgGeoreferenciaciones" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                                </td>
                                                <td>
                                                    <asp:Button ID="btnAgregarPunto" Text="Agregar" OnClick="btAgregarPunto_Click" ValidationGroup="vgGeoreferenciaciones" runat="server" Width="60px" /></td>
                                            </tr>
                                        </table>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Label ID="lblMsjError" runat="server" Visible="false"></asp:Label></td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveGeoreferenciaciones" Text="Aceptar" OnClick="btSaveGeoreferenciacion_Click" runat="server" />
                            <asp:Button ID="btNewGeoreferenciaciones" Text="Aceptar y Agregar Nuevo" OnClick="btNewGeoreferenciacion_Click" runat="server" />
                            <asp:Button ID="btCancelGeoreferenciaciones" Text="Cerrar" OnClick="btCancelGeoreferenciacion_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderGeoreferenciaciones" runat="server" CancelControlID="Button4"
        PopupDragHandleControlID="GeoreferenciacionesPopUpDragHandle" PopupControlID="PopUpGeoreferenciaciones"
        OkControlID="Button4" TargetControlID="Button4" BackgroundCssClass="modalBackground" />
</asp:Panel>


