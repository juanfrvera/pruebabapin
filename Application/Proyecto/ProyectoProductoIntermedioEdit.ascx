<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoProductoIntermedioEdit.ascx.cs"  Inherits="UI.Web.ProyectoProductoIntermedioEdit" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlEjecucion" runat="server" GroupingText ="Inversión Física" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <asp:Panel Width="300" ID="PnelProy" runat="server" GroupingText ="¿Es un proyecto presupuestario?" >
                    <asp:UpdatePanel ID= "UpdatePanelProy"  runat="server" UpdateMode = "Conditional" >
                    <ContentTemplate>
                        <asp:CheckBox runat="server" ID="cbEsProyecto" OnCheckedChanged="cbEsProyecto_OnCheckedChanged" AutoPostBack="true" />&nbsp;&nbsp;<asp:Literal runat="server" ID="litProy" Text="Si" ></asp:Literal>
                        &nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;
                        <asp:Literal runat="server" ID="ltNro" Text="Cód." ></asp:Literal>
                        &nbsp;&nbsp;
                        <asp:TextBox runat="server" Type="text" ID="tbNroProyecto" Width="65"></asp:TextBox>
                        <asp:RegularExpressionValidator ID="revNroProyecto" runat="server"   ControlToValidate="tbNroProyecto"  ValidationGroup="EditionProyectoProductoIntermedio"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                    </ContentTemplate>
                    </asp:UpdatePanel>
                </asp:Panel>
            </td>            
        </tr>
    </table>      
    <asp:UpdatePanel ID= "upGridEjecucion"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
     <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
         <tr>        
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarEjecucion" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarEjecucion" runat ="server" Text="Agregar" OnClick="btAgregarEjecucion_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr> 
                </table>        
            </td>
        </tr>        
    </table>      
        <%-- Matias 20131101 - Tarea 12 - Esto es para la ETAPA (antes de definir el Detalle) - Antes: AllowPaging="True" y AllowSorting="True" en todos! Width="100%" --%>
        <asp:GridView ID="gridEjecucion" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="False" 
            OnRowCommand="GridEjecucion_RowCommand" OnRowDataBound="GridEjecucion_OnRowDataBound"     
            AllowSorting="False" OnSorting="GridEjecucion_Sorting"
            OnPageIndexChanging="GridEjecucion_PageIndexChanging" 
            EmptyDataText="No hay producto intermerdio definido"
            Width ="98%">
            <Columns>
                <asp:TemplateField   HeaderText=""  SortExpression=""  HeaderStyle-Width ="4%">            
                    <ItemTemplate>                        
                        <asp:RadioButton id="rbEtapa" runat="server" GroupName="grupoRadioEtapa" OnCheckedChanged="rbEtapa_OnCheckedChanged" AutoPostBack="true" Checked="true"  />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:BoundField HeaderText ="Descripción" DataField ="Nombre" SortExpression ="Nombre" ItemStyle-Width="500"/>                
                <asp:BoundField HeaderText ="Cat. Pres." DataField ="Tipo" SortExpression ="Cat. Pres."  ItemStyle-Width="70" />
                 <asp:BoundField HeaderText ="Cód" DataField ="NroEtapaConCeros" SortExpression ="NroEtapa" ItemStyle-HorizontalAlign="Center" />                                
                <asp:BoundField HeaderText ="Código Vinculación" DataField ="CodigoVinculacion" SortExpression ="CodigoVinculacion" />                
                <asp:TemplateField>
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;
                        <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                        &nbsp;
                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%# GetMensajeEliminar((Int32)Eval("ID")) %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                    </ItemTemplate>            
                    <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
                </asp:TemplateField>
             </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <br/>
    <asp:Panel ID="pnlEtapaIndicadorCompose" runat="server" GroupingText="Detalle">
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                    <tr>                      
                        <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarEtapaIndicadorCompose" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btExportarDetalle" runat ="server" Text="Exportar Excel" OnClick="btExportarDetalle_Click" TabIndex ="1"/> 
                                <asp:Button ID="btAgregarEtapaIndicadorCompose" runat ="server" Text="Agregar" OnClick="btAgregarEtapaIndicadorCompose_Click" TabIndex ="2"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
                        </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>
    <asp:UpdatePanel ID= "upGridIndicadoresEtapa"  runat="server" UpdateMode = "Conditional" >
        <ContentTemplate>
            <div style="overflow:auto; width:920px; height:180px"> <%-- Matias 20131101 - Tarea 16 - Nueva linea mas AllowPaging y AllowSorting en "False" --%>
            <asp:GridView ID="gridIndicadoresEtapa" runat = "server"
                AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="False"  
                OnRowCommand="GridIndicadoresEtapa_RowCommand"   
                AllowSorting="False" OnSorting="GridIndicadoresEtapa_Sorting"
                OnPageIndexChanging="GridIndicadoresEtapa_PageIndexChanging" 
                EmptyDataText="No hay elementos definidos" 
                Width ="100%">
                <Columns> 
                    <asp:BoundField HeaderText ="Descripción" DataField ="Descripcion" SortExpression ="Descripcion"  HeaderStyle-Width="350px"/>
                    <asp:BoundField HeaderText ="Contratista" DataField ="Contratista" SortExpression ="Contratista"  />
                    <asp:BoundField HeaderText ="Expediente" DataField ="NroExpediente" SortExpression ="NroExpediente"  />
                    <asp:BoundField HeaderText ="Monto Del Contrato" DataField ="MontoContrato" SortExpression ="MontoContrato" DataFormatString="{0:N0}" ItemStyle-HorizontalAlign="Right" />
                    <asp:TemplateField HeaderStyle-Width="110px">
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID="imgEvoloucion" runat="server" src="../Images/evolution.png"
                            ToolTip="Evolución" CommandName='<%# Command.SHOW_DETAILS %>' CommandArgument='<%#Eval("ID")%>'
                            CausesValidation="false" />
                            &nbsp;
                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                            &nbsp;
                            <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick="return confirm('Está seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                        </ItemTemplate>            
                        <ItemStyle Width="110px"  HorizontalAlign ="Right"/>
                    </asp:TemplateField>
                </Columns>
                </asp:GridView>
            </div> <%-- Matias 20131101 - Tarea 16 - Nueva linea --%>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:Panel>
</asp:Panel>

<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <tr>
        <td>
            <div class="CollapsiblePanelTab" >
                <span id="spanGastos">
                    <asp:Label ID="lblGastos" runat ="server" Text ="Otros Gastos" ></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />                    
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeGastos" runat="Server"
                    TargetControlID="pnlGastos"
                    Collapsed="True"
                    ExpandControlID="spanGastos"
                    CollapseControlID="spanGastos"
                    AutoCollapse="False"
                    AutoExpand="False"
                    ExpandDirection="Vertical" />                
            </div>
        </td>
    </tr>
    <tr>
        <td>
            <asp:Panel ID="pnlGastos" runat = "server">
                <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                            <tr>                      
                                <td  align ="right" >
                                    <asp:UpdatePanel ID="pnlAgregarGastos" runat = "server" UpdateMode ="Conditional" >
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarGastos" runat ="server" Text="Agregar" OnClick="btAgregarGasto_Click" TabIndex ="2"/> 
                                    </ContentTemplate>
                                    </asp:UpdatePanel>	                    
                                </td>
                            </tr>
                        </table>        
                    </td>
                </tr>        
            </table>
            <asp:UpdatePanel ID= "upGridGastos"  runat="server" UpdateMode = "Conditional" >
                <ContentTemplate>
                    <asp:GridView ID="gridGastos" runat = "server"
                        AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="False" 
                        OnRowCommand="GridGastos_RowCommand"    
                        AllowSorting="False" OnSorting="GridGastos_Sorting"
                        OnPageIndexChanging="GridGastos_PageIndexChanging" 
                        EmptyDataText="No hay Gastos definidos" 
                        Width ="100%">
                        <Columns>
                            <asp:BoundField HeaderText ="Fase" DataField ="Fase_Nombre" SortExpression ="Fase_Nombre" ItemStyle-Width="70" />
                            <asp:BoundField HeaderText ="Etapa" DataField ="Tipo" SortExpression ="Tipo" ItemStyle-Width="70" />
                            <asp:BoundField HeaderText ="Descripción" DataField ="Nombre" SortExpression ="Nombre"  ItemStyle-Width="500" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                        &nbsp;
                                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick="return confirm('Está seguro de eliminar?');" CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                    </ItemTemplate>            
                                    <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
                                </asp:TemplateField>
                            </Columns>
                        </asp:GridView>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
        </td>
    </tr>
</table>
</div>

<%--PANEL ALTA EJECUCION --%>
<asp:Panel ID="PopUpEjecucion" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EjecucionPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEjecucion" runat="server" Text="Inversión Física" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEjecucion" Height="250px" DefaultButton="btSaveEjecucion" runat="server">
        <asp:UpdatePanel ID="upEjecucionPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" 
                    style="margin-left:20px;margin-right:20px;margin-bottom:20px">
                    <tr>
                        <td>                                
                            <table>
                                <tr>
                                    <td colspan="2">
                                        <br />
                                        <asp:Literal ID="lblTipoEtapaEjecucion" runat="server" 
                                            Text="Categoría Presupuestaria"></asp:Literal>
                                        <br />
                                        <asp:DropDownList ID="ddlEtapa" runat="server">
                                        </asp:DropDownList>
                                    </td>
                                </tr>
                                <tr>
                                    <td>
                                        <asp:Literal ID="litNroEjecucion" runat="server" Text="Cód Presupuestario"></asp:Literal>
                                        <br />
                                        <asp:TextBox ID="tbNroEjecucion" Type="text" runat="server" MaxLength="2" Width="40"></asp:TextBox>
                                        &nbsp;
                                        <asp:RegularExpressionValidator ID="revNroEjecucion" runat="server" 
                                            ControlToValidate="tbNroEjecucion" Height="1px" Text="*" 
                                            ValidationGroup="vgEjecucion" Width="1px"></asp:RegularExpressionValidator>
                                    </td>
                                    <td>
                                    </td>
                                    <asp:Label ID="lblError" runat="server" style="color:Red;font-size:12px" 
                                        Text="" Visible="false"></asp:Label>
                                </tr>
                            </table>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litDesc2" runat="server" Text="Descripción"></asp:Literal>
                            <br />
                            <asp:TextBox ID="tbDescripcionEjecucion" runat="server" Width="500"></asp:TextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="litVinculacion" runat="server" Text="Cód. Vinculación"></asp:Literal>
                            <br />
                            <asp:TextBox ID="tbCodeVinculacionEjecucion" runat="server" MaxLength="20" 
                                Width="70"></asp:TextBox>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">
                            <asp:Button ID="btSaveEjecucion" runat="server" OnClick="btSaveEjecucion_Click" 
                                Text="Aceptar" ValidationGroup="vgEjecucion" />
                            <asp:Button ID="btNewEjecucion" runat="server" OnClick="btNewEjecucion_Click" 
                                Text="Aceptar y Agregar Nuevo" ValidationGroup="vgEjecucion" Visible="false" />
                            <asp:Button ID="btCancelEjecucion" runat="server" 
                                OnClick="btCancelEjecucion_Click" Text="Cerrar" Width="60px" />
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEjecucion" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="EjecucionPopUpDragHandle" PopupControlID="PopUpEjecucion"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA DETALLE --%>
<asp:Panel ID="PopUpIndicadoresEtapa" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="IndicadoresEtapaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Literal ID="headerPopUpIndicadoresEtapa" runat="server" Text="Detalle" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnIndicadoresEtapa" DefaultButton="btSaveIndicadoresEtapa" runat="server">
        <asp:UpdatePanel ID="upIndicadoresEtapaPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" cellpadding="4px" style="margin:10px;margin-left:35px" >
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblDesc" Text="Descripción"></asp:Label><br/>
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="IND_tbDescripcion"  Width="550px" TabIndex="1" ></asp:TextBox> &nbsp
                            <asp:RequiredFieldValidator ID="rfvDescripcionEtapa" runat="server" ControlToValidate="IND_tbDescripcion"  ValidationGroup="vgIndicadoresEtapa"  Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                        </td>
                    </tr>
                    <tr>
                        <td style="width:150px">
                            <asp:Label runat="server" id="lblUnidad" Text="Unidad"></asp:Label><br/>
                        </td>
                        <td colspan="3">
                            <asp:DropDownList runat="server" ID="IND_ddlUnidad" Width="50px" TabIndex="2"></asp:DropDownList>&nbsp;&nbsp;
                            <asp:Label runat="server" id="lblMagnitud" Text="Magnitud"></asp:Label>&nbsp;&nbsp;                        
                            <cc:NumericTextBox runat="server" ID="IND_txtMagnitud" InputType="PositiveInteger" UseSeparadorMiles="true" Width="60px" TabIndex="3"></cc:NumericTextBox>
                        
                        </td>                        
                    </tr>
                <%--<tr>
                        <td colspan="4">
                            <asp:Label runat="server" id="lblMedio" Text="Medio de Verificación"></asp:Label><br />
                            <asp:DropDownList runat="server" ID="IND_ddlMedioVerificacion" SkinID="AnchoLibre" Width="92%"></asp:DropDownList>
                        </td>
                    </tr> --%>            
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblExpediente" Text="Nro. Expediente/Licitación"></asp:Label>  
                         </td>
                        <td>
                            <asp:TextBox runat="server" ID="IND_tbExpediente" MaxLength="50" TabIndex="4"></asp:TextBox>&nbsp
                        </td>
                        <td>
                            <asp:Label runat="server" id="lblMoneda" Text="Moneda"></asp:Label><br/>
                        </td>
                        <td>
                            <asp:DropDownList runat="server" ID="IND_ddlMoneda" TabIndex="5"></asp:DropDownList>
                        </td>                                       
                    </tr>                           
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblFechaLici" Text="Fecha Licitación"></asp:Label>
                        </td>
                        <td>
                            <uc:DateInput ID="IND_diFechaLicitacion" runat="server" Width="100px" TabIndex="6"
                            ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false" /> <!-- Matias 20150120 - Tarea 191 - NewSent "ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false""-->
                        </td>         
                        <td>
                            <asp:Label runat="server" id="lblFechaCont" Text="Fecha Contratación"></asp:Label>
                        </td>
                        <td>
                            <uc:DateInput ID="IND_diFechaContratacion" runat="server" Width="100px" TabIndex="7" 
                            ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false" /> <!-- Matias 20150120 - Tarea 191 - NewSent "ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false""-->
                        </td>                        
                    </tr>
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblContra" Text="Contratista"></asp:Label>
                        </td>
                        <td colspan="3">
                            <asp:TextBox runat="server" ID="IND_tbContratista" MaxLength="120" Width="525px" TabIndex="8"></asp:TextBox>
                        </td>                        
                    </tr>                            
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblInicio" Text="F. Inicio Ejec. Obra"></asp:Label>
                        </td>
                        <td>
                            <uc:DateInput ID="IND_diFechaInicioObra" runat="server" Width="100px" TabIndex="9" 
                            ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false" /> <!-- Matias 20150120 - Tarea 191 - NewSent "ValidationGroup="vgIndicadoresEtapa" IsValidEmpty="false""-->
                        </td>
                        <td>
                            <asp:Label runat="server" id="lblPlazo" Text="Plazo Ejecución"></asp:Label>
                        </td>
                        <td>
                            <asp:TextBox runat="server" ID="IND_tbPlazo" MaxLength="200" Width="100px" TabIndex="10"></asp:TextBox>
                        </td>    
                    </tr>        
                    <tr>
                        <td>
                            <asp:Label runat="server" id="lblMContrato" Text="Monto Contrato"></asp:Label>  
                         </td>
                        <td>
                            <cc:NumericTextBox runat="server" ID="IND_txtMContrato"  InputType="PositiveInteger" UseSeparadorMiles="true" Width="100px" TabIndex="11"></cc:NumericTextBox>                            
                        </td>
                        <td>
                            <asp:Label runat="server" id="lblMVigente" Text="Monto Vigente"></asp:Label><br/>
                        </td>
                        <td>
                            <cc:NumericTextBox runat="server" ID="IND_txtMVigente" InputType="PositiveInteger" UseSeparadorMiles="true" Width="100px" TabIndex="12"></cc:NumericTextBox>
                        </td>                                       
                    </tr>                                                                   
                    <tr>             
                        <td colspan="4">
                            <asp:Label runat="server" id="lblObser" Text="Observaciones"></asp:Label><br/>
                            <asp:TextBox runat="server" TextMode="MultiLine" Rows="3" ID="IND_tbObservaciones" Width="700px" TabIndex="13"></asp:TextBox>
                        </td>                        
                    </tr>                    
                    <tr>             
                        <td colspan="4">
                            <asp:Label runat="server" ID="lblErrorEtapaIndicadorCompose" Text="" Visible="false"></asp:Label>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveIndicadoresEtapa" Text="Aceptar" OnClick="btSaveEtapaIndicadorCompose_Click" runat="server" ValidationGroup="vgIndicadoresEtapa" />
                            <asp:Button ID="btNewIndicadoresEtapa" Text="Aceptar y Agregar Nuevo" OnClick="btNewEtapaIndicadorCompose_Click" runat="server" ValidationGroup="vgIndicadoresEtapa" />
                            <asp:Button ID="btCancelIndicadoresEtapa" Text="Cerrar" OnClick="btCancelEtapaIndicadorCompose_Click" runat="server" Width="60px" />                                
                            <br/><br/>
                        </td>
                    </tr>
                </table>
                <br/>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadoresEtapa" runat="server" CancelControlID="Button5"
        PopupDragHandleControlID="IndicadoresEtapaPopUpDragHandle" PopupControlID="PopUpIndicadoresEtapa"
        OkControlID="Button5" TargetControlID="Button5" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA GASTOS --%>
<asp:Panel ID="PopUpGastos" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="GastosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpGastos" runat="server" Text="Otros Gastos" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnGastos" Height="200px" DefaultButton="btSaveGastos" runat="server">
        <asp:UpdatePanel ID="upGastosPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" style="margin:20px" >
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:Literal runat="server" ID="litFase" Text="Fase"></asp:Literal></td>
                                    <td><cc:ExtendedDropDownList ID="ddlFase" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlFase_OnSelectedIndexChanged" ></cc:ExtendedDropDownList></td>        
                                </tr>                            
                                <tr>
                                    <td><asp:Literal runat="server" ID="ltTipo2" Text="Etapa"></asp:Literal></td>
                                    <td><cc:ExtendedDropDownList ID="ddlTipoEtapa" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlTipoEtapa_OnSelectedIndexChanged" Enabled="false"></cc:ExtendedDropDownList></td>        
                                </tr>
                                <tr>
                                    <td colspan="2"><asp:Literal runat="server" ID="ltDescripcion" Text="Descripción"></asp:Literal><br />
                                    <asp:TextBox runat="server" ID="tbDescripcion" Width="600"></asp:TextBox> </td>        
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveGastos" Text="Aceptar" OnClick="btSaveGastos_Click" runat="server" ValidationGroup="vgGastos" />
                            <asp:Button ID="btNewGastos" Text="Aceptar y Agregar Nuevo" OnClick="btNewGastos_Click" runat="server" ValidationGroup="vgGastos" />
                            <asp:Button ID="btCancelGastos" Text="Cerrar" OnClick="btCancelGastos_Click" runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderGastos" runat="server" CancelControlID="Button1"
        PopupDragHandleControlID="GastosPopUpDragHandle" PopupControlID="PopUpGastos"
        OkControlID="Button1" TargetControlID="Button1" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA EVOLUCIONES --%>
<asp:Panel ID="PopUpEvoluciones" runat="server" Width="980px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EvolucionesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpEvoluciones" runat="server" Text="Evolución" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEvoluciones" DefaultButton="btNewEvolucion" runat="server">
        <asp:UpdatePanel ID="upEvolucionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloEvoluciones" runat="server" Text=""></asp:Label>
                <asp:Panel ID="pnEvolucionesAgregar" runat="server" GroupingText="Agregar">
                    <table Width="940px"> <%-- Matias - Tarea 7 - Antes: 960px (no tiene relacion directa con la tarea pero la idea es taggearla en alguna) --%>
                        <tr>
                            <td><asp:Literal ID="ltLocalizacion" Text="Localización" runat="server"></asp:Literal></td>
                            <td width="200px" colspan="4"><uc:TreeLocalizacion runat="server" ID="tsEvolucion" RequiredValue="true" TabIndex="1"
                            ValidationGroup="vgEvolucion" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue" ></uc:TreeLocalizacion></td>
                            <td colspan="2">&nbsp;</td>
                        </tr>
                        <tr>
                            <td width="200px"><asp:Literal ID="ltEstado" Text="Tipo / Estado" runat="server"></asp:Literal></td>
                            <td width="200px"><cc:ExtendedDropDownList ID="ddlEstadoEvolucion" runat="server" TabIndex="2" SkinID="ancholibre" Width="142px" ></cc:ExtendedDropDownList></td>                        
                            
                            <td width="200px"><asp:Literal ID="ltFechaEstimadaEvolucion" Text="Fecha Estimada" runat="server"></asp:Literal></td>
                            <td width="200px"><uc:DateInput ID="diFechaEstimadaEvolucion" runat="server" ValidationGroup="vgEvolucion" IsValidEmpty="true" Width="70px" TabIndex="7"/></td>
                            
                            <td width="200px"><asp:Literal ID="ltFechaRealizadaEvolucion" Text="Fecha Realizada" runat="server"></asp:Literal></td>
                            <td width="200px"><uc:DateInput ID="diFechaRealizadaEvolucion" runat="server" ValidationGroup="vgEvolucion" IsValidEmpty="false" Width="70px" TabIndex="12"/></td>
                        </tr>
                        <tr>
                            <td><asp:Literal ID="ltNroExpediente" Text="Nro. Expediente" runat="server"></asp:Literal></td>
                            <td><asp:Textbox ID="txtExpediente" runat="server"  TabIndex="3"></asp:Textbox></td>
                            
                            <td><asp:Literal ID="ltCantEstimadaEvolucion" Text="% E. Certificado" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbCantEstimadaEvolucion" InputType="PositiveFractional" Width="70px"  TabIndex="8"></cc:NumericTextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revCantEstimadaEvolucion" runat="server"   ControlToValidate="tbCantEstimadaEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvCantEstimadaEvolucion" runat="server" ControlToValidate="tbCantEstimadaEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RVCantEstimadaEvolucion" runat="server" 
                                    ControlToValidate="tbCantEstimadaEvolucion"  ValidationGroup="vgEvolucion"  
                                    Text="*" Width="1px" Height="1px" MinimumValue="0" MaximumValue="100" 
                                    Type="Double" ></asp:RangeValidator>
                            </td>
                            <td><asp:Literal ID="ltCantRealizadaEvolucion" Text="% R. Certificado" 
                                    runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbCantRealizadaEvolucion" InputType="PositiveFractional" Width="70px" TabIndex="13"></cc:NumericTextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revCantRealizadaEvolucion" runat="server"   ControlToValidate="tbCantRealizadaEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="RVCantRealizadaEvolucion" runat="server" 
                                    ControlToValidate="tbCantRealizadaEvolucion"  ValidationGroup="vgEvolucion"  
                                    Text="*" Width="1px" Height="1px" MinimumValue="0" MaximumValue="100" 
                                    Type="Double" ></asp:RangeValidator>
                            </td>                            
                        </tr>
                        <tr>
                            <td><asp:Literal ID="ltNroCertificadoEvolucion" Text="Nro. Certificado" runat="server"></asp:Literal></td>
                            <td><asp:TextBox ID="tbNroCertificadoEvolucion" runat="server"  TabIndex="4"></asp:TextBox>
                             &nbsp
                            <asp:RequiredFieldValidator ID="rfvNroCertificadoEvolucion" runat="server" ControlToValidate="tbNroCertificadoEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                            <asp:RegularExpressionValidator ID="revNroCertificadoEvolucion" runat="server"   ControlToValidate="tbNroCertificadoEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            </td> 
                            <td><asp:Literal ID="ltPEA" Text="% E. Acumulado" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbPE_AcumuladoEvolucion" InputType="Fractional" Width="70px"  TabIndex="9"></cc:NumericTextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revPE_AcumuladoEvolucion" runat="server"   ControlToValidate="tbPE_AcumuladoEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            <asp:RequiredFieldValidator ID="rfvPE_AcumuladoEvolution" runat="server" ControlToValidate="tbPE_AcumuladoEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
                            <asp:RangeValidator ID="RVPE_AcumuladoEvolution" runat="server" 
                                    ControlToValidate="tbPE_AcumuladoEvolucion"  ValidationGroup="vgEvolucion"  
                                    Text="*" Width="1px" Height="1px" MaximumValue="100" MinimumValue="0" 
                                    Type="Double"  ></asp:RangeValidator>
                           </td>
                            <td><asp:Literal ID="ltPRA" Text="% R. Acumulado" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbPR_AcumuladoEvolucion" InputType="Fractional" Width="70px"  TabIndex="14"></cc:NumericTextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revPR_AcumuladoEvolucion" runat="server"   ControlToValidate="tbPR_AcumuladoEvolucion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            <asp:RangeValidator ID="RVPR_AcumuladoEvolucion" runat="server"   
                                    ControlToValidate="tbPR_AcumuladoEvolucion"  ValidationGroup="vgEvolucion"  
                                    Text="*" Width="1px" Height="1px" MinimumValue="0" MaximumValue="100" 
                                    Type="Double"  ></asp:RangeValidator>
                           
                            </td>
                        </tr>
                        <tr>                        
                            <td><asp:Literal ID="ltNroDesembolso" Text="Nro. Desembolso" runat="server"></asp:Literal></td>
                            <td><asp:TextBox ID="tbNroDesembolso" runat="server"  TabIndex="5"></asp:TextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revNroDesembolso" runat="server"   ControlToValidate="tbNroDesembolso"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            </td>
                            <td><asp:Literal ID="ltMontoEstimadoEvolucion" Text="Monto Estimado" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbMontoEstimadoEvolucion" InputType="Fractional"  Width="70px"  TabIndex="10"></cc:NumericTextBox>                            
                            &nbsp
                            </td>
                            <td><asp:Literal ID="ltMontoRealizadoEvolucion" Text="Monto Realizado" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbMontoRealizadoEvolucion" InputType="Fractional" UseSeparadorMiles="true" Width="70px"  TabIndex="15"></cc:NumericTextBox>
                            &nbsp
                            </td>                            
                        </tr>
                        <tr>                        
                            <td><asp:Literal ID="Cotizacion" Text="Cotización" runat="server"></asp:Literal></td>
                            <td><cc:NumericTextBox runat="server" ID="tbCotizacion" InputType="PositiveFractional" Width="70px"  TabIndex="6"></cc:NumericTextBox>
                            &nbsp
                            <asp:RegularExpressionValidator ID="revCotizacion" runat="server"   ControlToValidate="tbCotizacion"  ValidationGroup="vgEvolucion"  Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
                            </td>
                            <td><asp:Literal ID="ltFPagoCertificacoEvolucion" Text="F. Pago Certificado" runat="server"></asp:Literal></td>
                            <td><uc:DateInput ID="diFPagoCertificacoEvolucion" runat="server" ValidationGroup="vgEvolucion" IsValidEmpty="false"  Width="70px"  TabIndex="11"/></td>
                            <td><asp:Literal ID="ltFVtoCertificadoEvolucion" Text="F. Vencimiento Certificado" runat="server"></asp:Literal></td>
                            <td><uc:DateInput ID="diFVtoCertificadoEvolucion" runat="server" ValidationGroup="vgEvolucion" IsValidEmpty="false"  Width="70px"  TabIndex="16"/></td>
                        </tr>                        
                        <tr>
                            <td colspan='6'><br/>
                                <asp:Literal ID="Literal1" Text="Observaciones" runat="server"></asp:Literal><br/>
                                <asp:TextBox ID="tbObservacionesEvolucion" TextMode="MultiLine" Rows='3' runat="server" TabIndex="17"></asp:TextBox>
                            </td>
                        </tr>
                        <tr>
                            <td  style="color:Red;text-align:center" colspan="6">
                                <asp:Label ID="lblErrorEvoluciones" runat="server" Text="" Visible="false"></asp:Label>
                            </td>
                        </tr>                                              
                    </table>
                    <table width="935px">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewEvolucion" Text="Agregar" OnClick="btSaveEvolucion_Click" runat="server" ValidationGroup="vgEvolucion" />
                                <asp:Button ID="btSaveEvolucion" Text="Guardar" OnClick="btNewEvolucion_Click" runat="server" ValidationGroup="vgEvolucion" />
                                <asp:Button ID="btCancelEvolucion" Text="Cerrar" OnClick="btCancelEvolucion_Click" ValidationGroup="vgEvolucionPopUp" runat="server" />
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
            </ContentTemplate>
        </asp:UpdatePanel>
        <asp:UpdatePanel ID="upGridEvoluciones" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <div style="overflow:auto; width:978px; height:250px"> <%-- Matias 20131101 - Tarea 12 - Nueva linea--%>
                <%-- Matias 20131101 - Tarea 12 - asp: AllowPaging="False" y AllowSorting="False"--%>
                <asp:GridView ID="gridEvoluciones" runat="server" AutoGenerateColumns="False" DataKeyNames="ID"
                    AllowPaging="False" OnRowCommand="GridEvoluciones_RowCommand" AllowSorting="False"
                    OnSorting="GridEvoluciones_Sorting" OnPageIndexChanging="GridEvoluciones_PageIndexChanging"
                    EmptyDataText="No hay evoluciones definidas" Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Localización Geográfica" DataField="ClasificacionGeografica_Descripcion" SortExpression="ClasificacionGeografica_Descripcion" />
                        <asp:BoundField HeaderText="Nro. Exp." DataField="NroExpediente" SortExpression="NroExpediente" />
                        <asp:BoundField HeaderText="F. E." DataField="FechaEstimada" SortExpression="FechaEstimada"   DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField HeaderText="% E. Cert." DataField="CantidadEstimada" SortExpression="CantidadEstimada" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F2}"/>
                        <asp:BoundField HeaderText="% E. Acum." DataField="CantidadAcumuladaEstimada" SortExpression="CantidadAcumuladaEstimada" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F2}"/>
                        <asp:BoundField HeaderText="Monto E." DataField="MontoEstimado" SortExpression="MontoEstimado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/>                        
                        <asp:BoundField HeaderText="F. R." DataField="FechaReal" SortExpression="FechaReal"   DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center"/>
                        <asp:BoundField HeaderText="% R. Cert." DataField="CantidadReal" SortExpression="CantidadReal" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F2}" />
                        <asp:BoundField HeaderText="% R. Acum." DataField="CantidadAcumuladaRealizada" SortExpression="CantidadAcumuladaRealizada" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:F2}"/>
                        <asp:BoundField HeaderText="Monto R." DataField="MontoRealizado" SortExpression="MontoRealizado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/>                      
                        <asp:BoundField HeaderText="Nro. Cert." DataField="CertificadoNumero" SortExpression="CertificadoNumero" />                        
                        <asp:BoundField HeaderText="Tipo/Estado" DataField="CertificadoEstado_Nombre" SortExpression="CertificadoEstado_Nombre" />
                        <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                    CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            </ItemTemplate>
                            <ItemStyle Width="60px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div> <%-- Matias 20131101 - Tarea 12 - Nueva linea --%>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button8" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEvoluciones" runat="server"
        CancelControlID="Button8" PopupDragHandleControlID="EvolucionesPopUpDragHandle"
        PopupControlID="PopUpEvoluciones" OkControlID="Button8" TargetControlID="Button8"
        BackgroundCssClass="modalBackground" />
</asp:Panel>
