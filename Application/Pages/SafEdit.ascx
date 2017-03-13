<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SafEdit.ascx.cs" Inherits="UI.Web.SafEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionSaf"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px"    MaxLength="5"   runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDenominacion" Text="Denominación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server"   ControlToValidate="txtDenominacion"  ValidationGroup="EditionSaf"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>   
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtDenominacion"  Width="99%"  MaxLength="255"   TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liTipoOrganismo" Text="Tipo de Organismo" runat="server"  ></asp:Literal></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvTipoOrganismo" runat="server" ControlToValidate="ddlTipoOrganismo"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlTipoOrganismo" runat="server" CssClass="field_input" Width="100%"></cc:ExtendedDropDownList></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liSector" Text="Sector" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlSector" runat="server" CssClass="field_input"  Width="100%"></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="ddlSector"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liTipoAdministracion" Text="Tipo de Administración" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlAdministracionTipo" runat="server" CssClass="field_input" Width="100%" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvAdministracionTipo" runat="server" ControlToValidate="ddlAdministracionTipo"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liTipoEntidad" Text="Tipo de Entidad" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlEntidadTipo" runat="server" CssClass="field_input"  Width="100%" ></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvEntidadTipo" runat="server" ControlToValidate="ddlEntidadTipo"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input"   Width="100%"></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvJurisdiccion" runat="server" ControlToValidate="ddlJurisdiccion"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  InitialValue="0"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liSubjurisdiccion" Text="Subjurisdicción" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlSubJurisdiccion" runat="server" CssClass="field_input"  Width="100%"></cc:ExtendedDropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvSubJurisdiccion" runat="server" ControlToValidate="ddlSubJurisdiccion"  ValidationGroup="EditionSaf"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaAlta" Text="Fecha de Alta" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="false" ID="diFechaAlta" /></td>
	</tr><tr>
		 <td class="tdLabel"  ><asp:Literal ID="liFechaBaja" Text="Fecha de Baja" runat="server" ></asp:Literal></td>
	 	 <td class="filaValidator">&nbsp;</td>
		 <td class="filaInput" ><uc:DateInput runat="server" IsValidEmpty="true" ID="diFechaBaja" /></td>
	</tr><tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
