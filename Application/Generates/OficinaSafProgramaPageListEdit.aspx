<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="OficinaSafProgramaPageList.aspx.cs" Inherits="UI.Web.OficinaSafProgramaPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterOficinaSafPrograma" Src="OficinaSafProgramaFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListOficinaSafPrograma" Src="OficinaSafProgramaList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditOficinaSafPrograma" Src="OficinaSafProgramaEdit.ascx" %>
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
                               <uc:FilterOficinaSafPrograma runat="server" ID="ftOficinaSafPrograma" ></uc:FilterOficinaSafPrograma>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar OficinaSafPrograma" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Esta seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterOficinaSafPrograma" ></uc:PaggingButtons ></td>
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
                       <uc:ListOficinaSafPrograma runat="server" ID="lstOficinaSafPrograma" ></uc:ListOficinaSafPrograma >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT OficinaSafPrograma-->
            <asp:Panel ID="pnPopUpEditOficinaSafPrograma" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditOficinaSafProgramaDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n OficinaSafPrograma</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditOficinaSafPrograma" runat="server">             
                <asp:UpdatePanel ID="upEditOficinaSafPrograma" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditOficinaSafProgramarunat="server" ID="editOficinaSafPrograma" ></uc:EditOficinaSafPrograma>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionOficinaSafPrograma" runat="server" DisplayMode="BulletList" ValidationGroup="EditionOficinaSafPrograma" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnOficinaSafPrograma" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditOficinaSafPrograma" runat="server" CancelControlID="btPnOficinaSafPrograma" 
					PopupDragHandleControlID="pnPopUpEditOficinaSafProgramaDragHandle" PopupControlID="pnPopUpEditOficinaSafPrograma"
					OkControlID="Button2" TargetControlID="btPnOficinaSafPrograma" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT OficinaSafPrograma -->            
           </td>
        </tr>
    </table>
</asp:Content>
