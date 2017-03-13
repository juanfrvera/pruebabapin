<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoComentarioTecnicoEdit.ascx.cs"
    Inherits="UI.Web.ProyectoComentarioTecnicoEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<table width="100%" cellpadding="0" cellspacing="5px" border="0">
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liTipoDeProyecto" Text="T.Proyecto" runat="server"></asp:Literal>
        </td>
        <td>
            &nbsp;
        </td>        
        <td valign="top">
            <asp:RadioButton ID="rbTipoProyectoInversion" runat="server" Text="Inversión" GroupName="obrTipoProyecto"
                OnCheckedChanged="rbTipoProyecto_OnCheckedChanged" AutoPostBack="true" TabIndex="1" />
            <asp:RadioButton ID="rbTipoProyectoPrestamo" runat="server" Text="Préstamo" GroupName="obrTipoProyecto"
                OnCheckedChanged="rbTipoProyecto_OnCheckedChanged" AutoPostBack="true" TabIndex="2" />                
        </td>
        <td>
            &nbsp;
        </td>

    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liProyecto" Text="Código" runat="server"></asp:Literal>&nbsp;
        </td>
        <td>
            &nbsp;
        </td>
        <td class="filaInput">
            <asp:TextBox ID="txtProyectoCodigo" type="text" min="0" ontextchanged="txtProyectoCodigo_TextChanged" runat="server"  AutoPostBack ="true" Width="100px" ></asp:TextBox>
            <asp:RequiredFieldValidator ID="rfvProyecto" runat="server" ControlToValidate="txtProyectoCodigo"
                ValidationGroup="EditionProyectoComentarioTecnico" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
        </td>
        <td class="filaValidator">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liNombreProyecto" Text="Denominación" runat="server"></asp:Literal>
        </td>
        <td>
            &nbsp;
        </td>
        <td class="filaInput">
            <asp:Literal ID="liProyectoNombre" runat="server"></asp:Literal>
        </td>
        <td class="filaValidator">
            &nbsp;
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liComentarioTecnico" Text="Tipo" runat="server"></asp:Literal>
        </td>
        <td>
            &nbsp;
        </td>
        <td class="filaInput">
            <cc:ExtendedDropDownList ID="ddlComentarioTecnico" runat="server" CssClass="field_input" ></cc:ExtendedDropDownList>
           
        </td>
        <td class="filaValidator">
            &nbsp;<asp:RequiredFieldValidator ID="rfvComentarioTecnico" runat="server" ControlToValidate="ddlComentarioTecnico"
                ValidationGroup="EditionProyectoComentarioTecnico" Text="*" Width="1px" Height="1px" InitialValue ="0"></asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liFecha" Text="Fecha" runat="server"></asp:Literal>
        </td>
        <td class="filaValidator">
            &nbsp;
        </td>
        <td class="filaInput">
            <uc:DateInput runat="server" IsValidEmpty="True" ID="diFecha"
            ValidationGroup="EditionProyectoComentarioTecnico" /> <!-- Matias 20150120 - Tarea 192 - NewSent "ValidationGroup="EditionProyectoComentarioTecnico" e IsValidEmpty="True" " -->
        </td>
    </tr>
    <tr>
        <td class="tdLabel">
            <asp:Literal ID="liObservacion" Text="Observación" runat="server"></asp:Literal>
        </td>
        <td class="filaValidator">
            &nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server" ControlToValidate="txtObservacion"
                ValidationGroup="EditionProyectoComentarioTecnico" Text="*" Width="1px" Height="1px"
                ErrorMessage="La Observación no es válida"></asp:RegularExpressionValidator>
                <asp:RequiredFieldValidator ID="rfvObservacion" runat="server" ControlToValidate="txtObservacion"
                ValidationGroup="EditionProyectoComentarioTecnico" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>                
        </td>
    </tr>
    <tr>
        <td class="filaInput" colspan="3">
            <asp:TextBox ID="txtObservacion" Width="100%" MaxLength="500" TextMode="MultiLine"
                Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
        </td>
    </tr>
    <tr>
        <td colspan="3">
            GeneraComentarioTecnico<asp:CheckBox ID="chkGeneraComentarioTecnico" runat="server"></asp:CheckBox>
        </td>
    </tr>
</table>
