<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramaFilter.ascx.cs"
    Inherits="UI.Web.ProgramaFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter" colspan="2">
            <div>
                <asp:Literal ID="liSAF" Text="SAF" runat="server"></asp:Literal>&nbsp;<asp:RequiredFieldValidator
                    ID="rfvSAF" runat="server" ControlToValidate="ddlSAF" ValidationGroup="FilterPrograma"
                    Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlSAF"  runat="server" SkinID="AnchoLibre"  Width= "445" CssClass="field_input">
                </asp:DropDownList>
            </div>
        </td>
        <td class="tdFilter" style="width: 240px">
            <div>
                <asp:Literal ID="liFechaAlta" Text="Fecha de Alta" runat="server"></asp:Literal></div>
            <uc:DateRangeInput runat="server" ID="rdFechaAlta" ValidationGroup="FilterPrograma" />
        </td>
        <td class="tdFilter" style="width: 230px">
            <div>
                <asp:Literal ID="liActivo" Text="Activo" runat="server"></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
    </tr>
    <tr>
        <td width="230px" valign="top">
            <div>
                <asp:Literal ID="liCodigo" Text="Código" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revCodigo" runat="server" ControlToValidate="txtCodigo" ValidationGroup="FilterPrograma"
                    Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtCodigo" runat="server" CssClass="field_input" MaxLength="3"></asp:TextBox></div>
        </td>
        <td width="230px" valign="top">
            <div>
                <asp:Literal ID="liNombre" Text="Nombre" runat="server"></asp:Literal>&nbsp;<asp:RegularExpressionValidator
                    ID="revNombre" runat="server" ControlToValidate="txtNombre" ValidationGroup="FilterPrograma"
                    Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtNombre" runat="server" CssClass="field_input" MaxLength="255" ></asp:TextBox></div>
        </td>
         <td valign="top">
            <div>
                <asp:Literal ID="liFechaBaja" Text="Fecha de Baja" runat="server"></asp:Literal></div>
            <uc:DateRangeInput runat="server" ID="rdFechaBaja" ValidationGroup="FilterPrograma" />
        </td>
        <td valign="top">
            <div>
				<asp:Literal ID="ltSectorialista" Text="Sectorialista" runat="server"></asp:Literal>			</div>
               <div>             <cc:ExtendedDropDownList ID="ddlSectorialista" runat="server" CssClass="field_input">
                </cc:ExtendedDropDownList></div>
        </td>
       
    </tr>
    <tr>
        <td class="tdFilter">

        </td>
        <td class="tdFilter">

        </td>
        <td class="tdFilter">

        </td>
        <td align="right" valign="bottom">
            <asp:Button ID="btClear" runat="server" Text="Limpiar" OnClick="btClear_Click" Visible="true" CausesValidation="false" />
            &nbsp;<asp:Button ID="btSearch" runat="server" Text="Buscar" OnClick="btSearch_Click"
                Visible="true" ValidationGroup="FilterPrograma" />
        </td>
    </tr>	
</table>