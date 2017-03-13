<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaEntidadEstadoEdit.ascx.cs" Inherits="UI.Web.SistemaEntidadEstadoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liSistemaEntidad" Text="Entidad Sistema" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvSistemaEntidad" runat="server" ControlToValidate="ddlSistemaEntidad"  ValidationGroup="EditionSistemaEntidadEstado"   Text="*" Width="1px" Height="1px" InitialValue="0"   ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlSistemaEntidad" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
</td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="EditionSistemaEntidadEstado"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlEstado" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaEntidadEstado"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionSistemaEntidadEstado"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="400px"  MaxLength="100"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
