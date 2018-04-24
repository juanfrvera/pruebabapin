<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="FuenteFinanciamientoTipoPageList.aspx.cs" Inherits="UI.Web.FuenteFinanciamientoTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterFuenteFinanciamientoTipo" Src="FuenteFinanciamientoTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListFuenteFinanciamientoTipo" Src="FuenteFinanciamientoTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditFuenteFinanciamientoTipo" Src="FuenteFinanciamientoTipoEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de Búsqueda"  ID="pnlFilter" >
                            <div>
                               <uc:FilterFuenteFinanciamientoTipo runat="server" ID="ftFuenteFinanciamientoTipo" ></uc:FilterFuenteFinanciamientoTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar FuenteFinanciamientoTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterFuenteFinanciamientoTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListFuenteFinanciamientoTipo runat="server" ID="lstFuenteFinanciamientoTipo" ></uc:ListFuenteFinanciamientoTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT FuenteFinanciamientoTipo-->
            <asp:Panel ID="pnPopUpEditFuenteFinanciamientoTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditFuenteFinanciamientoTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n FuenteFinanciamientoTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditFuenteFinanciamientoTipo" runat="server">             
                <asp:UpdatePanel ID="upEditFuenteFinanciamientoTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditFuenteFinanciamientoTiporunat="server" ID="editFuenteFinanciamientoTipo" ></uc:EditFuenteFinanciamientoTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionFuenteFinanciamientoTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionFuenteFinanciamientoTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnFuenteFinanciamientoTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditFuenteFinanciamientoTipo" runat="server" CancelControlID="btPnFuenteFinanciamientoTipo" 
					PopupDragHandleControlID="pnPopUpEditFuenteFinanciamientoTipoDragHandle" PopupControlID="pnPopUpEditFuenteFinanciamientoTipo"
					OkControlID="Button2" TargetControlID="btPnFuenteFinanciamientoTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT FuenteFinanciamientoTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
