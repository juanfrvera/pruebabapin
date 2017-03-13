<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PerfilActividadEdit.ascx.cs" Inherits="UI.Web.PerfilActividadEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liPerfil" Text="Perfil" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlPerfil" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPerfil" runat="server" ControlToValidate="ddlPerfil"  ValidationGroup="EditionPerfilActividad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liActividad" Text="Actividad" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlActividad" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvActividad" runat="server" ControlToValidate="ddlActividad"  ValidationGroup="EditionPerfilActividad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 </table>
