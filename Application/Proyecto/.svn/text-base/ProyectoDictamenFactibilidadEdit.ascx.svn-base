<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoDictamenFactibilidadEdit.ascx.cs" Inherits="UI.Web.ProyectoDictamenFactibilidadEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<style type="text/css">
    .style1
    {
        width: 457px;
    }
    .style2
    {
        width: 150px;
    }
</style>
<table>
    <tr>
        <td width ="1000px">
            <asp:Panel ID="pnEvaluacionFactibilidad" runat ="server" GroupingText ="Evaluación de Factibilidad" Width ="100%" >
                <asp:UpdatePanel ID="upGridProyectoSeguimiento" runat ="server" UpdateMode ="Conditional" >
                    <ContentTemplate >
                                 
                        <table width ="100%" >
                            <tr>
                                <td align ="right" >
                                    <asp:Button ID="btAgregarEvaluacionFactibilidad" runat ="server" 
                                        Text ="Agregar" onclick="btAgregarEvaluacionFactibilidad_Click" />
                                </td>
                            </tr>
                            <tr>
                                <td>
                             
                                    <asp:GridView ID="gvEvaluacionFactibilidad" runat ="server" 
                                        Width="100%"
                                        AutoGenerateColumns="False" DataKeyNames="ID"     
                                        OnRowCommand="gvEvaluacionFactibilidad_RowCommand"    
                                        OnSorting="gvEvaluacionFactibilidad_Sorting"
                                        EmptyDataText="No hay Evaluaciones de Factibilidad Asociadas" 
                                        AllowSorting="True"
                                         

                                    >
                                        <Columns >
                                            <asp:BoundField DataField="IdProyectoSeguimiento" HeaderText="Nro Secuencial" SortExpression="IdProyectoSeguimiento"  ItemStyle-Width="10%" />
                                            <asp:BoundField DataField="Saf_Denominacion" HeaderText="Saf" SortExpression="Saf_Denominacion" ItemStyle-Width="30%"/>
                                            <asp:BoundField DataField="Denominacion" HeaderText="Denominación" SortExpression="Denominacion" ItemStyle-Width="60%"/>    
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
                </asp:UpdatePanel>
            </asp:Panel>
             
        </td>
    </tr>
</table>

<asp:Panel ID="pnlDictamen"  runat ="server" GroupingText ="Dictamen" >
    <table width ="100%" >
        <tr>
            <td>
                <div>
                    <asp:Literal ID="liDenominacion" runat ="server" Text="Denominación" > </asp:Literal>
                </div>
                <div> &nbsp; </div>
                <div> &nbsp; </div>
            </td>

            <td>
                <asp:UpdatePanel ID ="upDenominacion" runat ="server" UpdateMode ="Conditional" >
                    <ContentTemplate>
                        <asp:TextBox ID="txtDenominacion" runat ="server" Width ="870px" TextMode ="MultiLine" Rows ="2" ></asp:TextBox>
                    
                    </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="rfvDenominacion" runat="server" 
                ControlToValidate="txtDenominacion"  ValidationGroup="EditionProyectoDictamenFactibilidad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
            </td>
        </tr>
        <%--<tr>
            <td>
                <asp:Literal ID="liEstado" runat="server" Text="Estado" ></asp:Literal>
            </td>
            <td>
            <asp:UpdatePanel ID ="upEstado" runat ="server" UpdateMode ="Conditional" >
                    <ContentTemplate>
                <asp:DropDownList ID="ddlEstado" runat ="server" SkinID="AnchoLibre" Width="305px" ></asp:DropDownList>
                 </ContentTemplate>
                </asp:UpdatePanel>
                <asp:RequiredFieldValidator ID="rfvEstado" runat="server" InitialValue="0" 
                ControlToValidate="ddlEstado"  ValidationGroup="EditionProyectoDictamenFactibilidad"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
            </td>
        </tr>--%>
        <tr>
            <td width ="100%" colspan ="2" >
                <asp:Panel ID="pnlUltimoEstado" runat="server" GroupingText="Ultimo Estado" Width = "100%"  >
                    <asp:UpdatePanel ID="upUltimoEstado" runat = "server" >
                    <ContentTemplate>
                        <table >
                            <tr>
                                <td >
                                    <asp:Button ID="btAgregarEstado" runat="server" Text="Agregar" 
                                        onclick="btAgregarEstado_Click" />
                                </td>
                                <td >
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Literal ID ="liUsuario" runat ="server" Text="Usuario" ></asp:Literal>
                                </td>
                                
                                <td >
                                    <asp:Label ID="lbUsuario" runat="server"  Enabled="false" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Literal ID="liEstadoSituacion" runat="server" Text="Estado Situación" ></asp:Literal>
                                </td>
                                <td>
                                    <asp:Label ID="lbEstadoSituacion" runat="server" ></asp:Label>
                                </td>
                            </tr>
                            <tr>
                                <td class="style2">
                                    <asp:Literal ID="liFechaEstado" runat = "server" Text ="Fecha Estado" ></asp:Literal>
                                </td>
                                <td>
                                    <uc:DateInput ID="diFechaEstado" runat = "server" Enabled ="false"  />
                                </td>
                            </tr>
                            <tr>
                                <td  class="style2">
                                    <asp:Literal ID="liObservacionEstado" runat ="server" Text="Observación Estado" ></asp:Literal>
                                </td>
                                <td></td>
                            </tr>

                        </table>
                           <asp:TextBox ID="txtObservacionEstado" runat="server" Rows ="12" TextMode ="MultiLine" Width="100%" ReadOnly ="true" ></asp:TextBox>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>
        </tr>
    </table>
</asp:Panel>



<asp:Panel ID="pnProyectos"  runat = "server" GroupingText ="Lista de Proyectos"  >
    <asp:UpdatePanel ID="upProyectos" runat = "server" UpdateMode ="Conditional" >
        <ContentTemplate>
        
            <asp:GridView ID="gvProyectos"  runat ="server"
                Width="100%"
                AutoGenerateColumns="False" DataKeyNames="ID"     
                
                AllowSorting="True"
                EmptyDataText="No hay Proyectos Asociados" 
             >
                <Columns >
                    <asp:BoundField DataField="Proyecto_Codigo" HeaderText="Bapin" SortExpression="Proyecto_Codigo" />
                    <asp:BoundField DataField="Proyecto_ProyectoDenominacion" HeaderText="Denominación" SortExpression="Proyecto_ProyectoDenominacion" />
	                
                   <%-- <asp:TemplateField  ItemStyle-HorizontalAlign="Right" >           
                        <ItemTemplate>
			                <asp:ImageButton ID ="btRead" runat ="server"  src="../Images/read.png" ToolTip ='<%# Translate("Consultar") %>'    CommandName='<%# Command.READ %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
			                &nbsp;
			                <asp:ImageButton ID ="btEdit" runat ="server"  src="../Images/edit.png" ToolTip ='<%# Translate("Editar") %>'      CommandName='<%# Command.EDIT %>'    CommandArgument='<%# Eval("ID")%>'  CausesValidation="false" />
			                &nbsp;
			                <asp:ImageButton ID ="btDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ='<%# Translate("Eliminar") %>'     CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
   	                    </ItemTemplate>            
                        <ItemStyle Width ="80px" />
                    </asp:TemplateField>--%>
                </Columns>
                
             </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

<asp:Panel ID="pnlLocalizacion" runat ="server" GroupingText="Localización" >
    <table width ="100%" >
        <tr>
            <td>
                <asp:UpdatePanel ID="upProvincias" runat ="server" >
                    <ContentTemplate>
                        <asp:DataList ID="dlProvincias" runat="server" CellSpacing="0" CellPadding="0" RepeatColumns="4" Width ="100%" Enabled ="false" >
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

<%--PopUp Proyectos Relacionados--%>
<asp:Panel ID="PopUpProyectoSeguimiento" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectoSeguimientoPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpProyectoSeguimiento" runat="server" Text="Asociar Evaluación de Factibilidad" />
                </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectoSeguimiento" DefaultButton="btSaveProyectoSeguimiento" runat="server">
        <asp:UpdatePanel ID="upProyectoSeguimientoPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                       <td>
                            <table>
                                <tr>
                                    <td>
                                        <asp:Literal ID="liNroProyectoSeguimiento" runat = "server" Text="Nro Secuencial" ></asp:Literal>
                                    </td>
                                    <td>
                                        <asp:TextBox ID ="txtNroProyectoSeguimiento" type="text" min="0" runat = "server" ></asp:TextBox>
                                    </td>
                                    <td>
                                         <div class="filaValidator">
                                            <asp:RequiredFieldValidator ID="rfvNroProyectoSeguimiento" runat="server"  ControlToValidate="txtNroProyectoSeguimiento"  ValidationGroup="vgProyectoSeguimiento"   Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revNroProyectoSeguimiento" runat="server"   ControlToValidate="txtNroProyectoSeguimiento"  ValidationGroup="vgProyectoSeguimiento"  Text="*" Width="1px" Height="1px"  ></asp:RegularExpressionValidator>
                                        </div>
                                    </td>
                                    <td class="filaInput" style=" width:80px" >
                                    <asp:UpdatePanel ID="upBapinBuscar" runat="server">
                                        <ContentTemplate>
                                            <asp:Button ID="btSearchProyecto" runat="server" Text="Buscar" OnClick="btSearchProyectoSeguimiento_Click" /> 
                                    </ContentTemplate>
                                    </asp:UpdatePanel>
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
                                        <asp:Literal Id="liDenominacionProyectoSeguimiento" runat = "server"  Text ="Denominación" ></asp:Literal>        
                                    </td>
                                    <td>
                                        <asp:Label ID="lbDenominacionProyectoSeguimiento" runat = "server" ></asp:Label>
                                    </td>
                                </tr>
                            </table>
                            
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveProyectoSeguimiento" Text="Aceptar" OnClick="btSaveProyectoSeguimiento_Click" runat="server" ValidationGroup="vgProyectoSeguimiento" />
                            <asp:Button ID="btNewProyectoSeguimiento" Text="Aceptar y Crear Nuevo" OnClick="btNewProyectoSeguimiento_Click" runat="server"
                                ValidationGroup="vgProyectoSeguimiento" />
                            <asp:Button ID="btCancelProyectoSeguimiento" Text="Cerrar" OnClick="btCancelProyectoSeguimiento_Click"
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectoSeguimiento" runat="server" CancelControlID="Button6"
        PopupDragHandleControlID="ProyectoSeguimientoPopUpDragHandle" PopupControlID="PopUpProyectoSeguimiento"
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