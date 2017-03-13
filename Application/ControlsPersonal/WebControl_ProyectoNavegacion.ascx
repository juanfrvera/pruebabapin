<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProyectoNavegacion.ascx.cs" Inherits="UI.Web.WebControl_ProyectoNavegacion" %>


<div style="margin: 0 auto;text-align:center">
  <ul class="TabbedPanelsTabGroup">
    <li id="ProyectoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoGenerales" TabIndex="1"
        CommandArgument="~/Pages/ProyectoPageEdit.aspx" 
        oncommand="lnk_Command" Text="Generales"></asp:LinkButton>    
    </li>
    <li id="ProyectoAlcanceGeograficoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoAlcanceGeografico" TabIndex="2"
        CommandArgument="~/Pages/ProyectoAlcanceGeograficoPageEdit.aspx" 
        oncommand="lnk_Command" Text="Alcance Geográfico"></asp:LinkButton>    
    </li>
    <li id="ProyectoObjetivosPageEdit" class="TabbedPanelsTab"  runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoObjetivos" TabIndex="3"
        CommandArgument="~/Pages/ProyectoObjetivosPageEdit.aspx" 
        oncommand="lnk_Command" Text="Objetivos"></asp:LinkButton>    
    </li>
    <li id="ProyectoProductoIntermedioPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoProductoIntermedio" TabIndex="4"
        CommandArgument="~/Pages/ProyectoProductoIntermedioPageEdit.aspx" 
        oncommand="lnk_Command" Text="Producto Intermedio"></asp:LinkButton>    
    </li>
    <li id="ProyectoCronogramaPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoCronograma" TabIndex="5"
        CommandArgument="~/Pages/ProyectoCronogramaPageEdit.aspx" 
        oncommand="lnk_Command" Text="Cronograma"></asp:LinkButton>    
    </li>
    <li id="ProyectoEvaluacionPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoEvaluacion" TabIndex="6"
        CommandArgument="~/Pages/ProyectoEvaluacionPageEdit.aspx" 
        oncommand="lnk_Command" Text="Evaluación"></asp:LinkButton>    
    </li>
    <li id="ProyectoDNIPPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoDNIP" TabIndex="7"
        CommandArgument="~/Pages/ProyectoDNIPPageEdit.aspx" 
        oncommand="lnk_Command" Text="Interv. DNIP"></asp:LinkButton>    
    </li>
    <li id="ProyectoAdjuntarPageList" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoAdjuntar" TabIndex="8"
        CommandArgument="~/Pages/ProyectoAdjuntarPageList.aspx" 
        oncommand="lnk_Command" Text="Adjuntar"></asp:LinkButton>    
    </li>
    <li id="ProyectoCalidadPageList" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoCalidad" TabIndex="9"
        CommandArgument="~/Pages/ProyectoCalidadPageList.aspx" 
        oncommand="lnk_Command" Text="Calidad"></asp:LinkButton> 
        <img src="../App_Themes/Sky/Images/Layout/con-contenido.png"/></li>
  </ul>
</div>
