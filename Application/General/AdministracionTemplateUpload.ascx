<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="AdministracionTemplateUpload.ascx.cs" Inherits="UI.Web.AdministracionTemplateUpload" %>
<%@ Register Tagprefix="uc"  TagName="DateInput" Src="~/Controls/WebControl_DateInput.ascx" %>
<%@ Register Tagprefix="uc"  TagName="FileUploadWC" Src="~/Controls/WebControl_FileUpload.ascx" %>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlTemplateFiles" runat="server" GroupingText ="Actualizar Template" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table cellpadding="0" cellspacing="5px" border="0"  width="100%">	  	
                    <tr>                      
	                    <td  align ="right" >
                            <asp:UpdatePanel ID="pnlAgregarTemplateFile" runat = "server" UpdateMode ="Conditional" >
                            <ContentTemplate>
                                <asp:Button ID="btAgregarTemplateFile" runat ="server" Text="Subir" OnClick="btAgregarTemplateFile_Click" TabIndex ="1"/> 
                            </ContentTemplate>
                            </asp:UpdatePanel>	                    
	                    </td>
                    </tr>
                </table>        
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridTemplateFiles"  runat="server" UpdateMode = "Conditional" >
    <ContentTemplate>
        <asp:GridView ID="gridTemplateFiles" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
            OnRowCommand="GridTemplateFiles_RowCommand" OnRowDataBound="GridTemplateFiles_OnRowDataBound"   
            AllowSorting="True" OnSorting="GridTemplateFiles_Sorting"
            OnPageIndexChanging="GridTemplateFiles_PageIndexChanging" PageSize="1000" 
            EmptyDataText="No hay Template cargado" 
            Width ="100%">
            <Columns>
                <asp:BoundField HeaderText ="Fecha" DataField ="Date" SortExpression ="Date" HeaderStyle-Width ="10%"  DataFormatString="{0:dd/MM/yyyy}" />
                <asp:BoundField HeaderText ="Nombre" DataField ="FileName" SortExpression ="FileName" HeaderStyle-Width ="83%" />
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
<asp:Panel ID="PopUpTemplateFiles" runat="server" Width="800px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="TemplateFilesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpTemplateFiles" runat="server" Text="Actualizar" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnTemplateFiles" DefaultButton="btSaveTemplateFiles" Height="170px" runat="server">
        <asp:UpdatePanel ID="upTemplateFilesPopUp"  runat="server" UpdateMode="Conditional">
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
                                    <td colspan='2' align="center"><asp:Label ID="lblError" runat="server" Text="" ForeColor="Red" ></asp:Label><br/></td>
                                </tr>
                                 <tr>
                                    <td align="center"  colspan="2" >                                
                                        <asp:Button ID="btSaveTemplateFiles" Text="Aceptar" OnClick="btSaveTemplateFile_Click" runat="server" ValidationGroup="vgTemplateFiles" />
                                        <asp:Button ID="btCancelTemplateFiles" Text="Cerrar" OnClick="btCancelTemplateFile_Click" runat="server" Width="60px" />                                
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
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderTemplateFiles" runat="server" CancelControlID="Button2"
        PopupDragHandleControlID="TemplateFilesPopUpDragHandle" PopupControlID="PopUpTemplateFiles"
        OkControlID="Button2" TargetControlID="Button2" BackgroundCssClass="modalBackground" />
</asp:Panel>