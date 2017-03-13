<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanTipoEdit.ascx.cs" Inherits="UI.Web.PlanTipoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
		<td class="tdLabel"  ><asp:Literal ID="liSigla" Text="Sigla" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revSigla" runat="server"   ControlToValidate="txtSigla"  ValidationGroup="EditionPlanTipo"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvSigla" runat="server" ControlToValidate="txtSigla"  ValidationGroup="EditionPlanTipo"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtSigla"  Width="60px"    MaxLength="5"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal></td>
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"   ControlToValidate="txtNombre"  ValidationGroup="EditionPlanTipo"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvNombre" runat="server" ControlToValidate="txtNombre"  ValidationGroup="EditionPlanTipo"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtNombre" Width="400px" MaxLength="50"    runat="server" CssClass="field_input"  ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal></td>	
		<td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionPlanTipo"  Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
		<asp:RequiredFieldValidator ID="rfvOrden" runat="server" ControlToValidate="txtOrden"  ValidationGroup="EditionPlanTipo"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		</td>
		<td class="filaInput" ><asp:TextBox ID="txtOrden" Width="60px" type="text" min="0" runat="server" CssClass="field_input" ></asp:TextBox></td>
	</tr>
	<tr>
		<td class="tdLabel"  ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></td>
		<td class="filaValidator" >&nbsp;</td>
		<td class="filaInput"><asp:CheckBox ID="chkActivo" runat="server" CssClass="field_input" ></asp:CheckBox></td>		
	</tr>
	</table>
