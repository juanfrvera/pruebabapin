<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="TextLanguagePageList.aspx.cs" Inherits="UI.Web.TextLanguagePageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterTextLanguage" Src="TextLanguageFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListTextLanguage" Src="TextLanguageList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditTextLanguage" Src="TextLanguageEdit.ascx" %>
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
                               <uc:FilterTextLanguage runat="server" ID="ftTextLanguage" ></uc:FilterTextLanguage>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar TextLanguage" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterTextLanguage" ></uc:PaggingButtons ></td>
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
                       <uc:ListTextLanguage runat="server" ID="lstTextLanguage" ></uc:ListTextLanguage >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT TextLanguage-->
            <asp:Panel ID="pnPopUpEditTextLanguage" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditTextLanguageDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n TextLanguage</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditTextLanguage" runat="server">             
                <asp:UpdatePanel ID="upEditTextLanguage" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditTextLanguagerunat="server" ID="editTextLanguage" ></uc:EditTextLanguage>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionTextLanguage" runat="server" DisplayMode="BulletList" ValidationGroup="EditionTextLanguage" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnTextLanguage" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditTextLanguage" runat="server" CancelControlID="btPnTextLanguage" 
					PopupDragHandleControlID="pnPopUpEditTextLanguageDragHandle" PopupControlID="pnPopUpEditTextLanguage"
					OkControlID="Button2" TargetControlID="btPnTextLanguage" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT TextLanguage -->            
           </td>
        </tr>
    </table>
</asp:Content>
