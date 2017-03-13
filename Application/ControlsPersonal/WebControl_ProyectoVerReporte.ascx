<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProyectoVerReporte.ascx.cs" Inherits="UI.Web.WebControl_ProyectoVerReporte" %>

<asp:Panel ID="pnPopupVerReporte" runat="server" Width="600px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color:Gray;">
    <asp:Panel ID="pnPopupVerReporteDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td><asp:Literal ID="liTitle" runat="server" Text="Ver Reportes" ></asp:Literal></td>
            </tr>
        </table>
    </asp:Panel>
    <asp:UpdatePanel ID="upControls" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
           <table width="100%" >
                <tr>
                    <td>
                        <asp:Literal ID="liAnioInicial" runat ="server" Text="Año Inicial del Cronograma" ></asp:Literal>
                    </td>
                    <td>
                        <asp:TextBox ID="txtAnioInicial" Type="text" runat="server" ></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revAnioInicial" ControlToValidate ="txtAnioInicial"  runat ="server" ValidationGroup="vgVerReporte" ></asp:RegularExpressionValidator>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Literal ID="liMonto" runat="server" Text="Montos" ></asp:Literal>
                    </td>
                    <td>
                        <asp:RadioButton ID ="rbEstimados" runat ="server" Text="Sólo Estimados" Checked ="true"   GroupName="gMontos" />
                        <asp:RadioButton ID ="rbRealizados" runat ="server" Text="Sólo Realizados"  GroupName="gMontos" />
                        <asp:RadioButton ID ="rbTodos" runat ="server" Text="Todos"  GroupName="gMontos" />
                    </td>
                </tr>
               <%-- <tr>
                    <td>
                        <asp:CheckBox ID="chkAperturaPresupuestaria" runat ="server" Text ="Concidera Aperturas Presupuestarias" />
                    </td>
                </tr>--%>
                <tr>
                    <td>
                        <asp:Literal ID="liFase" runat = "server" Text ="Fase" ></asp:Literal>
                    </td>
                    <td>
                        <asp:DropDownList ID="ddlFase" runat ="server" ></asp:DropDownList>
                    </td>
                </tr>
                <tr>
                    <td>
                    </td>
                    <td></td>
                </tr>
                <tr>
                    <td colspan ="2" align ="center" >
                        
                        <asp:Button ID="btImprimir" runat ="server" Text="Imprimir" 
                            onclick="btImprimir_Click" ValidationGroup="vgVerReporte"  />
                        <asp:Button ID="btExportar" runat ="server" Text="Exportar" 
                            onclick="btExportar_Click"  />
                        <asp:Button ID="btCancelar" runat ="server" Text="Cancelar" 
                            onclick="btCancelar_Click" />
                    </td>
                    
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>     
    <asp:Button ID="btPopup" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="mpePopupVerReporte" runat="server" CancelControlID="btPopup" PopupDragHandleControlID ="pnPopupVerReporteDragHandle"
    PopupControlID="pnPopupVerReporte" OkControlID="btPopup" TargetControlID="btPopup" BackgroundCssClass="modalBackground" />
</asp:Panel>
