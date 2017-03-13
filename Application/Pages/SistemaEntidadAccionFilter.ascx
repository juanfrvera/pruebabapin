<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="SistemaEntidadAccionFilter.ascx.cs" Inherits="UI.Web.SistemaEntidadAccionFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liSistemaEntidad" Text="SistemaEntidad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSistemaEntidad" runat="server" ControlToValidate="ddlSistemaEntidad"  ValidationGroup="FilterSistemaEntidadAccion" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSistemaEntidad" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liSistemaAccion" Text="SistemaAccion" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvSistemaAccion" runat="server" ControlToValidate="ddlSistemaAccion"  ValidationGroup="FilterSistemaEntidadAccion" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlSistemaAccion" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterSistemaEntidadAccion" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="100"   ></asp:TextBox></div>
        </td><td align="right" valign="bottom" >
            <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
            &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterSistemaEntidadAccion"/>
        </td>
	</tr>
</table>
