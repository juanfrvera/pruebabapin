<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="DictamenTipoEdit.ascx.cs" Inherits="UI.Web.DictamenTipoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  >Nombre</td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionDictamenTipo"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Nombre no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  >Nivel</td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNivel" runat="server" ControlToValidate="txtNivel"  ValidationGroup="EditionDictamenTipo"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Nivel no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtNivel" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	</table>
