<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FuenteFinanciamientoFilter.ascx.cs" Inherits="UI.Web.FuenteFinanciamientoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeFuenteFinanciamiento" Src="~/ControlsPersonal/WebControl_FuenteFinanciamiento.ascx" %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liCódigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterFuenteFinanciamiento" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="2" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liNombre" Text="Nombre" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNombre" runat="server"  ControlToValidate="txtNombre" ValidationGroup="FilterFuenteFinanciamiento" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="50" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liTipoFuenteFinanciamiento" Text="Tipo de Fuente de Financiamiento" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlFuenteFinanciamientoTipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:140px"   ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td class="tdFilter" colspan="3" >
	    <asp:Panel runat="server" GroupingText="Fuente de Financiamiento Padre"  ID="PnlFuenteFinanciamientoPadre"  Width="750px"   >
                                <table  cellpadding="0" cellspacing="0" border="0" >
                                    <tr>
                                        <td>
                                            <uc:TreeFuenteFinanciamiento runat="server" ID="toFuenteFinanciamientoPadre" Handler="../Handlers/FuenteFinanciamientoHandler.ashx" SelectOption="Any" ShowOption="All" >
            </uc:TreeFuenteFinanciamiento>
                                        </td>
                                        <td class="tdFilter">
                                                <asp:CheckBox ID="chkIncluirSubFuenteFinanciamiento" runat="server" Text="Incluir Subitems"
                                                    CssClass="field_input"></asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
		                    </asp:Panel>
	    
	</div>
		</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterFuenteFinanciamiento" />
		</td>
		</tr>
</table>
