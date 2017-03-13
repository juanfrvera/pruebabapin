<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AuditOperationDetailFilter.ascx.cs" Inherits="UI.Web.AuditOperationDetailFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liAuditOperation" Text="Auditoria de Operación" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvAuditOperation" runat="server" ControlToValidate="ddlAuditOperation"  ValidationGroup="FilterAuditOperationDetail" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlAuditOperation" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liParentId" Text="Id del Padre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revParentId" runat="server"  ControlToValidate="txtParentId" ValidationGroup="FilterAuditOperationDetail" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtParentId" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liDetail" Text="Detalle" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDeatil" runat="server"  ControlToValidate="txtDeatil" ValidationGroup="FilterAuditOperationDetail" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDeatil" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liStartDate" Text="Fecha de Inicio" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdStartDate"  />         
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liEndDate" Text="Fecha de Fin" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdEndDate"  />         
		</td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true"  ValidationGroup="FilterAuditOperationDetail"/></td>
		</tr>
</table>
