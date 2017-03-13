<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="GeoreferenciacionPuntoPageList.aspx.cs" Inherits="UI.Web.GeoreferenciacionPuntoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterGeoreferenciacionPunto" Src="GeoreferenciacionPuntoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListGeoreferenciacionPunto" Src="GeoreferenciacionPuntoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditGeoreferenciacionPunto" Src="GeoreferenciacionPuntoEdit.ascx" %>
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
                               <uc:FilterGeoreferenciacionPunto runat="server" ID="ftGeoreferenciacionPunto" ></uc:FilterGeoreferenciacionPunto>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar GeoreferenciacionPunto" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Está seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterGeoreferenciacionPunto" ></uc:PaggingButtons ></td>
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
                       <uc:ListGeoreferenciacionPunto runat="server" ID="lstGeoreferenciacionPunto" ></uc:ListGeoreferenciacionPunto >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT GeoreferenciacionPunto-->
            <asp:Panel ID="pnPopUpEditGeoreferenciacionPunto" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditGeoreferenciacionPuntoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n GeoreferenciacionPunto</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditGeoreferenciacionPunto" runat="server">             
                <asp:UpdatePanel ID="upEditGeoreferenciacionPunto" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditGeoreferenciacionPuntorunat="server" ID="editGeoreferenciacionPunto" ></uc:EditGeoreferenciacionPunto>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionGeoreferenciacionPunto" runat="server" DisplayMode="BulletList" ValidationGroup="EditionGeoreferenciacionPunto" ShowSummary="False" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnGeoreferenciacionPunto" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditGeoreferenciacionPunto" runat="server" CancelControlID="btPnGeoreferenciacionPunto" 
					PopupDragHandleControlID="pnPopUpEditGeoreferenciacionPuntoDragHandle" PopupControlID="pnPopUpEditGeoreferenciacionPunto"
					OkControlID="Button2" TargetControlID="btPnGeoreferenciacionPunto" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT GeoreferenciacionPunto -->            
           </td>
        </tr>
    </table>
</asp:Content>
