﻿<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoEstadoEdit.ascx.cs" Inherits="UI.Web.Proyecto.ProyectoSeguimientoEstadoEdit" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeSelect" Src="~/Controls/WebControl_TreeSelect.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>


<asp:Panel ID="pnlProyectoSeguimientoEstado" runat ="server"  GroupingText ="Seguimiento de Estados" >
    <asp:UpdatePanel ID="upGridProyectoSeguimientoEstado" runat = "server" >
        <ContentTemplate >
            <table width="100%">
                <tr>
                    <td>
                        <asp:Panel ID= "pnlGridProyectoSeguimientoEstado" runat = "server" ScrollBars ="Vertical" Height ="300px" >
                            <asp:GridView 
                            ID="gridProyectoSeguimientoEstado" 
                            runat ="server" 
                            AutoGenerateColumns="False" 
                            DataKeyNames="ID" 
                            AllowPaging="False" 
                            OnRowCommand="GridProyectoSeguimientoEstado_RowCommand"   
                            OnRowDataBound ="GridProyectoSeguimientoEstado_RowDataBound"     
                            AllowSorting="False"
                            OnSorting="GridProyectoSeguimientoEstado_Sorting"
                            OnPageIndexChanging="GridProyectoSeguimientoEstado_PageIndexChanging" 
                            EmptyDataText="No hay Estados definidos" 
                            Width ="100%"
                        >
                            <Columns >
                                <asp:BoundField DataField ="Estado_Nombre" HeaderText ="Estado" SortExpression ="Estado_Nombre" />
                                <asp:BoundField DataField ="Fecha" HeaderText ="Fecha" SortExpression ="Fecha" DataFormatString="{0:dd/MM/yyyy}"   />
                                <asp:BoundField DataField ="Persona_ApellidoYNombre" HeaderText = "Usuario" SortExpression = "Persona_ApellidoYNombre" />
                                <asp:BoundField DataField ="Observacion" HeaderText ="Comentario" SortExpression ="Observacion" />
                                <asp:BoundField DataField ="GeneraComentarioTecnico" HeaderText ="Genera Comentario Técnico" SortExpression ="GeneraComent" />
                                <asp:TemplateField HeaderStyle-Width ="7%">
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID ="imgView" runat ="server"  src="../Images/view.png" ToolTip ="Ver" CommandName='<%# Command.READ %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                        &nbsp;
                                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" Enabled='<%# EnableProyectoSeguimientoEstadoDelete %>'  />            
                                    </ItemTemplate>            
                                    <ItemStyle  HorizontalAlign ="Right"/>
                                </asp:TemplateField>
                            </Columns>

                        </asp:GridView>
                        </asp:Panel>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
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
    <asp:Panel ID="pnEstados" DefaultButton="btCancelEstados" runat="server">
        <asp:UpdatePanel ID="upEstadosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td class="style1">
                            <div>
                                <asp:Literal ID="liEstadoPopUpEstado" runat = "server" Text ="Estado"  ></asp:Literal>
                            </div>
                            <div>
                                <cc:ExtendedDropDownList ID="ddlEstadoPopUpEstado" runat = "server" Enabled ="false"  ></cc:ExtendedDropDownList>
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
                                <cc:ExtendedDropDownList ID="ddlUsuarioPopUpEstado" runat = "server" Enabled ="false"  ></cc:ExtendedDropDownList>
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
                            <div  >
                                <asp:Panel ID="pnlFechaPopUp" runat ="server" Enabled ="false" >
                                    <uc:DateInput ID="diFechaPopUpEstado" runat = "server" IsValidEmpty="false" ValidationGroup ="vgEstados"  />
                                </asp:Panel>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <asp:Literal ID ="liComentarioPopUpEstado" runat ="server" Text ="Comentario" ></asp:Literal>
                    </tr>
                    <tr>
                        <td colspan ="3">
                            <asp:TextBox ID="txtComentario" runat ="server" Rows ="10" Width ="100%" TextMode="MultiLine" Enabled ="false"  ></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Genera Comentario Técnico<asp:CheckBox ID="chkGeneraComent" runat ="server" Enabled ="false"  ></asp:CheckBox>
                        </td>
                    </tr>
                    
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btCancelEstados" Text="Cerrar" OnClick="btCancelProyectoSeguimientoEstado_Click"
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSeguimientoEstado" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="EstadosPopUpDragHandle" PopupControlID="PopUpEstados"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
