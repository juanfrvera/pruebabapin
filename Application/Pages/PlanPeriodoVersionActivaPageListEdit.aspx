<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="PlanPeriodoVersionActivaPageList.aspx.cs" Inherits="UI.Web.PlanPeriodoVersionActivaPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterPlanPeriodoVersionActiva" Src="PlanPeriodoVersionActivaFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListPlanPeriodoVersionActiva" Src="PlanPeriodoVersionActivaList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditPlanPeriodoVersionActiva" Src="PlanPeriodoVersionActivaEdit.ascx" %>
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
                               <uc:FilterPlanPeriodoVersionActiva runat="server" ID="ftPlanPeriodoVersionActiva" ></uc:FilterPlanPeriodoVersionActiva>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar PlanPeriodoVersionActiva" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterPlanPeriodoVersionActiva" ></uc:PaggingButtons ></td>
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
                       <uc:ListPlanPeriodoVersionActiva runat="server" ID="lstPlanPeriodoVersionActiva" ></uc:ListPlanPeriodoVersionActiva >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT PlanPeriodoVersionActiva-->
            <asp:Panel ID="pnPopUpEditPlanPeriodoVersionActiva" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditPlanPeriodoVersionActivaDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n PlanPeriodoVersionActiva</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditPlanPeriodoVersionActiva" runat="server">             
                <asp:UpdatePanel ID="upEditPlanPeriodoVersionActiva" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditPlanPeriodoVersionActivarunat="server" ID="editPlanPeriodoVersionActiva" ></uc:EditPlanPeriodoVersionActiva>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionPlanPeriodoVersionActiva" runat="server" DisplayMode="BulletList" ValidationGroup="EditionPlanPeriodoVersionActiva" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnPlanPeriodoVersionActiva" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditPlanPeriodoVersionActiva" runat="server" CancelControlID="btPnPlanPeriodoVersionActiva" 
					PopupDragHandleControlID="pnPopUpEditPlanPeriodoVersionActivaDragHandle" PopupControlID="pnPopUpEditPlanPeriodoVersionActiva"
					OkControlID="Button2" TargetControlID="btPnPlanPeriodoVersionActiva" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT PlanPeriodoVersionActiva -->            
           </td>
        </tr>
    </table>
</asp:Content>
