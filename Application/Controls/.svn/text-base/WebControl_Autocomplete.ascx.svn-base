<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_Autocomplete.ascx.cs" Inherits="UI.Web.WebControl_Autocomplete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>

<style type="text/css">
.imgButton
{
    width:23px;
    height:23px;
    vertical-align:bottom;
    padding:0px 0px 0px 0px;
}
</style>

<asp:Panel ID="pnControl" runat="server" >
    <%=this.Tag %>
    <asp:TextBox runat="server" ID="acTextBox" autocomplete="off" ValidationGroup="" />
    <asp:ImageButton  ID="btnClear" runat="server" Visible="false" OnClick="OnClearControl" src="/App_Themes/Sky/Images/Icons/clear.gif" CssClass="imgButton" ToolTip="Deseleccionar" TabIndex="-1" />
    <asp:HiddenField runat="server" id="acHidden" Value="0"></asp:HiddenField>
    <asp:HiddenField runat="server" id="acHiddenIsPosback" Value="0" OnValueChanged="OnValueChanged"></asp:HiddenField>
    <atk:AutoCompleteExtender ID="wcAutoComplete"
                              runat="server"  
                              OnClientPopulated="onGetList" 
                              OnClientItemSelected="onSelectItem"
                              OnClientPopulating="onPopulating"
                              BehaviorID="AutoCompleteEx"
                              TargetControlID="acTextBox"
                              ServicePath="~/Services/WebService.asmx"
                              ServiceMethod="GetListMetod"
                              MinimumPrefixLength="3"
                              CompletionInterval="1000"
                              EnableCaching="true"
                              CompletionSetCount="10"
                              DelimiterCharacters=";,:">
    </atk:AutoCompleteExtender>
    <asp:RequiredFieldValidator id="required" 
                                runat="server" 
                                ControlToValidate="acTextBox"
                                ErrorMessage="Campo Obligatorio" 
                                Display="dynamic" 
                                Text="*"
                                Enabled="false" 
                                ValidationGroup=""/>
<script type="text/javascript">
<!-- 
    function <%=wcAutoComplete.BehaviorID%>onPopulating()
    {   
        autocompleteOnPopulating("<%=acHidden.ClientID%>","<%=acTextBox.ClientID%>","<%=acHiddenIsPosback.ClientID%>");
    }
    function <%=wcAutoComplete.BehaviorID%>onSelectItem(ev)
    {
        autocompleteOnSelectItem(ev,"<%=acHidden.ClientID%>","<%=acTextBox.ClientID%>","<%=wcAutoComplete.BehaviorID%>","<%=acHiddenIsPosback.ClientID%>","<%=this.AutoPostback%>");
    }
    function <%=wcAutoComplete.BehaviorID%>onGetList()
    {        
        autocompleteOnGetList("<%=acHidden.ClientID%>", "<%=wcAutoComplete.BehaviorID%>","<%=acHiddenIsPosback.ClientID%>");
    }
    function <%=wcAutoComplete.BehaviorID%>LostFocus()
    {
        autocompleteOnLostFocus("<%=acHidden.ClientID%>","<%=acTextBox.ClientID%>","<%=acHiddenIsPosback.ClientID%>");
    }
    <%=dofocus%>    
//-->
</script>                                              
</asp:Panel>