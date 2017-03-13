<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="TestTreeView.aspx.cs" Inherits="Application.Test.TestTreeView" %>
<%@ Register Tagprefix="uc" TagName="TreeOficina" Src="~/ControlsPersonal/WebControl_Oficinas.ascx"  %>   
<%@ Register Tagprefix="uc" TagName="TreeLocalizacionGeografica" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx"  %> 
<%@ Register Tagprefix="uc" TagName="TreeClasificacionGasto" Src="~/ControlsPersonal/WebControl_ClasificacionGasto.ascx"  %> 
<%@ Register Tagprefix="uc" TagName="TreeFinalidadFuncion" Src="~/ControlsPersonal/WebControl_FinalidadFuncion.ascx"  %> 
<%@ Register Tagprefix="uc" TagName="TreeFuenteFinanciamiento" Src="~/ControlsPersonal/WebControl_FuenteFinanciamiento.ascx"  %> 


<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Untitled Page</title>
    
<script>
function __doPostBack(eventTarget, eventArgument) {
   document.form1.__EVENTTARGET.value = eventTarget;
   document.form1.__EVENTARGUMENT.value = eventArgument;
   document.form1.submit();
}
</script>
<style type="text/css">
.imgButton
{
    width:23px;
    height:23px;
    vertical-align:bottom;
    padding:0px 0px 0px 0px;
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
</head>
<body class="yui-skin-sam" >
    <form id="form1" runat="server">
        <input type="hidden" name="__EVENTTARGET" value="" />
	    <input type="hidden" name="__EVENTARGUMENT" value="" />
     <div>
        <asp:scriptmanager id="ScriptManager1" runat="server"></asp:scriptmanager>
       <table>            
            <tr>
                <td>Clasificacion Geografica:</td>
                <td><uc:TreeLocalizacionGeografica runat="server"  Width="320px" ID="treeLocalizacionGeografica" ></uc:TreeLocalizacionGeografica></td>
            </tr>
            <tr>
                <td>Clasificacion Oficina:</td>
                <td><uc:TreeOficina runat="server" ID="treeOficina" Width="220px" ></uc:TreeOficina></td>
            </tr>
            <tr>
                <td>Clasificacion Gasto:</td>
                <td><uc:TreeClasificacionGasto runat="server" Width="300px" ID="treeClasificacionGasto" ></uc:TreeClasificacionGasto></td>
            </tr>
            <tr>
                <td>Finalidad Funcion:</td>
                <td><uc:TreeFinalidadFuncion runat="server" Width="400px" ID="treeFinalidadFuncion" ></uc:TreeFinalidadFuncion></td>
            </tr>
            <tr>
                <td>Fuente Financiamiento:</td>
                <td><uc:TreeFuenteFinanciamiento runat="server" ID="treeFuenteFinanciamiento" ></uc:TreeFuenteFinanciamiento></td>
            </tr>             
       </table>  
            
   </div>
    </form>
</body>
</html>
