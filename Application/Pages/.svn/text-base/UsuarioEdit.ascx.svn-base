<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuarioEdit.ascx.cs" Inherits="UI.Web.UsuarioEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIdUsuario" runat="server" ControlToValidate="txtIdUsuario"  ValidationGroup="EditionUsuario"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvUsuario" runat="server" ControlToValidate="txtUsuario"  ValidationGroup="EditionUsuario"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtIdUsuario" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombreUsuario" Text="NombreUsuario" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombreUsuario" runat="server"   ControlToValidate="txtNombreUsuario"  ValidationGroup="EditionUsuario"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombreUsuario" runat="server" ControlToValidate="txtNombreUsuario"  ValidationGroup="EditionUsuario"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombreUsuario" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liClave" Text="Clave" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revClave" runat="server"   ControlToValidate="txtClave"  ValidationGroup="EditionUsuario"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvClave" runat="server" ControlToValidate="txtClave"  ValidationGroup="EditionUsuario"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtClave" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liEsSectioralista" Text="EsSectioralista" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkEsSectioralista" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liLanguage" Text="Language" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage"  ValidationGroup="EditionUsuario"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
