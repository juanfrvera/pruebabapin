<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramaObjetivoFilter.ascx.cs"
    Inherits="UI.Web.ProgramaObjetivoFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter" style="width: 290px">
            <div>
                <asp:Literal ID="liSaf" Text="SAF" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvSaf" runat="server" ControlToValidate="ddlSaf" ValidationGroup="FilterProgramaObjetivo"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlSaf" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlSAF_SelectedIndexChanged"
                    AutoPostBack="true">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter" style="width: 290px">
            <div>
                <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="FilterProgramaObjetivo"
                    Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input"></asp:TextBox></div>
        </td>
        <td>
            <div>
                <asp:Literal ID="liFechaAlta" Text="Fecha de Alta" runat="server"></asp:Literal></div>
            <div>
                <uc:DateInput runat="server" ID="diFechaAlta" Width="75px" />
            </div>
        </td>
        <td>
            <div>
                <asp:Literal ID="liFechaBaja" Text="Fecha de Baja" runat="server"></asp:Literal></div>
            <div>
                <uc:DateInput runat="server" ID="diFechaBaja" Width="75px" />
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liCodigo" Text="Código" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvCodigo" runat="server" ControlToValidate="ddlCodigo" ValidationGroup="FilterProgramaObjetivo"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlCodigo" runat="server" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            &nbsp;
        </td>
        <td class="tdFilter">
            &nbsp;
        </td>
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="ProgramaObjetivoFilter" />
        </td>
    </tr>
</table>
