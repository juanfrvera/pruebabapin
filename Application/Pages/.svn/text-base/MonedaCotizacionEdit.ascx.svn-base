<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonedaCotizacionEdit.ascx.cs" Inherits="UI.Web.MonedaCotizacionEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liMonda" Text="Moneda" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvMoneda" runat="server" ControlToValidate="ddlMoneda"  ValidationGroup="EditionMonedaCotizacion"   Text="*" Width="1px" Height="1px" InitialValue="0" ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlMoneda" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	</tr>
	 <tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput IsValidEmpty="false" runat="server" ID="diFecha" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liCotizacion" Text="Cotización" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCotizacion" runat="server" ControlToValidate="txtCotizacion"  ValidationGroup="EditionMonedaCotizacion"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCotizacion" runat="server" ControlToValidate="txtCotizacion"  ValidationGroup="EditionMonedaCotizacion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCotizacion" Width="60px" runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	</table>
