<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="IndicadorRubroPageList.aspx.cs" Inherits="UI.Web.IndicadorRubroPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterIndicadorRubro" Src="IndicadorRubroFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListIndicadorRubro" Src="IndicadorRubroList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditIndicadorRubro" Src="IndicadorRubroEdit.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListButtons" Src="~/Controls/WebControlListButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="PaggingButtons" Src="~/Controls/WebControlPaggingButtons.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditButtons" Src="~/Controls/WebControlEditionButtons2.ascx" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContenidoPrincipal" runat="server">
    <table width="100%"  >
        <tr>
            <td>
                <asp:UpdatePanel ID="upSearch" runat="server">
                    <ContentTemplate>
					    <asp:Panel runat="server" GroupingText="Filtro de B�squeda"  ID="pnlFilter" >
                            <div style="padding:15px" >
                               <uc:FilterIndicadorRubro runat="server" ID="ftIndicadorRubro" ></uc:FilterIndicadorRubro>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar IndicadorRubro" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterIndicadorRubro" ></uc:PaggingButtons ></td>
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
                       <uc:ListIndicadorRubro runat="server" ID="lstIndicadorRubro" ></uc:ListIndicadorRubro >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT IndicadorRubro-->
            <asp:Panel ID="pnPopUpEditIndicadorRubro" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditIndicadorRubroDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n IndicadorRubro</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditIndicadorRubro" runat="server">             
                <asp:UpdatePanel ID="upEditIndicadorRubro" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditIndicadorRubrorunat="server" ID="editIndicadorRubro" ></uc:EditIndicadorRubro>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionIndicadorRubro" runat="server" DisplayMode="BulletList" ValidationGroup="EditionIndicadorRubro" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnIndicadorRubro" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditIndicadorRubro" runat="server" CancelControlID="btPnIndicadorRubro" 
					PopupDragHandleControlID="pnPopUpEditIndicadorRubroDragHandle" PopupControlID="pnPopUpEditIndicadorRubro"
					OkControlID="Button2" TargetControlID="btPnIndicadorRubro" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT IndicadorRubro -->            
           </td>
        </tr>
    </table>
</asp:Content>
