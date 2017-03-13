<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ActividadPageEdit.aspx.cs" Inherits="UI.Web.ActividadPageEdit" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="EditActividad" Src="ActividadEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>
  
<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
<%--
<script language="javascript" type="text/javascript">
unction OnTreeClick(evt)
    { 
       var src = window.event != window.undefined ? window.event.srcElement : evt.target; 
        var isChkBoxClick = (src.tagName.toLowerCase() == "input" && src.type == "checkbox"); 
        
        if(isChkBoxClick) 
        {     
            var parentTable = GetParentByTagName("table", src);     
            var nxtSibling = parentTable.nextSibling;     
            
            //check if nxt sibling is not null & is an element node      
            if(nxtSibling && nxtSibling.nodeType == 1)     
            {         
                if(nxtSibling.tagName.toLowerCase() == "div") //if node has children         
                {             
                    //check or uncheck children at all levels 
                    CheckUncheckChildren(parentTable.nextSibling, src.checked);         
                }     
            } 
            
            //check or uncheck parents at all levels 
            CheckUncheckParents(src, src.checked); 
            
            //mark thats something has changed, so much save in the db 
            hiddenFieldCtl = document.getElementById(hiddenFieldCtlId);
            if (hiddenFieldCtl != null)
            {
                hiddenFieldCtl.value = 'false';
            }
        }
    } 
    
    function CheckUncheckChildren(childContainer, check)
    { 
        var childChkBoxes = childContainer.getElementsByTagName("input");      
        var childChkBoxCount = childChkBoxes.length; 
        
        for(var i=0;i<childChkBoxCount;i++) 
        {     
            childChkBoxes[i].checked = check; 
        }
    }
    
    function CheckUncheckParents(srcChild, check)
    { 
        var parentDiv = GetParentByTagName("div", srcChild); 
        var parentNodeTable = parentDiv.previousSibling; 
        
        if(parentNodeTable) 
        {     
            var checkUncheckSwitch;     
            if(check) //checkbox checked     
            {         
                var isAllSiblingsChecked = true;//AreAllSiblingsChecked(srcChild);         
                if(isAllSiblingsChecked)                 
                    checkUncheckSwitch = true;         
                else                 
                    return; //do not need to check parent if any(one or more) child not checked     
            }     
            else //checkbox unchecked     
            {         
                var isAllSiblingsUnChecked = false;//AreAllSiblingsUnChecked(srcChild);         
                if(isAllSiblingsUnChecked)                 
                    checkUncheckSwitch = false;         
                else                 
                    return; //do not need to check parent if any(one or more) child not checked  
            }        
            
            var inpElemsInParentTable = parentNodeTable.getElementsByTagName("input");     
            if(inpElemsInParentTable.length > 0)     
            {         
                var parentNodeChkBox = inpElemsInParentTable[0]; 
                if (parentNodeChkBox.title != hiddenFieldRootText)        
                    parentNodeChkBox.checked = checkUncheckSwitch;         
                
                //do the same recursively        
                CheckUncheckParents(parentNodeChkBox, checkUncheckSwitch);     
            } 
        }
    }
    
    function AreAllSiblingsChecked(chkBox)
    { 
        var parentDiv = GetParentByTagName("div", chkBox); 
        var childCount = parentDiv.childNodes.length; 
        
        for(var i=0;i<childCount;i++) 
        {     
            if(parentDiv.childNodes[i].nodeType == 1)     
            {         
                //check if the child node is an element node         
                if(parentDiv.childNodes[i].tagName.toLowerCase() == "table")         
                {             
                    var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];             
                    //if any of sibling nodes are not checked, return false             
                    if (prevChkBox != null)
                    {
                        if(!prevChkBox.checked)             
                        {                 
                            return false;             
                        }
                    }         
                }     
            } 
        } 
        
        return true;
    }
    
    function AreAllSiblingsUnChecked(chkBox)
    { 
        var parentDiv = GetParentByTagName("div", chkBox); 
        var childCount = parentDiv.childNodes.length; 
        
        for(var i=0;i<childCount;i++) 
        {     
            if(parentDiv.childNodes[i].nodeType == 1)     
            {         
                //check if the child node is an element node         
                if(parentDiv.childNodes[i].tagName.toLowerCase() == "table")         
                {             
                    var prevChkBox = parentDiv.childNodes[i].getElementsByTagName("input")[0];             
                    //if any of sibling nodes are not checked, return false             
                    if (prevChkBox != null)
                    {
                        if(prevChkBox.checked)             
                        {                 
                            return false;             
                        }
                    }         
                }     
            } 
        } 
        
        return true;
    }
    
    //utility function to get the container of an element by tagname
    function GetParentByTagName(parentTagName, childElementObj)
    { 
        var parent = childElementObj.parentNode; 
        while(parent.tagName.toLowerCase() != parentTagName.toLowerCase())     
        {         
            parent = parent.parentNode;     
        } 
        
        return parent;
    }
</script>  
<script language="javascript" type="text/javascript">
    
    function getGridViewControl()
    {
        if (null == gridViewCtl)
        {
            gridViewCtl = document.getElementById(gridViewCtlId);
        }
        else
        {
            if (gridViewCtl.rows.length == 0)
            {
                gridViewCtl = document.getElementById(gridViewCtlId);
            }
        }
    }
    
    function onGridViewRowSelected(rowIdx)
    {
        hiddenFieldCtl = document.getElementById(hiddenFieldCtlId);
        if (hiddenFieldCtl != null)
        {
            if(hiddenFieldCtl.value != '') 
            //if(curSelRow != null)
                hiddenFieldCtl.value = confirm('¿Desea grabar los cambios?');
        }
    
        var selRow = getSelectedRow(rowIdx);
        if (curSelRow != null)
        {
            curSelRow.style.backgroundColor = '';
        }
        
        if (null != selRow)
        {
            curSelRow = selRow;
            curSelRow.style.backgroundColor = '#f0f0f0';
        }
        
        return false;
    }
    
    function getSelectedRow(rowIdx)
    {
        getGridViewControl();
        if (null != gridViewCtl)
        {
            return gridViewCtl.rows[rowIdx];
        }
        return null;
    }
    
    function modifCheckBox(aspRadioID, value)
    {
        hiddenFieldCtl = document.getElementById(hiddenFieldCtlId);
        if (hiddenFieldCtl != null)
        {
            hiddenFieldCtl.value = 'false';
        }
    }
</script>
--%>    
    <table >		 
		<tr><td>&nbsp;</td></tr>
        <tr>
            <td>
                <asp:UpdatePanel ID="upEdit" runat="server">
                    <ContentTemplate>
                        <uc:EditActividad runat="server" ID="editActividad" ></uc:EditActividad>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
		    <td>
		        <asp:ValidationSummary id="vsEditionActividad" runat="server" DisplayMode="BulletList" ValidationGroup="EditionActividad" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
		    </td>
		</tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upEditButtons" runat="server">
                    <ContentTemplate>
                       <uc:EditButtons runat="server" ID="editButtons"  ValidationGroup="EditionActividad" ></uc:EditButtons >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
    </table>
</asp:Content>
