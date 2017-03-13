<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanPeriodoFilter.ascx.cs" Inherits="UI.Web.PlanPeriodoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liTipoPlan" Text="Tipo de Plan" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPlanTipo" runat="server" ControlToValidate="ddlPlanTipo"  ValidationGroup="FilterPlanPeriodo" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlPlanTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterPlanPeriodo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"  MaxLength="50"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liSigla" Text="Sigla" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revSigla" runat="server"  ControlToValidate="txtSigla" ValidationGroup="FilterPlanPeriodo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtSigla" runat="server" CssClass="field_input"  MaxLength="20" ></asp:TextBox></div>
        </td><td class="tdFilter"  ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liAnioInicial" Text="Año Inicial" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revAnioInicial" runat="server"  ControlToValidate="txtAnioInicial" ValidationGroup="FilterPlanPeriodo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtAnioInicial" type="text" min="0" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liAnioFinal" Text="Año Final" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revAnioFinal" runat="server"  ControlToValidate="txtAnioFinal" ValidationGroup="FilterPlanPeriodo" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtAnioFinal" runat="server" type="text" min="0" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPlanPeriodo" />
		</td>
		</tr>
</table>
