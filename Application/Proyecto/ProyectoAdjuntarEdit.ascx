<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoAdjuntarEdit.ascx.cs" Inherits="UI.Web.ProyectoAdjuntarEdit" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Tagprefix="uc"  TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>
<!-- Matias 20140127 - Tarea 109 -->
<script type ="text/javascript" >
    function divLoadingGif() {
        setTimeout("document.getElementById ('DivLoadingGif').style.display ='block';", 500);
    }
</script>
<!-- FinMatias 20140127 - Tarea 109 -->
<div class="TabbedPanelsContent">
<asp:Panel ID="pnlProyectoFiles" runat="server" GroupingText ="Archivos Adjuntos" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarProyectoFile" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarProyectoFile" runat ="server" Text="Agregar" OnClick="btAgregarProyectoFile_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>  
    
    <asp:UpdatePanel ID= "upGridProyectoFiles"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridProyectoFiles" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
            OnRowCommand="GridProyectoFiles_RowCommand" OnRowDataBound="GridProyectoFiles_OnRowDataBound"   
            AllowSorting="True" OnSorting="GridProyectoFiles_Sorting"
            OnPageIndexChanging="GridProyectoFiles_PageIndexChanging" PageSize="10" 
            EmptyDataText="No hay Achivos adjuntos" 
            Width ="100%">
            <Columns>
                <asp:BoundField HeaderText ="Fecha" DataField ="File_Date" SortExpression ="File_Date" HeaderStyle-Width ="30px"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField HeaderText ="Nombre" DataField ="File_FileName" SortExpression ="File_FileName" HeaderStyle-Width ="700px" />
                <asp:TemplateField>
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;
                        <asp:HyperLink ID="hlOpen" runat="server" Target="_blank" ImageUrl="../Images/download.png" ></asp:HyperLink>
                        &nbsp;
                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                    </ItemTemplate>            
                    <ItemStyle Width="150px"  HorizontalAlign ="Right"/>
                </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

<br/>

    <%--PANEL MARCO LEGAL --%>
    <div class="CollapsiblePanelTab">
        <span id="spanMarcoLegal">
            <asp:Label ID="lblMarcoLegal" runat="server" Text="Marco Legal"></asp:Label>
            &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpeMarcoLegal" runat="Server" TargetControlID="pnlMarcoLegal"
            Collapsed="True" ExpandControlID="lblMarcoLegal" CollapseControlID="lblMarcoLegal"
            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlMarcoLegal" runat="server">
    <asp:UpdatePanel ID="upMarcoLegal" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtMarcoLegal" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revMarcoLegal" runat="server" ControlToValidate="txtMarcoLegal"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>

    <%--PANEL INFO ADICIONAL --%>
    <div class="CollapsiblePanelTab">
        <span id="spanInfoAdicional">
            <asp:Label ID="lblInfoAdicional" runat="server" Text="Información Adicional"></asp:Label>
            &nbsp;&nbsp;<img src="../App_Themes/Sky/Images/Layout/SpryMenuBarRight.gif" />
        </span>
        <ajaxToolkit:CollapsiblePanelExtender ID="cpeInfoAdicional" runat="Server" TargetControlID="pnlInfoAdicional"
            Collapsed="True" ExpandControlID="lblInfoAdicional" CollapseControlID="lblInfoAdicional"
            AutoCollapse="False" AutoExpand="False" ExpandDirection="Vertical" />
    </div>
    <asp:Panel ID="pnlInfoAdicional" runat="server">
    <asp:UpdatePanel ID="upInfoAdicional" runat="server" UpdateMode="Conditional">
        <ContentTemplate>
            <table width="100%" cellpadding="0" cellspacing="5px" border="0">
                <tr>
                    <td>
                        <asp:TextBox runat="server" ID="txtInfoAdicional" Rows="6" TextMode="MultiLine"></asp:TextBox>
                    </td>
                </tr>
                <tr>
                    <td>
                        <asp:RegularExpressionValidator ID="revInfoAdicional" runat="server" ControlToValidate="txtInfoAdicional"
                            ValidationGroup="EditionProyectoEvaluacion" Text="*" Width="1px" Height="1px">
                        </asp:RegularExpressionValidator>
                    </td>
                </tr>
            </table>
        </ContentTemplate>
    </asp:UpdatePanel>
    </asp:Panel>
</div>

<%--PANEL ALTA ARCHIVOS --%>
<asp:Panel ID="PopUpProyectoFiles" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectoFilesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpProyectoFiles" runat="server" Text="Adjuntar" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectoFiles" DefaultButton="btSaveProyectoFiles" Height="170px" runat="server">
        <asp:UpdatePanel ID="upProyectoFilesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="width:20px">&nbsp;</td>
                        <td style="width:460px">
                            <table width="100%">
                                <tr>
                                    <td align="left" ><asp:Literal ID="litArchivo" runat="server" Text="Archivo" ></asp:Literal></td>
	                                <td align="left"><uc:FileUploadWC ID="fuArchivo" runat="server"  ></uc:FileUploadWC></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litNombre" runat="server" Text="Nombre" ></asp:Literal></td>
                                    <td><asp:TextBox ID="tbNombre" runat="server" Width="540px"/></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litFecha" runat="server" Text="Fecha" ></asp:Literal></td>
                                    <td><uc:DateInput ID="diFecha" runat="server" ValidationGroup="vgProyectoFiles"
                                    IsValidEmpty="true"/></td>
                                    
                                </tr>
                                <tr>
                                    <td colspan='2' align="center"><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" ></asp:Label><br/></td>
                                </tr>
                                 <tr>
                                    <td align="center"  colspan="2" >                                
                                        <asp:Button ID="btSaveProyectoFiles" Text="Aceptar" OnClick="btSaveProyectoFile_Click" runat="server" ValidationGroup="vgProyectoFiles" OnClientClick="divLoadingGif()"/>
                                        <asp:Button ID="btNewProyectoFiles" Text="Aceptar y Agregar Nuevo" OnClick="btNewProyectoFile_Click" runat="server" ValidationGroup="vgProyectoFiles" />
                                        <asp:Button ID="btCancelProyectoFiles" Text="Cerrar" OnClick="btCancelProyectoFile_Click" runat="server" Width="60px" />                                
                                        <div id="DivLoadingGif" style="display:none">
                                            <image src="../Images/loading_file.gif" />
                                        </div>
                                    </td>
                                </tr>
                            </table>
                        </td>                        
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectoFiles" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="ProyectoFilesPopUpDragHandle" PopupControlID="PopUpProyectoFiles"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>