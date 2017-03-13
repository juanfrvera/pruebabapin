<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="PrestamoAlcanceGeograficoEdit.ascx.cs" Inherits="UI.Web.PrestamoAlcanceGeograficoEdit" %>
<%@ Register Tagprefix="uc" TagName="TreeLocalizacion" Src="~/ControlsPersonal/WebControl_LocalizacionGeografica.ascx"   %>

<div class="TabbedPanelsContent">
<asp:Panel ID="pnlAlcanceGeografico" runat="server" GroupingText ="Alcance Geográfico" >
    <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
        <tr>
            <td>
                <table width="100%"  cellpadding="0" cellspacing="5px" border="0">	  	
                    <tr>
                        <td>
                            <table cellpadding="0" cellspacing="5px" border="0"   width="100%">	  	
                                <tr>                      
                                    <td  align ="right" >
                                        <asp:UpdatePanel ID="pnlAgregarAlcance" runat = "server" UpdateMode ="Conditional" >
                                        <ContentTemplate>
                                            <asp:Button ID="btAgregarAlcance" runat ="server" Text="Agregar" OnClick="btAgregarAlcance_Click" TabIndex ="2"/> 
                                        </ContentTemplate>
                                        </asp:UpdatePanel>	                    
                                    </td>
                                </tr>
                            </table>        
                        </td>
                    </tr>        
                </table>       
            </td>
        </tr>        
    </table>  
    <asp:UpdatePanel ID= "upGridAlcances"  runat="server" UpdateMode = "Conditional" >
        <ContentTemplate>
        <asp:GridView ID="gridAlcances" runat = "server"
            AutoGenerateColumns="False" DataKeyNames="ID" AllowPaging="True" 
            OnRowCommand="GridAlcances_RowCommand"    
            AllowSorting="True" OnSorting="GridAlcances_Sorting"
            OnPageIndexChanging="GridAlcances_PageIndexChanging" 
            EmptyDataText="No hay Alcances geográficos definidos" 
            Width ="100%">
            <Columns>
                <asp:BoundField HeaderText ="Descripción" DataField ="Descripcion" SortExpression ="Descripcion"  HeaderStyle-Width="92%" />
                    <asp:TemplateField   HeaderStyle-Width="8%">
                        <HeaderTemplate>
                        </HeaderTemplate>
                        <ItemTemplate>
                            &nbsp;
                            <asp:ImageButton ID ="imgEdit" runat ="server"  src="../Images/edit.png" ToolTip ="Editar" CommandName='<%# Command.EDIT %>' CommandArgument='<%#Eval("ID")%>'   CausesValidation="false"  />
                            &nbsp;
                            <asp:ImageButton ID ="imgDelete" runat ="server"  src="../Images/delete.jpg" ToolTip ="Eliminar" CommandName='<%# Command.DELETE %>'   OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' CommandArgument='<%#Eval("ID")%>' CausesValidation="false" />            
                        </ItemTemplate>            
                        <ItemStyle HorizontalAlign ="Right"/>
                    </asp:TemplateField>
                </Columns>
            </asp:GridView>
        </ContentTemplate>
     </asp:UpdatePanel>
</asp:Panel>
</div>


<%--PANEL ALTA ALCANCES --%>
<asp:Panel ID="PopUpAlcances" runat="server" Width="800px" Height="120px" Style="background-color: #ffffff;
    border: solid 2px #ffffff; border-color: Gray;">
    <asp:Panel ID="AlcancesPopUpDragHandle" runat="server" Style="cursor: move;">
        <table width="100%" cellpadding="0" cellspacing="5">
            <tr class="menutoppopup">
                <td>
                    <th align="center" height="10">
                        <asp:Label ID="headerPopUpAlcances" runat="server" Text="Alcance Geográfico" />
                    </th>
                </td>
            </tr>
        </table>
    </asp:Panel>
    <asp:Panel ID="pnAlcances" DefaultButton="btSaveAlcances" runat="server">
        <asp:UpdatePanel ID="upAlcancesPopUp" runat="server" UpdateMode="Conditional">
            <ContentTemplate>
                <table width="100%">
                    <tr>
                        <td>
                            <table>
                                <td style="width: 62px">
                                    </td>
                                    <td>
                                        <asp:Literal ID="Literal1" Text="Alcance Geográfico:" runat="server"></asp:Literal>
                                    </td>
                                    <td>
                                        <uc:TreeLocalizacion runat="server" ID="tsAlcanceGeografico" SelectOption="OnlySelectedDefined" ShowOption="ActivesAndActualValue"  ></uc:TreeLocalizacion>
                                    </td> 
                            </table>
                        </td>                        
                    </tr>
                </table>
                <table width="100%">
                    <tr>
                        <td align="center">                                
                            <asp:Button ID="btSaveAlcances" Text="Aceptar" OnClick="btSaveAlcance_Click" runat="server" ValidationGroup="vgAlcances" />
                            <asp:Button ID="btNewAlcances" Text="Aceptar y Agregar Nuevo" OnClick="btNewAlcance_Click" runat="server" ValidationGroup="vgAlcances" />
                            <asp:Button ID="btCancelAlcances" Text="Cerrar" OnClick="btCancelAlcance_Click"
                                runat="server" Width="60px" />                                
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </asp:Panel>
    <asp:Button ID="Button3" runat="server" Text="Button" Style="display: none" />
    <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderAlcances" runat="server" CancelControlID="Button3"
        PopupDragHandleControlID="AlcancesPopUpDragHandle" PopupControlID="PopUpAlcances"
        OkControlID="Button3" TargetControlID="Button3" BackgroundCssClass="modalBackground" />
</asp:Panel>


