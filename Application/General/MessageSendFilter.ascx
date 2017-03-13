<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="MessageSendFilter.ascx.cs"
    Inherits="UI.Web.MessageSendFilter" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>



<table width="100%" cellpadding="0" cellspacing="0" border="0">
    <tr>
        <td class="tdFilter" style="width:25%">
            <div>
                <asp:Literal ID="liAgenda" Text="Agenda" runat="server" ></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkAgenda" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
        <td class="tdFilter" style="width:27%">
            <div>
                <asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></div>
            <uc:DateRangeInput runat="server" ID="rdStartDate" ValidationGroup="FilterMessage"/>          
        </td>
        <td class="tdFilter" style="width:25%">
            <div>
                <asp:Literal ID="liUsuario" Text="Usuario Destino" runat="server" ></asp:Literal>&nbsp;</div>
            <div>
                <uc:Autocomplete runat="server" ID="acUserTo" WebServiceName="~/Services/wsUsuario.asmx"
                    ServiceMethod="GetSimpleList" MinimumPrefixLength="4" AutoPostback="false" CssClass="CompletInput"
                    RequiredMessage="*" RequiredValue="false" ValidationGroup="FilterMessage"
                    ShowClearButton="true"></uc:Autocomplete>
            </div>
        </td>
         <td class="tdFilter" style="width:23px">
            <div style="width:100px">
                <asp:Literal ID="liProyecto" Text="Código BAPIN" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revCodProyecto" runat="server" ControlToValidate="txtCodProyecto"
                    ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
             </div>
            <div>
                 <asp:TextBox ID="txtCodProyecto" Type="text" runat="server" CssClass="field_input"></asp:TextBox>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liLeido" Text="Leído" runat="server" ></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkIsRead" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liFechaLectura" Text="Fecha de Lectura" runat="server" ></asp:Literal></div>
            <uc:DateRangeInput runat="server" ID="rdReadDate" ValidationGroup="FilterMessage" /> 
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liAsunto" Text="Asunto" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revSubject" runat="server" ControlToValidate="txtSubject"
                    ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
            <div>
                <asp:TextBox ID="txtSubject" runat="server" CssClass="field_input"></asp:TextBox></div>
        </td>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liPrioridad" Text="Prioridad" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvPriority" runat="server" ControlToValidate="ddlPriority"
                    ValidationGroup="FilterMessage" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></div>
            <div>
                <asp:DropDownList ID="ddlPriority" runat="server" Width="100px" >
                </asp:DropDownList>
            </div>
        </td>
    </tr>
    <tr>
        <td class="tdFilter">
            <div>
                <asp:Literal ID="liTipo" Text="Tipo" runat="server" ></asp:Literal></div>
            <div>
                <uc:ThreeState ID="chkIsManual" runat="server" CssClass="field_input"></uc:ThreeState>
            </div>
        </td>
        <td class="tdFilter">
             &nbsp;
        </td>
        <td class="tdFilter">
            &nbsp;
        </td>
        <td align="right" valign="bottom" >
            <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" CausesValidation="false" />
            &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterMessage" />
        </td>
    </tr>
</table>
