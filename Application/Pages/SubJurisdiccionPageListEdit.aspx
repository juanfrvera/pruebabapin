<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="SubJurisdiccionPageList.aspx.cs" Inherits="UI.Web.SubJurisdiccionPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterSubJurisdiccion" Src="SubJurisdiccionFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListSubJurisdiccion" Src="SubJurisdiccionList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditSubJurisdiccion" Src="SubJurisdiccionEdit.ascx" %>
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
                               <uc:FilterSubJurisdiccion runat="server" ID="ftSubJurisdiccion" ></uc:FilterSubJurisdiccion>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar SubJurisdiccion" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterSubJurisdiccion" ></uc:PaggingButtons ></td>
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
                       <uc:ListSubJurisdiccion runat="server" ID="lstSubJurisdiccion" ></uc:ListSubJurisdiccion >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT SubJurisdiccion-->
            <asp:Panel ID="pnPopUpEditSubJurisdiccion" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditSubJurisdiccionDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n SubJurisdiccion</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditSubJurisdiccion" runat="server">             
                <asp:UpdatePanel ID="upEditSubJurisdiccion" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditSubJurisdiccionrunat="server" ID="editSubJurisdiccion" ></uc:EditSubJurisdiccion>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionSubJurisdiccion" runat="server" DisplayMode="BulletList" ValidationGroup="EditionSubJurisdiccion" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnSubJurisdiccion" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditSubJurisdiccion" runat="server" CancelControlID="btPnSubJurisdiccion" 
					PopupDragHandleControlID="pnPopUpEditSubJurisdiccionDragHandle" PopupControlID="pnPopUpEditSubJurisdiccion"
					OkControlID="Button2" TargetControlID="btPnSubJurisdiccion" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT SubJurisdiccion -->            
           </td>
        </tr>
    </table>
</asp:Content>
