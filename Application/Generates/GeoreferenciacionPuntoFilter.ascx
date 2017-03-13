<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="GeoreferenciacionPuntoFilter.ascx.cs" Inherits="UI.Web.GeoreferenciacionPuntoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liGeoreferenciacion" Text="Georeferenciacion" runat="server" ></asp:Literal></div>
		<div><asp:DropDownList ID="ddlGeoreferenciacion" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server"  ControlToValidate="txtOrden" ValidationGroup="FilterGeoreferenciacionPunto" Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOrden" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liLongitud" Text="Longitud" runat="server" ></asp:Literal></div>
		 <div><uc:NumberRangeInput runat="server" ID="rnLongitud"  /> </div>         
		</td><td class="tdFilter" ><div ><asp:Literal ID="liLatitud" Text="Latitud" runat="server" ></asp:Literal></div>
		 <div><uc:NumberRangeInput runat="server" ID="rnLatitud"  /> </div>         
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="lidescripcion" Text="descripcion" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revdescripcion" runat="server"  ControlToValidate="txtdescripcion" ValidationGroup="FilterGeoreferenciacionPunto" Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtdescripcion" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
	           <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		  &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" />
	 </td>
	</tr>
</table>
