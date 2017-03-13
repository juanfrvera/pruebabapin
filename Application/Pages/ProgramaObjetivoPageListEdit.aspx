<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="ProgramaObjetivoPageList.aspx.cs" Inherits="UI.Web.ProgramaObjetivoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterProgramaObjetivo" Src="ProgramaObjetivoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListProgramaObjetivo" Src="ProgramaObjetivoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditProgramaObjetivo" Src="ProgramaObjetivoEdit.ascx" %>
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
                               <uc:FilterProgramaObjetivo runat="server" ID="ftProgramaObjetivo" ></uc:FilterProgramaObjetivo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar ProgramaObjetivo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick='<%#  "return confirm(\""+ConfirmDeleteMessage+"\")" %>' OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterProgramaObjetivo" ></uc:PaggingButtons ></td>
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
                       <uc:ListProgramaObjetivo runat="server" ID="lstProgramaObjetivo" ></uc:ListProgramaObjetivo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT ProgramaObjetivo-->
            <asp:Panel ID="pnPopUpEditProgramaObjetivo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditProgramaObjetivoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n ProgramaObjetivo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditProgramaObjetivo" runat="server">             
                <asp:UpdatePanel ID="upEditProgramaObjetivo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditProgramaObjetivorunat="server" ID="editProgramaObjetivo" ></uc:EditProgramaObjetivo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionProgramaObjetivo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionProgramaObjetivo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnProgramaObjetivo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditProgramaObjetivo" runat="server" CancelControlID="btPnProgramaObjetivo" 
					PopupDragHandleControlID="pnPopUpEditProgramaObjetivoDragHandle" PopupControlID="pnPopUpEditProgramaObjetivo"
					OkControlID="Button2" TargetControlID="btPnProgramaObjetivo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT ProgramaObjetivo -->            
           </td>
        </tr>
    </table>
</asp:Content>
