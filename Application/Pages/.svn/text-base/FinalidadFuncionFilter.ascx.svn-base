<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="FinalidadFuncionFilter.ascx.cs" Inherits="UI.Web.FinalidadFuncionFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>

<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodigo" runat="server"  ControlToValidate="txtCodigo" ValidationGroup="FilterFinalidadFuncion" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="3" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liDenominación" Text="Denominación" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server"  ControlToValidate="txtDenominacion" ValidationGroup="FilterFinalidadFuncion" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input"  MaxLength="50" ></asp:TextBox></div>
        </td><td class="tdFilter" style=" width:255px" ><div ><asp:Literal ID="liTipoFinalidadFunción" Text="Tipo de Finalidad - Función" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvFinalidadFunciontipo" runat="server" ControlToValidate="ddlFinalidadFunciontipo"  ValidationGroup="FilterFinalidadFuncion" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		<div><asp:DropDownList ID="ddlFinalidadFunciontipo" runat="server" CssClass="field_input"  ></asp:DropDownList></div>
		</td><td class="tdFilter" style=" width:140px" ><div ><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal></div>
		<div><uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState></div>        
		</td>
	</tr><tr>
	    <td colspan = "3">
                <asp:Panel runat="server" GroupingText="Finalidad - Función Padre"  ID="PnlCaracterEconomicoPadre"  Width="750px"   >
                    <table  cellpadding="0" cellspacing="0" border="0" >
                        <tr>
                            <td>
                                <uc:TreeFinalidadFuncion runat="server" ID="toFinalidadFuncionPadre" SelectOption="Any" ShowOption="All" Handler="../Handlers/FinalidadFuncionHandler.ashx"   >
            </uc:TreeFinalidadFuncion>
                            </td>
                            <td class="tdFilter">
                                    <asp:CheckBox ID="chkIncluirSubFinalidades" runat="server" Text="Incluir Subitems"
                                        CssClass="field_input"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
		</td>
		<td align="right" valign="bottom" >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterFinalidadFuncion"/>
		</td>
		</tr>
</table>
