<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="CaracterEconomicoTipoPageList.aspx.cs" Inherits="UI.Web.CaracterEconomicoTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterCaracterEconomicoTipo" Src="CaracterEconomicoTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListCaracterEconomicoTipo" Src="CaracterEconomicoTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditCaracterEconomicoTipo" Src="CaracterEconomicoTipoEdit.ascx" %>
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
                               <uc:FilterCaracterEconomicoTipo runat="server" ID="ftCaracterEconomicoTipo" ></uc:FilterCaracterEconomicoTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar CaracterEconomicoTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterCaracterEconomicoTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListCaracterEconomicoTipo runat="server" ID="lstCaracterEconomicoTipo" ></uc:ListCaracterEconomicoTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT CaracterEconomicoTipo-->
            <asp:Panel ID="pnPopUpEditCaracterEconomicoTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditCaracterEconomicoTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n CaracterEconomicoTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditCaracterEconomicoTipo" runat="server">             
                <asp:UpdatePanel ID="upEditCaracterEconomicoTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditCaracterEconomicoTiporunat="server" ID="editCaracterEconomicoTipo" ></uc:EditCaracterEconomicoTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionCaracterEconomicoTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionCaracterEconomicoTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnCaracterEconomicoTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditCaracterEconomicoTipo" runat="server" CancelControlID="btPnCaracterEconomicoTipo" 
					PopupDragHandleControlID="pnPopUpEditCaracterEconomicoTipoDragHandle" PopupControlID="pnPopUpEditCaracterEconomicoTipo"
					OkControlID="Button2" TargetControlID="btPnCaracterEconomicoTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT CaracterEconomicoTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
