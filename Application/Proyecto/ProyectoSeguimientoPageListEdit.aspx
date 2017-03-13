<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoSeguimientoPageList.aspx.cs" Inherits="UI.Web.ProyectoSeguimientoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProyectoSeguimiento" Src="ProyectoSeguimientoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProyectoSeguimiento" Src="ProyectoSeguimientoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoSeguimiento" Src="ProyectoSeguimientoEdit.ascx" %>
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
                            <div style="padding:15px" >
                               <uc:FilterProyectoSeguimiento runat="server" ID="ftProyectoSeguimiento" ></uc:FilterProyectoSeguimiento>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ProyectoSeguimiento" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProyectoSeguimiento" ></uc:PaggingButtons ></td>
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
                       <uc:ListProyectoSeguimiento runat="server" ID="lstProyectoSeguimiento" ></uc:ListProyectoSeguimiento >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ProyectoSeguimiento-->
            <asp:Panel ID="pnPopUpEditProyectoSeguimiento" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditProyectoSeguimientoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ProyectoSeguimiento</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditProyectoSeguimiento" runat="server">             
                <asp:UpdatePanel ID="upEditProyectoSeguimiento" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditProyectoSeguimientorunat="server" ID="editProyectoSeguimiento" ></uc:EditProyectoSeguimiento>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionProyectoSeguimiento" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoSeguimiento" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnProyectoSeguimiento" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditProyectoSeguimiento" runat="server" CancelControlID="btPnProyectoSeguimiento" 
					PopupDragHandleControlID="pnPopUpEditProyectoSeguimientoDragHandle" PopupControlID="pnPopUpEditProyectoSeguimiento"
					OkControlID="Button2" TargetControlID="btPnProyectoSeguimiento" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ProyectoSeguimiento -->            
           </td>
        </tr>
    </table>
</asp:Content>
