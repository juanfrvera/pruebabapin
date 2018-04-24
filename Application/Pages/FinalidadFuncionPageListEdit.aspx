<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="FinalidadFuncionPageList.aspx.cs" Inherits="UI.Web.FinalidadFuncionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterFinalidadFuncion" Src="FinalidadFuncionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListFinalidadFuncion" Src="FinalidadFuncionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditFinalidadFuncion" Src="FinalidadFuncionEdit.ascx" %>
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
                            <div>
                               <uc:FilterFinalidadFuncion runat="server" ID="ftFinalidadFuncion" ></uc:FilterFinalidadFuncion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar FinalidadFuncion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterFinalidadFuncion" ></uc:PaggingButtons ></td>
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
                       <uc:ListFinalidadFuncion runat="server" ID="lstFinalidadFuncion" ></uc:ListFinalidadFuncion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT FinalidadFuncion-->
            <asp:Panel ID="pnPopUpEditFinalidadFuncion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditFinalidadFuncionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n FinalidadFuncion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditFinalidadFuncion" runat="server">             
                <asp:UpdatePanel ID="upEditFinalidadFuncion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditFinalidadFuncionrunat="server" ID="editFinalidadFuncion" ></uc:EditFinalidadFuncion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionFinalidadFuncion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionFinalidadFuncion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnFinalidadFuncion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditFinalidadFuncion" runat="server" CancelControlID="btPnFinalidadFuncion" 
					PopupDragHandleControlID="pnPopUpEditFinalidadFuncionDragHandle" PopupControlID="pnPopUpEditFinalidadFuncion"
					OkControlID="Button2" TargetControlID="btPnFinalidadFuncion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT FinalidadFuncion -->            
           </td>
        </tr>
    </table>
</asp:Content>
