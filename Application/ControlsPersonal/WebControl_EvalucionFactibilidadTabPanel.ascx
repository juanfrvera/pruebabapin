<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_EvalucionFactibilidadTabPanel.ascx.cs" Inherits="UI.Web.WebControl_EvaluacionFactibilidadTabPanel" %>
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
             Text='<%# Eval("Text") %>' ></asp:LinkButton>    
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
    <li id="EvaluacionFactibilidadPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkEvaluacionFactibilidadGenerales" TabIndex="3"
        CommandArgument="~/Pages/EvaluacionFactibilidadPageEdit.aspx" 
        oncommand="lnk_Command" Text="Datos Generales"></asp:LinkButton>    
    </li>
    <li id="EvaluacionFactibilidadSeguimientoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkEvaluacionFactibilidadSeguimiento" TabIndex="2"
        CommandArgument="~/Pages/EvaluacionFactibilidadSeguimientoPageEdit.aspx" 
        oncommand="lnk_Command" Text="Seguimiento de Estados"></asp:LinkButton>    
    </li>
    <li id="EvaluacionFactibilidadAdjuntarPageList" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkEvaluacionFactibilidadAdjuntar" TabIndex="1"
        CommandArgument="~/Pages/EvaluacionFactibilidadAdjuntarPageList.aspx" 
        oncommand="lnk_Command" Text="Adjuntar"></asp:LinkButton>    
    </li>
  </ul>
</div>
--%>