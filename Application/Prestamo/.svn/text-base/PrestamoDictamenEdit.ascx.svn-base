<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoDictamenEdit.ascx.cs"
    Inherits="UI.Web.PrestamoDictamenEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<style type="text/css">
    .style1
    {
        width: 179px;
    }
</style>
<script type="text/jscript" language="javascript" >
function Change(input)
{
debugger ;
    CalcularTotales();
    ChangedWithThousandsFormat(input);
    ChangedWithThousandsFormat(document.getElementById('ctl00_ContenidoPrincipal_editPrestamoDictamen_lblMontoTotal'));
    document.getElementById('ctl00_ContenidoPrincipal_editPrestamoDictamen_lblMontoTotal').innerHTML = document.getElementById('ctl00_ContenidoPrincipal_editPrestamoDictamen_lblMontoTotal').value;
}
function ChangedWithThousandsFormat(input)
{
    var num = input.value.replace(/\./g,"");
    num = num.toString().split("").reverse().join("").replace(/(?=\d*\.?)(\d{3})/g,"$1.");
    num = num.split("").reverse().join("").replace(/^[\.]/,"");
    input.value = num;    
}

function CalcularTotales()
{

var prefix = 'ctl00_ContenidoPrincipal_editPrestamoDictamen_';
var MontoOtros = parseFloat(IsNumeric(document.getElementById(prefix + 'txtMontoOtros').value.replace('.', '')) ? document.getElementById(prefix + 'txtMontoOtros').value.replace('.', '') : '0');
var MontoPrestamo = parseFloat(IsNumeric(document.getElementById(prefix + 'txtMontoPrestamo').value.replace('.', '')) ? document.getElementById(prefix + 'txtMontoPrestamo').value.replace('.', '') : '0');
var MontoContraparteLocal = parseFloat(IsNumeric(document.getElementById(prefix + 'txtMontoContraparteLocal').value.replace('.', '')) ? document.getElementById(prefix + 'txtMontoContraparteLocal').value.replace('.', '') : '0');
var MontoTotal =  parseFloat(MontoOtros +  MontoPrestamo + MontoContraparteLocal).toFixed(2);
document.getElementById(prefix + 'lblMontoTotal').innerHTML =  MontoTotal.replace('.', '');
document.getElementById(prefix + 'lblMontoTotal').value =  MontoTotal.replace('.', '');
                        
}

</script>

<asp:Panel ID="pnlPrestamo" runat="server" GroupingText="Préstamo">
    <table>
        <tr>
            <td>
                <table width="450px" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liExpediente" Text="Expediente" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtExpediente" Width="100%" MaxLength="50"  runat="server" CssClass="field_input" TabIndex ="1"  ></asp:TextBox>
                        </td>
                        <td class="filaValidator">
                            &nbsp;<asp:RegularExpressionValidator ID="revExpediente" runat="server" ControlToValidate="txtExpediente"
                                ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvExpediente" runat="server" ControlToValidate="txtExpediente"
                                ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liOrganismo" Text="Organismo" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlOrganismo" runat="server" CssClass="field_input" TabIndex ="2" >
                            </cc:ExtendedDropDownList>
                        </td>
                        <td class="filaValidator">
                            <asp:RequiredFieldValidator ID="rfvOrganismo" runat="server" ControlToValidate="ddlOrganismo"
                                InitialValue="0" ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px"
                                Height="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liOrganismoDetalle" Text="Organismo Específico" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtOrganismoDetalle" Width="100%" MaxLength="255" runat="server" TabIndex ="3" TextMode="MultiLine" Rows="2"
                                CssClass="field_input"></asp:TextBox>
                        </td>
                        <td class="filaValidator">
                            &nbsp;<asp:RegularExpressionValidator ID="revOrganismoDetalle" runat="server" ControlToValidate="txtOrganismoDetalle"
                                ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El Organismo Específico no es válido"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtDenominacion" Width="100%" MaxLength="500" TextMode="MultiLine" TabIndex ="4"
                                Rows="4" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                        <td class="filaValidator">
                            &nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion"
                                ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="La Denominación no es válida"></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion"
                                ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liGestionTipo" Text="Tipo de Gestión" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlGestionTipo" runat="server" CssClass="field_input" TabIndex ="5">
                            </cc:ExtendedDropDownList>
                        </td>
                        <td class="filaValidator">
                            <asp:RequiredFieldValidator ID="rfvGestionTipo" runat="server" ControlToValidate="ddlGestionTipo"
                                InitialValue="0" ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px"
                                Height="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liOrganismoFinanciero" Text="Organismo Financiero" runat="server"></asp:Literal>
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlOrganismoFinanciero" runat="server" CssClass="field_input" TabIndex ="6" >
                            </cc:ExtendedDropDownList>
                        </td>
                        <td class="filaValidator">
                            <asp:RequiredFieldValidator ID="rfvOrganismoFinanciero" runat="server" ControlToValidate="ddlOrganismoFinanciero"
                                InitialValue="0" ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px"
                                Height="1px"></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
            </td>
            <td style="vertical-align: top">
                <asp:Panel ID="pnlUltimoEstado" runat="server" GroupingText="Último Estado">
                    <asp:UpdatePanel ID="upUltimoEstado" runat="server">
                        <ContentTemplate>
                            <table width="450px">
                                <tr>
                                    <td>
                                        <asp:Literal ID="liUsuario" runat="server" Text="Usuario"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbUsuario" runat="server" Enabled="false"></asp:Label>
                                    </td>
                                    <td align="right">
                                        <asp:Button ID="btAgregarEstado" runat="server" Text="Agregar" CausesValidation="false" OnClick="btAgregarEstado_Click" TabIndex ="13"/>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liEstadoSituacion" runat="server" Text="Estado Situación"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbEstadoSituacion" runat="server"></asp:Label>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liFechaEstado" runat="server" Text="Fecha"></asp:Literal>
                                    </td>
                                    <td>
                                        <uc:DateInput ID="diFechaEstado" runat="server" Enabled="false" />
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:Literal ID="liObservacionEstado" runat="server" Text="Comentario"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td colspan="3">
                                        <asp:TextBox ID="txtObservacionEstado" runat="server" Rows="5" TextMode="MultiLine"
                                            Width="100%" ReadOnly="true"></asp:TextBox>
                                    </td>
                                </tr>
                            </table>
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>


<asp:Panel ID="pnlPrestamoMontos" runat="server" GroupingText="Montos del préstamo">	
	<table>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liMontoContraparteLocal" Text="Contraparte Local" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <cc:NumericTextBox id="txtMontoContraparteLocal" Width="100px" runat="server" OnTextChanged ="Monto_TextChanged"  DataFormatString="{0:F2}"  AutoPostBack="true" UseSeparadorMiles ="true"  InputType="PositiveInteger" ></cc:NumericTextBox>
            </td>
            <td class="filaValidator">
                &nbsp;<asp:RegularExpressionValidator ID="revMontoContraparteLocal" runat="server"
                    ControlToValidate="txtMontoContraparteLocal" ValidationGroup="EditionPrestamoDictamen"
                    Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </td>
			
	    </tr>
		<tr>		
            <td class="tdLabel">
                <asp:Literal ID="liMontoOtros" Text="Otros" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <cc:NumericTextBox id="txtMontoOtros" runat="server" Width="100px"  DataFormatString="{0:F2}" OnTextChanged ="Monto_TextChanged"  AutoPostBack="true" UseSeparadorMiles ="true"  InputType="PositiveInteger" ></cc:NumericTextBox>
                
            </td>
            <td class="filaValidator">
                &nbsp;<asp:RegularExpressionValidator ID="revMontoOtros" runat="server" ControlToValidate="txtMontoOtros"
                    ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
            </td>
	    </tr>
		<tr>				
            <td class="tdLabel">
                <asp:Literal ID="liMontoPrestamo" Text="Préstamo" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <cc:NumericTextBox id="txtMontoPrestamo" runat="server"  Width="100px"  
                    DataFormatString="{0:F2}"  AutoPostBack="true" UseSeparadorMiles ="true"  
                    InputType="PositiveInteger" OnTextChanged ="Monto_TextChanged" ></cc:NumericTextBox>
                
            </td>
            <td class="filaValidator">
                &nbsp;<asp:RegularExpressionValidator ID="revMontoPrestamo" runat="server" ControlToValidate="txtMontoPrestamo"
                    ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
            </td>
	    </tr>
		<tr>				          
            <td class="tdLabel">
                <asp:Literal ID="liMontoTotal" Text="Total"  runat="server"></asp:Literal>
            </td>
            <td align="right" style="padding-right:4px">        
                <asp:Label ID="lblMontoTotal" runat="server"  Text=""></asp:Label>
            <td>
                &nbsp;
            </td>  			

        </tr>
    </table>
</asp:Panel>
    <table>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liPrestamo" Text="Préstamo" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <asp:TextBox ID="txtPrestamoNumero" OnTextChanged="txtPrestamoNumero_TextChanged" TabIndex ="10" 
                    runat="server" AutoPostBack="true"></asp:TextBox>
            </td>
            <td class="filaValidator">
                <asp:Label ID="lblPrestamoDenominacion" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liPrestamoDictamenRelacionado" Text="Dictamen Relacionado" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <asp:TextBox ID="txtPrestamoDictamenRelacionado" OnTextChanged="txtPrestamoDictamenRelacionado_TextChanged"
                    runat="server" AutoPostBack="true" TabIndex ="11" ></asp:TextBox>
            </td>
            <td class="filaValidator">
                <asp:Label ID="lblPrestamoDictamenRelacionado" runat="server" Text=""></asp:Label>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liAnalista" Text="Analista" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <cc:ExtendedDropDownList ID="ddlAnalista" runat="server" CssClass="field_input" TabIndex ="12" >
                </cc:ExtendedDropDownList>
            </td>
            <td class="filaValidator">
                <asp:RequiredFieldValidator ID="rfvAnalista" runat="server" ControlToValidate="ddlAnalista"
                    InitialValue="0" ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px"
                    Height="1px"></asp:RequiredFieldValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="pnlCalificacion" runat="server" GroupingText="Calificación">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liPrestamoCalificacion" Text="Calificación" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <cc:ExtendedDropDownList ID="ddlPrestamoCalificacion" runat="server" CssClass="field_input" TabIndex ="14">
                </cc:ExtendedDropDownList>
            </td>
            <td class="filaValidator">
            </td>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionFecha" Text="Fecha" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <uc:DateInput runat="server" IsValidEmpty="true" ID="diCalificacionFecha" />
            </td>
            <td class="filaValidator">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionITecnico" Text="Informe Técnico" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <asp:TextBox ID="txtCalificacionITecnico" MaxLength="50" runat="server" CssClass="field_input"></asp:TextBox>
            </td>
            <td class="filaValidator">
                &nbsp;<asp:RegularExpressionValidator ID="revCalificacionITecnico" runat="server"
                    ControlToValidate="txtCalificacionITecnico" ValidationGroup="EditionPrestamoDictamen"
                    Text="*" Width="1px" Height="1px" ErrorMessage="La Calificación Técnica no es válido"></asp:RegularExpressionValidator>
            </td>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionITFecha" Text="Informe Técnico Fecha" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <uc:DateInput runat="server" IsValidEmpty="true" ID="diCalificacionITFecha" />
            </td>
            <td class="filaValidator">
                &nbsp;
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionNotaDNIP" Text="Nota DNIP" runat="server"></asp:Literal>
            </td>
            <td class="filaInput">
                <asp:TextBox ID="txtCalificacionNotaDNIP" MaxLength="50" runat="server" CssClass="field_input"></asp:TextBox>
            </td>
            <td class="filaValidator">
                &nbsp;<asp:RegularExpressionValidator ID="revCalificacionNotaDNIP" runat="server"
                    ControlToValidate="txtCalificacionNotaDNIP" ValidationGroup="EditionPrestamoDictamen"
                    Text="*" Width="1px" Height="1px" ErrorMessage="La Nota DNIP no es válido"></asp:RegularExpressionValidator>
            </td>
            <td class="tdLabel">
                &nbsp;
            </td>
            <td class="filaInput">
                &nbsp;
            </td>
            <td class="filaValidator">
                &nbsp;
            </td>
        </tr>
    </table>
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionObservacion" Text="Observación" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="filaInput">
                <asp:TextBox ID="txtCalificacionObservacion" Width="100%" MaxLength="2147483647"
                    TextMode="MultiLine" Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCalificacionObservacion" runat="server" ControlToValidate="txtCalificacionObservacion"
                    ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="La Observación no es válida"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liCalificacionRecomendacion" Text="Recomendación" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="filaInput">
                <asp:TextBox ID="txtCalificacionRecomendacion" Width="100%" MaxLength="2147483647"
                    TextMode="MultiLine" Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revCalificacionRecomendacion" runat="server"
                    ControlToValidate="txtCalificacionRecomendacion" ValidationGroup="EditionPrestamoDictamen"
                    Text="*" Width="1px" Height="1px" ErrorMessage="La Recomendación no es válida"></asp:RegularExpressionValidator>
            </td>
        </tr>
        <tr>
            <td class="tdLabel">
                <asp:Literal ID="liComentario" Text="Otros" runat="server"></asp:Literal>
            </td>
        </tr>
        <tr>
            <td class="filaInput">
                <asp:TextBox ID="txtComentario" Width="100%" MaxLength="500" TextMode="MultiLine"
                    Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                <asp:RegularExpressionValidator ID="revComentario" runat="server" ControlToValidate="txtComentario"
                    ValidationGroup="EditionPrestamoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El Comentario no es válido"></asp:RegularExpressionValidator>
            </td>
        </tr>
    </table>
</asp:Panel>
<asp:Panel ID="PopUpEstados" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EstadosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpEstados" runat="server" Text="Estados" />
                </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEstados" DefaultButton="btSaveEstados" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upEstadosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5" border="0">
                    <tr>
                        <td>
                            <div>
                                <asp:Literal ID="liEstadoPopUpEstado" runat="server" Text="Estado"></asp:Literal>
                            </div>
                            <div>
                                <cc:ExtendedDropDownList ID="ddlEstadoPopUpEstado" runat="server" Width="200px">
                                </cc:ExtendedDropDownList>
                                <asp:RequiredFieldValidator ID="rfvEstadoPopUpEstado" runat="server" InitialValue="0"
                                    Text="*" ControlToValidate="ddlEstadoPopUpEstado" ValidationGroup="vgEstados">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div>
                                <asp:Literal ID="liUsuarioPopUpEstado" runat="server" Text="Usuario"></asp:Literal>
                            </div>
                            <div>
                                <cc:ExtendedDropDownList ID="ddlUsuarioPopUpEstado" runat="server">
                                </cc:ExtendedDropDownList>
                                <asp:RequiredFieldValidator ID="rfvUsuarioPopUpEstado" runat="server" InitialValue="0"
                                    Text="*" ControlToValidate="ddlUsuarioPopUpEstado" ValidationGroup="vgEstados">
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div>
                                <asp:Literal ID="liFechaPopUpEstado" runat="server" Text="Fecha"></asp:Literal>
                            </div>
                            <div>
                                <uc:DateInput ID="diFechaPopUpEstado" runat="server" IsValidEmpty="true" ValidationGroup="vgEstados" />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:Literal ID="liComentarioPopUpEstado" runat="server" Text="Comentario"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="3">
                            <asp:TextBox ID="txtComentarioPopUpEstado" runat="server" Rows="10" Width="100%"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveEstados" Text="Aceptar" OnClick="btSaveEstados_Click" runat="server"
                                ValidationGroup="vgEstados" />
                            <asp:Button ID="btNewEstados" Text="Aceptar y Crear Nuevo" OnClick="btNewEstados_Click"
                                runat="server" ValidationGroup="vgEstados" />
                            <asp:Button ID="btCancelEstados" Text="Cerrar" OnClick="btCancelEstados_Click" runat="server"
                                Width="60px" CausesValidation ="false"  />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ValidationSummary ID="vsEditionEstados" runat="server" DisplayMode="BulletList"
            ValidationGroup="vgEstados" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderPrestamoEstado" runat="server"
        CancelControlID="Button2" PopupDragHandleControlID="EstadosPopUpDragHandle" PopupControlID="PopUpEstados"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
