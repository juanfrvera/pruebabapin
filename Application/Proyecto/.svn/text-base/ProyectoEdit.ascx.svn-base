<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ProyectoEdit.ascx.cs" Inherits="UI.Web.ProyectoEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeSelect" Src="~/Controls/WebControl_TreeSelect.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<style type="text/css">
    .tdLabelestado {
        width: 140px;
    }

    .tdLabel2 {
        width: 160px;
    }

    .filaInput {
        width: 350px;
    }

    .field_input {
        width: 350px;
    }

    .field_inputDropDown {
        width: 305px;
    }

    .filaValidator {
        width: 1px;
    }

    .style1 {
        width: 120px;
    }
</style>
<%--Datos Generales--%>

<asp:UpdatePanel ID="upDatosGenerales" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlDatosGenerales" runat="server" GroupingText="Datos Generales">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" cellspacing="5px" border="0" style="height: 160px">
                            <tr>
                                <td style="width: 158px">
                                    <asp:Literal ID="liTipoProyecto" Text="Tipo de Proyecto" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td style="width: 220px">
                                    <cc:ExtendedDropDownList ID="ddlTipoProyecto" runat="server" CssClass="field_input" SkinID="AnchoLibre" Width="125px" OnSelectedIndexChanged="ddlTipoProyecto_IndexChanged" AutoPostBack="true" TabIndex="1"></cc:ExtendedDropDownList>
                                    <asp:CheckBox ID="chkBorrador" runat="server" Text="Borrador" TabIndex="2"  />
                                </td>
                                <td class="filaValidator">&nbsp;
	                            <%--<asp:RequiredFieldValidator ID="rfvTipoProyecto" runat="server" ControlToValidate="ddlTipoProyecto" InitialValue="0"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>--%>
                                    <!-- Matias 20141014 - Tarea 157 -->
                                    <asp:RequiredFieldValidator ID="rfvTipoProyecto2" runat="server" ControlToValidate="ddlTipoProyecto" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue=""></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvTipoProyecto" runat="server" ControlToValidate="ddlTipoProyecto" ValidationGroup="EditionProyecto" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    <!-- FinMatias 20141014 - Tarea 157 -->
                                </td>

                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="liSAF" Text="SAF" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td style="width: 300px">
                                    <cc:ExtendedDropDownList ID="ddlSAF" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlSaf_IndexChanged" AutoPostBack="true" SkinID="AnchoLibre" Width="250px" TabIndex="3"></cc:ExtendedDropDownList>

                                    <%--   <uc:Autocomplete runat="server" ID="acSaf" 
                           WebServiceName="../Services/wsSaf.asmx" MinimumPrefixLength="3" ServiceMethod ="GetSimpleList"  
                            ShowOption="ActivesAndActualValue" RequiredValue="true" ValidationGroup="EditionProyecto" Width="245">
                                    </uc:Autocomplete>  --%>		        
                                </td>
                                <td class="filaValidator">&nbsp;
	                            <asp:RequiredFieldValidator ID="rfvSAF" runat="server" ControlToValidate="ddlSAF" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue="0"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="liPrograma" Text="Programa" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td>
                                    <cc:ExtendedDropDownList ID="ddlPrograma" runat="server" CssClass="field_input" OnSelectedIndexChanged="ddlPrograma_IndexChanged" AutoPostBack="true" Enabled="false" SkinID="AnchoLibre" Width="250px" TabIndex="4"></cc:ExtendedDropDownList>
                                </td>
                                <td class="filaValidator">&nbsp;
	                             <asp:RequiredFieldValidator ID="rfvPrograma2" runat="server" ControlToValidate="ddlPrograma" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue=""></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvPrograma" runat="server" ControlToValidate="ddlPrograma" ValidationGroup="EditionProyecto" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <asp:Literal ID="liSubPrograma" Text="Subprograma" runat="server"></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td>
                                    <cc:ExtendedDropDownList ID="ddlSubPrograma" runat="server" CssClass="field_input" Enabled="false" SkinID="AnchoLibre" Width="250px" TabIndex="5"></cc:ExtendedDropDownList>
                                </td>
                                <td class="filaValidator">&nbsp;
	                             <asp:RequiredFieldValidator ID="rfvSubPrograma" runat="server" ControlToValidate="ddlSubPrograma" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue="0"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvSubPrograma2" runat="server" ControlToValidate="ddlSubPrograma" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" InitialValue=""></asp:RequiredFieldValidator>

                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="width: 550px">
                        <asp:Panel ID="pnlOficinasYFuncionarios" runat="server" GroupingText="Oficinas y Funcionarios" Width="550px">
                            <table cellpadding="0" cellspacing="0px" border="0" style="height: 120px">
                                <tr>
                                    <td class="tdLabel">
                                        <asp:Literal ID="liIniciador" Text="Iniciador" runat="server"></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td class="filaInput">
                                        <%--<asp:DropDownList ID="ddlIniciador" runat="server" CssClass="field_input"  ></asp:DropDownList>--%>
                                        <%--Matias 20140702 - Tarea 150--%>
                                        <%--<uc:TreeOficinas runat="server" ID="toIniciador" Width ="250px" TabIndex ="6" OnValueChanged="toIniciador_ValueChanged" Autopostback="true"></uc:TreeOficinas>--%>
                                        <uc:TreeOficinas runat="server" ID="toIniciador" Width="250px" TabIndex="6" OnValueChanged="toIniciador_ValueChanged" Autopostback="true" SelectOption="OnlySelectedDefined" ShowOption="All"></uc:TreeOficinas>
                                        <%--FinMatias 20140702 - Tarea 150--%>
                                        <%--<asp:ImageButton ID="imgFuncionario1" runat ="server" ImageUrl="~/Images/funcionario.png" ToolTip="Funcionarios" OnClick="funcionario1_Click" />--%>
                                    </td>
                                    <td class="filaInput">
                                        <asp:ImageButton ID="imgFuncionario1" runat="server" ImageUrl="~/Images/funcionario.png" ToolTip="Funcionarios" OnClick="funcionario1_Click" TabIndex="7" />
                                    </td>
                                    <td class="filaValidator">&nbsp;
                                    <%--    <asp:RequiredFieldValidator ID="rfvIniciador" runat="server" ControlToValidate="ddlIniciador"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px"  InitialValue ="0" ></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <asp:Literal ID="liEjecutor" Text="Ejecutor" runat="server"></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td class="filaInput">
                                        <%--Matias 20140702 - Tarea 150--%>
                                        <%--<uc:TreeOficinas runat="server" ID="toEjecutor" Width ="250px" TabIndex ="8" OnValueChanged="toEjecutor_ValueChanged" Autopostback="true" ></uc:TreeOficinas>--%>
                                        <uc:TreeOficinas runat="server" ID="toEjecutor" Width="250px" TabIndex="8" OnValueChanged="toEjecutor_ValueChanged" Autopostback="true" SelectOption="OnlySelectedDefined" ShowOption="All"></uc:TreeOficinas>
                                        <%--FinMatias 20140702 - Tarea 150--%>
                                        <%--<asp:DropDownList ID="ddlEjecutor" runat="server" CssClass="field_input"  ></asp:DropDownList>--%>
                                    </td>
                                    <td class="filaInput">
                                        <asp:ImageButton ID="imgFuncionario2" runat="server" ImageUrl="~/Images/funcionario.png" ToolTip="Funcionarios" OnClick="funcionario2_Click" TabIndex="9" />
                                    </td>
                                    <td class="filaValidator">&nbsp;
                                       <%--   <asp:RequiredFieldValidator ID="rfvEjecutor" runat="server" ControlToValidate="ddlEjecutor"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px" InitialValue ="0" ></asp:RequiredFieldValidator> --%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <asp:Literal ID="liResponsable" Text="Responsable" runat="server"></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td class="filaInput">
                                        <%--Matias 20140702 - Tarea 150--%>
                                        <%--<uc:TreeOficinas runat="server" ID="toResponsable" Width ="250px" TabIndex ="10" OnValueChanged="toResponsable_ValueChanged" Autopostback="true" ></uc:TreeOficinas>--%>
                                        <uc:TreeOficinas runat="server" ID="toResponsable" Width="250px" TabIndex="10" OnValueChanged="toResponsable_ValueChanged" Autopostback="true" SelectOption="OnlySelectedDefined" ShowOption="All"></uc:TreeOficinas>
                                        <%--FinMatias 20140702 - Tarea 150--%>
                                        <%--<asp:DropDownList ID="ddlResponsable" runat="server" CssClass="field_input"  ></asp:DropDownList>--%>
                                    </td>
                                    <td class="filaInput">
                                        <asp:ImageButton ID="imgFuncionario3" runat="server" ImageUrl="~/Images/funcionario.png" ToolTip="Funcionarios" OnClick="funcionario3_Click" TabIndex="11" />
                                    </td>
                                    <td class="filaValidator">&nbsp;
                                        <%--<asp:RequiredFieldValidator ID="rfvResponsable" runat="server" ControlToValidate="ddlResponsable"  ValidationGroup="EditionProyecto"   Text="*" Width="1px" Height="1px"   InitialValue ="0" ></asp:RequiredFieldValidator>--%>
                                    </td>
                                </tr>
                                <tr>
                                    <td class="tdLabel">
                                        <asp:Literal ID="liSectorialista" Text="Sectorialista" runat="server"></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td class="filaInput">
                                        <asp:Label ID="lbSectorialista" runat="server"></asp:Label>
                                    </td>
                                    <td class="filaValidator">&nbsp;</td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td style="width: 110px">
                        <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal></td>

                    <td>
                        <asp:TextBox ID="txtDenominacion" runat="server" Rows="3" TextMode="MultiLine" Width="780px" TabIndex="13"></asp:TextBox>
                    </td>
                    <td>
                        <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                        <asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" ErrorMessage="La Denominación no es válida"></asp:RegularExpressionValidator>
                    </td>

                </tr>
            </table>
            <table cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td style="width: 180px"></td>
                    <td></td>
                    <td>
                        <asp:CheckBox ID="chkRequiereDictamen" runat="server" Enabled="false" Text="Requiere Dictamen" TabIndex="17" />
                    </td>
                    <td width="100px"></td>
                    <td></td>

                    <td>
                        <asp:CheckBox ID="chkActivo" runat="server" Enabled="false" Text="Activo" TabIndex="17" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="liProceso" Text="Proceso" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    <td>
                        <cc:ExtendedDropDownList ID="ddlProceso" runat="server" Enable="false" TabIndex="14"></cc:ExtendedDropDownList>
                    </td>
                    <td>&nbsp;
                
                    </td>
                    <td>
                        <asp:Literal ID="liPrioridad" runat="server" Text="Prioridad"></asp:Literal>
                    </td>
                    <td colspan="2">
                        <cc:ExtendedDropDownList ID="ddlPrioridad" runat="server" TabIndex="18"></cc:ExtendedDropDownList>
                        <asp:TextBox ID="txtPrioridad" runat="server" TabIndex="19"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revPrioridad" runat="server" ControlToValidate="txtPrioridad" ValidationGroup="EditionProyecto" Text="*" Width="1px" Height="1px" ErrorMessage="El valor de Prioridad no es válido"></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="liEstado" Text="Estado Financiero" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    <td>
                        <cc:ExtendedDropDownList ID="ddlEstado" runat="server" TabIndex="15"></cc:ExtendedDropDownList>
                    </td>
                    <td>&nbsp;<asp:RequiredFieldValidator ID="rfvEstado" runat="server" ControlToValidate="ddlEstado" ValidationGroup="EditionProyecto" InitialValue="0" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator></td>

                    <td>
                        <asp:Literal ID="liFinalidadFuncion" runat="server" Text="Finalidad Función"></asp:Literal>
                    </td>
                    <td colspan="3">
                        <uc:TreeFinalidadFuncion runat="server" ID="toFinalidadFuncion" TabIndex="20" SelectOption="OnlySelectedDefined"
                            ShowOption="ActivesAndActualValue" RequiredValue="true" ValidationGroup="EditionFinalidadFuncion"
                            Handler="../Handlers/FinalidadFuncionHandler.ashx"></uc:TreeFinalidadFuncion>
                    </td>

                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="liModalidadContratacion" Text="Modalidad de Contratación" runat="server"></asp:Literal></td>
                    <td>&nbsp;</td>
                    <td colspan="6" align="left">
                        <cc:ExtendedDropDownList ID="ddlModalidadContratacion" runat="server" TabIndex="16"></cc:ExtendedDropDownList>
                    </td>
                </tr>
            </table>
        </asp:Panel>
        <asp:Panel ID="pnlPlanEditar" runat="server" GroupingText="Plan">
            <table width="100%">
                <tr>
                    <td>
                        <asp:LinkButton ID="lnkPlan" runat="server" Text="Editar Plan" OnClick="btAgregarProyectoPlan_Click" TabIndex="21"></asp:LinkButton>
                    </td>
                    <td>
                        <b>
                            <asp:Label ID="lbPlan" runat="server"></asp:Label></b>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:UpdatePanel ID="upOtrosDatos" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="Panel3" runat="server">
            <%--Situacion Actual--%>

            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td class="legend" style="color: #0099ff; font-weight: bold;">
                        <%--<asp:LinkButton  ID="liSituacionActual"  runat = "server" Text ="Situacion Actual" ></asp:LinkButton>--%>
                        <div style="cursor: hand; width: 125px">
                            <asp:Label ID="lblSituacionActual" runat="server" Text="Situación Actual"></asp:Label>&nbsp;
                            <asp:Image ID="imgCollapsiblePanel" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeSituacionActual" runat="Server"
                            TargetControlID="pnlSituacionActual"
                            Collapsed="True"
                            ExpandControlID="lblSituacionActual"
                            CollapseControlID="lblSituacionActual"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlSituacionActual" runat="server">
                            <asp:TextBox ID="txtSituacionActual" runat="server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <%--Descripcion--%>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td class="legend" style="color: #0099ff; font-weight: bold;">
                        <div style="cursor: hand; width: 195px">
                            <asp:Label ID="lblDescripcion" runat="server" Text="Descripción Técnica"></asp:Label>&nbsp;
                            <asp:Image ID="Image1" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeDescripcion" runat="Server"
                            TargetControlID="pnlDescripcion"
                            Collapsed="True"
                            ExpandControlID="lblDescripcion"
                            CollapseControlID="lblDescripcion"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDescripcion" runat="server">
                            <asp:TextBox ID="txtDescripcion" runat="server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
            <%--Observaciones--%>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td td class="legend" style="color: #0099ff; font-weight: bold;">
                        <div style="cursor: hand; width: 115px">
                            <asp:Label ID="lblObservaciones" runat="server" Text="Observaciones"></asp:Label>&nbsp;
                            <asp:Image ID="Image5" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeObservaciones" runat="Server"
                            TargetControlID="pnlObservaciones"
                            Collapsed="True"
                            ExpandControlID="lblObservaciones"
                            CollapseControlID="lblObservaciones"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlObservaciones" runat="server">
                            <asp:TextBox ID="txtObservaciones" runat="server" Rows="6" TextMode="MultiLine"></asp:TextBox>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<%--Origen del Financiamiento--%>
<asp:UpdatePanel ID="upOrigenFinanciamiento" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlOrigenFinanciamientoGral" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td class="legend" style="color: #0099ff; font-weight: bold;">
                        <div style="cursor: hand; width: 190px">
                            <asp:Label ID="lblOrigenDelFinanciamiento" runat="server" Text="Origen del Financiamiento"></asp:Label>&nbsp;
                            <asp:Image ID="Image2" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeOrigenDelFinanciamiento" runat="Server"
                            TargetControlID="pnlOrigenDelFinanciamiento"
                            Collapsed="True"
                            ExpandControlID="lblOrigenDelFinanciamiento"
                            CollapseControlID="lblOrigenDelFinanciamiento"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlOrigenDelFinanciamiento" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btAgregarOrigenFinanciamiento" runat="server" Text="Agregar Prestamo" OnClick="btProyectoOrigenFinanciamienta_Click" />
                                        <asp:Button ID="btAgregarTransferencia" runat="server" Text="Agregar Transferencia" OnClick="btAgregarTransferencia_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="upGridOrigenFinanciamiento" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GridOrigenFinanciamiento" runat="server"
                                                    AutoGenerateColumns="False" DataKeyNames="ID"
                                                    AllowPaging="True"
                                                    OnRowCommand="GridOrigenFinanciamiento_RowCommand"
                                                    AllowSorting="True"
                                                    OnSorting="GridOrigenFinanciamiento_Sorting"
                                                    OnPageIndexChanging="GridOrigenFinanciamiento_PageIndexChanging"
                                                    EmptyDataText="No hay Origenes de Financiamiento definidos"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="Tipo" DataField="ProyectoOrigenFinancianmientoTipo_Nombre" SortExpression="ProyectoOrigenFinancianmientoTipo_Nombre" HeaderStyle-Width="20%" />
                                                        <asp:BoundField HeaderText="Código" DataField="OrigenCodigoCompleto" SortExpression="OrigenCodigoCompleto" HeaderStyle-Width="6%" />
                                                        <asp:BoundField HeaderText="Denominación" DataField="OrigenDenominacion" SortExpression="OrigenDenominacion" HeaderStyle-Width="67%" />
                                                        <asp:TemplateField HeaderStyle-Width="7%">
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                <%--                                                                &nbsp;
                                                                <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />--%>
                                                                <%--     &nbsp;--%>
                                                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' CssClass='<%# EnableDatosGenerales==true?"":"ibDisable"  %>' Enabled='<%# EnableDatosGenerales %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                            </ItemTemplate>
                                                            <ItemStyle HorizontalAlign="Right" />
                                                        </asp:TemplateField>
                                                    </Columns>
                                                </asp:GridView>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<%--Proyectos Relacionados--%>
<asp:UpdatePanel ID="upProyectosRelacionados" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlProyectosRelacionadosGral" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td class="legend" style="color: #0099ff; font-weight: bold">
                        <div style="cursor: hand; width: 175px">
                            <asp:Label ID="lblProyectosRelacionados" runat="server" Text="Proyectos Relacionados"></asp:Label>&nbsp;
                            <asp:Image ID="Image3" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeProyectosRelacionados" runat="Server"
                            TargetControlID="pnlProyectosRelacionados"
                            Collapsed="True"
                            ExpandControlID="lblProyectosRelacionados"
                            CollapseControlID="lblProyectosRelacionados"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlProyectosRelacionados" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btAgregarProyectosRelacionados" runat="server"
                                            Text="Agregar" OnClick="btAgregarProyectosRelacionados_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="upGridProyectosRelacionados" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <asp:GridView ID="GridProyectosRelacionados" runat="server"
                                                    AutoGenerateColumns="False" DataKeyNames="ID"
                                                    AllowPaging="True"
                                                    OnRowCommand="GridProyectosRelacionados_RowCommand"
                                                    AllowSorting="True"
                                                    OnSorting="GridProyectosRelacionados_Sorting"
                                                    OnPageIndexChanging="GridProyectosRelacionados_PageIndexChanging"
                                                    EmptyDataText="No hay Proyectos Relacionados definidas"
                                                    Width="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText="BAPIN" DataField="ProyectoRelacionado_Codigo" SortExpression="ProyectoRelacionado_Codigo" />
                                                        <asp:BoundField HeaderText="Denominación" DataField="ProyectoRelacionado_ProyectoDenominacion" SortExpression="ProyectoRelacionado_ProyectoDenominacion" />
                                                        <asp:BoundField HeaderText="Tipo de Relación" DataField="ProyectoRelacionTipo_Nombre" SortExpression="ProyectoRelacionTipo_Nombre" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                &nbsp;
                                                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CssClass='<%# EnableDatosGenerales==true?"":"ibDisable"  %>' Enabled='<%# EnableDatosGenerales %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                                &nbsp;
                                                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' CssClass='<%# EnableDatosGenerales==true?"":"ibDisable"  %>' Enabled='<%# EnableDatosGenerales %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
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
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<%--Demoras--%>
<asp:UpdatePanel ID="upDemoras" runat="server" UpdateMode="Conditional">
    <ContentTemplate>
        <asp:Panel ID="pnlDemorasGral" runat="server">
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td class="legend" style="color: #0099ff; font-weight: bold;">
                        <div style="cursor: hand; width: 75px">
                            <asp:Label ID="lblDemoras" runat="server" Text="Demoras"></asp:Label>&nbsp;
                            <asp:Image ID="Image4" runat="server" src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeDemoras" runat="Server"
                            TargetControlID="pnlDemoras"
                            Collapsed="True"
                            ExpandControlID="lblDemoras"
                            CollapseControlID="lblDemoras"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlDemoras" runat="server">
                            <table width="100%">
                                <tr>
                                    <td align="right">
                                        <asp:Button ID="btDemoras" runat="server" Text="Agregar"
                                            OnClick="btDemoras_Click" />
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="upGridProyectoDemora" runat="server" UpdateMode="Conditional">
                                            <ContentTemplate>
                                                <div style="overflow: auto; width: 978px; height: 250px">
                                                    <%-- Matias 201201117 - Tarea 25 --%>
                                                    <%-- Matias 201201117 - Tarea 25 - asp: AllowPaging="False" y AllowSorting="False"--%>
                                                    <asp:GridView ID="GridProyectoDemora" runat="server"
                                                        AutoGenerateColumns="False" DataKeyNames="ID"
                                                        AllowPaging="False"
                                                        OnRowCommand="GridProyectoDemora_RowCommand"
                                                        AllowSorting="True"
                                                        OnSorting="GridProyectoDemora_Sorting"
                                                        OnPageIndexChanging="GridProyectoDemora_PageIndexChanging"
                                                        EmptyDataText="No hay Demoras definidas"
                                                        Width="100%">
                                                        <Columns>
                                                            <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha" HeaderStyle-Width="25%" DataFormatString="{0:dd/MM/yyyy}" />
                                                            <asp:BoundField HeaderText="Justificación" DataField="Justificacion" SortExpression="Justificacion" HeaderStyle-Width="60%" />

                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" CommandName='<%# Command.EDIT %>' CssClass='<%# EnableDatosGenerales==true?"":"ibDisable"  %>' Enabled='<%# EnableDatosGenerales %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                                    &nbsp;
                                                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' CssClass='<%# EnableDatosGenerales==true?"":"ibDisable"  %>' Enabled='<%# EnableDatosGenerales %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                                                </ItemTemplate>
                                                                <ItemStyle Width="150px" HorizontalAlign="Right" />
                                                            </asp:TemplateField>
                                                        </Columns>
                                                    </asp:GridView>
                                                </div>
                                                <%-- Matias 20120117 - Tarea 25 --%>
                                            </ContentTemplate>
                                        </asp:UpdatePanel>
                                    </td>
                                </tr>
                            </table>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>
<%--PopUps--%>

<%--PopUp Oficina--%>
<%--<asp:Panel ID="PopUpOficina" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="OficinaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpOficina" runat="server" Text="Oficinas" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnOficina" runat="server">
        <asp:UpdatePanel ID="upOficinaPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px">
                                    </td>
                                    <td>
                                        Jurisdicción:
                                    </td>
                                     
                                </tr>
                                <tr>
                                    <td>
                                         
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 62px">
                                    </td>
                                    <td>
                                        Oficina:
                                    </td>
                                    <td>
                                        <asp:DropDownList ID="ddlOficinaPopUp" runat="server" Width ="200px"  SkinID ="AnchoLibre" ></asp:DropDownList>
                                        <asp:RequiredFieldValidator ID="rfvOficinaPopUp" runat = "server" ValidationGroup ="vgOficina"  ControlToValidate ="ddlOficinaPopUp" Text="*" InitialValue ="0"></asp:RequiredFieldValidator>
                                    </td>        
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveOficina" Text="Aceptar" OnClick="btSaveOficina_Click" runat="server" ValidationGroup="vgOficina" />
                            <asp:Button ID="btCancelOficina" Text="Cerrar" OnClick="btCancelOficina_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderOficina" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="OficinaPopUpDragHandle" PopupControlID="PopUpOficina"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>--%>

<%--PopUp Funcionario Iniciador--%>
<asp:Panel ID="PopUpFuncionariosIniciador" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FuncionariosIniciadorPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">

                <th align="center" height="10">
                    <asp:Label ID="headerPopUpFuncionariosIniciador" runat="server" Text="Funcionarios" />
                </th>

            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFuncionariosIniciador" DefaultButton="btCancelFuncionariosIniciador" runat="server">
        <asp:UpdatePanel ID="upFuncionariosIniciadorPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel2" runat="server" ScrollBars="Vertical" Height="400px">
                                <asp:DataList ID="dlFuncionarioIniciador" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Usuario_ApellidoYNombre") %>' runat="server" />
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbTelefono" runat="server" Text='<%# Bind("Usuario_TelefonoLaboral") %>'></asp:Label>
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbMail" runat="server" Text='<%# Bind("Usuario_MailLaboral") %>'></asp:Label>
                                        <asp:HiddenField ID="hdValue" Value='<%# Bind("IdUsuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelFuncionariosIniciador" Text="Cerrar" OnClick="btCancelFuncionariosIniciador_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFuncionariosIniciador" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="FuncionariosIniciadorPopUpDragHandle" PopupControlID="PopUpFuncionariosIniciador"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Funcionarios Ejecutor--%>
<asp:Panel ID="PopUpFuncionariosEjecutor" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FuncionariosEjecutorPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">

                <th align="center" height="10">
                    <asp:Label ID="headerPopUpFuncionariosEjecutor" runat="server" Text="Funcionarios" />
                </th>

            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFuncionariosEjecutor" DefaultButton="btCancelFuncionariosEjecutor" runat="server">
        <asp:UpdatePanel ID="upFuncionariosEjecutorPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnldlFuncionario" runat="server" ScrollBars="Vertical" Height="400px">
                                <asp:DataList ID="dlFuncionarioEjecutor" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Usuario_ApellidoYNombre") %>' runat="server" />
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbTelefono" runat="server" Text='<%# Bind("Usuario_TelefonoLaboral") %>'></asp:Label>
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbMail" runat="server" Text='<%# Bind("Usuario_MailLaboral") %>'></asp:Label>
                                        <asp:HiddenField ID="hdValue" Value='<%# Bind("IdUsuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelFuncionariosEjecutor" Text="Cerrar" OnClick="btCancelFuncionariosEjecutor_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFuncionariosEjecutor" runat="server" CancelControlID="Button1"
        PopupDragHandleControlID="FuncionariosEjecutorPopUpDragHandle" PopupControlID="PopUpFuncionariosEjecutor"
        OkControlID="Button1" TargetControlID="Button1" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Funcionarios Responsable--%>
<asp:Panel ID="PopUpFuncionariosResponsable" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FuncionariosResponsablePopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">

                <th align="center" height="10">
                    <asp:Label ID="headerPopUpFuncionariosResponsable" runat="server" Text="Funcionarios" />
                </th>

            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFuncionariosResponsable" DefaultButton="btCancelFuncionariosResponsable" runat="server">
        <asp:UpdatePanel ID="upFuncionariosResponsablePopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <%--<tr>
                        <td style="width: 62px">
                        </td>
                        <td>
                            <asp:Literal ID="ltOficina" Text="Oficina:" runat="server"></asp:Literal>
                        </td>
                        <td>
                            <uc:TreeOficinas runat="server" ID="tsOficinaFuncionariosResponsable"   ></uc:TreeOficinas>
                        </td> 
                    </tr>  --%>
                    <tr>

                        <td>
                            <asp:Panel ID="Panel1" runat="server" ScrollBars="Vertical" Height="400px">
                                <asp:DataList ID="dlFuncionarioResponsable" runat="server" RepeatColumns="1" RepeatDirection="Horizontal" Width="100%">
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Usuario_ApellidoYNombre") %>' runat="server" />
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbTelefono" runat="server" Text='<%# Bind("Usuario_TelefonoLaboral") %>'></asp:Label>
                                        &nbsp;
                                        |
                                        &nbsp;
                                        <asp:Label ID="lbMail" runat="server" Text='<%# Bind("Usuario_MailLaboral") %>'></asp:Label>
                                        <asp:HiddenField ID="hdValue" Value='<%# Bind("IdUsuario") %>' runat="server" />
                                    </ItemTemplate>
                                </asp:DataList>
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelFuncionariosResponsable" Text="Cerrar" OnClick="btCancelFuncionariosResponsable_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button8" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFuncionariosResponsable" runat="server" CancelControlID="Button8"
        PopupDragHandleControlID="FuncionariosResponsablePopUpDragHandle" PopupControlID="PopUpFuncionariosResponsable"
        OkControlID="Button8" TargetControlID="Button8" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Finalidad Funcion--%>
<%--<asp:Panel ID="PopUpFinalidadFuncion" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FinalidadFuncionPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpFinalidadFuncion" runat="server" Text="Finalidad Funcion" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFinalidadFuncion" runat="server">
        <asp:UpdatePanel ID="upFinalidadFuncionPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" style=" text-align:center">
                    <tr>
                        <td>
                            <asp:UpdatePanel ID="upFinalidadFuncion" runat ="server" UpdateMode ="Conditional"  >
                                <ContentTemplate>
                                      <uc:TreeFinalidadFuncion runat="server" ID="toFinalidadFuncion" ></uc:TreeFinalidadFuncion> 
                                </ContentTemplate>
                            </asp:UpdatePanel>
                            
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveFinalidadFuncion" Text="Aceptar" OnClick="btSaveFinalidadFuncion_Click" runat="server" ValidationGroup="vgFinalidadFuncion" />
                            <asp:Button ID="btCancelFinalidadFuncion" Text="Cerrar" OnClick="btCancelFinalidadFuncion_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFinalidadFuncion" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="FinalidadFuncionPopUpDragHandle" PopupControlID="PopUpFinalidadFuncion"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>--%>
<%--PopUp Plan--%>
<asp:Panel ID="PopUpPlan" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="PlanPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpPlan" runat="server" Text="Plan" />
                </th>

            </tr>
        </table>
    </asp:Panel>
    <asp:Panel DefaultButton="btAgregarPlan" ID="pnPlan" runat="server">
        <asp:UpdatePanel ID="upPlanPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Panel ID="pnlPlanPopUp" runat="server" GroupingText="Agregar">
                    <table width="100%">
                        <tr>
                            <td style="width: 33%">
                                <div>
                                    <asp:Literal ID="liTipo" runat="server" Text="Tipo"></asp:Literal>
                                </div>
                                <div>
                                    <cc:ExtendedDropDownList ID="ddlTipoPopUp" runat="server" OnSelectedIndexChanged="ddlTipoPupUp_SelectedIndexChanged" AutoPostBack="true"></cc:ExtendedDropDownList>
                                </div>
                                <div class="filaValidator">
                                    <asp:RequiredFieldValidator ID="rfvTipoPopoUp" runat="server" InitialValue="0" ControlToValidate="ddlTipoPopUp" ValidationGroup="PlanPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </div>
                            </td>

                            <td style="width: 33%">
                                <div>
                                    <asp:Literal ID="liPeriodo" runat="server" Text="Período"></asp:Literal>
                                </div>
                                <div>
                                    <cc:ExtendedDropDownList ID="ddlPeriodoPopUp" runat="server" Enabled="false"
                                        OnSelectedIndexChanged="ddlPeriodoPopUp_SelectedIndexChanged" AutoPostBack="true">
                                    </cc:ExtendedDropDownList>
                                </div>
                                <div class="filaValidator">
                                    <asp:RequiredFieldValidator ID="rfvPeriodoPopUp" runat="server" InitialValue="0" ControlToValidate="ddlPeriodoPopUp" ValidationGroup="PlanPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvPeriodoPopUp2" runat="server" InitialValue="" ControlToValidate="ddlPeriodoPopUp" ValidationGroup="PlanPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                            <td style="width: 33%">
                                <div>
                                    <asp:Literal ID="liVersion" runat="server" Text="Versión"></asp:Literal>
                                </div>
                                <div>
                                    <cc:ExtendedDropDownList ID="ddlVersionPopUp" runat="server" Enabled="false"></cc:ExtendedDropDownList>
                                </div>
                                <div class="filaValidator">
                                    <asp:RequiredFieldValidator ID="rfvVersionPopUp" runat="server" InitialValue="0" ControlToValidate="ddlVersionPopUp" ValidationGroup="PlanPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                    <asp:RequiredFieldValidator ID="rfvVersionPopUp2" runat="server" InitialValue="" ControlToValidate="ddlVersionPopUp" ValidationGroup="PlanPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </div>
                            </td>
                        </tr>
                        <tr>
                            <td></td>
                            <td></td>
                            <td align="right">
                                <asp:Button ID="btAgregarPlan" runat="server" Text="Agregar" ValidationGroup="PlanPopUp"
                                    OnClick="btNewProyectoPlan_Click" />
                                <%-- <asp:Button ID ="btGuardarPlan" runat = "server" Text ="Guardar"  ValidationGroup="PlanPopUp"
                                    onclick="btSaveProyectoPlan_Click"  />--%>
                                <asp:Button ID="btCancelarPlan" runat="server" Text="Cerrar"
                                    OnClick="btCancelProyectoPlan_Click" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlPlan" runat="server" Height="350px" ScrollBars="Vertical">
                                <asp:GridView ID="gridPlanPopUp" runat="server"
                                    AutoGenerateColumns="False" DataKeyNames="ID"
                                    AllowPaging="False"
                                    OnRowCommand="gridPlanPopUp_RowCommand"
                                    AllowSorting="True"
                                    OnSorting="gridPlanPopUp_Sorting"
                                    OnPageIndexChanging="gridPlanPopUp_PageIndexChanging"
                                    EmptyDataText=""
                                    Width="98%">
                                    <Columns>
                                        <asp:BoundField HeaderText="Tipo" DataField="PlanTipo_Nombre" SortExpression="PlanTipo_Nombre" />
                                        <asp:BoundField HeaderText="Periodo" DataField="PlanPeriodo_Periodo" SortExpression="PlanPeriodo_Periodo" />
                                        <asp:BoundField HeaderText="Version" DataField="PlanVersion_Nombre" SortExpression="PlanVersion_Nombre" />
                                        <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha " DataFormatString="{0:dd/MM/yyyy}" ControlStyle-Width="50px" />
                                        <asp:TemplateField>
                                            <HeaderTemplate>
                                            </HeaderTemplate>
                                            <ItemTemplate>
                                                &nbsp;
                                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar" CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' Enabled='<%#Eval("Activo") %>' CausesValidation="false" />
                                            </ItemTemplate>
                                            <ItemStyle Width="50px" HorizontalAlign="Right" />
                                        </asp:TemplateField>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td></td>
                    </tr>
                </table>
                <asp:ValidationSummary ID="vsPlanPopUp" runat="server" DisplayMode="BulletList" ValidationGroup="PlanPopUp" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>

                <%--<table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSavePlan" Text="Aceptar" OnClick="btSavePlan_Click" runat="server" ValidationGroup="vgPlan" />
                            <asp:Button ID="btNewPlan" Text="Aceptar y Crear Nuevo" OnClick="btNewPlan_Click" runat="server"
                                ValidationGroup="vgPlan" />
                            <asp:Button ID="btCancelPlan" Text="Cerrar" OnClick="btCancelPlan_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>--%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderPlan" runat="server" CancelControlID="Button4"
        PopupDragHandleControlID="PlanPopUpDragHandle" PopupControlID="PopUpPlan"
        OkControlID="Button4" TargetControlID="Button4" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Origen Financiamiento--%>
<asp:Panel ID="PopUpOrigenFinanciamiento" runat="server" Width="600px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="OrigenFinanciamientoPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpOrigenFinanciamiento" runat="server" Text="Origen Financiamiento" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnOrigenFinanciamiento" DefaultButton="btSaveOrigenFinanciamiento" Style="padding: 10px" runat="server">
        <asp:UpdatePanel ID="upOrigenFinanciamientoPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td width="100px">
                            <asp:Literal ID="liCodigoOrigenFinanciamiento" runat="server" Text="Código"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtCodigoOrigenFinanciamiento" runat="server"></asp:TextBox>
                            <asp:RequiredFieldValidator ID="rfvCodigoOrigenFinanciamiento" runat="server" ControlToValidate="txtCodigoOrigenFinanciamiento" ValidationGroup="OrigenFinanciamientoPopUp" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                            <asp:Button ID="btSearchOrigenFinanciamiento" runat="server" Text="Buscar"
                                OnClick="btSearchOrigenFinanciamiento_Click" Style="width: 61px" />
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="liNombreOrigenFinanciamiento" runat="server" Text="Nombre"></asp:Literal>
                        </td>
                        <td>
                            <asp:Label ID="lblNombreOrigenFinanciamiento" runat="server"></asp:Label>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveOrigenFinanciamiento" Text="Aceptar" OnClick="btSaveProyectoOrigenFinanciamiento_Click" runat="server" ValidationGroup="OrigenFinanciamientoPopUp" />
                            <asp:Button ID="btNewOrigenFinanciamiento" Text="Aceptar y Crear Nuevo" OnClick="btNewProyectoOrigenFinanciamiento_Click" runat="server"
                                ValidationGroup="OrigenFinanciamientoPopUp" />
                            <asp:Button ID="btCancelOrigenFinanciamiento" Text="Cerrar" OnClick="btCancelProyectoOrigenFinanciamiento_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsOrigenFinanciamientoPopUp" runat="server" DisplayMode="BulletList" ValidationGroup="OrigenFinanciamientoPopUp" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderOrigenFinanciamiento" runat="server" CancelControlID="Button5"
        PopupDragHandleControlID="OrigenFinanciamientoPopUpDragHandle" PopupControlID="PopUpOrigenFinanciamiento"
        OkControlID="Button5" TargetControlID="Button5" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Proyectos Relacionados--%>
<asp:Panel ID="PopUpProyectosRelacionados" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectosRelacionadosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpProyectosRelacionados" runat="server" Text="Proyectos Relacionados" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectosRelacionados" DefaultButton="btSaveProyectoRelacion" runat="server">
        <asp:UpdatePanel ID="upProyectosRelacionadosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liBapinProyectosRelacionados" runat="server" Text="BAPIN"></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID="txtBapinProyectosRelacionados" Type="text" runat="server" OnTextChanged="txtBapinProyectosRelacionados_TextChanged" AutoPostBack="true"></asp:TextBox>
                                    </td>
                                    <td>
                                        <div class="filaValidator">
                                            <asp:RequiredFieldValidator ID="rfvBapin" runat="server" ControlToValidate="txtBapinProyectosRelacionados" ValidationGroup="vgProyectosRelacion" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revBapin" runat="server" ControlToValidate="txtBapinProyectosRelacionados" ValidationGroup="vgProyectosRelacion" Text="*" Width="1px" Height="1px" ErrorMessage="El código BAPIN no es válido"></asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liTipoRelacionProyectoRelacionado" runat="server" Text="Tipo de Relación"></asp:Literal>
                                    </td>
                                    <td>
                                        <cc:ExtendedDropDownList ID="ddlTipoRelacionProyectoRelacionado" runat="server"></cc:ExtendedDropDownList>
                                    </td>
                                    <td>
                                        <div class="filaValidator">
                                            <asp:RequiredFieldValidator ID="rfvTipoRelacionProyectoRelacionado" runat="server" InitialValue="0" ControlToValidate="ddlTipoRelacionProyectoRelacionado" ValidationGroup="vgProyectosRelacion" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <table>
                                <tr>
                                    <td>
                                        <b>
                                            <asp:Literal ID="liDenominacionProyectosRelacionados" runat="server" Text="Denominación"></asp:Literal>
                                        </b>
                                    </td>
                                    <td>
                                        <asp:Label ID="lbDenominacionProyectosRelacionados" runat="server"></asp:Label>
                                    </td>
                                </tr>
                            </table>

                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveProyectoRelacion" Text="Aceptar" OnClick="btSaveProyectoRelacion_Click" runat="server" ValidationGroup="vgProyectosRelacion" />
                            <asp:Button ID="btNewProyectoRelacion" Text="Aceptar y Crear Nuevo" OnClick="btNewProyectoRelacion_Click" runat="server"
                                ValidationGroup="vgProyectosRelacion" />
                            <asp:Button ID="btCancelProyectoRelacion" Text="Cerrar" OnClick="btCancelProyectoRelacion_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <uc:MessageBar ID="MessageBarForm" runat="server" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>

    <asp:ValidationSummary ID="vsProyectoRelacion" runat="server" DisplayMode="BulletList" ValidationGroup="vgProyectosRelacion" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>

    <asp:Button ID="Button6" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectosRelacionados" runat="server" CancelControlID="Button6"
        PopupDragHandleControlID="ProyectosRelacionadosPopUpDragHandle" PopupControlID="PopUpProyectosRelacionados"
        OkControlID="Button6" TargetControlID="Button6" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Demoras--%>
<asp:Panel ID="PopUpDemoras" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="DemorasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpDemoras" runat="server" Text="Demoras" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnDemoras" DefaultButton="btProyectoSaveDemoras" runat="server">
        <asp:UpdatePanel ID="upDemorasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liFechaDemora" runat="server" Text="Fecha"></asp:Literal>
                        </td>
                        <td>
                            <%--<asp:DropDownList ID="ddlFechaDemora" runat = "server" ></asp:DropDownList>--%>
                            <uc:DateInput ID="diFechaDemora" runat="server" ValidationGroup="vgDemora" IsValidEmpty="false" />
                        </td>

                    </tr>
                    <tr>
                        <td class="style1">
                            <asp:Literal ID="liJustificacionDemora" runat="server" Text="Justificación"></asp:Literal>
                        </td>
                        <td>
                            <asp:TextBox ID="txtJustificacionDemora" runat="server" TextMode="MultiLine" Rows="3" Width="100%"></asp:TextBox>
                        </td>
                        <td>
                            <div class="filaValidator">
                                <asp:RequiredFieldValidator ID="rfvJustificacionDemora" runat="server" ControlToValidate="txtJustificacionDemora" ValidationGroup="vgDemora" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revJustificacionDemora" runat="server" ControlToValidate="txtJustificacionDemora" ValidationGroup="vgDemora" Text="*" Width="1px" Height="1px" ErrorMessage="La Justificación no es válida"></asp:RegularExpressionValidator>
                            </div>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btProyectoSaveDemoras" Text="Aceptar" OnClick="btSaveProyectoDemora_Click" runat="server" ValidationGroup="vgDemora" />
                            <asp:Button ID="btNewProyectoDemoras" Text="Aceptar y Crear Nuevo" OnClick="btNewProyectoDemora_Click" runat="server"
                                ValidationGroup="vgDemora" />
                            <asp:Button ID="btCancelProyectoDemoras" Text="Cerrar" OnClick="btCancelProyectoDemora_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsDemora" runat="server" DisplayMode="BulletList" ValidationGroup="vgDemora" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button7" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDemoras" runat="server" CancelControlID="Button7"
        PopupDragHandleControlID="DemorasPopUpDragHandle" PopupControlID="PopUpDemoras"
        OkControlID="Button7" TargetControlID="Button7" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PopUp Transferencias--%>
<asp:Panel ID="PopUpTransferencia" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="TransferenciaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpTransferencia" runat="server" Text="Transferencia" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnTransferencia" runat="server" Style="padding: 10px">
        <asp:Panel ID="pnTransferenciaFiltro" DefaultButton="btAceptarTransferencia" runat="server" GroupingText="Filtro">
            <asp:UpdatePanel ID="upTransferenciaPopUp" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <table width="100% ">

                        <tr>
                            <td style="width: 150px">
                                <asp:Literal ID="liJurisdiccionTransferencia" Text="Jurisdicción" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlJurisdiccionTransferencia" runat="server" SkinID="AnchoLibre" Width="500px" CssClass="field_input"
                                    OnSelectedIndexChanged="ddlJurisdiccionTransferencia_SelectedIndexChanged" AutoPostBack="true">
                                </asp:DropDownList>
                                <%-- Matias 20140403 - Tarea 122
                            <asp:RequiredFieldValidator ID="rfvJurisdiccionTransferencia" runat="server" ControlToValidate="ddlJurisdiccionTransferencia"
                            InitialValue="0" ValidationGroup="vgTransferencia" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                            Matias 20140403 - Tarea 122 --%>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Literal ID="liSAFTransferencia" Text="SAF" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlSAFTransferencia" runat="server" SkinID="AnchoLibre" Width="500px" CssClass="field_input"
                                    OnSelectedIndexChanged="ddlSAFTransferencia_SelectedIndexChanged" AutoPostBack="true" Enabled="false">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvSAFTransferencia" runat="server" ControlToValidate="ddlSAFTransferencia"
                                    InitialValue="0" ValidationGroup="vgTransferencia" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Literal ID="liProgramaTransferencia" Text="Programa" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProgramaTransferencia" runat="server" SkinID="AnchoLibre" Width="500px" CssClass="field_input"
                                    Enabled="false">
                                </asp:DropDownList>

                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Literal ID="liClasificacionGastoTransferencia" Text="Objetivo del Gasto" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlClasificacionGastoTransferencia" runat="server" SkinID="AnchoLibre" Width="500px" CssClass="field_input">
                                </asp:DropDownList>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 150px">
                                <asp:Literal ID="liProvincia" Text="Provincia" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlProvinciaTransferencia" runat="server" SkinID="AnchoLibre" Width="250px" CssClass="field_input">
                                </asp:DropDownList>
                                <%-- Matias 20140403 - Tarea 122
                           <asp:RequiredFieldValidator ID="rfvProvinciaTransferencia" runat="server" ControlToValidate="ddlProvinciaTransferencia"
                           InitialValue="0" ValidationGroup="vgTransferencia" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                           Matias 20140403 - Tarea 122 --%>							
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 200px">
                                <asp:Literal ID="liDenominacionTransferencia" Text="Denominación" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:TextBox ID="txtDenominacionTransferencia" Width="300px" runat="server"></asp:TextBox>
                            </td>
                        </tr>

                    </table>
                    <br />
                    <br />
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btSaveTransferencia" Text="Buscar" OnClick="btBuscarProyectoOrigenFinanciamientoTransferencia_Click"
                                    runat="server" ValidationGroup="vgTransferencia" />
                                <asp:Button ID="btNewTransferencia" Text="Limpiar" CausesValidation="false" OnClick="btLimpiarProyectoOrigenFinanciamientoTransferencia_Click"
                                    runat="server" ValidationGroup="vgTransferencia" />
                                &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
		                    <asp:Button ID="btAceptarTransferencia" Text="Aceptar" CausesValidation="false" OnClick="btAceptarProyectoOrigenFinanciamientoTransferencia_Click"
                                runat="server" Width="80px" />
                                <asp:Button ID="btCancelTransferencia" Text="Cancelar" CausesValidation="false" OnClick="btCancelProyectoOrigenFinanciamientoTransferencia_Click"
                                    runat="server" Width="80px" />
                            </td>
                        </tr>
                    </table>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>
        <br />
        <asp:UpdatePanel ID="upGridTransferencias" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="overflow: scroll; height: 300px;">
                    <asp:GridView ID="gridTransferencias" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                        AllowPaging="False" AllowSorting="False"
                        EmptyDataText="No se han encontrado transferencias" Width="2000px">
                        <Columns>
                            <asp:TemplateField>
                                <ItemTemplate>
                                    <input id="ItemCheckBox" runat="server" name="ItemCheckBox" type="checkbox" />
                                </ItemTemplate>
                                <ItemStyle Width="25px" />
                            </asp:TemplateField>
                            <asp:BoundField HeaderText="Jurisdiccion" DataField="Jurisdiccion"
                                SortExpression="Jurisdiccion" ItemStyle-Width="50px" />
                            <asp:BoundField HeaderText="Saf" DataField="Saf"
                                SortExpression="Saf" />
                            <asp:BoundField HeaderText="Programa" DataField="Programa"
                                SortExpression="Programa" ItemStyle-Width="200px" />
                            <asp:BoundField HeaderText="Denominacion" DataField="ActividadDenominacion"
                                SortExpression="ActividadDenominacion" />
                            <asp:BoundField HeaderText="Gasto" DataField="ObjetivoGasto"
                                SortExpression="ObjetivoGasto" />
                            <asp:BoundField HeaderText="Provincia" DataField="ClasificacionGeografica_Descripcion"
                                SortExpression="ClasificacionGeografica_Descripcion" />

                        </Columns>
                    </asp:GridView>
                </div>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>


    <asp:ValidationSummary ID="vsTransferencia" runat="server" DisplayMode="BulletList" ValidationGroup="vgTransferencia" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button9" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderTransferencia" runat="server" CancelControlID="Button9"
        PopupDragHandleControlID="TransferenciaPopUpDragHandle" PopupControlID="PopUpTransferencia"
        OkControlID="Button9" TargetControlID="Button9" BackgroundCssClass="modalBackground" />
</asp:Panel>
