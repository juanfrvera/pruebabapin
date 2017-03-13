<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SistemaEntidadEstadoPageList.aspx.cs" Inherits="UI.Web.SistemaEntidadEstadoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSistemaEntidadEstado" Src="SistemaEntidadEstadoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSistemaEntidadEstado" Src="SistemaEntidadEstadoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSistemaEntidadEstado" Src="SistemaEntidadEstadoEdit.ascx" %>
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
                               <uc:FilterSistemaEntidadEstado runat="server" ID="ftSistemaEntidadEstado" ></uc:FilterSistemaEntidadEstado>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar SistemaEntidadEstado" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSistemaEntidadEstado" ></uc:PaggingButtons ></td>
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
                       <uc:ListSistemaEntidadEstado runat="server" ID="lstSistemaEntidadEstado" ></uc:ListSistemaEntidadEstado >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT SistemaEntidadEstado-->
            <asp:Panel ID="pnPopUpEditSistemaEntidadEstado" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSistemaEntidadEstadoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n SistemaEntidadEstado</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSistemaEntidadEstado" runat="server">             
                <asp:UpdatePanel ID="upEditSistemaEntidadEstado" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSistemaEntidadEstadorunat="server" ID="editSistemaEntidadEstado" ></uc:EditSistemaEntidadEstado>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSistemaEntidadEstado" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSistemaEntidadEstado" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSistemaEntidadEstado" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSistemaEntidadEstado" runat="server" CancelControlID="btPnSistemaEntidadEstado" 
					PopupDragHandleControlID="pnPopUpEditSistemaEntidadEstadoDragHandle" PopupControlID="pnPopUpEditSistemaEntidadEstado"
					OkControlID="Button2" TargetControlID="btPnSistemaEntidadEstado" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT SistemaEntidadEstado -->            
           </td>
        </tr>
    </table>
</asp:Content>
