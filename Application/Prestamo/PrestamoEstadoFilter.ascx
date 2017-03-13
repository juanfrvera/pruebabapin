<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoEstadoFilter.ascx.cs" Inherits="UI.Web.PrestamoEstadoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style="width:230px" ><div ><asp:Literal ID="liPrestamo" Text="Préstamo" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPrestamo" runat="server" ControlToValidate="ddlPrestamo"  ValidationGroup="FilterPrestamoEstado" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlPrestamo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style="width:230px" ><div ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="FilterPrestamoEstado" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlEstado" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style="width:230px" ><div ><asp:Literal ID="liFechaEstimada" Text="Fecha Estimada" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFechaEstimada"  />         
		</td><td class="tdFilter" style="width:230px"><div ><asp:Literal ID="liFechaRealizada" Text="Fecha Realizada" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFechaRealizada"  />         
		</td>
	</tr><tr><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPrestamoEstado" />
		</td>
	</tr>
</table>
