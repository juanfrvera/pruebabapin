<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanPeriodoVersionActivaFilter.ascx.cs" Inherits="UI.Web.PlanPeriodoVersionActivaFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liPlanTipo" Text="Tipo" runat="server" ></asp:Literal>&nbsp</div>
		<div><asp:DropDownList ID="ddlPlanTipo" runat="server" CssClass="field_input"  onselectedindexchanged="ddlPlanTipo_SelectedIndexChanged" AutoPostBack ="true"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liPlanPeriodo" Text="Período" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlPlanPeriodo" runat="server" CssClass="field_input" Enabled="false" ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liPlanVersion" Text="Versión" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlPlanVersion" runat="server" CssClass="field_input" Enabled="false" ></asp:DropDownList></div>
		</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPlanPeriodoVersionActiva"/>
		</td>
</tr>
</table>
