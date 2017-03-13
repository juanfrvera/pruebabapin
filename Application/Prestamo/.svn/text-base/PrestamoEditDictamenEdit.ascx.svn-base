<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="PrestamoEditDictamenEdit.ascx.cs"
    Inherits="UI.Web.PrestamoEditDictamenEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="PrestamoDictamen" Src="~/Prestamo/PrestamoDictamenEdit.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProyectoComentarioTecnico" Src="~/Proyecto/ProyectoComentarioTecnicoEdit.ascx" %>
<asp:panel id="pnlDictamen" runat="server" groupingtext="Dictamen">
<asp:UpdatePanel ID= "upGridDictamenes"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
<table width="100%" >
    <tr> 
        <td>
            <asp:GridView ID="gridDictamen" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                AllowPaging="False" OnRowCommand="GridDictamen_RowCommand" OnPageIndexChanging="GridDictamen_PageIndexChanging"
                OnSorting="GridDictamen_Sorting" AllowSorting="True" EmptyDataText="No hay Dictamenes"
                Width="100%">
                <Columns>
                    <asp:BoundField HeaderText="Expediente" DataField="Expediente" SortExpression="Expediente" HeaderStyle-Width ="12%" />
                   <asp:BoundField HeaderText="Calificación" DataField="PrestamoCalificacion_Nombre"
                        SortExpression="PrestamoCalificacion_Nombre" HeaderStyle-Width ="12%" />
                    <asp:BoundField HeaderText="Fechas Alta" DataField="FechaAlta" SortExpression="FechaAlta" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width ="10%"  />
                    <asp:BoundField HeaderText="Monto Total" DataField="MontoTotal" SortExpression="MontoTotal"  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width ="10%"  DataFormatString="{0:N0}"/>
                     <asp:BoundField HeaderText="Monto Prestamo" DataField="MontoPrestamo" SortExpression="MontoPrestamo"  ItemStyle-HorizontalAlign="Right" HeaderStyle-Width ="12%" DataFormatString="{0:N0}"   />
                     <asp:TemplateField  HeaderText="Calificación Observación"  SortExpression="CalificacionObservacion" HeaderStyle-Width ="19%" >            
                        <ItemTemplate>
                            <asp:Label ID="CalificacionObservacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("CalificacionObservacion"),30) %>' ToolTip='<%# Eval("CalificacionObservacion") %>'  ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderText="Calificación Recomendación"  SortExpression="CalificacionRecomendacion" HeaderStyle-Width ="19%" >            
                        <ItemTemplate>
                            <asp:Label ID="CalificacionRecomendacion" runat="server" Text='<%# Contract.DataHelper.CutString((string)Eval("CalificacionRecomendacion"),30) %>' ToolTip='<%# Eval("CalificacionRecomendacion") %>'  ></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField  HeaderStyle-Width ="6%">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID="imgEdit" runat="server" src="../Images/read.png" ToolTip='<%# Translate("Leer") %>'
                                CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            &nbsp;
                        </ItemTemplate>
                        <ItemStyle HorizontalAlign="Right" />
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
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
                            OnSorting="GridProyectoComentarioTecnico_Sorting" OnPageIndexChanging="GridProyectoComentarioTecnico_PageIndexChanging"
                            AllowSorting="True" EmptyDataText="No hay comentarios DNIP" Width="100%">
                            <Columns>
                                <asp:BoundField HeaderText="Tipo" DataField="ComentarioTecnico_Nombre" SortExpression="ComentarioTecnico_Nombre" />
                                <asp:BoundField HeaderText="Fecha" DataField="Fecha" SortExpression="Fecha" DataFormatString="{0:dd/MM/yyyy}"  />
                                <asp:BoundField HeaderText="Usuario" DataField="NombreCompleto" SortExpression="NombreCompleto" />
                                <asp:BoundField HeaderText="Mensaje" DataField="Observacion" SortExpression="Observacion" ItemStyle-Width="45%" />
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
</asp:panel>
<asp:panel id="PopUpDictamen" runat="server" width="1000px" style="background-color: #ffffff;
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
    <asp:Panel DefaultButton="btCancelDictamen" ID="pnDictamen" runat="server">
     <asp:UpdatePanel ID="upDictamenPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Panel ID="pnlPrestamo" runat="server" ScrollBars="Vertical" Height="500px">
                                <uc:PrestamoDictamen ID="pDictamen" runat="server" />
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
</asp:panel>
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