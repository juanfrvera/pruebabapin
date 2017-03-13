<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SafFilter.ascx.cs" Inherits="UI.Web.SafFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<style>
    
</style>
<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:345px"  ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input"   MaxLength="5" Width="300px" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:345px" ><div ><asp:Literal ID="liDenominacion" Text="Denominación" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server"  ControlToValidate="txtDenominacion" ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input"   MaxLength="255" Width="300px" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:225px"><div ><asp:Literal ID="liFechaAlta" Text="Fecha de Alta" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFechaAlta"  />         
		</td>
	</tr><tr>
	    <td class="tdFilter"  ><div ><asp:Literal ID="liTipoOrganismo" Text="Tipo de Organismo" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvTipoOrganismo" runat="server" ControlToValidate="ddlTipoOrganismo"  ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlTipoOrganismo" runat="server" CssClass="field_input" Width="305px" SkinID="AnchoLibre"  ></asp:DropDownList></div>
		</td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liSector" Text="Sector" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSector" runat="server" ControlToValidate="ddlSector"  ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSector" runat="server" CssClass="field_input" Width="305px" SkinID="AnchoLibre"></asp:DropDownList></div>
		</td>
		<td class="tdFilter" ><div ><asp:Literal ID="liFechaBaja" Text="Fecha de Baja" runat="server" ></asp:Literal></div>
		 <uc:DateRangeInput runat="server" ID="rdFechaBaja"  />         
		</td>
	</tr>
	<tr> <td class="tdFilter" ><div ><asp:Literal ID="liTipoAdministracion" Text="Tipo de Administración" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvAdministracionTipo" runat="server" ControlToValidate="ddlAdministracionTipo"  ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlAdministracionTipo" runat="server" CssClass="field_input"  Width="305px" SkinID="AnchoLibre"></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liTipoEntidad" Text="Tipo de Entidad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvEntidadTipo" runat="server" ControlToValidate="ddlEntidadTipo"  ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlEntidadTipo" runat="server" CssClass="field_input" Width="305px" SkinID="AnchoLibre"></asp:DropDownList></div>
		</td>   
	    <td class="tdFilter"  ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
		</tr>
		<tr>
		<td class="tdFilter" ><div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input" Width="305px" SkinID="AnchoLibre"></asp:DropDownList></div>
		</td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liSubjurisdiccion" Text="Subjurisdicción" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSubJurisdiccion" runat="server" ControlToValidate="ddlSubJurisdiccion"  ValidationGroup="FilterSaf" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSubJurisdiccion" runat="server" CssClass="field_input" Width="305px" SkinID="AnchoLibre"></asp:DropDownList></div>
		</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterSaf" />
		</td>
		</tr>
</table>
