<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="Matching_InfoArmadoPlan.aspx.cs" Inherits="UI.Web.Matching.Matching_InfoArmadoPlan" %>

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
                <td>     <asp:Button ID="cmdArmPlanAgrup" Text="1.Archivo Info para Armado de Plan" runat="server" OnClick="cmdArmPlanAgrup_Click"/>

                </td>
                <td>     <asp:Button ID="cmdInfoSidifNoVinculado" Text="2.Archivo Info para Armado de Plan Sidif No Vinculado" runat="server" OnClick="cmdInfoSidifNoVinculado_Click"/>
                    
                </td>
              </tr><tr>
              <td>     <asp:Button ID="cmdInfoSidifVinculados" Text="3. Archivo Info para Armado de Plan Sidif Vinculados" runat="server" OnClick="cmdInfoSidifVinculados_Click"/>
                                      
                </td>
                
                <td>     <asp:Button ID="cmdInfoSidifVinculadosND" Text="4. Archivo Info para Armado de Plan Sidif Vinculados ND" runat="server" OnClick="cmdInfoSidifVinculadosND_Click"/>
                                      
                </td>
            </tr><tr>
                <td>     <asp:Button ID="cmdVolver" Text="Volver Matching Principal" runat="server" OnClick="cmdVolver_Click"/>
                                      
                </td>

                </tr>
            </table>

    
         
    
         </div>
        </fieldset> 

   
</asp:Content>
