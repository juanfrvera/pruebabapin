<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EtapaFilter.ascx.cs" Inherits="UI.Web.EtapaFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liFase" Text="Fase" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvFase" runat="server" ControlToValidate="ddlFase"  ValidationGroup="FilterEtapa" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlFase" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter"  ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterEtapa" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="2" ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterEtapa" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="50" ></asp:TextBox></div>
        </td><td class="tdFilter"  ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server"  ControlToValidate="txtOrden" ValidationGroup="FilterEtapa" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOrden" type="text" min="0" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td>
	    <td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterEtapa"/>
		</td>
		</tr>
</table>
