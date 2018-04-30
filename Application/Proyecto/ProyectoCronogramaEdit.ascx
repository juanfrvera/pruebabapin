<%@ Control Language="C#" AutoEventWireup="True" CodeBehind="ProyectoCronogramaEdit.ascx.cs"
    Inherits="UI.Web.ProyectoCronogramaEdit" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<%@ Register TagPrefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeControl" Src="~/ControlsPersonal/WebControl_ClasificacionGasto.ascx" %>
<%@ Register TagPrefix="uc" TagName="TreeFuenteFinanciamiento" Src="~/ControlsPersonal/WebControl_FuenteFinanciamiento.ascx" %>


<div class="TabbedPanelsContent">
    <asp:panel id="pnlEtapas" runat="server" groupingtext="Cronograma de gastos">
        <asp:UpdatePanel ID= "upGridEtapas"  runat="server" UpdateMode = "Conditional" >
            <ContentTemplate>
                <table width="100%"  cellpadding="0" cellspacing="2px" border="0">	  	
                <tr>
                    <td>
                        <table width="100%" cellpadding="0" style="margin-bottom:12px" >	  	
                            <!--<tr>                      
                                <td style="width:100px">&nbsp;</td>
                                <td style="width:100px">&nbsp;</td>
	                            <td style="width:200px">&nbsp;</td>
	                            <td style="width:90px;text-align:left"><asp:Literal ID="ltrFIE" runat="server" Text="Fecha Inicio E."></asp:Literal></td>
	                            <td style="width:90px;text-align:left"><asp:Literal ID="ltrFFE" runat="server" Text="Fecha Fin E."></asp:Literal></td>
	                            <td style="width:100px;text-align:left"><asp:Literal ID="ltrFIR" runat="server" Text="Fecha Inicio R."></asp:Literal></td>
	                            <td style="width:100px;text-align:left"><asp:Literal ID="ltrFFR" runat="server" Text="Fecha Fin R."></asp:Literal></td>
	                            <td style="width:100px;text-align:left"><asp:Literal ID="ltrTE" runat="server" Text="Total E."></asp:Literal></td>
	                            <td style="width:100px;text-align:left"><asp:Literal ID="ltrTR" runat="server" Text="Total R."></asp:Literal></td>
    	                        <td style="width:20px">&nbsp;</td>
                            </tr>-->
                            <tr>                      
	                            <td width="70px"><asp:Literal ID="ltrFase" runat="server" Text="Gastos de"></asp:Literal></td>
	                            <td><cc:ExtendedDropDownList ID="ddlFase" runat="server" OnSelectedIndexChanged="ddlFase_OnSelectedIndexChanged" AutoPostBack="true"  ></cc:ExtendedDropDownList></td>
	                            <td></td>
	                            <!--<td align="center"><asp:Label ID="lblMfie" runat="server" ></asp:Label></td>
	                            <td align="center"><asp:Label ID="lblMffe" runat="server" ></asp:Label></td>
	                            <td align="center"><asp:Label ID="lblMfir" runat="server" ></asp:Label></td>
	                            <td align="center"><asp:Label ID="lblMffr" runat="server" ></asp:Label></td>
	                            <td align="right"><asp:Label ID="lblMte" runat="server" ></asp:Label>&nbsp;</td>
	                            <td align="right"><asp:Label ID="lblMtr" runat="server" ></asp:Label>&nbsp;</td>-->

                            <!--<tr>
                                <td colspan ="10" align ="right" >
                                    <asp:Button ID ="btVerTotales" runat ="server" Text ="Total por Año" CausesValidation="false" 
                                        OnClick="btVerTotales_Click" />
                                </td>
                            </tr>-->
                                <td align="right">
                                    <asp:Button ID ="btInicioDeCarga" Visible="false" runat ="server" Text ="Inicio de Carga" CausesValidation="false" 
                                        OnClick="btInicioDeCarga_Click" />
                                </td>
                            </tr>
                        </table>        
                    </td>
                </tr>        
                </table>  
                <asp:GridView ID="gridEtapas" runat = "server"
                    AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
                    OnRowCommand="GridEtapas_RowCommand" OnRowDataBound="GridEtapas_RowDataBound"
                    AllowSorting="True" OnSorting="GridEtapas_Sorting"
                    OnPageIndexChanging="GridEtapas_PageIndexChanging" 
                    EmptyDataText="No hay producto intermedio definido" 
                    Width ="100%">
                    <Columns>
                        <asp:TemplateField HeaderText=""  SortExpression=""  HeaderStyle-Width ="4%">            
                            <ItemTemplate>                        
                                <asp:RadioButton id="rbEtapa" runat="server" GroupName="grupoRadioEtapa" OnCheckedChanged="rbEtapa_OnCheckedChanged" AutoPostBack="true" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:TemplateField HeaderText="Denominación de la Obra"  SortExpression="DescripcionCorta" ItemStyle-Width="250px" >            
                            <ItemTemplate>
                                <asp:Label ID="lblProyectoDenominacion" runat="server" Text='<%# Eval("DescripcionCorta") %>'  ></asp:Label>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField HeaderText ="Estado Financiero" DataField ="Estado_Nombre" SortExpression ="Estado_Nombre"   ItemStyle-Width ="80px"/>
                        <asp:BoundField HeaderText ="Fecha Inicio Estimada" DataField ="FechaInicioEstimada" SortExpression ="FechaInicioEstimada"  DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width ="100px"/>
                        <asp:BoundField HeaderText ="Fecha Fin Estimada" DataField ="FechaFinEstimada" SortExpression ="FechaFinEstimada" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width ="100px"/>   
                        <asp:BoundField HeaderText ="Fecha Inicio Realizada" DataField ="FechaInicioRealizada" SortExpression ="FechaInicioRealizada" DataFormatString="{0:dd/MM/yyyy}" ItemStyle-HorizontalAlign="Center" ItemStyle-Width ="100px"/>
                        <asp:BoundField HeaderText ="Fecha Fin Realizada" DataField ="FechaFinRealizada" SortExpression ="FechaFinRealizada" DataFormatString="{0:dd/MM/yyyy}"  ItemStyle-HorizontalAlign="Center" ItemStyle-Width ="100px"/>
                        <asp:BoundField HeaderText ="Total Estimada" DataField ="TotalEstimado" SortExpression ="TotalEstimado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ItemStyle-Width ="100px"/> 
                        <asp:BoundField HeaderText ="Total Realizada" DataField ="TotalRealizado" SortExpression ="TotalRealizado" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:N0}" ItemStyle-Width ="100px"/>                
                        <asp:TemplateField  HeaderStyle-Width ="5px">
                            <HeaderTemplate>
                            </HeaderTemplate>
                            <ItemTemplate>
                                <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                            </ItemTemplate>            
                            <ItemStyle Width="50px"  HorizontalAlign ="Right"/>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:panel>

    <asp:panel id="pnlInformacionPresupuestaria" runat="server" groupingtext="Información Presupuestaria">
        <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
            <tr>
                <td>
                    <table cellpadding="0" cellspacing="5px" border="0"   width="100%">
                        
                        <tr>
                            <td style="width:100px" >
                                <asp:Literal ID="liSAF" Text="SAF" runat="server"></asp:Literal>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSAF" runat="server" Enabled="false"  Width="830px" TabIndex="13"></asp:TextBox>
                            </td>
                            <td  style="width:1px" class="filaValidator">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="liPrograma" Text="Programa" runat="server"></asp:Literal></td>
                            <td colspan="2">
                                <asp:TextBox ID="txtPrograma" runat="server" Enabled="false"  Width="830px" TabIndex="13"></asp:TextBox>
                            </td>
                            <td class="filaValidator">
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:Literal ID="liSubPrograma" Text="Subprograma" runat="server"></asp:Literal>
                            </td>
                            <td colspan="2">
                                <asp:TextBox ID="txtSubPrograma" runat="server" Enabled="false"  Width="830px" TabIndex="13"></asp:TextBox>
                            </td>
                            <td class="filaValidator">
                                &nbsp;
                            </td>
                        </tr>
                        	  	
                        <tr>   
                            <td colspan="2">
                                <asp:Panel ID="Panel4" runat="server" GroupingText="Código Presupuestario de Ejecución">
                                    <table style="width:630px" cellpadding="0" cellspacing="0" border="0">
                                        <tr>
                                            <td style="width:58px">
                                                <asp:Literal ID="litNroProyecto" Text="Proyecto" runat="server"></asp:Literal>
                                            </td>
                                            <td style="width:60px">
                                                <asp:TextBox ID="txtNroProyecto" Enabled="false" runat="server" TabIndex="19" Width="50px"></asp:TextBox>
                                            </td>
                                            <td style="width:60px">
                                                <asp:Literal ID="litActividad" runat="server" Text="Actividad"></asp:Literal>
                                            </td>
                                            <td style="width:60px">
                                                <asp:TextBox ID="txtNroActividad" Enabled="false" runat="server" TabIndex="19" Width="50px"></asp:TextBox>
                                            </td>
                                            <td style="width:60px">
                                                <asp:Literal ID="litObra" runat="server" Text="Obra"></asp:Literal>
                                            </td>
                                            <td style="width:60px">
                                                <asp:TextBox ID="txtNroObra" Enabled="false" runat="server" TabIndex="19" Width="50px"></asp:TextBox>
                                            </td>
                                            <td style="width:160px">
                                                &nbsp;
                                            </td>
                                        </tr>
                                    </table>
                                </asp:Panel>
                            </td>                   
                            <td style="width:100px">
                                <asp:UpdatePanel ID="pnlVerInfoPresupuestaria" runat = "server" UpdateMode ="Conditional" >
                                <ContentTemplate>
                                    <asp:Button ID="btVerInfoPresupuestaria" runat ="server" Text="Ver información presupuestaria" OnClick="btVerInfoPresupuestaria_Click" CausesValidation="false" TabIndex ="2"/> 
                                </ContentTemplate>
                                </asp:UpdatePanel>	                    
                            </td>
                            <td class="filaValidator">
                                &nbsp;
                            </td>
                        </tr>
                    </table>        
                </td>
            </tr>        
        </table>
    </asp:panel>

    <asp:panel id="pnlEtapaEstimada" runat="server" groupingtext="Gastos Estimados">
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                    <tr>            
	                    <td style="width:100px"><asp:Literal ID="ltrAnio" runat="server" Text="Mostrar Desde"></asp:Literal></td>
	                    <td style="width:100px">
	                        <cc:ExtendedDropDownList ID="ddlAnioCorrienteEstimado" runat="server" OnSelectedIndexChanged="ddlAnioCorrienteEstimado_IndexChanged" AutoPostBack="true" ></cc:ExtendedDropDownList>
	                    </td>                                  
                        <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarEtapaEstimada" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarEtapaEstimada" runat ="server" Text="Agregar" OnClick="btAgregarEtapaEstimada_Click" CausesValidation="false" TabIndex ="2"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
                        </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>
    <asp:UpdatePanel ID= "upGridEtapasEstimadas"  runat="server" UpdateMode = "Conditional" >
        <ContentTemplate>
              <div class="<%= scrollDivEstimadas %>">
                  <table cellpadding="0" cellspacing="0px" border="0"   width="100%">
                      <tr>
                        <td style="text-align:right">
                            <strong><asp:Literal ID="litEtapasEstimadasTotal" runat="server" Visible="False" Text=""></asp:Literal></strong>
                        </td>
                      </tr>	
                      <tr>
                          <td>
                            <asp:GridView ID="gridEtapasEstimadas" runat = "server"
                            AutoGenerateColumns="True" DataKeyNames="ID"   
                            OnRowCommand="GridEtapasEstimadas_RowCommand"
                            RowDataBound="algo"
                            EmptyDataText="Para cargar los Gastos Estimados, las Fechas Estimadas del Cronograma deben estar definidas." >
                                <Columns>                   
                                    <%--Estos botones no son los que se muestran en pantalla, esos botones se cargan dinamicamente. El objetivo de agregarlos aca es para evitar que desaparezca la grilla dinamica en algunos navegadores--%>
                                    <asp:TemplateField Visible="false" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="50px" >
                                        <ItemTemplate>
                                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CssClass='<%# EnableEtapaEstimadaUpdate==true?"":"ibDisable"  %>' Enabled='<%# EnableEtapaEstimadaUpdate %>'   CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                            &nbsp;
                                            <asp:ImageButton ID ='imgDelete' runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>' CssClass='<%# EnableEtapaEstimadaUpdate==true?"":"ibDisable"  %>' Enabled='<%# EnableEtapaEstimadaUpdate%>'    OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                        </ItemTemplate> 
                                    </asp:TemplateField>
                    
                                </Columns>
                            </asp:GridView>
                          </td>
                      </tr>	 
                   </table> 
               </div>
            </ContentTemplate>
        </asp:UpdatePanel>
</asp:panel>

    <asp:panel id="pnlEtapaRealizada" runat="server" groupingtext="Gastos Realizados">
        <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                    <tr>  
	                    <td style="width:100px"><asp:Literal ID="Literal1" runat="server" Text="Mostrar Desde"></asp:Literal></td>
	                    <td style="width:100px">
	                        <cc:ExtendedDropDownList ID="ddlAnioCorrienteRealizado" runat="server" OnSelectedIndexChanged="ddlAnioCorrienteRealizado_IndexChanged" AutoPostBack="true" ></cc:ExtendedDropDownList>
	                    </td>                    
                        <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarEtapaRealizada" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarEtapaRealizada" runat ="server" Text="Agregar" OnClick="btAgregarEtapaRealizada_Click" TabIndex ="2" CausesValidation="false"  /> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
                        </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>
    
        <asp:UpdatePanel ID= "upGridEtapasRealizadas"  runat="server" UpdateMode = "Conditional" >
        <ContentTemplate>
            <div class="<%= scrollDivRealizadas %>">        
                <table cellpadding="0" cellspacing="0px" border="0"   width="100%">
                      <tr>
                        <td style="text-align:right">
                            <strong><asp:Literal ID="litEtapasRealizadasTotal" runat="server" Visible="False" Text=""></asp:Literal></strong>
                        </td>
                      </tr>	
                      <tr>
                          <td>
                            <asp:GridView ID="gridEtapasRealizadas" runat = "server"
                                AutoGenerateColumns="True" DataKeyNames="ID" AllowPaging="False"  
                                OnRowCommand="GridEtapasRealizadas_RowCommand" 
                                AllowSorting="false"
                                EmptyDataText="Para cargar los Gastos Realizados, la Fecha de Inicio Realizada del Cronograma debe estar definida y el Estado Financiero del proyecto debe ser 'En Ejecución'">

                                <Columns> 
                                    <%--Estos botones no son los que se muestran en pantalla, esos botones se cargan dinamicamente. El objetivo de agregarlos aca es para evitar que desaparezca la grilla dinamica en algunos navegadores--%>
                                    <asp:TemplateField Visible="false"  ItemStyle-HorizontalAlign="Center" >
                                        <ItemTemplate>
                                            &nbsp;
                                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CssClass='<%# EnableEtapaRealizadaUpdate==true?"":"ibDisable"  %>' Enabled='<%# EnableEtapaRealizadaUpdate %>'    CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                                            &nbsp;
                                            <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>' CssClass='<%# EnableEtapaRealizadaUpdate==true?"":"ibDisable"  %>' Enabled='<%# EnableEtapaRealizadaUpdate %>'    OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                                        </ItemTemplate>            
                                        <ItemStyle Width="50px"  HorizontalAlign ="Right"/>
                                    </asp:TemplateField>
                                </Columns>
                                </asp:GridView>
                          </td>
                      </tr>
                    </table>	
            </div>                        
            </ContentTemplate>    
        </asp:UpdatePanel>
    </asp:panel>

<cc:NumericTextBox id="txtMontoXXX" runat="server" Visible="False"  UseSeparadorMiles ="true"  InputType="PositiveInteger" ></cc:NumericTextBox>
</div>


<%--PANEL INFO PRESUPUESTARIA --%>
<asp:panel id="PopUpInfoPresupuestaria" runat="server" width="800px" style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="InfoPresupuestariaPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                    <th align="center" height="10">
                                <asp:Label ID="Label1" runat="server" Text="Información Presupuestaria" />
                    </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnInfoPresupuestaria" DefaultButton="btCancelTotales" runat="server">
        <asp:UpdatePanel ID="upInfoPresupuestariaPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            &nbsp;
                            <asp:Label ID="Label2" runat ="server" Text ="Año Presupuestario"></asp:Label>
                            &nbsp;
                            <asp:Label ID="lblAnioPresupuestario" runat ="server" Text =""></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <asp:GridView ID="gvInfoPresupuestaria" runat="server"  Width="100%" DataKeyNames="ID"
                            AutoGenerateColumns="False" AllowSorting="False" EmptyDataText="No se registran datos con montos mayores a cero.">                                          
                            <Columns> 
                                <asp:BoundField HeaderText ="Obj.del Gasto" DataField ="ObjDelGasto" SortExpression ="ObjDelGasto"  HeaderStyle-Width ="35%" />
                                <asp:BoundField HeaderText ="F.Financiamiento" DataField ="FFinanciamiento" SortExpression ="FFinanciamiento"  HeaderStyle-Width ="20%" />
                                <asp:TemplateField   HeaderText="Monto Inicial"  HeaderStyle-Width ="10%" >            
                                    <ItemTemplate>                        
                                        <cc:NumericTextBox id="txtc" runat="server" Width="97px" DataFormatString="{0:F2}"  Text='<%#string.Format("{0:F2}",Eval("MontoInicial")) %>' Enabled='false'  UseSeparadorMiles ="true"  InputType="PositiveFractional" ></cc:NumericTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField   HeaderText="Monto Vigente"  HeaderStyle-Width ="10%" >            
                                    <ItemTemplate>                        
                                        <cc:NumericTextBox id="txtMontoVigente" runat="server" Width="97px" DataFormatString="{0:F2}"  Text='<%#string.Format("{0:F2}",Eval("MontoVigente")) %>' Enabled='false'  UseSeparadorMiles ="true"  InputType="PositiveFractional" ></cc:NumericTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>	
                                <asp:TemplateField   HeaderText="MVE (*)"  HeaderStyle-Width ="8%" >            
                                    <ItemTemplate>                        
                                        <asp:CheckBox id="cbMontoVigenteEstimativo" runat="server" Enabled='false' Checked='<%# Convert.ToBoolean(Eval("MontoVigenteEstimativo")) %>'></asp:CheckBox>
                                    </ItemTemplate>
                                </asp:TemplateField>
                                <asp:TemplateField   HeaderText="Monto Devengado"  HeaderStyle-Width ="10%" >            
                                    <ItemTemplate>                        
                                        <cc:NumericTextBox id="txtMontoDevengado" runat="server" Width="97px" DataFormatString="{0:F2}"  Text='<%#string.Format("{0:F2}",Eval("MontoDevengado")) %>' Enabled='false' UseSeparadorMiles ="true"  InputType="PositiveFractional" ></cc:NumericTextBox>
                                    </ItemTemplate>
                                </asp:TemplateField>		                                   
                            </Columns>
                        </asp:GridView> 
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                          
                            <asp:Button ID="Button8" Text="Cerrar" OnClick="btCerrarInfoPresupuestaria_Click" CausesValidation="false" 
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="btnInfoPresupuestaria" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderInfoPresupuestaria" runat="server" CancelControlID="btnInfoPresupuestaria"
        PopupDragHandleControlID="InfoPresupuestariaPopUpDragHandle" PopupControlID="PopUpInfoPresupuestaria"
        OkControlID="btnInfoPresupuestaria" TargetControlID="btnInfoPresupuestaria" BackgroundCssClass="modalBackground" />
</asp:panel>

<%--PANEL ALTA ETAPAS --%>
<asp:panel id="PopUpEtapas" runat="server" width="800px" style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EtapasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                    <th align="center" height="10">
                                <asp:Label ID="headerPopUpEtapas" runat="server" Text="Etapa" />
                    </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEtapas" DefaultButton="btSaveEtapas" runat="server">
        <asp:UpdatePanel ID="upEtapasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 100%;padding:7px">
                                            <table>
                                                <tr>
                                                    <td colspan="4"><asp:Label ID="lblEtapa" runat="server" Text=""  ></asp:Label></td>
                                                </tr>
                                                <tr><td colspan="4"><br /></td></tr>
                                                <tr>
                                                    <td><asp:Literal ID="litEstado" runat="server" Text="Estado Financiero" ></asp:Literal></td>
                                                    <td><cc:ExtendedDropDownList ID="ddlEstado" runat="server" Width="150px" TabIndex="2"></cc:ExtendedDropDownList></td>
                                                    <td colspan="2" align="center" style="color:Red;margin:10px"><asp:Label ID="lblErrorEtapa" runat="server" Text=""  Visible="false" ></asp:Label></td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Literal ID="litFIE" runat="server" Text="Fecha Inicio Estimada" ></asp:Literal></td>
                                                    <td><uc:DateInput ID="diFIE" runat="server" Width="100px" ValidationGroup="vgEtapas"/></td>
                                                    <td><asp:Literal ID="litFFE" runat="server" Text="Fecha Fin Estimada" ></asp:Literal></td>
                                                    <td><uc:DateInput ID="diFFE" runat="server" Width="100px" ValidationGroup="vgEtapas" /></td>
                                                </tr>
                                                <tr>
                                                    <td><asp:Literal ID="litFIR" runat="server" Text="Fecha Inicio Realizada" ></asp:Literal></td>
                                                    <td><uc:DateInput ID="diFIR" runat="server" Width="100px" ValidationGroup="vgEtapas" /></td>
                                                    <td><asp:Literal ID="litFRR" runat="server" Text="Fecha Fin Realizada" ></asp:Literal></td>
                                                    <td><uc:DateInput ID="diFFR" runat="server" Width="100px" ValidationGroup="vgEtapas" /></td>
                                                </tr>
                                            </table>                                            
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveEtapas" Text="Aceptar" OnClick="btSaveEtapa_Click" runat="server" ValidationGroup="vgEtapas" />
                            <asp:Button ID="btCancelEtapas" Text="Cerrar" OnClick="btCancelEtapa_Click" CausesValidation="false" runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:ValidationSummary ID="vgEtapas" runat="server" DisplayMode="BulletList" ValidationGroup="vgEtapas" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEtapas" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="EtapasPopUpDragHandle" PopupControlID="PopUpEtapas"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:panel>

<%--PANEL ALTA ESTIMADOS --%>
<asp:panel id="PopUpEtapasEstimadas" runat="server" width="900px" style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EtapasEstimadasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                        <asp:Literal ID="headerPopUpEtapasEstimadas" runat="server" Text="Cronograma Estimados" />
                </th>
                
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEtapasEstimadas" DefaultButton="btSaveEtapasEstimadas" runat="server">
        <asp:UpdatePanel ID="upEtapasEstimadasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td align ="right" >
                            <asp:Button ID="btFirstEtapaEstimada" runat ="server" Text ="<<" 
                                onclick="btFirstEtapaEstimada_Click" CausesValidation ="false" />
                            <asp:Button ID="btBackEtapaEstimada" runat ="server" Text ="<" 
                                onclick="btBackEtapaEstimada_Click" CausesValidation ="false" />
                            <asp:Button ID="btNextEtapaEstimada" runat ="server" Text =">" 
                                onclick="btNextEtapaEstimada_Click"  CausesValidation ="false" />
                            <asp:Button ID="btLastEtapaEstimada" runat ="server" Text =">>" 
                                onclick="btLastEtapaEstimada_Click" CausesValidation ="false" />
                        </td>
                    </tr>
                    <tr>
                        <td >
                            <table width="90%">
                                <tr>
                                        <td style="width: 40%;" valign="top" >
                                            <asp:Panel ID="pnlBuscarObjetoGastoEstimado" runat="server" GroupingText="Buscar Objeto del Gasto">
                                                <table >
                                                <%--<tr>
                                                    <td valign="top"><asp:RadioButton ID="rbPorCodigoEstimada" runat="server" Text="Por Código" GroupName="obrGroupEsti" OnCheckedChanged="rbPorCodigoEstimada_OnCheckedChanged" AutoPostBack="true" /><br /></td>
                                                    <td valign="top"><asp:RadioButton ID="rbPorDescripcionEstimada" runat="server" Text="Por Descripción" GroupName="obrGroupEsti"  OnCheckedChanged="rbPorCodigoEstimada_OnCheckedChanged" AutoPostBack="true" /></td>
                                                </tr>--%>
                                                <tr>
                                                <td valign="top">
                                                    <%--<uc:Autocomplete runat="server" ID="acGastosEstimada" AutoPostback="true" Width="280" MinimumPrefixLength="2" ></uc:Autocomplete>--%>
                                                    <uc:TreeControl runat="server" ID="acGastosEstimada" SelectOption="OnlySelectedDefined" RequiredValue="true" ValidationGroup="vgEtapasEstimadas" Width="400px" ></uc:TreeControl>
                                                </td></tr></table>
                                            </asp:Panel>
                                        </td>
                                        <td style="width: 60%;padding:7px">
                                                <table>
                                                <tr>
                                                    <td><asp:Literal ID="litFFinanciamientoEstimada" runat="server" Text="F.Financiamiento" ></asp:Literal></td>
                                                    <td><uc:TreeFuenteFinanciamiento runat="server" ID="tsFuenteFinanciamientoEstimada" RequiredValue="true" SelectOption="SelectedDefinedAndActualValue" ShowOption="ActivesAndActualValue">
                                                  </uc:TreeFuenteFinanciamiento></td>
                                                </tr>
                                                <%--<tr>
                                                    <td><asp:Literal ID="litOFinanciamientoEstimada" runat="server" Text="O. Financiamiento" ></asp:Literal></td>
                                                    <td><asp:DropDownList ID="ddlOFinanciamientoEstimada" runat="server"  Width="50px" ></asp:DropDownList></td>
                                                </tr>--%>
                                                <tr>
                                                    <td align="left"><asp:Literal ID="litMonedaEstimada" runat="server" Text="Moneda" ></asp:Literal></td>
                                                    <td><cc:ExtendedDropDownList ID="ddlMonedaEstimada" runat="server"  Width="150px" AutoPostBack="true" OnSelectedIndexChanged="ddlMonedaEstimada_OnSelectedIndexChanged" ></cc:ExtendedDropDownList></td>
                                                </tr>
                                                <tr>
                                                    <td colspan="2" align="center" style="color:Red;margin:10px"><asp:Label ID="lblErrorEtapaEstimada" runat="server" Text="" Visible="false" ></asp:Label></td>
                                                </tr>                                                
                                                </table>                                            
                                        </td>
                                </tr>
                                <tr>
                                <td colspan="2" >
                                        <asp:GridView ID="GridPeriodoEstimado" runat="server"  Width="100%" DataKeyNames="ID"
                                            AutoGenerateColumns="False" AllowSorting="False" OnDataBound ="GridPeriodoEstimado_OnDataBound">                                          
                                            <Columns> 
                                                <asp:BoundField HeaderText ="" DataField ="Periodo" SortExpression ="Periodo"  HeaderStyle-Width ="6%" />
                                                <asp:TemplateField   HeaderText="Moneda Externa" HeaderStyle-Width ="17%" >            
                                                    <ItemTemplate>                         
                                                        <cc:NumericTextBox id="txtMonedaEstimado" runat="server"  Width="120px" DataFormatString="{0:F2}"  Text='<%# string.Format("{0:F2}",Eval("MontoPeriodo")) %>'  Enabled='<%#!(bool)Eval("UsaMonedaBase")%>'  UseSeparadorMiles ="true"  InputType="PositiveInteger" ></cc:NumericTextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField   HeaderText="Tipo de Cambio"  HeaderStyle-Width ="17%" >            
                                                    <ItemTemplate>                        
                                                        <cc:NumericTextBox id="txtTipoCambioEstimado" runat="server" Width="120px" DataFormatString="{0:F2}"  Text='<%#string.Format("{0:F2}",Eval("CotizacionPeriodo")) %>' Enabled='<%#!(bool)Eval("UsaMonedaBase")%>'  UseSeparadorMiles ="true"  InputType="PositiveFractional" ></cc:NumericTextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>
                                                <asp:TemplateField   HeaderText="Monto"  HeaderStyle-Width ="17%" >            
                                                    <ItemTemplate>                        
                                                        <cc:NumericTextBox id="txtMontoEstimado" runat="server" ValidationGroup="vgEtapasEstimadas" Width="120px" DataFormatString="{0:N0}" Text='<%#string.Format("{0:N0}",Eval("MontoCalculadoPeriodo")) %>'  Enabled='<%#!(bool)Eval("Bloqueado") && (bool)Eval("UsaMonedaBase")%>'  UseSeparadorMiles ="true"  InputType="PositiveInteger" ></cc:NumericTextBox>
                                                    </ItemTemplate>
                                                </asp:TemplateField>		                                   
                                            </Columns>
                                        </asp:GridView> 
                                </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveEtapasEstimadas" Text="Aceptar" OnClick="btSaveEtapaEstimada_Click" runat="server" ValidationGroup="vgEtapasEstimadas" />
                            <asp:Button ID="btNewEtapasEstimadas" Text="Aceptar y Agregar Nuevo" OnClick="btNewEtapaEstimada_Click" runat="server" ValidationGroup="vgEtapasEstimadas" />
                            <asp:Button ID="btCancelEtapasEstimadas" Text="Cerrar" OnClick="btCancelEtapaEstimada_Click" CausesValidation="false"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button4" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEtapasEstimadas" runat="server" CancelControlID="Button4"
        PopupDragHandleControlID="EtapasEstimadasPopUpDragHandle" PopupControlID="PopUpEtapasEstimadas"
        OkControlID="Button4" TargetControlID="Button4" BackgroundCssClass="modalBackground" />
</asp:panel>

<%--PANEL ALTA REALIZADOS --%>
<asp:Panel ID="PopUpEtapasRealizadas" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="EtapasRealizadasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <th align="center" height="10">
                    <asp:Literal ID="headerPopUpEtapasRealizadas" runat="server" Text="Cronograma Realizados" />
                </th>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnEtapasRealizadas" DefaultButton="btSaveEtapasRealizadas" runat="server">
        <asp:UpdatePanel ID="upEtapasRealizadasPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <tr>
                                    <td style="width: 50%;" valign="top" >
                                        <asp:Panel ID="pnlBuscarObjetoGastoRealizado" runat="server" GroupingText="Buscar Objeto del Gasto">
                                            <table >
                                            <%--<tr>
                                                <td valign="top"><asp:RadioButton ID="rbPorCodigoRealizada" runat="server" Text="Por Código" GroupName="obrGroup" OnCheckedChanged="rbPorCodigoRealizada_OnCheckedChanged" AutoPostBack="true"  /><br /></td>
                                                <td valign="top"><asp:RadioButton ID="rbPorDescripcionRealizada" runat="server" Text="Por Descripción" GroupName="obrGroup"  OnCheckedChanged="rbPorCodigoRealizada_OnCheckedChanged" AutoPostBack="true"/></td>
                                            </tr>--%>
                                            <tr>
                                            <td valign="top">
                                                <%--<uc:Autocomplete runat="server" ID="acGastosRealizada" AutoPostback="true" Width="280" MinimumPrefixLength="2" ></uc:Autocomplete>--%>
                                                <uc:TreeControl runat="server" ID="acGastosRealizada" Width="370px" ></uc:TreeControl>
                                            </td></tr></table>
                                        </asp:Panel>
                                    </td>
                                    <td style="width: 50%;padding:7px">
                                            <table>
                                            <tr>
                                            
                                                <td><asp:Literal ID="litFFinanciamientoRealizada" runat="server" Text="F.Financiamiento" ></asp:Literal></td>
                                                <td>
                                                <uc:TreeFuenteFinanciamiento runat="server" ID="tsFuenteFinanciamientoRealizada" RequiredValue="true" SelectOption="SelectedDefinedAndActualValue" ShowOption="ActivesAndActualValue">
                                                  </uc:TreeFuenteFinanciamiento>                      
                                                 </td>
                                            </tr>
                                           <%-- <tr>
                                                <td><asp:Literal ID="litOFinanciamientoRealizada" runat="server" Text="O. Financiamiento" ></asp:Literal></td>
                                                <td><asp:DropDownList ID="ddlOFinanciamientoRealizada" runat="server"  Width="50px"  ></asp:DropDownList></td>
                                            </tr>--%>
                                            <tr>
                                                <td><asp:Literal ID="litMonedaRealizada" runat="server" Text="Moneda" ></asp:Literal></td>
                                                <td><cc:ExtendedDropDownList ID="ddlMonedaRealizada" runat="server"  Width="150px" AutoPostBack="true"  OnSelectedIndexChanged="ddlMonedaRealizada_OnSelectedIndexChanged"></cc:ExtendedDropDownList></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="litPeriodoRealizada" runat="server" Text="Período" ></asp:Literal></td>
                                                <td><cc:ExtendedDropDownList ID="ddlPeriodoRealizada" runat="server"  Width="150px"></cc:ExtendedDropDownList></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="litFechaRealizada" runat="server" Text="Fecha" ></asp:Literal></td>
                                                <td><uc:DateInput ID="diFechaRealizada" runat="server" ValidationGroup="vgEtapasRealizadas"/></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="litMonedaExternaRealizada" runat="server" Text="Moneda Externa" ></asp:Literal></td>
                                                <td><cc:NumericTextBox ID="tbMonedaExternaRealizada" runat="server" Enabled="false" AutoPostBack="true"  OnTextChanged="tbTipoDeCambioRealizada_OnTextChanged" InputType="PositiveInteger" UseSeparadorMiles ="true"  ></cc:NumericTextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="litTipoDeCambioRealizada" runat="server" Text="Tipo de Cambio" ></asp:Literal></td>
                                                <td><cc:NumericTextBox ID="tbTipoDeCambioRealizada" runat="server" Enabled="false" AutoPostBack="true"  OnTextChanged="tbTipoDeCambioRealizada_OnTextChanged"  InputType="PositiveFractional" ></cc:NumericTextBox></td>
                                            </tr>
                                            <tr>
                                                <td><asp:Literal ID="litMontoRealizda" runat="server" Text="Monto" ></asp:Literal></td>
                                                <td><cc:NumericTextBox ID="tbMontoRealizda" runat="server"  InputType="PositiveInteger" UseSeparadorMiles ="true" ></cc:NumericTextBox></td>
                                            </tr>   
                                            <tr>
                                                <td colspan="2" align="center" style="color:Red;margin:10px"><asp:Label ID="lblErrorEtapaRealizada" runat="server" Text="" Visible="false" ></asp:Label></td>
                                            </tr>                                                                                                                                 
                                            </table>                                            
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveEtapasRealizadas" Text="Aceptar" OnClick="btSaveEtapaRealizada_Click"   runat="server" ValidationGroup="vgEtapasRealizadas" />
                            <asp:Button ID="btNewEtapasRealizadas" Text="Aceptar y Agregar Nuevo" OnClick="btNewEtapaRealizada_Click"  runat="server" ValidationGroup="vgEtapasRealizadas" />
                            <asp:Button ID="btCancelEtapasRealizadas" Text="Cerrar" OnClick="btCancelEtapaRealizada_Click" CausesValidation="false"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button1" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEtapasRealizadas" runat="server" CancelControlID="Button1"
        PopupDragHandleControlID="EtapasRealizadasPopUpDragHandle" PopupControlID="PopUpEtapasRealizadas"
        OkControlID="Button1" TargetControlID="Button1" BackgroundCssClass="modalBackground" />
</asp:Panel>

<%--Totales --%>
<asp:panel id="PopUpTotales" runat="server" width="800px" style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="DemorasPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpTotales" runat="server" Text="Totales" />
                    </th>
                
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnTotales" DefaultButton="btCancelTotales" runat="server">
        <asp:UpdatePanel ID="upTotalesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <asp:Image id="img" runat ="server" ImageUrl="~/Images/alert.png" />
                        </td>
                        <td>
                            <asp:Label ID="lbAdvertencia" runat ="server" Text ="Deberá Guardar los cambios para que se vean reflejados en el presente listado"></asp:Label>
                        </td>
                    </tr>
                    <tr>
                        <td colspan ="2">
                            <asp:GridView ID="gvTotales" runat = "server" AutoGenerateColumns ="false" 
                                Width="100%" OnSorting="gvTotales_Sorting"  >
                                <Columns >
                                    <asp:BoundField HeaderText ="Año" DataField="Anio" />
                                    <asp:BoundField HeaderText ="Estimado" DataField ="Estimado" DataFormatString="{0:N0}"/>
                                    <asp:BoundField HeaderText ="Realizado" DataField="Realizado" DataFormatString="{0:N0}"/>
                                </Columns>
                            </asp:GridView>
                        </td>
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                          
                            <asp:Button ID="btCancelTotales" Text="Cerrar" OnClick="btCancelTotales_Click" CausesValidation="false" 
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button7" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderTotales" runat="server" CancelControlID="Button7"
        PopupDragHandleControlID="TotalesPopUpDragHandle" PopupControlID="PopUpTotales"
        OkControlID="Button7" TargetControlID="Button7" BackgroundCssClass="modalBackground" />
</asp:panel>
