<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoFilter.ascx.cs"
    Inherits="UI.Web.ProyectoSeguimientoFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td>
            <asp:Literal ID="liSaf" Text="Saf" runat="server"></asp:Literal>&nbsp;</td>
        <td class="tdFilter">
            <asp:DropDownList ID="ddlSaf" runat="server">
            </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
            <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="FilterProyectoSeguimiento"
                Text="*" Width="1px" Height="1px" ErrorMessage="El Denominación no es válido"></asp:RegularExpressionValidator>
        </td>
        <td class="tdFilter">
            <asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input"></asp:TextBox>
        </td>
        <td>
        </td>
        <td class="tdFilter" style="width: 95px" rowspan="3">
          
                <asp:Literal ID="liEstado" Text="Estado" runat="server"></asp:Literal>&nbsp;
        </td>
        <td style="width: 95px" rowspan="3">
                <asp:ListBox ID="lbxEstado" runat="server" CssClass="field_input" SelectionMode="Multiple"
                    Rows="3" Height="95px"></asp:ListBox>
          
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="liAnalista" Text="Analista" runat="server"></asp:Literal>&nbsp;
        </td>
        <td class="tdFilter">
            <asp:DropDownList ID="ddlAnalista" runat="server">
            </asp:DropDownList>
        </td>
        <td>
        </td>
        <td>
            <asp:Literal ID="liMalla" Text="Malla" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                ID="revMalla" runat="server" ControlToValidate="txtMalla" ValidationGroup="FilterProyectoSeguimiento"
                Text="*" Width="1px" Height="1px" ErrorMessage="La Malla no es válida"></asp:RegularExpressionValidator>
        </td>
        <td class="tdFilter">
            <asp:TextBox ID="txtMalla" runat="server" CssClass="field_input"></asp:TextBox>
        </td>
        <td class="tdFilter">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td>
            <asp:Literal ID="liRuta" Text="Ruta" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                ID="revRuta" runat="server" ControlToValidate="txtRuta" ValidationGroup="FilterProyectoSeguimiento"
                Text="*" Width="1px" Height="1px" ErrorMessage="La Ruta no es válida"></asp:RegularExpressionValidator>
        </td>
        <td class="tdFilter">
            <asp:TextBox ID="txtRuta" runat="server" CssClass="field_input"></asp:TextBox>
        </td>
        <td>
        </td>      
        <td class="tdFilter" >
            <asp:Literal ID="liNroProyecto" Text="Código BAPIN" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNroProyecto" runat="server"  ControlToValidate="txtNroProyecto" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ErrorMessage="El Nro. de Proyecto no es válido"></asp:RegularExpressionValidator>
        </td>
        <td>
            <asp:TextBox ID="txtNroProyecto" runat="server" type="text" min="0" CssClass="field_input"  ></asp:TextBox>
		 </td>  
    </tr>
    <tr>     
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td></td>
        <td align="right" valign="bottom" colspan ="2">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="FilterProyectoSeguimiento" />
        </td>
    </tr>
</table>
