<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClasificacionGastoEdit.ascx.cs" Inherits="UI.Web.ClasificacionGastoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeCaracterEconomico" Src="~/ControlsPersonal/WebControl_CaracterEconomico.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeClasificacionGasto" Src="~/ControlsPersonal/WebControl_ClasificacionGasto.ascx" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel" style="width:140px"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator"  >&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionClasificacionGasto"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionClasificacionGasto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" >&nbsp;<asp:TextBox ID="txtCodigo"  Width="60px"   MaxLength="4"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionClasificacionGasto"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionClasificacionGasto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" >&nbsp;<asp:TextBox ID="txtNombre"  Width="420px" MaxLength="90"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liCaracterEconomico" Text="Caracter Económico" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput" >
	<uc:TreeCaracterEconomico runat="server" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" ID="toCaracterEconomico" Handler="../Handlers/CaracterEconomicoHandler.ashx"> 
            </uc:TreeCaracterEconomico>
	</td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liClasificacionGastoRubro" Text="Rubro" runat="server" ></asp:Literal></td>
	<td >&nbsp;<asp:RequiredFieldValidator ID="rfvClasificacionGastoRubro" runat="server" ControlToValidate="ddlClasificacionGastoRubro"  ValidationGroup="EditionClasificacionGasto" InitialValue="0"  Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></td>
	<td  class="filaInput">&nbsp;<asp:DropDownList ID="ddlClasificacionGastoRubro" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liClasificacionGastoPadre" Text="Padre" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput" ><uc:TreeClasificacionGasto runat="server" ID="toClasificacionGastoPadre"    Autopostback="true"  OnValueChanged="toClasificacionGastoPadre_ValueChanged" SelectOption="Any" ShowOption="ActivesAndActualValue" Handler="../Handlers/ClasificacionGastoHandler.ashx">
            </uc:TreeClasificacionGasto></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liClasificacionGastoTipo" Text="Nivel/Tipo " runat="server" ></asp:Literal></td>
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
		<td class="filaValidator" ></td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	 </table>
