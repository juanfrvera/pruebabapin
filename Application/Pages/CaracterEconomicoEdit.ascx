<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="CaracterEconomicoEdit.ascx.cs" Inherits="UI.Web.CaracterEconomicoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeCaracterEconomico" Src="~/ControlsPersonal/WebControl_CaracterEconomico.ascx" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionCaracterEconomico"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionCaracterEconomico"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px" MaxLength="3" runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionCaracterEconomico"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionCaracterEconomico"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre"  Width="420px" MaxLength="50" runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liCaracterEconómico" Text="Caracter Económico Padre" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput">
	<uc:TreeCaracterEconomico runat="server" ID="toCaracterEconomicoPadre" Handler="../Handlers/CaracterEconomicoHandler.ashx" SelectOption="Any" ShowOption="ActivesAndActualValue" >
            </uc:TreeCaracterEconomico>
	</td>
	<td class="filaValidator">&nbsp;</td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liCaracterEconomicoTipo" Text="Nivel/Tipo " runat="server" ></asp:Literal></td>
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
