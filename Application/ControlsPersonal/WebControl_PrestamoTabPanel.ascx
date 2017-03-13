<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_PrestamoTabPanel.ascx.cs" Inherits="UI.Web.WebControl_PrestamoTabPanel" %>
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
