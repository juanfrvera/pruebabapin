<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ProyectoDictamenEdit.ascx.cs" Inherits="UI.Web.ProyectoDictamenEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>


<style type="text/css">
    .style1 {
        width: 260px;
    }

    .style2 {
        width: 233px;
    }
</style>
<script type="text/jscript" language="javascript">
    function ChangedWithThousandsFormat(input) {
        //debugger;
        var num = input.value.replace(/\./g, "");
        num = num.toString().split("").reverse().join("").replace(/(?=\d*\.?)(\d{3})/g, "$1.");
        num = num.split("").reverse().join("").replace(/^[\.]/, "");
        input.value = num;

    }
</script>

<table>
    <tr>
        <td>
            <asp:Panel ID="pnlCalificacion" runat="server" GroupingText="Calificación" Width="950px">
                <table width="100%">
                    <tr>
                        <td class="style2">
                            <asp:Literal ID="liNumero" Text="Nro." runat="server"></asp:Literal>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtNumero" Width="120px" type="text" min="0" MaxLength="10" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                        <td class="filaValidator">&nbsp;
                            <asp:RegularExpressionValidator ID="revNumero" runat="server" ControlToValidate="txtNumero"
                                ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El Número no es válido"></asp:RegularExpressionValidator>
                        </td>
                        <td class="tdLabel">&nbsp;
                        </td>
                        <td class="style1">
                            <asp:Literal ID="liFecha" Text="Fecha" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <uc:DateInput runat="server" IsValidEmpty="false" ID="diFecha" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Literal ID="liProyectoCalificacion" Text="Calificación" runat="server"></asp:Literal>
                        </td>
                        <td>&nbsp;
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlProyectoCalificacion" runat="server" CssClass="field_input"></cc:ExtendedDropDownList>
                        </td>
                        <td class="filaValidator">&nbsp;
                            <asp:RequiredFieldValidator ID="rfvProyectoCalificacion" runat="server" ControlToValidate="ddlProyectoCalificacion"
                                ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                        </td>
                        <td class="style5"></td>
                        <td class="style1">
                            <asp:Literal ID="liFechaVencimiento" Text="Fecha Vencimiento Calificación" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <uc:DateInput runat="server" IsValidEmpty="false" ID="diFechaVencimiento" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Literal ID="liInformeTecnico" Text="Informe Técnico" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revInformeTecnico" runat="server" ControlToValidate="txtInformeTecnico"
                            ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El Informe Técnico no es válido"></asp:RegularExpressionValidator>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtInformeTecnico" Width="195px" MaxLength="50" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                        <td></td>
                        <td class="style5"></td>
                        <td class="style1">
                            <asp:Literal ID="liFechaComiteTecnico" Text="Fecha Reunión Comité Técnico" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <uc:DateInput runat="server" IsValidEmpty="false" ID="diFechaComiteTecnico" />
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Literal ID="liMotivoIntervencion" Text="Motivo de Intervención" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlMotivoIntervencion" runat="server" CssClass="field_input"></cc:ExtendedDropDownList>
                        </td>
                        <td></td>
                        <td class="style5"></td>
                        <td class="style1">
                            <asp:Literal ID="liEjercicioInicioEjecucion" Text="Ejercicio Inicio Ejecución" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <cc:ExtendedDropDownList ID="ddlEjercicioInicioEjecucion" runat="server" CssClass="field_input" SkinID="AnchoLibre" Width="100px"></cc:ExtendedDropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td class="style2">
                            <asp:Literal ID="liMontoInversionAprobada" Text="Monto Inversión Aprobada" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revMontoInversionAprobada" runat="server"
                            ControlToValidate="txtMontoInversionAprobada" ValidationGroup="EditionProyectoDictamen"
                            Text="*" Width="1px" Height="1px" ErrorMessage="El Monto no es válido"></asp:RegularExpressionValidator>
                        </td>
                        <td class="filaInput">
                            <%--<asp:TextBox ID="txtMontoInversionAprobada" Width="150px" runat="server" CssClass="field_input" onchange="javascript: ChangedWithThousandsFormat( this );"   ></asp:TextBox>--%>
                            <cc:NumericTextBox ID="txtMontoInversionAprobada" Width="150px" runat="server" ValidationGroup="vgEtapasEstimadas" DataFormatString="{0:N0}" AutoPostBack="true" UseSeparadorMiles="true" InputType="PositiveInteger"></cc:NumericTextBox>
                        </td>
                        <td></td>
                        <td class="style5"></td>
                        <td class="style1">
                            <asp:Literal ID="liDuracionMeses" Text="Duración Etapa Inversión" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revDuracionMeses" runat="server" ControlToValidate="txtDuracionMeses"
                            ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="Los Meses de duración no son válidos"></asp:RegularExpressionValidator>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtDuracionMeses" Width="60px" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                    </tr>

                </table>
            </asp:Panel>
        </td>
        <tr>
            <td>
                <table width="950px">
                    <tr>
                        <td class="tdLabel">
                            <asp:Literal ID="liObservacion" Text="Observación" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revObservacion" runat="server" ControlToValidate="txtObservacion"
                            ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="La Observación no es válida"></asp:RegularExpressionValidator>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtObservacion" Width="800px" MaxLength="2147483647" TextMode="MultiLine"
                                Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    <tr>
        <td>
            <table width="950px">
                <tr>
                    <td class="tdLabel">
                        <asp:Literal ID="liRecomendacion" Text="Recomendación" runat="server"></asp:Literal>
                    </td>
                    <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRecomendacion" runat="server" ControlToValidate="txtRecomendacion"
                        ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El Recomendación no es valido"></asp:RegularExpressionValidator>
                    </td>
                    <td class="filaInput">
                        <asp:TextBox ID="txtRecomendacion" Width="800px" MaxLength="2147483647" TextMode="MultiLine"
                            Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                    </td>
                </tr>
            </table>
        </td>
    </tr>
</table>

<table width="100%">
    <tr>
        <td colspan="2">
            <asp:Panel ID="pnlRespuestaOrganismo" runat="server" GroupingText="Respuesta Del Organismo" Width="950px">
                <table width="100%">
                    <tr>
                        <td class="tdLabel">
                            <asp:Literal ID="liFechaRepuesta" Text="Fecha Respuesta" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;
                        </td>
                        <td class="filaInput">
                            <uc:DateInput runat="server" IsValidEmpty="true" ID="diFechaRepuesta" />
                        </td>
                    </tr>
                    <tr>
                        <td class="tdLabel">
                            <asp:Literal ID="liRespuestaOrganismo" Text="Respuesta Organismo" runat="server"></asp:Literal>
                        </td>
                        <td class="filaValidator">&nbsp;<asp:RegularExpressionValidator ID="revRespuestaOrganismo" runat="server" ControlToValidate="txtRespuestaOrganismo"
                            ValidationGroup="EditionProyectoDictamen" Text="*" Width="1px" Height="1px" ErrorMessage="El RespuestaOrganismo no es valido"></asp:RegularExpressionValidator>
                        </td>
                        <td class="filaInput">
                            <asp:TextBox ID="txtRespuestaOrganismo" Width="800px" MaxLength="2147483647" TextMode="MultiLine"
                                Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
        </td>
    </tr>
</table>

<!--TODO-->
<asp:Panel ID="pnlFileInfo" runat="server" GroupingText="Archivos Adjuntos" Width="950px">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">

        <tr>
            <td width="80%">
                <%-- <asp:HyperLink ID="hlFile" runat="server" Target="_blank" Text="" ></asp:HyperLink>  --%>
            </td>
            <%--<td width ="80%">
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarFileInfo" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>                                
                                                                                            
                                <asp:Button ID="btAgregarFileInfo" runat ="server" Text="Agregar" OnClick="btAgregarFileInfo_Click" CausesValidation ="false" /> 
                                <asp:Button ID="btEliminarFileInfo" runat ="server" Text="Eliminar" OnClick="btEliminarFileInfo_Click" CausesValidation ="false" /> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr>
                </table>        
            </td>--%>
        </tr>


    </table>
    <asp:UpdatePanel ID="upGridProyectoDictamenFiles" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gridProyectoDictamenFiles" runat="server"
                AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True"
                OnRowDataBound="GridProyectoDictamenFiles_OnRowDataBound"
                AllowSorting="True" OnSorting="GridProyectoDictamenFiles_Sorting"
                OnPageIndexChanging="GridProyectoDictamenFiles_PageIndexChanging" PageSize="1000"
                EmptyDataText="No hay Achivos adjundos"
                Width="100%">
                <Columns>
                       <asp:BoundField HeaderText="Fecha" DataField="File_Date" SortExpression="File_Date" HeaderStyle-Width="30px" DataFormatString="{0:dd/MM/yyyy}" />
                    <asp:BoundField HeaderText="Nombre" DataField="File_FileName" SortExpression="File_FileName" HeaderStyle-Width="700px" />
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                        <asp:HyperLink ID="hlOpen" runat="server" Target="_blank" ImageUrl="../Images/download.png"></asp:HyperLink>
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <%--<asp:UpdatePanel ID="upGridFileInfo" runat ="server" UpdateMode ="Conditional" >
                    <ContentTemplate >
                                 
                        <table width ="100%" >
                            <tr>
                                <td align ="right" >
                                    <asp:Button ID="btAgregarFileInfo" runat ="server" 
                                        Text ="Agregar" onclick="btAgregarFileInfo_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                             
                                    <asp:GridView ID="gvFileInfo" runat ="server" 
                                        Width="100%"
                                        AutoGenerateColumns="False" DataKeyNames="ID"     
                                        OnRowCommand="gvFileInfo_RowCommand"    
                                        OnSorting="gvFileInfo_Sorting"
                                        EmptyDataText="No hay Archivos adjuntos asociados" 
                                        AllowSorting="True"
                                         

                                    >
                                        <Columns >
                                            <asp:BoundField DataField="Denominacion" HeaderText="Nombre archivo" SortExpression="Denominacion"  ItemStyle-Width="10%" /> 
	                                        <asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
                                                <ItemTemplate>
	                                                &nbsp;
	                                                <asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'  CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                               </ItemTemplate>            
                                                <ItemStyle Width ="80px" />
                                            </asp:TemplateField>
                                        </Columns>
                                    </asp:GridView>
                                      
                                </td>
                            </tr>
                        
                        </table>
                    </ContentTemplate>
                </asp:UpdatePanel>--%>
</asp:Panel>
    
</asp:Panel>
