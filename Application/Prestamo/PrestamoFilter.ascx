<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoFilter.ascx.cs" Inherits="UI.Web.PrestamoFilter" %>
<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="DateRangeInput" Src="~/Controls/WebControl_DateRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="NumberRangeInput" Src="~/Controls/WebControl_NumericRangeInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>
<%@ Register TagPrefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx" %>
<%@ Register Tagprefix="uc" TagName="TreeOficinas" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"   %>



<table width="100%"  cellpadding="0" cellspacing="0" border="0">
<tr>
	    <td class="tdFilter" style=" width:305px" >
	        <div ><asp:Literal ID="liJurisdiccion" Text="Jurisdicción" runat="server" ></asp:Literal>&nbsp;<asp:RequiredFieldValidator ID="rfvJurisdiccion" runat="server" ControlToValidate="ddlJurisdiccion"  ValidationGroup="FilterPrestamo" Text="*" Width="1px" Height="1px"  ></asp:RequiredFieldValidator></div>
		    <asp:DropDownList ID="ddlJurisdiccion" runat="server" CssClass="field_input" 
		        onselectedindexchanged="ddlJurisdiccion_SelectedIndexChanged" AutoPostBack ="true" SkinID="AnchoLibre" Width="290px"  ></asp:DropDownList>
	    </td>
	    <td class="tdFilter" style=" width:305px" >
	        <div ><asp:Literal ID="liSAF" Text="SAF" runat="server" ></asp:Literal>&nbsp;</div>
		    <div><asp:DropDownList ID="ddlSAF" runat="server" CssClass="field_input"  onselectedindexchanged="ddlSAF_SelectedIndexChanged" AutoPostBack ="true" Enabled="false" SkinID="AnchoLibre" Width="290px"  ></asp:DropDownList></div>
	    </td>
	    <td class="tdFilter" style=" width:305px" ><div ><asp:Literal ID="liPrograma" Text="Programa" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlPrograma" runat="server" CssClass="field_input" Enabled="false" SkinID="AnchoLibre" Width="290px"  ></asp:DropDownList></div>
		</td>
		
		
</tr> 	  
<tr>
        
	    <td class="tdFilter" ><div ><asp:Literal ID="liDenominacion" Text="Denominación" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revDenominacion" runat="server"  ControlToValidate="txtDenominacion" ValidationGroup="FilterPrestamo" Text="*" Width="1px" Height="1px"  ErrorMessage="La Denominación no es válida"></asp:RegularExpressionValidator></div>
		<div><asp:TextBox ID="txtDenominacion" runat="server" CssClass="field_input" Width="285px" ></asp:TextBox></div>
        </td>
	    <td class="tdFilter" ><div ><asp:Literal ID="liOrganismoFinanciero" Text="Organismo Financiero" runat="server" ></asp:Literal>&nbsp;</div>
		<div><asp:DropDownList ID="ddlOrganismoFinanciero" runat="server" CssClass="field_input" SkinID="AnchoLibre" Width="290px"  ></asp:DropDownList></div>
		</td>
		<td>
              <div><asp:Literal ID="liActivo" Text="Activo" runat="server" ></asp:Literal>
            </div>  
            <div>
                <uc:ThreeState ID="chkActivo" runat="server" CssClass="field_input" ></uc:ThreeState>
            </div>
	    </td>
</tr>
<tr>
<td colspan = "2">
                <asp:Panel runat="server" GroupingText="Finalidad Función"  ID="PnlFinalidadFuncion"  Width="620px"   >
                    <table  cellpadding="0" cellspacing="0" border="0" >
                        <tr>
                            <td>
                                <uc:TreeFinalidadFuncion  SelectOption="Any" ShowOption="All" runat="server" ID="toFinalidadFuncion" Handler="../Handlers/FinalidadFuncionHandler.ashx"></uc:TreeFinalidadFuncion>
                            </td>
                            <td class="tdFilter">
                                    <asp:CheckBox ID="chkIncluirFinalidadFuncionInteriores" runat="server" Text="Incluir Subitems"
                                        CssClass="field_input"></asp:CheckBox>
                            </td>
                        </tr>
                    </table>
                </asp:Panel>
		</td>
		<td class="tdFilter" style=" padding-top:13px;" > 
	        <asp:Panel runat="server"  ID="pnlNroPrestamo"  BorderWidth="1" BackColor=" #e6f7ff" width=290px   >
	            <table   cellpadding="0" cellspacing="0" border="0" style=" height:20px; padding:10px; " width=100px  >
	                <tr>
	                    <td class="tdFilter" ><div ><asp:Literal ID="liNumero" Text="Nro. Préstamo" runat="server" ></asp:Literal>&nbsp;<asp:RegularExpressionValidator ID="revNumero" runat="server"  ControlToValidate="txtNumero" ValidationGroup="FilterPrestamo" Text="*" Width="1px" Height="1px"  ErrorMessage="El Número no es válido"></asp:RegularExpressionValidator></div>
		                    <div><asp:TextBox ID="txtNumero" 
                                 runat="server" CssClass="field_input" ontextchanged="txtNroPrestamo_TextChanged" AutoPostBack ="true"  ></asp:TextBox></div>
                		 </td>  
	                </tr> 
	            </table>
	        </asp:Panel>
        </td>
</tr> 
<tr>
	    <td class="legend" style ="color:#0099ff;font-weight:bold;height:30px;">
	        <div style=" cursor: hand; width: 150px" ><asp:Label ID="lblBusquedaAvanzada" runat ="server" Text ="Búsqueda Avanzada" ></asp:Label> &nbsp; <asp:Image ID ="imgCollapsiblePanel" runat="server"  src="../Images/CollapsiblePanelImg.gif" /></div>
            <ajaxToolkit:CollapsiblePanelExtender ID="cpeBusquedaAvanzada" runat="Server"
                TargetControlID="pnlBusquedaAvanzada"
                Collapsed="True"
                ExpandControlID="lblBusquedaAvanzada"
                CollapseControlID="lblBusquedaAvanzada"
                AutoCollapse="False"
                AutoExpand="False"
                ExpandDirection="Vertical"
                />
	    </td>
</tr>
</table>
<table width="100%"  cellpadding="0" cellspacing="0" border="0">
<tr>
	    
	    <td colspan="4">
	        <asp:Panel ID="pnlBusquedaAvanzada" runat = "server" >
              <table width="100%"  cellpadding="0" cellspacing="0" border="0">
                    <tr>
	                    <td class="tdFilter" >
	                        <asp:Panel runat="server" GroupingText="Fecha de Ingreso"  ID="PnlFechaIngreso" width="280px"   >
	                            <table width="100%"  cellpadding="0" cellspacing="0" border="0" align="center" style="margin-left:10px">
	                                <tr>
	                                <td >
	                                    <uc:DateRangeInput runat="server" ID="rdFechaAlta" ValidationGroup="FilterPrestamo"/>
	                      <%--             <div ><asp:Literal ID="liFechaAltaDesde" Text="Desde" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaAltaDesde" Width="75px"  /></div >      
		                            </td>
		                            </tr>
		                            <tr>
	                                <td>
	                                    <div ><asp:Literal ID="liFechaAltaHasta" Text="Hasta" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaAltaHasta"  Width="75px"/></div >  --%> 
		                            </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
		                
		                <td class="tdFilter" rowspan="2">
                            <asp:Panel runat="server" GroupingText="Oficinas"  ID="PnlOficinas"  Width="505px"   >
                                <table  cellpadding="0" cellspacing="0" border="0" style="height:76px;" width="100%">
                                    <tr>
                                        <td>
                                            <uc:TreeOficinas runat="server" ID="toOficina" SelectOption="OnlySelectedDefined"  ShowOption="All" Handler="../Handlers/OficinaHandler.ashx" >
                                            </uc:TreeOficinas>
                        
                                        </td>
                                    </tr>
                                    <tr>
                                        <td class="tdFilter">
                                                <asp:CheckBox ID="chkIncluirOficinasInteriores" runat="server" Text="Incluir Oficinas Interiores"
                                                    CssClass="field_input"></asp:CheckBox>
                                        </td>
                                    </tr>
                                </table>
		                    </asp:Panel>
                         </td>
		                <td class="tdFilter" rowspan="2">
	                        <asp:Panel runat="server" GroupingText="Proyecto Asociado"  HorizontalAlign="Center" ID="PnlProyectoAsociado" width="150px"   >
	                            <table  cellpadding="0" cellspacing="0" border="0" style="height:76px; margin-left:0px;">
	                                <tr>
	                                    <td class="tdFilter" align ="center"  >
	                                        <div  align ="center" >
	                                            <asp:Literal ID="liCodigoVinculado" Text="Proyecto de Inversión Asociado" runat="server" ></asp:Literal>
	                                            &nbsp;
	                                            <asp:RegularExpressionValidator ID="revCodigoVinculado" runat="server"  ControlToValidate="txtCodigoVinculado" ValidationGroup="FilterPrestamo" Text="*" Width="1px" Height="1px" ></asp:RegularExpressionValidator>
	                                        </div>
		                                    <div align ="center" >
		                                        <asp:TextBox ID="txtCodigoVinculado" runat="server" Type="text" min="1" CssClass="field_input" Width="100px"  ></asp:TextBox>
		                                    </div>
                                        </td>
		                            </tr>
		                        </table>
		                    </asp:Panel>
		                </td>
		            </tr>
		            <tr>
		            <td class="tdFilter" align="center" >
	                        <asp:Panel runat="server" GroupingText="Fecha Últ. Mod."  ID="PnlFechaUltMod" width="280px"  >
	                            <table width="100%"  cellpadding="0" cellspacing="0" border="0" style="margin-left:10px">
	                                <tr>
	                                <td>
	                                     <uc:DateRangeInput runat="server" ID="rdFechaModificacion" ValidationGroup="FilterPrestamo"/>
	                     <%--               <div ><asp:Literal ID="liFechaModificacionDesde" Text="Desde" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaModificacionDesde" Width="80px"  /></div >      
		                            </td>
		                            </tr>
		                            <tr>
	                                <td>
	                                    <div ><asp:Literal ID="liFechaModificacionHasta" Text="Hasta" runat="server" ></asp:Literal></div>
	                                    <div ><uc:DateInput runat="server" ID="diFechaModificacionHasta" Width="80px" /></div > --%>
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
		<td align="right" valign="bottom" colspan="4" style ="height:30px;" align="center" >
	           <asp:Button  ID ="btClear"  runat = "server" Text="Limpiar" OnClick ="btClear_Click"  Visible="true" />
		  &nbsp;<asp:Button  ID ="btSearch"  runat = "server" Text="Buscar" OnClick ="btSearch_Click"  Visible="true" ValidationGroup="FilterPrestamo" />
	 </td>
</tr>
</table>
