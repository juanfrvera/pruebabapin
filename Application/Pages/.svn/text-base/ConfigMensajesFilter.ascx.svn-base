<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigMensajesFilter.ascx.cs" Inherits="UI.Web.ConfigMensajesFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>

<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liPagina" Text="Página" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revPagina" runat="server" ControlToValidate="txtPagina" ValidationGroup="FilterConfigMensajes" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:TextBox ID="txtPagina" runat="server" CssClass="field_input"></asp:TextBox>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liTipoOperacion" Text="Tipo operación" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revTipoOperacion" runat="server" ControlToValidate="cboTipoOperacion" ValidationGroup="FilterConfigMensajes" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:DropDownList ID="cboTipoOperacion" type="text" runat="server" CssClass="field_input">
                    <asp:ListItem Value="0" Selected="True">Seleccione</asp:ListItem>
                    <asp:ListItem Value="1">Alta</asp:ListItem>
                    <asp:ListItem Value="2">Baja</asp:ListItem>
                    <asp:ListItem Value="3">Modificación</asp:ListItem>
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liAsunto" Text="Asunto" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revAsunto" runat="server" ControlToValidate="txtAsunto" ValidationGroup="FilterConfigMensajes" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:TextBox Width="300" ID="txtAsunto" runat="server" CssClass="field_input"></asp:TextBox>
            </div>
        </td>

    </tr>
   
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liMensaje" Text="Info. Mensaje" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revMensaje" runat="server" ControlToValidate="txtMensaje" ValidationGroup="FilterConfigMensajes" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </div>
            <div>
                <asp:TextBox TextMode="MultiLine" Width="300" Height="50" ID="txtMensaje" runat="server" CssClass="field_input"></asp:TextBox>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">&nbsp;</td>
        <td class="tdFilter">&nbsp;</td>
        <td class="tdFilter">&nbsp;</td>
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" Visible="true" OnClick="btClear_Click" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" Visible="true" ValidationGroup="FilterConfigMensajes" OnClick="btSearch_Click" />
        </td>
    </tr>
</table>
