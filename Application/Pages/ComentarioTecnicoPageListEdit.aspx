<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ComentarioTecnicoPageList.aspx.cs" Inherits="UI.Web.ComentarioTecnicoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterComentarioTecnico" Src="ComentarioTecnicoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListComentarioTecnico" Src="ComentarioTecnicoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditComentarioTecnico" Src="ComentarioTecnicoEdit.ascx" %>
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
                            <div >
                               <uc:FilterComentarioTecnico runat="server" ID="ftComentarioTecnico" ></uc:FilterComentarioTecnico>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ComentarioTecnico" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterComentarioTecnico" ></uc:PaggingButtons ></td>
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
                       <uc:ListComentarioTecnico runat="server" ID="lstComentarioTecnico" ></uc:ListComentarioTecnico >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ComentarioTecnico-->
            <asp:Panel ID="pnPopUpEditComentarioTecnico" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditComentarioTecnicoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ComentarioTecnico</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditComentarioTecnico" runat="server">             
                <asp:UpdatePanel ID="upEditComentarioTecnico" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditComentarioTecnicorunat="server" ID="editComentarioTecnico" ></uc:EditComentarioTecnico>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionComentarioTecnico" runat="server" DisplayMode="BulletList" ValidationGroup="EditionComentarioTecnico" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnComentarioTecnico" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditComentarioTecnico" runat="server" CancelControlID="btPnComentarioTecnico" 
					PopupDragHandleControlID="pnPopUpEditComentarioTecnicoDragHandle" PopupControlID="pnPopUpEditComentarioTecnico"
					OkControlID="Button2" TargetControlID="btPnComentarioTecnico" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ComentarioTecnico -->            
           </td>
        </tr>
    </table>
</asp:Content>
