<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoEdit.ascx.cs"
    Inherits="UI.Web.PrestamoEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeFinalidad" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeSelect" Src="~/Controls/WebControl_TreeSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<%--Datos Generales--%>
<asp:UpdatePanel ID="upDatosGenerales" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlDatosGenerales" runat="server" GroupingText="Datos Generales" Width="100%">
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="0" border="0" width="100%">
                            <tr>
                                <td class="tdLabel" style="width: 140px">
                                    <asp:Literal ID="liSAF" Text="SAF" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <cc:ExtendedDropDownList ID="ddlSAF" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlSaf_IndexChanged" AutoPostBack="true" SkinID="AnchoLibre" Width="770px">
                                    </cc:ExtendedDropDownList>
                                </td>
                                <td class="filaValidator" style="width: 5px">
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvSAF" runat="server" ControlToValidate="ddlSAF"
                                        ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel" style="width: 140px">
                                    <asp:Literal ID="liPrograma" Text="Programa" runat="server"></asp:Literal>
                                </td>
                                <td class="filaInput">
                                    <cc:ExtendedDropDownList ID="ddlPrograma" runat="server" CssClass="field_input" AutoPostBack="true" Enabled="false" SkinID="AnchoLibre" Width="770px">
                                    </cc:ExtendedDropDownList>
                                </td>
                                <td class="filaValidator" style="width: 5px">
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ControlToValidate="ddlPrograma"
                                        ValidationGroup="EditionPrestamo" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>
                    </td>                    
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="width: 140px">
                        <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtDenominacion" runat="server" Rows="2" TextMode="MultiLine" Width="765px"></asp:TextBox>
                    </td>
                    <td>
                        &nbsp;<asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td style="width: 140px">
                        <asp:Literal ID="liResponsablePolítico" Text="Responsable Político" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtResponsablePolitico" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                        &nbsp
                        <asp:RegularExpressionValidator ID="revResponsablePolitico" runat="server" ControlToValidate="txtResponsablePolitico"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 140px">
                        <asp:Literal ID="liCodigoVinculacion" Text="Código de Vinculación 1" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigoVinculacion1" runat="server" Width="250px" MaxLength="50"></asp:TextBox>
                        &nbsp
                        <asp:RegularExpressionValidator ID="revCodigoVinculacion" runat="server" ControlToValidate="txtCodigoVinculacion1"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td style="width: 140px">
                        <asp:Literal ID="liResponsableTecnico" Text="Responsable Técnico" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtResponsableTecnico" runat="server" Width="250px" MaxLength="100"></asp:TextBox>
                        &nbsp
                        <asp:RegularExpressionValidator ID="revResponsableTecnico" runat="server" ControlToValidate="txtResponsableTecnico"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                    </td>
                    <td style="width: 140px">
                        <asp:Literal ID="liCodigoVinculacion2" Text="Código de Vinculación 2" runat="server"></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtCodigoVinculacion2" runat="server" Width="250px" MaxLength="50"></asp:TextBox>&nbsp
                        <asp:RegularExpressionValidator ID="revCodigoVinculacion2" runat="server" ControlToValidate="txtCodigoVinculacion2"
                            ValidationGroup="EditionPrestamo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan='3'>
                        <br />
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="0" border="0">
                <tr>
                    <td valign="top" style="width: 60%;" align="left">
                        <asp:Panel ID="pnlOficinasYFuncionarios" runat="server" GroupingText="Oficina y Funcionarios"
                            Width="100%">
                            <table cellpadding="0" cellspacing="0px" border="0">
                                <tr>
                                    <td class="filaInput" style="width: 110px">
                                        <asp:Literal ID="liResponsable" Text="Responsable" runat="server"></asp:Literal><br />
                                    </td>
                                    <td class="filaInput" valign="bottom">
                                        <uc:TreeOficinas runat="server" ID="toResponsable" Width="440px" OnValueChanged="toResponsable_OnValueChanged"
                                            SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" Autopostback="true"    >
                                        </uc:TreeOficinas>
                                    </td>
                                    <td class="filaInput" valign="middle">
                                        <asp:ImageButton ID="imgFuncionarios" runat="server" ImageUrl="~/Images/funcionario.png"
                                            ToolTip="Funcionarios" OnClick="funcionarios_Click" />
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>

            <asp:Panel ID="Panel2" runat="server" GroupingText="Estados" Width="100%">
                <table width="100%">
                    <tr>
                        <td align="right">
                            <asp:Button ID="btAgregarEstado" runat="server" Text="Agregar" OnClick="btAgregarEstado_Click"
                                TabIndex="1" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:GridView ID="gridEstados" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                AllowPaging="True" OnRowCommand="GridEstados_RowCommand" AllowSorting="True"
                                OnSorting="GridEstados_Sorting" OnPageIndexChanging="GridEstados_PageIndexChanging"
                                EmptyDataText="No hay Estados definidos" Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Estado" DataField="Estado_Nombre" SortExpression="Estado_Nombre" />
                                    <asp:BoundField HeaderText="Fecha" DataField="FechaEstimada" SortExpression="FechaEstimada"
                                        DataFormatString="{0:dd/MM/yyyy}" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                            <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                                CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                                CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<table width="100%" cellpadding="0" border="0">
    <tr>
        <td>
            <div class="CollapsiblePanelTab">
                <span id="spanOficina">
                    <asp:Label ID="lblOficinas" runat="server" Text="Oficinas Asociadas"></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeOficinas" runat="Server" TargetControlID="pnlOficinas"
                    Collapsed="True" ExpandControlID="spanOficina" CollapseControlID="spanOficina"
                    AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlOficinas" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:UpdatePanel ID="pnlAgregarOficina" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btAgregarOficina" runat="server" Text="Agregar" OnClick="btAgregarOficina_Click"
                                                    TabIndex="2" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="upGridOficinas" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridOficinas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                            AllowPaging="True" OnRowCommand="GridOficinas_RowCommand" AllowSorting="True"
                            OnSorting="GridOficinas_Sorting" OnPageIndexChanging="GridOficinas_PageIndexChanging"
                            EmptyDataText="No hay Oficinas definidas" Width="99%">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="Oficina_BreadcrumbCode" SortExpression="Oficina_BreadcrumbCode"
                                    ItemStyle-HorizontalAlign="Left" ItemStyle-Width="150px" />
                                <asp:BoundField HeaderText="Descripción" DataField="Oficina_DescripcionInvertida" SortExpression="Oficina_DescripcionInvertida"
                                    ItemStyle-HorizontalAlign="Left" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" border="0">
    <tr>
        <td>
            <div class="CollapsiblePanelTab">
                <span id="spanClasificacion">
                    <asp:Label ID="lblClasificaciones" runat="server" Text="Clasificación Funcional"></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeClasificaciones" runat="Server" TargetControlID="pnlClasificaciones"
                    Collapsed="True" ExpandControlID="spanClasificacion" CollapseControlID="spanClasificacion"
                    AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlClasificaciones" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:UpdatePanel ID="pnlAgregarClasificacion" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:Button ID="btAgregarClasificacion" runat="server" Text="Agregar" OnClick="btAgregarClasificacion_Click"
                                                    TabIndex="2" />
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <asp:UpdatePanel ID="upGridClasificaciones" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridClasificaciones" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="True" OnRowCommand="GridClasificaciones_RowCommand"
                            AllowSorting="True" OnSorting="GridClasificaciones_Sorting" OnPageIndexChanging="GridClasificaciones_PageIndexChanging"
                            EmptyDataText="No hay Clasificaciones definidas" Width="99%">
                            <Columns>
                                <asp:BoundField HeaderText="Código" DataField="FinalidadFuncion_BreadcrumbCode" SortExpression="FinalidadFuncion_BreadcrumbCode"
                                    ItemStyle-HorizontalAlign="Left" />
                                <asp:BoundField HeaderText="Descripción" DataField="FinalidadFuncion_Descripcion"
                                    SortExpression="FinalidadFuncion_Descripcion" ItemStyle-HorizontalAlign="Left" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                        <br />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" border="0">
    <tr>
        <td>
            <div class="CollapsiblePanelTab">
                <span id="spanDescripcion">
                    <asp:Label ID="lblDescripcion" runat="server" Text="Descripción"></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeDescripcion" runat="Server" TargetControlID="pnlDescripcion"
                    Collapsed="True" ExpandControlID="spanDescripcion" CollapseControlID="spanDescripcion"
                    AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlDescripcion" runat="server">
                <asp:UpdatePanel ID="upDescripcion" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtDescripcion" runat="server" Rows="7" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" border="0">
    <tr>
        <td>
            <div class="CollapsiblePanelTab">
                <span id="spanObservaciones">
                    <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeObservaciones" runat="Server" TargetControlID="pnlObservaciones"
                    Collapsed="True" ExpandControlID="spanObservaciones" CollapseControlID="spanObservaciones"
                    AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlObservaciones" runat="server">
                <asp:UpdatePanel ID="upObservaciones" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:TextBox ID="txtObservaciones" runat="server" Rows="7" TextMode="MultiLine" Width="98%"></asp:TextBox>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </td>
    </tr>
</table>
<%--PANEL ALTA ESTADOS --%>
<asp:Panel ID="PopUpEstados" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EstadosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEstados" runat="server" Text="Estado" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEstados" DefaultButton="btSaveEstados" Height="100px" runat="server">
        <asp:UpdatePanel ID="upEstadosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <table>
                                <tr>
                                    <td align="left">
                                        <asp:Literal ID="ltEstado" Text="Estado:" runat="server"></asp:Literal><br />
                                        <asp:DropDownList ID="ddlEstado" runat="server" Width="250px">
                                        </asp:DropDownList>
                                    </td>
                                    <td align="left">
                                        <asp:Literal ID="Literal1" Text="Fecha:" runat="server"></asp:Literal><br />
                                        <div>
                                            <uc:DateInput runat="server" ID="diFechaEstimada" Width="80px" IsValidEmpty="false"
                                                ValidationGroup="vgEstados" />
                                        </div>
                                        <%--   <asp:Label ID="lblFechaHoy" runat="server" Text=""></asp:Label> --%>
                                    </td>
                                </tr>
                                <tr>
                                    <td align="center" colspan="2" style="color: Red; margin: 10px">
                                        <asp:Label ID="lblErrorEstado" runat="server" Text="" Visible="false"></asp:Label>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveEstados" Text="Aceptar" OnClick="btSaveEstado_Click" runat="server"
                                ValidationGroup="vgEstados" />
                            <asp:Button ID="btNewEstados" Text="Aceptar y Agregar Nuevo" OnClick="btNewEstado_Click"
                                runat="server" ValidationGroup="vgEstados" />
                            <asp:Button ID="btCancelEstados" Text="Cerrar" OnClick="btCancelEstado_Click" runat="server"
                                Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEstados" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="EstadosPopUpDragHandle" PopupControlID="PopUpEstados"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA OFICINAS --%>
<asp:Panel ID="PopUpOficinas" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="OficinasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpOficinas" runat="server" Text="Oficina" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnOficinas" defaultbutton="btSaveOficinas"  runat="server">
        <asp:UpdatePanel ID="upOficinasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px">
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal2" runat="server" Text="Oficina:"></asp:Literal>
                                    </td>
                                    <td>
                                        <uc:TreeOficinas ID="toOficinas" runat="server"  RequiredValue="true" ValidationGroup="vgOficinas"
                                            SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"  
                                            Width="650px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveOficinas" Text="Aceptar" OnClick="btSaveOficina_Click" runat="server"
                                ValidationGroup="vgOficinas"  />
                            <asp:Button ID="btNewOficinas" Text="Aceptar y Agregar Nuevo" OnClick="btNewOficina_Click"
                                runat="server"  ValidationGroup="vgOficinas" />
                            <asp:Button ID="btCancelOficinas" Text="Cerrar" OnClick="btCancelOficina_Click" runat="server"
                                Width="60px"  />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsOficinas" runat="server" DisplayMode="BulletList" ValidationGroup="vgOficinas"
        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>	
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderOficinas" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="OficinasPopUpDragHandle" PopupControlID="PopUpOficinas"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA CLASIFICACIONES --%>
<asp:Panel ID="PopUpClasificaciones" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ClasificacionesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpClasificaciones" runat="server" Text="Clasificacion" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnClasificaciones" DefaultButton="btSaveClasificaciones" runat="server">
        <asp:UpdatePanel ID="upClasificacionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px">
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal3" runat="server" Text="Clasificación:"></asp:Literal>
                                    </td>
                                    <td>
                                        <uc:TreeFinalidad ID="toFinalidad" runat="server" 
                                            SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" 
                                            Width="650px" />
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveClasificaciones" Text="Aceptar" OnClick="btSaveClasificacion_Click"
                                runat="server" ValidationGroup="vgClasificaciones" />
                            <asp:Button ID="btNewClasificaciones" Text="Aceptar y Agregar Nuevo" OnClick="btNewClasificacion_Click"
                                runat="server" ValidationGroup="vgClasificaciones" />
                            <asp:Button ID="btCancelClasificaciones" Text="Cerrar" OnClick="btCancelClasificacion_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderClasificaciones" runat="server"
        CancelControlID="Button4" PopupDragHandleControlID="ClasificacionesPopUpDragHandle"
        PopupControlID="PopUpClasificaciones" OkControlID="Button4" TargetControlID="Button4"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL SELECCION FUNCIONARIOS--%>
<asp:Panel ID="PopUpFuncionariosResponsable" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FuncionariosResponsablePopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpFuncionariosResponsable" runat="server" Text="Funcionarios" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFuncionariosResponsable" DefaultButton="btCancelFuncionariosResponsable" runat="server">
        <asp:UpdatePanel ID="upFuncionariosResponsablePopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                        </td>
                        <td>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="250px">
                                <asp:DataList ID="dlFuncionarioResponsable" runat="server" RepeatColumns="1" RepeatDirection="Horizontal"
                                    Width="80%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Usuario_ApellidoYNombre") %>'
                                            runat="server" />
                                        <asp:HiddenField ID="hdValue" Value='<%# Bind("IdUsuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelFuncionariosResponsable" Text="Cerrar" OnClick="btCancelFuncionarios_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button8" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFuncionariosResponsable" runat="server"
        CancelControlID="Button8" PopupDragHandleControlID="FuncionariosResponsablePopUpDragHandle"
        PopupControlID="PopUpFuncionariosResponsable" OkControlID="Button8" TargetControlID="Button8"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
