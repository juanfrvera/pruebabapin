<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinalidadFuncionEdit.ascx.cs" Inherits="UI.Web.FinalidadFuncionEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="EditionFinalidadFuncion"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="EditionFinalidadFuncion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtCodigo"  Width="60px"   MaxLength="3"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liDenominacion" Text="Denominación" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server"   ControlToValidate="txtDenominacion"  ValidationGroup="EditionFinalidadFuncion"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion"  ValidationGroup="EditionFinalidadFuncion"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtDenominacion" Width="420px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	 <tr>
	<td class="tdLabel"  ><asp:Literal ID="liFinalidadFuncionPadre" Text="Padre" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><uc:TreeFinalidadFuncion runat="server" ID="toFinalidadFuncionPadre" Autopostback="true"  OnValueChanged="toFinalidadFuncionPadre_ValueChanged" SelectOption="Any"  ShowOption="ActivesAndActualValue" Handler="../Handlers/FinalidadFuncionHandler.ashx"   >
            </uc:TreeFinalidadFuncion></td>
	<td class="filaValidator">&nbsp;</td>
	</tr>
	<tr>
	<td class="tdLabel"  ><asp:Literal ID="liFinalidadFuncionTipo"  Text="Nivel/Tipo" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput" colspan="2" valign="top"><asp:Label ID="lbTipo" runat = "server" /></td>
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
