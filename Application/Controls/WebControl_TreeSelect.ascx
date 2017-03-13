<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_TreeSelect.ascx.cs" Inherits="UI.Web.WebControl_TreeSelect" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="atk" %>

<style type="text/css">
.imgButton
{
    width:23px;
    height:23px;
    vertical-align:bottom;
    padding:0px 0px 0px 0px;
}
.AutoComplete {    
    padding-bottom:2em;
}
</style>
<link rel="stylesheet" type="text/css" href="../App_Scripts/yui/build/fonts/fonts-min.css" /> 
<link rel="stylesheet" type="text/css" href="../App_Scripts/yui/build/treeview/assets/skins/sam/treeview.css" />
<link rel="stylesheet" type="text/css" href="../App_Scripts/yui/build/container/assets/skins/sam/container.css" />
<link rel="stylesheet" type="text/css" href="../App_Scripts/yui/build/autocomplete/assets/skins/sam/autocomplete.css" /> 

<script type="text/javascript" src="../App_Scripts/yui/build/yahoo/yahoo-min.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/json/json-min.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/yahoo-dom-event/yahoo-dom-event.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/connection/connection-min.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/treeview/treeview-min.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/dragdrop/dragdrop-min.js"></script> 
<script type="text/javascript" src="../App_Scripts/yui/build/container/container-min.js"></script> 
<script type="text/javascript" src="../App_Scripts/yui/build/animation/animation-min.js"></script>
<script type="text/javascript" src="../App_Scripts/yui/build/datasource/datasource-debug.js"></script> 
<script type="text/javascript" src="../App_Scripts/yui/build/autocomplete/autocomplete-debug.js"></script>  

<script src="../App_Scripts/TreeSelect.js" type="text/javascript"></script>
<script> 
<!-- 
function <%=ClientID%>SetTreeData(){
TreeData.Handler        = "<%=Handler%>";
TreeData.RootText       = "<%=RootText%>";
TreeData.divTree        = "<%=ClientID%>_tree";
TreeData.divPanel       = "<%=ClientID%>_panel";
TreeData.txtSelect      = "<%=txtSelect.ClientID%>";
TreeData.hdSelect       = "<%=hdSelect.ClientID%>";
TreeData.lblPath        = "<%=ClientID%>_lblPath"; 
}
function <%=ClientID%>Open(){<%=ClientID%>SetTreeData();TreeData.Open();}
function <%=ClientID%>Clear(){<%=ClientID%>SetTreeData();TreeData.Clear();} 
function <%=ClientID%>Select(){<%=ClientID%>SetTreeData();TreeData.Select();}
function <%=ClientID%>Close(){<%=ClientID%>SetTreeData();TreeData.Close();}          
//-->
</script>     
<asp:updatepanel id="upControl" runat="server" childrenastriggers="False" updatemode="Conditional">
<contenttemplate>
<asp:Panel ID="pnControl" runat="server"  >
    <div id="AutoComplete" class="AutoComplete"> 
        <asp:TextBox ID="txtSelect" runat="server" Width="250px"  autocomplete="off" ValidationGroup=""  ></asp:TextBox>
        <img src="../Images/OrganizationalUnit.png" style="cursor:hand"  onclick="<%=ClientID%>Open()" /> 
        <img src="../App_Themes/Sky/Images/Icons/clear.gif" style="cursor:hand"  onclick="<%=ClientID%>Clear()" />
        <div id="AutoCompleteContainer"></div> 
    </div>
    <asp:HiddenField ID="hdSelect" OnValueChanged="hdSelect_ValueChanged" runat="server" />             
    <div id="<%=ClientID%>_panel"  style="visibility:hidden;  height:1px;  background-color:White"> 
        <div class="hd" align="center" >Clasificacion Geografica</div> 
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
</contenttemplate>
    <triggers>
        <asp:AsyncPostBackTrigger controlId="hdSelect" />
    </triggers>
</asp:updatepanel>
   
   <script type="text/javascript"> 
YAHOO.example.BasicRemote = function() {       
    
    var dataSource = new YAHOO.widget.DS_XHR("../Handlers/ClasificacionGeograficaAutocompleteHandler.ashx");    
    dataSource.scriptQueryParam = "query";
    dataSource.scriptQueryAppend = "filter=<%=JsonFilter%>";
    dataSource.responseType = YAHOO.widget.DS_XHR.TYPE_JSON;
    dataSource.maxCacheEntries = 100;
    dataSource.responseSchema = {resultsList:"Nodes",fields:[{key:"Id"}
                                                     ,{key:"ParentId"}
                                                     ,{key:"Level"}
                                                     ,{key:"Orden"}
                                                     ,{key:"Text"}
                                                     ,{key:"PathComplete"}
                                                     ,{key:"BreadcrumbId"}
                                                     ,{key:"BreadcrumbOrden"}
                                                     ,{key:"Descripcion"}
                                                     ,{key:"DescripcionInvertida"}
                                                     ]                                             
                               };    
//    var dataSource = new YAHOO.util.XHRDataSource("../Handlers/ClasificacionGeograficaAutocompleteHandler.ashx");    
//    dataSource.scriptQueryParam = "query";
//    dataSource.s
//    dataSource.responseType = YAHOO.widget.DS_XHR.TYPE_JSON;
//    dataSource.maxCacheEntries = 100;
//    dataSource.responseSchema = {resultsList:"Nodes",fields:[{key:"Id"}
//                                                     ,{key:"ParentId"}
//                                                     ,{key:"Level"}
//                                                     ,{key:"Orden"}
//                                                     ,{key:"Text"}
//                                                     ,{key:"PathComplete"}
//                                                     ,{key:"BreadcrumbId"}
//                                                     ,{key:"BreadcrumbOrden"}
//                                                     ,{key:"Descripcion"}
//                                                     ,{key:"DescripcionInvertida"}
//                                                     ]                                             
//                               };
    // Instantiate the AutoComplete
    var autoComplete = new YAHOO.widget.AutoComplete("<%=ClientID%>_txtSelect", "AutoCompleteContainer", dataSource);
    autoComplete.minQueryLength = 4;
    autoComplete.queryDelay = 0.3;
    autoComplete.queryMatchSubset = true;
    autoComplete.resultTypeList = false;   
    autoComplete.formatResult = function(oResultData, sQuery, sResultMatch) {
        return oResultData.Descripcion;
    };
    
    var itemSelectHandler = function(sType, aArgs) {
	    //debugger;
	    var o = aArgs[2];
        $("<%=txtSelect.ClientID%>").value = o.Descripcion;
	    var strJson = '{"Id":'+o.Id+',"ParentId":'+o.ParentId+',"Level":'+o.Level+',"Orden":'+o.Orden+',"Text":'+o.Text+',"PathComplete":'+o.PathComplete+',"BreadcrumbId":'+o.BreadcrumbId+',"BreadcrumbOrden": '+o.BreadcrumbOrden+',"Descripcion": '+o.Descripcion+',"DescripcionInvertida": '+o.DescripcionInvertida+'}';
	    $("<%=hdSelect.ClientID%>").value= strJson;
	    __doPostBack('<%=hdSelect.ClientID%>','')
    };
    autoComplete.itemSelectEvent.subscribe(itemSelectHandler)
    
    return {
        oDS: dataSource,
        oAC: autoComplete
    };
}();
 function __doPostBack(eventTarget, eventArgument) {
   document.form1.__EVENTTARGET.value = eventTarget;
   document.form1.__EVENTARGUMENT.value = eventArgument;
   document.form1.submit();
}

</script>                                     
