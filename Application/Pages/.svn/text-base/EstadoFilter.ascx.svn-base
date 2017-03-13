<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="EstadoFilter.ascx.cs" Inherits="UI.Web.EstadoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterEstado" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liOrden" Text="Orden" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revOrden" runat="server"  ControlToValidate="txtOrden" ValidationGroup="FilterEstado" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtOrden" type="text" min="0"  runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter" ><div ><asp:Literal ID="liDescripción" Text="Descripción" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDescripcion" runat="server"  ControlToValidate="txtDescripcion" ValidationGroup="FilterEstado" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDescripcion" runat="server" CssClass="field_input"  ></asp:TextBox></div>
        </td><td class="tdFilter"  ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" >&nbsp;</td>
	    <td class="tdFilter" >&nbsp;</td>
		<td class="tdFilter" >&nbsp;</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterEstado" />
		</td>
		</tr>
</table>
