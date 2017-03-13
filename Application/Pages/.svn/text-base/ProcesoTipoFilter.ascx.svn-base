<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProcesoTipoFilter.ascx.cs" Inherits="UI.Web.ProcesoTipoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterProcesoTipo" Text="*" Width="1px" Height="1px"  ErrorMessage="El Nombre no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter"  ><div ><asp:Literal ID="liNivel" Text="Nivel" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNivel" runat="server"  ControlToValidate="txtNivel" ValidationGroup="FilterProcesoTipo" Text="*" Width="1px" Height="1px"  ErrorMessage="El Nivel no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNivel" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >&nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" /></td>
		</tr>
</table>
