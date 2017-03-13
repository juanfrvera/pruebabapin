<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstadoEdit.ascx.cs" Inherits="UI.Web.EstadoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionEstado"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="400px"  MaxLength="70"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionEstado"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px"   MaxLength="2"     runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionEstado"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtOrden" type="text" min="0"  Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDescripcion" Text="Descripción" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescripcion" runat="server"   ControlToValidate="txtDescripcion"  ValidationGroup="EditionEstado"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDescripcion"  Width="100%"  MaxLength="500"  TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
