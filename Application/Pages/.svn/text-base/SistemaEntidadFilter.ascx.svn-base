<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaEntidadFilter.ascx.cs" Inherits="UI.Web.SistemaEntidadFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterSistemaEntidad" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input"  MaxLength="50" ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterSistemaEntidad" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"  MaxLength="100" ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liIncluirSeguridad" Text="Incluir Seguridad" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkIncluirSeguridad" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td><td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr>
	<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liEntidadClaseBase" Text="Clase Base deEntidad" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revEntidadClaseBase" runat="server"  ControlToValidate="txtEntidadClaseBase" ValidationGroup="FilterSistemaEntidad" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntidadClaseBase" runat="server" CssClass="field_input"  MaxLength="50" ></asp:TextBox></div>
        </td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liEntidadClase" Text="Clase de Entidad" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revEntidadClase" runat="server"  ControlToValidate="txtEntidadClase" ValidationGroup="FilterSistemaEntidad" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtEntidadClase" runat="server" CssClass="field_input"  MaxLength="50" ></asp:TextBox></div>
        </td>
		<td class="tdFilter" ><div ><asp:Literal ID="liIncluirConfiguracion" Text="Incluir Configuración" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkIncluirConfiguracion" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>		
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterSistemaEntidad"/>
		</td>
	</tr>
</table>
