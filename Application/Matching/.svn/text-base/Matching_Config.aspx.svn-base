<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="Matching_Config.aspx.cs" Inherits="UI.Web.Matching.Matching_Config" %>

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
    
      <h1>Configuración Módulo Matching</h1><br /><br />

     <fieldset>
     <legend><asp:Literal ID="litFiltros" Text="Periodos Elegibles" runat="server" ></asp:Literal></legend>
          <h4>Por favor seleccione los períodos que desea incorporar al procesamiento de datos de Matching.</h4> <br />
          <table width="100%">
             
       
        <tr>
            <td>
<!--
          <asp:SqlDataSource ID="sqlProyectosAutomatch" runat="server"
                     ConnectionString="<%$ ConnectionStrings:Contract.Properties.Settings.BAPIN3ConnectionString %>"
                    SelectCommand="select pp.Activo,pp.IdPlanPeriodo,pp.Sigla,pp.AnioInicial,pp.AnioFinal,pt.Nombre from PlanPeriodo pp inner join PlanTipo pt on pp.IdPlanTipo=pt.IdPlanTipo where pp.IdPlanPeriodo not in (select IdPlanPeriodo from Matching_Config)" 
              />-->
               
                <asp:GridView ID="grdPlanPeriodoDisponibles"  
                      autogeneratecolumns="false"
                    emptydatatext="Sin datos disponibles!"
                    AllowPaging="true" PageSize="10" runat="server" DataKeyNames="IdPlanPeriodo" AllowSorting="true"  OnPageIndexChanging="grdPlanPeriodoDisponibles_PageIndexChanging" OnRowCreated="grdPlanPeriodoDisponibles_RowCreated" OnSelectedIndexChanged="grdPlanPeriodoDisponibles_SelectedIndexChanged" >
                   
                     <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"   />
           
                    
               <Columns>

                   <asp:BoundField DataField="IdPlanPeriodo" HeaderText="Id Plan Periodo" Visible="false" />
                   <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
                   <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                   <asp:BoundField DataField="Activo" HeaderText="Activo"  />
                   <asp:BoundField DataField="AnioInicial" HeaderText="Año Inicial" />
                   <asp:BoundField DataField="AnioFinal" HeaderText="Año Final" />
                   <asp:ButtonField Text="Incorporar al proceso" CommandName="Select" ItemStyle-Width="30" HeaderText="Acciones"  ItemStyle-HorizontalAlign="Center"  />
               
               </Columns>
                    
                 </asp:GridView>

                </td>
            <td valign="top"}>
                <!--Grilla de períodos elegidos-->
                
                     <asp:GridView ID="grdPlanPeriodosElegidos"  
                      autogeneratecolumns="false"
                    emptydatatext="Sin datos disponibles!"
                    AllowPaging="true" PageSize="10" runat="server" DataKeyNames="IdPlanPeriodo" AllowSorting="true"  OnRowCreated="grdPlanPeriodosElegidos_RowCreated"  OnSelectedIndexChanged="grdPlanPeriodosElegidos_SelectedIndexChanged" OnPageIndexChanging="grdPlanPeriodosElegidos_PageIndexChanging" >
                   
                     <HeaderStyle   Font-Bold="True" HorizontalAlign="Center"   />
           
                    
               <Columns>

                   <asp:BoundField DataField="IdPlanPeriodo" HeaderText="Id Plan Periodo" Visible="false" />
                   <asp:BoundField DataField="Sigla" HeaderText="Sigla" />
                   <asp:BoundField DataField="Nombre" HeaderText="Nombre" />
                   <asp:BoundField DataField="AnioInicial" HeaderText="Año Inicial" />
                   <asp:BoundField DataField="AnioFinal" HeaderText="Año Final" />  
                   <asp:BoundField DataField="Activo" HeaderText="Activo"  />
                   <asp:ButtonField Text="Quitar del proceso" CommandName="Select" ItemStyle-Width="30" HeaderText="Acciones"  ItemStyle-HorizontalAlign="Center" />
               
               </Columns>
                    
                 </asp:GridView>


              
            </td>

        </tr>
              </table>

         </fieldset>


</asp:Content>
