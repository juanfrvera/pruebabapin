<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SistemaCommandPageList.aspx.cs" Inherits="UI.Web.SistemaCommandPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSistemaCommand" Src="SistemaCommandFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSistemaCommand" Src="SistemaCommandList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSistemaCommand" Src="SistemaCommandEdit.ascx" %>
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
                               <uc:FilterSistemaCommand runat="server" ID="ftSistemaCommand" ></uc:FilterSistemaCommand>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar SistemaCommand" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Está seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSistemaCommand" ></uc:PaggingButtons ></td>
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
                       <uc:ListSistemaCommand runat="server" ID="lstSistemaCommand" ></uc:ListSistemaCommand >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT SistemaCommand-->
            <asp:Panel ID="pnPopUpEditSistemaCommand" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSistemaCommandDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n SistemaCommand</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSistemaCommand" runat="server">             
                <asp:UpdatePanel ID="upEditSistemaCommand" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSistemaCommandrunat="server" ID="editSistemaCommand" ></uc:EditSistemaCommand>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSistemaCommand" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSistemaCommand" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSistemaCommand" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSistemaCommand" runat="server" CancelControlID="btPnSistemaCommand" 
					PopupDragHandleControlID="pnPopUpEditSistemaCommandDragHandle" PopupControlID="pnPopUpEditSistemaCommand"
					OkControlID="Button2" TargetControlID="btPnSistemaCommand" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT SistemaCommand -->            
           </td>
        </tr>
    </table>
</asp:Content>
