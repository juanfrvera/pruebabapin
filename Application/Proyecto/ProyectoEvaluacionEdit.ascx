<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoEvaluacionEdit.ascx.cs"
    Inherits="UI.Web.Pages.ProyectoEvaluacionEdit" %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseAutocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteIndicadorClaseSinSector" Src="~/ControlsPersonal/WebControl_IndicadorClaseAutocompleteSinSector.ascx" %>
<%--German 01032014 - tarea 110--%>
<%@ Register TagPrefix="uc" TagName="TreeIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseTree.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeIndicadorClaseSinSector" Src="~/ControlsPersonal/WebControl_IndicadorClaseTreeSinSector.ascx" %>
<%--German 01032014 - tarea 110--%>

<style type="text/css">
    .tdLabel
    {
        width: 140px;
    }
    .filaInput
    {
        width: 350px;
    }
    .field_input
    {
        width: 350px;
    }
    .field_inputDropDown
    {
        width: 305px;
    }
    .filaValidator
    {
        width: 1px;
    }
    .style1
    {
        width: 120px;
    }
</style>
<%--PANEL INDICADORES EVALUACION --%>
<asp:Panel ID="pnlIndicadoresEvaluacion" runat="server" GroupingText="Indicadores Económicos">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td align="right">
                <asp:UpdatePanel ID="upAgregarIndicadorEconomico" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btAgregarIndicadorEconomico" runat="server" Text="Agregar" OnClick="btAgregarIndicadorEconomico_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGridIndicadoresEconomicos" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridIndicadoresEconomicos" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="false" OnRowCommand="GridIndicadoresEconomicos_RowCommand"
                            AllowSorting="False" OnSorting="GridIndicadoresEconomicos_Sorting" OnPageIndexChanging="GridIndicadoresEconomicos_PageIndexChanging"
                            EmptyDataText="No hay indicadores definidos" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Sigla" DataField="IndicadorClase_Sigla" SortExpression="IndicadorClase_Sigla" />
                                <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                                <asp:BoundField HeaderText="Unidad" DataField="IndicadorClase_Unidad" SortExpression="IndicadorClase_Unidad" />
                                <asp:BoundField HeaderText="Valor" DataField="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,0.00}"/>
                                <asp:BoundField HeaderText="Año" DataField="Anio" SortExpression="Anio" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="60px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upIndicadoresEconomicos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td width="700px">
                        <table width="700px" cellpadding="0" cellspacing="5px" border="0">
                            <tr>
                                <td>
                                    <asp:Literal ID="ltCriteriosEvaluacion" Text="Criterios de Evaluación" runat="server"></asp:Literal>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:TextBox runat="server" ID="txtCriteriosEvaluacion" Rows="6" TextMode="MultiLine"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:RegularExpressionValidator ID="revCriteriosEvaluacion" runat="server" ControlToValidate="txtCriteriosEvaluacion"
                                        ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0">
                            <tr>
                                <td>
                                    <asp:Literal ID="ltHorizonteEvaluacion" Text="Horizonte de Evaluación (años)" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <cc:NumericTextBox runat="server" ID="txtHorizonteEvaluacion" InputType="PositiveInteger"
                                        Width="50px"></cc:NumericTextBox>
                                    <asp:RegularExpressionValidator ID="revHorizonteEvaluacion" runat="server" ControlToValidate="txtHorizonteEvaluacion"
                                        ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="ltTasaReferencia" Text="Tasa de Referencia (%)" runat="server"></asp:Literal>
                                </td>
                                <td>
                                    <cc:NumericTextBox runat="server" ID="txtTasaReferencia" InputType="PositiveFractional"
                                        Width="50px"></cc:NumericTextBox>
                                    <asp:RegularExpressionValidator ID="revTasaReferencia" runat="server" ControlToValidate="txtTasaReferencia"
                                        ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                                    </asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
<%--PANEL BENEFICIOS --%>
<div class="CollapsiblePanelTab">
    <span id="spanBeneficios">
        <asp:Label ID="lblBeneficios" runat="server" Text="Beneficios"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeBeneficios" runat="Server" TargetControlID="pnlBeneficios"
        Collapsed="True" ExpandControlID="lblBeneficios" CollapseControlID="lblBeneficios"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlBeneficios" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td align="right">
                <asp:UpdatePanel ID="upAgregarIndicadorBeneficio" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btAgregarIndicadorBeneficio" runat="server" Text="Agregar" OnClick="btAgregarIndicadorBeneficio_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGridIndicadoresBeneficio" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridIndicadoresBeneficio" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridIndicadoresBeneficio_RowCommand"
                            AllowSorting="False" OnSorting="GridIndicadoresBeneficio_Sorting" OnPageIndexChanging="GridIndicadoresBeneficio_PageIndexChanging"
                            EmptyDataText="No hay indicadores definidos" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Sigla" DataField="IndicadorClase_Sigla" SortExpression="IndicadorClase_Sigla" />
                                <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                                <asp:BoundField HeaderText="Unidad" DataField="IndicadorClase_Unidad" SortExpression="IndicadorClase_Unidad" />
                                <asp:CheckBoxField HeaderText="Indirecto" DataField="Indirecto" SortExpression="Indirecto" />
                                <asp:BoundField HeaderText="Medio de Verificación" DataField="Indicador_MedioVerificacion"
                                    SortExpression="Indicador_MedioVerificacion" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEvoloucion" runat="server" src="../Images/evolution.png"
                                            ToolTip="Evolución" CommandName='<%# Command.SHOW_DETAILS %>' CommandArgument='<%#Eval("ID")%>'
                                            CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--PANEL BENEFICIARIOS 
<div class="CollapsiblePanelTab">
    <span id="spanBeneficiarios">
        <asp:Label ID="lblBeneficiarios" runat="server" Text="Beneficiarios"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeBeneficiarios" runat="Server" TargetControlID="pnlBeneficiarios"
        Collapsed="True" ExpandControlID="lblBeneficiarios" CollapseControlID="lblBeneficiarios"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlBeneficiarios" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td align="right">
                <asp:UpdatePanel ID="upAgregarIndicadorBeneficiario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btAgregarIndicadorBeneficiario" runat="server" Text="Agregar" OnClick="btAgregarIndicadorBeneficiario_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGridIndicadoresBeneficiario" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridIndicadoresBeneficiario" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridIndicadoresBeneficiario_RowCommand"
                            AllowSorting="False" OnSorting="GridIndicadoresBeneficiario_Sorting" OnPageIndexChanging="GridIndicadoresBeneficiario_PageIndexChanging"
                            EmptyDataText="No hay indicadores definidos" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Descripción" DataField="Beneficiario" SortExpression="Beneficiario" />
                                <asp:CheckBoxField HeaderText="Indirecto" DataField="Indirecto" SortExpression="Indirecto" />
                                <asp:BoundField HeaderText="Medio de Verificación" DataField="Indicador_MedioVerificacion"
                                    SortExpression="Indicador_MedioVerificacion" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEvoloucion" runat="server" src="../Images/evolution.png"
                                            ToolTip="Evolución" CommandName='<%# Command.SHOW_DETAILS %>' CommandArgument='<%#Eval("ID")%>'
                                            CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>
--%>

<%--PANEL MARCOS LEGAL

<div class="CollapsiblePanelTab" style="display:none">
    <span id="spanMarcoLegal">
        <asp:Label ID="lblMarcoLegal" runat="server" Text="Marco Legal"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeMarcoLegal" runat="Server" TargetControlID="pnlMarcoLegal"
        Collapsed="True" ExpandControlID="lblMarcoLegal" CollapseControlID="lblMarcoLegal"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlMarcoLegal" runat="server" Visible="false">
    <asp:UpdatePanel ID="upMarcoLegal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtMarcoLegal" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revMarcoLegal" runat="server" ControlToValidate="txtMarcoLegal"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
 --%>

<%--PANEL ESTUDIOS
<div class="CollapsiblePanelTab">
    <span id="spanEstudios">
        <asp:Label ID="lblEstudios" runat="server" Text="Estudios"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeEstudios" runat="Server" TargetControlID="pnlEstudios"
        Collapsed="True" ExpandControlID="lblEstudios" CollapseControlID="lblEstudios"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlEstudios" runat="server">
    <asp:UpdatePanel ID="upEstudios" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:Literal ID="ltEstudiosRealizados" Text="Estudios Realizados :" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtEstudiosRealizados" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revEstudiosRealizados" runat="server" ControlToValidate="txtEstudiosRealizados"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="ltEstudiosARealizar" Text="Estudios a Realizar" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtEstudiosARealizar" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revEstudiosARealizar" runat="server" ControlToValidate="txtEstudiosARealizar"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
 --%>

<%--PANEL SITUACION SIN PROYECTO
<div class="CollapsiblePanelTab">
    <span id="spanSituacionSinProyecto">
        <asp:Label ID="lblSituacionSinProyecto" runat="server" Text="Situación sin Proyecto"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeSituacionSinProyecto" runat="Server"
        TargetControlID="pnlSituacionSinProyecto" Collapsed="True" ExpandControlID="lblSituacionSinProyecto"
        CollapseControlID="lblSituacionSinProyecto" AutoCollapse="False" AutoExpand="False"
        ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlSituacionSinProyecto" runat="server">
    <asp:UpdatePanel ID="upSituacionSinProyecto" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtSituacionSinProyecto" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revSituacionSinProyecto" runat="server" ControlToValidate="txtSituacionSinProyecto"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
 --%>

<%--PANEL OPCIONES
<div class="CollapsiblePanelTab">
    <span id="spanOpciones">
        <asp:Label ID="lblOpciones" runat="server" Text="Opciones"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeOpciones" runat="Server" TargetControlID="pnlOpciones"
        Collapsed="True" ExpandControlID="lblOpciones" CollapseControlID="lblOpciones"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlOpciones" runat="server">
    <asp:UpdatePanel ID="upOpciones" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:Literal ID="ltOpcionA" Text="Opción A" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtOpcionA" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revOpcionA" runat="server" ControlToValidate="txtOpcionA"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="ltOpcionB" Text="Opción B" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtOpcionB" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revOpcionB" runat="server" ControlToValidate="txtOpcionB"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="ltJustificacionOpcion" Text="Justificación de la Opción" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtJustificacionOpcion" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revJustificacionOpcion" runat="server" ControlToValidate="txtJustificacionOpcion"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
 --%>

<%--PANEL INDICADORES PRIORIZACIONES --%>
<div class="CollapsiblePanelTab">
    <span id="spanIndicadoresPriorizacion">
        <asp:Label ID="lblIndicadoresPriorizacion" runat="server" Text="Indicadores de Priorización"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeIndicadoresPriorizacion" runat="Server"
        TargetControlID="pnlIndicadoresPriorizacion" Collapsed="True" ExpandControlID="lblIndicadoresPriorizacion"
        CollapseControlID="lblIndicadoresPriorizacion" AutoCollapse="False" AutoExpand="False"
        ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlIndicadoresPriorizacion" runat="server">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td align="right">
                <asp:UpdatePanel ID="upAgregarIndicadorPriorizacion" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:Button ID="btAgregarIndicadorPriorizacion" runat="server" Text="Agregar" OnClick="btAgregarIndicadorPriorizacion_Click" />
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upGridIndicadoresPriorizacion" runat="server" UpdateMode="Conditional">
                    <ContentTemplate>
                        <asp:GridView ID="gridIndicadoresPriorizacion" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridIndicadoresPriorizacion_RowCommand"
                            AllowSorting="False" OnSorting="GridIndicadoresPriorizacion_Sorting" OnPageIndexChanging="GridIndicadoresPriorizacion_PageIndexChanging"
                            EmptyDataText="No hay indicadores definidos" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Sigla" DataField="IndicadorClase_Sigla" SortExpression="IndicadorClase_Sigla" />
                                <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                                <asp:BoundField HeaderText="Unidad" DataField="IndicadorClase_Unidad" SortExpression="IndicadorClase_Unidad" />
                                <asp:BoundField HeaderText="Valor" DataField="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Right"
                                    DataFormatString="{0:#,0.00}"/>
                                <asp:BoundField HeaderText="Año" DataField="Anio" SortExpression="Anio" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                            CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                            CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
    </table>
</asp:Panel>
<%------  POPUPS ------%>
<%--PANEL ALTA INDICADORES PROYECTO --%>
<asp:Panel ID="PopUpIndicadoresProyecto" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="IndicadoresProyectoPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpIndicadoresProyecto" runat="server" Text="Indicadores" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnIndicadoresProyecto"  DefaultButton="btSaveIndicadoresProyecto" runat="server" Width="800px">
        <asp:UpdatePanel ID="upIndicadoresProyectoPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <table width="100%">
                                <tr>
                                    <td>
                                        <%--German 01032014 - Tarea 124 
                                        <asp:Literal ID="ltIndicador" Text="Indicador" runat="server"></asp:Literal> 
                                        German 01032014 - Tarea 124--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <uc:AutocompleteIndicadorClaseSinSector runat="server" ID="autoCmpIndicadorClaseIndicadoresProyecto"
                                            Width="300px" AutocompleteHandler="../Handlers/IndicadorClaseAutocompleteSimpleHandler.ashx"
                                            RequiredValue="true" ShowOption="ActivesAndActualValue" ValidationGroup="vgIndicadorProyecto">
                                        </uc:AutocompleteIndicadorClaseSinSector>
                                    </td>
                                </tr>
                                <%--German 01032014 - tarea 110--%>
                                <tr>
                                    <td style="padding-top:0px" width="600px" >
                                        <%--German 20140511 - Tarea 124 - Original: Text="Sectores e Indicadores"--%>
                                        <asp:Literal ID="Literal2" Text="Indicador" runat="server" ></asp:Literal>
                                        <%--Fin German 20140511 - Tarea 124--%>
                                        <uc:TreeIndicadorClaseSinSector runat="server" ID="toIndicadoClaseSinSector" Handler="../Handlers/IndicadorClaseSinSectorHandler.ashx" 
                                        SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" RequiredValue="true" ValidationGroup="vgIndicador" Width="400px"> </uc:TreeIndicadorClaseSinSector>
                                    </td>
                                </tr>
                                <%--German 01032014 - tarea 110--%>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltValorIndicadoresProyecto" Text="Valor" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc:NumericTextBox runat="server" ID="txtValorIndicadoresProyecto" InputType="PositiveFractional"></cc:NumericTextBox>
                                        <asp:RequiredFieldValidator ID="rfvValorIndicadoresProyecto" runat="server" ControlToValidate="txtValorIndicadoresProyecto"
                                            ValidationGroup="vgIndicadorProyecto" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                        <!--Matias 20141126 - Tarea 183-->
                                        <asp:RegularExpressionValidator ID="revValorIndicadoresProyecto" runat="server" ControlToValidate="txtValorIndicadoresProyecto"
                                            ValidationGroup="vgIndicadorProyecto" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                        <!--FinMatias 20141126 - Tarea 183-->
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltAnoIndicadoresProyecto" Text="Año" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <cc:ExtendedDropDownList ID="ddlAnoIndicadoresProyecto" runat="server">
                                        </cc:ExtendedDropDownList>
                                        <asp:RequiredFieldValidator ID="rfvAnoIndicadoresProyecto" runat="server" ControlToValidate="ddlAnoIndicadoresProyecto"
                                            InitialValue="0" ValidationGroup="vgIndicadorProyecto" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltObservacionesIndicadoresProyecto" Text="Observaciones" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObservacionesIndicadoresProyecto" Rows="6" TextMode="MultiLine"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revObservacionesIndicadoresProyecto" runat="server"
                                ControlToValidate="txtObservacionesIndicadoresProyecto" ValidationGroup="vgIndicadorProyecto"
                                Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveIndicadoresProyecto" Text="Aceptar" OnClick="btSaveIndicadorProyecto_Click"
                                runat="server" ValidationGroup="vgIndicadorProyecto" />
                            <asp:Button ID="btNewIndicadoresProyecto" Text="Aceptar y Agregar Nuevo" OnClick="btNewIndicadorProyecto_Click"
                                runat="server" ValidationGroup="vgIndicadorProyecto" />
                            <asp:Button ID="btCancelIndicadoresProyecto" Text="Cerrar" OnClick="btCancelIndicadorProyecto_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsIndicadorProyecto" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgIndicadorProyecto" ShowSummary="False" ShowMessageBox="True">
    </asp:ValidationSummary>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadoresProyecto" runat="server"
        CancelControlID="Button1" PopupDragHandleControlID="IndicadoresProyectoPopUpDragHandle"
        PopupControlID="PopUpIndicadoresProyecto" OkControlID="Button1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA INDICADORES BENEFICIO --%>
<asp:Panel ID="PopUpIndicadoresBeneficio" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="IndicadoresBeneficioPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpIndicadoresBeneficio" runat="server" Text="Beneficios" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnIndicadoresBeneficio" DefaultButton="btSaveIndicadoresBeneficio" runat="server" Width="800px">
        <asp:UpdatePanel ID="upIndicadoresBeneficioPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloIndicadoresBeneficio" runat="server" Text=""></asp:Label>
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <uc:AutocompleteIndicadorClase runat="server" ID="autoCmpIndicadorClaseBeneficio"
                                Width="300px" AutocompleteHandler="../Handlers/IndicadorClaseAutocompleteSimpleHandler.ashx"
                                RequiredValue="true" ShowOption="ActivesAndActualValue" ValidationGroup="vgIndicadorBeneficio">
                            </uc:AutocompleteIndicadorClase>
                        </td>
                    </tr>
                    <%--German 01032014 - tarea 110--%>
                    <tr>
                        <td style="padding-top:0px" width="600px" >
                            <%--German 19042014 - Tarea 124--%>
                            <%--<asp:Literal ID="Literal3" Text="Sectores e Indicadores" runat="server" ></asp:Literal>--%>
                            <asp:Literal ID="Literal3" Text="Sector&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Indicador" runat="server" ></asp:Literal>
                            <%--Fin German 19042014 - Tarea 124--%>
                            <uc:TreeIndicadorClase runat="server" ID="toIndicadoClase" Handler="../Handlers/IndicadorClaseHandler.ashx" 
                            SelectOption="Any" ShowOption="All" RequiredValue="true" ValidationGroup="vgIndicadorBeneficio" Width="600px"> </uc:TreeIndicadorClase>
                        </td>
                    </tr>
                       <%--German 01032014 - tarea 110--%>
                    <tr>
                        <td>
                            <asp:CheckBox ID="chkIndirectoBeneficio" Text="Indirecto" runat="server"></asp:CheckBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltMedioVerificacionBeneficio" Text="Medio de Verificación" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMedioVerificacionBeneficio" runat="server" OnSelectedIndexChanged="ddlMedioVerificacionBeneficio_IndexChanged">
                            </asp:DropDownList>
                            <!-- Matias 20170209 - Ticket #REQ819714 -->
                            <asp:RequiredFieldValidator ID="rfvMedioVerificacion2" runat="server" ControlToValidate="ddlMedioVerificacionBeneficio" ValidationGroup="vgIndicadorBeneficio" InitialValue="" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                            <asp:RequiredFieldValidator ID="rfvMedioVerificacion" runat="server" ControlToValidate="ddlMedioVerificacionBeneficio" ValidationGroup="vgIndicadorBeneficio" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                            <!-- FinMatias 20170209 - Ticket #REQ819714 -->
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltObservacionesIndicadoresBeneficio" Text="Observaciones" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObservacionesIndicadoresBeneficio" Rows="6" TextMode="MultiLine"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revObservacionesIndicadoresBeneficio" runat="server"
                                ControlToValidate="txtObservacionesIndicadoresBeneficio" ValidationGroup="vgIndicadorBeneficio"
                                Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveIndicadoresBeneficio" Text="Aceptar" OnClick="btSaveIndicadorBeneficio_Click"
                                runat="server" ValidationGroup="vgIndicadorBeneficio" />
                            <asp:Button ID="btNewIndicadoresBeneficio" Text="Aceptar y Agregar Nuevo" OnClick="btNewIndicadorBeneficio_Click"
                                runat="server" ValidationGroup="vgIndicadorBeneficio" />
                            <asp:Button ID="btCancelIndicadoresBeneficio" Text="Cerrar" OnClick="btCancelIndicadorBeneficio_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsIndicadorBeneficio" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgIndicadorBeneficio" ShowSummary="False" ShowMessageBox="True">
    </asp:ValidationSummary>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadoresBeneficio" runat="server"
        CancelControlID="Button2" PopupDragHandleControlID="IndicadoresBeneficioPopUpDragHandle"
        PopupControlID="PopUpIndicadoresBeneficio" OkControlID="Button2" TargetControlID="Button2"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA INDICADORES BENEFICIARIO --%>
<asp:Panel ID="PopUpIndicadoresBeneficiario" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="IndicadoresBeneficiarioPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpIndicadoresBeneficiario" runat="server" Text="Beneficiarios" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnIndicadoresBeneficiario" DefaultButton="btSaveIndicadoresBeneficiario" runat="server" Width="800px">
        <asp:UpdatePanel ID="upIndicadoresBeneficiarioPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltDescripcionBeneficiario" Text="Descripción" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                       <br />
                                    </td>
                                </tr>                                
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtDescripcionBeneficiario" Rows="2" TextMode="MultiLine"></asp:TextBox>
                                        <asp:RequiredFieldValidator ID="rfvDescripcionBeneficiario" runat="server" ControlToValidate="txtDescripcionBeneficiario"
                                            ValidationGroup="vgIndicadorBeneficiario" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDescripcionBeneficiario" runat="server" ControlToValidate="txtDescripcionBeneficiario"
                                            ValidationGroup="vgIndicadorBeneficiario" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:CheckBox ID="chkIndirectoBeneficiario" Text="Indirecto" runat="server"></asp:CheckBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltMedioVerificacionBeneficiario" Text="Medio de Verificación" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:DropDownList ID="ddlMedioVerificacionBeneficiario" runat="server" OnSelectedIndexChanged="ddlMedioVerificacionBeneficiario_IndexChanged">
                                        </asp:DropDownList>
                                        <!-- Matias 20170209 - Ticket #REQ819714 -->
                                        <asp:RequiredFieldValidator ID="rfvMedioVerificacion3" runat="server" ControlToValidate="ddlMedioVerificacionBeneficiario" ValidationGroup="vgIndicadorBeneficiario" InitialValue="" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                        <asp:RequiredFieldValidator ID="rfvMedioVerificacion4" runat="server" ControlToValidate="ddlMedioVerificacionBeneficiario" ValidationGroup="vgIndicadorBeneficiario" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                        <!-- FinMatias 20170209 - Ticket #REQ819714 -->
                                    </td>                                    
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltObservacionesIndicadoresBeneficiario" Text="Observaciones" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObservacionesIndicadoresBeneficiario" Rows="6"
                                TextMode="MultiLine"></asp:TextBox>
                            <asp:RegularExpressionValidator ID="revObservacionesIndicadoresBeneficiario" runat="server"
                                ControlToValidate="txtObservacionesIndicadoresBeneficiario" ValidationGroup="vgIndicadorBeneficiario"
                                Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                </td> </tr> </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveIndicadoresBeneficiario" Text="Aceptar" OnClick="btSaveIndicadorBeneficiario_Click"
                                runat="server" ValidationGroup="vgIndicadorBeneficiario" />
                            <asp:Button ID="btNewIndicadoresBeneficiario" Text="Aceptar y Agregar Nuevo" OnClick="btNewIndicadorBeneficiario_Click"
                                runat="server" ValidationGroup="vgIndicadorBeneficiario" />
                            <asp:Button ID="btCancelIndicadoresBeneficiario" Text="Cerrar" OnClick="btCancelIndicadorBeneficiario_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsIndicadorBeneficiario" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgIndicadorBeneficiario" ShowSummary="False" ShowMessageBox="True">
    </asp:ValidationSummary>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadoresBeneficiario" runat="server"
        CancelControlID="Button3" PopupDragHandleControlID="IndicadoresBeneficiarioPopUpDragHandle"
        PopupControlID="PopUpIndicadoresBeneficiario" OkControlID="Button2" TargetControlID="Button3"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA EVOLUCIONES BENFICIARIOS --%>
<asp:Panel ID="PopUpEvolucionesBeneficiario" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EvolucionesBeneficiarioPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEvolucionesBeneficiario" runat="server" Text="Evolución" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEvolucionesBeneficiario" DefaultButton="btNewEvolucionBeneficiario" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upEvolucionesBeneficiarioPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloEvolucionesBeneficiario" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Panel ID="pnEvolucionesBeneficiarioAgregar" runat="server" GroupingText="Agregar">
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td>
                                <asp:Literal ID="ltLocalizacion" Text="Localización" runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <uc:TreeLocalizacion runat="server" ID="tsEvolucionBeneficiario" RequiredValue="true"
                                    ValidationGroup="vgEvolucionBeneficiario" SelectOption="OnlySelectedDefined"
                                    ShowOption="ActivesAndActualValue"></uc:TreeLocalizacion>
                            </td>
                            <td>
                                <asp:Literal ID="ltTipoEvolucionBeneficiario" Text="Tipo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoEvolucionBeneficiario" runat="server" SkinID ="AnchoLibre" Width="120px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoEvolucionBeneficiario" runat="server" ControlToValidate="ddlTipoEvolucionBeneficiario"
                                    InitialValue="0" ValidationGroup="vgEvolucionBeneficiario" Text="*" Width="1px"
                                    Height="1px"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltFechaEstimadaEvolucionBeneficiario" Text="Fecha Estimada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput ID="diFechaEstimadaEvolucionBeneficiario" runat="server" ValidationGroup="vgEvolucionBeneficiario"
                                    IsValidEmpty="true" />
                            </td>
                            <td>
                                <asp:Literal ID="ltCantidadEstimadaEvolucionBeneficiario" Text="Cantidad Estimada"
                                    runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox runat="server" ID="txtCantidadEstimadaEvolucionBeneficiario" InputType="PositiveFractional" Width="115px"></cc:NumericTextBox>
                                <asp:RequiredFieldValidator ID="rfvCantidadEstimadaEvolucionBeneficiario" runat="server"
                                    ControlToValidate="txtCantidadEstimadaEvolucionBeneficiario" ValidationGroup="vgEvolucionBeneficiario"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCantidadEstimadaEvolucionBeneficiario" runat="server"
                                    ControlToValidate="txtCantidadEstimadaEvolucionBeneficiario" ValidationGroup="vgEvolucionBeneficiario"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltFechaRealizadaEvolucionBeneficiario" Text="Fecha Realizada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput ID="diFechaRealizadaEvolucionBeneficiario" runat="server" ValidationGroup="vgEvolucionBeneficiario"
                                    IsValidEmpty="false" />
                            </td>
                            <td>
                                <asp:Literal ID="ltCantidadRealizadaEvolucionBeneficiario" Text="Cantidad Realizada"
                                    runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox runat="server" ID="txtCantidadRealizadaEvolucionBeneficiario"
                                    InputType="PositiveFractional" Width="115px" ></cc:NumericTextBox>
                                <asp:RegularExpressionValidator ID="revCantidadRealizadaEvolucionBeneficiario" runat="server"
                                    ControlToValidate="txtCantidadRealizadaEvolucionBeneficiario" ValidationGroup="vgEvolucionBeneficiario"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewEvolucionBeneficiario" Text="Agregar" OnClick="btSaveEvolucionBeneficiario_Click"
                                    runat="server" ValidationGroup="vgEvolucionBeneficiario" />
                                <asp:Button ID="btSaveEvolucionBeneficiario" Text="Guardar" OnClick="btNewEvolucionBeneficiario_Click"
                                    runat="server" ValidationGroup="vgEvolucionBeneficiario" />
                                <asp:Button ID="btCancelEvolucionBeneficiario" Text="Cerrar" OnClick="btCancelEvolucionBeneficiario_Click"
                                    ValidationGroup="vgEvolucionBeneficiarioPopUp" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="upGridEvolucionesBeneficiario" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridEvolucionesBeneficiario" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridEvolucionesBeneficiario_RowCommand"
                    AllowSorting="False" OnSorting="GridEvolucionesBeneficiario_Sorting" OnPageIndexChanging="GridEvolucionesBeneficiario_PageIndexChanging"
                    EmptyDataText="No hay Evoluciones definidas" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Localización Geográfica" DataField="ClasificacionGeografica_Descripcion"
                            SortExpression="ClasificacionGeografica_Descripcion" />
                        <asp:BoundField HeaderText="Tipo" DataField="IndicadorEvolucionInstancia_Nombre"
                            SortExpression="IndicadorEvolucionInstancia_Nombre" />
                        <asp:BoundField HeaderText="Fecha E." DataField="FechaEstimada" SortExpression="FechaEstimada"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad E." DataField="CantidadEstimada" SortExpression="CantidadEstimada"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Fecha Real" DataField="FechaReal" SortExpression="FechaReal"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad Real" DataField="CantidadReal" SortExpression="CantidadReal"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                    CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsEvolucionBeneficiario" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgEvolucionBeneficiario" ShowSummary="False" ShowMessageBox="True">
    </asp:ValidationSummary>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEvolucionesBeneficiario" runat="server"
        CancelControlID="Button4" PopupDragHandleControlID="EvolucionesBeneficiarioPopUpDragHandle"
        PopupControlID="PopUpEvolucionesBeneficiario" OkControlID="Button4" TargetControlID="Button4"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA EVOLUCIONES BENFICIO --%>
<asp:Panel ID="PopUpEvolucionesBeneficio" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EvolucionesBeneficioPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEvolucionesBeneficio" runat="server" Text="Evolución" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEvolucionesBeneficio" DefaultButton="btNewEvolucionBeneficio" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upEvolucionesBeneficioPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloEvolucionesBeneficio" runat="server" Text=""></asp:Label>
                <asp:Panel ID="pnEvolucionesBeneficioAgregar" runat="server" GroupingText="Agregar">
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td>
                                <asp:Literal ID="Literal1" Text="Localización" runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <uc:TreeLocalizacion runat="server" ID="tsEvolucionBeneficio" RequiredValue="true"
                                    ValidationGroup="vgEvolucionBeneficio" TabIndex="0"></uc:TreeLocalizacion>
                            </td>
                            <td>
                                <asp:Literal ID="ltTipoEvolucionBeneficio" Text="Tipo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoEvolucionBeneficio" Width="120px" SkinID="AnchoLibre"
                                    TabIndex="1" runat="server">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoEvolucionBeneficio" runat="server" ControlToValidate="ddlTipoEvolucionBeneficio"
                                    InitialValue="0" ValidationGroup="vgEvolucionBeneficio" Text="*" Width="1px"
                                    Height="1px"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltFechaEstimadaEvolucionBeneficio" Text="Fecha Estimada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput ID="diFechaEstimadaEvolucionBeneficio" runat="server" ValidationGroup="vgEvolucionBeneficio"
                                 TabIndex="2"   IsValidEmpty="true" />
                            </td>
                            <td>
                                <asp:Literal ID="ltFechaRealizadaEvolucionBeneficio" Text="Fecha Realizada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput TabIndex="5" ID="diFechaRealizadaEvolucionBeneficio" runat="server" ValidationGroup="vgEvolucionBeneficio"
                                    IsValidEmpty="false" />
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltCantidadEstimadaEvolucionBeneficio" Text="Cantidad Estimada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox TabIndex="3" runat="server" ID="txtCantidadEstimadaEvolucionBeneficio" InputType="PositiveFractional"></cc:NumericTextBox>
                                <asp:RequiredFieldValidator ID="rfvCantidadEstimadaEvolucionBeneficio" runat="server"
                                    ControlToValidate="txtCantidadEstimadaEvolucionBeneficio" ValidationGroup="vgEvolucionBeneficio"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCantidadEstimadaEvolucionBeneficio" runat="server"
                                    ControlToValidate="txtCantidadEstimadaEvolucionBeneficio" ValidationGroup="vgEvolucionBeneficio"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Literal ID="ltCantidadRealizadaEvolucionBeneficio" Text="Cantidad Realizada"
                                    runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox TabIndex="6" runat="server" ID="txtCantidadRealizadaEvolucionBeneficio" InputType="PositiveFractional"></cc:NumericTextBox>
                                <asp:RegularExpressionValidator ID="revCantidadRealizadaEvolucionBeneficio" runat="server"
                                    ControlToValidate="txtCantidadRealizadaEvolucionBeneficio" ValidationGroup="vgEvolucionBeneficio"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltPrecioUnitarioEstimadoEvolucionBeneficio" Text="Precio Unitario E."
                                    runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox TabIndex="4" runat="server" ID="txtPrecioUnitarioEstimadoEvolucionBeneficio"
                                    InputType="PositiveFractional"></cc:NumericTextBox>
                                <asp:RegularExpressionValidator ID="revPrecioUnitarioEstimadoEvolucionBeneficio"
                                    runat="server" ControlToValidate="txtPrecioUnitarioEstimadoEvolucionBeneficio"
                                    ValidationGroup="vgEvolucionBeneficio" Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                            <td>
                                <asp:Literal ID="ltPrecioUnitarioRealizadoEvolucionBeneficio" Text="Precio Unitario R."
                                    runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox TabIndex="7" runat="server" ID="txtPrecioUnitarioRealizadoEvolucionBeneficio"
                                    InputType="PositiveFractional"></cc:NumericTextBox>
                                <asp:RegularExpressionValidator ID="revPrecioUnitarioRealizadoEvolucionBeneficio"
                                    runat="server" ControlToValidate="txtPrecioUnitarioRealizadoEvolucionBeneficio"
                                    ValidationGroup="vgEvolucionBeneficio" Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltMontoEstimadoEvolucionBeneficio" Text="Monto E." runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Label ID="lblMontoEstimadoEvolucionBeneficio" runat="server" Text=""></asp:Label>
                            </td>
                            <td>
                                <asp:Literal ID="ltMontoRealizadoEvolucionBeneficio" Text="Monto R." runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:Label ID="lblMontoRealizadoEvolucionBeneficio" runat="server" Text=""></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewEvolucionBeneficio" Text="Agregar" OnClick="btSaveEvolucionBeneficio_Click"
                                    runat="server" ValidationGroup="vgEvolucionBeneficio" />
                                <asp:Button ID="btSaveEvolucionBeneficio" Text="Guardar" OnClick="btNewEvolucionBeneficio_Click"
                                    runat="server" ValidationGroup="vgEvolucionBeneficio" />
                                <asp:Button ID="btCancelEvolucionBeneficio" Text="Cerrar" OnClick="btCancelEvolucionBeneficio_Click"
                                    ValidationGroup="vgEvolucionBeneficioPopUp" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <br />
        <asp:UpdatePanel ID="upGridEvolucionesBeneficio" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridEvolucionesBeneficio" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridEvolucionesBeneficio_RowCommand"
                    AllowSorting="False" OnSorting="GridEvolucionesBeneficio_Sorting" OnPageIndexChanging="GridEvolucionesBeneficio_PageIndexChanging"
                    EmptyDataText="No hay EvolucionesBeneficio definidas" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Localización Geográfica" DataField="ClasificacionGeografica_Descripcion"
                            SortExpression="ClasificacionGeografica_Descripcion" />
                        <asp:BoundField HeaderText="Tipo" DataField="IndicadorEvolucionInstancia_Nombre"
                            SortExpression="IndicadorEvolucionInstancia_Nombre" />
                        <asp:BoundField HeaderText="Fecha E." DataField="FechaEstimada" SortExpression="FechaEstimada"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad E." DataField="CantidadEstimada" SortExpression="CantidadEstimada"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Precio Unitario E." DataField="PrecioUnitarioEstimado"
                            SortExpression="PrecioUnitarioEstimado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Monto E." DataField="MontoEstimadoCalc" SortExpression="MontoEstimadoCalc"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Fecha Real" DataField="FechaReal" SortExpression="FechaReal"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad Real" DataField="CantidadReal" SortExpression="CantidadReal"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Precio Unitario Real" DataField="PrecioUnitarioReal"
                            SortExpression="PrecioUnitarioReal" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Monto R." DataField="MontoRealizadoCalc" SortExpression="MontoRealizadoCalc"
                            ItemStyle-HorizontalAlign="Right" DataFormatString="{0:#,0.00}"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                    CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="90px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsEvolucionBeneficio" runat="server" DisplayMode="BulletList"
        ValidationGroup="vgEvolucionBeneficio" ShowSummary="False" ShowMessageBox="True">
    </asp:ValidationSummary>
    <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEvolucionesBeneficio" runat="server"
        CancelControlID="Button5" PopupDragHandleControlID="EvolucionesBeneficioPopUpDragHandle"
        PopupControlID="PopUpEvolucionesBeneficio" OkControlID="Button5" TargetControlID="Button5"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
