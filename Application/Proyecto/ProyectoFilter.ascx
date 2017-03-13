<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoFilter.ascx.cs" Inherits="UI.Web.ProyectoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeLocalizacionGeografica" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx"   %>
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"   %>



<table width="100%"  cellpadding="0" cellspacing="0" border="0">	   
<tr>
	    <td class="tdFilter" style=" width:230px" >
	        <div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:DropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input"  
		            onselectedindexchanged="ddlJurisdiccion_SelectedIndexChanged" AutoPostBack ="true" SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	    </td>
	    <td class="tdFilter" style=" width:230px">
	        <div ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:DropDownList ID="ddlSAF" runat="server" CssClass="field_input" 
                    onselectedindexchanged="ddlSAF_SelectedIndexChanged" AutoPostBack ="true" Enabled="false" SkinID="AnchoLibre" Width="230px"  ></asp:DropDownList></div>
	    </td>
	    <td class="tdFilter" style=" width:230px">
	        <div ><asp:Literal ID="liPrograma" Text="Programa" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:DropDownList ID="ddlPrograma" runat="server" CssClass="field_input" 
                    onselectedindexchanged="ddlPrograma_SelectedIndexChanged" AutoPostBack ="true" Enabled="false"  SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	        
	    </td>
		
	    <td class="tdFilter" style=" width:230px" >
	        <div ><asp:Literal ID="liSubPrograma" Text="SubPrograma" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:DropDownList ID="ddlSubPrograma" runat="server" CssClass="field_input"  Enabled="false"  SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	    </td>  
</tr>
<tr>
<td class="tdFilter" >
	    <div ><asp:Literal ID="liProyectoDenominacion" Text="Denominación" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revProyectoDenominacion" runat="server"  ControlToValidate="txtProyectoDenominacion" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ErrorMessage="El ProyectoDenominacion no es valido"></asp:RegularExpressionValidator></div>
		    <div><asp:TextBox ID="txtProyectoDenominacion" runat="server" CssClass="field_input" Width="225px"  ></asp:TextBox></div>
	    </td>  	    
	   <td>
           <div ><asp:Literal ID="liBorrador" Text="Borrador" runat="server" ></asp:Literal>
           </div>
            <div >
                <uc:ThreeState ID="chkBorrador" runat="server" CssClass="field_input" ></uc:ThreeState>
            </div>
       </td>
	   <td>
              <div><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal>
            </div>  
            <div>
                <uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState>
            </div>
	    </td>
	    <td class="tdFilter" style=" width:230px" rowspan ="2">
	       <div ><asp:Literal ID="liEstado" Text="Estado" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:ListBox ID="lbxEstado" runat="server" CssClass="field_input" SelectionMode="Multiple" Rows="4"  Height="70px" Width="230px" ></asp:ListBox></div>
	    </td>
	    
	    </tr>   
<tr>
         <td class="tdFilter" colspan="3">
         
            <asp:Panel runat="server" GroupingText="Localización"  ID="Panel1" width="715px"  >
                <table style="width:100%;"  cellpadding="0" cellspacing="0" border="0" >
                    <tr>
	                        <td class="tdFilter" > <div> <uc:TreeLocalizacionGeografica runat="server" ID="toLocalizacionGeografica" SelectOption="OnlySelectedDefined"  ShowOption="All" ></uc:TreeLocalizacionGeografica>
	                        </div>
	                        </td>
                       
                        <td class="tdFilter">
                            <asp:CheckBox ID="chkIncluirLocalizacionesInteriores" runat="server" Text="Incluir Subitems"
                                CssClass="field_input"></asp:CheckBox>
                        </td>
                    </tr>
                </table>
            </asp:Panel>
	        
	    </td>	
	    
</tr>   
<tr> 
	    <td class="tdFilter" colspan="3"  > 
	        <asp:Panel runat="server" GroupingText="Plan"  ID="pnlFilter" Width="715px"  >
	            <table width="100%"  cellpadding="0" cellspacing="0" border="0" style="  margin-bottom:0px; ">
	                <tr>
	                    <td >
	                        <div ><asp:Literal ID="liPlanTipo" Text="Tipo" runat="server" ></asp:Literal>&nbsp;</div>
		                    <div><asp:DropDownList ID="ddlPlanTipo" runat="server" CssClass="field_input" 
                                    onselectedindexchanged="ddlPlanTipo_SelectedIndexChanged" AutoPostBack ="true" SkinID="AnchoLibre" Width="180px"  ></asp:DropDownList></div>
                                 <asp:RequiredFieldValidator ID="rfvPlanTipo" runat ="server" Text="*" ValidationGroup ="vgHistoricoPlan" ControlToValidate ="ddlPlanTipo" InitialValue ="0"></asp:RequiredFieldValidator>
		                    
	                    </td>
	                    <td >
	                        <div ><asp:Literal ID="liPlanPeriodo" Text="Período" runat="server" ></asp:Literal>&nbsp;</div>
		                    <div ><asp:DropDownList ID="ddlPlanPeriodo" runat="server" CssClass="field_input" Enabled="false" SkinID="AnchoLibre" Width="150px"></asp:DropDownList></div>
		                          <asp:RequiredFieldValidator ID="rfvPlanPeriodo" runat ="server" Text="*" ValidationGroup ="vgHistoricoPlan" ControlToValidate ="ddlPlanPeriodo" InitialValue ="0"></asp:RequiredFieldValidator>
		                    
	                    </td> 
	                    <td >
	                        <div ><asp:Literal ID="liPlanVersion" Text="Versión" runat="server" ></asp:Literal>&nbsp;</div>
		                    <div><asp:DropDownList ID="ddlPlanVersion" runat="server" CssClass="field_input"  Enabled="false" SkinID="AnchoLibre" Width="150px" ></asp:DropDownList></div>
		                         <asp:RequiredFieldValidator ID="rfvPlanVersion" runat ="server" Text="*" ValidationGroup ="vgHistoricoPlan" ControlToValidate ="ddlPlanVersion" InitialValue ="0"></asp:RequiredFieldValidator>
		                    
	                    </td>  
	                    <td align="right" valign="bottom"  >
	                        <asp:Button  ID ="btHistoricoPorPlan"  runat = "server" Text="Hist. Plan" OnClick ="btHistoricoPorPlan_Click" CausesValidation="true" ValidationGroup ="vgHistoricoPlan"  />
	                    </td>
	                </tr> 
	            </table>
	        </asp:Panel>
	    </td>

	    <td class="tdFilter" style=" padding-top:10px;padding-bottom:10px;" > 
	        <asp:Panel runat="server"  ID="pnlNroBapin"  BorderWidth="1" BackColor=" #e6f7ff" Width="225px"   >
	            <table width="100%"  cellpadding="0" cellspacing="0" border="0" style=" height:20px; padding:10px; "  >
	                <tr>
	                    <td class="tdFilter" align="center" ><div ><asp:Literal ID="liNroProyecto" Text="Código BAPIN" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNroProyecto" runat="server"  ControlToValidate="txtNroProyecto" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ErrorMessage="El NroProyecto no es valido"></asp:RegularExpressionValidator></div>
		                <div><asp:TextBox Type="text" min="1" ID="txtNroProyecto" runat="server" CssClass="field_input" 
                                Width="100px" ontextchanged="txtNroProyecto_TextChanged" AutoPostBack ="true"></asp:TextBox>
		                </div>
                		 </td>  
	                </tr> 
	            </table>
	        </asp:Panel>
        </td>
	    
	</tr>
	<tr>
        
	    <td id="busquedaLegend" class="legend" style ="color:#0099ff;font-weight:bold;height:30px;">
	        <div style=" cursor: pointer; width: 150px" ><asp:Label ID="lblBusquedaAvanzada" runat ="server" Text ="Búsqueda Avanzada"  ></asp:Label>&nbsp; <asp:Image ID ="imgCollapsiblePanel" runat="server"  src="../Images/CollapsiblePanelImg.gif" /></div>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeBusquedaAvanzada" runat="Server"
                TargetControlID="pnlBusquedaAvanzada"
                Collapsed="True"
                ExpandControlID="lblBusquedaAvanzada"
                CollapseControlID="lblBusquedaAvanzada"
                AutoCollapse="False"
                AutoExpand="False"
                ExpandDirection="Vertical" />
	    </td>
        <td id="infoBusquedaLegend" class="legend" style ="visibility:hidden; color:red;font-weight:bold;width:30px;">
            <div style=" cursor: none; width: 350px" ><asp:Label ID="infoBusquedaAvanzada" runat ="server" Text ="Hay filtros cargados de búsqueda avanzada"  ></asp:Label></div>
        </td>
	</tr>
	<tr>
	    
	    <td colspan="4">
	        <asp:Panel ID="pnlBusquedaAvanzada" runat = "server" >
                <table width="100%"  cellpadding="0" cellspacing="0" border="0">
                    <tr>
	                    <td class="tdFilter" >
	                        <asp:Panel runat="server" GroupingText="Fecha de Ingreso"  ID="PnlFechaIngreso" width="404px"  >
	                            <table width="100%"  cellpadding="0" cellspacing="0" border="0"  style="margin-left:60px" >
	                                <tr>
	                                <td>
                                        <uc:DateRangeInput runat="server" ID="rdFechaInicio" ValidationGroup="FilterProyecto"/>
                                        
	                           <%--          <div ><asp:Literal ID="liFechaInicioDesde" Text="Desde" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaInicioDesde" Width="80px"  /></div >      
		                            </td>
		                            </tr>
		                            <tr>
	                                <td  style=" padding-bottom:6px;">
	                                    <div ><asp:Literal ID="liFechaInicioHasta" Text="Hasta" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaInicioHasta"  Width="80px"/></div > --%>
		                            </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
		                
		                <td class="tdFilter" valign="top" rowspan="2" >
	                        <asp:Panel runat="server" GroupingText="Procesos"  ID="PnlProcesos" width="300px"     >
	                            <table  cellpadding="0" cellspacing="0" border="0" style="margin-left:33px" height="76px"  >
	                                <tr>
		                                <td  valign="top"  ><div ><asp:Literal ID="liTipoProyecto" Text="Tipo de Proyecto"  runat="server" ></asp:Literal>&nbsp;</div>
		                                    <asp:DropDownList ID="ddlTipoProyecto" AutoPostBack="true" runat="server" 
                                                OnSelectedIndexChanged="ddlTipoProyecto_IndexChanged"  ></asp:DropDownList>
		                                </td>
		                            </tr>
	                                <tr>
	                                    <td  valign="top" ><div ><asp:Literal ID="liProceso" Text="Proceso"  runat="server" ></asp:Literal>&nbsp;</div>
		                                <asp:DropDownList ID="ddlProceso" runat="server" Enabled ="false"  ></asp:DropDownList>
		                                </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
		               
    		            
		                <td rowspan="5" class="tdFilter" >
	                        <asp:Panel runat="server" GroupingText="Intervención DNIP"  ID="Panel4" width="240px"  >
	                            <table width="100%"  cellpadding="0" cellspacing="0" border="0"  >
	                                <tr>
	                                    <td class="tdFilter" >
	                                    <div><asp:Literal ID="liPriorización" Text="Priorización" runat="server" ></asp:Literal></div>
		                                <div><asp:DropDownList ID="ddlPriorizacion" runat="server" ></asp:DropDownList></div>
		                                </td>
		                            </tr>
		                            <%--<tr>
	                                    <td class="tdFilter" ><asp:Literal ID="liCalificacionDictamen" Text="Calific. Dictamen" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvCalifcDictamen" runat="server" ControlToValidate="ddlCalificDictamen"  ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
		                                <asp:DropDownList ID="ddlCalificDictamen" runat="server"   ></asp:DropDownList>
		                                </td>
		                            </tr> --%>
		                            <tr>
		                             <td class="tdFilter" style=" width:230px ; padding-top:5px;" >
                                       <div ><asp:Literal ID="liCalificacionDictamen" Text="Calific. Dictamen" runat="server" ></asp:Literal>&nbsp;</div>
                                        <div><asp:ListBox ID="lbxCalificacionDictamen" runat="server" CssClass="field_input" SelectionMode="Multiple" Rows="4"  Height="70px" Width="205px" ></asp:ListBox></div>
                                    </td>
                                    </tr>
		                            <tr>
	                                    <td class="tdFilter" style=" padding-top:10px;">
	                                    <div><asp:Literal ID="liAnio" Text="Año" runat="server" ></asp:Literal></div>
		                                <div><asp:DropDownList ID="ddlAnio" runat="server" ></asp:DropDownList></div>
		                                </td>
		                            </tr>
		                            <tr>
	                                    <td class="tdFilter" style=" padding-top:10px;">
	                                        <asp:CheckBox ID="chkRequiereDictamen" runat="server" CssClass="field_input" Text="Requiere Dictamen" ></asp:CheckBox>
		                                </td>
		                            </tr>
		                            <tr>
	                                    <td class="tdFilter" style=" padding-top:5px;"  >
	                                        <asp:CheckBox ID="chkRequiereArt15" runat="server" CssClass="field_input" Text="Requiere Art. 15" ></asp:CheckBox>
		                                </td>
		                            </tr>
		                            <tr>
	                                    <td class="tdFilter" style=" padding-top:5px;"  >
	                                        <asp:CheckBox ID="chkCalidadPendiente" runat="server" CssClass="field_input" Text="Calidad Pendiente" ></asp:CheckBox>
		                                </td>
		                            </tr>
		                            <tr>
	                                    <td class="tdFilter" style=" padding-top:10px;"><div><asp:Literal ID="liSectorialista" Text="Sectorialista" runat="server" ></asp:Literal></div>
		                                <div><asp:DropDownList ID="ddlSectorialista" runat="server" ></asp:DropDownList></div>
		                                </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
	            </tr>
	            <tr>
	                 <td class="tdFilter" height="40px" >
	                        <asp:Panel runat="server" GroupingText="Fecha Últ. Mod."  ID="PnlFechaUltMod" width="404px" >
	                            <table width="100%"  cellpadding="0" cellspacing="0" border="0" style="margin-left:60px" >
	                                <tr>
	                                <td>
                                        <uc:DateRangeInput runat="server" ID="rdFechaModificacion" ValidationGroup="FilterProyecto"/>
	                                <%--    <div ><asp:Literal ID="liFechaModificacionDesde" Text="Desde" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaModificacionDesde" Width="80px"  /></div >      
		                            </td>
		                            </tr>
		                            <tr>
	                                <td style=" padding-bottom:6px;">
	                                    <div ><asp:Literal ID="liFechaModificacionHasta" Text="Hasta" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaModificacionHasta" Width="80px" /></div > --%>
		                            </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
		         </tr>
	            <tr>
                    <td class="tdFilter" colspan="3">
                        <asp:Panel runat="server" GroupingText="Oficinas"  ID="PnlOficinas" width="715px"   >
                            <table width="100%"  cellpadding="0" cellspacing="0" border="0" >
                                <tr>
                                    <td colspan="2">
                                        <div><uc:TreeOficinas runat="server" ID="toOficinas" SelectOption="OnlySelectedDefined" ShowOption="All" OnValueChanged="toOficina_OnValueChanged" Autopostback="true"></uc:TreeOficinas></div>
	                                    <%-- <asp:RequiredFieldValidator ID="rfvOficina" runat="server" ControlToValidate="ddlOficina"  ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator>
	                                    <asp:DropDownList ID="ddlOficina" runat="server"  Width="180px"  SkinID="AnchoLibre"></asp:DropDownList> --%>
	                                    </td>
	                                </tr>
                                    <tr>
	                                    <td style="padding-top:8px" width="460px" >
                                            <asp:CheckBox ID="chkIncluirOficinasInteriores" runat="server" Text="Incluir Subitems"
                                                CssClass="field_input" ></asp:CheckBox>
                                        </td>
	                                
                                    <td class="tdFilter" Width="240px"  >
                                    <div><asp:Literal ID="liRol" Text="Rol" runat="server" ></asp:Literal></div>
                                    <div><asp:DropDownList ID="ddlRol" runat="server" SkinID="AnchoLibre" Width="200px"  ></asp:DropDownList></div>
	                                </td>
	                            </tr>
	                        </table>
	                    </asp:Panel>
	                </td>
	            </tr>
	            <tr>
                    <td class="tdFilter" colspan="3">
                        <asp:Panel runat="server" GroupingText="Finalidad - Función"  ID="Panel2" width="715px"  >
                            <table width="100%"  cellpadding="0" cellspacing="0" border="0" >
                                <tr>
                                   <td class="tdFilter" > <div><uc:TreeFinalidadFuncion runat="server" ID="toFinalidadFuncion" SelectOption="Any" ShowOption="All" ></uc:TreeFinalidadFuncion> </div>
	                                </td>
	                                <td class="tdFilter">
                                        <asp:CheckBox ID="chkIncluirFinalidadFuncion" runat="server" Text="Incluir Subitems"
                                            CssClass="field_input"></asp:CheckBox>
                                    </td>
	                            </tr>
	                        </table>
	                    </asp:Panel>
	                </td>
	            </tr>
	            <tr>
                    <td colspan="3" class="tdFilter" style="margin-top:0px" >
                        <asp:Panel runat="server" GroupingText="Descripción del Proyecto"  ID="PnlDescripcionProyecto" Width="715px"  >
                                <table width="100%"  cellpadding="0" cellspacing="0" border="0"  style="margin-bottom:0px"  >
                                    <tr>
                                        <td class="tdFilter"  >
                                        <div> 
                                              <asp:Literal ID="liProyectoDescripcion" Text="Descripción" runat="server" ></asp:Literal>
                                              <asp:TextBox ID="txtProyectoDescripcion" runat="server" Width="450px"  ></asp:TextBox>
                                              <asp:RegularExpressionValidator ID="revProyectoDescripcion" runat="server"  ControlToValidate="txtProyectoDescripcion" ValidationGroup="FilterProyecto" Text="*" Width="1px" Height="1px"></asp:RegularExpressionValidator></div>
                                        </td>
                                        <td>&nbsp;</td>
	                                    <td class="tdFilter" >
                                        <asp:Literal ID="liEstadoDeDesicion" Text="Estado de Decisión" runat="server" ></asp:Literal>
		                                <asp:DropDownList ID="ddlEstadoDeDesicion" runat="server"   ></asp:DropDownList>
		                                </td>
		                            </tr>
	                            </table>
	                     </asp:Panel>
	                </td>
	            </tr>
	        </table>
	        </asp:Panel>
        </td>
    </tr>
    <tr>
	    <td class="tdFilter" >
		</td>
		<td class="tdFilter" >
		</td>
		<td class="tdFilter" >
		</td>
		<td align="right" valign="bottom"style ="height:30px;" align="center"  >
		    <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		    &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterProyecto"/>
		</td>
	</tr>
</table>
