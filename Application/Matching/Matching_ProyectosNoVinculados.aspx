 <%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="Matching_ProyectosNoVinculados.aspx.cs" Inherits="UI.Web.Matching.Matching_ProyectosNoVinculados" EnableEventValidation="false" %>


<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register TagPrefix="uc" TagName="FilterProyecto" Src="~/Proyecto/ProyectoFilter.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListProyecto" Src="~/Proyecto/ProyectoList.ascx" %>
<%@ Register TagPrefix="uc" TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register TagPrefix="uc" TagName="Confirm" Src="~/Controls/WebControl_Confirm.ascx" %>
<%@ Register TagPrefix="uc" TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register TagPrefix="uc" TagName="Copy" Src="~/ControlsPersonal/WebControl_CopyProject.ascx" %>
<%@ Register TagPrefix="uc" TagName="VerReporte" Src="~/ControlsPersonal/WebControl_ProyectoVerReporte.ascx" %>
<%@ Register TagPrefix="uc" TagName="ImprimirProyecto" Src="~/ControlsPersonal/WebControl_PrintProyecto.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProjectHistoricoReporte" Src="~/ControlsPersonal/WebControl_ProjectHistoricoReporte.ascx" %>
<%@ Register TagPrefix="uc" TagName="ProjectEstadoDesicionHistorico" Src="~/ControlsPersonal/WebControl_ProjectEstadoDesicionHistorico.ascx" %>





<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

       <fieldset>
     <legend><asp:Literal ID="litFiltros" Text="Filtros" runat="server" ></asp:Literal></legend>
     <div id="filtro">

       
      <table width="100%"  cellpadding="0" cellspacing="10" border="0">
          
          <tr>

	            <td class="tdFilter" style=" width:230px" >
	                <div ><asp:Literal ID="Literal3" Text="Año Ejercicio:" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlEjercicio" runat="server" CssClass="field_input"  
		                    AutoPostBack ="true" SkinID="AnchoLibre" Width="230px" OnSelectedIndexChanged="ddlEjercicio_SelectedIndexChanged" ></asp:DropDownList></div>
	            </td>
            <td class="tdFilter" style=" width:230px" >
	                <div ><asp:Literal ID="Literal4" Text="Mes:" runat="server" ></asp:Literal>&nbsp;</div>
		            <div><asp:DropDownList ID="ddlMes" runat="server" CssClass="field_input"  
		                    AutoPostBack ="true" SkinID="AnchoLibre" Width="230px" ></asp:DropDownList></div>
	            </td>


	      </tr>
          
            
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
                </tr><tr> 
                <td>     <asp:Button ID="cmdBuscar" Text="Buscar" runat="server" OnClick="cmdBuscar_Click" />
                </td>
                </tr>
            </table>

    
         
    
         </div>
        </fieldset> 
    <!--Tabla de Resultados-->

     <fieldset>
     <legend><asp:Literal ID="Literal1" Text="Proyectos No Vinculados" runat="server" ></asp:Literal></legend>
        <table width="100%">
             
        <tr><td>Ultima actualización: <strong><em>
            <asp:Label ID="lblUltimaActualizacion" runat="server" ></asp:Label></em></strong></td></tr>
      <tr>
          <td><h2>Proyectos Matching Proyectos No Vinculados</h2></td></tr>
         
        <tr>
            <td>
          
                <asp:GridView ID="grdProyectosAutomatch"  
                      autogeneratecolumns="false"
                    emptydatatext="Sin datos disponibles!"
                    AllowPaging="true" PageSize="10" runat="server" OnSelectedIndexChanged="grdProyectosAutomatch_SelectedIndexChanged"  OnRowDataBound="grdProyectosAutomatch_RowDataBound" DataKeyNames="IdentificadorProyectoSidif" AllowSorting="true"  OnPageIndexChanging="grdProyectosAutomatch_PageIndexChanging" >
                    
               <Columns>
                  
                   <asp:BoundField DataField="Jurisdiccion" HeaderText="Jurisdicción" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="SAF" HeaderText="SAF" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Programa" HeaderText="Programa" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Subprograma" HeaderText="Subprograma"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Proyecto" HeaderText="Proyecto" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Actividad" HeaderText="Actividad" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Obra" HeaderText="Obra" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="AperturaProgramaticaSeparada" HeaderText="Aper. Prog." ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="AperturaPresupuestariaSeparada" HeaderText="Aper. Presup." ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="CreditoInicial" DataFormatString="{0:N0}" HeaderText="Inicial"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="CreditoVigente" DataFormatString="{0:N0}" HeaderText="Vigente"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Devengado" HeaderText="Devengado" DataFormatString="{0:N0}"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Pagado" HeaderText="Pagado" DataFormatString="{0:N0}"  ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:ButtonField Text="Vincular" CommandName="Select" ItemStyle-Width="30" HeaderText="Acciones" />
           
               
               </Columns>
                    
                 </asp:GridView>
           </td>
        </tr>
     </table>
        <asp:Button ID="cmdExportarExcel" Text="Exportar Excel" ToolTip="Se realiza la exportación de los resultados expuestos a Excel" runat="server" OnClick="cmdExportarExcel_Click" />
         <asp:Label ID="lblExportExcel" Font-Size="10px" Font-Names="Verdana" runat="server"></asp:Label>
    <!--    <asp:Label ID="lblID" BackColor="Blue" ForeColor="White" Font-Bold="true" Font-Size="Large" runat="server"></asp:Label>-->
          </fieldset>

    <!--Acciones-->
       <fieldset>
        <legend><asp:Literal ID="Literal2" Text="Acciones" runat="server" ></asp:Literal></legend>
        <table>
            <tr>
               <td><asp:Button ID="cmdMatchingVinculados" Text="Ver Proyectos Vinculados" OnClick="cmdMatchingVinculados_Click" runat="server" /></td>
              
            </tr>
        </table>    
        

    </fieldset>


</asp:Content>
