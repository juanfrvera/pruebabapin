<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstadoTipoEdit.ascx.cs" Inherits="UI.Web.EstadoTipoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liTipoEstado" Text="Tipo de Estado" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIdTipoEstado" runat="server" ControlToValidate="txtIdTipoEstado"  ValidationGroup="EditionEstadoTipo"  Text="*" Width="1px" Height="1px"  ErrorMessage="El IdTipoEstado no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtIdTipoEstado" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionEstadoTipo"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Nombre no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="300px"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
