<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_IndicadorClaseTree.ascx.cs" Inherits="UI.Web.ControlsPersonal.WebControl_IndicadorClaseTree" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>

<style type="text/css">
#<%=ClientID%>_tree .ygtvdepth0 {
    display:none;
}
.treeNodeIconHide{
    display:none;
}
</style>

<%--Matias 20140523 - Tarea 110 - Nuevo Control--%>
<asp:Panel ID="pnControl" runat="server"  >
    <table width="100%">
        <tr valign="top" >
         <td width="140px" >            
            <asp:DropDownList ID="ddlSectorInd"  SkinID="AnchoLibre" runat="server" Width="140px"></asp:DropDownList>
        </td>    
        <td width="<%= txtSelect.Width %>" >
            <asp:TextBox ID="txtSelect" runat="server"  autocomplete="off" 
                ValidationGroup="" Width="417px" Enabled= "true" ></asp:TextBox>
            <div id="<%=ClientID%>AutoCompleteContainer" class="yui-ac-content yui-skin-sam"  style="z-index:100;width:100%" ></div> 
        </td>
        <td width="5px" >
            <asp:RequiredFieldValidator id="required" runat="server" ControlToValidate="txtSelect"
             ErrorMessage="Campo Obligatorio" Text="*" Display="dynamic" Enabled="false" ValidationGroup=""/>
        </td>
        <td width="100px" >
            <img src="../Images/OrganizationalUnit.png" style="cursor:hand<%= Enabled==true?"":";visibility:hidden" %>"    onclick="<%=ClientID%>Open()" /> 
            <img src="../App_Themes/Sky/Images/Icons/clearb.gif" style="cursor:hand<%= Enabled==true?"":";visibility:hidden" %>"   onclick="<%=ClientID%>Clear()" />
       </td>
       </tr>
    </table>     
    <asp:HiddenField ID="hdSelect" OnValueChanged="OnValueChanged" runat="server" />
    <asp:HiddenField ID="hdFilter" runat="server" />    
    <div id="<%=ClientID%>_panel"  style="visibility:hidden;  height:1px;  background-color:White"> 
        <div class="hd" align="center" ><%=TreeTitle%></div> 
        <div class="bd">
            <div style="height:300px; overflow:auto" id="<%=ClientID%>_tree"></div>
            <br /><b>Path:</b><span id="<%=ClientID%>_lblPath" ></span><br />
            <div align="center" >
             <input type="button" value="Aceptar" onclick="<%=ClientID%>Select()" />&nbsp;
             <input type="button" value="Cerrar" onclick="<%=ClientID%>Close()" />  
            </div> 
        </div>
   </div>
   </asp:Panel>
<script type="text/javascript">
function <%=ClientID%>SetTreeData(){
debugger ;
TreeData.Handler        = "<%=TreeHandler%>";
TreeData.RootText       = "<%=RootText%>";
TreeData.divTree        = "<%=ClientID%>_tree";
TreeData.divPanel       = "<%=ClientID%>_panel";
TreeData.txtSelect      = "<%=txtSelect.ClientID%>";
TreeData.hdSelect       = "<%=hdSelect.ClientID%>";
TreeData.hdFilter       = "<%=hdFilter.ClientID%>";
TreeData.lblPath        = "<%=ClientID%>_lblPath";
TreeData.SelectOption   = <%=(int) this.SelectOption %>;
TreeData.ShowOption     = <%=(int) this.ShowOption %>;
TreeData.ChangeValueHandler  = <%=ClientID%>ChangeValue;
} 
function <%=ClientID%>Open(){<%=ClientID%>SetTreeData();TreeData.Open();}
function <%=ClientID%>Clear(){<%=ClientID%>SetTreeData();TreeData.Clear();} 
function <%=ClientID%>Select(){<%=ClientID%>SetTreeData();TreeData.Select();}
function <%=ClientID%>Close(){<%=ClientID%>SetTreeData();TreeData.Close();} 
function <%=ClientID%>ChangeValue(){if(<%=Autopostback.ToString().ToLower()%>){__doPostBack('<%=hdSelect.ClientID%>','');}} 
var <%=ClientID%>Autocomplete =null;

function <%=ClientID%>SetAutocomplete()
{
    debugger;
    
    <%=ClientID%>SetTreeData();
    var strJson = $(TreeData.hdFilter).value;  
    if(strJson!="")
    {
        var filter = YAHOO.lang.JSON.parse(strJson);
        filter.IdIndicadorRubro =  $("<%=ddlSectorInd.ClientID%>").value;
        $(TreeData.hdFilter).value =YAHOO.lang.JSON.stringify(filter);
    }

    var hdFilter = '<%=hdFilter.ClientID%>';
    var strJson1 = $(hdFilter).value;
    if(strJson1!="")    
    {
        var filter = YAHOO.lang.JSON.parse(strJson1); 
        filter.IdIndicadorRubro = $("<%=ddlSectorInd.ClientID%>").value;
        $(hdFilter).value =YAHOO.lang.JSON.stringify(filter);        
    }

    <%=ClientID%>Autocomplete =new AutocompleteSimple('<%=AutocompleteHandler%>',$(hdFilter).value,'<%=txtSelect.ClientID%>','<%=hdSelect.ClientID%>','<%=ClientID%>AutoCompleteContainer',<%=ClientID%>ChangeValue,<%=(int) this.SelectOption %>,<%=(int) this.ShowOption %>);  
    <%=ClientID%>Autocomplete.oAC.minQueryLength = 1;
}

function <%=ClientID%>SelectSector()
{
    debugger ;

    $("<%=txtSelect.ClientID%>").value =""; /*German 20140602 - Tarea 124*/

    var strJson = $(TreeData.hdFilter).value;

    if(strJson!="")
    {
        var filter = YAHOO.lang.JSON.parse(strJson);
        filter.IdIndicadorRubro =  $("<%=ddlSectorInd.ClientID%>").value;
        $(TreeData.hdFilter).value =YAHOO.lang.JSON.stringify(filter);
    }
    
    TreeData.BuildTree();
    var hdFilter = '<%=hdFilter.ClientID%>';
    var strJson1 = $(hdFilter).value;

    if(strJson1!="")    
    {
        var filter = YAHOO.lang.JSON.parse(strJson1); 
        filter.IdIndicadorRubro = $("<%=ddlSectorInd.ClientID%>").value;
        $(hdFilter).value =YAHOO.lang.JSON.stringify(filter);        
        <%=ClientID%>Autocomplete.oDS.scriptQueryAppend = 'filter='+$(hdFilter).value+'&SelectOption='+<%=(int) this.SelectOption %>+'&ShowOption='+<%=(int) this.ShowOption %>+'&t'+(new Date().getTime());
    }


} 
</script>