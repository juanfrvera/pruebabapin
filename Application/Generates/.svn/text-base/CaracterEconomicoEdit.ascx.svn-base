<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaracterEconomicoEdit.ascx.cs" Inherits="UI.Web.CaracterEconomicoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCaracterEconomico" Text="Caracter Económico" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIdCaracterEconomico" runat="server" ControlToValidate="txtIdCaracterEconomico"  ValidationGroup="EditionCaracterEconomico"  Text="*" Width="1px" Height="1px"  ErrorMessage="El IdCaracterEconomico no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtIdCaracterEconomico" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionCaracterEconomico"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Codigo no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionCaracterEconomico"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Nombre no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="200px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liTipoCaracterEconomico" Text="Tipo de Caracter Económico" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlCaracterEconomicoTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvCaracterEconomicoTipo" runat="server" ControlToValidate="ddlCaracterEconomicoTipo"  ValidationGroup="EditionCaracterEconomico"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liCaracterEconómico" Text="Caracter Económico Padre" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlCaracterEconomicoPadre" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvCaracterEconomicoPadre" runat="server" ControlToValidate="ddlCaracterEconomicoPadre"  ValidationGroup="EditionCaracterEconomico"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
