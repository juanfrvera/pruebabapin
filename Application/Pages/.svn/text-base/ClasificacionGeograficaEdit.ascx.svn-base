<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClasificacionGeograficaEdit.ascx.cs" Inherits="UI.Web.ClasificacionGeograficaEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacionGeografica" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>


<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionClasificacionGeografica"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionClasificacionGeografica"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px" MaxLength="4"      runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionClasificacionGeografica"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionClasificacionGeografica"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="420px"  MaxLength="60"       runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liNClasificacionGeograficaPadre" Text="Padre" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput" colspan="2">
	    <uc:TreeLocalizacionGeografica runat="server" ID="toClasificacionGeograficaPadre" Handler="../Handlers/ClasificacionGeograficaHandler.ashx" Autopostback="true"  OnValueChanged="toClasificacionGeograficaPadre_ValueChanged" SelectOption="Any" ShowOption="ActivesAndActualValue" >
            </uc:TreeLocalizacionGeografica>
	</td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liClasificacionGeograficaTipo" Text="Nivel/Tipo " runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput" valign="top">&nbsp;<asp:Label ID="lbTipo" runat = "server" /></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liSeleccionable" Text="Seleccionable" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkSeleccionable" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
