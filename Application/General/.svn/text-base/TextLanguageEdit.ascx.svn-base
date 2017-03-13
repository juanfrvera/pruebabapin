<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextLanguageEdit.ascx.cs" Inherits="UI.Web.TextLanguageEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liText" Text="Texto" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvText" runat="server" ControlToValidate="ddlText"  ValidationGroup="EditionTextLanguage"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><asp:DropDownList ID="ddlText" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liLanguage" Text="Lenguaje" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage"  ValidationGroup="EditionTextLanguage"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liTranslateText" Text="Traducir Texto" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revTranslateText" runat="server"   ControlToValidate="txtTranslateText"  ValidationGroup="EditionTextLanguage"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvTranslateText" runat="server" ControlToValidate="txtTranslateText"  ValidationGroup="EditionTextLanguage"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtTranslateText"  Width="100%"  MaxLength="2147483647"   TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	    
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liIsAutomaticLoad" Text="Carga Automática" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkIsAutomaticLoad" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liStartDate" Text="Fecha de Inicio" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diStartDate" ValidationGroup="EditionTextLanguage" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liChecked" Text="Checked" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkChecked" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liCheckedDate" Text="Comprobado" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diCheckedDate" /></td>
	</tr><tr>
	<td class="tdLabel"  ><asp:Literal ID="liUsuarioChecked" Text="UsuarioChecked" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlUsuarioChecked" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvUsuarioChecked" runat="server" ControlToValidate="ddlUsuarioChecked"  ValidationGroup="EditionTextLanguage"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
