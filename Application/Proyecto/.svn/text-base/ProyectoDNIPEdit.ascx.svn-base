<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoDNIPEdit.ascx.cs"
    Inherits="UI.Web.ProyectoDNIPEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoDictamen" Src="~/Proyecto/ProyectoDictamenEdit.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoPrioridad" Src ="~/Proyecto/ProyectoPriorizacionDNIPEdit.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoComentarioTecnico" Src="~/Proyecto/ProyectoComentarioTecnicoEdit.ascx" %>
<asp:UpdatePanel ID="upDNIP" runat ="server" UpdateMode ="Conditional" >
    <ContentTemplate>
        <table width="100%" >
            <tr>
                <td >
	                <div class="legend" style ="color:#0099ff;font-weight:bold;height:30px;cursor: hand" >
	                    <asp:Label ID="lblDictamen" runat ="server" Text ="Dictamen"  ></asp:Label>
	                    <asp:Image ID ="imgCollapsiblePanel" runat="server"  src="../Images/CollapsiblePanelImg.gif" />
	                </div>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeDictamen" runat="Server"
                        TargetControlID="pnlDictamen"
                        Collapsed="False"
                        ExpandControlID="lblDictamen"
                        CollapseControlID="lblDictamen"
                        AutoCollapse="False"
                        AutoExpand="False"
                        ExpandDirection="Vertical" />
        	    
	                <asp:Panel ID="pnlDictamen" runat = "server"  >
	                    <asp:GridView ID="gridDictamen" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                            AllowPaging="False" OnRowCommand="GridDictamen_RowCommand" OnPageIndexChanging="GridDictamen_PageIndexChanging"
                            OnSorting="GridDictamen_Sorting" AllowSorting="True" EmptyDataText="No hay Dictámenes"
                            Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Nro. Dictamen" DataField="Numero" SortExpression="Numero" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField HeaderText="Calificación" DataField="ProyectoCalificacion_Nombre"
                                    SortExpression="ProyectoCalificacion_Nombre" />
                                <asp:BoundField HeaderText="Vencimiento" DataField="FechaVencimiento" SortExpression="FechaVencimiento" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField HeaderText="Monto" DataField="Monto" SortExpression="Monto" DataFormatString="{0:N0}"/> <%-- Matias 20141125 - Tarea 178 - Se agregó DataFormatString="{0:N0}"--%>
                                <asp:BoundField HeaderText="Nro. IT" DataField="InformeTecnico" SortExpression="InformeTecnico" />
                                <asp:BoundField HeaderText="Estado" DataField ="UltimoEstadoNombre" SortExpression ="UltimoEstadoNombre" />
                                <asp:BoundField HeaderText="Fecha Resp Organismo" DataField ="FechaRepuesta" SortExpression ="FechaRepuesta" DataFormatString="{0:dd/MM/yyyy}" />
                                <%--<asp:BoundField HeaderText="Nro. Resolucion" DataField="FechaVencimiento" SortExpression="FechaVencimiento" />--%>
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Leer") %>'
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
	                <div class="legend" style ="color:#0099ff;font-weight:bold;height:30px;cursor: hand">
	                    <asp:Label ID="lblPriorizacion" runat ="server" Text ="Priorización"  ></asp:Label>&nbsp; <asp:Image ID ="Image1" runat="server"  src="../Images/CollapsiblePanelImg.gif" />
	                </div>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpePriorizacion" runat="Server"
                        TargetControlID="pnlPriorizacion"
                        Collapsed="True"
                        ExpandControlID="lblPriorizacion"
                        CollapseControlID="lblPriorizacion"
                        AutoCollapse="False"
                        AutoExpand="False"
                        ExpandDirection="Vertical" />
	                <asp:Panel ID="pnlPriorizacion" runat ="server" >
	                    <asp:GridView ID="gridProyectoPrioridad" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridProyectoPrioridad_RowCommand"
                            OnPageIndexChanging="GridProyectoPrioridad_PageIndexChanging" OnSorting="GridProyectoPrioridad_Sorting"
                            AllowSorting="True" EmptyDataText="No hay Priorizacion" Width="100%">
                            
                            <Columns>
                                <asp:BoundField HeaderText="Plan Período" DataField="Periodo" SortExpression="Periodo" />
                                <asp:BoundField HeaderText="Resultado" DataField="Resultado" SortExpression="Resultado" />
                                <asp:BoundField HeaderText="Clasificación" DataField="Clasificacion_Nombre" SortExpression="Clasificacion_Nombre" />
                                <asp:TemplateField HeaderText ="Requiere Art 15" >
                                    <ItemTemplate>
                                        <asp:CheckBox ID="chkReqArt15" runat="server" Checked=' <%# Eval("ReqArt15")==null?false:Eval("ReqArt15") %>' Enabled="false"  />
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:BoundField HeaderText="Comentario" DataField="Comentario" SortExpression="Comentario" />
                                <asp:BoundField HeaderText="Fecha" DataField="Proyecto_FechaModificacion" SortExpression="Proyecto_FechaModificacion" DataFormatString="{0:dd/MM/yyyy}" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Leer") %>'
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </asp:Panel>
                </td>
            </tr>
            <tr>
                <td >
	                <div class="legend" style ="color:#0099ff;font-weight:bold;height:30px;cursor: hand" ><asp:Label ID="lbComentarioDNIP" runat ="server" Text ="Comentarios Técnicos"  ></asp:Label>&nbsp; <asp:Image ID ="Image2" runat="server"  src="../Images/CollapsiblePanelImg.gif" /></div>
                    <ajaxToolkit:CollapsiblePanelExtender ID="cpeComentarioDNIP" runat="Server"
                        TargetControlID="pnlComentarioTecnico"
                        Collapsed="True"
                        ExpandControlID="lbComentarioDNIP"
                        CollapseControlID="lbComentarioDNIP"
                        AutoCollapse="False"
                        AutoExpand="False"
                        ExpandDirection="Vertical" />
        	        
	                <asp:Panel ID="pnlComentarioTecnico" runat = "server" >
	                    <asp:GridView ID="gridProyectoComentarioTecnico" runat="server" AutoGenerateColumns="False"
                            DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridProyectoComentarioTecnico_RowCommand"
                            OnSorting="GridProyectoComentarioTecnico_Sorting" OnRowDataBound="GridProyectoComentarioTecnico_RowDataBound" OnPageIndexChanging="GridProyectoComentarioTecnico_PageIndexChanging"
                            AllowSorting="True" EmptyDataText="No hay comentarios DNIP" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo" DataField="ComentarioTecnico_Nombre" SortExpression="ComentarioTecnico_Nombre" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField HeaderText="Usuario" DataField="NombreCompleto" SortExpression="NombreCompleto" />
                                <asp:BoundField HeaderText="Mensaje" DataField="Observacion" SortExpression="Observacion" ItemStyle-Width="45%" />
                                <asp:BoundField DataField="GeneraComentarioTecnico" Visible="false" HeaderText="Genera comentario técnico" SortExpression="GeneraComentarioTecnico" ItemStyle-Width="60%" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID="imgEdit" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Leer") %>'
                                            CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                        &nbsp;
                                        
                                    </ItemTemplate>
                                    <ItemStyle Width="150px" HorizontalAlign="Right" />
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>                    
                    </asp:Panel>
                </td>
            </tr>
        </table>
    </ContentTemplate>
</asp:UpdatePanel>
<asp:Panel ID="PopUpDictamen" runat="server" Width="1050px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="DictamenPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpDictamen" runat="server" Text="Dictamen" />
                </th>
                
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnDictamen" DefaultButton="btCancelDictamen" runat="server">
        <asp:UpdatePanel ID="upDictamenPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlProyecto" runat="server" ScrollBars="Vertical" Height="500px"  >
                                <asp:Panel ID="pnlControlProyecto" runat ="server"  Enabled ="true" >
                                    <uc:ProyectoDictamen ID="pDictamen" runat="server" />
                                </asp:Panel>
                            </asp:Panel>
                        </td>
                    </tr>
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelDictamen" Text="Cerrar" OnClick="btCancelDictamen1_Click" 
                                runat="server" Width="60px" CausesValidation="false"  />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDictamen" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="DictamenPopUpDragHandle" PopupControlID="PopUpDictamen"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
<asp:Panel ID="PopUpProyectoPrioridad" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectoPrioridadPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpProyectoPrioridad" runat="server" 
                        Text="Priorización" />
                </th>
               
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectoPrioridad" DefaultButton="btCancelProyectoPrioridad" runat="server">
        <asp:UpdatePanel ID="upProyectoPrioridadPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlControlProyectoPrioridad" runat ="server" Enabled ="false"   >
                                <uc:ProyectoPrioridad ID="ctlProyectoPrioridad" runat="server"  />
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCancelProyectoPrioridad" Text="Cerrar" OnClick="btCancelProyectoPrioridad1_Click"
                                runat="server" Width="60px" CausesValidation="false"   />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectoPrioridad" runat="server"
        CancelControlID="Button3" PopupDragHandleControlID="ProyectoPrioridadPopUpDragHandle"
        PopupControlID="PopUpProyectoPrioridad" OkControlID="Button3" TargetControlID="Button3"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
<asp:Panel ID="PopUpComentarioTecnico" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ComentarioTecnicoPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Label ID="headerPopUpComentarioTecnico" runat="server" Text="Comentario DNIP" />
                </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnComentarioTecnico" DefaultButton="btCamcelProyectoComentarioTecnico" runat="server">
        <asp:UpdatePanel ID="upComentarioTecnicoPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="Panel1" runat ="server"  Enabled ="false"  >
                                <uc:ProyectoComentarioTecnico ID="ctlProyectoComentarioTecnico" runat="server"  />    
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btCamcelProyectoComentarioTecnico" Text="Cerrar" OnClick="btCancelProyectoComentarioTecnico1_Click"
                                runat="server" Width="60px" CausesValidation="false"   />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderComentarioTecnico" runat="server"
        CancelControlID="Button1" PopupDragHandleControlID="ComentarioTecnicoPopUpDragHandle"
        PopupControlID="PopUpComentarioTecnico" OkControlID="Button1" TargetControlID="Button1"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
