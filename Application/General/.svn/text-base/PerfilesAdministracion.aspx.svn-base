<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="PerfilesAdministracion.aspx.cs" Inherits="UI.Web.PerfilesAdministracion" %>
<asp:Content ID="Content2" ContentPlaceHolderID="ContenidoPrincipal" runat="server">

<script language="javascript" type="text/javascript">
    var hiddenFieldRootText = '<%=hfRootText.Value%>'
    
    function OnTreeClick(evt)
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
    var hiddenFieldCtlId = '<%=hfGraba.ClientID%>';
    var gridViewCtlId = '<%=gvPerfiles.ClientID%>';
    var hiddenFieldCtl = null;
    var gridViewCtl = null;
    var curSelRow = null;

    
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
   
    <table border="0" style="width:100%;height:540px;" >
        <tr>
            <td style="vertical-align:top"  >
                <table border="0">
                    <tr>
                        <td id="tdGrillaArticulos" runat="server" align="right" style="vertical-align:top;border:solid 1px #cccccc" >
                            <asp:Panel ID="Panel2" runat="server" Style="height:400px;width:140px;overflow:auto;" >
                                <asp:GridView ID="gvPerfiles" AutoGenerateColumns="false" DataKeyNames="RoleName" runat="server" SkinID="GridView1" style="width:100%" 
                                 AllowPaging="false" OnSelectedIndexChanged="gvPerfiles_SelectedIndexChanged" OnRowCreated="gvPerfiles_RowCreated" 
                                 ShowHeader="true" Caption='' BorderStyle="None">
                                    <Columns>                                        
                                        <asp:ButtonField ButtonType="Link" CommandName="Select"  Visible="true" CausesValidation="true" 
                                        DataTextField="RoleName" HeaderText="Perfiles" SortExpression="RoleName"
                                        ItemStyle-HorizontalAlign="Left" ItemStyle-Height="18" ItemStyle-BorderStyle="None"/>
                                    </Columns>
                                </asp:GridView>
                            </asp:Panel>
                        </td>
                        <td id="tdGrillaArticulosSucursales" runat="server" style="vertical-align:top; background-color:#fcfcfc; border:solid 1px #cccccc" align="left">
                            <asp:Panel ID="Panel1" runat="server" Style="height:540px;width:680px;overflow:auto;">
                                <table width="100%"><tr><td></td></tr></table>
                                <asp:UpdatePanel ID="upGrillaAcciones" UpdateMode="Conditional" ChildrenAsTriggers="true" runat="server" > 
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvPerfiles" EventName="SelectedIndexChanged"/>
                                        <asp:AsyncPostBackTrigger ControlID="btnAceptar" EventName="Click"/>
                                    </Triggers>
                                    <ContentTemplate>
                                        <asp:GridView ID="gvAcciones" AutoGenerateColumns="false" DataKeyNames="ruleName,Asignado" runat="server" SkinID="GridView1" 
                                        style="width:100%" Caption='<table width="100%" class="tablaEncabezado"><tr><td>Acciones</td></tr></table>'>
                                            <Columns>
                                                <asp:BoundField DataField="ruleName" HeaderText="Perfiles" SortExpression="ruleName">
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="gridColumnaHeader"/>
                                                    <ItemStyle CssClass="gridColumnaItem"/>
                                                </asp:BoundField>  
                                                <asp:TemplateField HeaderText="Asignar" ItemStyle-HorizontalAlign="Center" >
                                                    <HeaderTemplate>
                                                        <label id="SoloExhibicion" style="white-space:nowrap"><asp:Literal ID="liAsignado" Text="Asignado" runat="server" ></asp:Literal>
                                                        <input id="cbTodosAsignado" runat="server" name="cbTodosAsignado" type="checkbox" title="Marcar Todos" visible="true" onclick="modifCheckBox('cbAsignado', this.checked);"/>
                                                        </label>
                                                    </HeaderTemplate>
                                                    <HeaderStyle HorizontalAlign="Center" CssClass="gridColumnaHeader"/>
                                                    <ItemStyle Width="150px" HorizontalAlign="Center" CssClass="gridColumnaItem"/>
                                                    <ItemTemplate>
                                                        <input id="cbAsignado" runat="server" name="cbAsignado" type="checkbox" value='<%# Eval("Asignado") %>' checked='<%# EvalAsignado(Eval("Asignado").ToString()) %>' onclick="modifCheckBox('','');"/>
                                                    </ItemTemplate>
                                                </asp:TemplateField>                                                      
                                            </Columns>
                                        </asp:GridView>
                                        <asp:HiddenField ID="hfGraba" runat="server"/>                                    
                                        <asp:TreeView ID="treeAcciones" runat="server" SkinID="treeViewSkin" NodeIndent="20" ShowLines="true" onclick="OnTreeClick(event);">
                                            <NodeStyle ChildNodesPadding="0" NodeSpacing="0" />
                                        </asp:TreeView>                                    
                                        <asp:HiddenField ID="hfRootText" runat="server" Value="(Asignar Todas)"/>        
                                    </ContentTemplate>
                                </asp:UpdatePanel>  
                            </asp:Panel>
                        </td>
                    </tr>
                </table>
            </td>
        </tr>
        <tr>
            <td align="center">
                <table>
                    <tr>                                                    
                        <td>
                            <asp:Button ID="btnAceptar" runat="server" text="Aceptar" OnClick="btnAceptar_Click" />
                            <asp:Button ID="btnSalir" runat="server" Text="Cancelar"  OnClick="btnSalir_Click" />
                        </td>
                    </tr>
                </table>            
            </td>
        </tr>
    </table>
</asp:Content>
