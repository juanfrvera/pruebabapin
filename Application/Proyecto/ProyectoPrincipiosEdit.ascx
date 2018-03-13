<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoPrincipiosEdit.ascx.cs" Inherits="UI.Web.Pages.ProyectoPrincipiosEdit" %>

<%--PANEL Necesidad a satisfacer --%>
<div class="CollapsiblePanelTab">
    <span id="spanNecesidadASatisfacer">
        <asp:Label ID="lblNecesidadASatisfacer" runat="server" Text="¿Cuál es la necesidad a satisfacer o la problemática a solucionar con el presente proyecto de inversión?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeNecesidadASatisfacer" runat="Server" TargetControlID="pnlNecesidadASatisfacer"
        Collapsed="True" ExpandControlID="lblNecesidadASatisfacer" CollapseControlID="lblNecesidadASatisfacer"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlNecesidadASatisfacer" runat="server">
<asp:UpdatePanel ID="upNecesidadASatisfacer" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtNecesidadASatisfacer" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revNecesidadASatisfacer" runat="server" ControlToValidate="txtNecesidadASatisfacer"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Objetivo del Proyecto --%>
<div class="CollapsiblePanelTab">
    <span id="span1">
        <asp:Label ID="lblObjetivoDelProyecto" runat="server" Text="¿Cuál es el objetivo del proyecto?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeObjetivoDelProyecto" runat="Server" TargetControlID="pnlObjetivoDelProyecto"
        Collapsed="True" ExpandControlID="lblObjetivoDelProyecto" CollapseControlID="lblObjetivoDelProyecto"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlObjetivoDelProyecto" runat="server">
<asp:UpdatePanel ID="upObjetivoDelProyecto" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtObjetivoDelProyecto" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revObjetivoDelProyecto" runat="server" ControlToValidate="txtObjetivoDelProyecto"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px" ErrorMessage="El Objetivo del proyecto no es válido">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL ProductoOServicio --%>
<div class="CollapsiblePanelTab">
    <span id="span2">
        <asp:Label ID="lblProductoOServicio" runat="server" Text="¿Cuál es el producto o servicio que brindará el proyecto una vez finalizado?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeProductoOServicio" runat="Server" TargetControlID="pnlProductoOServicio"
        Collapsed="True" ExpandControlID="lblProductoOServicio" CollapseControlID="lblProductoOServicio"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlProductoOServicio" runat="server">
<asp:UpdatePanel ID="upProductoOServicio" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtProductoOServicio" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revProductoOServicio" runat="server" ControlToValidate="txtProductoOServicio"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Alternativas --%>
<div class="CollapsiblePanelTab">
    <span id="span3">
        <asp:Label ID="lblAlternativas" runat="server" Text="¿Qué alternativas han sido consideradas para satisfacer la necesidad o resolver la problemática planteada?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeAlternativas" runat="Server" TargetControlID="pnlAlternativas"
        Collapsed="True" ExpandControlID="lblAlternativas" CollapseControlID="lblAlternativas"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlAlternativas" runat="server">
<asp:UpdatePanel ID="upAlternativas" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtAlternativas" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revAlternativas" runat="server" ControlToValidate="txtAlternativas"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Porque alternativa--%>
<div class="CollapsiblePanelTab">
    <span id="span4">
        <asp:Label ID="lblPorqueAlternativa" runat="server" Text="¿Por qué han seleccionado la alternativa elegida?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpePorqueAlternativa" runat="Server" TargetControlID="pnlPorqueAlternativa"
        Collapsed="True" ExpandControlID="lblPorqueAlternativa" CollapseControlID="lblPorqueAlternativa"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlPorqueAlternativa" runat="server">
<asp:UpdatePanel ID="upPorqueAlternativa" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtPorqueAlternativa" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revPorqueAlternativa" runat="server" ControlToValidate="txtPorqueAlternativa"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Descripcion Tecnica --%>
<div class="CollapsiblePanelTab">
    <span id="span5">
        <asp:Label ID="lblDescripcionTecnica" runat="server" Text="Realice una descripción técnica de la alternativa elegida."></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDescripcionTecnica" runat="Server" TargetControlID="pnlDescripcionTecnica"
        Collapsed="True" ExpandControlID="lblDescripcionTecnica" CollapseControlID="lblDescripcionTecnica"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlDescripcionTecnica" runat="server">
<asp:UpdatePanel ID="upDescripcionTecnica" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtDescripcionTecnica" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revDescripcionTecnica" runat="server" ControlToValidate="txtDescripcionTecnica"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Vida util --%>
<div class="CollapsiblePanelTab">
    <span id="span6">
        <asp:Label ID="lblVidaUtil" runat="server" Text="¿Cuál es la vida útil del principal bien de capital a incorporar en el marco del proyecto?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeVidaUtil" runat="Server" TargetControlID="pnlVidaUtil"
        Collapsed="True" ExpandControlID="lblVidaUtil" CollapseControlID="lblVidaUtil"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlVidaUtil" runat="server">
<asp:UpdatePanel ID="upVidaUtil" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="Indicar el período en años/meses/días/horas" ID="txtVidaUtil" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revVidaUtil" runat="server" ControlToValidate="txtVidaUtil"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Cobertura--%>
<div class="CollapsiblePanelTab">
    <span id="span7">
        <asp:Label ID="lblCobertura" runat="server" Text="¿Cuál será la cobertura territorial y poblacional del proyecto? ¿Quiénes y cuántos serán los beneficiarios directos e indirectos del proyecto?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCobertura" runat="Server" TargetControlID="pnlCobertura"
        Collapsed="True" ExpandControlID="lblCobertura" CollapseControlID="lblCobertura"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlCobertura" runat="server">
<asp:UpdatePanel ID="upCobertura" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td style="width:101px;">
                    Cobertura Territorial
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaTerritorial" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaTerritorial" runat="server" ControlToValidate="txtCoberturaTerritorial"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Cobertura Poblacional
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaPoblacional" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaPoblacional" runat="server" ControlToValidate="txtCoberturaPoblacional"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Cobertura Beneficiarios Directos
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaBeneficiariosDirectos" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaBeneficiariosDirectos" runat="server" ControlToValidate="txtCoberturaBeneficiariosDirectos"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Cobertura Beneficiarios Indirectos
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaBeneficiariosIndirectos" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaBeneficiariosIndirectos" runat="server" ControlToValidate="txtCoberturaBeneficiariosIndirectos"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Dificultades Riesgos --%>
<div class="CollapsiblePanelTab">
    <span id="span8">
        <asp:Label ID="lblDificultadesRiesgos" runat="server" Text="¿El proyecto presenta dificultades o riesgos significativos (sociales, institucionales, legales ambientales, etc.) pasibles de suceder durante su ejecución, puesta en funcionamiento o cierre/desmantelamiento?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDificultadesRiesgos" runat="Server" TargetControlID="pnlDificultadesRiesgos"
        Collapsed="True" ExpandControlID="lblDificultadesRiesgos" CollapseControlID="lblDificultadesRiesgos"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlDificultadesRiesgos" runat="server">
<asp:UpdatePanel ID="upDificultadesRiesgos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td style="width:101px;">
                    <asp:CheckBox ID="cbDificultadesRiesgos" Text="Si" AutoPostBack="true" Checked='<%# Bind("DificultadesRiesgos") %>' runat="server" Enabled="true" OnCheckedChanged="cbDificultadesRiesgos_CheckedChanged" />
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDificultadesRiesgosEnumeracion" placeholder="Enumérelos" Rows="6" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revDificultadesRiesgosEnumeracion" runat="server" ControlToValidate="txtDificultadesRiesgosEnumeracion"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Dimensiones Costos --%>
<div class="CollapsiblePanelTab">
    <span id="span9">
        <asp:Label ID="lblDimensionesCostos" runat="server" Text="¿Han sido dimensionados los costos de operación y mantenimiento que tendrá el proyecto cuando esté en funcionamiento?"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender9" runat="Server" TargetControlID="pnlDimensionesCostos"
        Collapsed="True" ExpandControlID="lblDimensionesCostos" CollapseControlID="lblDimensionesCostos"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlDimensionesCostos" runat="server">
<asp:UpdatePanel ID="upDimensionesCostos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:CheckBox ID="cbDimensionesCostosDimensionados" Text="Si" AutoPostBack="true" Checked='<%# Bind("DimensionesCostosDimensionados") %>' runat="server" Enabled="true" OnCheckedChanged="cbDimensionesCostosDimensionados_CheckedChanged" />
                </td>
                <td>
                    <asp:CheckBox ID="cbDimensionesCostosValidados" Text="¿Los costos fueron validados con la institución, autoridad o nivel de gobierno (nacional, provincial, municipal) que deberá afrontarlos?" AutoPostBack="true" Checked='<%# Bind("DimensionesCostosValidados") %>' runat="server" Enabled="false" OnCheckedChanged="cbDimensionesCostosValidados_CheckedChanged" />
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    <asp:Literal ID="ltDimensionesCostosEnte" Text="Mencione el nombre de la institución, autoridad o nivel de gobierno que ha realizado la autorización." runat="server"></asp:Literal>
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtDimensionesCostosEnte" Rows="6" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revDimensionesCostosEnte" runat="server" ControlToValidate="txtDimensionesCostosEnte"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>

<%--PANEL Requiere Intevencion --%>
<div class="CollapsiblePanelTab">
    <span id="span10">
        <asp:Label ID="lblRequiereIntevencion" runat="server" Text="¿El proyecto requiere intervención de una autoridad ambiental competente? "></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender10" runat="Server" TargetControlID="pnlRequiereIntevencion"
        Collapsed="True" ExpandControlID="lblRequiereIntevencion" CollapseControlID="lblRequiereIntevencion"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlRequiereIntevencion" runat="server">
<asp:UpdatePanel ID="upRequiereIntevencion" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:CheckBox ID="cbRequiereIntevencion" Text="Si" AutoPostBack="true" Checked='<%# Bind("RequiereIntevencion") %>' runat="server" Enabled="true" OnCheckedChanged="cbRequiereIntevencion_CheckedChanged" />
                </td>
                <td style="width:101px;">
                    Indique cuál es la autoridad ambiental competente
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRequiereIntevencionAutoridad" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Estado del trámite
                </td>
                <td colspan="2">
                    <asp:RadioButton ID="cbRequiereIntevencionEstadoAIniciar" GroupName="RequiereIntevencionEstado" runat="server" TextAlign="Left"  Text="A Iniciar" CssClass="" ValidationGroup="" />
                    <asp:RadioButton ID="cbRequiereIntevencionEstadoEnCurso" GroupName="RequiereIntevencionEstado" runat="server" TextAlign="Left"  Text="En Curso" CssClass="" ValidationGroup="" />
                    <asp:RadioButton ID="cbRequiereIntevencionEstadoTerminado" GroupName="RequiereIntevencionEstado" runat="server" TextAlign="Left" Text="Terminado" CssClass="" ValidationGroup="" />
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revRequiereIntevencionAutoridad" runat="server" ControlToValidate="txtRequiereIntevencionAutoridad"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
</asp:Panel>
				
							