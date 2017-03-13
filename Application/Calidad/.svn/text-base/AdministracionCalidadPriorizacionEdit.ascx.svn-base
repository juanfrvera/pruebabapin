<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministracionCalidadPriorizacionEdit.ascx.cs" Inherits="UI.Web.AdministracionCalidadPriorizacionEdit" %>
<%@ Register TagPrefix="uc" TagName="ProyectoCalidadTabPanel" Src="~/ControlsPersonal/WebControl_CalidadTabPanel.ascx" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>
<style type ="text/css">
    .smallCheck
    {
        font-size:x-small;
    }
</style>

<table width="100%">
<tr>
    <td style="vertical-align:top;width:46%;">
        <asp:Panel ID="pnlHojaDeCalidad" runat="server" GroupingText ="Datos del Proyecto" width="530px" >
            <table width="100%"  cellpadding="0" cellspacing="5px" border="0">
            <tr>
                <td colspan='2'>&nbsp;</td>
            </tr>        
            <tr>
                <td style="width:5%">&nbsp;</td>
                <td style="width:95%"><asp:Literal ID="litActual" runat="server" Text="Actual"></asp:Literal></td>                        
            </tr>
            <tr>
                <td><asp:Literal ID="litDenominacion" runat="server" Text="Denominación"></asp:Literal></td>
                <td><asp:TextBox ID="tbDenominacionActual" runat="server" TextMode="MultiLine" Rows="3" Enabled="false" Width="305"></asp:TextBox></td>
            </tr>
            <tr>
                <td><br/><br/><br/></td>
                <td><br/><br/><br/></td>                        
            </tr>        
            <tr>
                <td><asp:Literal ID="litTipoProyecto" runat="server" Text="Tipo de Proyecto"></asp:Literal></td>
                <td><asp:DropDownList ID="ddlTipoProyectoActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Literal ID="litEstado" runat="server" Text="Estado"></asp:Literal></td>
                <td><asp:DropDownList ID="ddlEstadoActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            </tr>                    
            <tr>
                <td><asp:Literal ID="litProceso" runat="server" Text="Proceso"></asp:Literal></td>
                <td><asp:DropDownList ID="ddlProcesoActual" runat="server"  Enabled="false" ></asp:DropDownList></td>
            </tr>                    
            <tr>
                <td><asp:Literal ID="litFinalidad" runat="server" Text="Finalidad Función"></asp:Literal></td>
                <td><asp:DropDownList ID="ddlFinalidadActual" runat="server" Enabled="false" ></asp:DropDownList></td>
            </tr>
            <tr>
                <td><asp:Literal ID="litProvincias" runat="server" Text="Provincias"></asp:Literal></td>
                <td >
                    <table ><tr><td style="vertical-align:top">
                        <asp:DataList ID="dlProvinciasA" runat="server" CellSpacing="0" CellPadding="0">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkA" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                                <asp:HiddenField ID="hdValueA" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td><td valign="top">
                       <asp:DataList ID="dlProvinciasB" runat="server"  CellSpacing="0" CellPadding="0">
                            <ItemTemplate>
                                <asp:CheckBox ID="chkB" Checked='<%# Bind("Selected") %>' Text='<%# Bind("Nombre") %>' runat="server" CssClass="smallCheck" Enabled="false" />
                                <asp:HiddenField ID="hdValueB" Value='<%# Bind("IdClasificacionGeografica") %>' runat="server" />
                            </ItemTemplate>
                        </asp:DataList>
                    </td></tr></table>
                </td>
            </tr>
            <tr>
                <td><asp:Literal ID="litUltPlan" runat="server" Text="Ult. Plan"></asp:Literal></td>
                <td><asp:TextBox runat="server" ID="tbUltPlan" Width="300px"  Enabled="false"/></td>
            </tr>
            <tr>
                <td><asp:Literal ID="litArt15" runat="server" Text="Art.15"></asp:Literal></td>
                <td><asp:CheckBox runat="server" ID="cbArt15" Enabled="false" /></td>
            </tr>
            <tr>
                <td><asp:Literal ID="litDictamen" runat="server" Text="Dictamen"></asp:Literal></td>
                <td><asp:TextBox runat="server" ID="tbDictamen" Width="300px" Enabled="false" /></td>
            </tr>        
            <tr>
                <td><asp:Literal ID="litUltPriorizacion" runat="server" Text="Ult. Priorización"></asp:Literal></td>
                <td><asp:TextBox runat="server" ID="tbUltPriorizacion"  Width="300px" Enabled="false"/></td>
            </tr>        
            <tr>
                <td><asp:Literal ID="litPrioriOrga" runat="server" Text="Prioridad Organismo"></asp:Literal></td>
                <td><asp:TextBox runat="server" ID="tbPrioOrganismo"  Width="150px" Enabled="false"/>&nbsp;<asp:TextBox runat="server" ID="tbPrioOrganismoNro"  Width="140px" Enabled="false"/></td>
            </tr>                
        </table>                
        </asp:Panel>
    </td>
    <td  style="vertical-align:top;width:54%;padding-top:5px;" align="center">   
      <asp:UpdatePanel ID= "upCalidad"  runat="server" UpdateMode = "Conditional" >
      <ContentTemplate>
      <div style="margin: 0 auto;text-align:center;background-color:red">
          <ul class="TabbedPanelsTabGroup">
            <li id="ProyectoCalidadPageEdit" class="TabbedPanelsTab" runat="server">
                <asp:LinkButton runat="server" ID="lnkCalidadAdministracion" TabIndex="1"
                CommandArgument="~/Calidad/AdministracionCalidadPageEdit.aspx" 
                CommandName="<%# Command.CONFIRM_CHANGE_PAGE %>" CausesValidation ="false" 
                oncommand="lnk_Command" Text="Calidad" ></asp:LinkButton>    
            </li>
            <li id="Li1" class="TabbedPanelsTabSelected" runat="server">
                <asp:LinkButton runat="server" ID="lnkoCalidadPriorizacion" TabIndex="1"
                CommandArgument="~/Calidad/AdministracionCalidadPriorizacionPageEdit.aspx" 
                CommandName="<%# Command.CONFIRM_CHANGE_PAGE %>" CausesValidation ="false" 
                oncommand="lnk_Command" Text="Priorización" ></asp:LinkButton>    
            </li>
          </ul>
        </div>  
               
        <table width="100%"  cellpadding="0" cellspacing="17px" border="0" class="TabbedPanelsContentGroup" >
            <tr>
                <td colspan="4" align="left" runat="server" style="font-size: medium;font-weight:bold">
                    <asp:Literal runat="server" ID="litPlan" Text="Plan: " />&nbsp;
                    <asp:Label runat="server" ID="lblPlan" Text="" ></asp:Label>
                </td>
            </tr>
            <tr>
                <td align="left" colspan="2">
                    <asp:Label runat="server" ID="lblCalculada" Text="Prioridad Calculada" ></asp:Label>
                </td>
                <td align="left" colspan="2">
                    <asp:CheckBox ID="chkPrioridadAsignada" runat = "server" Text ="Prioridad Asignada" />                    
                </td>
            </tr>
            <tr>            
                <td align="left">
                    <asp:Literal ID="liOri" runat = "server" Text ="Original" ></asp:Literal>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtOriginal" runat = "server" Width="150px" ></asp:TextBox>
                </td>            
                <td align="left">
                    <asp:Literal ID="liFinal" runat = "server" Text ="Final" ></asp:Literal>
                </td>
                <td align="left">
                    <cc:ExtendedDropDownList ID="ddlPrioridad" runat = "server" Width="200px" OnSelectedIndexChanged="ddlPrioridad_OnSelectedIndexChanged" AutoPostBack="true"  ></cc:ExtendedDropDownList>
                </td>
            </tr>
            <tr>
                <td align="left">
                    <asp:Literal ID="Literal1" runat = "server" Text ="Asignado" ></asp:Literal>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtAsignado"  runat = "server"  Width="150px" ></asp:TextBox>
                </td>            
                <td align="left">
                    <asp:Literal ID="liPuntaje" runat = "server" Text ="Puntaje" ></asp:Literal>
                </td>
                <td align="left">
                    <asp:TextBox ID="txtPuntaje"  runat = "server"  Width="192px" ></asp:TextBox>
                </td>
            </tr>
            <tr>
                <td colspan ="4"  align="left" >
                    <table width="100%">
                        <tr>
                            <td>
                                <asp:CheckBox ID ="chkConfReq" runat = "server" Text ="Conf. Requerimientos" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <asp:Literal ID="liClasificacion" runat = "server" Text = "Clasificación" ></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <asp:CheckBox ID ="chkReqArt15" runat = "server" Text ="Requiere Art. 15" />
                            </td>
                            <td>
                            </td>
                            <td>
                                <cc:ExtendedDropDownList ID="ddlClasificacion" runat = "server"  Width="250px"></cc:ExtendedDropDownList>
                            </td>
                        </tr>                        
                        <tr>
                            <td></td>
                        </tr>
                        <tr>
                            <td>
                            <br/>
                                <asp:Literal ID="liComentario" runat = "server" Text ="Comentario" ></asp:Literal>
                            </td>
                        </tr>
                        <tr>
                            <td colspan ="3"><br/>
                                <asp:TextBox ID ="txtComentario" runat = "server" TextMode="MultiLine" Rows ="10" Width="100%" ></asp:TextBox>
                            </td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>        
        </ContentTemplate>
      </asp:UpdatePanel>   
        <asp:Panel ID="panelIndicadoresPriorizacion" runat="server" GroupingText="Indicadores"> <!-- Matias 20141105 - Tarea 170 -->
            <!--Matias 20140218 - Tarea 115 - (Entra: UpdatePanel | Sale: Panel)-->
                <asp:UpdatePanel ID="upPriorizacion" runat="server" UpdateMode="Conditional">
                <ContentTemplate>
                <!--<asp:Panel ID="pnlPriorizacion2" runat="server" GroupingText="Indicadores">-->
                <asp:GridView ID="gridProyectoPriorizacion" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="False" AllowSorting="True" EmptyDataText="No hay elementos"
                    Width="100%">
                    <Columns>
                        <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                        <asp:BoundField HeaderText="Valor" DataField="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Right"
                            DataFormatString="{0:0.#}" />
                        <asp:BoundField HeaderText="Año" DataField="Anio" SortExpression="Anio" />
                        <asp:BoundField HeaderText="Comentario" DataField="Observacion" SortExpression="Observacion" />
                    </Columns>
                </asp:GridView>
                <!--</asp:Panel>-->
                </ContentTemplate>
	            </asp:UpdatePanel>
            </asp:Panel>         
    </td>
</tr>
<tr>
    <td colspan="2">
        <asp:Panel ID="pnlEtapaEstimada" runat="server" GroupingText="Gastos Estimados">
            <div style="text-align:right;width:100%">
                <asp:Literal runat="server" id="litMonto1" Text="Monto Total:" />&nbsp;
                <asp:Label runat="server" id="lbMontoEstimado" Text="" />
            </div>
             <asp:GridView ID="gridEtapasEstimadas" runat = "server"
                AutoGenerateColumns="True" DataKeyNames="ID"   
                EmptyDataText="No hay elementos definidos" 
                Width ="100%">
                <Columns>                   
                </Columns>
                </asp:GridView>
        </asp:Panel>
        <asp:Panel ID="pnlEtapaRealizada" runat="server" GroupingText="Gastos Realizados">
            <div style="text-align:right;width:100%">
                <asp:Literal runat="server" id="litMonto2" Text="Monto Total:" />&nbsp;
                <asp:Label runat="server" id="lbMontoRealizado" Text="" />
            </div>
            <asp:GridView ID="gridEtapasRealizadas" runat = "server"
                AutoGenerateColumns="True" DataKeyNames="ID" 
                EmptyDataText="No hay elementos definidos" 
                Width ="100%">
                <Columns> 
                </Columns>
                </asp:GridView>
        </asp:Panel>
     <%--   <asp:Panel ID="pnlPriorizacion" runat ="server" GroupingText="Indicadores">
                <asp:GridView ID="gridProyectoPrioridad" runat="server" AutoGenerateColumns="False"
                    DataKeyNames="ID" AllowPaging="True" AllowSorting="True" EmptyDataText="No hay elementos" Width="100%">                    
                    <Columns>
                                <asp:BoundField HeaderText="Descripción" DataField="IndicadorClase_Nombre" SortExpression="IndicadorClase_Nombre" />
                                <asp:BoundField HeaderText="Valor" DataField="Valor" SortExpression="Valor" ItemStyle-HorizontalAlign="Right" DataFormatString="{0:0.#}"/>
                                <asp:BoundField HeaderText="Año" DataField="Anio" SortExpression="Anio" />                                
                                <asp:BoundField HeaderText="Comentario" DataField="Observacion" SortExpression="Observacion" />
                    </Columns>
                </asp:GridView>
            </asp:Panel>
       --%>
    </td>
</tr>
</table>
