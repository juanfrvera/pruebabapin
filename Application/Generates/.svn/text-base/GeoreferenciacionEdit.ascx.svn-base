<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GeoreferenciacionEdit.ascx.cs" Inherits="UI.Web.GeoreferenciacionEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liTipo" Text="Tipo" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revTipo" runat="server" ControlToValidate="txtTipo"  ValidationGroup="EditionGeoreferenciacion"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvTipo" runat="server" ControlToValidate="txtTipo"  ValidationGroup="EditionGeoreferenciacion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtTipo" Width="60px"   runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	</table>
