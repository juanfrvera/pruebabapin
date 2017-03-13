<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ParameterEdit.ascx.cs" Inherits="UI.Web.ParameterEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"   ControlToValidate="txtName"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"  ValidationGroup="EditionParameter"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtName" Width="400px"  MaxLength="70"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"   ControlToValidate="txtCode"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"  ValidationGroup="EditionParameter"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCode" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"   ControlToValidate="txtDescription"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDescription"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liParametroCategoria" Text="Categoría de Parametro" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlParameterCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvParameterCategory" runat="server" ControlToValidate="ddlParameterCategory"  ValidationGroup="EditionParameter"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liStringValue" Text="Valor String" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revStringValue" runat="server"   ControlToValidate="txtStringValue"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtStringValue"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNumberValue" Text=" Valor Número" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNumberValue" runat="server" ControlToValidate="txtNumberValue"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtNumberValue" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liDataValue" Text="Valor Fecha" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="false" ID="diDateValue" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liTextValue" Text="Valor Texto" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revTextValue" runat="server"   ControlToValidate="txtTextValue"  ValidationGroup="EditionParameter"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtTextValue"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
