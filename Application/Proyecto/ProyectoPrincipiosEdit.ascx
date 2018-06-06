<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoPrincipiosEdit.ascx.cs" Inherits="UI.Web.Pages.ProyectoPrincipiosEdit" %>

<asp:Panel ID="pnlInformacion" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                    <td>&nbsp;</td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="(No deben completar el formulario los proyectos en ejecución y el equipamiento básico de oficina)"></asp:Label>
                </td>
            </tr>
            <tr>
                    <td>&nbsp;</td>
            </tr>
        </table>
</asp:Panel>

<%--PANEL Necesidad a satisfacer --%>
<asp:UpdatePanel ID="upNecesidadASatisfacer" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="CollapsiblePanelTab">
            <span id="spanNecesidadASatisfacer">
                <asp:Label ID="lblNecesidadASatisfacer" runat="server" Text="1. ¿Cuál es la necesidad a satisfacer o la problemática a solucionar con el presente proyecto de inversión? (3000 caracteres)"></asp:Label>
                &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeNecesidadASatisfacer" runat="Server" TargetControlID="pnlNecesidadASatisfacer"
                Collapsed="True" ExpandControlID="lblNecesidadASatisfacer" CollapseControlID="lblNecesidadASatisfacer"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlNecesidadASatisfacer" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtNecesidadASatisfacer" MaxLength="3000" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Objetivo del Proyecto --%>
<asp:UpdatePanel ID="upObjetivoDelProyecto" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="CollapsiblePanelTab">
            <span id="span1">
                <asp:Label ID="lblObjetivoDelProyecto" runat="server" Text="2. ¿Cuál es el objetivo del proyecto? (1500 caracteres)"></asp:Label>
                &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeObjetivoDelProyecto" runat="Server" TargetControlID="pnlObjetivoDelProyecto"
                Collapsed="True" ExpandControlID="lblObjetivoDelProyecto" CollapseControlID="lblObjetivoDelProyecto"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlObjetivoDelProyecto" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObjetivoDelProyecto" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL ProductoOServicio --%>
<asp:UpdatePanel ID="upProductoOServicio" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="CollapsiblePanelTab">
        <span id="span2">
            <asp:Label ID="lblProductoOServicio" runat="server" Text="3. ¿Cuál es el producto o servicio que brindará el proyecto una vez finalizado? (1500 caracteres)"></asp:Label>
            &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpeProductoOServicio" runat="Server" TargetControlID="pnlProductoOServicio"
            Collapsed="True" ExpandControlID="lblProductoOServicio" CollapseControlID="lblProductoOServicio"
            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlProductoOServicio" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtProductoOServicio" MaxLength="1500"  Rows="6" TextMode="MultiLine"></asp:TextBox>
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
    </asp:Panel>
            </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Alternativas --%>
<asp:UpdatePanel ID="upAlternativas" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="CollapsiblePanelTab">
        <span id="span3">
            <asp:Label ID="lblAlternativas" runat="server" Text="4. ¿Qué alternativas han sido consideradas para satisfacer la necesidad o resolver la problemática planteada? (3000 caracteres)"></asp:Label>
            &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpeAlternativas" runat="Server" TargetControlID="pnlAlternativas"
            Collapsed="True" ExpandControlID="lblAlternativas" CollapseControlID="lblAlternativas"
            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlAlternativas" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtAlternativas" MaxLength="3000" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Porque alternativa--%>
<asp:UpdatePanel ID="upPorqueAlternativa" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="CollapsiblePanelTab">
            <span id="span4">
                <asp:Label ID="lblPorqueAlternativa" runat="server" Text="5. ¿Por qué han seleccionado la alternativa elegida? (3000 caracteres)"></asp:Label>
                &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpePorqueAlternativa" runat="Server" TargetControlID="pnlPorqueAlternativa"
                Collapsed="True" ExpandControlID="lblPorqueAlternativa" CollapseControlID="lblPorqueAlternativa"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlPorqueAlternativa" runat="server">

                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtPorqueAlternativa" MaxLength="3000" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Descripcion Tecnica --%>
<asp:UpdatePanel ID="upDescripcionTecnica" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="CollapsiblePanelTab">
    <span id="span5">
        <asp:Label ID="lblDescripcionTecnica" runat="server" Text="6. Realice una descripción técnica de la alternativa elegida. (3000 caracteres)"></asp:Label>
        &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDescripcionTecnica" runat="Server" TargetControlID="pnlDescripcionTecnica"
        Collapsed="True" ExpandControlID="lblDescripcionTecnica" CollapseControlID="lblDescripcionTecnica"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlDescripcionTecnica" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtDescripcionTecnica" MaxLength="3000" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
</asp:Panel>
            </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Vida util --%>
<asp:UpdatePanel ID="upVidaUtil" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="CollapsiblePanelTab">
    <span id="span6">
        <asp:Label ID="lblVidaUtil" runat="server" Text="7. ¿Cuál es la vida útil del principal bien de capital a incorporar en el marco del proyecto? (500 caracteres)"></asp:Label>
        &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeVidaUtil" runat="Server" TargetControlID="pnlVidaUtil"
        Collapsed="True" ExpandControlID="lblVidaUtil" CollapseControlID="lblVidaUtil"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlVidaUtil" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" placeholder="Indicar el período en años/meses/días/horas" ID="txtVidaUtil" MaxLength="500" Rows="6" TextMode="MultiLine"></asp:TextBox>
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
</asp:Panel>
            </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Cobertura--%>
<asp:UpdatePanel ID="upCobertura" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="CollapsiblePanelTab">
    <span id="span7">
        <asp:Label ID="lblCobertura" runat="server" Text="8. ¿Cuál será la cobertura territorial del proyecto? ¿Quiénes y cuántos serán los beneficiarios directos e indirectos del proyecto?"></asp:Label>
        &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="cpeCobertura" runat="Server" TargetControlID="pnlCobertura"
        Collapsed="True" ExpandControlID="lblCobertura" CollapseControlID="lblCobertura"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlCobertura" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td style="width:101px;">
                    Cobertura Territorial<br>(1500 caracteres)
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaTerritorial" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaTerritorial" runat="server" ControlToValidate="txtCoberturaTerritorial"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr runat="server" Visible="false">
                <td style="width:101px;">
                    Cobertura Poblacional<br>(255 caracteres)
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaPoblacional" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaPoblacional" runat="server" ControlToValidate="txtCoberturaPoblacional"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Beneficiarios Directos<br>(1500 caracteres)
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaBeneficiariosDirectos" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaBeneficiariosDirectos" runat="server" ControlToValidate="txtCoberturaBeneficiariosDirectos"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    Beneficiarios Indirectos<br>(1500 caracteres)
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtCoberturaBeneficiariosIndirectos" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revCoberturaBeneficiariosIndirectos" runat="server" ControlToValidate="txtCoberturaBeneficiariosIndirectos"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
</asp:Panel>
            </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Dificultades Riesgos --%>
<asp:UpdatePanel ID="upDificultadesRiesgos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="CollapsiblePanelTab">
            <span id="span8">
                <asp:Label ID="lblDificultadesRiesgos" runat="server" Text="9. ¿El proyecto presenta dificultades o riesgos significativos (sociales, institucionales, legales ambientales, etc.) pasibles de suceder durante su ejecución, puesta en funcionamiento o cierre/desmantelamiento? (3000 caracteres)"></asp:Label>
                &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeDificultadesRiesgos" runat="Server" TargetControlID="pnlDificultadesRiesgos"
                Collapsed="True" ExpandControlID="lblDificultadesRiesgos" CollapseControlID="lblDificultadesRiesgos"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlDificultadesRiesgos" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td style="width:101px;">
                            <asp:RadioButton ID="cbDificultadesRiesgos" GroupName="DificultadesRiesgos" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("DificultadesRiesgos") %>' Enabled="true" Text="Si" CssClass="" ValidationGroup="" OnCheckedChanged="cbDificultadesRiesgos_CheckedChanged"/>
                            <asp:RadioButton ID="cbDificultadesRiesgosNo" GroupName="DificultadesRiesgos" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("DificultadesRiesgos") %>' Enabled="true" Text="No" CssClass="" ValidationGroup=""  OnCheckedChanged="cbDificultadesRiesgos_CheckedChanged"/>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="txtDificultadesRiesgosEnumeracion" MaxLength="3000" placeholder="Enumérelos" Rows="6" TextMode="MultiLine" Enabled="false"></asp:TextBox>
                        </td>
                        <td Width="1px">
                            <asp:RegularExpressionValidator Enabled="false" Display = "Dynamic" ControlToValidate = "txtDificultadesRiesgosEnumeracion" ID="revDificultadesRiesgosEnumeracionMinLength" ValidationExpression = "^[\s\S]{8,}$" runat="server" Text="*" ValidationGroup="EditionProyectoPrincipios"></asp:RegularExpressionValidator>
                            <asp:RegularExpressionValidator Enabled="false" ID="revDificultadesRiesgosEnumeracion" runat="server" ControlToValidate="txtDificultadesRiesgosEnumeracion"
                                ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                            </asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvDificultadesRiesgosEnumeracion" Enabled="false" runat="server"
                                ControlToValidate="txtDificultadesRiesgosEnumeracion" Text="*" ValidationGroup="EditionProyectoPrincipios">
                            </asp:RequiredFieldValidator>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Dimensiones Costos --%>
<asp:UpdatePanel ID="upDimensionesCostos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
    <div class="CollapsiblePanelTab">
        <span id="span9">
            <asp:Label ID="lblDimensionesCostos" runat="server" Text="10. ¿Han sido dimensionados los costos de operación y mantenimiento que tendrá el proyecto cuando esté en funcionamiento?"></asp:Label>
            &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender9" runat="Server" TargetControlID="pnlDimensionesCostos"
            Collapsed="True" ExpandControlID="lblDimensionesCostos" CollapseControlID="lblDimensionesCostos"
            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlDimensionesCostos" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td colspan="2">
                        <asp:RadioButton ID="cbDimensionesCostosDimensionados" GroupName="DimensionesCostosDimensionados" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("DimensionesCostosDimensionados") %>' Enabled="true" Text="Si" CssClass="" ValidationGroup="" OnCheckedChanged="cbDimensionesCostosDimensionados_CheckedChanged"/>
                        <asp:RadioButton ID="cbDimensionesCostosDimensionadosNo" GroupName="DimensionesCostosDimensionados" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("DimensionesCostosDimensionados") %>' Enabled="true" Text="No" CssClass="" ValidationGroup=""  OnCheckedChanged="cbDimensionesCostosDimensionados_CheckedChanged"/>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Literal ID="lblDimensionesCostosValidados" Text="¿Los costos fueron validados con la institución, autoridad o nivel de gobierno (nacional, provincial, municipal) que deberá afrontarlos?" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RadioButtonList ID="rblDimensionesCostosValidados" RepeatDirection="Horizontal" RepeatLayout="Table" TextAlign="Left"  runat="server" ValidationGroup="EditionProyectoPrincipios" AutoPostBack="true" OnTextChanged="cbDimensionesCostosValidados_CheckedChanged" >
                            <asp:ListItem>Si</asp:ListItem>
                            <asp:ListItem>No</asp:ListItem>
                        </asp:RadioButtonList>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDimensionesCostosValidados" Enabled="false" runat="server" Text="*"
                            ControlToValidate="rblDimensionesCostosValidados" ValidationGroup="EditionProyectoPrincipios">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
                <tr>
                    <td colspan="2">
                        <asp:Literal ID="ltDimensionesCostosEnte" Text="Mencione el nombre de la institución, autoridad o nivel de gobierno que ha realizado la autorización. (500 caracteres)" runat="server"></asp:Literal>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtDimensionesCostosEnte" MaxLength="500" Rows="6" Enabled="false" TextMode="MultiLine"></asp:TextBox>
                    </td>
                    <td Width="1px">
                        <asp:RegularExpressionValidator ID="revDimensionesCostosEnte" runat="server" ControlToValidate="txtDimensionesCostosEnte"
                            ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                        <asp:RegularExpressionValidator ID="revDimensionesCostosEnteMinLength" Enabled="false" Display = "Dynamic" ControlToValidate = "txtDimensionesCostosEnte" ValidationExpression = "^[\s\S]{8,}$" runat="server" Text="*" ValidationGroup="EditionProyectoPrincipios"></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator ID="rfvDimensionesCostosEnte" Enabled="false" runat="server"
                            ControlToValidate="txtDimensionesCostosEnte" Text="*" ValidationGroup="EditionProyectoPrincipios">
                        </asp:RequiredFieldValidator>
                    </td>
                </tr>
            </table>
    </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Requiere Intevencion --%>
<asp:UpdatePanel ID="upRequiereIntevencion" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="CollapsiblePanelTab">
    <span id="span10">
        <asp:Label ID="lblRequiereIntevencion" runat="server" Text="11. ¿El proyecto requiere intervención de una autoridad ambiental competente? "></asp:Label>
        &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender10" runat="Server" TargetControlID="pnlRequiereIntevencion"
        Collapsed="True" ExpandControlID="lblRequiereIntevencion" CollapseControlID="lblRequiereIntevencion"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlRequiereIntevencion" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:RadioButton ID="cbRequiereIntevencion" GroupName="RequiereIntevencion" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("RequiereIntevencion") %>' Enabled="true" Text="Si" CssClass="" ValidationGroup="" OnCheckedChanged="cbRequiereIntevencion_CheckedChanged"/>
                    <asp:RadioButton ID="cbRequiereIntevencionNo" GroupName="RequiereIntevencion" runat="server" AutoPostBack="true"  TextAlign="Left"  Checked='<%# Bind("RequiereIntevencion") %>' Enabled="true" Text="No" CssClass="" ValidationGroup=""  OnCheckedChanged="cbRequiereIntevencionNo_CheckedChanged"/>
                </td>
                <td style="width:101px;">
                    Indique cuál es la autoridad ambiental competente<br>(500 caracteres)
                </td>
                <td>
                    <asp:TextBox runat="server" ID="txtRequiereIntevencionAutoridad" MaxLength="500" Enabled="false" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
                <td>
                    <asp:RegularExpressionValidator ID="revRequiereIntevencionAutoridad" runat="server" ControlToValidate="txtRequiereIntevencionAutoridad"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                    <asp:RequiredFieldValidator ID="rfvRequiereIntevencionAutoridad" runat="server"
                        ControlToValidate="txtRequiereIntevencionAutoridad" Text="*" ValidationGroup="EditionProyectoPrincipios">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
            <tr>
                <td style="width:101px;">
                    &nbsp;
                </td>
                <td>
                    &nbsp;
                </td>
                <td>
                    Estado del trámite &nbsp;
                    <asp:RadioButtonList ID="rblRequiereIntevencionEstado" Enabled="false" RepeatDirection="Horizontal" RepeatLayout="Flow" runat="server" ValidationGroup="EditionProyectoPrincipios" >
                        <asp:ListItem>A Iniciar</asp:ListItem>
                        <asp:ListItem>En Curso</asp:ListItem>
                        <asp:ListItem>Terminado</asp:ListItem>
                    </asp:RadioButtonList>
                </td>
                <td>
                    <asp:RequiredFieldValidator ID="rfvRequiereIntevencionEstado" runat="server" Text="*"
                        ControlToValidate="rblRequiereIntevencionEstado" ValidationGroup="EditionProyectoPrincipios">
                    </asp:RequiredFieldValidator>
                </td>
            </tr>
        </table>
</asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>				
<%--PANEL Relacion entre proyecto y metodología (12 Agregada)--%>
<asp:UpdatePanel ID="upRelacionProyMet" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <div class="CollapsiblePanelTab">
            <span id="span11">
                <asp:Label ID="lblRelacionProyMet" runat="server" Text="12. ¿Cuál es la relación entre el Proyecto y la Metodología Marco Lógico? (1500 caracteres)"></asp:Label>
                &nbsp;&nbsp;<!--img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" /-->
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeRelacionProyMet" runat="Server" TargetControlID="pnlRelacionProyMet"
                Collapsed="True" ExpandControlID="lblRelacionProyMet" CollapseControlID="lblRelacionProyMet"
                AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlRelacionProyMet" runat="server">
                <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtRelacionProyMet" MaxLength="1500" Rows="6" TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="revRelacionProyMet" runat="server" ControlToValidate="txtRelacionProyMet"
                                ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px" ErrorMessage="La relación no es válida">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<br/>
<%--PANEL Observaciones DNIP --%>
<asp:UpdatePanel ID="upObservacionesDNIP" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
<div class="CollapsiblePanelTab">
    <span id="span12">
        <asp:Label ID="lblObservacionesDNIP" runat="server" Text="Observaciones de la DNIP"></asp:Label>
        &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
    </span>
    <ajaxToolkit:CollapsiblePanelExtender ID="CollapsiblePanelExtender1" runat="Server" TargetControlID="pnlObservacionesDNIP"
        Collapsed="True" ExpandControlID="lblObservacionesDNIP" CollapseControlID="lblObservacionesDNIP"
        AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
</div>
<asp:Panel ID="pnlObservacionesDNIP" runat="server">

        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td>
                    <asp:TextBox runat="server" ID="txtObservacionesDNIP" Enabled="false" Rows="6" TextMode="MultiLine"></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td>
                    <asp:RegularExpressionValidator ID="revObservacionesDNIP" runat="server" ControlToValidate="txtObservacionesDNIP"
                        ValidationGroup="EditionProyectoPrincipios" Text="*" Width="1px" Height="1px">
                    </asp:RegularExpressionValidator>
                </td>
            </tr>
        </table>
</asp:Panel>						
            </ContentTemplate>
</asp:UpdatePanel>