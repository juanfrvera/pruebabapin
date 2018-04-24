<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoComentarioTecnicoPageList.aspx.cs" Inherits="UI.Web.ProyectoComentarioTecnicoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProyectoComentarioTecnico" Src="ProyectoComentarioTecnicoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProyectoComentarioTecnico" Src="ProyectoComentarioTecnicoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoComentarioTecnico" Src="ProyectoComentarioTecnicoEdit.ascx" %>
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
                               <uc:FilterProyectoComentarioTecnico runat="server" ID="ftProyectoComentarioTecnico" ></uc:FilterProyectoComentarioTecnico>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ProyectoComentarioTecnico" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProyectoComentarioTecnico" ></uc:PaggingButtons ></td>
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
                       <uc:ListProyectoComentarioTecnico runat="server" ID="lstProyectoComentarioTecnico" ></uc:ListProyectoComentarioTecnico >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ProyectoComentarioTecnico-->
            <asp:Panel ID="pnPopUpEditProyectoComentarioTecnico" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditProyectoComentarioTecnicoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ProyectoComentarioTecnico</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditProyectoComentarioTecnico" runat="server">             
                <asp:UpdatePanel ID="upEditProyectoComentarioTecnico" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditProyectoComentarioTecnicorunat="server" ID="editProyectoComentarioTecnico" ></uc:EditProyectoComentarioTecnico>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionProyectoComentarioTecnico" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoComentarioTecnico" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnProyectoComentarioTecnico" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditProyectoComentarioTecnico" runat="server" CancelControlID="btPnProyectoComentarioTecnico" 
					PopupDragHandleControlID="pnPopUpEditProyectoComentarioTecnicoDragHandle" PopupControlID="pnPopUpEditProyectoComentarioTecnico"
					OkControlID="Button2" TargetControlID="btPnProyectoComentarioTecnico" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ProyectoComentarioTecnico -->            
           </td>
        </tr>
    </table>
</asp:Content>
