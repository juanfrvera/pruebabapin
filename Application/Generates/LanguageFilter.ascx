<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LanguageFilter.ascx.cs" Inherits="UI.Web.LanguageFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liName" Text="Name" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"  ControlToValidate="txtName" ValidationGroup="FilterLanguage" Text="*" Width="1px" Height="1px"  ErrorMessage="El Name no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtName" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liCode" Text="Code" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"  ControlToValidate="txtCode" ValidationGroup="FilterLanguage" Text="*" Width="1px" Height="1px"  ErrorMessage="El Code no es valido"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCode" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >&nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" /></td>
	</tr>
</table>
