<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="UnidadMedidaPageList.aspx.cs" Inherits="UI.Web.UnidadMedidaPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterUnidadMedida" Src="UnidadMedidaFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListUnidadMedida" Src="UnidadMedidaList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditUnidadMedida" Src="UnidadMedidaEdit.ascx" %>
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
                               <uc:FilterUnidadMedida runat="server" ID="ftUnidadMedida" ></uc:FilterUnidadMedida>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar UnidadMedida" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterUnidadMedida" ></uc:PaggingButtons ></td>
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
                       <uc:ListUnidadMedida runat="server" ID="lstUnidadMedida" ></uc:ListUnidadMedida >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT UnidadMedida-->
            <asp:Panel ID="pnPopUpEditUnidadMedida" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditUnidadMedidaDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n UnidadMedida</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditUnidadMedida" runat="server">             
                <asp:UpdatePanel ID="upEditUnidadMedida" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditUnidadMedidarunat="server" ID="editUnidadMedida" ></uc:EditUnidadMedida>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionUnidadMedida" runat="server" DisplayMode="BulletList" ValidationGroup="EditionUnidadMedida" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnUnidadMedida" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditUnidadMedida" runat="server" CancelControlID="btPnUnidadMedida" 
					PopupDragHandleControlID="pnPopUpEditUnidadMedidaDragHandle" PopupControlID="pnPopUpEditUnidadMedida"
					OkControlID="Button2" TargetControlID="btPnUnidadMedida" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT UnidadMedida -->            
           </td>
        </tr>
    </table>
</asp:Content>
