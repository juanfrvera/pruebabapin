<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenEdit.ascx.cs" Inherits="UI.Web.PrestamoDictamenEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liPrestamo" Text="Préstamo" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlPrestamo" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPrestamo" runat="server" ControlToValidate="ddlPrestamo"  ValidationGroup="EditionPrestamoDictamen"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liDictamen" Text="Dictamen" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIdDictamen" runat="server" ControlToValidate="txtIdDictamen"  ValidationGroup="EditionPrestamoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El IdDictamen no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtIdDictamen" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liObservacion" Text="Observación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server"   ControlToValidate="txtObservacion"  ValidationGroup="EditionPrestamoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El Observacion no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtObservacion"  Width="100%"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liUsuario" Text="Usuario" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revIdUsuario" runat="server" ControlToValidate="txtIdUsuario"  ValidationGroup="EditionPrestamoDictamen"  Text="*" Width="1px" Height="1px"  ErrorMessage="El IdUsuario no es valido"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtIdUsuario" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" ID="diFecha" /></td>
	</tr><tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaIngreso" Text="Fecha de Ingreso" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" ID="diFechaIngreso" /></td>
	</tr></table>
