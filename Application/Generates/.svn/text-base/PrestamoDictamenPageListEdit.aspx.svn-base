<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PrestamoDictamenPageList.aspx.cs" Inherits="UI.Web.PrestamoDictamenPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterPrestamoDictamen" Src="PrestamoDictamenFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListPrestamoDictamen" Src="PrestamoDictamenList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditPrestamoDictamen" Src="PrestamoDictamenEdit.ascx" %>
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
                            <div >
                               <uc:FilterPrestamoDictamen runat="server" ID="ftPrestamoDictamen" ></uc:FilterPrestamoDictamen>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar PrestamoDictamen" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Esta seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterPrestamoDictamen" ></uc:PaggingButtons ></td>
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
                       <uc:ListPrestamoDictamen runat="server" ID="lstPrestamoDictamen" ></uc:ListPrestamoDictamen >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT PrestamoDictamen-->
            <asp:Panel ID="pnPopUpEditPrestamoDictamen" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditPrestamoDictamenDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n PrestamoDictamen</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditPrestamoDictamen" runat="server">             
                <asp:UpdatePanel ID="upEditPrestamoDictamen" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditPrestamoDictamenrunat="server" ID="editPrestamoDictamen" ></uc:EditPrestamoDictamen>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionPrestamoDictamen" runat="server" DisplayMode="BulletList" ValidationGroup="EditionPrestamoDictamen" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnPrestamoDictamen" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditPrestamoDictamen" runat="server" CancelControlID="btPnPrestamoDictamen" 
					PopupDragHandleControlID="pnPopUpEditPrestamoDictamenDragHandle" PopupControlID="pnPopUpEditPrestamoDictamen"
					OkControlID="Button2" TargetControlID="btPnPrestamoDictamen" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT PrestamoDictamen -->            
           </td>
        </tr>
    </table>
</asp:Content>
