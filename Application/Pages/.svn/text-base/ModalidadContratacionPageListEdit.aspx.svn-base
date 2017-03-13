<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ModalidadContratacionPageList.aspx.cs" Inherits="UI.Web.ModalidadContratacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterModalidadContratacion" Src="ModalidadContratacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListModalidadContratacion" Src="ModalidadContratacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditModalidadContratacion" Src="ModalidadContratacionEdit.ascx" %>
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
                               <uc:FilterModalidadContratacion runat="server" ID="ftModalidadContratacion" ></uc:FilterModalidadContratacion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ModalidadContratacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterModalidadContratacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListModalidadContratacion runat="server" ID="lstModalidadContratacion" ></uc:ListModalidadContratacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ModalidadContratacion-->
            <asp:Panel ID="pnPopUpEditModalidadContratacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditModalidadContratacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ModalidadContratacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditModalidadContratacion" runat="server">             
                <asp:UpdatePanel ID="upEditModalidadContratacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditModalidadContratacionrunat="server" ID="editModalidadContratacion" ></uc:EditModalidadContratacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionModalidadContratacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionModalidadContratacion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnModalidadContratacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditModalidadContratacion" runat="server" CancelControlID="btPnModalidadContratacion" 
					PopupDragHandleControlID="pnPopUpEditModalidadContratacionDragHandle" PopupControlID="pnPopUpEditModalidadContratacion"
					OkControlID="Button2" TargetControlID="btPnModalidadContratacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ModalidadContratacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
