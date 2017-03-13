<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoGeoreferenciacionPageList.aspx.cs" Inherits="UI.Web.ProyectoGeoreferenciacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProyectoGeoreferenciacion" Src="ProyectoGeoreferenciacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProyectoGeoreferenciacion" Src="ProyectoGeoreferenciacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoGeoreferenciacion" Src="ProyectoGeoreferenciacionEdit.ascx" %>
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
                               <uc:FilterProyectoGeoreferenciacion runat="server" ID="ftProyectoGeoreferenciacion" ></uc:FilterProyectoGeoreferenciacion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ProyectoGeoreferenciacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Está seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProyectoGeoreferenciacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListProyectoGeoreferenciacion runat="server" ID="lstProyectoGeoreferenciacion" ></uc:ListProyectoGeoreferenciacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ProyectoGeoreferenciacion-->
            <asp:Panel ID="pnPopUpEditProyectoGeoreferenciacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditProyectoGeoreferenciacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ProyectoGeoreferenciacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditProyectoGeoreferenciacion" runat="server">             
                <asp:UpdatePanel ID="upEditProyectoGeoreferenciacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditProyectoGeoreferenciacionrunat="server" ID="editProyectoGeoreferenciacion" ></uc:EditProyectoGeoreferenciacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionProyectoGeoreferenciacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoGeoreferenciacion" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnProyectoGeoreferenciacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditProyectoGeoreferenciacion" runat="server" CancelControlID="btPnProyectoGeoreferenciacion" 
					PopupDragHandleControlID="pnPopUpEditProyectoGeoreferenciacionDragHandle" PopupControlID="pnPopUpEditProyectoGeoreferenciacion"
					OkControlID="Button2" TargetControlID="btPnProyectoGeoreferenciacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ProyectoGeoreferenciacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
