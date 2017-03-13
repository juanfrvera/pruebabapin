<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SafPageList.aspx.cs" Inherits="UI.Web.SafPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSaf" Src="SafFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSaf" Src="SafList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSaf" Src="SafEdit.ascx" %>
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
                               <uc:FilterSaf runat="server" ID="ftSaf" ></uc:FilterSaf>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar Saf" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSaf" ></uc:PaggingButtons ></td>
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
                       <uc:ListSaf runat="server" ID="lstSaf" ></uc:ListSaf >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT Saf-->
            <asp:Panel ID="pnPopUpEditSaf" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSafDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n Saf</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSaf" runat="server">             
                <asp:UpdatePanel ID="upEditSaf" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSafrunat="server" ID="editSaf" ></uc:EditSaf>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSaf" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSaf" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSaf" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSaf" runat="server" CancelControlID="btPnSaf" 
					PopupDragHandleControlID="pnPopUpEditSafDragHandle" PopupControlID="pnPopUpEditSaf"
					OkControlID="Button2" TargetControlID="btPnSaf" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT Saf -->            
           </td>
        </tr>
    </table>
</asp:Content>
