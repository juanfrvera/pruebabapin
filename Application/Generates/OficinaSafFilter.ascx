<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OficinaSafFilter.ascx.cs" Inherits="UI.Web.OficinaSafFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liOficina" Text="Oficina" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvOficina" runat="server" ControlToValidate="ddlOficina"  ValidationGroup="FilterOficinaSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlOficina" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liSaf" Text="Saf" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSaf" runat="server" ControlToValidate="ddlSaf"  ValidationGroup="FilterOficinaSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSaf" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
	           <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		  &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" />
	 </td>
	</tr>
</table>
