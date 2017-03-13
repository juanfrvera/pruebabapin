<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="AuditSessionPageList.aspx.cs" Inherits="UI.Web.AuditSessionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterAuditSession" Src="AuditSessionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListAuditSession" Src="AuditSessionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditAuditSession" Src="AuditSessionEdit.ascx" %>
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
                               <uc:FilterAuditSession runat="server" ID="ftAuditSession" ></uc:FilterAuditSession>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar AuditSession" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterAuditSession" ></uc:PaggingButtons ></td>
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
                       <uc:ListAuditSession runat="server" ID="lstAuditSession" ></uc:ListAuditSession >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT AuditSession-->
            <asp:Panel ID="pnPopUpEditAuditSession" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditAuditSessionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n AuditSession</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditAuditSession" runat="server">             
                <asp:UpdatePanel ID="upEditAuditSession" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditAuditSessionrunat="server" ID="editAuditSession" ></uc:EditAuditSession>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionAuditSession" runat="server" DisplayMode="BulletList" ValidationGroup="EditionAuditSession" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnAuditSession" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditAuditSession" runat="server" CancelControlID="btPnAuditSession" 
					PopupDragHandleControlID="pnPopUpEditAuditSessionDragHandle" PopupControlID="pnPopUpEditAuditSession"
					OkControlID="Button2" TargetControlID="btPnAuditSession" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT AuditSession -->            
           </td>
        </tr>
    </table>
</asp:Content>
