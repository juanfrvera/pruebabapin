<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_OficinaAutocomplete.ascx.cs" Inherits="UI.Web.WebControl_OficinaAutocomplete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>
<asp:Panel ID="pnControl" runat="server"  >
    <table width="100%">
        <tr valign="top" >
        <td width="<%= txtSelect.Width %>" >            
            <asp:TextBox ID="txtSelect" runat="server"  autocomplete="off" ValidationGroup="" ></asp:TextBox> 
            <div id="<%=ClientID%>AutoCompleteContainer"  class="yui-ac-content yui-skin-sam"  style="z-index:100;width:100%" ></div> 
        </td>
        <td width="5px" >
            <asp:RequiredFieldValidator id="required" runat="server" ControlToValidate="txtSelect"
             ErrorMessage="Campo Obligatorio" Text="*" Display="dynamic" Enabled="false" ValidationGroup=""/>
        </td>
        <td width="55px" >
            <img src="../App_Themes/Sky/Images/Icons/clearb.gif" style="cursor:hand"  onclick="<%=ClientID%>Clear()" />
       </td>
       </tr>
    </table>     
    <asp:HiddenField ID="hdSelect" OnValueChanged="OnValueChanged" runat="server" />
    <asp:HiddenField ID="hdFilter" runat="server" />            
    
   </asp:Panel>
<script type="text/javascript">
function <%=ClientID%>ChangeValue(){
    if(<%=Autopostback.ToString().ToLower()%>){
        __doPostBack('<%=hdSelect.ClientID%>','');
    }
}
function <%=ClientID%>Clear()
{
    try{
        $('<%=hdSelect.ClientID%>').value = "";
        $('<%=txtSelect.ClientID%>').value = "";
        <%=ClientID%>ChangeValue();
    }catch(e){alert(e.message);} 
} 
var <%=ClientID%>Autocomplete =null;
function <%=ClientID%>SetAutocomplete()
{
    <%=ClientID%>Autocomplete =new AutocompleteSimple('<%=AutocompleteHandler%>','<%=hdFilter.Value%>','<%=txtSelect.ClientID%>','<%=hdSelect.ClientID%>','<%=ClientID%>AutoCompleteContainer',<%=ClientID%>ChangeValue,<%=(int) this.SelectOption %>,<%=(int) this.ShowOption %>);  
}</script>