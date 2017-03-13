<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationEdit.ascx.cs" Inherits="UI.Web.ConfigurationEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liName" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"   ControlToValidate="txtName"  ValidationGroup="EditionConfiguration"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"  ValidationGroup="EditionConfiguration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtName" Width="400px"  MaxLength="70"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCode" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"   ControlToValidate="txtCode"  ValidationGroup="EditionConfiguration"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"  ValidationGroup="EditionConfiguration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCode" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"   ControlToValidate="txtDescription"  ValidationGroup="EditionConfiguration"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDescription"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liConfigurationCategory" Text="Categoría de Configuración" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlConfigurationCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvConfigurationCategory" runat="server" ControlToValidate="ddlConfigurationCategory"  ValidationGroup="EditionConfiguration"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liActive" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActive" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liSistemaEntidad" Text="Entidad del Sistema" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlSistemaEntidad" runat="server"  ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvSistemaEntidad" runat="server" ControlToValidate="ddlSistemaEntidad"  ValidationGroup="EditionConfiguration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlEstado" runat="server" CssClass="field_input"></cc:ExtendedDropDownList>
	</td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="EditionConfiguration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
