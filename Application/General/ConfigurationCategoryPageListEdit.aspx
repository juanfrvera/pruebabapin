<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ConfigurationCategoryPageList.aspx.cs" Inherits="UI.Web.ConfigurationCategoryPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterConfigurationCategory" Src="ConfigurationCategoryFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListConfigurationCategory" Src="ConfigurationCategoryList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditConfigurationCategory" Src="ConfigurationCategoryEdit.ascx" %>
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
                               <uc:FilterConfigurationCategory runat="server" ID="ftConfigurationCategory" ></uc:FilterConfigurationCategory>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ConfigurationCategory" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterConfigurationCategory" ></uc:PaggingButtons ></td>
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
                       <uc:ListConfigurationCategory runat="server" ID="lstConfigurationCategory" ></uc:ListConfigurationCategory >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ConfigurationCategory-->
            <asp:Panel ID="pnPopUpEditConfigurationCategory" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditConfigurationCategoryDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ConfigurationCategory</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditConfigurationCategory" runat="server">             
                <asp:UpdatePanel ID="upEditConfigurationCategory" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditConfigurationCategoryrunat="server" ID="editConfigurationCategory" ></uc:EditConfigurationCategory>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionConfigurationCategory" runat="server" DisplayMode="BulletList" ValidationGroup="EditionConfigurationCategory" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnConfigurationCategory" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditConfigurationCategory" runat="server" CancelControlID="btPnConfigurationCategory" 
					PopupDragHandleControlID="pnPopUpEditConfigurationCategoryDragHandle" PopupControlID="pnPopUpEditConfigurationCategory"
					OkControlID="Button2" TargetControlID="btPnConfigurationCategory" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ConfigurationCategory -->            
           </td>
        </tr>
    </table>
</asp:Content>
