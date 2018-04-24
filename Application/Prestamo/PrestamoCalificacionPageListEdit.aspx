<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PrestamoCalificacionPageList.aspx.cs" Inherits="UI.Web.PrestamoCalificacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterPrestamoCalificacion" Src="PrestamoCalificacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListPrestamoCalificacion" Src="PrestamoCalificacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditPrestamoCalificacion" Src="PrestamoCalificacionEdit.ascx" %>
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
                               <uc:FilterPrestamoCalificacion runat="server" ID="ftPrestamoCalificacion" ></uc:FilterPrestamoCalificacion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar PrestamoCalificacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterPrestamoCalificacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListPrestamoCalificacion runat="server" ID="lstPrestamoCalificacion" ></uc:ListPrestamoCalificacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT PrestamoCalificacion-->
            <asp:Panel ID="pnPopUpEditPrestamoCalificacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditPrestamoCalificacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n PrestamoCalificacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditPrestamoCalificacion" runat="server">             
                <asp:UpdatePanel ID="upEditPrestamoCalificacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditPrestamoCalificacionrunat="server" ID="editPrestamoCalificacion" ></uc:EditPrestamoCalificacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionPrestamoCalificacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionPrestamoCalificacion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnPrestamoCalificacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditPrestamoCalificacion" runat="server" CancelControlID="btPnPrestamoCalificacion" 
					PopupDragHandleControlID="pnPopUpEditPrestamoCalificacionDragHandle" PopupControlID="pnPopUpEditPrestamoCalificacion"
					OkControlID="Button2" TargetControlID="btPnPrestamoCalificacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT PrestamoCalificacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
