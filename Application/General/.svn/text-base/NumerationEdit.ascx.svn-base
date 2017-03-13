<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="NumerationEdit.ascx.cs" Inherits="UI.Web.NumerationEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"   ControlToValidate="txtCode"  ValidationGroup="EditionNumeration"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<asp:RequiredFieldValidator ID="rfvCode" runat="server" ControlToValidate="txtCode"  ValidationGroup="EditionNumeration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		<td class="filaInput" ><asp:TextBox ID="txtCode" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liUltimoValor" Text="Último Valor" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revLastvalue" runat="server" ControlToValidate="txtLastvalue"  ValidationGroup="EditionNumeration"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvLastvalue" runat="server" ControlToValidate="txtLastvalue"  ValidationGroup="EditionNumeration"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtLastvalue" type="text" min="0"  Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	</table>
