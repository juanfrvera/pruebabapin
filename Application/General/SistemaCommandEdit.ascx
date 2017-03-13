<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaCommandEdit.ascx.cs" Inherits="UI.Web.SistemaCommandEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaCommand"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaCommand"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDescripcion" Text="Descripcion" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescripcion" runat="server"   ControlToValidate="txtDescripcion"  ValidationGroup="EditionSistemaCommand"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtDescripcion"  Width="100%"  MaxLength="250"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="lisistemaEntidad" Text="sistemaEntidad" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlsistemaEntidad" runat="server" CssClass="field_input"     ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvsistemaEntidad" InitialValue="0" runat="server" ControlToValidate="ddlsistemaEntidad"  ValidationGroup="EditionSistemaCommand"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liCommandText" Text="CommandText" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCommandText" runat="server"   ControlToValidate="txtCommandText"  ValidationGroup="EditionSistemaCommand"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCommandText" runat="server" ControlToValidate="txtCommandText"  ValidationGroup="EditionSistemaCommand"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCommandText"  Width="100%"  MaxLength="2000"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>	
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
