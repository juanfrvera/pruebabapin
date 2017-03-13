<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="CubosPrincipal.aspx.cs" Inherits="UI.Web.Cubos.CubosPrincipal" EnableEventValidation="false" %>

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
        <legend><asp:Literal ID="Literal2" Text="Acciones" runat="server" ></asp:Literal></legend>
        <table>
            <tr>
            <td><asp:Label runat="server" ID="lblCubosxTotal" Text="Cubos por Total (Duración Estimada de Proceso: 5 minutos)"/>
                <asp:Button  ID="cmdGenerarCuboxTotal" Text="Generar CuboxTotal" runat="server" OnClick="cmdGenerarCuboxTotal_Click" /></td>
           
            </tr>
            <tr>
            <td><asp:Label runat="server" ID="lblCubos" Text="Cubos por Objeto (Duración Estimada de Proceso: 10 minutos)"/>
                <asp:Button  ID="cmdGenerarCuboxObjeto" Text="Generar CuboxObjeto" runat="server" OnClick="cmdGenerarCuboxObjeto_Click" /></td>
           
            </tr>
              <tr>
            <td><asp:Label ID="lblStatusResultado" runat="server"></asp:Label></td>
           
            </tr>

        </table>    
        

    </fieldset>

</asp:Content>
