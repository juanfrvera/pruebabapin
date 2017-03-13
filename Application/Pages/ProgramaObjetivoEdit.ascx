<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProgramaObjetivoEdit.ascx.cs"
    Inherits="UI.Web.ProgramaObjetivoEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseAutocomplete.ascx" %>
<%--German 02032014 - tarea 110--%>
<%@ Register TagPrefix="uc" TagName="TreeIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseTree.ascx" %>
<%--German 02032014 - tarea 110--%>

<style type ="text/css">
    .tdDatosGenerales1
    {
        width :110px;   
    }
    .tdDatosGenerales2
    {
        width :650px;   
    }
    .tdDatosGenerales3
    {
        width :100px;   
    }    
    .tdDatosGenerales4
    {
        width :100px;   
    }        
</style>

<%--DATOS GENERALES --%>
<asp:Panel ID="pnlDatosGenerales" runat="server" GroupingText="Datos Generales">
    <table  cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesSaf" Text="SAF" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales2">
                <asp:TextBox runat="server" ID="txtDatosGeneralesSaf" Enabled="false" width="630px"></asp:TextBox>
            </td>
            <td class="tdDatosGenerales3">
                <asp:Literal ID="ltDatosGeneralesFechaAlta" Text="Fecha de Alta" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales4">
                <asp:TextBox runat="server" ID="txtDatosGeneralesFechaAlta" width="80px" Enabled="false" ></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesCodigo" Text="Código" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales2">
                <asp:TextBox runat="server" ID="txtDatosGeneralesCodigo" width="80px" Enabled="false" ></asp:TextBox>
            </td>
            <td class="tdDatosGenerales3">
                <asp:Literal ID="ltDatosGeneralesFechaBaja" Text="Fecha de Baja" runat="server"></asp:Literal>
            </td>
            <td class="tdDatosGenerales4">
                <asp:TextBox runat="server" ID="txtDatosGeneralesFechaBaja" width="80px" Enabled="false" ></asp:TextBox>
            </td>
        </tr>
        </table>
        <table cellpadding="0" cellspacing="5px" border="0">        
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltDatosGeneralesDenominacion" Text="Denominación" runat="server" ></asp:Literal>
            </td>
            <td width="830px">
                <asp:TextBox runat="server" ID="txtDatosGeneralesDenominacion" Rows="3" TextMode="MultiLine" Enabled="false" width="820px"></asp:TextBox>
            </td>
        </tr>
        <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="ltSectorialista" Text="Sectorialista" runat="server" ></asp:Literal>
            </td>
            <td width="830px">
                <asp:TextBox runat="server" ID="txtSectorialista" Enabled="false" width="220px"></asp:TextBox>
            </td>
        </tr>
	     <tr>
            <td class="tdDatosGenerales1">
                <asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal>                
            </td>
            <td width="830px">
                <asp:CheckBox ID="chkActivo" runat="server" Enabled="false"></asp:CheckBox>
            </td>
        </tr>                 
    </table>
</asp:Panel>
<%--SUBPROGRAMAS --%>
<asp:Panel ID="pnlSubprogramas" runat="server" GroupingText="Subprogramas">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <asp:GridView ID="gridSubprogramas" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    AllowPaging="False" AllowSorting="False" OnSorting="GridSubprogramas_Sorting" OnPageIndexChanging="GridSubprogramas_PageIndexChanging"
                    EmptyDataText="No hay subprogramas definidos" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Código" DataField="Codigo" SortExpression="Codigo" />
                        <asp:BoundField HeaderText="Denominación" DataField="Nombre" SortExpression="Nombre" />
                        <asp:BoundField HeaderText="Fecha Alta" DataField="FechaAlta" SortExpression="FechaAlta" />
                        <asp:BoundField HeaderText="Fecha Baja" DataField="FechaBaja" SortExpression="FechaBaja" />
                    </Columns>
                </asp:GridView>
            </td>
        </tr>
    </table>
</asp:Panel>
<%--OBJETIVOS --%>
<asp:Panel ID="pnlObjetivos" runat="server" GroupingText="Objetivos">
    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0" width="100%">
                    <tr>
                        <td align="right">
                            <asp:UpdatePanel ID="pnlAgregarObjetivo" runat="server" UpdateMode="Conditional">
                                <ContentTemplate>
                                    <asp:Button ID="btAgregarObjetivo" runat="server" Text="Agregar" OnClick="btAgregarObjetivo_Click"
                                        TabIndex="1"  />
                                </ContentTemplate>
                            </asp:UpdatePanel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
    </table>
    <asp:UpdatePanel ID="upGridObjetivos" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <asp:GridView ID="gridObjetivos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                AllowPaging="False" OnRowCommand="GridObjetivos_RowCommand" OnRowDataBound="GridObjetivos_RowDataBound"
                AllowSorting="False" OnSorting="GridObjetivos_Sorting" OnPageIndexChanging="GridObjetivos_PageIndexChanging"
                EmptyDataText="No hay objetivos definidos" Width="100%">
                <Columns>
                    <asp:TemplateField ItemStyle-Width="30px" >
                        <ItemTemplate>
                            <asp:RadioButton ID="rbSeleccionObjetivo" runat="server" OnCheckedChanged="rbSeleccionObjetivo_CheckedChanged"
                                AutoPostBack="true" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:BoundField HeaderText="Objetivos" DataField="Objetivo_Nombre" SortExpression="Objetivo_Nombre" />
                    <asp:TemplateField >
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID="imgSupuesto" runat="server" src="../Images/supuestos.png" ToolTip="Supuestos"
                                CommandName='<%# Command.SHOW_DETAILS %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            &nbsp;
                            <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            &nbsp;
                            <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                CommandArgument='<%#Eval("ID")%>'  Enabled='<%# Enable %>' CausesValidation="false" />
                        </ItemTemplate>
                        <ItemStyle Width="100px" HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
<br />    
    <div class="CollapsiblePanelTab">
        <span id="spanGeoref">
            <asp:Label ID="lblIndicadoresObjetivo" runat="server" Text="Indicadores"></asp:Label>
            &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpeIndicadoresObjetivo" runat="Server"
            TargetControlID="pnlIndicadoresObjetivo" Collapsed="True" ExpandControlID="lblIndicadoresObjetivo"
            CollapseControlID="lblIndicadoresObjetivo" AutoCollapse="False" AutoExpand="False"
            ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlIndicadoresObjetivo" runat="server">
        <table width="100%" cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td align="right">
                    <asp:UpdatePanel ID="upAgregarIndicadorObjetivo" runat="server" UpdateMode="Conditional">
                        <ContentTemplate>
                            <asp:Button ID="btAgregarIndicadorObjetivo" runat="server" Text="Agregar" OnClick="btAgregarIndicadorObjetivo_Click" />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                </td>
            </tr>
        </table>
        <asp:UpdatePanel ID="upGridIndicadoresObjetivo" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridIndicadoresObjetivo" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridIndicadores_RowCommand"
                    AllowSorting="False" OnSorting="GridIndicadores_Sorting" OnPageIndexChanging="GridIndicadores_PageIndexChanging"
                    EmptyDataText="No hay indicadores definidos" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Sigla" DataField="IndicadorClase_Sigla" SortExpression="IndicadorClase_Sigla" />
                        <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                        <asp:BoundField HeaderText="Unidad" DataField="IndicadorClase_Unidad" SortExpression="IndicadorClase_Unidad" />
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
                                    CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                    CommandArgument='<%#Eval("ID")%>'  Enabled='<%# Enable %>'  CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="100px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
</asp:Panel>
<%--PANEL ALTA OBJETIVOS --%>
<asp:Panel ID="PopUpObjetivos" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ObjetivosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5px">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpObjetivos" runat="server" Text="Objetivos" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnObjetivos" DefaultButton="btSaveObjetivos" runat="server">
        <asp:UpdatePanel ID="upObjetivosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="ltObjetivo" Text="Objetivo :" runat="server"></asp:Literal>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:TextBox runat="server" ID="txtObjetivo" Width="700px" Rows="6" TextMode="MultiLine"></asp:TextBox>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:RequiredFieldValidator ID="rfvObjetivo" runat="server" ControlToValidate="txtObjetivo"
                                            ValidationGroup="vgObjetivo" Text="*" Width="1px" Height="1px">
                                        </asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revObjetivo" runat="server" ControlToValidate="txtObjetivo"
                                            ValidationGroup="vgObjetivo" Text="*" Width="1px" Height="1px">
                                        </asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveObjetivos" Text="Aceptar" OnClick="btSaveObjetivo_Click" runat="server"
                                ValidationGroup="vgObjetivo" />
                            <asp:Button ID="btNewObjetivos" Text="Aceptar y Agregar Nuevo" OnClick="btNewObjetivo_Click"
                                runat="server" ValidationGroup="vgObjetivo" />
                            <asp:Button ID="btCancelObjetivos" Text="Cerrar" OnClick="btCancelObjetivo_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsObjetivo" runat="server" DisplayMode="BulletList" ValidationGroup="vgObjetivo"
        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderObjetivos" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="ObjetivosPopUpDragHandle" PopupControlID="PopUpObjetivos"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA SUPUESTOS --%>
<asp:Panel ID="PopUpSupuestos" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="SupuestosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="Label1" runat="server" Text="Supuestos" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnSupuestos" runat="server">
        <asp:UpdatePanel ID="upSupuestosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloSupuestos" runat="server" Text=""></asp:Label>
                <asp:Panel ID="pnAccionSupuestos" runat="server" GroupingText="Agregar">
                    <table width="100%" cellpadding="0" cellspacing="5px">
                        <tr>
                            <td>
                                <table>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="ltSupuesto" Text="Supuesto :" runat="server"></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:TextBox runat="server" ID="txtSupuesto" Width="700px" Height="66px" TextMode="MultiLine"></asp:TextBox>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:RequiredFieldValidator ID="rfvSupuestos" runat="server" ControlToValidate="txtSupuesto"
                                                ValidationGroup="vgSupuesto" Text="*" Width="1px" Height="1px">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revSupuestos" runat="server" ControlToValidate="txtSupuesto"
                                                ValidationGroup="vgSupuesto" Text="*" Width="1px" Height="1px">
                                            </asp:RegularExpressionValidator>
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="5px">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewSupuesto" Text="Agregar" OnClick="btSaveSupuesto_Click" runat="server"
                                    ValidationGroup="vgSupuesto" />
                                <asp:Button ID="btSaveSupuesto" Text="Guardar" OnClick="btNewSupuesto_Click" runat="server"
                                    ValidationGroup="vgSupuesto" />
                                <asp:Button ID="btCanelSupuesto" Text="Cerrar" OnClick="btCancelSupuesto_Click" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upGridSupuestos" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td>
                            <asp:GridView ID="gridSupuestos" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                                AllowPaging="False" OnRowCommand="GridSupuestos_RowCommand" AllowSorting="False"
                                OnSorting="GridSupuestos_Sorting" OnPageIndexChanging="GridSupuestos_PageIndexChanging"
                                EmptyDataText="No hay supuestos definidos" Width="100%">
                                <Columns>
                                    <asp:BoundField HeaderText="Supuestos" DataField="Descripcion" SortExpression="Descripcion" />
                                    <asp:TemplateField>
                                        <HeaderTemplate>
                                        </HeaderTemplate>
                                        <ItemTemplate>
                                            &nbsp;
                                            <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                                CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                            &nbsp;
                                            <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                                CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                                CommandArgument='<%#Eval("ID")%>'  Enabled='<%# Enable %>'  CausesValidation="false" />
                                        </ItemTemplate>
                                        <ItemStyle Width="150px" HorizontalAlign="Right" />
                                    </asp:TemplateField>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsSupuesto" runat="server" DisplayMode="BulletList" ValidationGroup="vgSupuesto"
        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSupuestos" runat="server" CancelControlID="Button5"
        PopupDragHandleControlID="SupuestosPopUpDragHandle" PopupControlID="PopUpSupuestos"
        OkControlID="Button5" TargetControlID="Button5" BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA INDICADORES --%>
<asp:Panel ID="PopUpIndicadores" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="IndicadoresPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpIndicadores" runat="server" Text="Indicadores" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnIndicadores" DefaultButton="btSaveIndicadores" runat="server">
        <asp:UpdatePanel ID="upIndicadoresPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td>
                            <asp:Label ID="lblTituloIndicadores" runat="server" Text=""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                           <%--German 01032014 - Tarea 124 
                           <asp:Literal ID="ltIndicador" Text="Indicador" runat="server"></asp:Literal> 
                           German 01032014 - Tarea 124--%>
                        </td>
                    </tr>                    
                    <tr>
                        <td>
                           <uc:AutocompleteIndicadorClase runat="server" ID="autoCmpIndicadorClase" Width="300px"
                           AutocompleteHandler="../Handlers/IndicadorClaseAutocompleteSimpleHandler.ashx"
                           RequiredValue="true" ShowOption="ActivesAndActualValue" ValidationGroup="vgIndicador">
                                    </uc:AutocompleteIndicadorClase>  
                        </td>
                    </tr>
                    <%--German 02032014 - tarea 110--%>
                    <tr>
                        <td style="padding-top:0px" width="600px" >
                            <%--Matias 20140520 - Tarea 124--%>
                            <%--<asp:Literal ID="Literal9" Text="Sectores e Indicadores" runat="server" ></asp:Literal>--%>
                            <asp:Literal ID="Literal9" Text="Sector&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;Indicador" runat="server" ></asp:Literal>
                            <%--Matias 20140520 - Tarea 124--%>
                            <uc:TreeIndicadorClase runat="server" ID="toIndicadoClase" Handler="../Handlers/IndicadorClaseHandler.ashx" 
                            SelectOption="Any" ShowOption="All" RequiredValue="true" ValidationGroup="vgIndicador" Width="600px"> </uc:TreeIndicadorClase>
                        </td>
                    </tr>
                       <%--German 02032014 - tarea 110--%>
                    <tr>
                        <td>
                            <asp:Literal ID="ltMedioVerificacion" Text="Medio de Verificación" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMedioVerificacion" runat="server" OnSelectedIndexChanged="ddlMedioVerificacion_IndexChanged">
                            </asp:DropDownList>
                        </td>                 
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltObservacionesIndicadores" Text="Obervaciones" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObservacionesIndicadores" Width="700px" Rows="6"
                                TextMode="MultiLine"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:RegularExpressionValidator ID="revObservacionesIndicadores" runat="server" ControlToValidate="txtObservacionesIndicadores"
                                ValidationGroup="vgIndicador" Text="*" Width="1px" Height="1px">
                            </asp:RegularExpressionValidator>
                        </td>
                    </tr>
                </table>
                <table width="100%" cellpadding="0" cellspacing="5px">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveIndicadores" Text="Aceptar" OnClick="btSaveIndicador_Click"
                                runat="server" ValidationGroup="vgIndicador" />
                            <asp:Button ID="btNewIndicadores" Text="Aceptar y Agregar Nuevo" OnClick="btNewIndicador_Click"
                                runat="server" ValidationGroup="vgIndicador" />
                            <asp:Button ID="btCancelIndicadores" Text="Cerrar" OnClick="btCancelIndicador_Click"
                                runat="server" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vsIndicador" runat="server" DisplayMode="BulletList" ValidationGroup="vgIndicador"
        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button6" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadores" runat="server"
        CancelControlID="Button6" PopupDragHandleControlID="IndicadoresPopUpDragHandle"
        PopupControlID="PopUpIndicadores" OkControlID="Button6" TargetControlID="Button6"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<%--PANEL ALTA EVOLUCIONES --%>
<asp:Panel ID="PopUpEvoluciones" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EvolucionesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEvoluciones" runat="server" Text="Evolucion" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEvoluciones" DefaultButton="btNewEvolucion" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upEvolucionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloEvoluciones" runat="server" Text=""></asp:Label>
                <br />
                <br />                
                <asp:Panel ID="pnEvolucionesAgregar" runat="server" GroupingText="Agregar">
                    <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                        <tr>
                            <td>
                                <asp:Literal ID="ltLocalizacion" Text="Localización"  runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <uc:TreeLocalizacion runat="server" ID="tsEvolucion"  RequiredValue="true" ValidationGroup="vgEvolucion" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"  ></uc:TreeLocalizacion>
                            </td>
                            <td>
                                <asp:Literal ID="ltTipoEvolucion" Text="Tipo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoEvolucion" runat="server" SkinID="AnchoLibre" Width="120px">
                                </asp:DropDownList>
                                <asp:RequiredFieldValidator ID="rfvTipoEvolucion" runat="server" ControlToValidate="ddlTipoEvolucion"
                                    InitialValue="0" ValidationGroup="vgEvolucion" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltFechaEstimadaEvolucion" Text="Fecha Estimada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput ID="diFechaEstimadaEvolucion" runat="server" ValidationGroup="vgEvolucion"
                                    IsValidEmpty="true" />
                            </td>
                            <td>
                                <asp:Literal ID="ltCantidadEstimadaEvolucion" Text="Cantidad Estimada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox runat="server" ID="txtCantidadEstimadaEvolucion" InputType="PositiveFractional" Width="115px" ></cc:NumericTextBox>
                                <asp:RequiredFieldValidator ID="rfvCantidadEstimadaEvolucion" runat="server" ControlToValidate="txtCantidadEstimadaEvolucion"
                                    ValidationGroup="vgEvolucion" Text="*" Width="1px" Height="1px">
                                </asp:RequiredFieldValidator>
                                <asp:RegularExpressionValidator ID="revCantidadEstimadaEvolucion" runat="server"
                                    ControlToValidate="txtCantidadEstimadaEvolucion" ValidationGroup="vgEvolucion"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>	                                
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="ltFechaRealizadaEvolucion" Text="Fecha Realizada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <uc:DateInput ID="diFechaRealizadaEvolucion" runat="server" ValidationGroup="vgEvolucion"
                                    IsValidEmpty="false" />
                            </td>
                            <td>
                                <asp:Literal ID="ltCantidadRealizadaEvolucion" Text="Cantidad Realizada" runat="server" ></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox runat="server" ID="txtCantidadRealizadaEvolucion" InputType="PositiveFractional" Width="115px"></cc:NumericTextBox>
                              <asp:RegularExpressionValidator ID="revCantidadRealizadaEvolucion" runat="server"
                                    ControlToValidate="txtCantidadRealizadaEvolucion" ValidationGroup="vgEvolucion"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>								                                
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewEvolucion" Text="Agregar" OnClick="btSaveEvolucion_Click" runat="server"
                                    ValidationGroup="vgEvolucion" />
                                <asp:Button ID="btSaveEvolucion" Text="Guardar" OnClick="btNewEvolucion_Click" runat="server"
                                    ValidationGroup="vgEvolucion" />
                                <asp:Button ID="btCancelEvolucion" Text="Cerrar" OnClick="btCancelEvolucion_Click"
                                    ValidationGroup="vgEvolucionPopUp" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
         <br />
        <asp:UpdatePanel ID="upGridEvoluciones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:GridView ID="gridEvoluciones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    AllowPaging="False" OnRowCommand="GridEvoluciones_RowCommand" AllowSorting="False"
                    OnSorting="GridEvoluciones_Sorting" OnPageIndexChanging="GridEvoluciones_PageIndexChanging"
                    EmptyDataText="No hay evoluciones definidas" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Localización Geográfica" DataField="ClasificacionGeografica_Descripcion"
                            SortExpression="ClasificacionGeografica_Descripcion" />
                        <asp:BoundField HeaderText="Tipo" DataField="IndicadorEvolucionInstancia_Nombre"
                            SortExpression="IndicadorEvolucionInstancia_Nombre" />
                        <asp:BoundField HeaderText="Fecha E." DataField="FechaEstimada" SortExpression="FechaEstimada" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField HeaderText="Cantidad E." DataField="CantidadEstimada" SortExpression="CantidadEstimada" ItemStyle-HorizontalAlign="Right"  DataFormatString="{0:0.00}"/>
                        <asp:BoundField HeaderText="Fecha Real" DataField="FechaReal" SortExpression="FechaReal" DataFormatString="{0:dd/MM/yyyy}"/>
                        <asp:BoundField HeaderText="Cantidad Real" DataField="CantidadReal" SortExpression="CantidadReal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0.00}"/>
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                    CommandArgument='<%#Eval("ID")%>'  Enabled='<%# Enable %>' CausesValidation="false"  />
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
<asp:ValidationSummary id="vsEvolucion" runat="server" DisplayMode="BulletList" ValidationGroup="vgEvolucion"  ShowSummary="False"  ShowMessageBox="True"  ></asp:ValidationSummary>    
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEvoluciones" runat="server"
        CancelControlID="Button2" PopupDragHandleControlID="EvolucionesPopUpDragHandle"
        PopupControlID="PopUpEvoluciones" OkControlID="Button2" TargetControlID="Button2"
        BackgroundCssClass="modalBackground" />
</asp:Panel>

