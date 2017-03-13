<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GeoreferenciacionPuntoEdit.ascx.cs" Inherits="UI.Web.GeoreferenciacionPuntoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liGeoreferenciacion" Text="Georeferenciacion" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlGeoreferenciacion" runat="server" CssClass="field_input"     ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvGeoreferenciacion" InitialValue="0" runat="server" ControlToValidate="ddlGeoreferenciacion"  ValidationGroup="EditionGeoreferenciacionPunto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionGeoreferenciacionPunto"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionGeoreferenciacionPunto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtOrden" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liLongitud" Text="Longitud" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revLongitud" runat="server" ControlToValidate="txtLongitud"  ValidationGroup="EditionGeoreferenciacionPunto"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvLongitud" runat="server" ControlToValidate="txtLongitud"  ValidationGroup="EditionGeoreferenciacionPunto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtLongitud" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liLatitud" Text="Latitud" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revLatitud" runat="server" ControlToValidate="txtLatitud"  ValidationGroup="EditionGeoreferenciacionPunto"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvLatitud" runat="server" ControlToValidate="txtLatitud"  ValidationGroup="EditionGeoreferenciacionPunto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtLatitud" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="lidescripcion" Text="descripcion" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revdescripcion" runat="server"   ControlToValidate="txtdescripcion"  ValidationGroup="EditionGeoreferenciacionPunto"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtdescripcion"  Width="300px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
