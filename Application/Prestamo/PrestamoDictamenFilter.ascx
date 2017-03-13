<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenFilter.ascx.cs"
    Inherits="UI.Web.PrestamoDictamenFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<style type="text/css">
    .style1
    {
        width: 240px;
    }
</style>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liOrganismo" Text="Organismo" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvOrganismo" runat="server" ControlToValidate="ddlOrganismo" ValidationGroup="FilterPrestamoDictamen"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlOrganismo" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liOrganismoFinanciero" Text="Organismo Financiero" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvOrganismoFinanciero" runat="server" ControlToValidate="ddlOrganismoFinanciero"
                    ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlOrganismoFinanciero" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liGestionTipo" Text="Tipo de Gestión" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvGestionTipo" runat="server" ControlToValidate="ddlGestionTipo" ValidationGroup="FilterPrestamoDictamen"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlGestionTipo" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter" rowspan="2" style="padding: 10px; width: 130px">
            Nro Secuencial
            <asp:Panel runat="server" ID="pnlNumeroSecuencial" BorderWidth="1" BackColor=" #e6f7ff" 
                Style="padding: 10px">
                <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                    <tr>
                        <td>
                            <div>
                                <asp:Literal ID="liNumeroSecuencialDesde" Text="Desde" runat="server"></asp:Literal></div>
                            <div>
                                <asp:TextBox ID="txtNumeroSecuencialDesde" type="text" min="0" runat="server" CssClass="field_input"
                                    Width="90px"></asp:TextBox></div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div>
                                <asp:Literal ID="liNumeroSecuencialHasta" Text="Hasta" runat="server"></asp:Literal></div>
                            <div>
                                <asp:TextBox ID="txtNumeroSecuencialHasta" type="text" min="0" runat="server" CssClass="field_input"
                                    Width="90px"></asp:TextBox></div>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liExpediente" Text="Expediente" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revExpediente" runat="server" ControlToValidate="txtExpediente" ValidationGroup="FilterPrestamoDictamen"
                    Text="*" Width="1px" Height="1px" ErrorMessage="El Expediente no es válido"></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtExpediente" runat="server" CssClass="field_input"></asp:TextBox></div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liAnalista" Text="Analista" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvAnalista" runat="server" ControlToValidate="ddlAnalista" ValidationGroup="FilterPrestamoDictamen"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlAnalista" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="Literal1" Text="Estado" runat="server"></asp:Literal>
            </div>
            <div>
                <asp:ListBox ID="lbxEstado" runat="server" CssClass="field_input" SelectionMode="Multiple" Rows="4"  Height="70px" Width="205px" ></asp:ListBox>
            </div>
        </td>
        <td class="tdFilter">
            &nbsp;
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="legend" style="color: #0099ff; font-weight: bold; height: 30px;">
            <div style="cursor: hand; width: 150px">
                <asp:Label ID="lblBusquedaAvanzada" runat="server" Text="Búsqueda Avanzada"></asp:Label>
                &nbsp;
                <asp:Image ID="imgCollapsiblePanel" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeBusquedaAvanzada" runat="Server" TargetControlID="pnlBusquedaAvanzada"
                Collapsed="True" ExpandControlID="lblBusquedaAvanzada" CollapseControlID="lblBusquedaAvanzada"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td colspan="4">
            <asp:Panel ID="pnlBusquedaAvanzada" runat="server">
                <table width="100%" cellpadding="0" cellspacing="0" border="0">
                    <tr>
                        <td class="style1">
                            <asp:Panel runat="server" GroupingText="Entre Fechas de Alta" 
                                ID="PnlFechaIngreso" Width="160px">
                                <table width="100%" cellpadding="0" cellspacing="0" border="0" align="center">
                                    <tr>
                                        <td >
                                            <%--<div>
                                                <asp:Literal ID="liFechaAltaDesde" Text="Desde" runat="server"></asp:Literal></div>
                                            <div>
                                                <uc:DateInput runat="server" ID="diFechaAltaDesde" Width="75px" />
                                            </div>--%>
                                            <uc:DateRangeInput runat="server" ID="rdFechaAlta" ValidationGroup="FilterPrestamoDictamen" TagTo=""  TagFrom="" />
                                        <%--</td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <div>
                                                <asp:Literal ID="liFechaAltaHasta" Text="Hasta" runat="server"></asp:Literal></div>
                                            <div>
                                                <uc:DateInput runat="server" ID="diFechaAltaHasta" Width="75px" />
                                            </div>--%>
                                        </td>
                                    </tr>
                                </table>
                            </asp:Panel>
                        </td>
                        <td class="tdFilter">
                            <table cellspacing="5px" style="width: 335px; height: 104px">
                                <tr>
                                    <td class="tdFilter">
                                        <div>
                                            <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>
                                            &nbsp;<asp:RegularExpressionValidator
                                                ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="FilterPrestamoDictamen"
                                                Text="*" Width="1px" Height="1px" ErrorMessage="La Denominación no es válida"></asp:RegularExpressionValidator></div>
                                        <div>
                                            <asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input"></asp:TextBox></div>
                                    </td>
                                    <td class="tdFilter">
                                        <div>
                                            <asp:Literal ID="liCalificacionNotaDNIP" Text="Nota DNIP" runat="server"></asp:Literal>
                                            &nbsp;<asp:RegularExpressionValidator
                                                ID="revCalificacionNotaDNIP" runat="server" ControlToValidate="txtCalificacionNotaDNIP"
                                                ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="LA Nota DNIP no es válido"></asp:RegularExpressionValidator></div>
                                        <div>
                                            <asp:TextBox ID="txtCalificacionNotaDNIP" runat="server" CssClass="field_input"></asp:TextBox></div>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdFilter">
                                        <div>
                                            <asp:Literal ID="liNumeroPrestamo" Text="Nro. de Préstamo" runat="server"></asp:Literal>
                                            &nbsp;<asp:RegularExpressionValidator
                                                ID="revNumeroPrestamo" runat="server" ControlToValidate="txtNumeroPrestamo" ValidationGroup="FilterPrestamoDictamen"
                                                Text="*" Width="1px" Height="1px" ErrorMessage="El Número de Préstamo no es válido"></asp:RegularExpressionValidator></div>
                                        <div>
                                            <asp:TextBox ID="txtNumeroPrestamo" type="text" min="0" runat="server" CssClass="field_input"></asp:TextBox></div>
                                    </td>
                                    <td class="tdFilter">
                                        <div>
                                            <asp:Literal ID="liCalificacionITecnico" Text="Informe Técnico" runat="server"></asp:Literal>
                                            &nbsp;<asp:RegularExpressionValidator
                                                ID="revCalificacionITecnico" runat="server" ControlToValidate="txtCalificacionITecnico"
                                                ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El I.Técnico no es válido"></asp:RegularExpressionValidator></div>
                                        <div>
                                            <asp:TextBox ID="txtCalificacionITecnico" runat="server" CssClass="field_input"></asp:TextBox></div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="FilterPrestamoDictamen" />
        </td>
    </tr>
</table>
