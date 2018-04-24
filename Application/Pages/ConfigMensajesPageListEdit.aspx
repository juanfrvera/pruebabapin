<%@ Page Language="C#" AutoEventWireup="true" MasterPageFile="~/App_Shared/General.Master" CodeBehind="ConfigMensajesPageListEdit.aspx.cs" Inherits="UI.Web.ConfigMensajesPageListEdit" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterConfigMensajes" Src="ConfigMensajesFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListConfigMensajes" Src="ConfigMensajesList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditConfigMensajes" Src="ConfigMensajesEdit.ascx" %>
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
                               <uc:FilterConfigMensajes runat="server" ID="ftConfigMensajes" ></uc:FilterConfigMensajes>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar Estado"/> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver"/> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>'/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterEstado" ></uc:PaggingButtons ></td>
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
                       <uc:ListConfigMensajes runat="server" ID="lstEstado" ></uc:ListConfigMensajes>
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT Configuracion de Mensajes-->
            <asp:Panel ID="pnPopUpEditConfigMensajes" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditConfigMensajesDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n Configuración de Mensajes</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditConfigMensajes" runat="server">             
                <asp:UpdatePanel ID="upEditConfigMensajes" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditConfigMensajes runat="server" ID="editConfigMensajes" ></uc:EditConfigMensajes>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionConfigMensajes" runat="server" DisplayMode="BulletList" ValidationGroup="EditionConfigMensajes" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnConfigMensajes" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditConfigMensajes" runat="server" CancelControlID="btPnConfigMensajes" 
					PopupDragHandleControlID="pnPopUpEditConfigMensajesDragHandle" PopupControlID="pnPopUpEditConfigMensajes"
					OkControlID="Button2" TargetControlID="btPnConfigMensajes" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT Configuracion de Mensajes -->            
           </td>
        </tr>
    </table>
</asp:Content>>
