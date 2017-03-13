<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="WebControl_CaracterEconomico.ascx.cs" Inherits="UI.Web.WebControl_CaracterEconomico" %>
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
TreeData.Handler        = "<%=TreeHandler%>";
TreeData.RootText       = "<%=RootText%>";
TreeData.divTree        = "<%=ClientID%>_tree";
TreeData.divPanel       = "<%=ClientID%>_panel";
TreeData.txtSelect      = "<%=txtSelect.ClientID%>";
TreeData.SelectOption   = <%=(int) this.SelectOption %>;
TreeData.ShowOption     = <%=(int) this.ShowOption %>;
TreeData.hdSelect       = "<%=hdSelect.ClientID%>";
TreeData.lblPath        = "<%=ClientID%>_lblPath";
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
    <%=ClientID%>Autocomplete =new AutocompleteSelect('<%=AutocompleteHandler%>','<%=hdFilter.Value%>','<%=txtSelect.ClientID%>','<%=hdSelect.ClientID%>','<%=ClientID%>AutoCompleteContainer',<%=ClientID%>ChangeValue,<%=(int) this.SelectOption %>,<%=(int) this.ShowOption %>);  
} 
</script>