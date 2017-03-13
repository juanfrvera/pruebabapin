<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProyectoCalificacionPageList.aspx.cs" Inherits="UI.Web.ProyectoCalificacionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProyectoCalificacion" Src="ProyectoCalificacionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProyectoCalificacion" Src="ProyectoCalificacionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditProyectoCalificacion" Src="ProyectoCalificacionEdit.ascx" %>
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
                               <uc:FilterProyectoCalificacion runat="server" ID="ftProyectoCalificacion" ></uc:FilterProyectoCalificacion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ProyectoCalificacion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProyectoCalificacion" ></uc:PaggingButtons ></td>
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
                       <uc:ListProyectoCalificacion runat="server" ID="lstProyectoCalificacion" ></uc:ListProyectoCalificacion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ProyectoCalificacion-->
            <asp:Panel ID="pnPopUpEditProyectoCalificacion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditProyectoCalificacionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ProyectoCalificacion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditProyectoCalificacion" runat="server">             
                <asp:UpdatePanel ID="upEditProyectoCalificacion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditProyectoCalificacionrunat="server" ID="editProyectoCalificacion" ></uc:EditProyectoCalificacion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionProyectoCalificacion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProyectoCalificacion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnProyectoCalificacion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditProyectoCalificacion" runat="server" CancelControlID="btPnProyectoCalificacion" 
					PopupDragHandleControlID="pnPopUpEditProyectoCalificacionDragHandle" PopupControlID="pnPopUpEditProyectoCalificacion"
					OkControlID="Button2" TargetControlID="btPnProyectoCalificacion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ProyectoCalificacion -->            
           </td>
        </tr>
    </table>
</asp:Content>
