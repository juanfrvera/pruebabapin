<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="Matching_ProyectosBapinPlanSinSidif.aspx.cs" Inherits="UI.Web.Matching.Matching_ProyectosBapinPlanSinSidif" %>

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

      <!--Tabla de Resultados-->

    <fieldset>
     <legend><asp:Literal ID="Literal1" Text="Proyectos Bapin Marca Plan sin Sidif Asignado" runat="server" ></asp:Literal></legend>
        <table width="100%">
             
        <tr><td>Ultima actualización: <strong><em>
            <asp:Label ID="lblUltimaActualizacion" runat="server" ></asp:Label></em></strong></td></tr>
      <tr>
          <td><h2>Proyectos Bapin Marca Plan sin Sidif Asignado</h2></td></tr>
         
        <tr>
            <td>
                <!-- <asp:SqlDataSource ID="sqlProyectosAutomatch" runat="server"
                     ConnectionString="<%$ ConnectionStrings:Contract.Properties.Settings.BAPIN3ConnectionString %>"
                    SelectCommand="EXEC [sp_Matching_ProyectosVinculados] 2016,9, '576044007'" />
                -->
                <asp:GridView ID="grdProyectosBapinSinSidif"  
                      autogeneratecolumns="false"
                    emptydatatext="Sin datos disponibles!"
                    AllowPaging="true" PageSize="10" runat="server" AllowSorting="true" OnPageIndexChanging="grdProyectosBapinSinSidif_PageIndexChanging"  >
                    
               <Columns>
               
                   <asp:BoundField DataField="Bapin" HeaderText="Bapin" HeaderStyle-HorizontalAlign="Right"  ItemStyle-HorizontalAlign="Right"  />
                   <asp:BoundField DataField="AperProg" HeaderText="Aper.Prog." HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  />
                   <asp:BoundField DataField="Denominacion" HeaderText="Denominacion" HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  />
                   <asp:BoundField DataField="Jurisdiccion" HeaderText="Jurisdic." HeaderStyle-HorizontalAlign="Right" ItemStyle-HorizontalAlign="Right"  />
                   <asp:BoundField DataField="SAF" HeaderText="Saf" ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right"  />
                   <asp:BoundField DataField="Programa" HeaderText="Prog." ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                   <asp:BoundField DataField="Subprograma" HeaderText="SubProg." ItemStyle-HorizontalAlign="Right" HeaderStyle-HorizontalAlign="Right" />
                 
               
               </Columns>
                    
                 </asp:GridView>
                
            </td>
            
        </tr>

     </table>
         <asp:Button ID="cmdExportarExcel" Text="Exportar Excel" ToolTip="Se realiza la exportación de los resultados expuestos a Excel" runat="server" OnClick="cmdExportarExcel_Click" />
         <asp:Label ID="lblExportExcel" Font-Bold="true" Font-Size="Small" runat="server"></asp:Label> 
        </fieldset>

    <fieldset>
        <legend><asp:Literal ID="Literal2" Text="Acciones" runat="server" ></asp:Literal></legend>
        <table>
            <tr>

            <td><asp:Button  ID="cmdVolver" Text="Proyectos Vinculados" runat="server" OnClick="cmdVolver_Click" /></td>
            
            </tr>
        </table>    
        

    </fieldset>

</asp:Content>
