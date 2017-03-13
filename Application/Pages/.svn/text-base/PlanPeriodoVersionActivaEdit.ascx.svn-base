<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PlanPeriodoVersionActivaEdit.ascx.cs" Inherits="UI.Web.PlanPeriodoVersionActivaEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
<tr>
    <td class="tdLabel"  ><asp:Literal ID="liPlanTipo" Text="Plan" runat="server" ></asp:Literal>&nbsp;</td>
    <td class="filaValidator">&nbsp;</td>
    <td class="filaValidator"><cc:ExtendedDropDownList ID="ddlPlanTipo" runat="server" CssClass="field_input" 
            onselectedindexchanged="ddlPlanTipo_SelectedIndexChanged" AutoPostBack ="true"   ></cc:ExtendedDropDownList></td>
</tr>
<tr>
<td class="tdLabel"  ><asp:Literal ID="liPlanPeriodo" Text="Período" runat="server" ></asp:Literal></td>
<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPlanPeriodo" runat="server" ControlToValidate="ddlPlanPeriodo"  ValidationGroup="EditionPlanPeriodoVersionActiva"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlPlanPeriodo" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
</tr>
 <tr>
<td class="tdLabel"  ><asp:Literal ID="liVersionPlan" Text="Versión" runat="server" ></asp:Literal></td>
<td class="filaValidator">&nbsp;<asp:RequiredFieldValidator ID="rfvPlanVersion" runat="server" ControlToValidate="ddlPlanVersion"  ValidationGroup="EditionPlanPeriodoVersionActiva"   Text="*" Width="1px" Height="1px" InitialValue="0"  ></asp:RequiredFieldValidator></td>
<td  class="filaInput"><cc:ExtendedDropDownList ID="ddlPlanVersion" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList></td>
</tr>
 </table>
