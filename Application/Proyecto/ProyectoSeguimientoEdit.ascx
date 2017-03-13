<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoEdit.ascx.cs"
    Inherits="UI.Web.ProyectoSeguimientoEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx" %>
<%@ Register TagPrefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<asp:UpdatePanel ID="upDatosGenerales" runat = "server" UpdateMode ="Conditional" >
    <ContentTemplate >
        <asp:Panel ID="pnlDatosGenerales" runat = "server" GroupingText ="Datos Generales" >
            <table>
                <tr>
                    <td>
                        <table width="450px" cellpadding="0" cellspacing="5px" border="0">
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liSaf" Text="Saf" runat="server"></asp:Literal>
                                </td>
                                <td class="filaValidator">
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvSaf" runat="server"  ControlToValidate="ddlSaf" InitialValue ="0"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </td>
                                <td class="filaInput">
                                    <cc:ExtendedDropDownList ID="ddlSaf" SkinID ="AnchoLibre" Width ="350px"  runat="server"  ></cc:ExtendedDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liDenominacion" Text="Denominación" runat="server"></asp:Literal>
                                </td>
                                <td class="filaValidator">
                                    &nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server" ControlToValidate="txtDenominacion"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" Height="1px"
                                        ErrorMessage="La Denominación no es válida"></asp:RegularExpressionValidator>
                                    <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" ControlToValidate="txtDenominacion"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" 
                                        Height="16px"></asp:RequiredFieldValidator>
                                </td>
                                <td class="filaInput">
                                    
                                </td>
                            </tr>
                            <tr>
                                <td colspan ="3">
                                    <asp:TextBox ID="txtDenominacion" Width="450px" MaxLength="500" TextMode="MultiLine"
                                        Rows="6" runat="server" CssClass="field_input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liRuta" Text="Ruta" runat="server"></asp:Literal>
                                </td>
                                <td class="filaValidator">
                                    &nbsp;<asp:RegularExpressionValidator ID="revRuta" runat="server" ControlToValidate="txtRuta"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" Height="1px"
                                        ErrorMessage="El Ruta no es válida"></asp:RegularExpressionValidator>
                                </td>
                                <td class="filaInput">
                                    <asp:TextBox ID="txtRuta" Width="200px" MaxLength="50" runat="server" CssClass="field_input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liMalla" Text="Malla" runat="server"></asp:Literal>
                                </td>
                                <td class="filaValidator">
                                    &nbsp;<asp:RegularExpressionValidator ID="revMalla" runat="server" ControlToValidate="txtMalla"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" Height="1px"
                                        ErrorMessage="El Malla no es válida"></asp:RegularExpressionValidator>
                                </td>
                                <td class="filaInput">
                                    <asp:TextBox ID="txtMalla" Width="200px" MaxLength="50" runat="server" CssClass="field_input"></asp:TextBox>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liAnalista" Text="Analista" runat="server"></asp:Literal>
                                &nbsp;</td>
                                <td class="filaValidator">
                                    &nbsp;
                                    <asp:RequiredFieldValidator ID="rfvAnalista" runat="server" ControlToValidate="ddlAnalista" InitialValue ="0"
                                        ValidationGroup="EditionProyectoSeguimiento" Text="*" Width="1px" Height="1px"></asp:RequiredFieldValidator>
                                </td>
                                <td class="filaInput">
                                    <cc:ExtendedDropDownList ID="ddlAnalista" runat="server" ></cc:ExtendedDropDownList>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel">
                                    <asp:Literal ID="liProyectoSeguimientoAnterior" Text="Ref. Dict. Anterior"
                                        runat="server"></asp:Literal>
                                </td>
                                <td>
                                    &nbsp;
                                </td>
                                <td class="filaInput">
                                    <asp:TextBox ID="txtProyectoSeguimientoAnterior" runat ="server" ></asp:TextBox>
                                    <asp:Button ID="btBuscarProyectoSeguimientoAnterior" runat="server" 
                                            OnClick="btBuscarProyectoSeguimientoAnterior_Click" Text ="Buscar" />
                                </td>
                                <td class="filaValidator">
                                    &nbsp;
                                        <%--<asp:RequiredFieldValidator ID="rfvProyectoSeguimientoAnterior" runat="server"
                                        ControlToValidate="ddlProyectoSeguimientoAnterior" ValidationGroup="EditionProyectoSeguimiento"
                                        Text="*" Width="16px" Height="1px"></asp:RequiredFieldValidator>--%>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                </td>
                                <td>
                                </td>
                                <td>
                                    <asp:Label ID="lbDenominacionEvaluacion" runat ="server" ></asp:Label>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="vertical-align:top">
                        <asp:Panel ID="pnlUltimoEstado" runat="server" GroupingText="Último Estado" >
                            <asp:UpdatePanel ID="upUltimoEstado" runat = "server" >
                            <ContentTemplate>
                                <table width="450px">
                                    <tr>
                                        <td>
                                            <asp:Literal ID ="liUsuario" runat ="server" Text="Usuario" ></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbUsuario" runat="server"  Enabled="false" ></asp:Label>
                                        </td>
                                        <td align="right">
                                            <asp:Button ID="btAgregarEstado" runat="server" Text="Agregar" 
                                                onclick="btAgregarEstado_Click" />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="liEstadoSituacion" runat="server" Text="Estado Situación" ></asp:Literal>
                                        </td>
                                        <td>
                                            <asp:Label ID="lbEstadoSituacion" runat="server" ></asp:Label>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <asp:Literal ID="liFechaEstado" runat = "server" Text ="Fecha Estado" ></asp:Literal>
                                        </td>
                                        <td>
                                            <uc:DateInput ID="diFechaEstado" runat = "server" Enabled ="false"  />
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan ="3" >
                                            <asp:Literal ID="liObservacionEstado" runat ="server" Text="Observación Estado" ></asp:Literal>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td colspan="3" >
                                            <asp:TextBox ID="txtObservacionEstado" runat="server" Rows ="12" TextMode ="MultiLine" Width="100%" ReadOnly ="true" ></asp:TextBox>
                                        </td>
                                    </tr>
                                </table>
                            </ContentTemplate>
                            </asp:UpdatePanel>
                        </asp:Panel>
                    </td>
                </tr>
                <tr>
                    <td colspan ="2" >
                        <asp:Panel ID="pnlListaProyectos" runat="server" GroupingText="Lista de Proyectos" >
                            <table width="100%">
                                <tr>
                                    <td align="right" >
                                        <asp:Button ID="btAgregarProyecto" runat ="server" Text="Agregar" 
                                            onclick="btAgregarProyecto_Click" />
                                    </td>                       
                                </tr>
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="upGridProyectos" runat="server" UpdateMode ="Conditional" >
                                            <ContentTemplate>
                                                <asp:GridView ID="GridProyectos" 
                                                    runat="server"  
                                                    AutoGenerateColumns="False" 
                                                    DataKeyNames="ID" 
                                                    AllowPaging="True" 
                                                    OnRowCommand="GridProyectos_RowCommand"    
                                                    AllowSorting="True"
                                                    OnSorting="GridProyectos_Sorting"
                                                    OnPageIndexChanging="GridProyectos_PageIndexChanging" 
                                                    EmptyDataText="No hay Proyectos Definidos" 
                                                    Width ="100%"  
                                                    
                                                >
                                                    <Columns>
                                                        <asp:BoundField DataField="Proyecto_Codigo" HeaderText ="Proyecto de Inversión" SortExpression="Proyecto_Codigo" ItemStyle-Width="6%"/>
                                                        <asp:BoundField DataField="Proyecto_ProyectoDenominacion" HeaderText ="Denominación" SortExpression="Proyecto_ProyectoDenominacion" ItemStyle-Width="85%" />
                                                        <asp:TemplateField>
                                                            <HeaderTemplate>
                                                            </HeaderTemplate>
                                                            <ItemTemplate>
                                                                &nbsp;
                                                                <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                                                &nbsp;
                                                                <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                                            </ItemTemplate>            
                                                            <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
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
                <tr>
                    <td colspan ="2">
                        <asp:Panel ID="pnlLocalizacion" runat ="server" GroupingText="Localización" >
                            <table width ="100%" >
                                <tr>
                                    <td>
                                        <asp:UpdatePanel ID="upProvincias" runat ="server" >
                                            <ContentTemplate>
                                                <asp:DataList ID="dlProvincias" runat="server" CellSpacing="0" CellPadding="0" RepeatColumns="4" >
                                                    <ItemTemplate>
                                                        <asp:CheckBox ID="chk" Checked='<%# Bind("Selected") %>' Text='<%# Bind("CalificacionGeografica_Nombre") %>' runat="server" CssClass="smallCheck"/>
                                                        <asp:HiddenField ID="hdValue" Value='<%# Bind("IdCalificacionGeografica") %>' runat="server" />
                                                    </ItemTemplate>
                                                </asp:DataList>    
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
<%--PopUp Proyectos Relacionados--%>
<asp:Panel ID="PopUpProyectoSeguimientoProyecto" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectoSeguimientoProyectoPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpProyectoSeguimientoProyecto" runat="server" Text="BAPIN" />
                </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectoSeguimientoProyecto" DefaultButton="btSaveProyecto" runat="server">
        <asp:UpdatePanel ID="upProyectoSeguimientoProyectoPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                       <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liBapinProyecto" runat = "server" Text="Código" ></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="txtBapinProyecto" type="text" min="0" runat = "server" OnTextChanged="txtBapinProyecto_TextChanged" AutoPostBack ="true"  ></asp:TextBox>
                                    </td>
                                    <td>
                                         <div class="filaValidator">
                                            <asp:RequiredFieldValidator ID="rfvBapin" runat="server"  ControlToValidate="txtBapinProyecto"  ValidationGroup="vgProyecto"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revBapin" runat="server"   ControlToValidate="txtBapinProyecto"  ValidationGroup="vgProyecto"  Text="*" Width="1px" Height="1px"  ErrorMessage="El código BAPIN no es válido"></asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                </tr>
                            </table>
                       </td>
                       
                    </tr>
                    <tr>
                        <td >
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal Id="liDenominacionProyecto" runat = "server"  Text ="Denominación" ></asp:Literal>        
                                    </td>
                                    <td>
                                        <asp:Label ID="lbDenominacionProyecto" runat = "server" ></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveProyecto" Text="Aceptar" OnClick="btSaveProyecto_Click" runat="server" ValidationGroup="vgProyectoSeguimientoProyecto" />
                            <asp:Button ID="btNewProyecto" Text="Aceptar y Crear Nuevo" OnClick="btNewProyecto_Click" runat="server"
                                ValidationGroup="vgProyectoSeguimientoProyecto" />
                            <asp:Button ID="btCancelProyecto" Text="Cerrar" OnClick="btCancelProyecto_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                    <tr>
                        <td align ="center" >
                             <uc:MessageBar ID="MessageBarForm" runat="server" />      
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>   
    <asp:Button ID="Button6" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectoSeguimientoProyecto" runat="server" CancelControlID="Button6"
        PopupDragHandleControlID="ProyectoSeguimientoProyectoPopUpDragHandle" PopupControlID="PopUpProyectoSeguimientoProyecto"
        OkControlID="Button6" TargetControlID="Button6" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PopUp Estados--%>
 
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
    <asp:Panel ID="pnEstados" DefaultButton="btSaveEstados" runat="server">
        <asp:UpdatePanel ID="upEstadosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td class="style1">
                            <div>
                                <asp:Literal ID="liEstadoPopUpEstado" runat = "server" Text ="Estado"  ></asp:Literal>
                            </div>
                            <div>
                                <cc:ExtendedDropDownList ID="ddlEstadoPopUpEstado" runat = "server" ></cc:ExtendedDropDownList>
                                <asp:RequiredFieldValidator ID="rfvEstadoPopUpEstado" runat ="server" InitialValue ="0" 
                                    Text ="*" ControlToValidate="ddlEstadoPopUpEstado" 
                                    ValidationGroup="vgEstados" >
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div>
                                <asp:Literal ID="liUsuarioPopUpEstado" runat = "server" Text ="Usuario" ></asp:Literal>
                            </div>
                            <div>
                                <cc:ExtendedDropDownList ID="ddlUsuarioPopUpEstado" runat = "server" ></cc:ExtendedDropDownList>
                                <asp:RequiredFieldValidator ID="rfvUsuarioPopUpEstado" runat ="server" InitialValue ="0" 
                                    Text ="*" ControlToValidate="ddlUsuarioPopUpEstado" 
                                    ValidationGroup="vgEstados" >
                                </asp:RequiredFieldValidator>
                            </div>
                        </td>
                        <td>
                            <div>
                                <asp:Literal ID="liFechaPopUpEstado" runat ="server" Text ="Fecha"  ></asp:Literal>
                            </div>
                            <div>
                                <uc:DateInput ID="diFechaPopUpEstado" runat = "server" IsValidEmpty="false" ValidationGroup ="vgEstados"  />
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <asp:Literal ID ="liComentarioPopUpEstado" runat ="server" Text ="Comentario" ></asp:Literal>
                    </tr>
                    <tr>
                        <td colspan ="3">
                            <asp:TextBox ID="txtComentario" runat ="server" Rows ="10" Width ="100%" TextMode="MultiLine" ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <asp:CheckBox ID="chkGeneraComentarioTecnico" runat ="server" 
                                Text ="Genera Comentario Técnico" AutoPostBack ="true"
                                oncheckedchanged="chkGeneraComentarioTecnico_CheckedChanged"/>    
                             <asp:CheckBox ID="chkEnviaMensaje" runat ="server" Text="Envía Mensaje" AutoPostBack ="true" oncheckedchanged="chkGeneraComentarioTecnico_CheckedChanged"/>    
                        </td>
                        <td>
                            <asp:Literal ID="liFechaComentarioPopUpEstado" runat ="server" Text="Fecha Comentario" ></asp:Literal>
                        </td>
                        <td>
                            <asp:Panel ID="pnFechaComentarioPopUpEstado" runat ="server" Enabled ="false" >
                                <uc:DateInput ID="diFechaComentarioPopUpEstado" runat = "server" />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveEstados" Text="Aceptar" OnClick="btSaveEstados_Click" runat="server" ValidationGroup="vgEstados" />
                            <asp:Button ID="btNewEstados" Text="Aceptar y Crear Nuevo" OnClick="btNewEstados_Click" runat="server"
                                ValidationGroup="vgEstados" />
                            <asp:Button ID="btCancelEstados" Text="Cerrar" OnClick="btCancelEstados_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:ValidationSummary id="vsEditionEstados" runat="server" DisplayMode="BulletList" ValidationGroup="vgEstados"  ShowSummary="False"  ShowMessageBox="True"  ></asp:ValidationSummary>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEstados" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="EstadosPopUpDragHandle" PopupControlID="PopUpEstados"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
