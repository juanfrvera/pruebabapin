<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="FinalidadFuncionTipoPageList.aspx.cs" Inherits="UI.Web.FinalidadFuncionTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterFinalidadFuncionTipo" Src="FinalidadFuncionTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListFinalidadFuncionTipo" Src="FinalidadFuncionTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditFinalidadFuncionTipo" Src="FinalidadFuncionTipoEdit.ascx" %>
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
                               <uc:FilterFinalidadFuncionTipo runat="server" ID="ftFinalidadFuncionTipo" ></uc:FilterFinalidadFuncionTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar FinalidadFuncionTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterFinalidadFuncionTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListFinalidadFuncionTipo runat="server" ID="lstFinalidadFuncionTipo" ></uc:ListFinalidadFuncionTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT FinalidadFuncionTipo-->
            <asp:Panel ID="pnPopUpEditFinalidadFuncionTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditFinalidadFuncionTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n FinalidadFuncionTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditFinalidadFuncionTipo" runat="server">             
                <asp:UpdatePanel ID="upEditFinalidadFuncionTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditFinalidadFuncionTiporunat="server" ID="editFinalidadFuncionTipo" ></uc:EditFinalidadFuncionTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionFinalidadFuncionTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionFinalidadFuncionTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnFinalidadFuncionTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditFinalidadFuncionTipo" runat="server" CancelControlID="btPnFinalidadFuncionTipo" 
					PopupDragHandleControlID="pnPopUpEditFinalidadFuncionTipoDragHandle" PopupControlID="pnPopUpEditFinalidadFuncionTipo"
					OkControlID="Button2" TargetControlID="btPnFinalidadFuncionTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT FinalidadFuncionTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
