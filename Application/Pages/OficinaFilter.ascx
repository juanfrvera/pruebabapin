<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="OficinaFilter.ascx.cs"
    Inherits="UI.Web.OficinaFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_OficinasSinJudisdiccion.ascx" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter" style=" width:220px">
            <div>
                <asp:Literal ID="liCodigo" Text="Código" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revCodigo" runat="server" ControlToValidate="txtCodigo" ValidationGroup="FilterOficina" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="15"></asp:TextBox></div>
        </td>
        <td class="tdFilter" style=" width:540px">
            <div>
                <asp:Literal ID="liJurisdiccion" Text="Jurisdicción Propia o Relacionada" runat="server"></asp:Literal>&nbsp;</div>
            <div>
                <asp:DropDownList ID="ddlJurisdiccion" runat="server" SkinID ="AnchoLibre" Width="548px"  AutoPostBack="true"
                    OnSelectedIndexChanged="ddlJurisdiccion_SelectedIndexChanged">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter" style=" width:140px">
            <div>
                <asp:Literal ID="liVisible" Text="Visible" runat="server"></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkVisible" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liNombre" Text="Nombre" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="FilterOficina"
                    Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="100"></asp:TextBox></div>
        </td>
        <td class="tdFilter" >
            <div>
                <asp:Literal ID="liSaf" Text="SAF Propio o Relacionado" runat="server"></asp:Literal>&nbsp;</div>
            <div>
                <asp:DropDownList ID="ddlSaf" runat="server"  SkinID ="AnchoLibre" Width="548px"  CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liActivo" Text="Activo" runat="server"></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter" colspan="2">
            <asp:Panel runat="server" GroupingText="Oficina Padre"  ID="PnlOficinaFamilia"  Width="96%"   >
                <table  cellpadding="0" cellspacing="0" border="0" style="  ">
                    <tr>
                        <td>
                        
                            <uc:TreeOficinas runat="server" ID="toOficinaPadre" SelectOption="Any" ShowOption="All" Handler="../Handlers/OficinaHandler.ashx">
                            </uc:TreeOficinas>
                        
                        </td>
                        <td class="tdFilter">
                                <asp:CheckBox ID="chkIncluirOficinasInteriores" runat="server" Text="Incluir Subitems"
                                    CssClass="field_input"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
		    </asp:Panel>
         </td>   
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="FilterOficina" />
        </td>
    </tr>
</table>
