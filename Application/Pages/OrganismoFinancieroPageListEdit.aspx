<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="OrganismoFinancieroPageList.aspx.cs" Inherits="UI.Web.OrganismoFinancieroPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterOrganismoFinanciero" Src="OrganismoFinancieroFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListOrganismoFinanciero" Src="OrganismoFinancieroList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditOrganismoFinanciero" Src="OrganismoFinancieroEdit.ascx" %>
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
                            <div style="padding:15px" >
                               <uc:FilterOrganismoFinanciero runat="server" ID="ftOrganismoFinanciero" ></uc:FilterOrganismoFinanciero>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar OrganismoFinanciero" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterOrganismoFinanciero" ></uc:PaggingButtons ></td>
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
                       <uc:ListOrganismoFinanciero runat="server" ID="lstOrganismoFinanciero" ></uc:ListOrganismoFinanciero >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT OrganismoFinanciero-->
            <asp:Panel ID="pnPopUpEditOrganismoFinanciero" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditOrganismoFinancieroDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n OrganismoFinanciero</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditOrganismoFinanciero" runat="server">             
                <asp:UpdatePanel ID="upEditOrganismoFinanciero" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditOrganismoFinancierorunat="server" ID="editOrganismoFinanciero" ></uc:EditOrganismoFinanciero>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionOrganismoFinanciero" runat="server" DisplayMode="BulletList" ValidationGroup="EditionOrganismoFinanciero" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnOrganismoFinanciero" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditOrganismoFinanciero" runat="server" CancelControlID="btPnOrganismoFinanciero" 
					PopupDragHandleControlID="pnPopUpEditOrganismoFinancieroDragHandle" PopupControlID="pnPopUpEditOrganismoFinanciero"
					OkControlID="Button2" TargetControlID="btPnOrganismoFinanciero" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT OrganismoFinanciero -->            
           </td>
        </tr>
    </table>
</asp:Content>
