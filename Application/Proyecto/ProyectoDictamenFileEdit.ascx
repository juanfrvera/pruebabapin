<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="ProyectoDictamenFileEdit.ascx.cs" Inherits="UI.Web.ProyectoDictamenFileEdit" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Tagprefix="uc"  TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlProyectoDictamenFiles" runat="server" GroupingText ="Archivos Adjuntos" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarProyectoDictamenFile" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarProyectoDictamenFile" runat ="server" Text="Agregar" OnClick="btAgregarProyectoDictamenFile_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridProyectoDictamenFiles"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridProyectoDictamenFiles" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
            OnRowCommand="GridProyectoDictamenFiles_RowCommand"
            OnRowDataBound="GridProyectoDictamenFiles_OnRowDataBound"   
            AllowSorting="True" OnSorting="GridProyectoDictamenFiles_Sorting"
            OnPageIndexChanging="GridProyectoDictamenFiles_PageIndexChanging" PageSize="1000" 
            EmptyDataText="No hay Achivos adjuntados" 
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
</div>

<%--PANEL ALTA ARCHIVOS --%>
<asp:Panel ID="PopUpProyectoDictamenFiles" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="ProyectoDictamenFilesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpProyectoDictamenFiles" runat="server" Text="Adjuntar" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnProyectoDictamenFiles" DefaultButton="btSaveProyectoDictamenFiles" Height="170px" runat="server">
        <asp:UpdatePanel ID="upProyectoDictamenFilesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="width:74px">&nbsp;</td>
                        <td >
                            <table width="80%">
                                <tr>
                                    <td align="left" ><asp:Literal ID="litArchivo" runat="server" Text="Archivo" ></asp:Literal></td>
	                                <td align="left"><uc:FileUploadWC ID="fuArchivo" runat="server"></uc:FileUploadWC></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litNombre" runat="server" Text="Nombre" ></asp:Literal></td>
                                    <td><asp:TextBox ID="tbNombre" runat="server" width="480"/></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litFecha" runat="server" Text="Fecha" ></asp:Literal></td>
                                    <td><uc:DateInput ID="diFecha" runat="server" /></td>
                                </tr>
                                <tr>
                                    <td colspan='2' align="center"><asp:Label ID="lblError" runat="server" Text="" ></asp:Label><br/></td>
                                </tr>
                                 <tr>
                                    <td align="center"  colspan="2" >                                
                                        <asp:Button ID="btSaveProyectoDictamenFiles" Text="Aceptar" OnClick="btSaveProyectoDictamenFile_Click" runat="server" ValidationGroup="vgProyectoDictamenFiles" />
                                        <asp:Button ID="btNewProyectoDictamenFiles" Text="Aceptar y Agregar Nuevo" OnClick="btNewProyectoDictamenFile_Click" runat="server" ValidationGroup="vgProyectoDictamenFiles" />
                                        <asp:Button ID="btCancelProyectoDictamenFiles" Text="Cerrar" OnClick="btCancelProyectoDictamenFile_Click" runat="server" Width="60px" />                                
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderProyectoDictamenFiles" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="ProyectoDictamenFilesPopUpDragHandle" PopupControlID="PopUpProyectoDictamenFiles"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>