<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ConfigurationFilter.ascx.cs" Inherits="UI.Web.ConfigurationFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liName" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revName" runat="server"  ControlToValidate="txtName" ValidationGroup="FilterConfiguration" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtName" runat="server" CssClass="field_input" MaxLength="70"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liCode" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCode" runat="server"  ControlToValidate="txtCode" ValidationGroup="FilterConfiguration" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCode" runat="server" CssClass="field_input" MaxLength="50"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liDescription" Text="Descripción" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDescription" runat="server"  ControlToValidate="txtDescription" ValidationGroup="FilterConfiguration" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDescription" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liActive" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActive" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liConfigurationCategory" Text="Categoría de Configuración" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlConfigurationCategory" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liSistemaEntidad" Text="Entidad del Sistema" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSistemaEntidad" runat="server" ControlToValidate="ddlSistemaEntidad"  ValidationGroup="FilterConfiguration" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSistemaEntidad" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado"  ValidationGroup="FilterConfiguration" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlEstado" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterConfiguration" />
		</td>
	</tr>
</table>
