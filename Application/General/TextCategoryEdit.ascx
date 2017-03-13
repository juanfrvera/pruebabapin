<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="TextCategoryEdit.ascx.cs" Inherits="UI.Web.TextCategoryEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liName" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"   ControlToValidate="txtName"  ValidationGroup="EditionTextCategory"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"  ValidationGroup="EditionTextCategory"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtName" Width="400px"  MaxLength="70"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"   ControlToValidate="txtDescription"  ValidationGroup="EditionTextCategory"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></td>
		<td class="filaInput" ><asp:TextBox ID="txtDescription"  Width="100%"  MaxLength="2000"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
