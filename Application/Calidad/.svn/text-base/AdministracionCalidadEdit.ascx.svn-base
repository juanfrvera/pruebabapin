<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministracionCalidadEdit.ascx.cs"
    Inherits="UI.Web.AdministracionCalidadEdit" %>
<%@ Register TagPrefix="uc" TagName="ProyectoCalidadTabPanel" Src="~/ControlsPersonal/WebControl_CalidadTabPanel.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<style type="text/css">
    .smallCheck
    {
        font-size: x-small;
    }
    /*Matias 20150120 - Tarea 189*/
    .defaultGrid th
    {
	    cursor:default;
    }
    /*Matias 20150120 - Tarea 189*/
</style>
<table width="100%">
    <tr>
        <td style="vertical-align: top;">
	    <!--Matias 20140218 - Tarea 115 - (Entra: UpdatePanel | Sale: Panel)-->
            <asp:UpdatePanel ID="upHojaDeCalidad" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
            <!--<asp:Panel ID="pnlHojaDeCalidad" runat="server" GroupingText="Datos del Proyecto" Width="535px">-->
                <table cellpadding="0" cellspacing="5px" border="0" style="position:relative">
                    <tr>
                        <td colspan='2'>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 5%">
                            &nbsp;
                        </td>
                        <td style="width: 95%">
                            <asp:Literal ID="litActual" runat="server" Text="Actual"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litDenominacion" runat="server" Text="Denominación"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="tbDenominacionActual" runat="server" TextMode="MultiLine" Rows="3"
                                Enabled="false" Width="305"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <br />
                            <br />
                            <br />
                        </td>
                        <td>
                            <br />
                            <br />
                            <br />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litTipoProyecto" runat="server" Text="Tipo de Proyecto"></asp:Literal>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlTipoProyectoActual" runat="server" skinID="AnchoLibre" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlEstadoActual" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litProceso" runat="server" Text="Proceso"></asp:Literal>
                        </td>
                        <td>
                            <asp:DropDownList ID="ddlProcesoActual" runat="server" Enabled="false">
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litFinalidad" runat="server" Text="Finalidad Función"></asp:Literal>
                        </td>
                        <%--<td><asp:DropDownList ID="ddlFinalidadActual" runat="server" Enabled="false" ></asp:DropDownList></td>--%>
                        <td>
                            <asp:Panel ID="pnlFinalidadActual" runat="server" Enabled="false">
                                <uc:TreeFinalidadFuncion runat="server" ID="toFinalidadActual" SelectOption="OnlySelectedDefined" 
                                    ShowOption="ActivesAndActualValue" RequiredValue="true" ValidationGroup="EditionFinalidadFuncion"
                                    Handler="../Handlers/FinalidadFuncionHandler.ashx"></uc:TreeFinalidadFuncion>
                            </asp:Panel>
                        </td>
                        
                    </tr>
                    <tr>
                         <td>
                            <asp:Literal ID="litProvincias" runat="server" Text="Provincias"></asp:Literal>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td style="vertical-align: top;">
                                        <asp:DataList ID="dlProvinciasA" runat="server" CellSpacing="0" CellPadding="0">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkA" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>'
                                                    runat="server" CssClass="smallCheck" Enabled="false" />
                                                <asp:HiddenField ID="hdValueA" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                    <td valign="top" >
                                        <asp:DataList  ID="dlProvinciasB" runat="server" CellSpacing="0" CellPadding="0">
                                            <ItemTemplate>
                                                <asp:CheckBox ID="chkB" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>'
                                                    runat="server" CssClass="smallCheck" Enabled="false" />
                                                <asp:HiddenField ID="hdValueB" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                                            </ItemTemplate>
                                        </asp:DataList>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litUltPlan" runat="server" Text="Ult. Plan"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbUltPlan" Width="300px" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litDictamen" runat="server" Text="Dictamen"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbDictamen" Width="300px" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litUltPriorizacion" runat="server" Text="Ult. Priorización"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbUltPriorizacion" Width="200px" Enabled="false" />&nbsp;
                            <asp:TextBox runat="server" ID="tbPrioPeriodo" Width="100px" Enabled="false" />
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litArt15" runat="server" Text="Art.15"></asp:Literal>
                        </td>
                        <td>
                            <asp:CheckBox runat="server" ID="cbArt15" Enabled="false" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litPrioriOrga" runat="server" Text="Prioridad Organismo"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="tbPrioOrganismo" Width="150px" Enabled="false" />&nbsp;
                            <asp:TextBox runat="server" ID="tbPrioOrganismoNro" Width="140px" Enabled="false" />
                        </td>
                    </tr>
                </table>
            <!--</asp:Panel>-->
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
        <td style="vertical-align: top; padding-top: 5px">
            <asp:UpdatePanel ID="upCalidad" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <div style="margin: 0 auto; text-align: center; background-color: red">
                        <ul class="TabbedPanelsTabGroup">
                            <li id="ProyectoCalidadPageEdit" class="TabbedPanelsTabSelected" runat="server">
                                <asp:LinkButton runat="server" ID="lnkCalidadAdministracion" TabIndex="1" CommandArgument="~/Calidad/AdministracionCalidadPageEdit.aspx"
                                    CommandName="<%# Command.CONFIRM_CHANGE_PAGE %>" CausesValidation="false" OnCommand="lnk_Command"
                                    Text="Calidad"></asp:LinkButton>
                            </li>
                            <li id="Li1" class="TabbedPanelsTab" runat="server">
                                <asp:LinkButton runat="server" ID="lnkoCalidadPriorizacion" TabIndex="1" CommandArgument="~/Calidad/AdministracionCalidadPriorizacionPageEdit.aspx"
                                    CommandName="<%# Command.CONFIRM_CHANGE_PAGE %>" CausesValidation="false" OnCommand="lnk_Command"
                                    Text="Priorización"></asp:LinkButton>
                            </li>
                        </ul>
                    </div>
                    <table width="100%" cellpadding="0" cellspacing="3px" border="0" class="TabbedPanelsContentGroup">
                        <tr>
                            <td colspan='3'>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 14%">
                                &nbsp;
                            </td>
                            <td style="width: 44%">
                                <asp:Literal ID="litSugerido" runat="server" Text="Sugerido"></asp:Literal>
                            </td>
                            <td style="width: 2%; text-align: center">
                                <asp:Literal ID="litAceptado" runat="server" Text="OK"></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal1" runat="server" Text="Denominación"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="tbDenominacionSugerido" runat="server" TextMode="MultiLine" Rows="3"
                                    Width="305"></asp:TextBox>
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoDenominacion" runat="server" OnCheckedChanged="cbAceptadoDenominacion_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal7" runat="server" Text="Denominación Original"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="tbDenominacionOriginalSugerido" runat="server" TextMode="MultiLine"
                                    Rows="3" Enabled="false" Width="305"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal2" runat="server" Text="Tipo de Proyecto"></asp:Literal>
                            </td>
                            <td>
                                <asp:UpdatePanel ID="upTipoProyectoSugerido" runat ="server" UpdateMode ="Conditional" >
                                    <ContentTemplate >
                                        <cc:ExtendedDropDownList ID="ddlTipoProyectoSugerido" runat="server" OnSelectedIndexChanged="ddlTipoProyectoSugerido_SelectedIndexChanged"
                                            AutoPostBack="true">
                                        </cc:ExtendedDropDownList>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoTipoProyecto" runat="server" OnCheckedChanged="cbAceptadoTipoProyecto_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal3" runat="server" Text="Estado"></asp:Literal>
                            </td>
                            <td>
                                <cc:ExtendedDropDownList ID="ddlEstadoSugerido" runat="server">
                                </cc:ExtendedDropDownList>
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoEstado" runat="server" OnCheckedChanged="cbAceptadoEstado_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal4" runat="server" Text="Proceso"></asp:Literal>
                            </td>
                            <td>
                                <cc:ExtendedDropDownList ID="ddlProcesoSugerido" runat="server">
                                </cc:ExtendedDropDownList>    
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoProceso" runat="server" OnCheckedChanged="cbAceptadoProceso_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal5" runat="server" Text="Finalidad Función"></asp:Literal>
                            </td>
                            <td>
                                <uc:TreeFinalidadFuncion runat="server" ID="toFinalidadSugerido" SelectOption="OnlySelectedDefined"
                                    ShowOption="ActivesAndActualValue" RequiredValue="true" ValidationGroup="EditionFinalidadFuncion"
                                    Handler="../Handlers/FinalidadFuncionHandler.ashx"></uc:TreeFinalidadFuncion>
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoFinalidad" runat="server" OnCheckedChanged="cbAceptadoFinalidad_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="Literal6" runat="server" Text="Provincias"></asp:Literal>
                            </td>
                            <td>
                                <table>
                                    <tr>
                                        <td style="height: 50px; vertical-align: top">
                                            <asp:DataList ID="dlProvinciasC" runat="server" CellSpacing="0" CellPadding="0">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkC" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>'
                                                        runat="server" CssClass="smallCheck" />
                                                    <asp:HiddenField ID="hdValueC" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                        <td valign="top" style="height: 50px">
                                            <asp:DataList ID="dlProvinciasD" runat="server" CellSpacing="0" CellPadding="0">
                                                <ItemTemplate>
                                                    <asp:CheckBox ID="chkD" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>'
                                                        runat="server" CssClass="smallCheck" />
                                                    <asp:HiddenField ID="hdValueD" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                                                </ItemTemplate>
                                            </asp:DataList>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                            <td style="text-align: center">
                                <asp:CheckBox ID="cbAceptadoLocalizacion" runat="server" OnCheckedChanged="cbAceptadoLocalizacion_CheckedChanged"
                                    AutoPostBack="true" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:CheckBox runat="server" ID="cbRequiereDictamen" Text="Requiere Dictamen" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litEstadoCalidad" runat="server" Text="Estado"></asp:Literal>
                            </td>
                            <td colspan="2">
                                <cc:ExtendedDropDownList runat="server" ID="ddlEstadoCalidad" OnSelectedIndexChanged="ddlEstadoCalidad_OnSelectedIndexChanged"
                                    AutoPostBack="true">
                                </cc:ExtendedDropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="litFecha" runat="server" Text="Fecha"></asp:Literal>
                            </td>
                            <td colspan="2">
                                <uc:DateInput runat="server" ID="diFecha" />
                            </td>
                        </tr>
                        <tr>
                            <td colspan="3">
                                <asp:Literal ID="litComentario" runat="server" Text="Comentario"></asp:Literal><br />
                                <asp:TextBox TextMode="MultiLine" Rows="6" runat="server" ID="tbComentario" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </td>
    </tr>
    <tr>
        <td colspan="2">
            <asp:Panel ID="panelEstiamdoPI" runat="server" GroupingText="Gastos Estimados" > <!-- Matias 20141105 - Tarea 170 -->
            <!--Matias 20140218 - Tarea 115 - (Entra: UpdatePanel | Sale: Panel)-->
            <asp:UpdatePanel ID="upEtapaEstimada" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <!--<asp:Panel ID="pnlEtapaEstimada" runat="server" GroupingText="Estimados">-->
                <div style="text-align: right; width: 100%">
                    <asp:Literal runat="server" ID="litMonto1" Text="Monto Total:" />&nbsp;
                    <asp:Label runat="server" ID="lbMontoEstimado" Text="" />
                </div>
                <asp:GridView ID="gridEtapasEstimadas" runat="server" AutoGenerateColumns="true" 
                    DataKeyNames="ID" EmptyDataText="No hay elementos definidos" Width="100%" Style="margin-top: 0px" >                    
                    <Columns>
                    </Columns>
                </asp:GridView>
                <!--</asp:Panel>-->
                </ContentTemplate>
	        </asp:UpdatePanel>
            </asp:Panel>
            <asp:Panel ID="panelRealizadoPI" runat="server" GroupingText="Gastos Realizados" > <!-- Matias 20141105 - Tarea 170 -->
            <!--Matias 20140218 - Tarea 115 - (Entra: UpdatePanel | Sale: Panel)-->
            <asp:UpdatePanel ID="upEtapaRealizada" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <!--<asp:Panel ID="pnlEtapaRealizada" runat="server" GroupingText="Realizado">-->
                <div style="text-align: right; width: 100%">
                    <asp:Literal runat="server" ID="litMonto2" Text="Monto Total:" />&nbsp;
                    <asp:Label runat="server" ID="lbMontoRealizado" Text="" />
                </div>
                <asp:GridView ID="gridEtapasRealizadas" runat="server" AutoGenerateColumns="True"
                    DataKeyNames="ID" EmptyDataText="No hay elementos definidos" Width="100%">
                    <Columns>
                    </Columns>
                </asp:GridView>
                <!--</asp:Panel>-->
                </ContentTemplate>
	            </asp:UpdatePanel>
            </asp:Panel>
            <%--<asp:Panel ID="panelIndicadoresCalidad" runat="server" GroupingText="Indicadores"> <!-- Matias 20141105 - Tarea 170 -->
            <!--Matias 20140218 - Tarea 115 - (Entra: UpdatePanel | Sale: Panel)-->
                <asp:UpdatePanel ID="upPriorizacion" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <!--<asp:Panel ID="pnlPriorizacion" runat="server" GroupingText="Indicadores">-->
                <asp:GridView ID="gridProyectoPrioridad" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="False" AllowSorting="True" EmptyDataText="No hay elementos"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                        <asp:BoundField HeaderText="Valor" DataField="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Right"
                            DataFormatString="{0:0.#}" />
                        <asp:BoundField HeaderText="Año" DataField="Anio" SortExpression="Anio" />
                        <asp:BoundField HeaderText="Comentario" DataField="Observacion" SortExpression="Observacion" />
                    </Columns>
                </asp:GridView>
                <!--</asp:Panel>-->
                </ContentTemplate>
	            </asp:UpdatePanel>
            </asp:Panel>--%>
        </td>
    </tr>
</table>
