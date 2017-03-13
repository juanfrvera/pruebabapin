<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ConfigurationPageList.aspx.cs" Inherits="UI.Web.ConfigurationPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterConfiguration" Src="ConfigurationFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListConfiguration" Src="ConfigurationList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditConfiguration" Src="ConfigurationEdit.ascx" %>
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
                               <uc:FilterConfiguration runat="server" ID="ftConfiguration" ></uc:FilterConfiguration>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar Configuration" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterConfiguration" ></uc:PaggingButtons ></td>
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
                       <uc:ListConfiguration runat="server" ID="lstConfiguration" ></uc:ListConfiguration >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT Configuration-->
            <asp:Panel ID="pnPopUpEditConfiguration" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditConfigurationDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n Configuration</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditConfiguration" runat="server">             
                <asp:UpdatePanel ID="upEditConfiguration" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditConfigurationrunat="server" ID="editConfiguration" ></uc:EditConfiguration>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionConfiguration" runat="server" DisplayMode="BulletList" ValidationGroup="EditionConfiguration" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnConfiguration" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditConfiguration" runat="server" CancelControlID="btPnConfiguration" 
					PopupDragHandleControlID="pnPopUpEditConfigurationDragHandle" PopupControlID="pnPopUpEditConfiguration"
					OkControlID="Button2" TargetControlID="btPnConfiguration" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT Configuration -->            
           </td>
        </tr>
    </table>
</asp:Content>
