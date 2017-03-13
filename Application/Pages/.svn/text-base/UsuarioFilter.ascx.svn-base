<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="UsuarioFilter.ascx.cs" Inherits="UI.Web.UsuarioFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liNombreUsuario" Text="NombreUsuario" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombreUsuario" runat="server"  ControlToValidate="txtNombreUsuario" ValidationGroup="FilterUsuario" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombreUsuario" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liClave" Text="Clave" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revClave" runat="server"  ControlToValidate="txtClave" ValidationGroup="FilterUsuario" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtClave" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td><td class="tdFilter" ><div ><asp:Literal ID="liEsSectioralista" Text="EsSectioralista" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkEsSectioralista" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liLanguage" Text="Language" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvLanguage" runat="server" ControlToValidate="ddlLanguage"  ValidationGroup="FilterUsuario" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlLanguage" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterUsuario"/>
		</td>
	</tr>
</table>
