<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Test_Accordion.aspx.cs" Inherits="Application.Test.Test_Accordion" MasterPageFile="~/App_Shared/General.Master"  %>

<%@ Register Tagprefix="uc" TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx"   %>
<%@ Register Tagprefix="uc" TagName="Autocomplete" Src="~/Controls/WebControl_Autocomplete.ascx"   %>
<%@ Register Tagprefix="uc" TagName="ThreeState" Src="~/Controls/WebControl_ThreeStatesCheckbox.ascx"   %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <ajaxToolkit:Accordion ID="Accordion1" runat="server" 
    FadeTransitions="True" 
    FramesPerSecond="50" 
    Width="100%" 
    SelectedIndex="1"
    TransitionDuration="200"> 
    <Panes> 
        <ajaxToolkit:AccordionPane ID="AccordionPane1" runat="server" > 
        <Header>
            Header 1    
        </Header> 
            <Content>
                <asp:Label id="Label1" runat ="server" Text = "1"></asp:Label>
            </Content> 
        </ajaxToolkit:AccordionPane> 
        <ajaxToolkit:AccordionPane ID="AccordionPane2" runat="server" > 
        <Header>
            Header 2    
        </Header> 
            <Content>
                <asp:Label id="Label2" runat ="server" Text = "2"></asp:Label>
            </Content>
        </ajaxToolkit:AccordionPane>             
    </Panes> 
    </ajaxToolkit:Accordion> 

</asp:Content>