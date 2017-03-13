<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="IndicadorClaseFilter.ascx.cs" Inherits="UI.Web.IndicadorClaseFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liIndicadorTipo" Text="Tipo de Indicador" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvIndicadorTipo" runat="server" ControlToValidate="ddlIndicadorTipo"  ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlIndicadorTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liIndicadorSector" Text="Sector de Indicador" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlIndicadorSector" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liSigla" Text="Sigla" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revSigla" runat="server"  ControlToValidate="txtSigla" ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtSigla" runat="server" CssClass="field_input"  MaxLength="10" ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"   MaxLength="100"></asp:TextBox></div>
        </td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liUnidad" Text="Unidad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvUnidad" runat="server" ControlToValidate="ddlUnidad"  ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlUnidad" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liRangoInicial" Text="Rango Inicial" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revRangoInicial" runat="server"  ControlToValidate="txtRangoInicial" ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtRangoInicial" type="text" min="0" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liRangoFinal" Text="Rango Final" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revRangoFinal" runat="server"  ControlToValidate="txtRangoFinal" ValidationGroup="FilterIndicadorClase" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtRangoFinal" type="text" min="0" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr><td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
	           <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		  &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterIndicadorClase" />
	 </td>
	</tr>
</table>
