<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ClasificacionGeograficaPageList.aspx.cs" Inherits="UI.Web.ClasificacionGeograficaPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterClasificacionGeografica" Src="ClasificacionGeograficaFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListClasificacionGeografica" Src="ClasificacionGeograficaList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditClasificacionGeografica" Src="ClasificacionGeograficaEdit.ascx" %>
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
                            <div>
                               <uc:FilterClasificacionGeografica runat="server" ID="ftClasificacionGeografica" ></uc:FilterClasificacionGeografica>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ClasificacionGeografica" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterClasificacionGeografica" ></uc:PaggingButtons ></td>
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
                       <uc:ListClasificacionGeografica runat="server" ID="lstClasificacionGeografica" ></uc:ListClasificacionGeografica >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ClasificacionGeografica-->
            <asp:Panel ID="pnPopUpEditClasificacionGeografica" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditClasificacionGeograficaDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ClasificacionGeografica</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditClasificacionGeografica" runat="server">             
                <asp:UpdatePanel ID="upEditClasificacionGeografica" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditClasificacionGeograficarunat="server" ID="editClasificacionGeografica" ></uc:EditClasificacionGeografica>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionClasificacionGeografica" runat="server" DisplayMode="BulletList" ValidationGroup="EditionClasificacionGeografica" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnClasificacionGeografica" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditClasificacionGeografica" runat="server" CancelControlID="btPnClasificacionGeografica" 
					PopupDragHandleControlID="pnPopUpEditClasificacionGeograficaDragHandle" PopupControlID="pnPopUpEditClasificacionGeografica"
					OkControlID="Button2" TargetControlID="btPnClasificacionGeografica" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ClasificacionGeografica -->            
           </td>
        </tr>
    </table>
</asp:Content>
