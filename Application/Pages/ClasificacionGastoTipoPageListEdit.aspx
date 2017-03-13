<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ClasificacionGastoTipoPageList.aspx.cs" Inherits="UI.Web.ClasificacionGastoTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterClasificacionGastoTipo" Src="ClasificacionGastoTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListClasificacionGastoTipo" Src="ClasificacionGastoTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditClasificacionGastoTipo" Src="ClasificacionGastoTipoEdit.ascx" %>
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
                               <uc:FilterClasificacionGastoTipo runat="server" ID="ftClasificacionGastoTipo" ></uc:FilterClasificacionGastoTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ClasificacionGastoTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterClasificacionGastoTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListClasificacionGastoTipo runat="server" ID="lstClasificacionGastoTipo" ></uc:ListClasificacionGastoTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ClasificacionGastoTipo-->
            <asp:Panel ID="pnPopUpEditClasificacionGastoTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditClasificacionGastoTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ClasificacionGastoTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditClasificacionGastoTipo" runat="server">             
                <asp:UpdatePanel ID="upEditClasificacionGastoTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditClasificacionGastoTiporunat="server" ID="editClasificacionGastoTipo" ></uc:EditClasificacionGastoTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionClasificacionGastoTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionClasificacionGastoTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnClasificacionGastoTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditClasificacionGastoTipo" runat="server" CancelControlID="btPnClasificacionGastoTipo" 
					PopupDragHandleControlID="pnPopUpEditClasificacionGastoTipoDragHandle" PopupControlID="pnPopUpEditClasificacionGastoTipo"
					OkControlID="Button2" TargetControlID="btPnClasificacionGastoTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ClasificacionGastoTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
