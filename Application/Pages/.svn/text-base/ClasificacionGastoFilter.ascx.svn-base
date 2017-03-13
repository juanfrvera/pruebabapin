<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClasificacionGastoFilter.ascx.cs" Inherits="UI.Web.ClasificacionGastoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeCaracterEconomico" Src="~/ControlsPersonal/WebControl_CaracterEconomico.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeClasificacionGasto" Src="~/ControlsPersonal/WebControl_ClasificacionGasto.ascx" %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:270px" ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterClasificacionGasto" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="4"  ></asp:TextBox></div>
		</td> <td class="tdFilter" colspan="2" style=" width:280px" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterClasificacionGasto" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="90" Width="430px"  ></asp:TextBox></div>
        </td>
        <td class="tdFilter" style=" width:195px" ><div ><asp:Literal ID="liTipoClasificacionGasto" Text="Tipo de Clasificación del Gasto" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvClasificacionGastoTipo" runat="server" ControlToValidate="ddlClasificacionGastoTipo"  ValidationGroup="FilterClasificacionGasto" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlClasificacionGastoTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td>
	</tr>
	<tr> 
            <td colspan = "3" rowspan = "2" >
	    <asp:Panel runat="server" GroupingText="Caracter Económico"  ID="Panel1"  Width="710px"   >
                                <table  cellpadding="0" cellspacing="0" border="0" >
                                    <tr>
                                        <td>
                                            <uc:TreeCaracterEconomico runat="server" ID="toCaracterEconomico" Handler="../Handlers/CaracterEconomicoHandler.ashx" SelectOption="OnlySelectedDefined" ShowOption="All" >
            </uc:TreeCaracterEconomico>
                                        </td>
                                        <td class="tdFilter">
                                                <asp:CheckBox ID="chkIncluirSubCaracterEconomico" runat="server" Text="Incluir Subitems"
                                                    CssClass="field_input"></asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
		                    </asp:Panel>
		                     </td>  
		                          
    
		
		<td class="tdFilter" ><div ><asp:Literal ID="liClasificacionGastoRubro" Text="Rubro" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlClasificacionGastoRubro" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td></tr>
		<tr>
		<td class="tdFilter" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
		</tr>
		<tr>
		<td colspan = "3" >
	    <asp:Panel runat="server" GroupingText="Clasificación del Gasto Padre"  ID="PnlClasificacionGastoPadre"  Width="710px"   >
                                <table  cellpadding="0" cellspacing="0" border="0" >
                                    <tr>
                                        <td>
                                            <uc:TreeClasificacionGasto runat="server" ID="toClasificacionGastoPadre" SelectOption="Any" ShowOption="All"  Handler="../Handlers/ClasificacionGastoHandler.ashx">
                                        </uc:TreeClasificacionGasto>
                                        </td>
                                        <td class="tdFilter">
                                                <asp:CheckBox ID="chkIncluirSubClasificaciones" runat="server" Text="Incluir Subitems"
                                                    CssClass="field_input"></asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
		                    </asp:Panel>
		                     </td>
        <td align="right" valign="bottom" ><asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterClasificacionGasto" /></td>
		</tr>
</table>
