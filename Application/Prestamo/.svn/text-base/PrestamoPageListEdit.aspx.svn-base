<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PrestamoPageList.aspx.cs" Inherits="UI.Web.PrestamoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterPrestamo" Src="PrestamoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListPrestamo" Src="PrestamoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditPrestamo" Src="PrestamoEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro"  ID="pnlFilter" >
                            <div style="padding:15px" >
                               <uc:FilterPrestamo runat="server" ID="ftPrestamo" ></uc:FilterPrestamo>
						    </div>
                        </asp:Panel>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		<tr>
            <td>
                <asp:UpdatePanel ID="upListButtons" runat="server">
                    <ContentTemplate>
                      <table width="100%">
                        <tr>
                            <td align="left">
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar Prestamo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterPrestamo" ></uc:PaggingButtons ></td>
                        </tr>
                      </table>                       
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>		
		<tr>
            <td>
                <asp:UpdatePanel ID="upGrilla" runat="server">
                    <ContentTemplate>
                       <uc:ListPrestamo runat="server" ID="lstPrestamo" ></uc:ListPrestamo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT Prestamo-->
            <asp:Panel ID="pnPopUpEditPrestamo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditPrestamoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n Prestamo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditPrestamo" runat="server">             
                <asp:UpdatePanel ID="upEditPrestamo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditPrestamorunat="server" ID="editPrestamo" ></uc:EditPrestamo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionPrestamo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionPrestamo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnPrestamo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditPrestamo" runat="server" CancelControlID="btPnPrestamo" 
					PopupDragHandleControlID="pnPopUpEditPrestamoDragHandle" PopupControlID="pnPopUpEditPrestamo"
					OkControlID="Button2" TargetControlID="btPnPrestamo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT Prestamo -->            
           </td>
        </tr>
    </table>
</asp:Content>
