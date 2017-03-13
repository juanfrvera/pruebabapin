<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ModalidadFinancieraPageList.aspx.cs" Inherits="UI.Web.ModalidadFinancieraPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterModalidadFinanciera" Src="ModalidadFinancieraFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListModalidadFinanciera" Src="ModalidadFinancieraList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditModalidadFinanciera" Src="ModalidadFinancieraEdit.ascx" %>
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
                               <uc:FilterModalidadFinanciera runat="server" ID="ftModalidadFinanciera" ></uc:FilterModalidadFinanciera>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ModalidadFinanciera" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterModalidadFinanciera" ></uc:PaggingButtons ></td>
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
                       <uc:ListModalidadFinanciera runat="server" ID="lstModalidadFinanciera" ></uc:ListModalidadFinanciera >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ModalidadFinanciera-->
            <asp:Panel ID="pnPopUpEditModalidadFinanciera" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditModalidadFinancieraDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ModalidadFinanciera</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditModalidadFinanciera" runat="server">             
                <asp:UpdatePanel ID="upEditModalidadFinanciera" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditModalidadFinancierarunat="server" ID="editModalidadFinanciera" ></uc:EditModalidadFinanciera>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionModalidadFinanciera" runat="server" DisplayMode="BulletList" ValidationGroup="EditionModalidadFinanciera" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnModalidadFinanciera" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditModalidadFinanciera" runat="server" CancelControlID="btPnModalidadFinanciera" 
					PopupDragHandleControlID="pnPopUpEditModalidadFinancieraDragHandle" PopupControlID="pnPopUpEditModalidadFinanciera"
					OkControlID="Button2" TargetControlID="btPnModalidadFinanciera" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ModalidadFinanciera -->            
           </td>
        </tr>
    </table>
</asp:Content>
