<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MonedaCotizacionFilter.ascx.cs" Inherits="UI.Web.MonedaCotizacionFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:250px" ><div ><asp:Literal ID="liMoneda" Text="Moneda" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvMoneda" runat="server" ControlToValidate="ddlMoneda"  ValidationGroup="FilterMonedaCotizacion" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlMoneda" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:250px" ><div ><asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFecha"  />         
		</td><td class="tdFilter" style=" width:250px" ><div ><asp:Literal ID="liCotización" Text="Cotización" runat="server" ></asp:Literal></div>
		 <div><uc:NumberRangeInput runat="server" ID="rnCotizacion" ValidationGroup="FilterMonedaCotizacion"   /> </div>         
		</td><td align="right" valign="bottom" >
		        <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		        &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterMonedaCotizacion" />
		     </td>
		</tr>
</table>
