<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ClasificacionGeograficaTipoPageList.aspx.cs" Inherits="UI.Web.ClasificacionGeograficaTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterClasificacionGeograficaTipo" Src="ClasificacionGeograficaTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListClasificacionGeograficaTipo" Src="ClasificacionGeograficaTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditClasificacionGeograficaTipo" Src="ClasificacionGeograficaTipoEdit.ascx" %>
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
                               <uc:FilterClasificacionGeograficaTipo runat="server" ID="ftClasificacionGeograficaTipo" ></uc:FilterClasificacionGeograficaTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ClasificacionGeograficaTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterClasificacionGeograficaTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListClasificacionGeograficaTipo runat="server" ID="lstClasificacionGeograficaTipo" ></uc:ListClasificacionGeograficaTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ClasificacionGeograficaTipo-->
            <asp:Panel ID="pnPopUpEditClasificacionGeograficaTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditClasificacionGeograficaTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ClasificacionGeograficaTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditClasificacionGeograficaTipo" runat="server">             
                <asp:UpdatePanel ID="upEditClasificacionGeograficaTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditClasificacionGeograficaTiporunat="server" ID="editClasificacionGeograficaTipo" ></uc:EditClasificacionGeograficaTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionClasificacionGeograficaTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionClasificacionGeograficaTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnClasificacionGeograficaTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditClasificacionGeograficaTipo" runat="server" CancelControlID="btPnClasificacionGeograficaTipo" 
					PopupDragHandleControlID="pnPopUpEditClasificacionGeograficaTipoDragHandle" PopupControlID="pnPopUpEditClasificacionGeograficaTipo"
					OkControlID="Button2" TargetControlID="btPnClasificacionGeograficaTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ClasificacionGeograficaTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
