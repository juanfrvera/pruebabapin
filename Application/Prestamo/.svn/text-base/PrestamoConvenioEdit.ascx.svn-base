<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoConvenioEdit.ascx.cs" Inherits="UI.Web.PrestamoConvenioEdit" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>


<div class="TabbedPanelsContent">
<asp:Panel ID="pnlConvenio" runat="server" GroupingText ="Convenios" >
    <asp:UpdatePanel ID="upDatosGenerales" runat = "server" UpdateMode ="Conditional" >
        <ContentTemplate >
           <asp:Panel ID="Panel1" runat="server"  >
            <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0" style ="height:120px">	  	
                             <tr>
                                <td  style=" width:150px"><asp:Literal ID="liOrganismoFinanciero" Text="Organismo Financiero" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td  style=" width:210px" ><cc:ExtendedDropDownList ID="ddlOrganismoFinanciero" 
                                        runat="server" CssClass="field_input" Width="205px" 
                                        OnSelectedIndexChanged="ddlOrganismoFinanciero_SelectedIndexChanged" AutoPostBack="true" ></cc:ExtendedDropDownList></td>
                                <td valign="top">
                                <asp:RequiredFieldValidator ID="rfvOrganismoFinanciero" runat="server" ControlToValidate="ddlOrganismoFinanciero"  ValidationGroup="EditionPrestamoConvenio" Text="*" Width="5px" Height="5px" InitialValue ="0" ></asp:RequiredFieldValidator>
                                 </td>
                            </tr>
                            <tr>
                                <td class="tdLabel"  style=" width:150px" ><asp:Literal ID="liSigla" Text="Sigla" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td  class="filaInput">
                                <asp:TextBox ID="txtSigla" runat = "server" CssClass="field_input" ></asp:TextBox>
                                </td>
                                <td  ><asp:RegularExpressionValidator ID="revSigla" runat="server"   ControlToValidate="txtSigla"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator></td>
                                
                            </tr>
                            <tr>
                                <td><asp:Literal ID="liNumeroConvenio" Text="Número Convenio" runat="server" ></asp:Literal></td>
                                 <td>&nbsp;</td>
                                <td  >
                                <asp:TextBox ID="txtNumeroConvenio" runat = "server" CssClass="field_input"></asp:TextBox>
                                </td>
                                <td valign="middle" ><asp:RegularExpressionValidator ID="revNumeroConvenio" runat="server"   ControlToValidate="txtNumeroConvenio"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px"></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td class="tdLabel"  ><asp:Literal ID="liMontoTotal" Text="Monto Total" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td  class="filaInput">
                                <cc:NumericTextBox runat="server" ID="txtMontoTotal" InputType="PositiveInteger" UseSeparadorMiles="true" Width="200px"></cc:NumericTextBox>
                                 <td align="left" style=" text-align:left;" valign="top"> <asp:RequiredFieldValidator ID="rfvMontoTotal" runat="server" ControlToValidate="txtMontoTotal"  ValidationGroup="EditionPrestamoConvenio"   Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                &nbsp;<asp:RegularExpressionValidator ID="revMontoTotal" runat="server"   ControlToValidate="txtMontoTotal"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            <tr>
                                <td   ><asp:Literal ID="liMontoPrestamo" Text="Monto Préstamo" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td >
                                <cc:NumericTextBox runat="server" ID="txtMontoPrestamo" InputType="PositiveInteger" UseSeparadorMiles="true" Width="200px"></cc:NumericTextBox>
                                 </td>
                                <td valign="top"><asp:RequiredFieldValidator ID="rfvMontoPrestamo" runat="server" ControlToValidate="txtMontoPrestamo"  ValidationGroup="EditionPrestamoConvenio"   Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                &nbsp;
                                <asp:RegularExpressionValidator ID="revMontoPrestamo" runat="server"   ControlToValidate="txtMontoPrestamo"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                            
                        </table>        
                    </td>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0" style ="height:120px" >	  	
                            
                            
                            <tr>
                                <td style=" width:150px" ><asp:Literal ID="liMoneda" Text="Moneda" runat="server" ></asp:Literal></td>
                                 <td>&nbsp;</td>
                                <td  class="filaInput">
                                    <cc:ExtendedDropDownList ID="ddlMoneda" runat="server" CssClass="field_input" Width="205px"></cc:ExtendedDropDownList>
                                </td>
                                <td valign="middle"><asp:RequiredFieldValidator ID="rfvMoneda" runat="server" ControlToValidate="ddlMoneda"  ValidationGroup="EditionPrestamoConvenio" Text="*" Width="5px" Height="5px" InitialValue ="0" ></asp:RequiredFieldValidator></td>
                             </tr>
                             <tr>
                                <td  ><asp:Literal ID="liModalidad" Text="Modalidad" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td  >
                                    <cc:ExtendedDropDownList ID="ddlModalidad" runat="server" CssClass="field_input" Width="205px" ></cc:ExtendedDropDownList>
                                </td>
                               <%-- <td valign="top" >
                                <!--Matias 20140425 - Tarea 139-->
                                <asp:RequiredFieldValidator ID="rfvModalidad" runat="server" ControlToValidate="ddlModalidad"  ValidationGroup="EditionPrestamoConvenio" Text="*" Width="5px" Height="5px" InitialValue ="0" ></asp:RequiredFieldValidator>                                
                                </td>  --%>                              
                             </tr>
                            <tr>
                                <td class="tdLabel" valign="top"  ><asp:Literal ID="liDatosModalidad" Text="Datos de Modalidad" runat="server" ></asp:Literal></td>
                                <td>&nbsp;</td>
                                <td  class="filaInput">
                                <asp:TextBox ID="txtDatosModalidad" runat = "server" CssClass="field_input" TextMode="MultiLine" Rows="2" ></asp:TextBox>
                                </td>
                                <td > <asp:RegularExpressionValidator ID="revDatosModalidadFinanciera" runat="server"   ControlToValidate="txtDatosModalidad"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator></td>
                                
                            </tr>
                            <tr style ="height:33px">
                                <td >&nbsp;</td>
                            </tr>
                        </table>        
                    </td>
                </tr> 
                <tr>
                    <td  colspan="2">
                        <table cellpadding="0" cellspacing="5px" border="0" >	  	
                             <tr>
                                <td class="tdLabel" style=" width:170px"  valign="top" ><asp:Literal ID="liObservacion" Text="Observaciones" runat="server" ></asp:Literal></td>
                                <td style=" width:10px">&nbsp;</td>
                                <td  class="filaInput"  style=" width:690px">
                                <asp:TextBox ID="txtObservacion" runat = "server" CssClass="field_input" TextMode="MultiLine" Rows="3" Width="680px"></asp:TextBox>
                                </td>
                                <td style=" width:10px" ><asp:RegularExpressionValidator ID="revObservacion" runat="server"   ControlToValidate="txtObservacion"  ValidationGroup="EditionPrestamoConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                </td>
                            </tr>
                        </table>
                   </td>
                </tr>       	

            </table>  
            </asp:Panel>
    </ContentTemplate>
</asp:UpdatePanel>

<%--SubConvenios--%>
<asp:UpdatePanel ID="upSubCovenio" runat = "server" UpdateMode ="Conditional" >
    <ContentTemplate >    
        <asp:Panel ID="pnlSubCovenioGral" runat = "server" >
            <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                <tr>
                    <td class="legend" style ="color:#0099ff;font-weight:bold;">
                        <div style=" cursor: hand; width: 190px" ><asp:Label ID="lblSubCovenio" runat ="server" Text ="SubConvenio" ></asp:Label>&nbsp; <asp:Image ID ="Image2" runat="server"  src="../Images/CollapsiblePanelImg.gif" /></div>
                        <ajaxToolkit:CollapsiblePanelExtender ID="cpeSubCovenio" runat="Server"
                            TargetControlID="pnlSubCovenio"
                            Collapsed="True"
                            ExpandControlID="lblSubCovenio"
                            CollapseControlID="lblSubCovenio"
                            AutoCollapse="False"
                            AutoExpand="False"
                            ExpandDirection="Vertical" />
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:Panel ID="pnlSubCovenio" runat = "server" >
                            <table width ="100%" >
                                <tr>
                                    <td align ="right" >
                                        <asp:Button ID="btAgregarSubCovenio" runat = "server" Text = "Agregar" onclick="btAgregarSubConvenio_Click" />
                                    </td>
                                </tr>
                                    <tr>
                                      <td>
                                         <asp:UpdatePanel ID= "upGridSubConvenios"  runat="server" UpdateMode = "Conditional" >
                                            <ContentTemplate>
                                                <asp:GridView ID="gridSubConvenios" runat = "server"
                                                    AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
                                                    OnRowCommand="GridSubConvenios_RowCommand"    
                                                    AllowSorting="True" OnSorting="GridSubConvenios_Sorting"
                                                    OnPageIndexChanging="GridSubConvenios_PageIndexChanging" 
                                                    EmptyDataText="No hay SubConvenios definidos" 
                                                    Width ="100%">
                                                    <Columns>
                                                        <asp:BoundField HeaderText ="Código" DataField ="Codigo" SortExpression ="Codigo"  HeaderStyle-Width="10%"  />
                                                        <asp:BoundField HeaderText ="Descripción" DataField ="Descripcion" SortExpression ="Descripcion" HeaderStyle-Width="15%" />
                                                        <asp:BoundField HeaderText ="Tipo" DataField ="TipoSubConvenio_Nombre" SortExpression ="TipoSubConvenio_Nombre" HeaderStyle-Width="10%"  />
                                                        <asp:BoundField HeaderText ="Ejecutor" DataField ="Ejecutor" SortExpression ="Ejecutor" HeaderStyle-Width="14%" />
                                                        <asp:BoundField HeaderText ="Contraparte" DataField ="Contraparte" SortExpression ="Contraparte" HeaderStyle-Width="10%" />
                                                        <asp:BoundField HeaderText ="Monto Total" DataField ="MontoTotal" SortExpression ="MontoTotal" HeaderStyle-Width="12%" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" />
                                                        <asp:BoundField HeaderText ="Monto Préstamo" DataField ="MontoPrestamo" SortExpression ="MontoPrestamo"  HeaderStyle-Width="12%" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" />
                                                         <asp:BoundField HeaderText ="Fecha" DataField ="Fecha" SortExpression ="Fecha" DataFormatString="{0:dd/MM/yyyy}" HeaderStyle-Width="10%" />
                                                            <asp:TemplateField>
                                                                <HeaderTemplate>
                                                                </HeaderTemplate>
                                                                <ItemTemplate>
                                                                    &nbsp;
                                                                    <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                                                    &nbsp;
                                                                    <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                                                </ItemTemplate>            
                                                                <ItemStyle Width="60px"  HorizontalAlign ="Right"/>
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
</asp:Panel>
</div>
<%--PANEL SUBCONVENIOS --%>
<asp:Panel ID="PopUpSubConvenios" runat="server" Width="720px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="SubConveniosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpSubConvenios" runat="server" Text="SubConvenio" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnSubConvenios" DefaultButton="btSaveSubConvenios" runat="server">
        <asp:UpdatePanel ID="upSubConveniosPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" >
                    <tr>
                        <td >
                            <table>
                                <tr>
                                    <td ><asp:Literal ID="liCodigo" Text="Código" runat="server" ></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td><asp:TextBox ID="txtCodigo" runat = "server" CssClass="field_input" ></asp:TextBox></td>
                                    <td valign="middle" style="width:10px">
                                        <asp:RequiredFieldValidator ID="rfvCodigo" runat="server" ControlToValidate="txtCodigo"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revCodigo" runat="server"   ControlToValidate="txtCodigo"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td  valign="top"  ><asp:Literal ID="liDescripcion" Text="Descripción" runat="server" ></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td  colspan="5">
                                         <asp:TextBox ID="txtDescripcion" TextMode= "MultiLine" Rows="2" runat = "server" CssClass="field_input"  Width="585px" ></asp:TextBox>
                                    </td>
                                    <td valign="middle">
                                        <asp:RequiredFieldValidator ID="rfvDescripcion" runat="server" ControlToValidate="txtDescripcion"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px" ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revDescripcion" runat="server"   ControlToValidate="txtDescripcion"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Literal ID="liTipo" Text="Tipo" runat="server" ></asp:Literal></td>
                                     <td > &nbsp;</td>
                                    <td ><cc:ExtendedDropDownList ID="ddlTipo" runat="server" CssClass="field_input" Width="205px" ></cc:ExtendedDropDownList></td>
                                    <td valign="middle">
                                          <asp:RequiredFieldValidator ID="rfvTipo" runat="server" ControlToValidate="ddlTipo"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px" InitialValue ="0" ></asp:RequiredFieldValidator>
                                         <asp:RequiredFieldValidator ID="rfvTipo1" runat="server" ControlToValidate="ddlTipo"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px" InitialValue ="" ></asp:RequiredFieldValidator>
                                        &nbsp;
                                    </td>
                                    <td><asp:Literal ID="liFecha" Text="Fecha" runat="server" ></asp:Literal></td>
                                    <td> &nbsp; </td>
                                    <td>
                                        <uc:DateInput ID="diFechaSubConvenio" runat="server" ValidationGroup="vgSubConvenio"
                                            IsValidEmpty="true" />
                                    </td>
                                </tr>
                                 <tr>
                                    <td ><asp:Literal ID="liEjecutor" Text="Ejecutor" runat="server" ></asp:Literal></td>
                                    <td  >&nbsp;</td>
                                    <td ><asp:TextBox ID="txtEjecutor" runat = "server" CssClass="field_input" ></asp:TextBox></td>
                                    <td valign="middle" >
                                        <asp:RequiredFieldValidator ID="rfvEjecutor" runat="server" ControlToValidate="txtEjecutor"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="revEjecutor" runat="server"   ControlToValidate="txtEjecutor"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                    <td><asp:Literal ID="liContraparte" Text="Contraparte" runat="server" ></asp:Literal></td>
                                    <td  >&nbsp;</td>
                                    <td ><asp:TextBox ID="txtContraparte" runat = "server" CssClass="field_input" ></asp:TextBox></td>
                                    <td valign="bottom" style="width:10px">
                                        <asp:RequiredFieldValidator ID="rfvContraparte" runat="server" ControlToValidate="txtContraparte"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revContraparte" runat="server"   ControlToValidate="txtContraparte"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td><asp:Literal ID="liMontoTotalSubConvenio" Text="Monto Total" runat="server" ></asp:Literal></td>
                                    <td>&nbsp;</td>
                                    <td>
                                   <cc:NumericTextBox runat="server" ID="txtMontoTotalSubConvenio" InputType="PositiveInteger" UseSeparadorMiles="true" Width="200px"></cc:NumericTextBox>
                                  </td>
                                    <td valign="middle">
                                        <asp:RequiredFieldValidator ID="rfvMontoTotalSubConvenio" runat="server" ControlToValidate="txtMontoTotalSubConvenio"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="revMontoTotalSubConvenio" runat="server"   ControlToValidate="txtMontoTotalSubConvenio"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                        &nbsp;
                                    </td>
                                    <td ><asp:Literal ID="liMontoPrestamoSubConvenio" Text="Monto Préstamo" runat="server" ></asp:Literal></td>
                                    <td >&nbsp;</td>
                                    <td ><cc:NumericTextBox runat="server" ID="txtMontoPrestamoSubConvenio" InputType="PositiveInteger" UseSeparadorMiles="true" Width="200px"></cc:NumericTextBox>
                                    </td>
                                    <td valign="bottom" style="width:10px">
                                        <asp:RequiredFieldValidator ID="rfvMontoPrestamoSubConvenio" runat="server" ControlToValidate="txtMontoPrestamoSubConvenio"  ValidationGroup="vgSubConvenio" Text="*" Width="5px" Height="5px"  ></asp:RequiredFieldValidator>
                                        <asp:RegularExpressionValidator ID="revMontoPrestamoSubConvenio" runat="server"   ControlToValidate="txtMontoPrestamoSubConvenio"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px" ></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                                <tr>
                                    <td valign="top"  ><asp:Literal ID="liObservaciones" Text="Observaciones" runat="server" ></asp:Literal></td>
                                    <td >&nbsp;</td>
                                    <td   colspan="5" >
                                         <asp:TextBox ID="txtObservaciones" TextMode= "MultiLine" Rows="3" runat = "server" CssClass="field_input"  Width="585px" ></asp:TextBox>
                                    </td>
                                     <td >&nbsp;
                                        <asp:RegularExpressionValidator ID="revObservaciones" runat="server"   ControlToValidate="txtObservaciones"  ValidationGroup="vgSubConvenio"  Text="*" Width="5px" Height="5px"></asp:RegularExpressionValidator>
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveSubConvenios" Text="Aceptar" OnClick="btSaveSubConvenio_Click" runat="server" ValidationGroup="vgSubConvenio" />
                            <asp:Button ID="btNewSubConvenios" Text="Aceptar y Agregar Nuevo" OnClick="btNewSubConvenio_Click" runat="server" ValidationGroup="vgSubConvenio" />
                            <asp:Button ID="btCancelSubConvenios" Text="Cerrar" OnClick="btCancelSubConvenio_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSubConvenios" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="SubConveniosPopUpDragHandle" PopupControlID="PopUpSubConvenios"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>
