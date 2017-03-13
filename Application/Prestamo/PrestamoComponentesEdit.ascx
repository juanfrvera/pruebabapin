<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoComponentesEdit.ascx.cs" Inherits="UI.Web.PrestamoComponentesEdit" %>
<%@ Register Tagprefix="uc" TagName="TreeFuenteFinanciamiento" Src="~/ControlsPersonal/WebControl_FuenteFinanciamiento.ascx"  %> 
<%@ Register TagPrefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<%@ Register TagPrefix="uc" TagName="AutocompleteIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseAutocomplete.ascx" %>
<%--German 02032014 - tarea 110--%>
<%@ Register TagPrefix="uc" TagName="TreeIndicadorClase" Src="~/ControlsPersonal/WebControl_IndicadorClaseTree.ascx" %>
<%--German 02032014 - tarea 110--%>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlComponente" runat="server" GroupingText ="Componentes" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarComponente" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarComponente" runat ="server" Text="Agregar" OnClick="btAgregarComponente_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr> 
                </table>        
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridComponentes"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridComponentes" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="False" 
            OnRowCommand="GridComponentes_RowCommand"  OnRowDataBound="GridComponente_RowDataBound"  
            AllowSorting="True" OnSorting="GridComponentes_Sorting"
            OnPageIndexChanging="GridComponentes_PageIndexChanging" 
            EmptyDataText="No hay Componentes definidas" 
            Width ="100%">
            <Columns>            
                <asp:TemplateField   HeaderText=""  SortExpression=""  HeaderStyle-Width ="40px">            
                    <ItemTemplate>                        
                        <asp:RadioButton id="rbComponente" runat="server" GroupName="grupoRadioEtapa" OnCheckedChanged="rbComponente_OnCheckedChanged" AutoPostBack="true" />
                    </ItemTemplate>
                </asp:TemplateField>            
                <asp:BoundField HeaderText ="Descripción" DataField ="Descripcion" SortExpression ="Descripcion" ItemStyle-Width="500px" />
                <asp:BoundField HeaderText ="Monto" DataField ="Monto" SortExpression ="Monto" ItemStyle-Width="150px"  ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/>
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID="imgSupuesto" runat="server" src="../Images/supuestos.png" ToolTip="Supuestos"
                                CommandName='<%# Command.SHOW_DETAILS %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                            &nbsp;
                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                            &nbsp;
                            <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ Translate("ConfirmDeleteComponente") +"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                        </ItemTemplate>            
                        <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <div class="CollapsiblePanelTab"  align ="Left">
                                <span id="span1">
                                    <asp:Label ID="Label2" runat="server" Text="Subcomponentes"></asp:Label>
                                </span>
                            </div>
                            <asp:UpdatePanel ID="pnlAgregarSubComponente" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarSubComponente" runat ="server" Text="Agregar" OnClick="btAgregarSubComponente_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr> 
                </table>        
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridSubComponentes"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridSubComponentes" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="False" 
            OnRowCommand="GridSubComponentes_RowCommand"    
            AllowSorting="True" OnSorting="GridSubComponentes_Sorting"
            OnPageIndexChanging="GridSubComponentes_PageIndexChanging" 
            EmptyDataText="No hay SubComponentes definidas" 
            Width ="100%">
            <Columns>
                <asp:BoundField HeaderText ="Descripción" DataField ="Descripcion" SortExpression ="Descripcion" ItemStyle-Width="540px" />
                <asp:BoundField HeaderText ="Monto" DataField ="Monto" SortExpression ="Monto" ItemStyle-Width="150px"  ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/>                
                    <asp:TemplateField>
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" OnClick="GridImageButtonSC_Click" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                            &nbsp;
                            <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" OnClick="GridImageButtonSC_Click" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                        </ItemTemplate>            
                        <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
            <br />
        <div class="CollapsiblePanelTab" style="margin-left:14px">
            <span id="spanGeoref">
                <asp:Label ID="lblIndicadoresComponente" runat="server" Text="Indicadores"></asp:Label>
                &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
            </span>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeIndicadoresComponente" runat="Server"
                TargetControlID="pnlIndicadoresComponente" Collapsed="True" ExpandControlID="lblIndicadoresComponente"
                CollapseControlID="lblIndicadoresComponente" AutoCollapse="False" AutoExpand="False"
                ExpandDirection="Vertical" />
        </div>
        <asp:Panel ID="pnlIndicadoresComponente" runat="server">
            <table width="99%">
                <tr>
                    <td align="right">
                        <asp:UpdatePanel ID="upAgregarIndicadorComponente" runat="server" UpdateMode="Conditional">
                            <ContentTemplate>
                                <asp:Button ID="btAgregarIndicadorComponente" runat="server" Text="Agregar" OnClick="btAgregarIndicadorComponente_Click" TabIndex="3" />
                            </ContentTemplate>
                        </asp:UpdatePanel>
                    </td>
                </tr>
            </table>
            <br />
            <asp:UpdatePanel ID="upGridIndicadoresComponente" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                    <asp:GridView ID="gridIndicadoresComponente" runat="server" AutoGenerateColumns="False"
                        DataKeyNames="ID" AllowPaging="False" OnRowCommand="GridIndicadores_RowCommand"
                        AllowSorting="True" OnSorting="GridIndicadores_Sorting" OnPageIndexChanging="GridIndicadores_PageIndexChanging"
                        EmptyDataText="No hay Indicadores definidos" Width="100%">
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
                                        CausesValidation="false" OnClick="GridImageButtonIndicadores_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar"
                                        CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" OnClick="GridImageButtonIndicadores_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                        CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                        CommandArgument='<%#Eval("ID")%>' CausesValidation="false"  OnClick="GridImageButtonIndicadores_Click" />
                                </ItemTemplate>
                                <ItemStyle Width="150px" HorizontalAlign="Right" />
                            </asp:TemplateField>
                        </Columns>
                    </asp:GridView>
                </ContentTemplate>
            </asp:UpdatePanel>
        </asp:Panel>         
    </ContentTemplate>    
    </asp:UpdatePanel>
</asp:Panel>
<asp:Panel ID="Panel1" runat="server" GroupingText ="Financiamiento por Componente" >
<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <%--<tr>
        <td>
            <div class="CollapsiblePanelTab" >
                <span id="spanFinanciamiento">
                    <asp:Label ID="lblFinanciamiento" runat ="server" Text ="Financiamiento por Componente" ></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeFinanciamiento" runat="Server"
                    TargetControlID="pnlFinanciamiento"
                    Collapsed="True"
                    ExpandControlID="spanFinanciamiento"
                    CollapseControlID="spanFinanciamiento"
                    AutoCollapse="False"
                    AutoExpand="False"
                    ExpandDirection="Vertical" />                                 
            </div>
        </td>
    </tr>--%>
    <tr>
        <td>
            <asp:Panel ID="pnlFinanciamiento" runat="server">
            <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                            <tr>                      
                                <td  align ="right" >
                                    <asp:UpdatePanel ID="pnlAgregarFinanciamiento" runat = "server" UpdateMode ="Conditional" >
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarFinanciamiento" runat ="server" Text="Agregar" OnClick="btAgregarFinanciamiento_Click" TabIndex ="2"/> 
                                    </ContentTemplate>
                                    </asp:UpdatePanel>	                    
                                </td>
                            </tr>
                        </table>        
                    </td>
                </tr>        
            </table>
            <asp:UpdatePanel ID= "upGridFinanciamientos"  runat="server" UpdateMode = "Conditional" >
                <ContentTemplate>
                    <asp:GridView ID="gridFinanciamientos" runat = "server"
                        AutoGenerateColumns="False" DataKeyNames="ID" 
                        OnRowCommand="GridFinanciamientos_RowCommand"    
                        AllowSorting="True" AllowPaging="False"  OnSorting="GridFinanciamientos_Sorting"
                        OnPageIndexChanging="GridFinanciamientos_PageIndexChanging" 
                        EmptyDataText="No hay Financiamientos definidos" 
                        Width ="100%">
                        <Columns>
                                <asp:BoundField HeaderText ="Componente" DataField ="PrestamoComponente_Nombre" SortExpression ="PrestamoComponente_Nombre"  />
                                <asp:BoundField HeaderText ="SubComponente" DataField ="PrestamoSubComponente_Descripcion" SortExpression ="PrestamoSubComponente_Descripcion"  />
                                <asp:BoundField HeaderText ="Fuente de Financiamiento" DataField ="FuenteFinanciamiento_Descripcion" SortExpression ="FuenteFinanciamiento_Descripcion"  />
                                <asp:BoundField HeaderText ="Monto" DataField ="Monto" SortExpression ="Monto"  ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" OnClick="GridImageButtonFinancia_Click" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                        &nbsp;
                                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" OnClick="GridImageButtonFinancia_Click" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
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
</asp:Panel>
<asp:Panel ID="Panel2" runat="server" GroupingText ="Desembolsos del Préstamo" >
<table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
    <%--<tr>
        <td>
            <div class="CollapsiblePanelTab" >
                <span id="spanDesembolso">
                    <asp:Label ID="lblDesembolso" runat ="server" Text ="Desembolsos" ></asp:Label>
                    &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
                </span>
                <ajaxToolkit:CollapsiblePanelExtender ID="cpeDesembolso" runat="Server"
                    TargetControlID="pnlDesembolso"
                    Collapsed="True"
                    ExpandControlID="spanDesembolso"
                    CollapseControlID="spanDesembolso"
                    AutoCollapse="False"
                    AutoExpand="False"
                    ExpandDirection="Vertical" />                                 
            </div>
        </td>
    </tr>--%>
    <tr>
        <td>
            <asp:Panel ID="pnlDesembolso" runat="server">
              <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                <tr>
                    <td>
                        <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                            <tr>                      
                                <td  align ="right" >
                                    <asp:UpdatePanel ID="pnlAgregarDesembolso" runat = "server" UpdateMode ="Conditional" >
                                    <ContentTemplate>
                                        <asp:Button ID="btAgregarDesembolso" runat ="server" Text="Agregar" OnClick="btAgregarDesembolso_Click" TabIndex ="2"/> 
                                    </ContentTemplate>
                                    </asp:UpdatePanel>	                    
                                </td>
                            </tr>
                        </table>        
                    </td>
                </tr>        
              </table>
              <asp:UpdatePanel ID= "upGridDesembolsos"  runat="server" UpdateMode = "Conditional" >
                <ContentTemplate>
                    <asp:GridView ID="gridDesembolsos" runat = "server"
                        AutoGenerateColumns="False" DataKeyNames="ID"
                        OnRowCommand="GridDesembolsos_RowCommand"    
                        AllowSorting="True" AllowPaging="False"  OnSorting="GridDesembolsos_Sorting"
                        OnPageIndexChanging="GridDesembolsos_PageIndexChanging" 
                        EmptyDataText="No hay Desembolsos definidos" 
                        Width ="100%">
                        <Columns>
                                <asp:BoundField HeaderText ="Fecha" DataField ="Fecha" SortExpression ="Fecha"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" />
                                <asp:BoundField HeaderText ="Monto Acumulado" DataField ="MontoAcumulado" SortExpression ="MontoAcumulado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}"/>
                                <asp:BoundField HeaderText ="% Total" DataField ="PTotal" SortExpression ="PTotal"  DataFormatString="{0:F2}" ItemStyle-HorizontalAlign="Right"/>
                                <asp:BoundField HeaderText ="Observación" DataField ="Observacion" SortExpression ="Observacion"  ItemStyle-HorizontalAlign="Left" ItemStyle-Width="500px" />
                                <asp:TemplateField>
                                    <HeaderTemplate>
                                    </HeaderTemplate>
                                    <ItemTemplate>
                                        &nbsp;
                                        <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" OnClick="GridImageButton2_Click" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                        &nbsp;
                                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" OnClick="GridImageButton2_Click" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
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
</asp:Panel>
</div>

<%--PANEL ALTA EVOLUCIONES --%>
<asp:Panel ID="PopUpEvoluciones" runat="server" Width="800px" Style="background-color: #ffffff;
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
    <asp:Panel ID="pnEvoluciones" DefaultButton="btNewEvolucion" runat="server" Style="padding: 10px">
        <asp:UpdatePanel ID="upEvolucionesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <asp:Label ID="lblTituloEvoluciones" runat="server" Text=""></asp:Label>
                <br />
                <br />
                <asp:Panel ID="pnEvolucionesAgregar" runat="server" GroupingText="Agregar">
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:Literal ID="ltLocalizacion" Text="Localización" runat="server"></asp:Literal>
                            </td>
                            <td colspan="3">
                                <uc:TreeLocalizacion runat="server" RequiredValue="true" ValidationGroup="vgEvolucion"
                                    ID="tsEvolucion" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue">
                                </uc:TreeLocalizacion>
                            </td>
                            <td>
                                <asp:Literal ID="ltTipoEvolucion" Text="Tipo" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <asp:DropDownList ID="ddlTipoEvolucion" runat="server"  SkinID="AnchoLibre" Width="120px">
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
                                <cc:NumericTextBox runat="server" ID="txtCantidadEstimadaEvolucion" InputType="PositiveFractional"></cc:NumericTextBox>
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
                                <asp:Literal ID="ltCantidadRealizadaEvolucion" Text="Cantidad Realizada" runat="server"></asp:Literal>
                            </td>
                            <td>
                                <cc:NumericTextBox runat="server" ID="txtCantidadRealizadaEvolucion" InputType="PositiveFractional"></cc:NumericTextBox>
                                <asp:RegularExpressionValidator ID="revCantidadRealizadaEvolucion" runat="server"
                                    ControlToValidate="txtCantidadRealizadaEvolucion" ValidationGroup="vgEvolucion"
                                    Text="*" Width="1px" Height="1px">
                                </asp:RegularExpressionValidator>
                            </td>
                        </tr>
                        <tr>
                            <td>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="4">
                                <asp:Label ID="lblErrorEvoluciones" runat="server" Text="" Style="color: Red"></asp:Label>
                            </td>
                        </tr>
                    </table>
                    <table width="100%">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewEvolucion" Text="Agregar" OnClick="btNewEvolucion_Click" runat="server"
                                    ValidationGroup="vgEvolucion" />
                                <asp:Button ID="btSaveEvolucion" Text="Guardar" OnClick="btSaveEvolucion_Click" runat="server"
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
                        <asp:BoundField HeaderText="Fecha E." DataField="FechaEstimada" SortExpression="FechaEstimada"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad E." DataField="CantidadEstimada" ItemStyle-HorizontalAlign="Right"
                            SortExpression="CantidadEstimada" DataFormatString="{0:#,0.00}"/>
                        <asp:BoundField HeaderText="Fecha Real" DataField="FechaReal" SortExpression="FechaReal"
                            DataFormatString="{0:dd/MM/yyyy}" />
                        <asp:BoundField HeaderText="Cantidad Real" DataField="CantidadReal" ItemStyle-HorizontalAlign="Right"
                            SortExpression="CantidadReal" DataFormatString="{0:#,0.00}"/>
                      <asp:TemplateField>
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                &nbsp;
                                <asp:ImageButton ID="imgEdit" runat="server" src="../Images/edit.png" ToolTip="Editar" OnClick="GridImageButtonEvolucion_Click"
                                    CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />
                                &nbsp;
                                <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                    CommandName='<%# Command.DELETE %>' OnClientClick="return confirm('Está seguro de eliminar?');"
                                    CommandArgument='<%#Eval("ID")%>' CausesValidation="false"  OnClick="GridImageButtonEvolucion_Click" />
                            </ItemTemplate>
                            <ItemStyle Width="150px" HorizontalAlign="Right" />
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
   <%-- <asp:ValidationSummary ID="vsEvolucion" runat="server" DisplayMode="BulletList" ValidationGroup="vgEvolucion"
        ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary> --%>
    <asp:Button ID="Button8" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEvoluciones" runat="server"
        CancelControlID="Button8" PopupDragHandleControlID="EvolucionesPopUpDragHandle"
        PopupControlID="PopUpEvoluciones" OkControlID="Button8" TargetControlID="Button8"
        BackgroundCssClass="modalBackground" />
</asp:Panel>


<%--PANEL ALTA COMPONENTES --%>
<asp:Panel ID="PopUpComponentes" runat="server" Width="750px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ComponentesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpComponentes" runat="server" Text="Componentes" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnComponentes" DefaultButton="btSaveComponentes" Height="100px" runat="server">
        <asp:UpdatePanel ID="upComponentesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" >
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:Literal ID="ltComponente" Text="Componente:" runat="server"></asp:Literal></td>
                                    <td><asp:TextBox runat="server" ID="txtComponente" Width="600px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvComp" runat="server" ControlToValidate="txtComponente" ValidationGroup="vgComponentes" Text="*" Width="5px" Height="5px"></asp:RequiredFieldValidator></td>        
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveComponentes" Text="Aceptar" OnClick="btSaveComponente_Click" runat="server" ValidationGroup="vgComponentes" />
                            <asp:Button ID="btNewComponentes" Text="Aceptar y Agregar Nuevo" OnClick="btNewComponente_Click" runat="server" ValidationGroup="vgComponentes" />
                            <asp:Button ID="btCancelComponentes" Text="Cerrar" OnClick="btCancelComponente_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderComponentes" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="ComponentesPopUpDragHandle" PopupControlID="PopUpComponentes"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA SUBCOMPONENTES --%>
<asp:Panel ID="PopUpSubComponentes" runat="server" Width="700px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="SubComponentesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpSubComponentes" runat="server" Text="SubComponentes" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnSubComponentes" DefaultButton="btSaveSubComponentes" Height="100px" runat="server">
        <asp:UpdatePanel ID="upSubComponentesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%" >
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:Literal ID="ltSubComponente" Text="SubComponente:" runat="server"></asp:Literal></td>
                                    <td valign="top" style="width:555px"><asp:TextBox runat="server" ID="txtSubComponente" Width="520px" ></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="rfvSubComp" runat="server" ControlToValidate="txtSubComponente" ValidationGroup="vgSubComponentes" Text="*" Width="5px" Height="5px"></asp:RequiredFieldValidator></td>        
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveSubComponentes" Text="Aceptar" OnClick="btSaveSubComponente_Click" runat="server" ValidationGroup="vgSubComponentes" />
                            <asp:Button ID="btNewSubComponentes" Text="Aceptar y Agregar Nuevo" OnClick="btNewSubComponente_Click" runat="server" ValidationGroup="vgSubComponentes" />
                            <asp:Button ID="btCancelSubComponentes" Text="Cerrar" OnClick="btCancelSubComponente_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button5" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSubComponentes" runat="server" CancelControlID="Button5"
        PopupDragHandleControlID="SubComponentesPopUpDragHandle" PopupControlID="PopUpSubComponentes"
        OkControlID="Button5" TargetControlID="Button5" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA FINANCIAMIENTOS --%>
<asp:Panel ID="PopUpFinanciamientos" runat="server" Width="650px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="FinanciamientosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpFinanciamientos" runat="server" Text="Financiamiento por Componente" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnFinanciamientos" DefaultButton="btSaveFinanciamientos" runat="server">
        <asp:UpdatePanel ID="upFinanciamientosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:Literal ID="Literal1" Text="Componente :" runat="server"></asp:Literal></td>
                                    <td><asp:DropDownList runat="server" ID="ddlF_Componente" AutoPostBack="true" Width ="300px" SkinID="AnchoLibre" OnSelectedIndexChanged="ddlComponenetes_OnSelectedIndexChanged" ></asp:DropDownList>
                                    <asp:RequiredFieldValidator ID="rfvComponente" runat="server" ControlToValidate="ddlF_Componente" ValidationGroup="vgFinanciamientos" Text="*" Width="5px" Height="5px" InitialValue="0"></asp:RequiredFieldValidator>
                                    </td> 
                                </tr>                                    
                                <tr>
                                    <td><asp:Literal ID="Literal2" Text="SubComponente :" runat="server"></asp:Literal></td>
                                    <td><asp:DropDownList runat="server" ID="ddlF_SubComponente" SkinID ="AnchoLibre"  Enabled="false" Width ="300px"></asp:DropDownList></td> 
                                </tr>                                    
                                <tr>
                                    <td><asp:Literal ID="Literal3" Text="Fuente de Financiamiento :" runat="server"></asp:Literal></td>
                                    <td><uc:TreeFuenteFinanciamiento runat="server" ID="tsFuenteFinanciamiento" RequiredValue="true" ValidationGroup="vgFinanciamientos" SelectOption="SelectedDefinedAndActualValue" ShowOption="ActivesAndActualValue"></uc:TreeFuenteFinanciamiento></td> 
                                </tr>                                                                                                    
                                <tr>
                                    <td><asp:Literal ID="Literal4" Text="Monto :" runat="server" ></asp:Literal></td>
                                    <td valign="top"><%--<asp:TextBox ID="txtF_Monto" runat="server" Width="74"></asp:TextBox>--%>
                                    <cc:NumericTextBox runat="server" ID="txtF_Monto" InputType="PositiveInteger" UseSeparadorMiles="true" ></cc:NumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvMontoFinanciamiento" runat="server" ControlToValidate="txtF_Monto" ValidationGroup="vgFinanciamientos" Text="*" Width="5px" Height="5px"></asp:RequiredFieldValidator>
                                    </td> 
                                </tr>    
                                <tr>
                                    <td align="center" colspan="2" style="color:Red;margin:10px">
                                    <asp:Label ID="lblErrorFinanciamiento" runat="server" Text=""></asp:Label>
                                    </td>
                                </tr>                                         
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveFinanciamientos" Text="Aceptar" OnClick="btSaveFinanciamiento_Click" runat="server" ValidationGroup="vgFinanciamientos" />
                            <asp:Button ID="btNewFinanciamientos" Text="Aceptar y Agregar Nuevo" OnClick="btNewFinanciamiento_Click" runat="server" ValidationGroup="vgFinanciamientos" />
                            <asp:Button ID="btCancelFinanciamientos" Text="Cerrar" OnClick="btCancelFinanciamiento_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderFinanciamientos" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="FinanciamientosPopUpDragHandle" PopupControlID="PopUpFinanciamientos"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL ALTA DESEMBOLSOS --%>
<asp:Panel ID="PopUpDesembolsos" runat="server" Width="650px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="DesembolsosPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpDesembolsos" runat="server" Text="Desembolso del préstamo" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnDesembolsos" DefaultButton="btSaveDesembolsos" runat="server">
        <asp:UpdatePanel ID="upDesembolsosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td><asp:Literal ID="Literal7" Text="Fecha :" runat="server"></asp:Literal></td>
                                    <td><uc:DateInput ID="diD_Fecha" runat="server" Width="100px" IsValidEmpty="true" ValidationGroup="vgDesembolsos" /></td>
                                </tr>                                                                                                                                
                                <tr>
                                    <td><asp:Literal ID="Literal8" Text="Monto Acumulado:" runat="server"></asp:Literal></td>
                                    <td><%--<asp:TextBox ID="txtD_Monto" runat="server" Width="100"></asp:TextBox>--%>
                                    <cc:NumericTextBox runat="server" ID="txtD_Monto" InputType="PositiveInteger" UseSeparadorMiles="true" ></cc:NumericTextBox>
                                    <asp:RequiredFieldValidator ID="rfvMontoAcumulado" runat="server" ControlToValidate="txtD_Monto" ValidationGroup="vgDesembolsos" Text="*" Width="5px" Height="5px"></asp:RequiredFieldValidator>
                                    </td> 
                                </tr>                                             
                                <tr>
                                    <td><asp:Literal ID="Literal5" Text="% Total :" runat="server"></asp:Literal></td>
                                    <td><asp:Label ID="txtD_Total" runat="server" Width="200" ReadOnly="true"></asp:Label></td> 
                                </tr>                                
                                <tr>
                                    <td colspan="2"><asp:Literal ID="Literal6" Text="Observaciones :" runat="server"></asp:Literal><br />
                                    <asp:TextBox ID="txtD_Observaciones" runat="server" Width="500" TextMode="MultiLine" Rows="4"></asp:TextBox></td> 
                                </tr>              
                                <tr>
                                    <td colspan="2" align="center">
                                        <asp:Label ID="lblErrorDesembolso" runat="server" Text="" style="color: Red"></asp:Label>
                                    </td>
                                </tr>                                                  
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveDesembolsos" Text="Aceptar" OnClick="btSaveDesembolso_Click" runat="server" ValidationGroup="vgDesembolsos" />
                            <asp:Button ID="btNewDesembolsos" Text="Aceptar y Agregar Nuevo" OnClick="btNewDesembolso_Click" runat="server" ValidationGroup="vgDesembolsos" />
                            <asp:Button ID="btCancelDesembolsos" Text="Cerrar" OnClick="btCancelDesembolso_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button7" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderDesembolsos" runat="server" CancelControlID="Button7"
        PopupDragHandleControlID="DesembolsosPopUpDragHandle" PopupControlID="PopUpDesembolsos"
        OkControlID="Button7" TargetControlID="Button7" BackgroundCssClass="modalBackground" />
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
    <asp:Panel ID="pnIndicadores" DefaultButton="btSaveIndicadores" runat="server" style="padding: 10px">
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
                            <asp:Label ID="lblErrorIndicadores" runat="server" Text="" style="color: Red"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltMedioVerificacion" Text="Medio de Verificación" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:DropDownList ID="ddlMedioVerificacion" runat="server" OnSelectedIndexChanged="ddlMedioVerificacion_IndexChanged"></asp:DropDownList>
                        </td>                 
                    </tr>
                    <tr>
                        <td>
                            <asp:Literal ID="ltObservacionesIndicadores" Text="Observaciones" runat="server"></asp:Literal>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox runat="server" ID="txtObservacionesIndicadores" Width="700px" rows="6" TextMode="MultiLine"></asp:TextBox>                                
                        </td>                        
                    </tr>
                    <%--<tr>
                        <td>

                        <asp:RegularExpressionValidator ID="revObservacionesIndicadores" runat="server" ControlToValidate="txtObservacionesIndicadores"
                            ValidationGroup="vgIndicador" Text="*" Width="1px" Height="5px">
                        </asp:RegularExpressionValidator>                                
                        </td>                        
                    </tr>  --%>                  
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
    <asp:ValidationSummary id="vsIndicador" runat="server" DisplayMode="BulletList" ValidationGroup="vgIndicador"  ShowSummary="False"  ShowMessageBox="True"  ></asp:ValidationSummary>    
        <asp:Button ID="Button6" runat="server" Text="Button" Style="display: none" />
        <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderIndicadores" runat="server"
            CancelControlID="Button6" PopupDragHandleControlID="IndicadoresPopUpDragHandle"
            PopupControlID="PopUpIndicadores" OkControlID="Button6" TargetControlID="Button6" BackgroundCssClass="modalBackground" />
        
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
    <asp:Panel ID="pnSupuestos" DefaultButton="btNewSupuesto" runat="server">
        <asp:UpdatePanel ID="upSupuestosPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                                <asp:Label ID="lblTituloSupuestos" runat="server" Text=""></asp:Label>
                <br />
                <br />
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
                                            <%--<asp:RequiredFieldValidator ID="rfvSupuestos" runat="server" ControlToValidate="txtSupuesto"
                                                ValidationGroup="vgSupuesto" Text="*" Width="1px" Height="5px">
                                            </asp:RequiredFieldValidator>
                                            <asp:RegularExpressionValidator ID="revSupuestos" runat="server" ControlToValidate="txtSupuesto"
                                                ValidationGroup="vgSupuesto" Text="*" Width="1px" Height="5px">
                                            </asp:RegularExpressionValidator>  --%>                                          
                                        </td>
                                    </tr>
                                </table>
                            </td>
                        </tr>
                    </table>
                    <table width="100%" cellpadding="0" cellspacing="5px">
                        <tr>
                            <td align="right">
                                <asp:Button ID="btNewSupuesto" Text="Agregar" OnClick="btSaveSupuesto_Click" runat="server" ValidationGroup="vgSupuesto" />
                                <asp:Button ID="btSaveSupuesto" Text="Guardar" OnClick="btNewSupuesto_Click" runat="server" ValidationGroup="vgSupuesto" />
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
                        AllowPaging="False" OnRowCommand="GridSupuestos_RowCommand" AllowSorting="True"
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
                                        CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" 
                                        OnClick="GridImageButtonSupuestos_Click" />
                                    &nbsp;
                                    <asp:ImageButton ID="imgDelete" runat="server" src="../Images/delete.jpg" ToolTip="Eliminar"
                                        CommandName='<%# Command.DELETE %>' OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'
                                        CommandArgument='<%#Eval("ID")%>' CausesValidation="false" OnClick="GridImageButtonSupuestos_Click" />
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
    <%--<asp:ValidationSummary id="vsSupuesto" runat="server" DisplayMode="BulletList" ValidationGroup="vgSupuesto"  ShowSummary="False"  ShowMessageBox="True"  ></asp:ValidationSummary>    --%>
    <asp:Button ID="Button9" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderSupuestos" runat="server" CancelControlID="Button9"
        PopupDragHandleControlID="SupuestosPopUpDragHandle" PopupControlID="PopUpSupuestos"
        OkControlID="Button9" TargetControlID="Button9" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--PANEL MENSAJE --%>
<asp:Panel ID="PopUpMensajes" runat="server" Width="650px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="MensajesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpMensajes" runat="server" Text="Aviso" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnMensajes" DefaultButton="btCancelMensajes" Height="100px" runat="server">
        <asp:UpdatePanel ID="upMensajesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align="center" >
                            <asp:Literal ID="ltMensajeErrorMonto" Text="" runat="server"></asp:Literal>
                            <br /><br />
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btCancelMensajes" Text="Cerrar" OnClick="btCancelMensaje_Click" runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderMensajes" runat="server" CancelControlID="Button4"
        PopupDragHandleControlID="MensajesPopUpDragHandle" PopupControlID="PopUpMensajes"
        OkControlID="Button4" TargetControlID="Button4" BackgroundCssClass="modalBackground" />
</asp:Panel>