<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="CaracterEconomicoPageList.aspx.cs" Inherits="UI.Web.CaracterEconomicoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterCaracterEconomico" Src="CaracterEconomicoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListCaracterEconomico" Src="CaracterEconomicoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditCaracterEconomico" Src="CaracterEconomicoEdit.ascx" %>
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
                               <uc:FilterCaracterEconomico runat="server" ID="ftCaracterEconomico" ></uc:FilterCaracterEconomico>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar CaracterEconomico" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterCaracterEconomico" ></uc:PaggingButtons ></td>
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
                       <uc:ListCaracterEconomico runat="server" ID="lstCaracterEconomico" ></uc:ListCaracterEconomico >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT CaracterEconomico-->
            <asp:Panel ID="pnPopUpEditCaracterEconomico" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditCaracterEconomicoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n CaracterEconomico</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditCaracterEconomico" runat="server">             
                <asp:UpdatePanel ID="upEditCaracterEconomico" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditCaracterEconomicorunat="server" ID="editCaracterEconomico" ></uc:EditCaracterEconomico>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionCaracterEconomico" runat="server" DisplayMode="BulletList" ValidationGroup="EditionCaracterEconomico" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnCaracterEconomico" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditCaracterEconomico" runat="server" CancelControlID="btPnCaracterEconomico" 
					PopupDragHandleControlID="pnPopUpEditCaracterEconomicoDragHandle" PopupControlID="pnPopUpEditCaracterEconomico"
					OkControlID="Button2" TargetControlID="btPnCaracterEconomico" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT CaracterEconomico -->            
           </td>
        </tr>
    </table>
</asp:Content>
