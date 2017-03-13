<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextEdit.ascx.cs" Inherits="UI.Web.TextEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCode" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"   ControlToValidate="txtCode"  ValidationGroup="EditionText"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"  ValidationGroup="EditionText"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCode" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel" valign="top"  ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"   ControlToValidate="txtDescription"  ValidationGroup="EditionText"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDescription"  Width="100%"  MaxLength="2000"  TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liTextCategory" Text="Texto Categoría" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvTextCategory" runat="server" ControlToValidate="ddlTextCategory"  ValidationGroup="EditionText"   Text="*" Width="1px" Height="1px"  InitialValue="0"   ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><asp:DropDownList ID="ddlTextCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liIsAutomaticLoad" Text="Carga Automática" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkIsAutomaticLoad" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liStartDate" Text="Fecha de Inicio" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="false"  ID="diStartDate" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liChecked" Text="Chequeado" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkChecked" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liCheckedDate" Text="Fecha de Chequeado" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diCheckedDate" /></td>
	</tr><tr>
	<td class="tdLabel"  ><asp:Literal ID="liUsuarioChecked" Text="Usuario Verificador" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlUsuarioChecked" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvUsuarioChecked" runat="server" ControlToValidate="ddlUsuarioChecked"  ValidationGroup="EditionText"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
