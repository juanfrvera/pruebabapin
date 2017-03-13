<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaracterEconomicoFilter.ascx.cs" Inherits="UI.Web.CaracterEconomicoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterCaracterEconomico" Text="*" Width="1px" Height="1px"  ErrorMessage="El Codigo no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterCaracterEconomico" Text="*" Width="1px" Height="1px"  ErrorMessage="El Nombre no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liTipoCaracterEconomico" Text="Tipo de Caracter Económico" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvCaracterEconomicoTipo" runat="server" ControlToValidate="ddlCaracterEconomicoTipo"  ValidationGroup="FilterCaracterEconomico" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlCaracterEconomicoTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liCaracterEconomicoPadre" Text="Caracter Económico Padre" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvCaracterEconomicoPadre" runat="server" ControlToValidate="ddlCaracterEconomicoPadre"  ValidationGroup="FilterCaracterEconomico" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlCaracterEconomicoPadre" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >&nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" /></td>
		</tr>
</table>
