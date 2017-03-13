<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_IndicadorClaseAutocomplete.ascx.cs" Inherits="UI.Web.WebControl_IndicadorClaseAutocomplete" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>
<%@ Register Assembly="Application" Namespace="UI.Web" TagPrefix="cc" %>

<asp:Panel ID="pnControl" runat="server"  >
    <table width="100%">
        <tr valign="top" >
        <td width="140px" >            

            <asp:DropDownList ID="ddlSectorInd"  SkinID="AnchoLibre" runat="server" Width="140px"></asp:DropDownList>
        </td>        
        <td width="550px" >            
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
    //debugger;
        $('<%=hdSelect.ClientID%>').value = "";
        $('<%=txtSelect.ClientID%>').value = "";
        <%=ClientID%>ChangeValue();        
    }catch(e){alert(e.message);} 
} 


var <%=ClientID%>Autocomplete =null;
function <%=ClientID%>SetAutocomplete()
{
    //debugger;
    <%=ClientID%>Autocomplete =new AutocompleteSimple('<%=AutocompleteHandler%>','<%=hdFilter.Value%>','<%=txtSelect.ClientID%>','<%=hdSelect.ClientID%>','<%=ClientID%>AutoCompleteContainer',<%=ClientID%>ChangeValue,<%=(int) this.SelectOption %>,<%=(int) this.ShowOption %>);  
    <%=ClientID%>Autocomplete.oAC.minQueryLength = 1;
   
    
}

function SelectSector()
{
    debugger ;
    var hdFilter = '<%=hdFilter.ClientID%>';
    var strJson = $(hdFilter).value;
     if(strJson!="")    
    {
        var filter = YAHOO.lang.JSON.parse(strJson); 
        filter.IdIndicadorRubro = $("<%=ddlSectorInd.ClientID%>").value;
        $(hdFilter).value =YAHOO.lang.JSON.stringify(filter);        
        <%=ClientID%>Autocomplete.oDS.scriptQueryAppend = 'filter='+$(hdFilter).value+'&SelectOption='+<%=(int) this.SelectOption %>+'&ShowOption='+<%=(int) this.ShowOption %>+'&t'+(new Date().getTime());
    }
    
}



</script>