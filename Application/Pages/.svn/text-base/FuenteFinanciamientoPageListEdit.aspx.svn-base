<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="FuenteFinanciamientoPageList.aspx.cs" Inherits="UI.Web.FuenteFinanciamientoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterFuenteFinanciamiento" Src="FuenteFinanciamientoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListFuenteFinanciamiento" Src="FuenteFinanciamientoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditFuenteFinanciamiento" Src="FuenteFinanciamientoEdit.ascx" %>
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
                            <div>
                               <uc:FilterFuenteFinanciamiento runat="server" ID="ftFuenteFinanciamiento" ></uc:FilterFuenteFinanciamiento>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar FuenteFinanciamiento" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterFuenteFinanciamiento" ></uc:PaggingButtons ></td>
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
                       <uc:ListFuenteFinanciamiento runat="server" ID="lstFuenteFinanciamiento" ></uc:ListFuenteFinanciamiento >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT FuenteFinanciamiento-->
            <asp:Panel ID="pnPopUpEditFuenteFinanciamiento" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditFuenteFinanciamientoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n FuenteFinanciamiento</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditFuenteFinanciamiento" runat="server">             
                <asp:UpdatePanel ID="upEditFuenteFinanciamiento" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditFuenteFinanciamientorunat="server" ID="editFuenteFinanciamiento" ></uc:EditFuenteFinanciamiento>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionFuenteFinanciamiento" runat="server" DisplayMode="BulletList" ValidationGroup="EditionFuenteFinanciamiento" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnFuenteFinanciamiento" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditFuenteFinanciamiento" runat="server" CancelControlID="btPnFuenteFinanciamiento" 
					PopupDragHandleControlID="pnPopUpEditFuenteFinanciamientoDragHandle" PopupControlID="pnPopUpEditFuenteFinanciamiento"
					OkControlID="Button2" TargetControlID="btPnFuenteFinanciamiento" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT FuenteFinanciamiento -->            
           </td>
        </tr>
    </table>
</asp:Content>
