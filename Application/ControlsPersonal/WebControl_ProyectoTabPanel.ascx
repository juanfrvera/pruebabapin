<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_ProyectoTabPanel.ascx.cs" Inherits="UI.Web.WebControl_ProyectoTabPanel" %>
<script src="../App_Scripts/TabPanelScript.js" type="text/javascript"></script>
<asp:UpdatePanel ID="upTabPanel" runat = "server" UpdateMode ="Conditional" >
  <ContentTemplate >
        <asp:Repeater ID="rpTab" runat="server"  OnItemCommand="rpTab_ItemCommand"  > 
        <HeaderTemplate>
            <div style="margin: 0 auto;text-align:center">
              <ul class="TabbedPanelsTabGroup" > 
        </HeaderTemplate> 
        <ItemTemplate>
                <li id="liTab" class='<%# GetTabClass(Eval("Url").ToString()) %>' runat="server" visible='<%# Eval("Visible") %>'  >
                    <asp:LinkButton runat="server" ID="lnkUrl"  
                     CommandArgument='<%# Eval("Url") %>'
                     CommandName="<%# Command.CONFIRM_CHANGE_PAGE %>" 
                     CausesValidation = "false" 
                     Text='<%# Eval("Text") %>'  ></asp:LinkButton>    
                </li> 
        </ItemTemplate> 
        <FooterTemplate> 
             </ul>
            </div>
        </FooterTemplate> 
        </asp:Repeater> 
  </ContentTemplate>
</asp:UpdatePanel>  
<%--
<div style="margin: 0 auto;text-align:center">
  <ul class="TabbedPanelsTabGroup">  
    <li id="ProyectoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoGenerales" TabIndex="1"
        CommandArgument="~/Proyecto/ProyectoPageEdit.aspx" 
         oncommand="lnk_Command" Text="Generales"></asp:LinkButton>    
    </li>
    <li id="ProyectoAlcanceGeograficoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoAlcanceGeografico" TabIndex="2"
        CommandArgument="~/Proyecto/ProyectoAlcanceGeograficoPageEdit.aspx" 
         OnCommand="lnk_Command" Text="Alcance Geográfico"></asp:LinkButton>    
    </li>
    <li id="ProyectoObjetivosPageEdit" class="TabbedPanelsTab"  runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoObjetivos" TabIndex="3"
        CommandArgument="~/Proyecto/ProyectoObjetivosPageEdit.aspx" 
        oncommand="lnk_Command" Text="Objetivos" ></asp:LinkButton>    
    </li>
    <li id="ProyectoProductoIntermedioPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoProductoIntermedio" TabIndex="4"
        CommandArgument="~/Proyecto/ProyectoProductoIntermedioPageEdit.aspx" 
        oncommand="lnk_Command" Text="Producto Intermedio"></asp:LinkButton>    
    </li>
    <li id="ProyectoCronogramaPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoCronograma" TabIndex="5"
        CommandArgument="~/Proyecto/ProyectoCronogramaPageEdit.aspx" 
        oncommand="lnk_Command" Text="Cronograma"></asp:LinkButton>    
    </li>
    <li id="ProyectoEvaluacionPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoEvaluacion" TabIndex="6"
        CommandArgument="~/Proyecto/ProyectoEvaluacionPageEdit.aspx" 
        oncommand="lnk_Command" Text="Evaluación"></asp:LinkButton>    
    </li>
    <li id="ProyectoDNIPPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoDNIP" TabIndex="7"
        CommandArgument="~/Proyecto/ProyectoDNIPPageEdit.aspx" 
        oncommand="lnk_Command" Text="Interv. DNIP"></asp:LinkButton>    
    </li>
    <li id="ProyectoAdjuntarPageList" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoAdjuntar" TabIndex="8"
        CommandArgument="~/Proyecto/ProyectoAdjuntarPageList.aspx" 
        oncommand="lnk_Command" Text="Adjuntar"></asp:LinkButton>    
    </li>
    <li id="ProyectoCalidadPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkProyectoCalidad" TabIndex="9"
        CommandArgument="~/Proyecto/ProyectoCalidadPageEdit.aspx" 
        oncommand="lnk_Command" Text="Calidad"></asp:LinkButton> 
        <img src="../App_Themes/Sky/Images/Layout/con-contenido.png"/></li>
  </ul>
</div>
--%>
