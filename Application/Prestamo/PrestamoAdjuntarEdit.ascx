<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoAdjuntarEdit.ascx.cs" Inherits="UI.Web.PrestamoAdjuntarEdit" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Tagprefix="uc"  TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlPrestamoFiles" runat="server" GroupingText ="Archivos Adjuntos" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarPrestamoFile" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarPrestamoFile" runat ="server" Text="Agregar" OnClick="btAgregarPrestamoFile_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridPrestamoFiles"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridPrestamoFiles" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
            OnRowCommand="GridPrestamoFiles_RowCommand" OnRowDataBound="GridPrestamoFiles_OnRowDataBound"   
            AllowSorting="True" OnSorting="GridPrestamoFiles_Sorting"
            OnPageIndexChanging="GridPrestamoFiles_PageIndexChanging" PageSize="1000" 
            EmptyDataText="No hay Achivos adjuntados" 
            Width ="100%">
            <Columns>
                <asp:BoundField HeaderText ="Fecha" DataField ="File_Date" SortExpression ="File_Date" HeaderStyle-Width ="10%"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField HeaderText ="Nombre" DataField ="File_FileName" SortExpression ="File_FileName" HeaderStyle-Width ="83%" />
                <asp:TemplateField HeaderStyle-Width ="7%" >
                    <HeaderTemplate>
                    </HeaderTemplate>
                    <ItemTemplate>
                        &nbsp;
                        <asp:HyperLink ID="hlOpen" runat="server" Target="_blank" ImageUrl="../Images/download.png" ></asp:HyperLink>
                        &nbsp;
                        <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                    </ItemTemplate>            
                    <ItemStyle   HorizontalAlign ="Right"/>
                </asp:TemplateField>
            </Columns>
          </asp:GridView>
        </ContentTemplate>
    </asp:UpdatePanel>
</asp:Panel>
</div>

<%--PANEL ALTA ARCHIVOS --%>
<asp:Panel ID="PopUpPrestamoFiles" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="PrestamoFilesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpPrestamoFiles" runat="server" Text="Adjuntar" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnPrestamoFiles" DefaultButton="btSavePrestamoFiles" Height="170px" runat="server">
        <asp:UpdatePanel ID="upPrestamoFilesPopUp"  runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td style="width:80px">&nbsp;</td>
                        <td style="width:460px">
                            <table width="100%">
                                <tr>
                                    <td align="left" ><asp:Literal ID="litArchivo" runat="server" Text="Archivo" ></asp:Literal></td>
	                                <td align="left" ><uc:FileUploadWC ID="fuArchivo" runat="server" ></uc:FileUploadWC></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litNombre" runat="server" Text="Nombre" ></asp:Literal></td>
                                    <td><asp:TextBox ID="tbNombre" runat="server" Width="540px" /></td>
                                </tr>                            
                                <tr>
                                    <td><asp:Literal ID="litFecha" runat="server" Text="Fecha" ></asp:Literal></td>
                                    <td><uc:DateInput ID="diFecha" runat="server"  ValidationGroup="vgPrestamoFiles"
                                    IsValidEmpty="true"/></td>
                                </tr>
                                <tr>
                                    <td colspan='2' align="center"><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" ></asp:Label><br/></td>
                                </tr>
                                 <tr>
                                    <td align="center"  colspan="2" >                                
                                        <asp:Button ID="btSavePrestamoFiles" Text="Aceptar" OnClick="btSavePrestamoFile_Click" runat="server" ValidationGroup="vgPrestamoFiles" />
                                        <asp:Button ID="btNewPrestamoFiles" Text="Aceptar y Agregar Nuevo" OnClick="btNewPrestamoFile_Click" runat="server" ValidationGroup="vgPrestamoFiles" />
                                        <asp:Button ID="btCancelPrestamoFiles" Text="Cerrar" OnClick="btCancelPrestamoFile_Click" runat="server" Width="60px" />                                
                                    </td>
                                </tr>
                            </table>
                        </td>  
                        <td style="width:40px">&nbsp;</td>                      
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button2" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderPrestamoFiles" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="PrestamoFilesPopUpDragHandle" PopupControlID="PopUpPrestamoFiles"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>