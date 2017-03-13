<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ClasificacionGeograficaFilter.ascx.cs" Inherits="UI.Web.ClasificacionGeograficaFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacionGeografica" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:255px"><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterClasificacionGeografica" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="4" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterClasificacionGeografica" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="60" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px"><div ><asp:Literal ID="liTipoClasificacionGeografica" Text="Tipo de Clasificación Geográfica" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvClasificacionGeograficaTipo" runat="server" ControlToValidate="ddlClasificacionGeograficaTipo"  ValidationGroup="FilterClasificacionGeografica" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlClasificacionGeograficaTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:140px"><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr><td colspan = "3">
	    <asp:Panel runat="server" GroupingText="Clasificación Geográfica Padre"  ID="PnlClasificacionGeograficaPadre"  Width="750px"   >
                                <table  cellpadding="0" cellspacing="0" border="0" >
                                    <tr>
                                        <td>
                                             <uc:TreeLocalizacionGeografica runat="server" ID="toClasificacionGeograficaPadre" Handler="../Handlers/ClasificacionGeograficaHandler.ashx" SelectOption="Any" ShowOption="All" >
            </uc:TreeLocalizacionGeografica>
                                        </td>
                                        <td class="tdFilter">
                                                <asp:CheckBox ID="chkIncluirSubClasificaciones" runat="server" Text="Incluir Subitems"
                                                    CssClass="field_input"></asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
		                    </asp:Panel>
		 </td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterClasificacionGeografica" />
		</td>
		</tr>
</table>
