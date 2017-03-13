<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerfilActividadFilter.ascx.cs" Inherits="UI.Web.PerfilActividadFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liPerfil" Text="Perfil" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ControlToValidate="ddlPerfil"  ValidationGroup="FilterPerfilActividad" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlPerfil" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liActividad" Text="Actividad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="ddlActividad"  ValidationGroup="FilterPerfilActividad" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlActividad" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPerfilActividad" />
		</td>
		</tr>
</table>
