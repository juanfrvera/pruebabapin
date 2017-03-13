<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SistemaEntidadAccionPageList.aspx.cs" Inherits="UI.Web.SistemaEntidadAccionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSistemaEntidadAccion" Src="SistemaEntidadAccionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSistemaEntidadAccion" Src="SistemaEntidadAccionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSistemaEntidadAccion" Src="SistemaEntidadAccionEdit.ascx" %>
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
                               <uc:FilterSistemaEntidadAccion runat="server" ID="ftSistemaEntidadAccion" ></uc:FilterSistemaEntidadAccion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar SistemaEntidadAccion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSistemaEntidadAccion" ></uc:PaggingButtons ></td>
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
                       <uc:ListSistemaEntidadAccion runat="server" ID="lstSistemaEntidadAccion" ></uc:ListSistemaEntidadAccion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT SistemaEntidadAccion-->
            <asp:Panel ID="pnPopUpEditSistemaEntidadAccion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSistemaEntidadAccionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n SistemaEntidadAccion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSistemaEntidadAccion" runat="server">             
                <asp:UpdatePanel ID="upEditSistemaEntidadAccion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSistemaEntidadAccionrunat="server" ID="editSistemaEntidadAccion" ></uc:EditSistemaEntidadAccion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSistemaEntidadAccion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSistemaEntidadAccion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSistemaEntidadAccion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSistemaEntidadAccion" runat="server" CancelControlID="btPnSistemaEntidadAccion" 
					PopupDragHandleControlID="pnPopUpEditSistemaEntidadAccionDragHandle" PopupControlID="pnPopUpEditSistemaEntidadAccion"
					OkControlID="Button2" TargetControlID="btPnSistemaEntidadAccion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT SistemaEntidadAccion -->            
           </td>
        </tr>
    </table>
</asp:Content>
