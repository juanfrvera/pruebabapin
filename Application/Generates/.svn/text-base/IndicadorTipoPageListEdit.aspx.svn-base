<%@ Page Title="" Language="C#" MasterPageFile="~/App_Shared/General.Master" AutoEventWireup="true" CodeBehind="IndicadorTipoPageList.aspx.cs" Inherits="UI.Web.IndicadorTipoPageList" %>
<%@ Register Assembly="System.Web.Entity, Version=3.5.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>
<%@ Register Tagprefix="uc"  TagName="FilterIndicadorTipo" Src="IndicadorTipoFilter.ascx" %>
<%@ Register Tagprefix="uc"  TagName="ListIndicadorTipo" Src="IndicadorTipoList.ascx" %>
<%@ Register Tagprefix="uc"  TagName="EditIndicadorTipo" Src="IndicadorTipoEdit.ascx" %>
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
                               <uc:FilterIndicadorTipo runat="server" ID="ftIndicadorTipo" ></uc:FilterIndicadorTipo>
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
								&nbsp;<asp:Button  ID ="btTransferencia"  Enabled="false" runat = "server" Text="Agregar IndicadorTipo" OnClick ="btNew_Click"  /> 
                                &nbsp;<asp:Button  ID ="btEdit"   runat = "server" Text="Editar" OnClick ="btEdit_Click" /> 
                                &nbsp;<asp:Button  ID ="btView"  runat = "server" Text="Ver" OnClick ="btView_Click" /> 
                                &nbsp;<asp:Button  ID ="btDelete" runat = "server"   Text="Cancelar" OnClientClick="return confirm('Esta seguro de eliminar?');" OnClick ="btDelete_Click"/>                                 
                            </td>
                            <td align="right" ><uc:PaggingButtons runat="server" ID="pgButtons"  SearchVisible="true" ValidationGroup="FilterIndicadorTipo" ></uc:PaggingButtons ></td>
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
                       <uc:ListIndicadorTipo runat="server" ID="lstIndicadorTipo" ></uc:ListIndicadorTipo >
                    </ContentTemplate>
                </asp:UpdatePanel>
            </td>
        </tr>
		 <tr>
           <td>
           <!-- BEGIN EDIT IndicadorTipo-->
            <asp:Panel ID="pnPopUpEditIndicadorTipo" runat="server" Width="800px" Style="background-color: #ffffff; border: solid 2px #ffffff; border-color: Gray;">
            <asp:Panel ID="pnPopUpEditIndicadorTipoDragHandle" runat="server" Style="cursor: move;">
            <table width="100%" cellpadding="0" cellspacing="5">
                <tr class="menutop" >
                    <th align="center" height="10">Edici&oacute;n IndicadorTipo</th>                    
                </tr>
            </table>
            </asp:Panel>
            <asp:Panel ID="pnEditIndicadorTipo" runat="server">             
                <asp:UpdatePanel ID="upEditIndicadorTipo" runat="server" UpdateMode="Conditional" >
                <ContentTemplate>
                <table >	             
                <tr>
                    <td>                      
                        <uc:EditIndicadorTiporunat="server" ID="editIndicadorTipo" ></uc:EditIndicadorTipo>                           
                    </td>
                </tr>               
               
                <tr>
                    <td>
                        <asp:ValidationSummary id="vsEditionIndicadorTipo" runat="server" DisplayMode="BulletList" ValidationGroup="EditionIndicadorTipo" ShowSummary="false" ShowMessageBox="True"></asp:ValidationSummary>
                    </td>
                </tr>		
                </table>
                </ContentTemplate>
                </asp:UpdatePanel>
            </asp:Panel>
            <asp:Button ID="btPnIndicadorTipo" runat="server" Text="Button" Style="display: none" />
            <ajaxToolkit:ModalPopupExtender ID="ModalPopupExtenderEditIndicadorTipo" runat="server" CancelControlID="btPnIndicadorTipo" 
					PopupDragHandleControlID="pnPopUpEditIndicadorTipoDragHandle" PopupControlID="pnPopUpEditIndicadorTipo"
					OkControlID="Button2" TargetControlID="btPnIndicadorTipo" BackgroundCssClass="modalBackground" />
            </asp:Panel>
            <!--END EDIT IndicadorTipo -->            
           </td>
        </tr>
    </table>
</asp:Content>
