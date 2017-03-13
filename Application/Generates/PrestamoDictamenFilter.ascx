<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenFilter.ascx.cs" Inherits="UI.Web.PrestamoDictamenFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:230px" ><div ><asp:Literal ID="liPrestamo" Text="Préstamo" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPrestamo" runat="server" ControlToValidate="ddlPrestamo"  ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlPrestamo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:230px"><div ><asp:Literal ID="liIdDictamen" Text="Id Dictamen" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revIdDictamen" runat="server"  ControlToValidate="txtIdDictamen" ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px"  ErrorMessage="El IdDictamen no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtIdDictamen" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:230px"><div ><asp:Literal ID="liObservacion" Text="Observación" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server"  ControlToValidate="txtObservacion" ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px"  ErrorMessage="El Observacion no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtObservacion" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:230px"><div ><asp:Literal ID="liIdUsuario" Text="Id Usuario" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revIdUsuario" runat="server"  ControlToValidate="txtIdUsuario" ValidationGroup="FilterPrestamoDictamen" Text="*" Width="1px" Height="1px"  ErrorMessage="El IdUsuario no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtIdUsuario" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFecha"  />         
		</td><td class="tdFilter" ><div ><asp:Literal ID="liFechaIngreso" Text="Fecha de Ingreso" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFechaIngreso"  />         
		</td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >&nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" /></td>
		</tr>
</table>
