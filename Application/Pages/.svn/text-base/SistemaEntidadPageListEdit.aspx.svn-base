<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SistemaEntidadPageList.aspx.cs" Inherits="UI.Web.SistemaEntidadPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSistemaEntidad" Src="SistemaEntidadFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSistemaEntidad" Src="SistemaEntidadList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSistemaEntidad" Src="SistemaEntidadEdit.ascx" %>
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
                               <uc:FilterSistemaEntidad runat="server" ID="ftSistemaEntidad" ></uc:FilterSistemaEntidad>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar SistemaEntidad" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSistemaEntidad" ></uc:PaggingButtons ></td>
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
                       <uc:ListSistemaEntidad runat="server" ID="lstSistemaEntidad" ></uc:ListSistemaEntidad >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT SistemaEntidad-->
            <asp:Panel ID="pnPopUpEditSistemaEntidad" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSistemaEntidadDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n SistemaEntidad</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSistemaEntidad" runat="server">             
                <asp:UpdatePanel ID="upEditSistemaEntidad" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSistemaEntidadrunat="server" ID="editSistemaEntidad" ></uc:EditSistemaEntidad>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSistemaEntidad" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSistemaEntidad" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSistemaEntidad" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSistemaEntidad" runat="server" CancelControlID="btPnSistemaEntidad" 
					PopupDragHandleControlID="pnPopUpEditSistemaEntidadDragHandle" PopupControlID="pnPopUpEditSistemaEntidad"
					OkControlID="Button2" TargetControlID="btPnSistemaEntidad" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT SistemaEntidad -->            
           </td>
        </tr>
    </table>
</asp:Content>
