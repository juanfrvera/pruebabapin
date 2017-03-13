<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_PrestamoDictamenTabPanel.ascx.cs" Inherits="UI.Web.WebControl_PrestamoDictamenTabPanel" %>
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
             CausesValidation ="false" 
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
    <li id="PrestamoDictamenPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkPrestamoDictamenGenerales" TabIndex="1"
        CommandArgument="~/Prestamo/PrestamoDictamenPageEdit.aspx" 
        oncommand="lnk_Command" Text="Datos Generales"></asp:LinkButton>    
    </li>
    <li id="PrestamoDictamenSeguimientoPageEdit" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkPrestamoDictamenSeguimiento" TabIndex="2"
        CommandArgument="~/Prestamo/PrestamoDictamenSeguimientoPageEdit.aspx" 
        oncommand="lnk_Command" Text="Seguimiento de Estados"></asp:LinkButton>    
    </li>
    <li id="PrestamoDictamenAdjuntarPageList" class="TabbedPanelsTab" runat="server">
        <asp:LinkButton runat="server" ID="lnkPrestamoDictamenAdjuntar" TabIndex="3"
        CommandArgument="~/Prestamo/PrestamoDictamenAdjuntarPageList.aspx" 
        oncommand="lnk_Command" Text="Adjuntar"></asp:LinkButton>    
    </li>
  </ul>
</div>
--%>