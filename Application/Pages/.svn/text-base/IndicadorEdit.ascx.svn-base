<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadorEdit.ascx.cs" Inherits="UI.Web.IndicadorEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
	<td class="tdLabel"  ><asp:Literal ID="liMedioVerificacion" Text="MedioVerificacion" runat="server" ></asp:Literal></td>
	<td >&nbsp;</td>
	<td  class="filaInput"><asp:DropDownList ID="ddlMedioVerificacion" runat="server" CssClass="field_input"  ></asp:DropDownList></td>
	<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvMedioVerificacion" runat="server" ControlToValidate="ddlMedioVerificacion"  ValidationGroup="EditionIndicador"   Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></td>
	</tr>
	 <tr>
		<td class="tdLabel"  ><asp:Literal ID="liObservacion" Text="Observacion" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server"   ControlToValidate="txtObservacion"  ValidationGroup="EditionIndicador"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtObservacion"  Width="100%"  MaxLength="500"    TextMode="MultiLine"  Rows="6"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	</table>
